import { Table, Card, Button, Modal, Form, Input, Select, Switch, message, Spin } from "antd";
import { useEffect, useState } from "react";
import { DeleteOutlined,EditOutlined  } from "@ant-design/icons";
import {CreateMainDepartmentDto,MainDepartmentMastersDto} from "../models/MainDepartment.dto";
import {getAllMainDepartment,createMainDepartment,deleteMainDepartment} from "../services/MainDepartment.service";


export function MainDepartment() {
  const [data, setData] = useState<MainDepartmentMastersDto[]>([]);
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm<CreateMainDepartmentDto>();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isEditMode, setIsEditMode] = useState(false);
  const [editingDept, setEditingDept] = useState<MainDepartmentMastersDto | null>(null);

const loadDepartments = async () => {
    setLoading(true);
    try {
      const result = await getAllMainDepartment();
      setData(result);
    } catch (error: any) {
      message.error("Failed to load departments");
    }
    setLoading(false);
  };

  useEffect(() => {
    loadDepartments();
  }, []);

  const handleCreateOrUpdate = async (values: CreateMainDepartmentDto & { id?: number }) => {
    try {
      if (isEditMode && editingDept?.id) {
        // Update logic here
        message.success("Department updated successfully");
      } else {
        await createMainDepartment(values);
        message.success("Department created successfully");
      }
      form.resetFields();
      setIsModalOpen(false);
      setIsEditMode(false);
      setEditingDept(null);
      loadDepartments();
    } catch (error: any) {
      message.error(error.response?.data?.message || "Operation failed");
    }
  };

  const handleEdit = (record: MainDepartmentMastersDto) => {
    setEditingDept(record);
    setIsEditMode(true);
    setIsModalOpen(true);
    form.setFieldsValue({
      mainDeptID: record.mainDeptID??undefined,
      mainDepartmentName: record.mainDepartmentName??undefined,
    });
  };

  const handleDelete = async (id: number) => {
    const confirmed = await Modal.confirm({
      title: "Delete Department?",
      content: "This action cannot be undone.",
      okText: "Delete",
      okType: "danger",
    });
    
    if (confirmed) {
      try {
        await deleteMainDepartment(id);
        message.success("Department deleted successfully");
        loadDepartments();
      } catch {
        message.error("Delete failed");
      }
    }
  };

  return (
    <Card 
      title="Main Departments" 
      extra={
        <Button 
          type="primary" 
          onClick={() => {
            setIsModalOpen(true);
            setIsEditMode(false);
            setEditingDept(null);
            form.resetFields();
          }}
        >
          Add Department
        </Button>
      }
    >
      <Spin spinning={loading}>
        <Table<MainDepartmentMastersDto>
          rowKey="id"
          columns={[
            { 
              title: "Dept ID", 
              dataIndex: "mainDeptID", 
              width: 120 
            },
            { 
              title: "Department Name", 
              dataIndex: "mainDepartmentName",
              ellipsis: true 
            },
            { 
              title: "Created", 
              dataIndex: "createDate", 
              render: (date: string) => date ? new Date(date).toLocaleDateString() : '-',
              width: 140 
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

      {/* Create/Edit Modal */}
      <Modal 
        title={isEditMode ? "Edit Department" : "Create Department"}
        open={isModalOpen} 
        onCancel={() => {
          setIsModalOpen(false);
          setIsEditMode(false);
          setEditingDept(null);
          form.resetFields();
        }} 
        footer={null}
        width={600}
      >
        <Form<CreateMainDepartmentDto> 
          form={form} 
          layout="vertical" 
          onFinish={handleCreateOrUpdate}
        >
          <Form.Item 
            label="Department ID" 
            name="mainDeptID"
          >
            <Input placeholder="e.g. MD001" />
          </Form.Item>

          <Form.Item 
            label="Department Name" 
            name="mainDepartmentName"
            rules={[{ required: true, message: "Please enter department name" }]}
          >
            <Input placeholder="e.g. General Medicine" />
          </Form.Item>

          <div style={{ display: 'flex', gap: 8, marginTop: 24 }}>
            <Button 
              type="primary" 
              htmlType="submit" 
              style={{ flex: 1 }}
            >
              {isEditMode ? "Update" : "Create"}
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