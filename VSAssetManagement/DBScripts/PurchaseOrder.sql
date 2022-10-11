--Insert
USE [VISWASAMUDRA]
GO

INSERT INTO [dbo].[PURCHASE_ORDER]
           ([PURCHASE_ORDER_NO]
           ,[PURCHASE_ORDER_DATE]
           ,[RECEIVED_BY]
           ,[CREATED_BY]
           ,[LAST_UPDATED_BY]
           ,[RECORD_STATUS]
     VALUES
           ('ABCD123443434'
           ,GETDATE()-12
           ,'User'
           ,'User1'
           ,'User1'
           ,1)
GO


--Insert PO Batch

USE [VISWASAMUDRA]
GO

INSERT INTO [dbo].[BATCH]
           ([BATCH_NO]
           ,[BATCH_NAME]
           ,[QUANTITY]
           ,[ASSET_TYPE]
           ,[ASSET_SIZE]
           ,[CREATED_BY]
           ,[LAST_UPDATED_BY]
           ,[RECORD_STATUS]
           ,[PURCHASE_BATCH_MASTER_GUID])
     VALUES
           ('1234556'
           ,'First Order Batch'
           ,12
           ,'Tracker Sat'
           ,'30'
           ,'User1'
           ,'User1'
           ,1
           ,'f12e7bc6-6db6-4734-80c8-bbd853c55970')
GO


