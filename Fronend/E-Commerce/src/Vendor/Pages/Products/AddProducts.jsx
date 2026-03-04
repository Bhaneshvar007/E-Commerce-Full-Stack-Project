import React from 'react'
import { Link } from 'react-router-dom'


const AddProducts = () => {
  return (
    <div className="flex items-center justify-center px-4">
      <div className="bg-white w-full max-w-150 rounded-xl shadow-md py-4 px-6 ">

        <h2 className="text-2xl font-semibold text-gray-600 mb-6">
          Add Product
        </h2>

        <div className="mb-6">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='CategoryName'>
            Category
          </label>
          <select name='CategoryName' id='CategoryName' className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none focus:ring-2 focus:ring-blue-500/30 text-gray-500">
            <option value="" selected>Select Category</option>
            <option value="">Electronics</option>
            <option value="">Furniture</option>
            <option value="">Grosary</option>
            <option value="">Foods</option>
          </select>
        </div>


        <div className="mb-6">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='SubCategoryName'>
            Sub Category
          </label>
          <select className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none focus:ring-2 focus:ring-blue-500/30 text-gray-500"
                                      id='SubCategoryName' name='SubCategoryName'
                                      >
            <option value="" selected >Select Sub Category</option>
            <option value="">Mobile</option>
            <option value="">Tablet</option>
            <option value="">Accessories</option>
            <option value="">TV</option>
          </select>
        </div>


        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='ProductName'>
            Product Name
          </label>
          <input
            type="text" id='ProductName' name='ProductName'
            placeholder="Enter category name"
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
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='BrandName'>
            Brand Name
          </label>
          <input
            type="text" id='BrandName' name='BrandName'
            placeholder="Enter category name"
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
          <label className="block text-sm font-medium text-gray-700 mb-1" htmlFor='Mrp'>
            MR'P
          </label>
          <input
            type="number" id='Mrp' name='Mrp'
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
  )
}

export default AddProducts