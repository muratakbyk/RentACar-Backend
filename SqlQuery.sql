Create Table Cars
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

