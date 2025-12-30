
import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Login from '../Authentication/Login'
import Signup from '../Authentication/Signup'
import { Toaster } from 'react-hot-toast'
import Home from '../Customer/Pages/HomePage/Home'
import HomePage from '../Vendor/Pages/HomePage'
import Products from '../Vendor/Pages/Products/Products'
import AddProducts from '../Vendor/Pages/Products/AddProducts'
import Cetagory from '../Vendor/Pages/Cetagory/Cetagory'
import AddCetagory from '../Vendor/Pages/Cetagory/AddCetagory'
import SubCetagory from '../Vendor/Pages/SubCetagory/SubCetagory'
import AddSubCetagory from '../Vendor/Pages/SubCetagory/AddSubCetagory'
import SellerInventory from '../Vendor/Pages/SellerInventory/SellerInventory'
import AddSellerInventory from '../Vendor/Pages/SellerInventory/AddSellerInventory'

const AppRoutes = () => {
  return (
    <div>
      <Toaster />
      <Routes>

        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/Home" element={<Home />} />


        <Route path="/HomePage" element={<HomePage />} />
        <Route path="/Products" element={<Products />} />
        <Route path="/AddProduct" element={<AddProducts />} />
        <Route path="/Cetagory" element={<Cetagory />} />
        <Route path="/AddCetagory" element={<AddCetagory />} />
        <Route path="/SubCetagory" element={<SubCetagory />} />
        <Route path="/AddSubCetagory" element={<AddSubCetagory />} />
        <Route path="/SellerInventory" element={<SellerInventory />} />
        <Route path="/AddInventory" element={<AddSellerInventory />} />

      </Routes>
    </div>
  )
}

export default AppRoutes
