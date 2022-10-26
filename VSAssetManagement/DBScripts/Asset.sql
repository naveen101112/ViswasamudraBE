--Insert

USE [VISWASAMUDRA]
GO

INSERT INTO [dbo].[ASSET]
           ([CODE]
           ,[NAME]
           ,[TYPE]
           ,[SIZE]
           ,[COMPANY_NAME]
           ,[CREATED_BY]
           ,[LAST_UPDATED_BY]
           ,[RECORD_STATUS]
           ,[PROJECT_GUID]
           ,[STORE_GUID]
           ,[BATCH_GUID])
     VALUES
           ('PRC00001'
           ,'New Asset'
           ,'Tracker'
           ,'30'
           ,'Wingz'
           ,'User1'
           ,'User1'
           ,1
           ,'d3829648-9e24-425c-a8fb-9f28faf5f0f8'
           ,'BE4325C2-081D-4624-A627-FDAEF779A2F7'
           ,'6a530837-cb7b-404d-ba78-b37d0770315c')
GO


