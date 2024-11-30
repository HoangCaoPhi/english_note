import axios, { AxiosInstance, AxiosResponse, AxiosError, InternalAxiosRequestConfig } from 'axios';

// Create an Axios instance
const axiosClient: AxiosInstance = axios.create({
  baseURL: '/api', // Use relative URL for the reverse proxy
  headers: {
    'Content-Type': 'application/json',  // Default content type for JSON requests
  },
});

// Request Interceptor to add token to headers if available
axiosClient.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    // Get access token from localStorage (or other secure storage)
    const accessToken = localStorage.getItem('access_token');
    
    if (accessToken) {
      // Attach the access token to the Authorization header
      config.headers['Authorization'] = `Bearer ${accessToken}`;
    }
    
    return config;
  },
  (error: AxiosError) => {
    // Handle any request errors
    return Promise.reject(error);
  }
);

// Response Interceptor to handle errors globally
axiosClient.interceptors.response.use(
  (response: AxiosResponse) => {
    return response;
  },
  (error: AxiosError) => {
    // Handle response errors (e.g., 401, 403)
    if (error.response && error.response.status === 401) {
      // Optionally, handle token expiry here (e.g., redirect to login)
      localStorage.removeItem('access_token');
      window.location.href = '/login'; // Redirect to login page
    }
    return Promise.reject(error);
  }
);

// Helper methods for GET, POST, PUT, PATCH, DELETE requests
const apiService = {
  // GET Request
  get: async <T>(url: string, config?: any): Promise<AxiosResponse<T>> => {
    return axiosClient.get<T>(url, config);
  },

  // POST Request
  post: async <T>(url: string, data: any, config?: any): Promise<AxiosResponse<T>> => {
    return axiosClient.post<T>(url, data, config);
  },

  // PUT Request
  put: async <T>(url: string, data: any, config?: any): Promise<AxiosResponse<T>> => {
    return axiosClient.put<T>(url, data, config);
  },

  // PATCH Request
  patch: async <T>(url: string, data: any, config?: any): Promise<AxiosResponse<T>> => {
    return axiosClient.patch<T>(url, data, config);
  },

  // DELETE Request
  delete: async <T>(url: string, config?: any): Promise<AxiosResponse<T>> => {
    return axiosClient.delete<T>(url, config);
  },
};

export default apiService;
