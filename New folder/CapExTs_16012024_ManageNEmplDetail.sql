USE [CapExTS]
GO
/****** Object:  StoredProcedure [dbo].[ManageNEmpDetail]    Script Date: 16/01/2024 18:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- CREATE PROCEDURE
ALTER PROCEDURE [dbo].[ManageNEmpDetail]
    @Action VARCHAR(10),
    @Name VARCHAR(100),
    @DOB DATE,
    @Gender VARCHAR(10),
    @FatherName VARCHAR(100),
    @MotherName VARCHAR(100),
    @HomeAddress VARCHAR(500),
    @PostCode VARCHAR(100),
    @HomeTel VARCHAR(100),
    @Mobile VARCHAR(100),
    @EName VARCHAR(100),
    @ERelationship VARCHAR(100),
    @EContactAddress VARCHAR(500),
    @EPostCode VARCHAR(100),
    @EHomeTel VARCHAR(100),
    @EWorkMobile VARCHAR(100),
    @PersonalMobile VARCHAR(100),
    @ETName VARCHAR(100),
    @ETRelationship VARCHAR(100),
    @ETHomeTel VARCHAR(100),
    @ETWorkMobile VARCHAR(100),
    @ETPersonalMobile VARCHAR(100),
    @MedicalConditionDrop VARCHAR(10),
    @MedicalCondition VARCHAR(500),
    @BankName VARCHAR(100),
    @AccountNumber VARCHAR(100),
    @IFSCCode VARCHAR(100),
    @BranchAddress VARCHAR(500),
	@ID VARCHAR(500),
	@PersonalID VARCHAR(500)
AS
BEGIN
    IF @Action = 'INSERT'
    BEGIN
        INSERT INTO dbo.NEmp_Detail (
            [Name], [DOB], [Gender], [Father_name], [Mother_Name],
            [Home_address], [Post_code], [Home_tel], [Mobile],
            [EName], [ERelationship], [EContact_address], [EPost_code],
            [EHome_tel], [EWorkMobile], [Personalmobile],
            [ETName], [ETRelationship], [ETHome_tel], [ETWorkMobile],
            [ETPersonalmobile], [Medicalcondition_drop], [Medicalcondition],
            [BankName], [AccountNumber], [IFsc_code], [Branch_address],PersonalID
        )
        VALUES (
            @Name, @DOB, @Gender, @FatherName, @MotherName,
            @HomeAddress, @PostCode, @HomeTel, @Mobile,
            @EName, @ERelationship, @EContactAddress, @EPostCode,
            @EHomeTel, @EWorkMobile, @PersonalMobile,
            @ETName, @ETRelationship, @ETHomeTel, @ETWorkMobile,
            @ETPersonalMobile, @MedicalConditionDrop, @MedicalCondition,
            @BankName, @AccountNumber, @IFSCCode, @BranchAddress,@PersonalID
        );
    END
    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE dbo.NEmp_Detail
        SET
            [Name] = @Name,
            [DOB] = @DOB,
            [Gender] = @Gender,
            [Father_name] = @FatherName,
            [Mother_Name] = @MotherName,
            [Home_address] = @HomeAddress,
            [Post_code] = @PostCode,
            [Home_tel] = @HomeTel,
            [Mobile] = @Mobile,
            [EName] = @EName,
            [ERelationship] = @ERelationship,
            [EContact_address] = @EContactAddress,
            [EPost_code] = @EPostCode,
            [EHome_tel] = @EHomeTel,
            [EWorkMobile] = @EWorkMobile,
            [Personalmobile] = @PersonalMobile,
            [ETName] = @ETName,
            [ETRelationship] = @ETRelationship,
            [ETHome_tel] = @ETHomeTel,
            [ETWorkMobile] = @ETWorkMobile,
            [ETPersonalmobile] = @ETPersonalMobile,
            [Medicalcondition_drop] = @MedicalConditionDrop,
            [Medicalcondition] = @MedicalCondition,
            [BankName] = @BankName,
            [AccountNumber] = @AccountNumber,
            [IFsc_code] = @IFSCCode,
            [Branch_address] = @BranchAddress,
				PersonalID=	@PersonalID
        WHERE [ID] = @ID; -- Assuming there is an ID column as the primary key
    END
    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM dbo.NEmp_Detail WHERE [ID] = @ID; -- Assuming there is an ID column as the primary key
    END
    ELSE IF @Action = 'SELECT'
    BEGIN
        SELECT * FROM dbo.NEmp_Detail  WHERE [ID] =  @ID -- Assuming there is an ID column as the primary key
    END

	 ELSE IF @Action = 'SELECTFull'
    BEGIN
        SELECT 	[Name]
      ,[DOB]
      ,[Gender]
      ,[Father_name]
      ,[Mother_Name]
      ,[Home_address]
      ,[Post_code]
      ,[Home_tel]
      ,[Mobile]
      ,[EName]
      ,[ERelationship]
      ,[EContact_address]
      ,[EPost_code]
      ,[EHome_tel]
      ,[EWorkMobile]
      ,[Personalmobile]
      ,[ETName]
      ,[ETRelationship]
      ,[ETHome_tel]
      ,[ETWorkMobile]
      ,[ETPersonalmobile]
      ,[Medicalcondition_drop]
      ,[Medicalcondition]
      ,[BankName]
      ,[AccountNumber]
      ,[IFsc_code]
      ,[Branch_address]
      ,[ID]
      ,[PersonalID] FROM dbo.NEmp_Detail -- Assuming there is an ID column as the primary key
    END
END;
