import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { loginApi, signupApi } from "../../Services/AuthApi";


export const LoginUser = createAsyncThunk(
    "/User/Login",
    async (data, thunkAPI) => {

        try {
            const res = await loginApi(data);
            return res.data;
        } catch (err) {
            return thunkAPI.rejectWithValue(err.response.data);
        }
    }
);


export const SignupUser = createAsyncThunk(
    "/User/SignUp",
    async (data, thunkAPI) => {
        debugger
        try {
            const res = await signupApi(data);
            debugger
            if (res.data?.status === false) {
                return thunkAPI.rejectWithValue({
                    message: res.data.message || "Signup failed",
                });
            }

            return res.data;
        } catch (err) {
            return thunkAPI.rejectWithValue({
                message: err.response?.data?.message || "Server error",
            });
        }
    }
)


const authSlice = createSlice({
    name: "auth",
    initialState: {
        user: null,
        token: localStorage.getItem("token"),
        isLoading: false,
        error: null,
        successMessage: null,

    },
    reducers: {
        logout: (state) => {
            state.user = null;
            state.token = null;
            localStorage.clear();
        }
    },
    extraReducers: (builder) => {
        builder
            // LOGIN
            .addCase(LoginUser.pending, (state) => {
                state.isLoading = true;
            })
            .addCase(LoginUser.fulfilled, (state, action) => {
                state.isLoading = false;
                state.successMessage = action.payload.message;
                state.token = action.payload.token;
                localStorage.setItem("token", action.payload.token);
            })
            .addCase(LoginUser.rejected, (state, action) => {
                state.isLoading = false;
                state.error = action.payload?.message || "Signup failed";
            })

            // SIGNUP
            .addCase(SignupUser.pending, (state) => {
                state.isLoading = true;
            })
            .addCase(SignupUser.fulfilled, (state, action) => {
                state.isLoading = false;
                state.user = action.payload.user;
                state.successMessage = action.payload.message;
            })
            .addCase(SignupUser.rejected, (state, action) => {
                state.isLoading = false;
                state.error = action.payload?.message || "Signup failed";
            });
    },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
