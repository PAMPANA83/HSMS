import { apiClient } from "../api-client";
import { CreateAreaDto } from "../models/Area.dto";
import {ApiResponse} from "../models/country.dto";
export const getAllArea = async () => {
  const response = await apiClient.get("/AreaMaster/GetAllAreaMaster");
  return response.data;
};



export const createArea = async (data: CreateAreaDto):Promise<ApiResponse<CreateAreaDto> >=> {
 
    try {
      const response = await apiClient.post<ApiResponse<CreateAreaDto>>(
        "/AreaMaster/CreateArea", 
        data
      );
      return response.data;
    } catch (error: any) {
      throw new Error(error?.response?.data?.message);
    }
};

export const deleteArea = async (id: number) => {
  const response = await apiClient.delete(`/AreaMaster/${id}`);
  return response.data;
};


export const getAreasByCity = async (id: number) => {
  const response = await apiClient.delete(`/DistrictMaster/${id}`);
  return response.data;
};