import axios, { type AxiosInstance } from "axios";

export function useAxios(): AxiosInstance {
  const instance = axios.create({
    baseURL: "http://localhost:5050/api", // TODO Set correct value
  });

  instance.interceptors.request.use((request) => {
    // TODO Set access token conditionally
    // TODO Log outgoing request
    return request;
  });

  instance.interceptors.response.use(
    (response) => {
      // TODO Log incoming response
      return response;
    },
    (err) => {
      // TODO Log error
      // TODO Handle error
    }
  );

  return instance;
}
