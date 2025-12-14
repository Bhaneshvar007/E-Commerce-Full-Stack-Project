import React, { useState } from 'react'

function Login() {

    let [IsReset, SetIsReset] = useState(false);


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

                    <div className="mb-5">
                        <label className="block text-sm font-medium mb-1" htmlFor='password'>Password</label>
                        <div className="relative">
                            <input
                                type="password" id='password'
                                placeholder="Enter password"
                                className="
                                w-full px-4 py-2 pr-10
                                border border-gray-300
                                rounded-md
                                outline-none
                                transition-all duration-300
                                focus:border-blue-500
                                focus:ring-2 focus:ring-blue-500/30
                                "
                            />

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