import { apiClient } from "../api-client";
import{CreateCompanyDto} from "../models/Company.dto";

export const getCompany = async () => {
  const response = await apiClient.get("/CompanyMaster/GetAllRecord");
  return response.data;
};

export const createCompany = async (data: CreateCompanyDto) => {
  const response = await apiClient.post("/CompanyMaster/NewCountry", data);
  return response.data;
};

export const deleteCompany = async (id: number) => {
  const response = await apiClient.delete(`/CompanyMaster/${id}`);
  return response.data;
};