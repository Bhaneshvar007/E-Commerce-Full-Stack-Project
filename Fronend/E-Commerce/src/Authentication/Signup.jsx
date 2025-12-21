import React, { useEffect, useState } from 'react'
import { SignupUser } from '../Customer/Features/Auth/authSlice';
import { useSelector, useDispatch } from 'react-redux'
import { FaEye, FaEyeSlash } from "react-icons/fa";
import { EmailValidatore, PasswordValidatore } from '../utils/CommonLogic';
import { showError, showSuccess } from '../utils/toast';
import { useNavigate } from 'react-router-dom';

const Signup = () => {

  const dispatch = useDispatch();
  const { isLoading, error, successMessage } = useSelector(
    (state) => state.auth
  );
  const [showPassword, setShowPassword] = useState(false);
  const navigation = useNavigate();

  const [formData, setFormData] = useState({
    UserName: "",
    Email: "",
    Password: "",
    RoleName: "Customer"
  });

  const [errors, setErrors] = useState({
    Password: null,
    Email: null,
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;

    setFormData({
      ...formData,
      [name]: value,
    });



    if (name === "Password") {
      setErrors((prev) => ({
        ...prev,
        Password: PasswordValidatore(value),
      }));
    }

    if (name === "Email") {
      setErrors((prev) => ({
        ...prev,
        Email: EmailValidatore(value),
      }));
    }


  };


  const handleInputSubmit = (e) => {
    e.preventDefault();
    dispatch(SignupUser(formData));
  }

  useEffect(() => {
    if (successMessage) {
      showSuccess(successMessage);
      navigation("/Login");
    }

    if (error) {
      showError(error);
    }
  }, [successMessage, error]);




  useEffect(() => {
    if (successMessage) {
      setFormData({
        UserName: "",
        Email: "",
        Password: "",
        RoleName: "Customer",
      });

      setErrors({
        Password: null,
        Email: null,
      });
    }
  }, [successMessage]);



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
            <label className="block text-sm font-medium mb-1" htmlFor='UserName'>Full Name</label>
            <input
              type="text" id='UserName' name='UserName' required
              placeholder="Enter your name"
              value={formData.UserName}
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
            <label className="block text-sm font-medium mb-1" htmlFor='Email'>Email</label>
            <input
              type="email"
              placeholder="Enter your email" id='Email' name='Email' required
              value={formData.Email} autoComplete="new-email"
              onChange={handleInputChange}
              className={`
            w-full px-4 py-2
            border border-gray-300
            rounded-md
            outline-none
            transition-all duration-300
            focus:border-blue-500
            focus:ring-2 focus:ring-blue-500/30
                  ${errors.Email ? "border-red-500" : "border-gray-300"}

          `} />
            {errors.Email && (
              <p className="text-xs text-red-500! mt-1 font-medium opacity-100">
                {errors.Email}
              </p>
            )}
          </div>

          <div className="mb-5">
            <label className="block text-sm font-medium mb-1" htmlFor='Password'>Password</label>
            <div className="relative">
              <input
                type={showPassword ? "text" : "password"} required
                placeholder="Enter password" id='Password' name='Password'
                value={formData.Password}
                onChange={handleInputChange} autoComplete="new-password"
                className={`w-full px-4 py-2 pr-10
                  border border-gray-300
                  rounded-md
                  outline-none
                  transition-all duration-300
                  focus:border-blue-500
                  focus:ring-2 focus:ring-blue-500/30
                  ${errors.Password ? "border-red-500" : "border-gray-300"}
                `} />

              <span
                onClick={() => setShowPassword(!showPassword)}
                className="absolute right-3 top-1/2 -translate-y-1/2 cursor-pointer text-gray-500 hover:text-gray-700"
              >
                {showPassword ? <FaEyeSlash /> : <FaEye />}
              </span>
            </div>
            {errors.Password && (
              <p className="text-xs text-red-500! mt-1 font-medium opacity-100">
                {errors.Password}
              </p>
            )}
          </div>


          <div className="mb-5">
            <label className="block text-sm font-medium mb-1">
              Register As
            </label>

            <div className="flex gap-4">
              <label className="flex items-center gap-2 cursor-pointer">
                <input
                  type="radio"
                  name="RoleName"
                  value="Customer"
                  checked={formData.RoleName === "Customer"}
                  onChange={handleInputChange}
                />
                Customer
              </label>

              <label className="flex items-center gap-2 cursor-pointer">
                <input
                  type="radio"
                  name="RoleName"
                  value="Seller"
                  checked={formData.RoleName === "Seller"}
                  onChange={handleInputChange}
                />
                Seller
              </label>
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