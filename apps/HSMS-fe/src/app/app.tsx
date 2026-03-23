import  { useState, useEffect } from "react";
import { Layout } from "antd";
import { Routes, Route, useNavigate } from "react-router-dom";
import { Header, Sidebar } from "@hsms/ui"; // your UI components

import { Country } from "./pages/Country";
import { State } from "./pages/State";
import { District } from "./pages/District";
import { City } from "./pages/City";
import { Area } from "./pages/Area";
import { Branch } from "./pages/Branch";
import { Company } from "./pages/Company";
import { Profile } from "./pages/Profile";

const { Content } = Layout;

export function App() {
  const [collapsed, setCollapsed] = useState(false);
  const navigate = useNavigate();
  const [user, setUser] = useState<{ name: string; email: string; role: string } | null>(null);

  // Simulate login
  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    if (storedUser) {
      setUser(JSON.parse(storedUser));
    } else {
      const fakeUser = { name: "Naresh Kumaar", email: "naresh@example.com", role: "Super Admin" };
      localStorage.setItem("user", JSON.stringify(fakeUser));
      setUser(fakeUser);
    }
  }, []);

  if (!user) return <p>Loading...</p>;

  const toggle = () => setCollapsed(prev => !prev);
  const handleProfile = () => navigate("/profile");
  const handleLogout = () => {
    localStorage.clear();
    setUser(null);
    navigate("/");
    alert("Logged out!");
  };

  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sidebar collapsed={collapsed} />
      <Layout>
        <Header
          collapsed={collapsed}
          toggle={toggle}
          onProfileClick={handleProfile}
          onLogout={handleLogout}
          username={user.name} // dynamic username
        />
        <Content style={{ margin: 16, padding: 24, background: "#fff" }}>
          <Routes>
            <Route path="/" element={<div>Dashboard</div>} />
            <Route path="/country" element={<Country />} />
            <Route path="/state" element={<State />} />
            <Route path="/district" element={<District />} />
            <Route path="/city" element={<City />} />
            <Route path="/area" element={<Area />} />
            <Route path="/branch" element={<Branch />} />
            <Route path="/company" element={<Company />} />
            <Route path="/profile" element={<Profile />} />
          </Routes>
        </Content>
      </Layout>
    </Layout>
  );
}

export default App;