USE master
GO
IF EXISTS(SELECT * FROM SYSDATABASES WHERE NAME='MySchool')
	DROP DATABASE MySchool
GO
CREATE DATABASE MySchool
ON
(
	NAME='MySchool_data',
	FILENAME='D:\SQL\MSSQL11.MSSQLSERVER\MSSQL\DATA\MySchool\MySchool.mdf',
	SIZE=5MB,
	MAXSIZE=100MB,
	FILEGROWTH=10%
)
LOG ON
(
	NAME='MySchool_Log',
	FILENAME='D:\SQL\MSSQL11.MSSQLSERVER\MSSQL\DATA\MySchool\MySchool.ldf',
	SIZE=5MB,
	FILEGROWTH=10%
)





USE MySchool
GO
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME='Grade')
	DROP TABLE Grade
GO
CREATE TABLE Grade
(
	GradeId int NOT NULL CONSTRAINT PK_GradeId PRIMARY KEY(GRADEID),
	GradeName NVARCHAR(30) NOT NULL
)
INSERT INTO Grade(GradeId,GradeName)
values(1,'S1')
INSERT INTO Grade(GradeId,GradeName)
values(2,'S2')
INSERT INTO Grade(GradeId,GradeName)
values(3,'S3')

IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME='Result')
	DROP TABLE Result
GO
CREATE TABLE Result
(
	StudentNo int NOT NULL,
	SubjectNo int not null,
	ExamDate datetime NOT NULL,
	StudentResult int NOT NULL
)
INSERT INTO Result(StudentNo,SubjectNo,ExamDate,StudentResult)
VALUES(1,4,2017-7-1,100)

IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME='Subject')
	DROP TABLE Subject
GO
CREATE TABLE Subject
(
	SubjectNo int NOT NULL,
	SubjectName NVARCHAR(50) not null,
	ClassHour INT,
	GradeId int
)
INSERT INTO Subject(SubjectNo,SubjectName,ClassHour,GradeId)
VALUES(1,'语文',45,1)
INSERT INTO Subject(SubjectNo,SubjectName,ClassHour,GradeId)
VALUES(1,'数学',44,2)

IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME='Student')
	DROP TABLE Student
GO
CREATE TABLE Student
(
	StudentNo INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentNo PRIMARY KEY(StudentNo),
	LoginPwd NVARCHAR(50) NOT NULL CONSTRAINT CK_LoginPwd CHECK(LEN(LoginPwd)>=6),
	StudentName nvarchar(50) not null,
	Sex CHAR(2) NOT NULL CONSTRAINT CK_SEX CHECK(SEX='男'or sex='女'),
	GradeId INT NOT NULL CONSTRAINT FK_Grade_Student_GradeId FOREIGN KEY(GradeId) REFERENCES Grade(GradeId),
	Phone NVARCHAR(11),
	Adress NVARCHAR(255) NOT NULL CONSTRAINT DF_Addess DEFAULT('合肥'),
	BornDate DATETIME NOT NULL,
	Email NVARCHAR(50),
	IdentityCard VARCHAR(18) NOT NULL CONSTRAINT UQ_IdentityCard UNIQUE(IdentityCard)
)
INSERT INTO Student(LoginPwd,StudentName,Sex,GradeId,Phone,Adress,BornDate,Email,IdentityCard)
VALUES(1234567,'张三','男',3,18555115357,'上海',1995-12-29,'absver@outlook.com',342225199511087814)
INSERT INTO Student(LoginPwd,StudentName,Sex,GradeId,Phone,Adress,BornDate,Email,IdentityCard)
VALUES(12345665,'李四','女',3,17756024097,'北京',1995-11-08,'absver@foxmail.com',342225199511087815)
INSERT INTO Student(LoginPwd,StudentName,Sex,GradeId,Phone,Adress,BornDate,Email,IdentityCard)
VALUES(1234567453,'小明','男',3,18985115357,'上海',1995-2-29,'absver@outlook.com',342225199511087987)
INSERT INTO Student(LoginPwd,StudentName,Sex,GradeId,Phone,Adress,BornDate,Email,IdentityCard)
VALUES(123456756,'小强','女',3,17756012097,'北京',1995-11-3,'absver@foxmail.com',342225199511081215)
