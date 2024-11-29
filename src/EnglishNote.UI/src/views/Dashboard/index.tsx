import Navbar from "../../components/Navbar";
import { Outlet } from "react-router";

export default function Dashboard() {
    return (
       <div>
         <Navbar />
         <Outlet></Outlet>
       </div>
      );
}