import { apiClient } from "../api-client";
import{CreateMainDepartmentDto} from "../models/MainDepartment.dto";


export const getAllMainDepartment= async () => {
  const response = await apiClient.get("/MainDepartmentMasters/GetAllRecord");
  return response.data;
};

export const createMainDepartment = async (data: CreateMainDepartmentDto) => {
  const response = await apiClient.post("/MainDepartmentMasters/NewCountry", data);
  return response.data;
};


export const deleteMainDepartment = async (id: number) => {
  const response = await apiClient.delete(`/MainDepartmentMasters/${id}`);
  return response.data;
};