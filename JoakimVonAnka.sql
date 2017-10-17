use master
go
drop database JoakimVonAnka
go
create database JoakimVonAnka
GO
USE JoakimVonAnka
GO

		--====TABLES====--
CREATE TABLE [dbo].[Artiklar](
	[ArtikelID] [int] IDENTITY(1,1) primary key NOT NULL,
	[ArtikelNamn] [varchar](max) NOT NULL,
	[Pris] [int] NOT NULL,
	[Kategori] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
CREATE TABLE [dbo].[Kunder](
	[KundID] [int] IDENTITY(1,1) primary key NOT NULL,
	[NickName] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Name] [varchar](max) NULL,
	[Street] [varchar](max) NULL,
	[Zip] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[SSN] [varchar](max) NULL,
	[Telefon] [varchar](max) NULL,
	[Epost] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
CREATE TABLE [dbo].[Varukorg](
	[VarukorgID] [int] IDENTITY(1,1) primary key NOT NULL,
	[ArtikelID] [int] foreign key references Artiklar(ArtikelID)NOT NULL,
	[Pris] [int] NOT NULL,
	[Q] [int] NOT NULL,
	[Total] [int] NOT NULL
) ON [PRIMARY]

GO
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) primary key NOT NULL,
	[KundID] [int] foreign key references Kunder(KundID) NOT NULL,
	[VarukorgID] [int] foreign key references Varukorg(VarukorgID) NOT NULL,
	[Status] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		--====PROCEDURE====--
			--===USER==--
GO
CREATE PROCEDURE [dbo].[RegisterUser] 

	@nick varchar(max),
	@pass varchar(max),
	@name varchar(max),
	@street varchar(max),
	@zip varchar(max),
	@city varchar(max),
	@ssn varchar(max),
	@tel varchar(max),
	@epost varchar(max)
	
AS
BEGIN

 insert into Kunder ([NickName], [Password], [Name], [Street], [Zip], [City], [SSN], [Telefon], [Epost]) values(@nick, @pass, @name, @street, @zip, @city, @ssn, @tel, @epost);
	 	 		 
END

GO
CREATE PROCEDURE [dbo].[DeleteUser] 

	@KID int
	
AS
BEGIN

Delete from Kunder where KundID=@KID;
 	 		 
END

GO
CREATE PROCEDURE [dbo].[UpdateUser] 

	@nick varchar(max),
	@pass varchar(max),
	@name varchar(max),
	@street varchar(max),
	@zip varchar(max),
	@city varchar(max),
	@ssn varchar(max),
	@tel varchar(max),
	@epost varchar(max),
	@KID int
	
AS
BEGIN

 update Kunder set [NickName]= @nick, [Password]= @pass, [Name]=@name, [Street]=@street, [Zip]=@zip, [City]=@city, [SSN]=@ssn, [Telefon]=@tel, [Epost]=@epost where [KundID]=@KID;
	 	 		 
END

		--===ARTIKLAR===--
GO
CREATE PROCEDURE [dbo].[RegisterArtikel] 

	@artikelNamn varchar(max),
	@pris int,
	@kategori varchar(max)
	
AS
BEGIN

 insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(@artikelNamn, @pris, @kategori);
	 	 		 
END

GO
CREATE PROCEDURE [dbo].[DeleteArtikel] 

	@AID int
	
AS
BEGIN

Delete from Artiklar where ArtikelID=@AID;
 	 		 
END

GO

CREATE PROCEDURE [dbo].[UpdateArtikel] 

	@artikelNamn varchar(max),
	@pris int,
	@kategori varchar(max),
	@AID int
	
AS
BEGIN

 update Artiklar set [ArtikelNamn]= @artikelNamn, [Pris]= @pris, [Kategori]=@kategori where [ArtikelID]=@AID;
	 	 		 
END

GO
			--===VARUKORG===--

CREATE PROCEDURE [dbo].[RegisterVarukorg] 

	@artikelNamn varchar(max),
	@pris int,
	@kategori varchar(max)
	
AS
BEGIN

 insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(@artikelNamn, @pris, @kategori);
	 	 		 
END

GO



											--===TEST AREA===--
	--====KUNDER====--
	 --==REGISTER==--

declare @nick varchar(max), @pass varchar(max), @name varchar(max), @street varchar(max), @zip varchar(max), @city varchar(max), @ssn varchar(max), @tel varchar(max), @epost varchar(max)

execute [RegisterUser]  'Admin',	'AdminPassword',	'Admin  Adminsson', 'Work',  '1337', 'AdMin',	'1337', '070 1337', 'ad@min'
	 	 		 
execute [RegisterUser]  'Nick1',	'Password1',	'Name1  Namesson1', 'Street1',  'Zip1', 'City1',	'SSN1', 'Tel1', 'Epost1'
execute	[RegisterUser]	'Nick2',	'Password2',	'Name2	Namesson2',	'Street2',	'Zip2',	'City2',	'SSN2',	'Tel2',	'Epost2'																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																				
execute	[RegisterUser]	'Nick3',	'Password3',	'Name3	Namesson3',	'Street3',	'Zip3',	'City3',	'SSN3',	'Tel3',	'Epost3'																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																				
execute	[RegisterUser]	'Nick4',	'Password4',	'Name4	Namesson4',	'Street4',	'Zip4',	'City4',	'SSN4',	'Tel4',	'Epost4'																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																				
execute	[RegisterUser]	'Nick5',	'Password5',	'Name5	Namesson5',	'Street5',	'Zip5',	'City5',	'SSN5',	'Tel5',	'Epost5'																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																				
execute	[RegisterUser]	'Nick6',	'Password6',	'Name6	Namesson6',	'Street6',	'Zip6',	'City6',	'SSN6',	'Tel6',	'Epost6'																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																				
execute	[RegisterUser]	'Nick7',	'Password7',	'Name7	Namesson7',	'Street7',	'Zip7',	'City7',	'SSN7',	'Tel7',	'Epost7'																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																				
select * from Kunder
		--==DELETE==--
declare @KID int
set @KID=2
execute DeleteUser @KID
select * from Kunder
		--==UPDATE==--
execute	UpdateUser 'Nick7',	'Password7','Name7	Namesson7',	'Street7','Zip7','City7','SSN7','Tel7',	'Epost7',3
select * from Kunder																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																		
		--====ARTIKLAR====--
		  --==REGISTER==--
execute	[RegisterArtikel]	'TestArtikel1',20,	'Testkategori1'			
execute	[RegisterArtikel]	'TestArtikel2',30,	'Testkategori2'			
execute	[RegisterArtikel]	'TestArtikel3',40,	'Testkategori3'			
execute	[RegisterArtikel]	'TestArtikel4',50,	'Testkategori1'			
execute	[RegisterArtikel]	'TestArtikel5',60,	'Testkategori2'			
execute	[RegisterArtikel]	'TestArtikel6',70,	'Testkategori3'			
execute	[RegisterArtikel]	'TestArtikel7',80,	'Testkategori1'			
select * from Artiklar	
		  --==DELETE==--
declare @AID int
set @AID=2
execute DeleteArtikel @AID
select * from Artiklar																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																	
		 --==UPDATE==--
execute	UpdateArtikel 'UppdateradTestArtikel3',	'1337','UppdateradTestkategori3',3
select * from Artiklar																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																										
