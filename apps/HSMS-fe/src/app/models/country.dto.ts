export interface CountryMastersDto {
  id?: number;
  countryCode?: string;
  countryName?: string;
  createUserId?: number;
  createDate?: string;
  createTerminalId?: string;
  editUserId?: number;
  editDate?: string;
  editTerminalId?: string;
}

export interface CountryDto {
  CountryName?: string | null;
}

export interface ApiResponse<T = any> {
  success: boolean;
  data?: T;
  message?: string;
  errors?: string[];
}