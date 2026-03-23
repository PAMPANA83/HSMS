export interface DistrictMastersDto {
  id?: number;                    // int? ID
  districtID?: string;           // string? DistrictID
  districtName?: string;         // string? DistrictName
  stateID?: number; 
  stateName?:string;
  createUserId?: number;         // int? CREATEUSERID
  createdate?: string;           // DateTime? → ISO string
  createTerminalId?: string;     // string? CREATETERMINALID
  editUserId?: number;           // int? EDITUSERID
  editdate?: string;             // DateTime? → ISO string
  editTerminalId?: string;       // string? EDITTERMINALID
}

export interface CreateDistrictDto {

  districtID?: string;           // string? DistrictID
  districtName?: string;         // string? DistrictName
  stateID?: number;              // int? StateID
  
}



export interface UpdateDistrictDto {
    id?: number;   
  districtID?: string;           // string? DistrictID
  districtName?: string;         // string? DistrictName
  stateID?: number;              // int? StateID
  
}