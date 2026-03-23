

export interface MainDepartmentMastersDto {
  id?: number | null;
  mainDeptID?: string | null;
  mainDepartmentName?: string | null;
  createUserId?: number | null;
  createDate?: string | null;
  createTerminalId?: string | null;
  editUserId?: number | null;
  editDate?: string | null;
  editTerminalId?: string | null;
}

export interface CreateMainDepartmentDto {
  id: number;
  mainDeptID?: string;
  mainDepartmentName: string;
}

export interface UpdateMainDepartmentDto {
  id: number;
  mainDeptID?: string;
  mainDepartmentName: string;
}
