Create DATABASE VS_EMPLOYEE

USE VS_EMPLOYEE

Create Table EMPLOYEE_MASTER
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
Employee_Code varchar(150),
First_Name varchar(150),
Middle_Name varchar(150),
Last_Name varchar(150),
Gender varchar(1),
Father_Husband_Name varchar(150),
Dateof_Birth datetime,
Placeof_Birth varchar(150),
Nationality varchar(150),
Religion varchar(150),
Caste varchar(150),
Language varchar(150),
Blood_Group varchar(150),
Adhar_No varchar(150),
Adhar_Name varchar(150),
Date_of_Joining datetime,
CreatedBy varchar(150),
CreatedDate datetime default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime default getdate(),
Is_Active char,
CONSTRAINT EMPLOYEE_MASTER_PK primary key (UNIQUE_ID)
)


Create Table COMPANY
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
Name varchar(150),
Code varchar(15),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT COMPANY_PK primary key (UNIQUE_ID)
)

Create Table DIVISION
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
CompanyUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
CompanyCode varchar(15),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT DIVISION_PK primary key (UNIQUE_ID),
CONSTRAINT DIVISION_COMPANY_FK foreign key (CompanyUID)  REFERENCES COMPANY(UNIQUE_ID)  
)

Create Table ZONES
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
DivisionUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
divisionCode varchar(15),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT ZONES_PK primary key (UNIQUE_ID),
CONSTRAINT ZONES_DIVISION_FK foreign key (DivisionUID)  REFERENCES DIVISION(UNIQUE_ID)  
)

Create Table BRANCH
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
ZoneUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
ZoneCode varchar(15),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT BRANCH_PK primary key (UNIQUE_ID),
CONSTRAINT BRANCH_ZONE_FK foreign key (ZoneUID)  REFERENCES ZONES(UNIQUE_ID)  
)

Create Table LOCATIONS
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
BranchUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
BranchCode varchar(15),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT LOCATION_PK primary key (UNIQUE_ID),
CONSTRAINT LOCATION_BRANCH_FK foreign key (BranchUID)  REFERENCES BRANCH(UNIQUE_ID)  
)

Create Table DEPARTMENT
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
CompanyUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
CompanyCode varchar(15),
CreatedBy varchar(150),
CreatedDate datetime,
ModifiedBy varchar(150),
ModifiedDate datetime,
Is_Active char,
CONSTRAINT DEPARTMENT_PK primary key (UNIQUE_ID),
CONSTRAINT DEPARTMENT_COMPANY_FK foreign key (CompanyUID)  REFERENCES COMPANY(UNIQUE_ID)  
)

Create Table DEPUTATION
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
DepartmentUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
CreatedBy varchar(150),
CreatedDate datetime,
ModifiedBy varchar(150),
ModifiedDate datetime,
Is_Active char,
CONSTRAINT DEPUTATION_PK primary key (UNIQUE_ID),
CONSTRAINT DEPUTATION_DEPARTMENT_FK foreign key (DepartmentUID)  REFERENCES DEPARTMENT(UNIQUE_ID)  
)

Create Table SALUTATION
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
DepartmentUID uniqueidentifier,
Name varchar(150),
Code varchar(15),
CreatedBy varchar(150),
CreatedDate datetime,
ModifiedBy varchar(150),
ModifiedDate datetime,
Is_Active char,
CONSTRAINT SALUTATION_PK primary key (UNIQUE_ID),
CONSTRAINT SALUTATION_DEPARTMENT_FK foreign key (DepartmentUID)  REFERENCES DEPARTMENT(UNIQUE_ID) 
)


Create Table EMPLOYEE_ROLES
(
Id int identity(1,1),
Unique_Id uniqueidentifier default newID(),
EmployeeUID uniqueidentifier,
Company_Code varchar(150),
Division_Code varchar(150),
Zone_Code varchar(150),
Branch_Code varchar(150),
Location_Code varchar(150),
Department_Code varchar(150),
Deputation_Code varchar(150),
Salutation varchar(150),
OrgChartReportingCode varchar(150),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT EMPLOYEE_ROLES_PK primary key (UNIQUE_ID),
CONSTRAINT ROLE_EMPLOYEE_MASTER_FK foreign key (EmployeeUID)  REFERENCES EMPLOYEE_MASTER(UNIQUE_ID),  
CONSTRAINT COMPANY_ROLE_FK foreign key (EmployeeUID)  REFERENCES COMPANY(UNIQUE_ID),
CONSTRAINT DIVISION_ROLE_FK foreign key (EmployeeUID)  REFERENCES DIVISION(UNIQUE_ID),
CONSTRAINT ZONES_ROLE_FK foreign key (EmployeeUID)  REFERENCES ZONES(UNIQUE_ID),
CONSTRAINT BRANCH_ROLE_FK foreign key (EmployeeUID)  REFERENCES BRANCH(UNIQUE_ID),
CONSTRAINT LOCATIONS_ROLE_FK foreign key (EmployeeUID)  REFERENCES LOCATIONS(UNIQUE_ID),
CONSTRAINT DEPARTMENT_ROLE_FK foreign key (EmployeeUID)  REFERENCES DEPARTMENT(UNIQUE_ID),
CONSTRAINT DEPUTATION_ROLE_FK foreign key (EmployeeUID)  REFERENCES DEPUTATION(UNIQUE_ID),
CONSTRAINT SALUTATION_ROLE_FK foreign key (EmployeeUID)  REFERENCES SALUTATION(UNIQUE_ID),
)

Create Table EMPLOYEE_DETAILS
(
ID int identity(1,1),
UNIQUE_ID uniqueidentifier default newID(),
Marital_Status varchar(150),
Wedding_Anniversary datetime,
Smoker char,
Handicap char,
Address_1 varchar(max),
Address_2 varchar(max),
CityName varchar(150),
StateName varchar(150),
Pin_Code varchar(15),
Mobile varchar(15),
Home varchar(15),
Other varchar(15),
Email_Work varchar(150),
Email_Personal varchar(150),
P_Address_1 varchar(150),
P_Address_2 varchar(150),
P_CityName varchar(150),
P_StateName varchar(150),
P_Pin_Code varchar(150),
P_Mobile varchar(150),
P_Home varchar(150),
EmegContactName varchar(150),
Relation varchar(150),
Emeg_Address_1 varchar(max),
Emeg_Address_2 varchar(max),
Emeg_CityName varchar(150),
Emeg_StateName varchar(150),
Emeg_Pin_Code varchar(150),
Emeg_Mobile varchar(150),
Emeg_Home varchar(150),
Emeg_Email_Personal varchar(150),
CreatedBy varchar(150),
CreatedDate datetime  default getdate(),
ModifiedBy varchar(150),
ModifiedDate datetime  default getdate(),
Is_Active char,
CONSTRAINT EMPLOYEE_DETAILS_PK primary key (UNIQUE_ID),
CONSTRAINT EMPLOYEE_DETAILS_EMPLOYEE_MASTER_FK foreign key (UNIQUE_ID)  REFERENCES EMPLOYEE_MASTER(UNIQUE_ID) 
)

Create Table EMPLOYEE_STATUS
(
	ID int identity(1,1),
	UNIQUE_ID uniqueidentifier default newID(),
	EmployeeStatus_Code varchar(150),	
	Probation_Period varchar(150),
	Confirmation_Date datetime,
	ExtConfirmation_Date datetime,
	Designation_Name varchar(150),
	Functional_Designation varchar(150),
	Grade_Name varchar(150),
	Relevant_Experince varchar(150),
	Past_Experience varchar(150),
	Total_Experience varchar(150),
	CategoryName varchar(150),
	Salary_Group varchar(150),
	Notice_Period varchar(150),
	Band_Name varchar(150),
	SubDepartment_Name varchar(150),
	AttCard_Number varchar(150),
	InterviewerEmpCode varchar(150),
	CostCenter_Name varchar(150),
	Salary_Type varchar(150),
	CTC	varchar(150),
    Incentives varchar(150),	
    Pay_Components varchar(150),
	Performance_Bonus varchar(150),
	Salary_On_Hold varchar(150),
	Overtime_Applicable varchar(150),
	CreatedBy varchar(150),
	CreatedDate datetime  default getdate(),
	ModifiedBy varchar(150),
	ModifiedDate datetime  default getdate(),
	Is_Active char,
	CONSTRAINT EMPLOYEE_STATUS_PK primary key (UNIQUE_ID),
	CONSTRAINT EMPLOYEE_STATUS_EMPLOYEE_MASTER_FK foreign key (UNIQUE_ID)  REFERENCES EMPLOYEE_MASTER(UNIQUE_ID) 
)