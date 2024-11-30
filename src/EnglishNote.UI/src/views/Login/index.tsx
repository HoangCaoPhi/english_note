import { useState } from "react";
import {
  TextField,
  Button,
  InputAdornment,
  IconButton,
  Stack,
  Typography,
  Link,
} from "@mui/material";
import "./index.css";
import { Google, Visibility, VisibilityOff } from "@mui/icons-material";
import { login } from "../../services/identity";
import { useNavigate } from "react-router";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [showPassword, setShowPassword] = useState(false);

  const navigate = useNavigate();
  
  const handleSubmit = async (e: { preventDefault: () => void; }) => {
    e.preventDefault(); 

    var res = await login(email, password);
    if(res) {
      navigate('/');
    }
    else {
      alert('Login failed. Please check your credentials.');
    }
  };

  const handleTogglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  return (
    <div className="flex flex-col items-center justify-center h-screen bg-gray-100">
      <div className="bg-white p-10 rounded-lg shadow-md">
        <h2 className="text-2xl font-bold mb-3">Welcome to English Note!</h2>
        <h3 className="mb-4">Sign in using your email and password.</h3>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Email"
            fullWidth
            margin="normal"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <TextField
            label="Password"
            type={showPassword ? "text" : "password"}
            fullWidth
            margin="normal"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            slotProps={{
              input: {
                endAdornment: (
                  <InputAdornment position="end">
                    <IconButton
                      aria-label={
                        showPassword ? "Hide password" : "Show password"
                      }
                      onClick={handleTogglePasswordVisibility}
                      edge="end"
                    >
                      {showPassword ? <VisibilityOff /> : <Visibility />}
                    </IconButton>
                  </InputAdornment>
                ),
              },
            }}
          />
          {/* Forgot Password Link */}
          <Typography align="right" sx={{ marginTop: 1 }}>
            <Link href="/forgot-password" underline="hover">
              Forgot Password?
            </Link>
          </Typography>

          <Stack spacing={2} direction="column" sx={{ marginTop: 2 }}>
            <Button
              type="submit"
              variant="contained"
              color="primary"
              fullWidth
            >
              Login
            </Button>

            <Button
              variant="outlined"
              color="secondary"
              fullWidth
              startIcon={<Google />}
            >
              Sign in with Google
            </Button>
          </Stack>
        </form>
      </div>
    </div>
  );
};

export default Login;
