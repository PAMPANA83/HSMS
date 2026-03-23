export interface AreaMastersDto {
  id?: number;                    // int? ID
  areaID?: string;               // string? AreaID
  areaName?: string;             // string? AreaName
  areaPINCode?: number;          // int? AreaPINCode
  cityID?: number;               // string? CityID
  cityName?: string;  
  branchID?: number;             // string? BranchID
  districtName?: string;  
  createUserId?: number;         // int? CREATEUSERID
  createdate?: string;           // DateTime? → ISO string
  createTerminalId?: string;     // string? CREATETERMINALID
  editUserId?: number;           // int? EDITUSERID
  editDate?: string;             // DateTime? → ISO string
  editTerminalId?: string;       // string? EDITTERMINALID
  active?: boolean;              // bool? Active
}


export interface CreateAreaDto {
  areaID: string;
  areaName: string;
  areaPINCode: number;
  cityID: string;
  branchID?: string;
  active?: boolean;
}

