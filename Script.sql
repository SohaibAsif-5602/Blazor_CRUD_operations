USE [test]
GO
/****** Object:  Table [dbo].[Userinfo]    Script Date: 30/10/2023 9:09:33 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userinfo](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[del_data]    Script Date: 30/10/2023 9:09:33 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[del_data]
@User_id int
as 
begin
Delete from Userinfo where User_id=@User_id
end
GO
/****** Object:  StoredProcedure [dbo].[get_data]    Script Date: 30/10/2023 9:09:33 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[get_data]
as 
begin
select * from Userinfo
end
GO
/****** Object:  StoredProcedure [dbo].[save_data]    Script Date: 30/10/2023 9:09:33 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[save_data]
@Name varchar(20),
@Email nvarchar(30),
@Phone nchar(12)
as 
begin
insert into Userinfo(Name,Email,Phone) values(@Name,@Email,@Phone)
end
GO
/****** Object:  StoredProcedure [dbo].[Update_data]    Script Date: 30/10/2023 9:09:33 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Update_data]
@User_id int,
@Name varchar(20),
@Email nvarchar(30),
@Phone nchar(12)
as 
begin
Update Userinfo
set Name=@Name,
Email=@Email,
Phone=@Phone
where User_id=@User_id
end
GO
