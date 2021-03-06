USE [master]
GO
/****** Object:  Database [QuanLyQuanCafe]    Script Date: 6/17/2017 8:15:27 PM ******/
CREATE DATABASE [QuanLyQuanCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QuanLyQuanCafe.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyQuanCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QuanLyQuanCafe_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyQuanCafe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLyQuanCafe]
GO
/****** Object:  UserDefinedFunction [dbo].[fucConvertUnicodeToUnsign]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fucConvertUnicodeToUnsign](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END

GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL DEFAULT (N'SBE'),
	[PassWord] [nvarchar](1000) NOT NULL DEFAULT ((0)),
	[Type] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL DEFAULT (getdate()),
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL DEFAULT ((0)),
	[discount] [int] NULL DEFAULT ((0)),
	[totalPrice] [float] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Food]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa đặt tên'),
	[status] [nvarchar](100) NOT NULL DEFAULT (N'Trống'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'SBE', N'King', N'3244185981728979115075721453575112', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'SBE1', N'Jack', N'3244185981728979115075721453575112', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'ss', N'abcd', N'20720532132149213101239102231223249249135100218', 0)
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1084, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 1, 1, 0, 302000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1085, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 7, 1, 0, 112000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1086, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 10, 1, 0, 120000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1087, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 2, 1, 0, 360000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1088, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 6, 1, 0, 600000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1089, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 11, 1, 0, 480000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1090, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 2, 1, 0, 480000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1091, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 7, 1, 0, 480000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1092, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 11, 1, 0, 480000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1093, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 11, 1, 0, 480000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1094, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 11, 1, 0, 120000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1095, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 8, 1, 0, 45000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1096, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 5, 1, 0, 30000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1097, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 18, 1, 0, 30000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1098, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 19, 1, 0, 30000)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (1099, CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 20, 1, 0, 30000)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1107, 1084, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1108, 1084, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1109, 1084, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1110, 1085, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1111, 1085, 3, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1112, 1085, 5, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1113, 1086, 5, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1114, 1087, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1115, 1088, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1116, 1089, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1117, 1090, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1118, 1091, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1119, 1092, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1120, 1093, 1, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1121, 1094, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1122, 1095, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1123, 1096, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1124, 1097, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1125, 1098, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (1126, 1099, 7, 2)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (1, N'Mực một nắng nướng sa tế', 1, 120000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (2, N'Nghêu hấp sả', 1, 50000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (3, N'Dú dê nướng sữa', 2, 60000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (4, N'Heo rừng nướng muối ớt', 4, 75000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (5, N'Cơm chiên mushi', 5, 40000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (6, N'7UP', 3, 12000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (7, N'Cafe', 3, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (8, N'Rượu volka cá sấu', 3, 30000)
SET IDENTITY_INSERT [dbo].[Food] OFF
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'Hải sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'Nông sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'Nước uống')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'Lâm sản')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'Sản sản')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn 0', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn 1', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Bàn 2', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Bàn 3', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Bàn 4', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Bàn 5', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Bàn 6', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (8, N'Bàn 7', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn 8', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn 9', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (11, N'Bàn 10', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (12, N'Bàn 11', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (13, N'Bàn 12', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (14, N'Bàn 13', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (15, N'Bàn 14', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (16, N'Bàn 15', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (17, N'Bàn 16', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (18, N'Bàn 17', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (19, N'Bàn 18', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (20, N'Bàn 19', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (21, N'Bàn 20', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteCategory]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DeleteCategory]
@idCategory INT
AS
BEGIN
	SELECT id INTO IDFoodTable FROM dbo.Food WHERE idCategory = @idCategory
	DELETE dbo.BillInfo WHERE idFood IN (SELECT * FROM IDFoodTable)
	DELETE dbo.Food WHERE id IN (SELECT * FROM IDFoodTable)
	DELETE FoodCategory WHERE id = @idCategory
	DROP TABLE IDFoodTable
END

GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteTable]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DeleteTable]
@idTable INT
AS
BEGIN
	SELECT id INTO IDBillTable FROM Bill WHERE idTable = @idTable
	DELETE dbo.BillInfo WHERE idBill IN (SELECT * FROM IDBillTable)
	DELETE dbo.Bill WHERE id IN (SELECT *  FROM IDBillTable)
	DELETE dbo.TableFood WHERE id = @idTable
	DROP TABLE IDBillTable
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE @userName = UserName
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetBillByDate]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[USP_GetBillByDate]
	@CheckIn DATE ,
    @CheckOut DATE 
	AS
     BEGIN 
		

      SELECT  t.name AS [tên bàn],
                b.DateCheckIn as [ngày vào],
                b.DateCheckOut AS [ngày ra],
                b.discount as [giảm giá (%)],
                totalPrice AS [tổng tiền]	
        FROM    dbo.Bill AS b ,
                TableFood AS t
        WHERE   t.id = b.idTable
                AND b.status = 1
                AND b.DateCheckIn >= @CheckIn
                AND b.DateCheckOut <= @CheckOut

    END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
    @CheckIn DATE ,
    @CheckOut DATE, 
	@page INT,
	@pageRows INT 
AS
    BEGIN 
		DECLARE @SelectRows INT =  @pageRows
		DECLARE @exceptRows INT = (@page - 1) * @pageRows

       ;WITH 	tableViewBill AS ( SELECT b.id AS [Mã hóa đơn], t.name AS [tên bàn],
                b.DateCheckIn as [ngày vào],
                b.DateCheckOut AS [ngày ra],
                b.discount as [giảm giá (%)],
                totalPrice AS [tổng tiền]	
        FROM    dbo.Bill AS b ,
                TableFood AS t
        WHERE   t.id = b.idTable
                AND b.status = 1
                AND b.DateCheckIn >= @CheckIn
                AND b.DateCheckOut <= @CheckOut)
		
		SELECT TOP (@SelectRows) * FROM tableViewBill  WHERE tableViewBill.[Mã hóa đơn] NOT IN (SELECT TOP (@exceptRows) tableViewBill.[Mã hóa đơn] FROM			tableViewBill)

    END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListFoodByCategoryID]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListFoodByCategoryID]
@CategoryID INT
AS 
BEGIN
	SELECT * FROM Food WHERE idCategory = @CategoryID
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
 AS SELECT * FROM dbo.TableFood

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill] @tableID INT
AS
    BEGIN
        INSERT  INTO dbo.Bill
                ( DateCheckIn ,
                  DateCheckOut ,
                  idTable ,
                  status ,
				  discount
	            )
        VALUES  ( GETDATE() , -- DateCheckIn - date
                  NULL , -- DateCheckOut - date
                  @tableID , -- idTable - int
                  0  ,-- status - int
				  0
	            ) 
    END

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
    @billID INT ,
    @foodID INT ,
    @count INT
AS
    BEGIN

		DECLARE @isExitsBillInfo INT
		DECLARE @foodCount INT = 1;

		SELECT @isExitsBillInfo = id, @foodCount = count FROM dbo.BillInfo WHERE idBill = @billID AND idFood = @foodID

		IF(@isExitsBillInfo>0)
		BEGIN
			DECLARE @newCount INT = @foodCount + @count
			IF(@newCount >0) UPDATE dbo.BillInfo SET count = @newCount WHERE idFood = @foodID
			ELSE DELETE dbo.BillInfo WHERE idBill = @billID AND idFood = @foodID

		END
		ELSE
		BEGIN        
        INSERT  INTO dbo.BillInfo
                ( idBill, idFood, count )
        VALUES  ( @billID, -- idBill - int
                  @foodID,-- idFood - int
                  @count  -- count - int
                  )
		END
	END

GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName NVARCHAR(100) ,@password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
END

GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTable]
    @idTable1 INT ,
    @idTable2 INT
AS
    BEGIN 
        DECLARE @firstBill INT 
        DECLARE @secondBill INT
        DECLARE @isFirstTableEmpty INT = 1
        DECLARE @isSecondTableEmpty INT = 1

        SELECT  @firstBill = id
        FROM    dbo.Bill
        WHERE   idTable = @idTable1
                AND status = 0
        SELECT  @secondBill = id
        FROM    dbo.Bill
        WHERE   idTable = @idTable2
                AND status = 0

        IF ( @firstBill IS NULL )
            BEGIN
                INSERT  dbo.Bill
                        ( DateCheckIn ,
                          DateCheckOut ,
                          idTable ,
                          status ,
                          discount
		                )
                VALUES  ( GETDATE() , -- DateCheckIn - date
                          NULL , -- DateCheckOut - date
                          @idTable1 , -- idTable - int
                          0 , -- status - int
                          0
		                )

                SELECT  @firstBill = MAX(id)
                FROM    dbo.Bill
                WHERE   idTable = @idTable1
                        AND status = 0
            END
		SELECT @isFirstTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @firstBill

        IF ( @secondBill IS NULL )
            BEGIN
                INSERT  dbo.Bill
                        ( DateCheckIn ,
                          DateCheckOut ,
                          idTable ,
                          status ,
                          discount
		                )
                VALUES  ( GETDATE() , -- DateCheckIn - date
                          NULL , -- DateCheckOut - date
                          @idTable2 , -- idTable - int
                          0 , -- status - int
                          0
		                )

                SELECT  @secondBill = MAX(id)
                FROM    dbo.Bill
                WHERE   idTable = @idTable2
                        AND status = 0
                
            END 
			
		SELECT @isSecondTableEmpty = COUNT(*) FROM BillInfo WHERE idBill = @secondBill
        SELECT  id
        INTO    IDBillInfoTable
        FROM    dbo.BillInfo
        WHERE   idBill = @secondBill

        UPDATE  BillInfo
        SET     idBill = @secondBill
        WHERE   idBill = @firstBill

        UPDATE  BillInfo
        SET     idBill = @firstBill
        WHERE   id IN ( SELECT  *
                            FROM    IDBillInfoTable )
	
        DROP TABLE IDBillInfoTable

		
        IF ( @isFirstTableEmpty = 0 )
            UPDATE  dbo.TableFood
            SET     status = N'Trống'
            WHERE   id = @idTable2
        IF ( @isSecondTableEmpty = 0)
            UPDATE  dbo.TableFood
            SET     status = N'Trống'
            WHERE   id = @idTable1
    END 

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 6/17/2017 8:15:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newpassword NVARCHAR(100)
AS		 
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE @userName = UserName AND @password = PassWord	
	IF(@isRightPass >= 1)
	BEGIN
		IF(@newpassword IS NULL OR @newpassword = N'2122914021714301784233128915223624866126')
		BEGIN 
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName 
		END 
		ELSE 
		UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newpassword WHERE UserName = @userName 
    END 
END

GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafe] SET  READ_WRITE 
GO
