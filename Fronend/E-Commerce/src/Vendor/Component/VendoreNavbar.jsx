import React, { useState } from "react";
import { FcApproval } from "react-icons/fc";
import {

  FiUser,
  FiEdit,
  FiLogOut,
  FiEye,
  FiCalendar,
} from "react-icons/fi";
import { TbUserSquareRounded } from "react-icons/tb";
import { Link } from "react-router-dom";

const VendoreNavbar = () => {
  const [open, setOpen] = useState(false);

  const userName = "Bhaneshvar";

  return (
    <div className="">
      <header
        className="fixed top-0 left-0 w-full z-100 px-12 py-4 flex items-center justify-between shadow-sm bg-white"
      >
        <a href="/Home" className="flex items-center gap-2 cursor-pointer">
          <div className="w-9 h-9 rounded-full bg-blue-700 flex items-center justify-center text-white font-semibold">
            SE
          </div>
          <span className="text-lg font-semibold text-gray-900">
            Shop Ease
          </span>
        </a>

        <nav className="hidden md:flex gap-8 text-gray-700 font-medium">
          <Link to="/HomePage" className="text-blue-700 font-bold hover:text-blue-600">Home</Link>
          <Link to="/Cetagory" className="hover:text-black">Cetagory</Link>
          <Link to="/SubCetagory" className="hover:text-black">Sub-Cetagory</Link>
          <Link to="/Products" className="hover:text-black">Products</Link>
          <Link to="/SellerInventory" className="hover:text-black">Seller-Inventory</Link>
        </nav>

        <div className="flex items-center gap-6 text-gray-800 relative">

          {/* <input
            type="text"
            placeholder="Search products..."
            className="hidden md:block px-4 py-2 w-64 rounded-full border border-gray-300 text-sm 
          focus:outline-none focus:ring focus:ring-gray-400"
          /> */}


          <div className="relative">
            <TbUserSquareRounded
              className="text-3xl cursor-pointer hover:text-black"
              onClick={() => setOpen(!open)}
            />

            {open && (
              <div className="absolute right-0 mt-3 w-56 bg-white rounded-xl shadow border border-gray-300 text-sm">

                <div className="px-4 py-3 border-b border-gray-300 font-semibold text-gray-800 flex items-center gap-2">
                  <FiUser className="text-blue-800 font-bold" /> {userName}
                </div>

                <ul className="py-2">
                  <li className="px-4 py-2 flex items-center gap-2 hover:bg-gray-100 cursor-pointer">
                    <FiEdit className="text-blue-800 font-bold" /> Edit Profile
                  </li>
                  <li className="px-4 py-2 flex items-center gap-2 hover:bg-gray-100 cursor-pointer">
                    <FiCalendar className="text-blue-800 font-bold" /> Recently Added
                  </li>

                  <li className="px-4 py-2 flex items-center gap-2 hover:bg-gray-100 cursor-pointer">
                    <FcApproval /> Approval Request
                  </li>

                  <li className="px-4 py-2 flex items-center gap-2 hover:bg-red-50 text-red-600 cursor-pointer">
                    <FiLogOut /> Logout
                  </li>
                </ul>
              </div>
            )}
          </div>
        </div>
      </header>

      <div className="h-18"></div>

    </div>
  );
};

export default VendoreNavbar;
