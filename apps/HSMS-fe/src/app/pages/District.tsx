import { Table, Card, Button, Modal, Form, Input, Select, message, Spin } from "antd";
import { useEffect, useState } from "react";
import { DistrictMastersDto,CreateDistrictDto } from "../models/District.Dto";
import { DeleteOutlined } from "@ant-design/icons";
import{getDistrict,createDistrict,deleteDistrict} from "../services/District.service";
import{getState} from "../services/State.service"

export function District() {
  const [data, setData] = useState<DistrictMastersDto[]>([]);
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm<CreateDistrictDto>(); // ✅ Typed form
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [states, setStates] = useState<{ id: number; stateName: string }[]>([]);

  const loadDistricts = async () => {
    setLoading(true);
    try {
      const result = await getDistrict();
      setData(result);
      console.log("Districts loaded:", result);
    } catch (error: any) {
      console.error("Load error:", error);
      message.error("Failed to load districts");
    }
    setLoading(false);
  };

  const loadStates = async () => {
    try {
      // TODO: Add getStates service call
       const statesResult = await getState();
       setStates(statesResult);
      console.log("States loaded for dropdown");
    } catch {
      message.error("Failed to load states");
    }
  };

  useEffect(() => {
    loadStates();
    loadDistricts();
  }, []);

  const handleCreate = async (values: CreateDistrictDto) => {
    try {
      await createDistrict(values);
      console.log("Create response:", values);
      message.success("District created successfully");
      form.resetFields();
      setIsModalOpen(false);
      loadDistricts();
    } catch (error: any) {
      console.error("Create error:", error);
      message.error(error.response?.data?.message || "Create failed");
    }
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete District?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
        // TODO: Add deleteDistrict service call
        const res = await deleteDistrict(id);
        if(res.status=200)
        console.log("Delete response for ID:", id);
        message.success("District deleted successfully");
        loadDistricts();
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
          District Master
        </label>
        <Button
          type="link"
          style={{ color: "white", fontWeight: "bold", padding: 0, height: "auto" }}
          onClick={() => setIsModalOpen(true)}
        >
          Add District
        </Button>
      </div>
  
      <Spin spinning={loading}>
        <Table
          rowKey="id"
          columns={[
            { title: "District", dataIndex: "districtName" },
            { title: "District ID", dataIndex: "districtID" },
            { title: "State Name", dataIndex: "stateName" },
            { 
              title: "Created", 
              dataIndex: "createDate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            { 
              title: "Edited", 
              dataIndex: "editDate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            {
              title: "Actions",
              width: 100,
              render: (_: any, record: DistrictMastersDto) => (
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

      <Modal
        title="Create District"
        open={isModalOpen}
        onCancel={() => {
          setIsModalOpen(false);
          form.resetFields();
        }}
        footer={null}
      >
        <Form<CreateDistrictDto> form={form} layout="vertical" onFinish={handleCreate}>
          <Form.Item
            label="District Name"
            name="districtName"
            rules={[{ required: true, message: "Enter district name" }]}
          >
            <Input placeholder="e.g. Bengaluru Urban" />
          </Form.Item>

          <Form.Item
            label="State"
            name="stateID"
            rules={[{ required: true, message: "Select state" }]}
          >
            <Select placeholder="Select state" loading={loading}>
              {states.map(state => (
                <Select.Option key={state.id} value={state.id}>
                  {state.stateName}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>

          <div style={{ display: 'flex', gap: 8, marginTop: 16 }}>
            <Button type="primary" htmlType="submit" style={{ flex: 1 }}>
              Create District
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