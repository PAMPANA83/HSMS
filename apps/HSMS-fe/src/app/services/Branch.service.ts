import { apiClient } from "../api-client";
import { CreateBranchDto,UpdateBranchDto } from "../models/Branch.dto";

export const getBranch = async () => {
  const response = await apiClient.get("/BranchMaster/GetAllRecord");
  return response.data;
};

export const createBranch = async (data: CreateBranchDto) => {
  const response = await apiClient.post("/BranchMaster/NewCountry", data);
  return response.data;
};

export const deleteBranch = async (id: number) => {
  const response = await apiClient.delete(`/BranchMaster/${id}`);
  return response.data;
};

export const updateBranch = async (data: UpdateBranchDto) => {
  const response = await apiClient.put(`/BranchMaster/Update`, data);
  return response.data;
};

