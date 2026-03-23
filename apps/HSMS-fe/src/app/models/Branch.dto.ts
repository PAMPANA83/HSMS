// src/models/branch.dto.ts
export interface BranchMastersDto {
  id?: number;                    // int? ID
  branchID?: string;             // string? BranchID
  branchName?: string;           // string? BranchName
  branchHeader?: string;         // string? BranchHeader
  registerName?: string;         // string? RegisterName
  labHeader?: string;            // string? LABHeader
  companyID?: number;            // int? CompanyID
  address?: string;              // string? Address
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

export interface CreateBranchDto {
  id?: number;  
  branchID?: string;  
  branchName: string;
  branchHeader?: string;
  registerName?: string;
  labHeader?: string;
  companyID: number;
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


export interface UpdateBranchDto {
  id?: number;  
  branchID?: string;  
  branchName: string;
  branchHeader?: string;
  registerName?: string;
  labHeader?: string;
  companyID: number;
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