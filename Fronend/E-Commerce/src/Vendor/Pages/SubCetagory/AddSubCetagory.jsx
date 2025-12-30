import React from 'react'
import { Link } from 'react-router-dom'

const AddSubCetagory = () => {
  return (
    <div className="flex items-center justify-center px-4">
      <div className="bg-white w-full max-w-[600px] rounded-xl shadow-md p-6  mt-5">

        <h2 className="text-2xl font-semibold text-gray-600 mb-6">
          Add Sub Category
        </h2>

        <div className="mb-6">
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Category
          </label>
          <select className="w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none focus:ring-2 focus:ring-blue-500/30">
            <option value="" disabled>Select</option>
            <option value="">Electronics</option>
            <option value="">Furniture</option>
            <option value="">Grosary</option>
            <option value="">Foods</option>
          </select>
        </div>

        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Sub Category Name
          </label>
          <input
            type="text"
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
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Description
          </label>
          <textarea
            rows="3"
            placeholder="Enter category description"
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
    </div>)
}

export default AddSubCetagory