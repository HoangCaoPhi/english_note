import { Box, Button, Container, TextField, Typography } from "@mui/material";

export default function Register() {
  return (
    <Container maxWidth="sm" className="mt-10">
      <Typography variant="h5" className="mb-4 text-center">
        Create an Account
      </Typography>
      <Box component="form" className="flex flex-col gap-4">
        <TextField label="Full Name" variant="outlined" fullWidth />
        <TextField label="Email" variant="outlined" fullWidth />
        <TextField label="Password" type="password" variant="outlined" fullWidth />
        <Button variant="contained" color="primary" fullWidth>
          Register
        </Button>
      </Box>
    </Container>
  );
}