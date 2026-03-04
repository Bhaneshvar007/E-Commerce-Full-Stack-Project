import React from 'react'
import { Link } from 'react-router-dom'


const AddSellerInventory = () => {
  return (
    <div>
      <div className="flex items-center justify-center px-4">
      <div className="bg-white w-full max-w-150 rounded-xl shadow-md py-4 px-6 ">

        <h2 className="text-2xl font-semibold text-gray-600 mb-6">
          Add Product Stock
        </h2>

         


        <div className="mb-6">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='SubCategoryName'>
            Products
          </label>
          <select className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none focus:ring-2 focus:ring-blue-500/30 text-gray-500"
                                      id='SubCategoryName' name='SubCategoryName'
                                      >
            <option value="" selected >Select Product</option>
            <option value="">Sumsaung M35 5G</option>
            <option value="">I-Phone 16</option>
            <option value="">Redmi Note 15 Pro</option>
            <option value="">Nothing Phone 4a</option>
          </select>
        </div>


          



        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='Price'>
            Buy Price
          </label>
          <input
            type="number" id='Price' name='Price'
            placeholder="Enter your buying price"
            className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none
                                      transition-all duration-300
                                      focus:border-blue-500
                                      focus:ring-2 focus:ring-blue-500/30"
          />
        </div>

        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='Quantity'>
            Quantity
          </label>
          <input
            type="number" id='Quantity' name='Quantity'
            placeholder="Set your product price ?"
            className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none
                                      transition-all duration-300
                                      focus:border-blue-500
                                      focus:ring-2 focus:ring-blue-500/30"
          />
        </div>



        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='Description'>
            Description
          </label>
          <textarea
            rows="3"
            placeholder="Enter category description" id='Description' name='Description' 
            className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none
                                      transition-all duration-300
                                      focus:border-blue-500
                                      focus:ring-2 focus:ring-blue-500/30"
          ></textarea>
        </div>

        <div className="flex justify-end gap-3">
          <Link to="/Products">
            <button
              className="px-5 py-2 border rounded-lg bg-red-600 text-gray-50 hover:bg-red-500"
            >
              Back
            </button>
          </Link>
          <button
            className="px-5 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700"
          >
            Save
          </button>
        </div>
      </div>
    </div>
    </div>
  )
}

export default AddSellerInventory