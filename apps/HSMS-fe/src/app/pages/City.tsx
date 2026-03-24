import { Table, Card, Button, Modal, Form, Input, Select, message, Spin } from "antd";
import { useEffect, useState } from "react";
import {CityMastersDto,CreateCityDto} from "../models/City.dto"
import { DeleteOutlined } from "@ant-design/icons";
import{deleteCity,getCity,createCity} from "../services/City.service"
import{getDistrict} from "../services/District.service"


export function City() {

     const [data, setData] = useState<CityMastersDto[]>([]);
    const [loading, setLoading] = useState(false);
  const [form] = Form.useForm<CreateCityDto>();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [districts, setDistricts] = useState<{ id: number; districtName: string }[]>([]);

   const loadCities = async () => {
    setLoading(true);
    try {
      const result = await getCity();
      setData(result);
      console.log("Cities loaded");
    } catch (error: any) {
      console.error("Load error:", error);
      message.error("Failed to load cities");
    }
    setLoading(false);
  };

  const loadDistricts = async () => {
    try {
      const districtsResult = await getDistrict();
       setDistricts(districtsResult);
      console.log("Districts loaded for dropdown");
    } catch {
      message.error("Failed to load districts");
    }
  };

  useEffect(() => {
    loadDistricts();
    loadCities();
  }, []);

  const handleCreate = async (values: CreateCityDto) => {
    try {
       await createCity(values);
      console.log("Create response:", { cityName: values.cityName, districtID: values.districtID });
      message.success("City created successfully");
      form.resetFields();
      setIsModalOpen(false);
      loadCities();
    } catch (error: any) {
      console.error("Create error:", error);
      message.error(error.response?.data?.message || "Create failed");
    }
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete City?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
         const res = await deleteCity(id);
        console.log("Delete response for ID:", id);
        message.success("City deleted successfully"+res);
        loadCities();
      } catch (error: any) {
        console.error("Delete error:", error);
        message.error("Delete failed");
      }
    }
  };

  return (
     <Card style={{ padding: 0 }}>
      {/* Header */}
      <div className="panel-heading" style={{
        backgroundColor: "#3c8dbc",
        padding: "10px 20px",
        color: "white",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        margin: "-24px -24px 24px -24px",
        borderRadius: "6px 6px 0 0",
      }}>
        <label style={{ fontSize: "large", fontWeight: "bold", margin: 0 }}>
          City Master
        </label>
        <Button
          type="link"
          style={{ color: "white", fontWeight: "bold", padding: 0, height: "auto" }}
          onClick={() => setIsModalOpen(true)}
        >
          Add City
        </Button>
      </div>
  
      <Spin spinning={loading}>
        <Table
          rowKey="id"
          columns={[
            { title: "City", dataIndex: "cityName" },
            { title: "City ID", dataIndex: "cityID" },
            { title: "District NAME", dataIndex: "districtName" },
            { 
              title: "Created", 
              dataIndex: "createdate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            { 
              title: "Edited", 
              dataIndex: "editdate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            {
              title: "Actions",
              width: 100,
              render: (_: any, record: CityMastersDto) => (
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

      {/* Create City Modal */}
      <Modal
        title="Create City"
        open={isModalOpen}
        onCancel={() => {
          setIsModalOpen(false);
          form.resetFields();
        }}
        footer={null}
      >
        <Form<CreateCityDto> form={form} layout="vertical" onFinish={handleCreate}>

        <Form.Item
            label="City ID"
            name="cityID"
            rules={[{ required: true, message: "Enter city ID" }]}
          >
            <Input placeholder="e.g. Bengaluru" />
          </Form.Item>
          <Form.Item
            label="City Name"
            name="cityName"
            rules={[{ required: true, message: "Enter city name" }]}
          >
            <Input placeholder="e.g. Bengaluru" />
          </Form.Item>

          <Form.Item
            label="District"
            name="districtID"
            rules={[{ required: true, message: "Select district" }]}
          >
            <Select placeholder="Select district" loading={loading}>
              {districts.map(district => (
                <Select.Option key={district.id} value={district.id}>
                  {district.districtName}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>

          <div style={{ display: 'flex', gap: 8, marginTop: 16 }}>
            <Button type="primary" htmlType="submit" style={{ flex: 1 }}>
              Create City
            </Button>
            <Button 
              onClick={() => {
                form.resetFields();
                setIsModalOpen(false);
              }}
              style={{ flex: 1 }}
            >
              Clear & Close
            </Button>
          </div>
        </Form>
      </Modal>
    </Card>
  );
}
