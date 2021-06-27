import axios from "axios";

export const TOKEN_KEY = "@ecommerce:user";
export const getToken = () => localStorage.getItem(TOKEN_KEY);

const api = axios.create({
  baseURL: "https://localhost:5001/api/ecommerce/",
  headers: {
    "Content-type": "application/json"
  }
});


api.interceptors.request.use(async config => {
  const result = getToken();
  let userToken = JSON.parse(result);
  if (userToken) {
    config.headers.Authorization = `Bearer ${userToken?.token}`;
  }
  return config;
});

export default api;