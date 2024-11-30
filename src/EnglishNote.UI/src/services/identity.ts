import axios from 'axios';
 
interface LoginResponse {
  access_token: string;
  refresh_token: string;
}

export const login = async (email: string, password: string): Promise<boolean> => {
  try {
    const response = await axios.post<LoginResponse>(
      `/api/identity/login`,
      {
        email: email,  
        password: password
      },
      {
        headers: {
          'Content-Type': 'application/json',  
        },
      }
    );
    
    const { access_token, refresh_token } = response.data;
    localStorage.setItem('access_token', access_token);
    localStorage.setItem('refresh_token', refresh_token);

    return true;
  } catch (error) {
    console.error('Error logging in:', error);
    return false;
  }
};

 
export const signUp = async (email: string, password: string): Promise<any> => {
  try {
    const response = await axios.post(
      `/api/identity/register`,  
      {
        email,
        password,
      },
      {
        headers: {
          'Content-Type': 'application/json',  
        },
      }      
    );
    return response.data;
  } catch (error) {
    console.error('Error signing up:', error);
    return false;
  }
};
 
export const logout = () => {
  localStorage.removeItem('access_token');
  localStorage.removeItem('refresh_token');
};
