// src/models/state.dto.ts
export interface StateMastersDto {
  id?: number;                    // int? ID
  stateID?: string;              // string? stateID  
  stateName?: string;            // string? StateName
  stateCode?: number;            // int? StateCode
  countryID?: number;            // int? CountryID
  CountryName:string;           // string CountryName (from related CountryMasters)
  createUserId?: number;         // int? CREATEUSERID
  createDate?: string;           // DateTime? → ISO string
  createTerminalId?: string;     // string? CREATETERMINALID
  editUserId?: number;           // int? EDITUSERID
  editDate?: string;             // DateTime? → ISO string
  editTerminalId?: string;       // string? EDITTERMINALID
}


export interface CreateStateMasters {
  
  stateID?: string;              // string? stateID  
  stateName?: string;            // string? StateName
  stateCode?: number;            // int? StateCode
  countryID?: number;            // int? CountryID
  
}

export interface UpdateStateMasters {
   id?: number;  
  stateID?: string;              // string? stateID  
  stateName?: string;            // string? StateName
  stateCode?: number;            // int? StateCode
  countryID?: number;            // int? CountryID
  
}
