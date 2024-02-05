import axios, { AxiosResponse } from 'axios';

interface User {
    id: string;
    email: string;
}

const Users = {
    async SignIn(email: string): Promise<any> {
            const response: AxiosResponse<{ user: User }> = await axios.post('https://localhost:7042/api/user', { email });
            console.log(response.data);
            return response.data;
    }
}

export default Users;