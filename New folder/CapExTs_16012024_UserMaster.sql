USE [CapExTS]
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 16/01/2024 18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UserCreate]
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@password varchar (50),
	@Active varchar(10) ,
	@status varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare 
	@data nvarchar(50) ;
    -- Insert statements for procedure here
	
	if(@status='UserCreate_Update')
	begin
	 select  @data=empCode from UserMaster_Temp where empCode=@username
	
	if(@data is null)
	begin
	

	INSERT INTO [dbo].[UserMaster_Temp]
           ([empCode],[password],[isActive])
     VALUES
           (@username, PWDENCRYPT(@password) ,'1')
	
	Select 'User Create SuccessFully'
	end
	if(@data!='' or @data is not null)
	begin


	UPDATE [dbo].[UserMaster_Temp]
   SET 
      [password] = PWDENCRYPT(@password) --@Encrypt1
      ,[isActive] =iif(@Active='1','1','0')
 WHERE  empCode=@username
 Select 'User Update SuccessFully'
	end



	end
	if(@status='UserCreateMasterGet')
	begin
	SELECT TOP (1000) [empCode]
      ,[password]
      ,[isActive]
  FROM [CapExTS].[dbo].[UserMaster_Temp]
 WHERE PWDCOMPARE(@password,[password]) = 1 and isActive=1 and empCode=@username
	end

	if(@status='UserCreateMasterGetFull')
	begin
	SELECT [empCode]
      ,[password]
      ,[isActive]
  FROM [CapExTS].[dbo].[UserMaster_Temp]

	end
	
	

END




--declare @b2 VARBINARY(50) 
--set @b2 = 0x54006800690073002000690073002000610020007400650073007400
--SELECT CONVERT(nVARCHAR(1000), @b2, 0);