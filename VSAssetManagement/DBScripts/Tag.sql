--Insert
USE [VISWASAMUDRA]
GO

INSERT INTO [dbo].[TAG]
           ([CODE]
           ,[NAME]
           ,[STATUS]
           ,[CREATED_BY]
           ,[LAST_UPDATED_BY]
           ,[RECORD_STATUS])
     VALUES
           ('ABC',
		   'Record1',
		   1,
		   'User1',
		   'User1',
		   0)
GO


