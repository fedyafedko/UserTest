import axios, { AxiosResponse } from "axios"
import { TestBody } from "./type/TestBody";
import TestByIdBody from "./type/TestByIdBody";
import UserAnswerBody from "./type/UserAnswerBody";

interface TestByIdResponse {
    test: TestByIdBody;
  }

const TestAPI = {
    async TestForUser (id: string | null): Promise<any> {
        const response: AxiosResponse<{ test: TestBody[] }> = await axios.get(`https://localhost:7042/api/test/user/${id}`);
        return response.data;
    },

    async TestById(id: string | undefined): Promise<any> {
        try {
          const response: AxiosResponse<TestByIdResponse> = await axios.get(`https://localhost:7042/api/test/${id}`);
          return response.data;
        } catch (error) {
          console.error('Error fetching test data:', error);
          return undefined;
        }
      },
    
      async AddAnswer(body: UserAnswerBody | undefined): Promise<any> {
        const response: AxiosResponse = await axios.post('https://localhost:7042/api/test/AddUserAnswer', body);
        console.log(response.data);
        return response.data;
    }    
}

export default TestAPI;
