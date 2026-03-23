import { apiClient } from "../api-client";
import{CreateCityDto} from "../models/City.dto";
import {ApiResponse} from "../models/country.dto";
export const getCity = async () => {
  const response = await apiClient.get("/CityMaster/GetAllCityMaster");
  return response.data;
};

export const createCity = async (data: CreateCityDto):Promise<ApiResponse<CreateCityDto> >=> {
 
    try {
      const response = await apiClient.post<ApiResponse<CreateCityDto>>(
        "/CityMaster/CreateCity", 
        data
      );
      return response.data;
    } catch (error: any) {
      throw new Error(error?.response?.data?.message);
    }
};

export const deleteCity = async (id: number) => {
  const response = await apiClient.delete(`/CityMaster/${id}`);
  return response.data;
};

export const getCitiesByDistrict = async (id: number) => {
  const response = await apiClient.delete(`/DistrictMaster/${id}`);
  return response.data;
};
