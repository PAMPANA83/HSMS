import { apiClient } from "../api-client";
import { CreateStateMasters } from "../models/state.dto";
import {ApiResponse} from "../models/country.dto"

export const getState = async () => {
  const response = await apiClient.get("/StateMasters/GetAllStateMaster");
  return response.data;
};



export const createstate = async (data: CreateStateMasters): Promise<ApiResponse<CreateStateMasters>> => {
  try {
    const response = await apiClient.post<ApiResponse<CreateStateMasters>>(
      "/StateMasters/CreateState", 
      data
    );
    return response.data;
  } catch (error: any) {
    throw new Error(error?.response?.data?.message);
  }
};


export const deleteState = async (id: number): Promise<ApiResponse<null>> => {
  try {
  const res=  await apiClient.delete(`/StateMasters/DeleteStateId/${id}`);
    
    // Manually create success response for 204
    return { success: true, message: res.data };
  } catch (error: any) {
    throw new Error(error?.response?.data?.message || 'Delete failed');
  }
};


export const updateCountry = async (data: CreateStateMasters) => {
  const response = await apiClient.put(`/StateMaster/Update`, data);
  return response.data;
};




export const GetStatebycountryID = async (id: number) => {
  const response = await apiClient.get(`/StateMasters/GetStateId/${id}`);
  return response.data;
};
