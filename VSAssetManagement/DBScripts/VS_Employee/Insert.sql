USE [VS_EMPLOYEE]
GO

INSERT INTO [dbo].[COMPANY]
           ([Name]
           ,[Code]
           ,[CreatedBy]
           ,[Is_Active])
     VALUES
           ('Viswasamudra'
           ,'WINGZ'
           ,'User1'
           ,1)
GO


INSERT INTO [dbo].[DIVISION]
           ([CompanyUID]
           ,[Name]
           ,[Code]
           ,[CompanyCode]
           ,[CreatedBy]
           ,[Is_Active])
     VALUES
           ('1B3301C6-3194-44BD-9AF9-30F968564CB3'
           ,'Division1'
           ,'TRACZ'
           ,'WINGZ'
           ,'User1'
           ,'1')
GO

INSERT INTO [dbo].[ZONES]
           ([DivisionUID]
           ,[Name]
           ,[Code]
           ,[divisionCode]
           ,[CreatedBy]
           ,[Is_Active])
     VALUES
           ('A543C6B6-6137-4D3F-92E2-D03A729781BB'
           ,'Zone1'
           ,'TKZN1'
           ,'TRACZ'
           ,'User1'
           ,1)
GO

INSERT INTO [dbo].[BRANCH]
           ([ZoneUID]
           ,[Name]
           ,[Code]
           ,[ZoneCode]
           ,[CreatedBy]
           ,[Is_Active])
     VALUES
           ('EBAD3D39-201D-4290-8B39-6AF5606E6D01'
           ,'Branch1'
           ,'BRTCZ'
           ,'TKZN1'
           ,'User1'
           ,1)
GO

INSERT INTO [dbo].[DEPARTMENT]
           ([CompanyUID]
           ,[Name]
           ,[Code]
           ,[CompanyCode]
           ,[CreatedBy])
     VALUES
           ('1B3301C6-3194-44BD-9AF9-30F968564CB3'
           ,'Department1'
           ,'DTRCZ'
           ,'WINGZ'
           ,'User1')
GO

INSERT INTO [dbo].[DEPUTATION]
           ([DepartmentUID]
           ,[Name]
           ,[Code]
           ,[CreatedBy])
     VALUES
           ('FCBD7BFC-B219-429E-9723-A5442BE01DBD'
           ,'Deputation1'
           ,'DETRZ'
           ,'User1')
GO

INSERT INTO [dbo].[LOCATIONS]
           ([BranchUID]
           ,[Name]
           ,[Code]
           ,[BranchCode]
           ,[CreatedBy])
     VALUES
           ('F13BA215-9977-4207-81D5-D9F069FADA50'
           ,'Location1'
           ,'LOCTZ'
           ,'BRTCZ'
           ,'User1')
GO

INSERT INTO [dbo].[SALUTATION]
           ([DepartmentUID]
           ,[Name]
           ,[Code]
           ,[CreatedBy])
     VALUES
           ('FCBD7BFC-B219-429E-9723-A5442BE01DBD'
           ,'Salutation1'
           ,'SALTZ'
           ,'User1')
GO
