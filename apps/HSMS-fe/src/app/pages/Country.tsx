import { useEffect, useState, useCallback } from "react";
import { Card, Button, Modal, Form, Input, message, Spin, Table } from "antd";
import { getCountries, createCountry, deleteCountry } from "../services/country.service";
import { CountryMastersDto, CountryDto } from "../models/country.dto";
import { DeleteOutlined } from "@ant-design/icons";

export function Country() {
  const [data, setData] = useState<CountryMastersDto[]>([]);
  const [form] = Form.useForm();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [loading, setLoading] = useState(false);

  const loadCountries = async () => {
  try {
    setLoading(true);
    const result = await getCountries();
    
    // Handle both ApiResponse and direct array
    const countries = result.data || result || [];
    console.log('Countries array:', countries); // Debug log
    
    setData(countries);
  } catch (error) {
    console.error('Load countries failed:', error);
    message.error("Failed to load countries");
    setData([]); // Reset on error
  } finally {
    setLoading(false);
  }
};

  useEffect(() => {
    loadCountries();
  }, []); // Fix: Remove loadCountries dependency

  const handleCreate = async (values: { countryName: string }) => {
    try {
      const countryData: CountryDto = {
        CountryName: values.countryName.trim()
      };
      
      const result = await createCountry(countryData);
      if (result.success) {
        message.success("Country created successfully");
        form.resetFields();
        setIsModalOpen(false);
        await loadCountries();
      } else {
        message.error(result.message || "Create failed");
      }
    } catch (error: any) {
      message.error(error.message || "Create failed");
    }
  };

  const handleDelete = useCallback(async (id: number) => {
    Modal.confirm({
      title: "Delete Country?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
      onOk: async () => {
        try {
         const res= await deleteCountry(id);
         if(res.success)
         {
          message.success(res.message) ;
          loadCountries();
         }
         else
         {
          message.error(res.message );
         }
        } catch (error) {
          message.error("Delete failed");
        }
      }
    });
  }, []);

  // Fix: Use Ant Design Table instead of raw HTML table
  const columns = [
    { title: "Name", dataIndex: "countryName", key: "name" },
    { title: "Code", dataIndex: "countryCode", key: "code", render: (code: number) => `${code}` },
    { 
      title: "Created", 
      dataIndex: "createdate", 
      key: "created",
      render: (date: string) => date ? new Date(date).toLocaleDateString('en-IN') : '-' 
    },
    { 
      title: "Edited", 
      dataIndex: "editDate", 
      key: "edited",
      render: (date: string) => date ? new Date(date).toLocaleDateString('en-IN') : '-' 
    },
    {
      title: "Actions",
      key: "actions",
      width: 100,
      render: (_: any, record: CountryMastersDto) => (
        <Button 
          type="text" 
          danger 
          icon={<DeleteOutlined />} 
          onClick={() => handleDelete(record.id!)}
        />
      ),
    },
  ];

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
          Country Master
        </label>
        <Button
          type="link"
          style={{ color: "white", fontWeight: "bold", padding: 0, height: "auto" }}
          onClick={() => setIsModalOpen(true)}
        >
          Add New
        </Button>
      </div>

      {/* Ant Design Table - Fixed */}
      <Spin spinning={loading}>
        <Table
          rowKey="id"
          columns={columns}
          dataSource={data}
          pagination={{ pageSize: 10 }}
          scroll={{ x: 800 }}
        />
      </Spin>

      {/* Create Modal */}
      <Modal 
        title="Create Country" 
        open={isModalOpen} 
        footer={null} 
        width={500}
        onCancel={() => { 
          setIsModalOpen(false); 
          form.resetFields(); 
        }}
      >
        <Form form={form} layout="vertical" onFinish={handleCreate}>
          <Form.Item 
            label="Country Name" 
            name="countryName" 
            rules={[{ required: true, message: "Enter country name" }]}
          >
            <Input placeholder="e.g. India" />
          </Form.Item>
          <div style={{ display: 'flex', gap: 8, marginTop: 16 }}>
            <Button type="primary" htmlType="submit" style={{ flex: 1 }}>
              Create
            </Button>
            <Button 
              onClick={() => { 
                form.resetFields(); 
                setIsModalOpen(false); 
              }} 
              style={{ flex: 1 }}
            >
              Cancel
            </Button>
          </div>
        </Form>
      </Modal>
    </Card>
  );
}
