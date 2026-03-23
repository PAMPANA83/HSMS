import { Table, Card, Button, Modal, Form, Input, Select, Switch, message, Spin,Row, Col  } from "antd";
import { useEffect, useState } from "react";
import { AreaMastersDto, CreateAreaDto } from "../models/Area.dto";
import { DeleteOutlined } from "@ant-design/icons";
import{getAllArea,createArea,deleteArea} from "../services/Area.service";
import{getCity} from "../services/City.service";
import{getBranch} from "../services/Branch.service";

export function Area() {
  const [data, setData] = useState<AreaMastersDto[]>([]);
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm<CreateAreaDto>();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [cities, setCities] = useState<{ id: number; cityName: string }[]>([]);
  const [branch,setBranchs]=useState<{id:number;branchName:string}[]>([]);

  const loadAreas = async () => {
    setLoading(true);
    try {
      const result = await getAllArea();
       setData(result);
      console.log("Areas loaded");
    } catch (error: any) {
      console.error("Load error:", error);
      message.error("Failed to load areas");
    }
    setLoading(false);
  };

   const loadDistrict = async () => {
    setLoading(true);
    try {
      const result = await getBranch();
       setBranchs(result);
      console.log("District loaded");
    } catch (error: any) {
      console.error("Load error:", error);
      message.error("Failed to load District");
    }
    setLoading(false);
  };

  const loadCities = async () => {
    try {
      const citiesResult = await getCity();
       setCities(citiesResult);
      console.log("Cities loaded for dropdown");
    } catch {
      message.error("Failed to load cities");
    }
  };

  useEffect(() => {
    loadCities();
    loadAreas();
    loadDistrict();
  }, []);

  const handleCreate = async (values: CreateAreaDto) => {
    try {
       await createArea(values);
      console.log("Create response:", values);
      message.success("Area created successfully");
      form.resetFields();
      setIsModalOpen(false);
      loadAreas();
    } catch (error: any) {
      console.error("Create error:", error);
      message.error(error.response?.data?.message || "Create failed");
    }
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete Area?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
         const res = await deleteArea(id);
        console.log("Delete response for ID:", id);
        message.success("Area deleted successfully");
        loadAreas();
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
          Area Master
        </label>
        <Button
          type="link"
          style={{ color: "white", fontWeight: "bold", padding: 0, height: "auto" }}
          onClick={() => setIsModalOpen(true)}
        >
          Add Area
        </Button>
      </div>
  
      <Spin spinning={loading}>
        <Table
          rowKey="id"
          columns={[
            { title: "Area", dataIndex: "areaName" },
            { title: "Area ID", dataIndex: "areaID" },
            { title: "PIN Code", dataIndex: "areaPINCode" },
            { title: "City NAME", dataIndex: "cityName" },
            { title: "Branch NAME", dataIndex: "districtName" },
            { 
              title: "Status", 
              dataIndex: "active",
              render: (active?: boolean) => active ? "Active" : "Inactive"
            },
            { 
              title: "Created", 
              dataIndex: "createDate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            {
              title: "Actions",
              width: 100,
              render: (_: any, record: AreaMastersDto) => (
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

      {/* Create Area Modal */}
    <Modal
  title="Create Area"
  open={isModalOpen}
  width={700} // optional: increase modal width
  onCancel={() => {
    setIsModalOpen(false);
    form.resetFields();
  }}
  footer={null}
>
  <Form<CreateAreaDto>
    form={form}
    layout="vertical"
    onFinish={handleCreate}
  >
    <Row gutter={16}>
      <Col span={12}>
        <Form.Item
          label="Area ID"
          name="areaID"
          rules={[{ required: true, message: "Enter area ID" }]}
        >
          <Input placeholder="e.g. SR" />
        </Form.Item>
      </Col>

      <Col span={12}>
        <Form.Item
          label="Area Name"
          name="areaName"
          rules={[{ required: true, message: "Enter area name" }]}
        >
          <Input placeholder="e.g. Jayanagar" />
        </Form.Item>
      </Col>
    </Row>

    <Row gutter={16}>
      <Col span={12}>
        <Form.Item
          label="PIN Code"
          name="areaPINCode"
          rules={[{ required: true, message: "Enter PIN code" }]}
        >
          <Input type="number" placeholder="e.g. 560011" />
        </Form.Item>
      </Col>

      <Col span={12}>
        <Form.Item
          label="City"
          name="cityID"
          rules={[{ required: true, message: "Select city" }]}
        >
          <Select placeholder="Select city" loading={loading}>
            {cities.map((city) => (
              <Select.Option key={city.id} value={city.id}>
                {city.cityName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>
    </Row>

    <Row gutter={16}>
      <Col span={12}>
        <Form.Item
          label="Branch"
          name="branchID"
          rules={[{ required: true, message: "Select Branch" }]}
        >
          <Select placeholder="Select Branch" loading={loading}>
            {branch.map((b) => (
              <Select.Option key={b.id} value={b.id}>
                {b.branchName}
              </Select.Option>
            ))}
          </Select>
        </Form.Item>
      </Col>

      <Col span={12}>
        <Form.Item label="Active" name="active" valuePropName="checked">
          <Switch />
        </Form.Item>
      </Col>
    </Row>

    <div style={{ display: "flex", gap: 8, marginTop: 16 }}>
      <Button type="primary" htmlType="submit" style={{ flex: 1 }}>
        Create Area
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
