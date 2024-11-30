import { useAuth } from "../../common/contexts/AuthContext";

export default function Home() {
    const { isLoggedIn } = useAuth();

    return (
       <div>
         {
            isLoggedIn ? 
            <div>User Loggined</div> :
            <div>User not Login</div>        
         }
       </div>
     );
}