
import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Login from '../Pages/Authentication/Login'
import Signup from '../Pages/Authentication/Signup'
import Navbar from '../Components/Navbar'
import { Toaster } from 'react-hot-toast'

const AppRoutes = () => {
  return (
    <div>
      <Toaster />
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
