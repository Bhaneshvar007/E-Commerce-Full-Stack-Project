import React, { useState } from 'react'
import { SignupUser } from '../../Features/Auth/authSlice';
import { useSelector, useDispatch } from 'react-redux'

const Signup = () => {

  const dispatch = useDispatch();
  const { isLoading } = useSelector((state) => state.auth);


  const [formData, setFormData] = useState({
    fullname: "",
    email: "",
    password: "",
    conformpassword: "",
  });



  let [IsInputData, setIsInputData] = useState()

  const handleInputChange = (e) => {
    const { name, value } = e.target;

    setFormData({
      ...formData,
      [name]: value,
    });
  };


  const handleInputSubmit = (e) => {
    e.preventDefault();
    dispatch(SignupUser(formData));
  }



  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">

      <div className="w-full max-w-md p-6 shadow rounded-xl">

        <h1 className="text-3xl font-semibold text-center mb-2">
          Create Account
        </h1>
        <p className="text-center text-gray-500 mb-8">
          Create a new account to get started with ShopEase.
        </p>
        <form onSubmit={handleInputSubmit}>
          <div className="mb-5">
            <label className="block text-sm font-medium mb-1" htmlFor='fullname'>Full Name</label>
            <input
              type="text" id='fullname' name='fullname'
              placeholder="Enter your name"
              value={formData.fullname}
              onChange={handleInputChange}
              className="
            w-full px-4 py-2
            border border-gray-300
            rounded-md
            outline-none
            transition-all duration-300
            focus:border-blue-500
            focus:ring-2 focus:ring-blue-500/30
            "/>
          </div>

          <div className="mb-5">
            <label className="block text-sm font-medium mb-1" htmlFor='email'>Email</label>
            <input
              type="email"
              placeholder="Enter your email" id='email' name='email'
              value={formData.email} autoComplete="new-email"
              onChange={handleInputChange}
              className="
            w-full px-4 py-2
            border border-gray-300
            rounded-md
            outline-none
            transition-all duration-300
            focus:border-blue-500
            focus:ring-2 focus:ring-blue-500/30
          "/>
          </div>

          <div className="mb-5">
            <label className="block text-sm font-medium mb-1" htmlFor='password'>Password</label>
            <div className="relative">
              <input
                type="password"
                placeholder="Enter password" id='password' name='password'
                value={formData.password}
                onChange={handleInputChange} autoComplete="new-password"
                className="
                  w-full px-4 py-2 pr-10
                  border border-gray-300
                  rounded-md
                  outline-none
                  transition-all duration-300
                  focus:border-blue-500
                  focus:ring-2 focus:ring-blue-500/30
                "/>

            </div>
          </div>
          <div className="mb-5">
            <label className="block text-sm font-medium mb-1" htmlFor='conformpassword'>Conform Password</label>
            <div className="relative">
              <input
                type="password"
                placeholder="Conform password" id='conformpassword' name='conformpassword'
                value={formData.conformpassword} autoComplete="new-password"
                onChange={handleInputChange}
                className="
                      w-full px-4 py-2 pr-10
                      border border-gray-300
                      rounded-md
                      outline-none
                      transition-all duration-300
                      focus:border-blue-500
                      focus:ring-2 focus:ring-blue-500/30
                "/>

            </div>
          </div>


          <button
            type='submit'
            className="
                w-full py-2
                bg-indigo-600
                text-white
                rounded-md
                font-medium
                transition-all
                hover:bg-indigo-700
                focus:outline-none
                focus:ring-2 focus:ring-indigo-500/50
              "
          >
            Create Acount
          </button>
        </form>

        <div className="flex items-center my-8">
          <div className="flex-1 h-px bg-gray-300"></div>
          <span className="px-3 text-sm text-gray-400">OR SIGN UP WITH</span>
          <div className="flex-1 h-px bg-gray-300"></div>
        </div>




        <div className="flex gap-4 mb-6  mt-4">
          <button className="flex-1 flex items-center justify-center gap-2 border border-gray-400 rounded-md py-2 hover:bg-gray-50 cursor-pointer">
            <img
              src="https://www.svgrepo.com/show/475656/google-color.svg"
              className="w-5"
            />
            Google
          </button>

          <button className="flex-1 flex items-center justify-center gap-2 border border-gray-400 rounded-md py-2 hover:bg-gray-50 cursor-pointer">
            <img
              src="https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Gmail_icon_%282020%29.svg/2560px-Gmail_icon_%282020%29.svg.png"
              className="w-5"
            />
            Email
          </button>
        </div>



        <p className="text-center text-sm text-gray-500 mt-2">
          Already Have An Account?
          <a href="/Login" className="text-blue-600 ml-1 hover:underline">
            Sign In.
          </a>
        </p>

      </div>
    </div>
  )
}

export default Signup;