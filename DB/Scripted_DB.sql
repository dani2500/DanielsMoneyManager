USE [master]
GO
/****** Object:  Database [DB_DanielsMoneyManager]    Script Date: 10/04/2023 18:13:39 ******/
CREATE DATABASE [DB_DanielsMoneyManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DanielsMoneyManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DanielsMoneyManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DanielsMoneyManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DanielsMoneyManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_DanielsMoneyManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET  MULTI_USER 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_DanielsMoneyManager', N'ON'
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET QUERY_STORE = OFF
GO
USE [DB_DanielsMoneyManager]
GO
/****** Object:  Table [dbo].[Cash_Actions]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cash_Actions](
	[Cash_Action_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[Sum] [float] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Cash_Action_Time] [datetime] NOT NULL,
	[Insert_Time] [datetime] NULL,
	[Update_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cash_Action_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Category_Name] [nvarchar](255) NOT NULL,
	[Insert_Time] [datetime] NOT NULL,
	[Update_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fund_Actions]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fund_Actions](
	[Fund_Action_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fund_ID] [int] NOT NULL,
	[Investment_Sum] [float] NOT NULL,
	[Investment_Date] [date] NOT NULL,
	[Current_State] [float] NOT NULL,
	[Note] [nvarchar](1024) NULL,
	[Insert_Time] [datetime] NOT NULL,
	[Update_Time] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funds]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funds](
	[Fund_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fund_Name] [nvarchar](255) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Insert_Time] [datetime] NOT NULL,
	[Update_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Fund_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](255) NOT NULL,
	[User_Password] [nvarchar](255) NOT NULL,
	[User_Email] [nvarchar](255) NOT NULL,
	[Insert_Time] [datetime] NULL,
	[Update_Time] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cash_Actions] ADD  CONSTRAINT [DF_Cash_Actions_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
GO
ALTER TABLE [dbo].[Fund_Actions] ADD  CONSTRAINT [DF_Fund_Actions_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
GO
ALTER TABLE [dbo].[Funds] ADD  CONSTRAINT [DF_funds_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
GO
/****** Object:  StoredProcedure [dbo].[Cash_Actions_Delete]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-24
-- Description:	Delete cash action (secured by User_ID)
-- =============================================
CREATE PROCEDURE [dbo].[Cash_Actions_Delete]
	@Cash_Action_IDs NVARCHAR(MAX),
	@User_ID INT
AS
BEGIN
	
	DELETE FROM [dbo].[Cash_Actions]
	WHERE [Cash_Action_ID] IN (SELECT value FROM STRING_SPLIT(@Cash_Action_IDs, ','))
			AND [Category_ID] IN (SELECT [Category_ID] FROM [dbo].[Categories] WHERE [User_ID]=@User_ID)

END
GO
/****** Object:  StoredProcedure [dbo].[Cash_Actions_Get]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-03
-- Description:	Get cash actions
-- =============================================
CREATE PROCEDURE [dbo].[Cash_Actions_Get]
	@From_Time DATETIME,
	@To_Time DATETIME,
	@Category_ID INT,
	@User_ID INT
AS
BEGIN
	SELECT [Cash_Action_ID]
		  ,CA.[Category_ID]
		  ,[Sum]
		  ,[Description]
		  ,[Cash_Action_Time]
		  ,CA.[Insert_Time]
		  ,CA.[Update_Time]
	  FROM [dbo].[Cash_Actions] CA
	  LEFT JOIN [dbo].[Categories] C ON C.Category_ID = CA.Category_ID
	  WHERE @From_Time<[Cash_Action_Time]
			AND [Cash_Action_Time]<=@To_Time
			AND (@Category_ID = -1 OR CA.Category_ID = @Category_ID)
			AND C.[User_ID] = @User_ID
END
GO
/****** Object:  StoredProcedure [dbo].[Cash_Actions_Get_Balances]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Get balance per category
-- =============================================
CREATE PROCEDURE [dbo].[Cash_Actions_Get_Balances]
	@User_ID INT,
	@To_Time DATETIME
AS
BEGIN

	SELECT C.[Category_ID],
			CASE WHEN SUM([Sum]) IS NULL THEN 0 ELSE SUM([Sum]) END AS 'Category_Balance',
			CASE WHEN SUM([Sum]) IS NULL THEN 0 ELSE COUNT (*) END AS 'Cash_Actions_Count'
	  FROM [dbo].[Categories] C
	  LEFT JOIN  [dbo].[Cash_Actions] CA ON C.Category_ID = CA.Category_ID AND CA.[Cash_Action_Time]<=@To_Time
	  WHERE C.[User_ID] = @User_ID
	GROUP BY C.[Category_ID]

END
GO
/****** Object:  StoredProcedure [dbo].[Cash_Actions_Get_Total_Balance]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Get total balance
-- =============================================
CREATE PROCEDURE [dbo].[Cash_Actions_Get_Total_Balance]
	@User_ID INT,
	@To_Time DATETIME
AS
BEGIN

	SELECT SUM(CA.[Sum]) AS 'Total_Balance'
	  FROM [dbo].[Cash_Actions] CA
	  LEFT JOIN [dbo].[Categories] C ON C.[Category_ID] = CA.[Category_ID]
	  WHERE C.[User_ID] = @User_ID
			AND [Cash_Action_Time]<=@To_Time

END
GO
/****** Object:  StoredProcedure [dbo].[Cash_Actions_Insert]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Insert cash action
-- =============================================
CREATE PROCEDURE [dbo].[Cash_Actions_Insert]
	@Category_ID INT
	,@Sum FLOAT
	,@Description NVARCHAR(255)
	,@Cash_Action_Time DATETIME
AS
BEGIN
	
	INSERT INTO [dbo].[Cash_Actions] ([Category_ID]
									  ,[Sum]
									  ,[Description]
									  ,[Cash_Action_Time])
	VALUES (@Category_ID
			,@Sum
			,@Description
			,@Cash_Action_Time)


	SELECT [Cash_Action_ID]
      ,[Category_ID]
      ,[Sum]
      ,[Description]
      ,[Cash_Action_Time]
      ,[Insert_Time]
      ,[Update_Time]
	FROM [dbo].[Cash_Actions]
	WHERE [Cash_Action_ID] = SCOPE_IDENTITY()


END
GO
/****** Object:  StoredProcedure [dbo].[Cash_Actions_Update]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Update cash action
-- =============================================
CREATE PROCEDURE [dbo].[Cash_Actions_Update]
	@Cash_Action_ID INT
	,@Category_ID INT
	,@Sum FLOAT
	,@Description NVARCHAR(255)
	,@Cash_Action_Time DATETIME
AS
BEGIN
	
	UPDATE [dbo].[Cash_Actions]
	SET [Category_ID] = @Category_ID
		,[Sum] = @Sum
		,[Description] = @Description
		,[Cash_Action_Time] = @Cash_Action_Time
	WHERE [Cash_Action_ID] = @Cash_Action_ID


	SELECT [Cash_Action_ID]
      ,[Category_ID]
      ,[Sum]
      ,[Description]
      ,[Cash_Action_Time]
      ,[Insert_Time]
      ,[Update_Time]
	FROM [dbo].[Cash_Actions]
	WHERE [Cash_Action_ID] = @Cash_Action_ID


END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Delete]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-06
-- Description:	Delete category
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Delete]
	@Category_ID INT

AS
BEGIN

	  DELETE FROM [dbo].[Categories]
	  WHERE [Category_ID] = @Category_ID

END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Get]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Get categories
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Get]
	@User_ID INT
AS
BEGIN

	SELECT [Category_ID]
		  ,[User_ID]
		  ,[Category_Name]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [dbo].[Categories]
	  WHERE [User_ID] = @User_ID


END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Get_By_ID]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-07
-- Description:	Get category by ID
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Get_By_ID]
	@Category_ID INT
AS
BEGIN

	SELECT [Category_ID]
		  ,[User_ID]
		  ,[Category_Name]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [dbo].[Categories]
	  WHERE [Category_ID] = @Category_ID


END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Get_By_Name]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Get categories
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Get_By_Name]
	@User_ID INT,
	@Category_Name NVARCHAR(255)
AS
BEGIN

	SELECT [Category_ID]
		  ,[User_ID]
		  ,[Category_Name]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [dbo].[Categories]
	  WHERE [User_ID] = @User_ID AND [Category_Name] = @Category_Name


END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Insert]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Insert category
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Insert]
	@User_ID INT,
	@Category_Name NVARCHAR(255)

AS
BEGIN
	
	INSERT INTO [dbo].[Categories] ([User_ID]
									,[Category_Name])
	VALUES (@User_ID
			,@Category_Name)

	SELECT [Category_ID]
		  ,[User_ID]
		  ,[Category_Name]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [DB_DanielsMoneyManager].[dbo].[Categories]
	  WHERE [Category_ID] = SCOPE_IDENTITY()

END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Update]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Update category
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Update]
	@Category_ID INT,
	@Category_Name NVARCHAR(255)
AS
BEGIN

	UPDATE [dbo].[Categories]
	SET [Category_Name] = @Category_Name
	WHERE [Category_ID] = @Category_ID

	SELECT [Category_ID]
		  ,[User_ID]
		  ,[Category_Name]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [DB_DanielsMoneyManager].[dbo].[Categories]
	  WHERE [Category_ID] = @Category_ID

END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Delete]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-09
-- Description:	Delete fund
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Delete]
	@Fund_ID INT

AS
BEGIN

	  DELETE FROM [dbo].[Funds]
	  WHERE [Fund_ID] = @Fund_ID

END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Get]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-09
-- Description:	Get funds
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Get]
	@User_ID INT
AS
BEGIN

	 SELECT [Fund_ID]
      ,[Fund_Name]
	  ,[User_ID]
      ,[Insert_Time]
      ,[Update_Time]
	FROM [dbo].[Funds]
	WHERE [User_ID] = @User_ID


END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Get_By_ID]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-09
-- Description:	Get fund by ID
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Get_By_ID]
	@Fund_ID INT
AS
BEGIN

	SELECT [Fund_ID]
		  ,[Fund_Name]
		  ,[User_ID]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [dbo].[Funds]
	  WHERE [Fund_ID] = @Fund_ID


END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Get_By_Name]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-09
-- Description:	Get fund by name
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Get_By_Name]
	@User_ID INT,
	@Fund_Name NVARCHAR(255)
AS
BEGIN

	SELECT [Fund_ID]
		  ,[Fund_Name]
		  ,[User_ID]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [dbo].[Funds]
	  WHERE [User_ID] = @User_ID AND [Fund_Name] = @Fund_Name


END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Get_Status]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-10
-- Description:	Get funds status
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Get_Status]
	@User_ID INT,
	@To_Time DATETIME
AS
BEGIN

	-- Declarations
	DECLARE @Fund_Ids TABLE([Fund_ID] INT)

	DECLARE @LastActionIds TABLE([Fund_Action_ID] INT)

	DECLARE @LastActionPerFund TABLE([Fund_Action_ID] INT
									,[Fund_ID] INT
									,[Investment_Sum] FLOAT
									,[Investment_Date] DATE
									,[Current_State] FLOAT
									,[Note] NVARCHAR(1024)
									)

	-- Caculations
	INSERT INTO @Fund_Ids
	SELECT [Fund_ID]
	FROM [dbo].[Funds]
	WHERE [User_ID] = @User_ID

	INSERT INTO @LastActionIds
	SELECT MAX([Fund_Action_ID])
	FROM [dbo].[Fund_Actions]
	WHERE [Investment_Date]<=@To_Time AND [Fund_ID] IN (SELECT [Fund_ID] FROM @Fund_Ids)
	GROUP BY [Fund_ID]

	INSERT INTO @LastActionPerFund
	SELECT [Fund_Action_ID]
		  ,[Fund_ID]
		  ,[Investment_Sum]
		  ,[Investment_Date]
		  ,[Current_State]
		  ,[Note]
	FROM [dbo].[Fund_Actions] 
	WHERE [Fund_Action_ID] IN (SELECT [Fund_Action_ID] FROM @LastActionIds)


	SELECT FA.[Fund_ID]
		  ,MIN(FA.[Investment_Date]) AS First_Investment_Date
		  ,MAX(FA.[Investment_Date]) AS Last_Investment_Date
		  ,SUM(FA.[Investment_Sum]) AS Invested_Sum
		  ,(SELECT [Current_State] FROM @LastActionPerFund LA WHERE LA.[Fund_ID] = FA.[Fund_ID]) AS Actual_Sum
		  ,(SELECT [Current_State] - SUM(FA.[Investment_Sum]) FROM @LastActionPerFund LA WHERE LA.[Fund_ID] = FA.[Fund_ID]) AS Profit
	  FROM [dbo].[Fund_Actions] FA
	  --RIGHT JOIN [dbo].[Funds] F ON F.Fund_ID = FA.Fund_ID
	  WHERE [Investment_Date]<=@To_Time AND FA.[Fund_ID] IN (SELECT [Fund_ID] FROM @Fund_Ids) 
	  GROUP BY FA.[Fund_ID]


END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Insert]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-10
-- Description:	Insert fund
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Insert]
	@User_ID INT,
	@Fund_Name NVARCHAR(255)

AS
BEGIN
	
	INSERT INTO [dbo].[Funds] ([User_ID]
									,[Fund_Name])
	VALUES (@User_ID
			,@Fund_Name)

	SELECT [Fund_ID]
		  ,[Fund_Name]
		  ,[User_ID]
		  ,[Insert_Time]
		  ,[Update_Time]
	  FROM [dbo].[Funds]
	  WHERE [Fund_ID] = SCOPE_IDENTITY()

END
GO
/****** Object:  StoredProcedure [dbo].[Funds_Update]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-09
-- Description:	Update fund
-- =============================================
CREATE PROCEDURE [dbo].[Funds_Update]
	@Fund_ID INT,
	@Fund_Name NVARCHAR(255)
AS
BEGIN

	UPDATE [dbo].[Funds]
	SET [Fund_Name] = @Fund_Name
	WHERE [Fund_ID] = @Fund_ID

	SELECT [Fund_ID]
      ,[Fund_Name]
      ,[Insert_Time]
      ,[Update_Time]
	FROM [dbo].[Funds]
	WHERE [Fund_ID] = @Fund_ID

END
GO
/****** Object:  StoredProcedure [dbo].[Users_Get_By_Cash_Action_ID]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-07
-- Description:	Get user by cash action
-- =============================================
CREATE PROCEDURE [dbo].[Users_Get_By_Cash_Action_ID]
	@Cash_Action_ID INT
AS
BEGIN
SELECT U.[User_ID]
      ,U.[User_Name]
      ,U.[User_Password]
      ,U.[User_Email]
  FROM [dbo].[Cash_Actions] CA
  LEFT JOIN [dbo].[Categories] C ON C.Category_ID = CA.Category_ID
  LEFT JOIN [dbo].[Users] U ON C.[User_ID] = U.[User_ID]
  WHERE CA.Cash_Action_ID = @Cash_Action_ID
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Get_By_Category_ID]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-04-07
-- Description:	Get user by cash action
-- =============================================
CREATE PROCEDURE [dbo].[Users_Get_By_Category_ID]
	@Category_ID INT
AS
BEGIN
SELECT U.[User_ID]
      ,U.[User_Name]
      ,U.[User_Password]
      ,U.[User_Email]
  FROM [dbo].[Users] U
  LEFT JOIN [dbo].[Categories] C ON C.[User_ID] = U.[User_ID]
  WHERE C.Category_ID = @Category_ID
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Get_By_Email]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-02
-- Description:	Get user by email
-- =============================================
CREATE PROCEDURE [dbo].[Users_Get_By_Email]
	@UserEmail NVARCHAR(255) = NULL
AS
BEGIN
	SELECT [User_ID]
      ,[User_Name]
      ,[User_Password]
      ,[User_Email]
	FROM [dbo].[Users]
	WHERE [User_Email] = @UserEmail
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Get_By_ID]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-02
-- Description:	Get user by id
-- =============================================
CREATE PROCEDURE [dbo].[Users_Get_By_ID]
	@UserID INT = NULL
AS
BEGIN
	SELECT [User_ID]
      ,[User_Name]
      ,[User_Password]
      ,[User_Email]
	FROM [dbo].[Users]
	WHERE [User_ID] = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Insert]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-02
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[Users_Insert]
	@UserName NVARCHAR(255),
	@UserPassword NVARCHAR(255),
	@UserEmail NVARCHAR(255)
AS
BEGIN
	INSERT INTO dbo.Users ([User_Name], [User_Password], [User_Email])
	VALUES (@UserName, @UserPassword, @UserEmail)

	SELECT [User_ID]
      ,[User_Name]
      ,[User_Password]
      ,[User_Email]
	FROM [dbo].[Users]
	WHERE [User_ID] = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Update]    Script Date: 10/04/2023 18:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Daniel Fridman
-- Create date: 2023-03-17
-- Description:	Update user
-- =============================================
CREATE PROCEDURE [dbo].[Users_Update]
	@UserID INT
	,@User_Name NVARCHAR(255)
	,@User_Password NVARCHAR(255)
	,@User_Email NVARCHAR(255)
AS
BEGIN
	UPDATE [dbo].[Users]
	SET [User_Name] = @User_Name
		  ,[User_Password] = @User_Password
		  ,[User_Email] = @User_Email
	WHERE [User_ID] = @UserID 

	SELECT [User_ID]
      ,[User_Name]
      ,[User_Password]
      ,[User_Email]
	FROM [dbo].[Users]
	WHERE [User_ID] = @UserID
END
GO
USE [master]
GO
ALTER DATABASE [DB_DanielsMoneyManager] SET  READ_WRITE 
GO
