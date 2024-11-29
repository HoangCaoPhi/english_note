import { BrowserRouter, Route, Routes } from 'react-router'
import Login from './views/Login'
import Register from './views/Register'
import Home from './views/Home'
import Dashboard from './views/Dashboard'
 
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Dashboard />}>
          <Route index element={<Home />} /> 
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Route>
        
      </Routes>
    </BrowserRouter>
    )
}

export default App
