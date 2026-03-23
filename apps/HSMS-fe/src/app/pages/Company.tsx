import { Table, Card, Button, Modal, Form, Input, Select, DatePicker, message, Spin } from "antd";
import { useEffect, useState } from "react";
import { CompanyMastersDto, CreateCompanyDto } from "../models/Company.dto";
import { DeleteOutlined } from "@ant-design/icons";
import{getCompany,createCompany} from "../services/Company.service";
import{getAllArea} from "../services/Area.service";
import{getState} from "../services/State.service";
import{getDistrictsByState} from "../services/District.service";
import{getCitiesByDistrict} from "../services/City.service";
import{getAreasByCity} from "../services/Area.service";

export function Company() {
  const [data, setData] = useState<CompanyMastersDto[]>([]);
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm<CreateCompanyDto>();
  const [isModalOpen, setIsModalOpen] = useState(false);
 const [states, setStates] = useState<{ id: number; stateName: string }[]>([]);
  const [districts, setDistricts] = useState<{ id: number; districtName: string }[]>([]);
  const [cities, setCities] = useState<{ id: number; cityName: string }[]>([]);
  const [areas, setAreas] = useState<{ id: number; areaName: string }[]>([]);

  const loadCompanies = async () => {
    setLoading(true);
    try {
      const result = await getCompany();
       setData(result);
      console.log("Companies loaded");
    } catch (error: any) {
      console.error("Load error:", error);
      message.error("Failed to load companies");
    }
    setLoading(false);
  };

    const loadStates = async () => {
    try {
      const result = await getState();
      setStates(result);
    } catch {
      message.error("Failed to load states");
    }
  };

  const loadAreas = async () => {
    try {
       const areasResult = await getAllArea();
       setAreas(areasResult);
      console.log("Areas loaded for dropdown");
    } catch {
      message.error("Failed to load areas");
    }
  };

    const loadDistricts = async (stateId: number) => {
    setLoading(true);
    try {
      const result = await getDistrictsByState(stateId);
      setDistricts(result);
      // Reset dependent fields
      form.setFieldsValue({ cityID: undefined, areaID: undefined });
      setCities([]);
      setAreas([]);
    } catch {
      message.error("Failed to load districts");
      setDistricts([]);
    }
    setLoading(false);
  };

  const loadCities = async (districtId: number) => {
    setLoading(true);
    try {
      const result = await getCitiesByDistrict(districtId);
      setCities(result);
      // Reset dependent field
      form.setFieldsValue({ areaID: undefined });
      setAreas([]);
    } catch {
      message.error("Failed to load cities");
      setCities([]);
    }
    setLoading(false);
  };
 const loadAreasByCity = async (cityId: number) => {
    setLoading(true);
    try {
      const result = await getAreasByCity(cityId);
      setAreas(result);
    } catch {
      message.error("Failed to load areas");
      setAreas([]);
    }
    setLoading(false);
  };

  useEffect(() => {
    loadStates();
    loadAreas();
    loadCompanies();
  }, []);

  const handleCreate = async (values: CreateCompanyDto) => {
    try {
       await createCompany( values );
      console.log("Create response:", values);
      message.success("Company created successfully");
      form.resetFields();
      setIsModalOpen(false);
      loadCompanies();
    } catch (error: any) {
      console.error("Create error:", error);
      message.error(error.response?.data?.message || "Create failed");
    }
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete Company?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
        // const res = await deleteCompany(id);
        console.log("Delete response for ID:", id);
        message.success("Company deleted successfully");
        loadCompanies();
      } catch (error: any) {
        console.error("Delete error:", error);
        message.error("Delete failed");
      }
    }
  };

  return (
    <Card 
      title="Company List" 
      extra={<Button type="primary" onClick={() => setIsModalOpen(true)}>Add Company</Button>}
    >
      <Spin spinning={loading}>
        <Table
          rowKey="id"
          columns={[
            { title: "Company", dataIndex: "companyName" },
            { title: "Code", dataIndex: "companyCode" },
            { 
              title: "Install Date", 
              dataIndex: "installationDate",
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-'
            },
            { 
              title: "Address", 
              dataIndex: "address",
              render: (addr: string) => addr?.substring(0, 30) + (addr?.length > 30 ? '...' : '')
            },
            { title: "Mobile 1", dataIndex: "mobile1" },
            { title: "Mobile 2", dataIndex: "mobile2" },
            { title: "Phone", dataIndex: "phone" },
            { title: "Contact", dataIndex: "contactPerson" },
            { 
              title: "Created", 
              dataIndex: "createDate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            {
              title: "Actions",
              width: 100,
              render: (_: any, record: CompanyMastersDto) => (
                <Button 
                  type="text" 
                  danger 
                  icon={<DeleteOutlined />} 
                  size="small"
                  onClick={() => handleDelete(record.id!)}
                />
              ),
            },
          ]}
          dataSource={data}
        />
      </Spin>

      {/* Create Company Modal */}
    <Modal title="Create Company" open={isModalOpen} onCancel={() => {
  setIsModalOpen(false);
  form.resetFields();
}} footer={null} width={900}>
  <Form<CreateCompanyDto> form={form} layout="vertical" onFinish={handleCreate}>
    {/* Row 1: Company ID + State */}
    <div style={{ display: 'flex', gap: 16 }}>
      <div style={{ flex: 1 }}>
        <Form.Item label="Company ID" name="companyID" rules={[{ required: true }]}>
          <Input placeholder="e.g. COMP001" />
        </Form.Item>
        
       
      </div>

      <div style={{ flex: 1 }}>

         <Form.Item label="Company Name" name="companyName" rules={[{ required: true }]}>
          <Input placeholder="e.g. ABC Corporation" />
        </Form.Item>
        
      </div>
    </div>

    {/* Row 2: Company Code + District */}
    <div style={{ display: 'flex', gap: 16 }}>
      <div style={{ flex: 1 }}>
        <Form.Item label="Company Code" name="companyCode" rules={[{ required: true }]}>
          <Input type="number" placeholder="e.g. 1001" />
        </Form.Item>
        
    
      </div>

      <div style={{ flex: 1 }}>

            <Form.Item label="Installation Date" name="installationDate">
          <DatePicker style={{ width: '100%' }} />
        </Form.Item>
        
      </div>
    </div>

    {/* Row 3: City + Area */}
    <div style={{ display: 'flex', gap: 16 }}>
      <div style={{ flex: 1 }}>
        <Form.Item label="State" name="stateID" rules={[{ required: true }]}>
          <Select 
            placeholder="Select state" 
            onChange={(value) => {
              form.setFieldsValue({ districtID: undefined, cityID: undefined, areaID: undefined });
              loadDistricts(value);
            }}
          >
            {states.map(state => (
              <Select.Option key={state.id} value={state.id}>{state.stateName}</Select.Option>
            ))}
          </Select>
        </Form.Item>

       
      </div>

      <div style={{ flex: 1 }}>

        <Form.Item label="District" name="districtID" rules={[{ required: true }]}>
          <Select 
            placeholder="Select district" 
            disabled={!districts.length}
            onChange={(value) => {
              form.setFieldsValue({ cityID: undefined, areaID: undefined });
              loadCities(value);
            }}
          >
            {districts.map(district => (
              <Select.Option key={district.id} value={district.id}>{district.districtName}</Select.Option>
            ))}
          </Select>
        </Form.Item>
       
      </div>
    </div>



    <div style={{ display: 'flex', gap: 16 }}>
      <div style={{ flex: 1 }}>
         <Form.Item label="City" name="cityID" rules={[{ required: true }]}>
          <Select 
            placeholder="Select city" 
            disabled={!cities.length}
            onChange={(value) => {
              form.setFieldsValue({  areaID: undefined });
              loadAreasByCity (value);
            }}
          >
            {cities.map(city => (
              <Select.Option key={city.id} value={city.id}>{city.cityName}</Select.Option>
            ))}
          </Select>
        </Form.Item>
       
      </div>

      <div style={{ flex: 1 }}>

         <Form.Item label="Area" name="areaID" rules={[{ required: true }]}>
          <Select placeholder="Select area" disabled={!areas.length} loading={loading}>
            {areas.map(area => (
              <Select.Option key={area.id} value={area.id}>{area.areaName}</Select.Option>
            ))}
          </Select>
        </Form.Item>
       
      </div>
    </div>

    {/* Address & Contacts (same as before) */}
    <Form.Item label="Address" name="address" rules={[{ required: true }]}>
      <Input.TextArea rows={3} placeholder="Full address" />
    </Form.Item>

    <div style={{ display: 'flex', gap: 16 }}>
      <Form.Item label="Mobile 1" name="mobile1" style={{ flex: 1 }}>
        <Input placeholder="e.g. 9876543210" />
      </Form.Item>
      <Form.Item label="Mobile 2" name="mobile2" style={{ flex: 1 }}>
        <Input placeholder="e.g. 9876543211" />
      </Form.Item>
    </div>

    <div style={{ display: 'flex', gap: 16 }}>
      <Form.Item label="Phone" name="phone" style={{ flex: 1 }}>
        <Input placeholder="e.g. 080-12345678" />
      </Form.Item>
      <Form.Item label="Contact Person" name="contactPerson" style={{ flex: 1 }}>
        <Input placeholder="e.g. John Doe" />
      </Form.Item>
    </div>

    <div style={{ display: 'flex', gap: 8, marginTop: 16 }}>
      <Button type="primary" htmlType="submit" style={{ flex: 1 }}>Create Company</Button>
      <Button onClick={() => { form.resetFields(); setIsModalOpen(false); }} style={{ flex: 1 }}>
        Clear & Close
      </Button>
    </div>
  </Form>
</Modal>

    </Card>
  );
}
