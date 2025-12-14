import Api from "./Api";

export const loginApi = (data) => {
  return Api.post("/User/Login", data);
};

export const signupApi = (data) => {
  return Api.post("/User/Signup", data);
};

