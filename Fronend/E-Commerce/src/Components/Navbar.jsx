import React from 'react'
import { FiSearch, FiHeart, FiShoppingBag } from "react-icons/fi";


const Navbar = () => {
    return (
        <header
            className="fixed top-0 left-0 w-full z-50 px-6 py-4 flex items-center justify-between shadow-sm"
            style={{ backgroundColor: "oklch(0.98 0.01 70)" }}
        >
            <div className="flex items-center gap-2">
                <div className="w-9 h-9 rounded-full bg-purple-700 flex items-center justify-center text-white font-semibold">
                    SE
                </div>
                <span className="text-lg font-semibold text-gray-900">
                    Shop Ease
                </span>
            </div>

            <nav className="hidden md:flex gap-8 text-gray-700 font-medium">
                <a href="#" className="hover:text-black">
                    Browse All
                </a>
                <a href="#" className="hover:text-black">
                    New
                </a>
                <a href="#" className="hover:text-black">
                    Sale
                </a>
            </nav>

            <div className="flex items-center gap-6 text-xl text-gray-800 relative">
                <FiSearch className="cursor-pointer hover:text-black" />
                <FiHeart className="cursor-pointer hover:text-black" />

                <div className="relative cursor-pointer">
                    <FiShoppingBag className="hover:text-black" />
                    <span className="absolute -top-2 -right-2 bg-orange-500 text-white text-xs w-5 h-5 flex items-center justify-center rounded-full">
                        2
                    </span>
                </div>
            </div>
        </header>
    )
}

export default Navbar