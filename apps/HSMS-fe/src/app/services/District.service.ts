import { apiClient } from "../api-client";
import{CreateDistrictDto,UpdateDistrictDto} from "../models/District.Dto"
import {ApiResponse} from "../models/country.dto"
export const getDistrict = async () => {
  const response = await apiClient.get("/DistrictMaster/GetAllDistrict");
  return response.data;
};



export const createDistrict = async (data: CreateDistrictDto): Promise<ApiResponse<CreateDistrictDto>> => {
  try {
    const response = await apiClient.post<ApiResponse<CreateDistrictDto>>(
      "/DistrictMaster/CreateDistrict", 
      data
    );
    return response.data;
  } catch (error: any) {
    throw new Error(error?.response?.data?.message);
  }
};

export const deleteDistrict = async (id: number):Promise<ApiResponse<null>> => {

   try {
  const res=  await apiClient.delete(`/DistrictMaster/DeleteDistrictId/${id}`);
    
    // Manually create success response for 204
    return { success: true, message: res.data };
  } catch (error: any) {
    throw new Error(error?.response?.data?.message || 'Delete failed');
  }

};

export const updateDistrict = async (data: UpdateDistrictDto) => {
  const response = await apiClient.put(`/DistrictMaster/Update`, data);
  return response.data;
};


export const getDistrictsByState = async (id: number) => {
  const response = await apiClient.delete(`/DistrictMaster/${id}`);
  return response.data;
};
