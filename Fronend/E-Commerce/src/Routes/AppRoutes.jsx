
import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Login from '../Pages/Authentication/Login'
import Signup from '../Pages/Authentication/Signup'
import Navbar from '../Components/Navbar'

const AppRoutes = () => {
  return (
    <div>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/navbar" element={<Navbar />} />
      </Routes>
    </div>
  )
}

export default AppRoutes
