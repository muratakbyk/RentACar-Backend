/*Create Table Cars
(
	Id int Primary Key identity (1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	CarName nvarchar,  
)

Create Table Brands
(
	Id int Primary Key Identity (1,1),
	BrandName nvarchar, 
)

Create Table Colors
(
	Id int Primary Key Identity (1,1),
	ColorName nvarchar,
)
Create Table Customers
(
	CustomerId int Primary Key Identity (1,1),
	UserId int,
	CompanyName nvarchar,
	
)
CREATE TABLE CarImages
(
	ImageId int Primary Key identity (1,1),
    CarId int,
    ImagePath nvarchar,
    Datee datetime
)

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
CREATE TABLE [dbo].[Users] (
    [UserId]       INT             NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [EMail]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
)
*/





