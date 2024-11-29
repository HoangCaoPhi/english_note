import { Outlet } from "react-router";

export default function AuthLayout() {
    return (
        <div style={{ padding: "20px", textAlign: "center" }}>
          <h1>Welcome to Auth Page</h1>
          <Outlet />  
        </div>
      );
}