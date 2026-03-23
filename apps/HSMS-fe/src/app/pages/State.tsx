import { Table, Card, Button, Modal, Form, Input, message, Spin,Select } from "antd";
import { useEffect, useState } from "react";
import { getState, createstate,deleteState } from "../services/State.service";
import { StateMastersDto,CreateStateMasters } from "../models/state.dto"
import { DeleteOutlined } from "@ant-design/icons";
import{getCountries} from "../services/country.service"

export function State() {
const [data, setData] = useState<StateMastersDto[]>([]);
const [loading, setLoading] = useState(false);
const [isModalOpen, setIsModalOpen] = useState(false);
 const [form] = Form.useForm();
  const [countries, setCountries] = useState<{ id: number; countryName: string }[]>([]);
 const loadStates = async () => {
    setLoading(true);
    try {
      const result = await getState();
     setData(result);
    } catch {
      message.error("Failed to load states");
    }
    setLoading(false);
  };

  const loadCountries = async () => {
    try {
       const countriesResult = await getCountries();
       const countries = countriesResult.data || countriesResult || [];
       setCountries(countries);
    } catch {
      message.error("Failed to load countries");
    }
  };

  useEffect(() => {
    loadCountries();
    loadStates();
  }, []);

  const handleCreate = async (values: CreateStateMasters) => {
    try {
     await createstate(values)
      message.success("State created successfully");
      form.resetFields();
      setIsModalOpen(false);
      loadStates();
    } catch {
      message.error("Create failed");
    }
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete State?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
        await deleteState(id);
        message.success("State deleted successfully");
        loadStates();
      } catch {
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
          State Master
        </label>
        <Button
          type="link"
          style={{ color: "white", fontWeight: "bold", padding: 0, height: "auto" }}
          onClick={() => setIsModalOpen(true)}
        >
          Add State
        </Button>
      </div>
  
    
      <Spin spinning={loading}>
        <Table
          rowKey="id"
          columns={[
            { title: "State", dataIndex: "stateName" },
            { title: "Code", dataIndex: "stateCode", render: (code: number) => `#${code}` },
            { title: "Country Name", dataIndex: "countryName" },
            { 
              title: "Created", 
              dataIndex: "createdate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-' 
            },
            {
              title: "Actions",
              width: 100,
              render: (_: any, record: StateMastersDto) => (
                <Button 
                  type="text" 
                  danger 
                  icon={<DeleteOutlined />} 
                  onClick={() => handleDelete(record.id!)}
                />
              ),
            },
          ]}
          dataSource={data}
        />
      </Spin>

      {/* Create State Modal */}
      <Modal
        title="Create State"
        open={isModalOpen}
        onCancel={() => {
          setIsModalOpen(false);
          form.resetFields();
        }}
        footer={null}
      >
        <Form form={form} layout="vertical" onFinish={handleCreate}>

             <Form.Item
            label="state ID"
            name="stateID"
            rules={[{ required: true, message: "Enter state ID" }]}
          >
            <Input placeholder="e.g. Karnataka" />
          </Form.Item>
          <Form.Item
            label="State Name"
            name="stateName"
            rules={[{ required: true, message: "Enter state name" }]}
          >
            <Input placeholder="e.g. Karnataka" />
          </Form.Item>

          <Form.Item
            label="State Code"
            name="stateCode"
            rules={[{ required: true, message: "Enter state code" }]}
          >
            <Input type="number" placeholder="e.g. 29" />
          </Form.Item>

          <Form.Item
            label="Country"
            name="countryID"
            rules={[{ required: true, message: "Select country" }]}
          >
            <Select placeholder="Select country">
              {countries.map(country => (
                <Select.Option key={country.id} value={country.id}>
                  {country.countryName}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>

       <div style={{ display: 'flex', gap: 8, marginTop: 16 }}>
  <Button 
    type="primary" 
    htmlType="submit" 
    style={{ flex: 1 }}
  >
    Create State
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