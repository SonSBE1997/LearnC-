CREATE DATABASE TestEntityFramework
GO

USE TestEntityFramework
GO

CREATE TABLE Class
    (
      ID INT IDENTITY
             PRIMARY KEY ,
      Name NVARCHAR(100) DEFAULT N'IT 1'
    )

CREATE TABLE Student
    (
      ID INT IDENTITY
             PRIMARY KEY ,
      Name NVARCHAR(100) DEFAULT N'SBE' ,
      IDClass INT NOT NULL ,
      CONSTRAINT fk_class_ID FOREIGN KEY ( IDClass ) REFERENCES dbo.Class ( ID )
    )
GO


-- Insert data
INSERT  INTO dbo.Class
        ( Name )
VALUES  ( N'IT1'  -- Name - nvarchar(100)
          )

INSERT  INTO dbo.Class
        ( Name )
VALUES  ( N'IT2'  -- Name - nvarchar(100)
          )

INSERT  INTO dbo.Class
        ( Name )
VALUES  ( N'IT3'  -- Name - nvarchar(100)
          )

INSERT  INTO dbo.Class
        ( Name )
VALUES  ( N'IT4'  -- Name - nvarchar(100)
          )

INSERT  INTO dbo.Class
        ( Name )
VALUES  ( N'IT5'  -- Name - nvarchar(100)
          )

-- Insert Student

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'A', -- Name - nvarchar(100)
          4  -- IDClass - int
          )
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'B', -- Name - nvarchar(100)
          4  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'C', -- Name - nvarchar(100)
          4  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'D', -- Name - nvarchar(100)
          4 -- IDClass - int
          )

--  Class 2
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'A', -- Name - nvarchar(100)
          1  -- IDClass - int
          )
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'B', -- Name - nvarchar(100)
          1  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'C', -- Name - nvarchar(100)
          1 -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'D', -- Name - nvarchar(100)
          1  -- IDClass - int
          )
-- Class 3

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'A', -- Name - nvarchar(100)
          2 -- IDClass - int
          )
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'B', -- Name - nvarchar(100)
          2  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'C', -- Name - nvarchar(100)
          2  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'D', -- Name - nvarchar(100)
          2  -- IDClass - int
          )

-- Class 4
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'A', -- Name - nvarchar(100)
          3  -- IDClass - int
          )
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'B', -- Name - nvarchar(100)
          3  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'C', -- Name - nvarchar(100)
          3  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'D', -- Name - nvarchar(100)
          3 -- IDClass - int
          )

-- 
-- Class 4
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'A', -- Name - nvarchar(100)
         5  -- IDClass - int
          )
INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'B', -- Name - nvarchar(100)
          5  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'C', -- Name - nvarchar(100)
          5  -- IDClass - int
          )

INSERT  INTO dbo.Student
        ( Name, IDClass )
VALUES  ( N'D', -- Name - nvarchar(100)
          5 -- IDClass - int
          )


-------------------------------------------------------


