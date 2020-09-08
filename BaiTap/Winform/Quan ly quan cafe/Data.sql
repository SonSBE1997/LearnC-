CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO
-- Tạo bảng
-- Food
-- Table
-- FoodCategory
-- Account 
-- Bill
-- BillInfo

CREATE TABLE TableFood
    (
      id INT IDENTITY
             PRIMARY KEY ,
      name NVARCHAR(100) NOT NULL
                         DEFAULT N'Chưa đặt tên' ,
      status NVARCHAR(100) NOT NULL
                           DEFAULT N'Trống' --Trống || có người
    )
GO

CREATE TABLE Account
    (
      UserName NVARCHAR(100) PRIMARY KEY ,
      DisplayName NVARCHAR(100) NOT NULL
                                DEFAULT N'SBE' ,
      PassWord NVARCHAR(1000) NOT NULL
                              DEFAULT 0 ,
      Type INT NOT NULL
               DEFAULT 0 -- 1 : Admin && 0 : Staff
    )
GO

CREATE TABLE FoodCategory
    (
      id INT IDENTITY
             PRIMARY KEY ,
      name NVARCHAR(100) NOT NULL
                         DEFAULT N'Chưa đặt tên',
    )
GO

CREATE TABLE Food
    (
      id INT IDENTITY
             PRIMARY KEY ,
      name NVARCHAR(100) NOT NULL
                         DEFAULT N'Chưa đặt tên' ,
      idCategory INT NOT NULL ,
      price FLOAT NOT NULL
                  DEFAULT 0 ,
      FOREIGN KEY ( idCategory ) REFERENCES dbo.FoodCategory ( id )
    )
GO

CREATE TABLE Bill
    (
      id INT IDENTITY
             PRIMARY KEY ,
      DateCheckIn DATE NOT NULL
                       DEFAULT GETDATE() ,
      DateCheckOut DATE ,
      idTable INT NOT NULL ,
      status INT NOT NULL
                 DEFAULT 0 ,	-- 1: đã thanh toán 0: chưa thanh toán
      FOREIGN KEY ( idTable ) REFERENCES dbo.TableFood ( id )
    )
GO

CREATE TABLE BillInfo
    (
      id INT IDENTITY
             PRIMARY KEY ,
      idBill INT NOT NULL ,
      idFood INT NOT NULL ,
      count INT NOT NULL
                DEFAULT 0 ,
      FOREIGN KEY ( idBill ) REFERENCES dbo.Bill ( id ) ,
      FOREIGN KEY ( idFood ) REFERENCES dbo.Food ( id )
    )
GO

-- Thêm tài khoản
INSERT  INTO Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'SBE' , -- UserName - 
          N'Kingdom' , -- DisplayName - 
          N'123' , -- PassWord - 
          1	 -- Type - 
		)

INSERT  INTO Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'staff' , -- UserName - 
          N'staff' , -- DisplayName - 
          N'123' , -- PassWord - 
          0	 -- Type - 
		)
GO

-- store procedure: lấy tài khoản theo tên đăng nhập
CREATE PROC USP_GetAccountByUserName
    @userName NVARCHAR(100)
AS
    BEGIN
        SELECT  *
        FROM    Account
        WHERE   @userName = UserName
    END
GO

EXEC USP_GetAccountByUserName @userName = N'SBE'
GO
-- store procedure: đăng nhập
CREATE PROC USP_Login
    @userName NVARCHAR(100) ,
    @password NVARCHAR(100)
AS
    BEGIN
        SELECT  *
        FROM    dbo.Account
        WHERE   UserName = @userName
                AND PassWord = @password
    END
GO

-- Thêm bàn ăn
DECLARE @i INT = 1 
WHILE @i <= 20
    BEGIN
        INSERT  dbo.TableFood
                ( name )
        VALUES  ( N'Bàn ' + CAST(@i AS NVARCHAR(100)) )
        SET @i = @i + 1
    END
GO
 
-- store procedure: lấy danh sách bàn ăn
CREATE PROC USP_GetTableList
AS
    SELECT  *
    FROM    dbo.TableFood
 GO
 
EXEC dbo.USP_GetTableList
 GO 

-- Thay đổi thông tin của bàn ăn
UPDATE  dbo.TableFood
SET     status = N'Có người'
WHERE   id = 9
GO

-- Thêm Loại thức ăn
INSERT  INTO dbo.FoodCategory
        ( name )
VALUES  ( N'Hải sản'  -- name - nvarchar(100)
          )

INSERT  INTO dbo.FoodCategory
        ( name )
VALUES  ( N'Nông sản'  -- name - nvarchar(100)
          )

INSERT  INTO dbo.FoodCategory
        ( name )
VALUES  ( N'Nước uống'  -- name - nvarchar(100)
          )

INSERT  INTO dbo.FoodCategory
        ( name )
VALUES  ( N'Lâm sản'  -- name - nvarchar(100)
          )

INSERT  INTO dbo.FoodCategory
        ( name )
VALUES  ( N'Sản sản'  -- name - nvarchar(100)
          )
-- Thêm món ăn

INSERT  INTO dbo.Food
        ( name ,
          idCategory ,
          price
        )
VALUES  ( N'Mực một nắng nướng sa tế' , -- name - nvarchar(100)
          1 , -- idCategory - int
          120000.0  -- price - float
        )

INSERT  INTO dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Nghêu hấp sả', 1, 50000.0 )

INSERT  INTO dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Dú dê nướng sữa', 2, 60000.0 )	

INSERT  INTO dbo.Food
        ( name ,
          idCategory ,
          price
        )
VALUES  ( N'Heo rừng nướng muối ớt' ,
          4 ,
          75000.0
        )

INSERT  INTO dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cơm chiên mushi', 5, 40000.0 )

INSERT  INTO dbo.Food
        ( name, idCategory, price )
VALUES  ( N'7UP', 3, 12000.0 )

INSERT  INTO dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cafe', 3, 15000.0 )

INSERT  INTO dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Rượu volka cá sấu', 3, 30000.0 )

--Thêm hóa đơn
INSERT  INTO dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() ,
          NULL ,
          1 ,
          0 
        )

INSERT  INTO dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() ,
          NULL ,
          2 ,
          0 
        )

INSERT  INTO dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() ,
          GETDATE() ,
          2 ,
          1 
        )

-- Thêm chi tiết hóa đơn
INSERT  INTO dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )

INSERT  INTO dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          3, -- idFood - int
          4  -- count - int
          )

INSERT  INTO dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          5, -- idFood - int
          1  -- count - int
          )

INSERT  INTO dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT  INTO dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          3, -- idFood - int
          2  -- count - int
          )
INSERT  INTO dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 3, -- idBill - int
          3, -- idFood - int
          3  -- count - int
          )
GO

-- Hiển thị tổng tiền 
SELECT  f.name ,
        bi.count ,
        f.price ,
        f.price * bi.count AS totalPrice
FROM    dbo.BillInfo AS bi ,
        dbo.Bill AS b ,
        dbo.Food AS f
WHERE   bi.idBill = b.id
        AND bi.idFood = f.id
        AND b.idTable = 1
        AND b.status = 0
GO

-- store procedure: lấy danh sách thức ăn
CREATE PROC USP_GetListFoodByCategoryID @CategoryID INT
AS
    BEGIN
        SELECT  *
        FROM    Food
        WHERE   idCategory = @CategoryID
    END
GO
-- store procedure: thêm hóa đơn

CREATE PROC USP_InsertBill @tableID INT
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
                  0 ,-- status - int
                  0
	            ) 
    END
GO

-- store procedure: thêm chi tiết hóa đơn

CREATE PROC USP_InsertBillInfo
    @billID INT ,
    @foodID INT ,
    @count INT
AS
    BEGIN

        DECLARE @isExitsBillInfo INT
        DECLARE @foodCount INT = 1;

        SELECT  @isExitsBillInfo = id ,
                @foodCount = count
        FROM    dbo.BillInfo
        WHERE   idBill = @billID
                AND idFood = @foodID

        IF ( @isExitsBillInfo > 0 )
            BEGIN
                DECLARE @newCount INT = @foodCount + @count
                IF ( @newCount > 0 )
                    UPDATE  dbo.BillInfo
                    SET     count = @newCount
                    WHERE   idFood = @foodID
                ELSE
                    DELETE  dbo.BillInfo
                    WHERE   idBill = @billID
                            AND idFood = @foodID

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

-- trigger : cập nhật BillInfo
CREATE TRIGGER UTG_UpdateBillInfo ON dbo.BillInfo
    FOR INSERT, UPDATE
AS
    BEGIN 
        DECLARE @idBill INT
        SELECT  @idBill = Inserted.idBill
        FROM    Inserted

        DECLARE @idTable INT
        SELECT  @idTable = idTable
        FROM    dbo.Bill
        WHERE   id = @idBill
                AND status = 0   
        DECLARE @count INT = 0
        SELECT  @count = COUNT(*)
        FROM    BillInfo
        WHERE   idBill = @idBill

        IF ( @count > 0 )
            BEGIN
                UPDATE  dbo.TableFood
                SET     status = N'Có người'
                WHERE   id = @idTable 
            END
        ELSE
            BEGIN
                UPDATE  dbo.TableFood
                SET     status = N'Trống'
                WHERE   id = @idTable 
            END
    END
GO


-- trigger : cập nhật Bill
CREATE TRIGGER UTG_UpdateBill ON dbo.Bill
    FOR UPDATE
AS
    BEGIN 
        DECLARE @idBill INT
        SELECT  @idBill = id
        FROM    Inserted

        DECLARE @idTable INT
        SELECT  @idTable = idTable
        FROM    dbo.Bill
        WHERE   id = @idBill

        DECLARE @count INT = 0
        SELECT  @count = COUNT(*)
        FROM    dbo.Bill
        WHERE   idTable = @idTable
                AND status = 0    
        IF ( @count = 0 )
            UPDATE  dbo.TableFood
            SET     status = N'Trống'
            WHERE   id = @idTable
    END
GO
--
SELECT  MAX(id)
FROM    dbo.Bill

--
CREATE TABLE dbo.Bill
--ADD discount INT DEFAULT 0
--GO

--store procedure: đổi bàn
CREATE PROC USP_SwitchTable
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
        SELECT  @isFirstTableEmpty = COUNT(*)
        FROM    BillInfo
        WHERE   idBill = @firstBill

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
			
        SELECT  @isSecondTableEmpty = COUNT(*)
        FROM    BillInfo
        WHERE   idBill = @secondBill
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
        IF ( @isSecondTableEmpty = 0 )
            UPDATE  dbo.TableFood
            SET     status = N'Trống'
            WHERE   id = @idTable1
    END 
GO

--	store procedure : lấy danh sách hóa đơn
CREATE PROC USP_GetListBillByDateAndPage
    @CheckIn DATE ,
    @CheckOut DATE ,
    @page INT ,
    @pageRows INT
AS
    BEGIN 
        DECLARE @SelectRows INT = @pageRows
        DECLARE @exceptRows INT = ( @page - 1 ) * @pageRows;
            WITH    tableViewBill
                      AS ( SELECT   b.id AS [Mã hóa đơn] ,
                                    t.name AS [tên bàn] ,
                                    b.DateCheckIn AS [ngày vào] ,
                                    b.DateCheckOut AS [ngày ra] ,
                                    b.discount AS [giảm giá (%)] ,
                                    totalPrice AS [tổng tiền]
                           FROM     dbo.Bill AS b ,
                                    TableFood AS t
                           WHERE    t.id = b.idTable
                                    AND b.status = 1
                                    AND b.DateCheckIn >= @CheckIn
                                    AND b.DateCheckOut <= @CheckOut
                         )
            SELECT TOP ( @SelectRows )
                    *
            FROM    tableViewBill
            WHERE   tableViewBill.[Mã hóa đơn] NOT IN (
                    SELECT TOP ( @exceptRows )
                            tableViewBill.[Mã hóa đơn]
                    FROM    tableViewBill )

    END
GO

-- store procedure : lấy hóa đơn
CREATE PROC  USP_GetBillByDate
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
    



--	store procedure : cập nhật tài khoản
CREATE PROC USP_UpdateAccount
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
--- trigger : xóa BillInfo
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR	DELETE
AS
BEGIN 
	DECLARE @idBill INT 	
	SELECT  @idBill = Deleted.idBill FROM Deleted

	DECLARE @idTable INT
	SELECT @idTable = Bill.idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi , dbo.Bill AS b WHERE bi.idBill = b.id AND b.id= @idBill AND b.status =0

	IF(@count =0) 
		UPDATE dbo.TableFood SET status = N'Trống'	WHERE id = @idTable
END
GO

-- store produce : xóa danh mục
CREATE PROC USP_DeleteCategory
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

-- store procedure: xóa bàn ăn
CREATE PROC USP_DeleteTable
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

-- function : chuyển chuỗi unicode sang chuỗi không dấu
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


SELECT  *
FROM    Account
SELECT  *
FROM    Bill
SELECT  *
FROM    BillInfo
SELECT  *
FROM    Account
SELECT  * 
FROM    Food
SELECT  *
FROM    FoodCategory
SELECT  *
FROM    dbo.TableFood 
 