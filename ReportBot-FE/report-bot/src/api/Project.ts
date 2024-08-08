import ApiResponse from "./models/response/ApiResponse";
import ProjectResponse from "./models/response/ProjectResponse";
import Api from "./repository/Api";

const Project = {
    getAll: async (): Promise<ApiResponse<ProjectResponse[]>> => {
        const response = await Api.get<ProjectResponse[]>("/project");

        return response;
    }
};

export default Project;