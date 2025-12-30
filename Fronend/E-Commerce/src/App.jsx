import { useState } from 'react'
import './App.css'
import AppRoutes from './Routes/AppRoutes'
import VendoreNavbar from './Vendor/Component/VendoreNavbar'

function App() {

  return (
    <div >
      <VendoreNavbar />
      <AppRoutes />
    </div>
  )
}

export default App
