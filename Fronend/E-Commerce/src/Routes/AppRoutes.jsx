
import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Login from '../Authentication/Login'
import Signup from '../Authentication/Signup'
import Navbar from '../Customer/Components/Navbar'
import { Toaster } from 'react-hot-toast'
import Home from '../Customer/Pages/HomePage/Home'

const AppRoutes = () => {
  return (
    <div>
      <Toaster />
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/navbar" element={<Navbar />} />
        <Route path="/Home" element={<Home />} />
      </Routes>
    </div>
  )
}

export default AppRoutes
