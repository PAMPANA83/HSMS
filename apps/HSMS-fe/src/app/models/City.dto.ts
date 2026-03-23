export interface CityMastersDto {
  id?: number;                    // int? ID
  cityID?: string;               // string? CityID
  cityName?: string;             // string? CityName
  districtID?: number;           // int? DistrictID
  districtName?:string;
  createUserId?: number;         // int? CREATEUSERID
  createdate?: string;           // DateTime? → ISO string
  createTerminalId?: string;     // string? CREATETERMINALID
  editUserId?: number;           // int? EDITUSERID
  editdate?: string;             // DateTime? → ISO string
  editTerminalId?: string;       // string? EDITTERMINALID
}


export interface CreateCityDto {
    cityID?: string; 
  cityName: string;
  districtID: number;
}
