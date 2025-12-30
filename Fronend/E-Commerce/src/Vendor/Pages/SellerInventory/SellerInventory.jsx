import React from "react";
import { Link } from "react-router-dom";

const SellerInventory = () => {
    return (
        <div className=" mt-6 mx-6 ">

            {/* Header */}
            <div className="flex justify-between items-center mb-4">
                <h2 className="text-xl font-semibold text-gray-700">
                    Seller Inventory List
                </h2>

                <Link to="/AddInventory">
                    <button
                        className="px-4 py-2 bg-blue-600 text-white rounded-md font-medium
                     hover:bg-blue-700 transition-all
                     focus:outline-none focus:ring-2 focus:ring-indigo-400"
                    >
                        + Add
                    </button>
                </Link>
            </div>


            <div className="h-[615px] shadow-md overflow-y-auto rounded-lg overflow-hidden">
                <table className="w-full border-collapse">
                    <thead className="sticky top-0 bg-blue-600 text-gray-50 text-sm z-10">
                        <tr>
                            <th className="px-4 py-4 text-left">Id</th>
                            <th className="px-4 py-3 text-left">Product Name</th>
                            <th className="px-4 py-3 text-left">Seller Name</th>
                            <th className="px-4 py-3 text-left">Price</th>
                            <th className="px-4 py-3 text-left">Quantity</th>
                            <th className="px-4 py-3 text-left">Created Date</th>
                            <th className="px-4 py-3 text-left">Action</th>
                        </tr>
                    </thead>

                    <tbody className="text-sm text-gray-700">

                        <tr className="border-b border-gray-200 hover:bg-gray-50">
                            <td className="px-4 py-3">1</td>
                            <td className="px-4 py-3">Electronics</td>
                            <td className="px-4 py-3 truncate">Latest Phone</td>
                            <td className="px-4 py-3 truncate">Latest Phone</td>
                            <td className="px-4 py-3 truncate">1281</td>
                            <td className="px-4 py-3">26 Dec 2025</td>
                            <td className="py-2">
                                <button
                                    className="px-3 py-2 text-xs text-center font-medium text-white bg-red-500 
                                        rounded-md hover:bg-red-600 transition-all
                                        focus:outline-none focus:ring-2 focus:ring-red-400"
                                >
                                    Delete
                                </button>
                            </td>
                        </tr>

                    </tbody>
                </table>
            </div>

        </div>
    );
};

export default SellerInventory;
