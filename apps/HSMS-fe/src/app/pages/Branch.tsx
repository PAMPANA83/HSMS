import { Table, Card, Button, Modal, Form, Input, Select, DatePicker, message, Spin, Row, Col} from "antd";
import { useEffect, useState } from "react";
import { BranchMastersDto, CreateBranchDto } from "../models/Branch.dto";
import { DeleteOutlined, EditOutlined } from "@ant-design/icons";
import {getBranch,createBranch,deleteBranch} from "../services/Branch.service";
import { getCompany } from "../services/Company.service";
import{getState} from "../services/State.service";
import{getDistrictsByState} from "../services/District.service";
import{getCitiesByDistrict} from "../services/City.service";
import{getAreasByCity} from "../services/Area.service";

export function Branch() {
  const [data, setData] = useState<BranchMastersDto[]>([]);
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm<CreateBranchDto>();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isEditMode, setIsEditMode] = useState(false);
  const [editingBranch, setEditingBranch] = useState<BranchMastersDto | null>(null);

  // Location states
  const [states, setStates] = useState<{ id: number; stateName: string }[]>([]);
  const [districts, setDistricts] = useState<{ id: number; districtName: string }[]>([]);
  const [cities, setCities] = useState<{ id: number; cityName: string }[]>([]);
  const [areas, setAreas] = useState<{ id: number; areaName: string }[]>([]);
  const [companies, setCompanies] = useState<{ id: number; companyName: string }[]>([]);
  
  const [locationLoading, setLocationLoading] = useState(false);

  const loadBranches = async () => {
    setLoading(true);
    try {
      const result = await getBranch();
      setData(result);
    } catch (error: any) {
      message.error("Failed to load branches");
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

const loadCompanies = async () => {
    setLoading(true);
    try {
      const result = await getCompany();
      setCompanies(result);
      console.log("Companies loaded");
    } catch (error: any) {
      console.error("Load error:", error);
      message.error("Failed to load companies");
    }
    setLoading(false);
  };

  const loadDistricts = async (stateId: number) => {
    setLocationLoading(true);
    try {
      const result = await getDistrictsByState(stateId);
      setDistricts(result);
      form.setFieldsValue({ districtID: undefined, cityID: undefined, areaID: undefined });
      setCities([]);
      setAreas([]);
    } catch {
      setDistricts([]);
    }
    setLocationLoading(false);
  };

  const loadCities = async (districtId: number) => {
    setLocationLoading(true);
    try {
      const result = await getCitiesByDistrict(districtId);
      setCities(result);
      form.setFieldsValue({ cityID: undefined, areaID: undefined });
      setAreas([]);
    } catch {
      setCities([]);
    }
    setLocationLoading(false);
  };

  const loadAreas = async (cityId: number) => {
    setLocationLoading(true);
    try {
      const result = await getAreasByCity(cityId);
      setAreas(result);
    } catch {
      setAreas([]);
    }
    setLocationLoading(false);
  };

  useEffect(() => {
    loadBranches();
    loadStates();
    loadCompanies();
  }, []);

  const handleCreateOrUpdate = async (values: CreateBranchDto & { id?: number }) => {
    try {
      if (isEditMode && editingBranch?.id) {
        // Update branch (you'll need UpdateBranchDto service)
        // await updateBranch({ id: editingBranch.id, ...values });
        message.success("Branch updated successfully");
      } else {
        await createBranch(values);
        message.success("Branch created successfully");
      }
      form.resetFields();
      setIsModalOpen(false);
      setIsEditMode(false);
      setEditingBranch(null);
      loadBranches();
    } catch (error: any) {
      message.error(error.response?.data?.message || "Operation failed");
    }
  };

  const handleEdit = (record: BranchMastersDto) => {
    setEditingBranch(record);
    setIsEditMode(true);
    setIsModalOpen(true);
    
    // Populate form with existing data
    form.setFieldsValue({
      branchID: record.branchID,
      branchName: record.branchName,
      branchHeader: record.branchHeader,
      registerName: record.registerName,
      labHeader: record.labHeader,
      companyID: record.companyID,
      address: record.address,
      stateID: record.stateID,
      districtID: record.districtID,
      cityID: record.cityID,
      areaID: record.areaID,
      mobile1: record.mobile1,
      mobile2: record.mobile2,
      phone: record.phone,
      contactPerson: record.contactPerson,
    });

    // Load cascading data
    if (record.stateID) loadDistricts(record.stateID);
    if (record.districtID && record.stateID) loadCities(record.districtID);
    if (record.cityID && record.districtID) loadAreas(record.cityID);
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete Branch?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
        await deleteBranch(id);
        message.success("Branch deleted successfully");
        loadBranches();
      } catch (error: any) {
        message.error("Delete failed");
      }
    }
  };

  return (
    <Card 
      title="Branch Management" 
      extra={
        <Button type="primary" onClick={() => {
          setIsModalOpen(true);
          setIsEditMode(false);
          setEditingBranch(null);
          form.resetFields();
        }}>
          Add Branch
        </Button>
      }
    >
      <Spin spinning={loading}>
        <Table<BranchMastersDto>
          rowKey="id"
          columns={[
            { title: "Branch ID", dataIndex: "branchID", width: 120 },
            { title: "Branch Name", dataIndex: "branchName", ellipsis: true },
            { 
              title: "Company", 
              render: (_, record) => record.companyID?.toString() || '-',
              width: 120 
            },
            { 
              title: "Address", 
              dataIndex: "address",
              render: (addr: string) => addr?.substring(0, 30) + (addr?.length! > 30 ? '...' : ''),
              ellipsis: true 
            },
            { title: "Mobile 1", dataIndex: "mobile1", width: 120 },
            { title: "Contact", dataIndex: "contactPerson", width: 120 },
            { 
              title: "Created", 
              dataIndex: "createDate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-',
              width: 120 
            },
            {
              title: "Actions",
              width: 120,
              render: (_, record) => (
                <>
                  <Button 
                    type="text" 
                    icon={<EditOutlined />} 
                    size="small"
                    onClick={() => handleEdit(record)}
                    style={{ marginRight: 8 }}
                  />
                  <Button 
                    type="text" 
                    danger 
                    icon={<DeleteOutlined />} 
                    size="small"
                    onClick={() => handleDelete(record.id!)}
                  />
                </>
              ),
            },
          ]}
          dataSource={data}
          pagination={{ pageSize: 10 }}
        />
      </Spin>

      {/* Branch Form Modal */}
  <Modal
  title={isEditMode ? "Edit Branch" : "Create Branch"}
  open={isModalOpen}
  width={1000}
  onCancel={() => {
    setIsModalOpen(false);
    setIsEditMode(false);
    setEditingBranch(null);
    form.resetFields();
  }}
  footer={null}
>
  <Form<CreateBranchDto>
    form={form}
    layout="vertical"
    onFinish={handleCreateOrUpdate}
  >
    {/* Row 1 */}
    <Row gutter={16}>
      <Col span={8}>
        <Form.Item label="Branch ID" name="branchID" rules={[{ required: true }]}>
          <Input placeholder="e.g. BR001" />
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="Branch Name" name="branchName" rules={[{ required: true }]}>
          <Input placeholder="e.g. Main Branch" />
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="Company" name="companyID" rules={[{ required: true }]}>
          <Select placeholder="Select company" loading={loading}>
            {companies.map((company) => (
              <Select.Option key={company.id} value={company.id}>
                {company.companyName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>
    </Row>

    {/* Row 2 */}
    <Row gutter={16}>
      <Col span={8}>
        <Form.Item label="State" name="stateID" rules={[{ required: true }]}>
          <Select
            placeholder="Select state"
            loading={locationLoading}
            onChange={(value) => {
              form.setFieldsValue({ districtID: undefined, cityID: undefined, areaID: undefined });
              if (value) loadDistricts(value as number);
            }}
          >
            {states.map((state) => (
              <Select.Option key={state.id} value={state.id}>
                {state.stateName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="District" name="districtID" rules={[{ required: true }]}>
          <Select
            placeholder="Select district"
            disabled={!districts.length}
            loading={locationLoading}
            onChange={(value) => {
              form.setFieldsValue({ cityID: undefined, areaID: undefined });
              if (value) loadCities(value as number);
            }}
          >
            {districts.map((district) => (
              <Select.Option key={district.id} value={district.id}>
                {district.districtName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="City" name="cityID" rules={[{ required: true }]}>
          <Select
            placeholder="Select city"
            disabled={!cities.length}
            loading={locationLoading}
            onChange={(value) => {
              form.setFieldsValue({ areaID: undefined });
              if (value) loadAreas(value as number);
            }}
          >
            {cities.map((city) => (
              <Select.Option key={city.id} value={city.id}>
                {city.cityName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>
    </Row>

    {/* Row 3 */}
    <Row gutter={16}>
      <Col span={8}>
        <Form.Item label="Area" name="areaID" rules={[{ required: true }]}>
          <Select
            placeholder="Select area"
            disabled={!areas.length}
            loading={locationLoading}
          >
            {areas.map((area) => (
              <Select.Option key={area.id} value={area.id}>
                {area.areaName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="Mobile 1" name="mobile1">
          <Input placeholder="e.g. 9876543210" />
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="Mobile 2" name="mobile2">
          <Input placeholder="e.g. 9876543211" />
        </Form.Item>
      </Col>
    </Row>

    {/* Row 4 */}
    <Row gutter={16}>
      <Col span={8}>
        <Form.Item label="Phone" name="phone">
          <Input placeholder="e.g. 080-12345678" />
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="Contact Person" name="contactPerson">
          <Input placeholder="e.g. John Doe" />
        </Form.Item>
      </Col>

      <Col span={8}>
        <Form.Item label="Branch Header" name="branchHeader">
          <Input placeholder="Header text" />
        </Form.Item>
      </Col>
    </Row>

    {/* Address Full Width */}
    <Row>
      <Col span={24}>
        <Form.Item label="Address" name="address" rules={[{ required: true }]}>
          <Input.TextArea rows={3} placeholder="Full branch address" />
        </Form.Item>
      </Col>
    </Row>

    {/* Buttons */}
    <Row gutter={16}>
      <Col span={12}>
        <Button type="primary" htmlType="submit" block loading={locationLoading}>
          {isEditMode ? "Update Branch" : "Create Branch"}
        </Button>
      </Col>
      <Col span={12}>
        <Button
          block
          onClick={() => {
            form.resetFields();
            setIsModalOpen(false);
            setIsEditMode(false);
            setEditingBranch(null);
          }}
        >
          Cancel
        </Button>
      </Col>
    </Row>
  </Form>
</Modal>
    </Card>
  );
}
