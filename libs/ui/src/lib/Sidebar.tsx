import { Layout, Menu } from "antd";
import {
  DashboardOutlined,
  UserOutlined,
  EnvironmentOutlined,
  PartitionOutlined,
  CompassOutlined,
  GlobalOutlined,
  AreaChartOutlined,
  DatabaseOutlined,
  ShopOutlined,
  BankOutlined,
  AppstoreOutlined,
  TeamOutlined,
  IdcardOutlined,
  SafetyCertificateOutlined,
  TagOutlined,FileTextOutlined,
  DollarOutlined,ToolOutlined,
  CustomerServiceOutlined,
  BarChartOutlined,UserSwitchOutlined,UserAddOutlined,LoginOutlined,SlidersOutlined,LogoutOutlined
} from "@ant-design/icons";

import { Link } from "react-router-dom";
const { Sider } = Layout;

interface SidebarProps {
  collapsed: boolean;
}

export function Sidebar({ collapsed }: SidebarProps) {
  return (
    <Sider collapsible collapsed={collapsed} trigger={null}>
      <div
        style={{
          height: 64,
          color: "white",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          fontWeight: "bold",
        }}
      >
        HSMS
      </div>

      <Menu
        theme="dark"
        mode="inline"
        defaultSelectedKeys={["1"]}
        defaultOpenKeys={["master-data"]}  // ✅ Opens submenu
        items={[
          {
            key: "1",
            icon: <DashboardOutlined />,
            label:<Link to="/dashboard">Dashboard</Link>,
          },
          {
            key: "master-data",
            icon: <DatabaseOutlined  />,
            label: (
              <span 
                onClick={(e) => e.stopPropagation()}  // ✅ Prevents navigation
                style={{ cursor: "default" }}
              >
                Master Data
              </span>
            ),
            children: [  // ✅ Submenu with icons
              {
                key: "2",
                icon: <GlobalOutlined />,
                label: <Link to="/country">Country</Link>,
              },
              {
                key: "3",
                icon: <CompassOutlined />,
                label: <Link to="/state">State</Link>,
              },
              {
                key: "4",
                icon: <PartitionOutlined />,
                label: <Link to="/district">District</Link>,
              },
              {
                key: "5",
                icon: <EnvironmentOutlined />,
                label: <Link to="/city">City</Link>,
              },
              {
                key: "6",
                icon: <AreaChartOutlined />,      // 📈 BEST for Area
                label: <Link to="/area">Area</Link>,
              },
            
            ],
          },
           {
            key: "general-data",
            icon: <AppstoreOutlined   />,
            label: (
              <span 
                onClick={(e) => e.stopPropagation()}  // ✅ Prevents navigation
                style={{ cursor: "default" }}
              >
               General
              </span>
            ),
               children: [ 
                  {
              key: "7",
              icon: <ShopOutlined />,        // 🏢 PERFECT for Company
              label: <Link to="/company">Company</Link>,
            },
              {
              key: "8",
              icon: <BankOutlined />,        // 🏢 PERFECT for Company
              label: <Link to="/branch">Branch</Link>,
            },
            {
              key: "9",
              icon: <TeamOutlined />,        // 👥 PERFECT for Main Department
              label: <Link to="/maindepartment">Main Department</Link>,
            },
             {
              key: "10",
              icon: <TeamOutlined />,        // 👥 PERFECT for Main Department
              label: <Link to="/department">Department</Link>,
            },
             {
              key: "11",
              icon: <IdcardOutlined  />,        // 👥 PERFECT for Main Department
              label: <Link to="/qualification">Qualification Masters</Link>,
            }

               ]
          },
          {
          key: "user-data",
            icon: <UserOutlined    />,
            label: (
              <span 
                onClick={(e) => e.stopPropagation()}  // ✅ Prevents navigation
                style={{ cursor: "default" }}
              >
               User
              </span>
            ),
            children: [ 

            {
              key: "12",
              icon: <SafetyCertificateOutlined  />,        // 🏢 PERFECT for Company
              label: <Link to="/userRoleMaster">User Role Master</Link>,
            },
            {
              key: "19",
              icon: <UserAddOutlined />,  
              label: <Link to="/user-creation">User Creation</Link>,
            },
            {
            key: "20",
            icon: <LoginOutlined />,  
            label: <Link to="/user-branch-mapping">User To Branch Mapping</Link>,
          }




            ]

          },
          {
          key: "tariff-data",
            icon: <DollarOutlined     />,
            label: (
              <span 
                onClick={(e) => e.stopPropagation()}  // ✅ Prevents navigation
                style={{ cursor: "default" }}
              >
               Tariff Masters
              </span>
            ),
            children: [ 

            {
              key: "13",
              icon: <TagOutlined   />,        // 🏢 PERFECT for Company
              label: <Link to="/tariffMaster">Tariff Master</Link>,
            },
            {
              key: "14",
              icon: <FileTextOutlined   />,        // 🏢 PERFECT for Company
              label: <Link to="/billing-header">Billing Header Master</Link>,
            },
            {
              key: "15",
              icon: <ToolOutlined />,  
              label: <Link to="/service-type">Service Type Master</Link>,
            },
            {
              key: "16",
              icon: <CustomerServiceOutlined />,  
              label: <Link to="/service">Service Master</Link>,
            },
            {
              key: "17",
              icon: <BarChartOutlined   />,  
              label: <Link to="/service-tariff-details">Service Tariff Details</Link>,
            },
            {
              key: "18",
              icon: <UserSwitchOutlined />,  
              label: <Link to="/consultant-tariff-details">Consultant Tariff Details</Link>,
            }
            ]

          },
           {
            key: "doctor-data",
            icon: <UserOutlined    />,
            label: (
              <span 
                onClick={(e) => e.stopPropagation()}  // ✅ Prevents navigation
                style={{ cursor: "default" }}
              >
               Doctor Master
              </span>
            ),
               children: [ 
                  {
                  key: "21",
                  icon: <UserOutlined  />,  
                  label: <Link to="/doctor-details">Doctor Details</Link>,
                },{
                  key: "22",
                  icon: <DollarOutlined  />,  
                  label: <Link to="/fee-details">Fee Details</Link>,
                },
                {
                  key: "23",
                  icon: <SlidersOutlined />,  
                  label: <Link to="/slab-rates">Slab Rates</Link>,
                }




               ]
          },
      // Logout as separator item
                {
                  type: "divider",
                  key: "divider-1"
                },
                {
                  key: "99",
                  icon: <LogoutOutlined />,
                  label: "Logout",
                 // onClick: handleLogout,
                },

        ]}
      />
    </Sider>
  );
}
