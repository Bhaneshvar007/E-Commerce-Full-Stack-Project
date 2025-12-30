import Api from "./Api";

export const loginApi = (data) => {
  return Api.post("/User/Login", data);
};

export const signupApi = (data) => {
  debugger
  return Api.post("/User/SignUp", data);
};

