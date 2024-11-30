import { AuthProvider } from "../../common/contexts/AuthContext";
import Navbar from "../../components/Navbar";
import { Outlet } from "react-router";

export default function Dashboard() {
  return (
       <div>
          <AuthProvider>
            <Navbar />
            <Outlet></Outlet>
          </AuthProvider>
       </div>
  );
}