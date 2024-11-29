import { useState } from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  InputBase,
  Button,
  Avatar,
  Box,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import AddIcon from "@mui/icons-material/Add";

const Navbar = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);  
  const [user] = useState({ avatar: "https://i.pravatar.cc/40", name: "User" });  

  return (
    <AppBar position="static" color="transparent" elevation={4}>
      <Toolbar className="flex justify-between items-center p-4">
 
        <div className="flex items-center space-x-4">
          <img
            src="https://via.placeholder.com/40"
            alt="Logo"
            className="w-12 h-12 object-contain"
          />
          <span className="font-bold text-xl text-gray-800">MyApp</span>
        </div>
 
        <div className="flex items-center bg-gray-200 rounded-full px-6 py-2 w-80 hover:bg-gray-300 transition-all ease-in-out">
          <IconButton size="small" className="text-gray-600 hover:text-gray-800">
            <SearchIcon />
          </IconButton>
          <InputBase
            placeholder="Tìm kiếm từ vựng"
            fullWidth
            inputProps={{ "aria-label": "search" }}
            className="bg-transparent focus:outline-none"
          />
        </div>
 
        <Box className="flex items-center space-x-4">
          <IconButton
            color="primary"
            className="bg-gray-100 rounded-full p-2 hover:bg-gray-300 transition-all ease-in-out"
          >
            <AddIcon />
          </IconButton>

          {isLoggedIn ? (
            <>
              <Button
                variant="contained"
                color="warning"
                className="text-sm bg-yellow-500 text-white py-1 px-4 rounded-lg hover:bg-yellow-600"
              >
                Nâng cấp
              </Button>
              <Avatar
                alt={user.name}
                src={user.avatar}
                className="w-10 h-10 rounded-full border-2 border-gray-300"
              />
            </>
          ) : (
            <>
              <Button
                color="inherit"
                onClick={() => alert("Login!")}
                className="text-sm text-gray-800 hover:text-blue-600"
              >
                Login
              </Button>
              <Button
                variant="outlined"
                color="primary"
                onClick={() => alert("Register!")}
                className="text-sm border-blue-600 text-blue-600 hover:bg-blue-100"
              >
                Register
              </Button>
            </>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
