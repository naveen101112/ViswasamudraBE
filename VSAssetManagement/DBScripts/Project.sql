--Insert

USE [VISWASAMUDRA]
GO

INSERT INTO [dbo].[PROJECT]
           ([CODE]
           ,[NAME]
           ,[TYPE]
           ,[CLIENT_NAME]
           ,[START_DATE]
           ,[END_DATE]
           ,[PROJECT_SITE_HEAD]
           ,[SITE_HEAD_MOBILE]
           ,[GSTIN_NO]
           ,[CITY_TOWN]
           ,[ADDRESS_LINE_1]
           ,[ADDRESS_LINE_2]
           ,[CREATED_BY]
           ,[LAST_UPDATED_BY]
           ,[RECORD_STATUS]
           ,[COMPANY]
           ,[DEPARTMENT]
           ,[PROJECT_HEAD])
     VALUES
           ('PRC'
           ,'Test2'
           ,'Full Time'
           ,'Viswasamudra'
           ,GETDATE()
           ,GETDATE()+365
           ,'KKD'
           ,'987654321012'
           ,'GSTIN256413'
           ,'HYD'
           ,'Hyderabad'
           ,''
           ,'User1'
           ,'User1'
           ,0
           ,'VS'
           ,'Tracking'
           ,'Nagarjun')
GO


