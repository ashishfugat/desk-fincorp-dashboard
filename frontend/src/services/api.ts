import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7283/api", // your .NET backend swagger URL
});

export default api;