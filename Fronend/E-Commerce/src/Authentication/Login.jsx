import React, { useEffect, useState } from 'react'
import { FaEye, FaEyeSlash } from "react-icons/fa";
import { EmailValidatore, PasswordValidatore } from '../utils/CommonLogic';
import { useDispatch, useSelector } from 'react-redux';
import { LoginUser } from '../Customer/Features/Auth/authSlice';
import { showError, showSuccess } from '../utils/toast';
import { useNavigate } from 'react-router-dom';



const Login = () => {

    let [IsReset, SetIsReset] = useState(false);
    const dispatch = useDispatch();
    const { isLoading, successMessage, error } = useSelector((state) => state.auth);
    const [showPassword, setShowPassword] = useState(false);
    const navigation = useNavigate();


    const [formData, setFormData] = useState({
        Email: "",
        Password: "",
    });



    const [errors, setErrors] = useState({
        Email: null,
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;

        setFormData({
            ...formData,
            [name]: value,
        });

        if (name === "Email") {
            setErrors((prev) => ({
                ...prev,
                Email: EmailValidatore(value),
            }));
        }

    };


    useEffect(() => {
 
        if (successMessage) {
            showSuccess(successMessage);
            navigation("/Home")
        }
        if (error) {
            showError(error);
        }
    }, [successMessage, error])


    const handleInputSubmit = (e) => {
        e.preventDefault();
        dispatch(LoginUser(formData));
    }

    return (
        <div className="min-h-screen flex items-center justify-center bg-gray-100">

            {!IsReset ? (
                <div className="w-full max-w-md p-12 shadow rounded-xl">

                    <h1 className="text-3xl font-bold text-center mb-2 text-gray-700;">
                        Welcome Back
                    </h1>
                    <p className="text-center text-gray-500 mb-8">
                        Sign in to your ShopEase account
                    </p>

                    <form onSubmit={handleInputSubmit}>
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
                                    type={showPassword ? "text" : "password"}
                                    placeholder="Enter password" id='Password' name='Password' required
                                    value={formData.password}
                                    onChange={handleInputChange} autoComplete="new-password"
                                    className={`w-full px-4 py-2 pr-10
                                      border border-gray-300
                                      rounded-md
                                      outline-none
                                      transition-all duration-300
                                      focus:border-blue-500
                                      focus:ring-2 focus:ring-blue-500/30
                                      ${errors.password ? "border-red-500" : "border-gray-300"}
                                    `} />

                                <span
                                    onClick={() => setShowPassword(!showPassword)}
                                    className="absolute right-3 top-1/2 -translate-y-1/2 cursor-pointer text-gray-500 hover:text-gray-700"
                                >
                                    {showPassword ? <FaEyeSlash /> : <FaEye />}
                                </span>
                            </div>

                        </div>

                        <div className="flex items-center justify-between mb-6">
                            <button className="text-sm text-blue-600 hover:underline cursor-pointer"
                                onClick={() => SetIsReset(true)}
                            >
                                Forgot Your Password?
                            </button>
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
                            Log In
                        </button>
                    </form>


                    <div className="flex items-center my-8">
                        <div className="flex-1 h-px bg-gray-300"></div>
                        <span className="px-3 text-sm text-gray-400">OR LOGIN WITH</span>
                        <div className="flex-1 h-px bg-gray-300"></div>
                    </div>



                    <div className="flex gap-4 mb-6">
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
                        Don&apos;t Have An Account?
                        <a href="/SignUp" className="text-blue-600 ml-1 hover:underline">
                            Register Now.
                        </a>
                    </p>

                </div>


                // Reset Password 


            ) : (

                <div className="w-full max-w-md p-12 shadow rounded-xl">

                    <h1 className="text-3xl font-semibold text-center mb-2">
                        Reset Password
                    </h1>
                    <p className="text-center text-gray-500 mb-8">
                        Enter your email address and we'll send you a reset link.
                    </p>

                    <div className="mb-5">
                        <label className="block text-sm font-medium mb-1" htmlFor='email'>Email</label>
                        <input
                            type="email" id='email'
                            placeholder="Enter your email"
                            className="
                                w-full px-4 py-2
                                border border-gray-300
                                rounded-md
                                outline-none
                                transition-all duration-300
                                focus:border-blue-500
                                focus:ring-2 focus:ring-blue-500/30
                            "
                        />
                    </div>


                    <button
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
                        Send Otp
                    </button>

                    <p className="text-center text-sm text-gray-500 mt-2">
                        Remember Your Password?
                        <button className="text-blue-600 ml-1 hover:underline cursor-pointer"
                            onClick={() => SetIsReset(false)}
                        >
                            Back to Login.
                        </button>
                    </p>

                </div>
            )}
        </div>

    )
}

export default Login;