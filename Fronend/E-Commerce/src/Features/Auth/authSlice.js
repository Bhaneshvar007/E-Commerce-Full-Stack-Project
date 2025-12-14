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
    "/User/Signup",
    async (data, thunkAPI) => {
        try {
            const res = await signupApi(data);
            return res.data;
        } catch (err) {
            return thunkAPI.rejectWithValue(err.response.data);
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
    },
    reducers: {
        logout: (state) => {
            state.user = null;
            state.token = null;
            localStorage.clear();
        },
    },
    extraReducers: (builder) => {
        builder
            // LOGIN
            .addCase(LoginUser.pending, (state) => {
                state.isLoading = true;
            })
            .addCase(LoginUser.fulfilled, (state, action) => {
                state.isLoading = false;
                state.user = action.payload.user;
                state.token = action.payload.token;
                localStorage.setItem("token", action.payload.token);
            })
            .addCase(LoginUser.rejected, (state, action) => {
                state.isLoading = false;
                state.error = action.payload || action.error.message;
            })

            // SIGNUP
            .addCase(SignupUser.pending, (state) => {
                state.isLoading = true;
            })
            .addCase(SignupUser.fulfilled, (state, action) => {
                state.isLoading = false;
                state.user = action.payload.user;
            })
            .addCase(SignupUser.rejected, (state, action) => {
                state.isLoading = false;
                state.error = action.payload || action.error.message;
            });
    },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
