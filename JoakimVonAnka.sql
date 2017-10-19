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
	[Name] [varchar](max) NOT NULL,
	[Street] [varchar](max) NOT NULL,
	[Zip] [varchar](max) NOT NULL,
	[City] [varchar](max) NOT NULL,
	[SSN] [varchar](max) NOT NULL,
	[Telefon] [varchar](max) NULL,
	[Epost] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) primary key NOT NULL,
	[KundID] [int] foreign key references Kunder(KundID) NOT NULL,	
	[PrisOrder] [int] NULL,
	[Status] [varchar](max) NOT NULL
	
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

GO
CREATE TABLE [dbo].[Varukorg](
	[VarukorgID] [int] IDENTITY(1,1) primary key NOT NULL,
	[ArtikelID] [int] foreign key references Artiklar(ArtikelID)NOT NULL,
	[KundID] [int] foreign key references Kunder(KundID) NOT NULL,
	[OrderID] [int] foreign key references [Order](OrderID) NOT NULL,
	[Pris] [int] NOT NULL,
	[Q] [int] NOT NULL,
	[PrisOrder] [int]
) ON [PRIMARY]

GO


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

CREATE PROCEDURE [dbo].[RegisterOrder] 

	@KID int,
	@OID int output
AS
BEGIN
declare @status varchar(max);
set @status = 'Skapad'
declare @prisOrder int;
set @prisOrder = 0;

insert into [Order]([KundID],[Status],[PrisOrder]) values (@KID, @status,@prisOrder)
 set @OID= SCOPE_IDENTITY()
   
	 	 	 		 
END

GO

CREATE PROCEDURE [dbo].[RegisterArtikelVarukorg] 

	@AID int,
	@pris int,
	@q int,
	@KID int,
	@OID int
AS
BEGIN

insert into Varukorg([ArtikelID], [Pris], [Q], [KundID], [OrderID], [PrisOrder]) values(@AID, @pris, @q, @KID, @OID,(@pris*@q));	 
declare @total int
select @total =SUM(PrisOrder) 
FROM Varukorg
where [KundID]=@KID and [OrderID]=@OID

update [Order] set [PrisOrder]=@total
	 		 
END

GO
								--===ARTIKLAR==--
								insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Blyertspenna	'	,	10	,	'	Pennor	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Bläckpenna	'	,	15	,	'	Pennor	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Kulspetspenna	'	,	15	,	'	Pennor	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Markeringspenna	'	,	10	,	'	Pennor	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4	'	,	500	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A3	'	,	700	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 hålat	'	,	500	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 pearl-white	'	,	600	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 off-white	'	,	600	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 pearl-white hålat	'	,	600	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 off-white hålat	'	,	600	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 rutigt	'	,	500	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Papper A5	'	,	250	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Papper A3	'	,	250	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Papper A4	'	,	150	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 återvunnet	'	,	450	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A3 återvunnet	'	,	600	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 hålat återvunnet	'	,	450	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 pearl-white återvunnet	'	,	550	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 off-white återvunnet	'	,	550	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 pearl-white hålat återvunnet	'	,	550	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 off-white hålat återvunnet	'	,	550	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Skrivarpapper A4 rutigt återvunnet	'	,	450	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Papper A5 återvunnet	'	,	200	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Papper A3 återvunnet	'	,	200	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Papper A4 återvunnet	'	,	125	,	'	Papper	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Häftapparat Klassisk	'	,	350	,	'	Häftapparater	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Häftapparat Modern	'	,	500	,	'	Häftapparater	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Häftapparat Automatisk	'	,	750	,	'	Häftapparater	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Häftapparat Häftig	'	,	1337	,	'	Häftapparater	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Häftapparat Stor	'	,	1000	,	'	Häftapparater	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	Häftapparat Liten	'	,	350	,	'	Häftapparater	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	10-Pack Small	'	,	10	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	10-Pack Medium	'	,	10	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	10-Pack Large	'	,	10	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	50-Pack Small	'	,	50	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	50-Pack Medium	'	,	50	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	50-Pack Large	'	,	50	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	100-Pack Small	'	,	100	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	100-Pack Medium	'	,	100	,	'	Gem	'	)
insert into Artiklar ([ArtikelNamn], [Pris], [Kategori]) values(		'	100-Pack Large	'	,	100	,	'	Gem	'	)

SELECT * FROM ARTIKLAR
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



	--==VARUKORG OCH ORDER==--
		
--declare @KID int;
set @KID = 4;

declare @OID int;
execute [RegisterOrder]	4,@OID
select * from [Order]

execute [RegisterArtikelVarukorg] 4, 20,1,4,1
execute [RegisterArtikelVarukorg] 5, 20,1,4,1
execute [RegisterArtikelVarukorg] 3, 20,2,4,1
execute [RegisterArtikelVarukorg] 1, 20,1,4,1
execute [RegisterArtikelVarukorg] 4, 20,3,4,1
select*from [Varukorg]