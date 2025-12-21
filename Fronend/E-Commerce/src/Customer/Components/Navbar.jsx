import React, { useState } from "react";
import { FaRegUserCircle } from "react-icons/fa";
import {
    FiHeart,
    FiShoppingBag,
    FiUser,
    FiEdit,
    FiLogOut,
    FiEye,
} from "react-icons/fi";
import { BsCart } from "react-icons/bs";

const Navbar = () => {
    const [open, setOpen] = useState(false);

    const userName = "Bhaneshvar";  

    return (
        <div className="">
            <header
                className="fixed top-0 left-0 w-full z-100 px-16 py-4 flex items-center justify-between shadow-sm"
                style={{ backgroundColor: "oklch(0.98 0.01 70)" }}
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
                    <a href="#" className="hover:text-black">Browse All</a>
                    <a href="#" className="hover:text-black">New</a>
                    <a href="#" className="hover:text-black">Sale</a>
                </nav>

                <div className="flex items-center gap-6 text-gray-800 relative">

                    <input
                        type="text"
                        placeholder="Search products..."
                        className="hidden md:block px-4 py-2 w-64 rounded-full border border-gray-300 text-sm 
          focus:outline-none focus:ring focus:ring-gray-400"
                    />

                    <FiHeart className="text-xl cursor-pointer hover:text-black" />

                    <div className="relative cursor-pointer text-xl">
                        <FiShoppingBag />
                        <span className="absolute -top-2 -right-2 bg-orange-500 text-white text-xs w-5 h-5 flex items-center justify-center rounded-full">
                            2
                        </span>
                    </div>

                    <div className="relative">
                        <FaRegUserCircle
                            className="text-2xl cursor-pointer hover:text-black"
                            onClick={() => setOpen(!open)}
                        />

                        {open && (
                            <div className="absolute right-0 mt-3 w-56 bg-white rounded-xl shadow border border-gray-300 text-sm">

                                <div className="px-4 py-3 border-b border-gray-300 font-semibold text-gray-800 flex items-center gap-2">
                                    <FiUser /> {userName}
                                </div>

                                <ul className="py-2">
                                    <li className="px-4 py-2 flex items-center gap-2 hover:bg-gray-100 cursor-pointer">
                                        <FiEdit /> Edit Profile
                                    </li>

                                    <li className="px-4 py-2 flex items-center gap-2 hover:bg-gray-100 cursor-pointer">
                                        <BsCart /> My Cart
                                    </li>

                                    <li className="px-4 py-2 flex items-center gap-2 hover:bg-gray-100 cursor-pointer">
                                        <FiEye /> Watching
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

            <div className="h-16"></div>

        </div>
    );
};

export default Navbar;
