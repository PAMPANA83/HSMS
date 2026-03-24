
export interface CompanyMastersDto {
  id?: number;                    // int? ID
  companyID?: string;            // string? CompanyID
  companyName?: string;          // string? CompanyName
  companyCode?: number;          // int? CompanyCode
  installationDate?: string;     // DateTime? → ISO string
  address?: string;              // string? Address
  countryID?:number;
  stateID?: number;              // int? StateID
  districtID?: number;           // int? DistrictID
  cityID?: number;               // int? CityID
  areaID?: number;               // int? AreaID
  mobile1?: string;              // string? Mobile1
  mobile2?: string;              // string? Mobile2
  phone?: string;                // string? Phone
  contactPerson?: string;        // string? ContactPerson
  createUserId?: number;         // int? CREATEUSERID
  createDate?: string;           // string? CREATEDATE (ISO string)
  createTerminalId?: string;     // string? CREATETERMINALID
  editUserId?: number;           // int? EDITUSERID
  editDate?: string;             // string? EDITDATE (ISO string)
  editTerminalId?: string;       // string? EDITTERMINALID
}

export interface CreateCompanyDto {
  companyID: string; 
  companyName: string;
  companyCode: number;
  installationDate: string;      // ISO date string
  address: string;
  stateID: number;
  districtID: number;
  cityID: number;
  areaID: number;
  mobile1?: string;
  mobile2?: string;
  phone?: string;
  contactPerson?: string;
}
