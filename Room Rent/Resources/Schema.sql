/****** Object:  Table [dbo].[tblWorkers]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblWorkers](
	[WorkerID] [int] NOT NULL,
	[WorkerName] [nvarchar](255) NULL,
	[DC_Date] [datetime] NULL,
	[Started_Date] [datetime] NULL,
	[Email] [nvarchar](255) NULL,
	[MobileNo] [nvarchar](255) NULL,
	[PreferredContactMethod] [nvarchar](255) NULL,
	[AdditionalInfo] [nvarchar](50) NULL,
	[Status] [nvarchar](255) NULL,
	[CheckInRoomNo] [nvarchar](255) NULL,
	[CheckInDate] [datetime] NULL,
	[CheckInID] [int] NULL,
	[dc_file] [image] NULL,
	[dc_file_ext] [nvarchar](255) NULL,
	[dc_file_name] [nvarchar](255) NULL,
	[NotAvailableTill] [datetime] NULL,
	[AvailabilityComment] [varchar](max) NULL,
	[RealName] [varchar](250) NULL,
	[DOB] [date] NULL,
	[Nation] [varchar](150) NULL,
 CONSTRAINT [aaaaatblWorkers_PK] PRIMARY KEY NONCLUSTERED 
(
	[WorkerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblWorkerFavourites]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblWorkerFavourites](
	[ItemId] [int] NOT NULL,
	[WorkerId] [int] NULL,
	[ClientName] [varchar](max) NULL,
	[Mobile] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PreferedContactTime] [varchar](550) NULL,
	[PrefereredContactMethod] [varchar](50) NULL,
 CONSTRAINT [PK_tblWorkerFavourites] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVouchers]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVouchers](
	[VoucherId] [int] NOT NULL,
	[RefNo] [nvarchar](255) NULL,
	[VoucherDate] [datetime] NULL,
	[Valid] [int] NULL,
	[VoucherValue] [int] NULL,
	[Comment] [ntext] NULL,
	[Status] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblVouchers_PK] PRIMARY KEY NONCLUSTERED 
(
	[VoucherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserRules]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserRules](
	[ItemSl] [int] NOT NULL,
	[RuleName] [varchar](50) NULL,
	[Enabled] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_tblRules] PRIMARY KEY CLUSTERED 
(
	[ItemSl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserLoginInfo]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserLoginInfo](
	[ItemSL] [int] NOT NULL,
	[UserID] [int] NULL,
	[LoginDate] [datetime] NULL,
	[LogoutDate] [datetime] NULL,
 CONSTRAINT [PK_tblUserLoginInfo] PRIMARY KEY CLUSTERED 
(
	[ItemSL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserDetails]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserDetails](
	[UserId] [int] NOT NULL,
	[BranchID] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserType] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Enable] [bit] NOT NULL,
	[LastLoginDate] [datetime] NULL,
	[EnabledDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Session] [varchar](50) NULL,
	[FullName] [varchar](150) NULL,
	[Address] [varchar](500) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Zip] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_tblUserDetails] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblStock]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStock](
	[StockId] [int] NOT NULL,
	[ProductID] [int] NULL,
	[Qty] [int] NULL,
	[Price] [int] NULL,
	[Tax] [int] NULL,
	[Discount] [int] NULL,
	[Type] [nvarchar](255) NULL,
	[TrasactionId] [int] NULL,
	[TrasactionType] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblStock_PK] PRIMARY KEY NONCLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblShiftFee]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblShiftFee](
	[Serial] [int] NOT NULL,
	[Room] [nvarchar](255) NULL,
	[FeeDate] [datetime] NULL,
	[WorkerID] [int] NULL,
	[Amount] [int] NULL,
	[Comment] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblShiftFee_PK] PRIMARY KEY NONCLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblSettings2]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSettings2](
	[ItemSl] [int] NOT NULL,
	[Item] [nvarchar](255) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [aaaaatblSettings2_PK] PRIMARY KEY NONCLUSTERED 
(
	[ItemSl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblSettings]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSettings](
	[Sl] [int] NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
	[ReceiptPrinterName] [nvarchar](255) NULL,
	[CompanyAddress] [nvarchar](255) NULL,
	[CompanyPhone] [nvarchar](255) NULL,
	[MemoFooter1] [nvarchar](255) NULL,
	[MemoFooter2] [nvarchar](255) NULL,
	[MemoFooter] [nvarchar](255) NULL,
	[MemoFooter3] [nvarchar](255) NULL,
	[RoomCharge] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[Surcharge] [decimal](18, 2) NULL,
	[SP_Percentage] [float] NULL,
	[SP_Percentage_Night] [float] NULL,
	[Day_Start] [nvarchar](255) NULL,
	[Day_End] [nvarchar](255) NULL,
	[Encryted] [nvarchar](255) NULL,
	[PassHint] [nvarchar](255) NULL,
	[SpecialServiceEnabled] [nvarchar](255) NULL,
	[Eve_start] [nvarchar](255) NULL,
	[Eve_End] [nvarchar](255) NULL,
	[Shifts_3_enabled] [nvarchar](255) NULL,
	[Contra] [nvarchar](255) NULL,
	[Contra_Password] [nvarchar](255) NULL,
	[OtherSettings] [varchar](max) NULL,
 CONSTRAINT [aaaaatblSettings_PK] PRIMARY KEY NONCLUSTERED 
(
	[Sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblService]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblService](
	[sl] [int] NOT NULL,
	[Service] [nvarchar](255) NULL,
	[DayPrice] [decimal](18, 2) NULL,
	[NightPrice] [decimal](18, 2) NULL,
 CONSTRAINT [aaaaatblService_PK] PRIMARY KEY NONCLUSTERED 
(
	[sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoom]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoom](
	[Sl] [int] NULL,
	[Room] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[AdditonalCharge] [decimal](18, 2) NULL,
	[Status] [nvarchar](255) NULL,
	[Usable] [nvarchar](255) NULL,
	[Comment] [ntext] NULL,
	[StatusTime] [datetime] NULL,
	[AutoActiveIn] [int] NULL,
	[AddlSP_Fee] [decimal](18, 2) NULL,
	[AddlHouse_Fee] [decimal](18, 2) NULL,
 CONSTRAINT [aaaaatblRoom_PK] PRIMARY KEY NONCLUSTERED 
(
	[Room] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProducts](
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Brand] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NULL,
	[Unit] [nvarchar](50) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Barcode] [nvarchar](15) NULL,
	[ExpireIn] [int] NULL,
	[ExpireInType] [nvarchar](25) NULL,
	[MinimumStock] [int] NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [aaaaatblProducts_PK] PRIMARY KEY NONCLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPremiumServices]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPremiumServices](
	[ItemID] [int] NOT NULL,
	[WeekDay] [int] NULL,
	[Servicecharge] [decimal](18, 2) NULL,
	[Sp] [decimal](18, 2) NULL,
	[House] [decimal](18, 2) NULL,
 CONSTRAINT [aaaaatblPremiumServices_PK] PRIMARY KEY NONCLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayment]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[ID] [int] NOT NULL,
	[Transc_ID] [int] NULL,
	[Transac_Type] [nvarchar](255) NULL,
	[PaymentMode] [nvarchar](255) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CASH] [decimal](18, 2) NULL,
	[CARD] [decimal](18, 2) NULL,
	[SURCHARGE_P] [decimal](18, 2) NULL,
	[SURCHARGE_AMT] [decimal](18, 2) NULL,
	[TOTAIL_PAID] [decimal](18, 2) NULL,
	[Transc_Time] [datetime] NULL,
	[Remarks] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[VoucherAmount] [decimal](18, 2) NULL,
	[VoucherID] [int] NULL,
	[ShiftFee] [decimal](18, 2) NULL,
	[MemoNo] [int] NULL,
	[CashOut] [decimal](18, 2) NULL,
	[Tip] [decimal](18, 2) NULL,
	[GST] [decimal](18, 2) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblPayment_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMembers]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMembers](
	[MemberID] [nvarchar](255) NOT NULL,
	[Sl] [int] NULL,
	[Name] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [aaaaatblMembers_PK] PRIMARY KEY NONCLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLookUp]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLookUp](
	[sl] [int] NOT NULL,
	[Worker] [int] NULL,
	[Client] [int] NULL,
	[Booking] [int] NULL,
	[Message] [nvarchar](255) NULL,
	[Extras] [nvarchar](255) NULL,
	[Service] [int] NULL,
	[SP_Amount] [decimal](18, 2) NULL,
	[House_Amount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Type] [nvarchar](255) NULL,
	[ServiceType] [nvarchar](255) NULL,
	[Room] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [aaaaatblLookUp_PK] PRIMARY KEY NONCLUSTERED 
(
	[sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLockerBooking]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLockerBooking](
	[Sl] [int] NOT NULL,
	[LockerNumber] [nvarchar](255) NULL,
	[ClientName] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[BookingDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [nvarchar](255) NULL,
	[Time] [int] NULL,
	[TimeType] [nvarchar](255) NULL,
	[Price] [int] NULL,
	[WorkerID] [int] NULL,
 CONSTRAINT [aaaaatblLockerBooking_PK] PRIMARY KEY NONCLUSTERED 
(
	[Sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLocker]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLocker](
	[Sl] [int] NULL,
	[LockerNumber] [nvarchar](255) NOT NULL,
	[LockerName] [nvarchar](255) NULL,
	[Price] [int] NULL,
	[Description] [ntext] NULL,
	[DateCreated] [datetime] NULL,
	[LastAccessed] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblLocker_PK] PRIMARY KEY NONCLUSTERED 
(
	[LockerNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInstant]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInstant](
	[InstantID] [int] NOT NULL,
	[DoorName] [nvarchar](255) NULL,
	[DoorCharge] [int] NULL,
	[InstantDate] [datetime] NULL,
	[TotalAmount] [int] NULL,
	[Qty] [int] NULL,
	[Status] [nvarchar](255) NULL,
	[MemoNo] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblInstant_PK] PRIMARY KEY NONCLUSTERED 
(
	[InstantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblExtraService]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExtraService](
	[Sl] [int] NOT NULL,
	[Service] [int] NULL,
	[BookingID] [int] NULL,
	[WorkerID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[MemoNo] [int] NULL,
	[ServiceType] [nvarchar](255) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblExtraService_PK] PRIMARY KEY NONCLUSTERED 
(
	[Sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEscortDriverInfo]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEscortDriverInfo](
	[ID] [int] NOT NULL,
	[BookingID] [int] NULL,
	[Location] [nvarchar](255) NULL,
	[Others] [ntext] NULL,
	[Remarks] [ntext] NULL,
 CONSTRAINT [aaaaatblEscortDriverInfo_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmpId] [int] NOT NULL,
	[EmpName] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Paytype] [nvarchar](255) NULL,
	[PayRate] [nvarchar](255) NULL,
	[PayStart] [datetime] NULL,
 CONSTRAINT [aaaaatblEmployee_PK] PRIMARY KEY NONCLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmpCheckIN]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmpCheckIN](
	[ID] [int] NOT NULL,
	[EmpID] [int] NULL,
	[CheckIn] [datetime] NULL,
	[CheckOut] [datetime] NULL,
	[Status] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblEmpCheckIN_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDocketMemo]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDocketMemo](
	[MemoNo] [int] NOT NULL,
	[MemoType] [nvarchar](255) NULL,
	[MemoDate] [datetime] NULL,
	[Remarks] [nvarchar](255) NULL,
	[PrintText] [ntext] NULL,
 CONSTRAINT [aaaaatblDocketMemo_PK] PRIMARY KEY NONCLUSTERED 
(
	[MemoNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDBVersion]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDBVersion](
	[ID] [int] NOT NULL,
	[Version] [nvarchar](255) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdaterInfo] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [aaaaatblDBVersion_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDailyCounter]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDailyCounter](
	[sl] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Value] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[Remarks] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblDailyCounter_PK] PRIMARY KEY NONCLUSTERED 
(
	[sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCheckIn]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCheckIn](
	[CheckInId] [int] NOT NULL,
	[WorkerID] [int] NULL,
	[CheckInRoomNo] [nvarchar](255) NULL,
	[CheckInDate] [datetime] NULL,
	[DC_Date] [datetime] NULL,
	[DC_File] [image] NULL,
	[DC_File_Name] [nvarchar](255) NULL,
	[DC_File_Ext] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblCheckIn_PK] PRIMARY KEY NONCLUSTERED 
(
	[CheckInId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCalender]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCalender](
	[date_val] [datetime] NOT NULL,
 CONSTRAINT [aaaaatblCalender_PK] PRIMARY KEY NONCLUSTERED 
(
	[date_val] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBookingStatus]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBookingStatus](
	[sl] [int] NOT NULL,
	[BookingID] [int] NULL,
	[Status] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[MemoNo] [int] NULL,
	[Reason] [varchar](max) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblBookingStatus_PK] PRIMARY KEY NONCLUSTERED 
(
	[sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBookings]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBookings](
	[BookingID] [int] NOT NULL,
	[Room] [nvarchar](255) NULL,
	[Service] [int] NULL,
	[BookingDate] [datetime] NULL,
	[Scheduledate] [datetime] NULL,
	[BookingType] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[WorkerID] [int] NULL,
	[CustomerName] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Worker_status] [nvarchar](255) NULL,
	[Client_status] [nvarchar](255) NULL,
	[TotalClient] [int] NULL,
	[MemberId] [nvarchar](255) NULL,
	[MemoNo] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblBookings_PK] PRIMARY KEY NONCLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBookingPayments]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBookingPayments](
	[Sl] [int] NOT NULL,
	[Type] [nvarchar](255) NULL,
	[Total] [decimal](18, 2) NULL,
	[BookingId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Cash] [decimal](18, 2) NULL,
	[CARD] [decimal](18, 2) NULL,
	[Surcharge] [decimal](18, 2) NULL,
	[Surcharge_Amt] [decimal](18, 2) NULL,
	[Tip] [decimal](18, 2) NULL,
	[Status] [nvarchar](255) NULL,
	[PaymentMode] [nvarchar](255) NULL,
	[Sp_Amount] [decimal](18, 2) NULL,
	[House_amount] [decimal](18, 2) NULL,
	[CashOut] [decimal](18, 2) NULL,
	[WorkerID] [int] NULL,
	[VoucherAmount] [decimal](18, 2) NULL,
	[VoucherID] [int] NULL,
	[ShiftFee] [decimal](18, 2) NULL,
	[MemoNo] [int] NULL,
	[Upgrade] [decimal](18, 2) NULL,
	[EncrytedInfo] [nvarchar](max) NULL,
	[GST] [decimal](18, 2) NULL,
	[UserId] [int] NULL,
	[CarFare] [decimal](18, 2) NULL,
	[EscortExtensionFees] [decimal](18, 2) NULL,
	[CardName] [varchar](50) NULL,
 CONSTRAINT [aaaaatblBookingPayments_PK] PRIMARY KEY NONCLUSTERED 
(
	[Sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBookingPause]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBookingPause](
	[ItemSl] [int] NOT NULL,
	[BookingId] [int] NULL,
	[WorkerId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[PausedTime] [datetime] NULL,
	[ResumeTime] [datetime] NULL,
	[Status] [varchar](50) NULL,
	[Reason] [varchar](max) NULL,
 CONSTRAINT [PK_tblBookingPause2] PRIMARY KEY CLUSTERED 
(
	[ItemSl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBillItems]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBillItems](
	[ItemID] [int] NOT NULL,
	[BillID] [int] NULL,
	[ProductId] [int] NULL,
	[Qty] [int] NULL,
	[Price] [int] NULL,
	[Subtotal] [int] NULL,
 CONSTRAINT [aaaaatblBillItems_PK] PRIMARY KEY NONCLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBill]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBill](
	[BillID] [int] NOT NULL,
	[C_Name] [nvarchar](255) NULL,
	[Amount] [int] NULL,
	[BillDate] [datetime] NULL,
	[Status] [nvarchar](255) NULL,
 CONSTRAINT [aaaaatblBill_PK] PRIMARY KEY NONCLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblActiveWorker]    Script Date: 10/31/2014 18:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblActiveWorker](
	[sl] [int] NOT NULL,
	[workerid] [int] NULL,
	[workingdate] [datetime] NULL,
	[room] [nvarchar](255) NULL,
	[service] [int] NULL,
	[addedtime] [datetime] NULL,
	[starttime] [datetime] NULL,
	[Status] [nvarchar](255) NULL,
	[BookingId] [int] NULL,
	[StoppedTime] [datetime] NULL,
	[MemoNo] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [aaaaatblActiveWorker_PK] PRIMARY KEY NONCLUSTERED 
(
	[sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__tblWorker__NotAv__6D0D32F4]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblWorkers] ADD  CONSTRAINT [DF__tblWorker__NotAv__6D0D32F4]  DEFAULT (getdate()) FOR [NotAvailableTill]
GO
/****** Object:  Default [DF__tblVouche__Statu__6B24EA82]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblVouchers] ADD  DEFAULT ('ACTIVE') FOR [Status]
GO
/****** Object:  Default [DF__tblVoucher__Type__6C190EBB]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblVouchers] ADD  DEFAULT ('DIRECT') FOR [Type]
GO
/****** Object:  Default [DF__tblSettin__Surch__5FB337D6]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ((0)) FOR [Surcharge]
GO
/****** Object:  Default [DF__tblSettin__Day_S__60A75C0F]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('00:00') FOR [Day_Start]
GO
/****** Object:  Default [DF__tblSettin__Day_E__619B8048]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('00:00') FOR [Day_End]
GO
/****** Object:  Default [DF__tblSettin__Encry__628FA481]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('0') FOR [Encryted]
GO
/****** Object:  Default [DF__tblSettin__PassH__6383C8BA]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('This is a hint') FOR [PassHint]
GO
/****** Object:  Default [DF__tblSettin__Speci__6477ECF3]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('0') FOR [SpecialServiceEnabled]
GO
/****** Object:  Default [DF__tblSettin__Eve_s__656C112C]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('00:00') FOR [Eve_start]
GO
/****** Object:  Default [DF__tblSettin__Eve_E__66603565]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('00:00') FOR [Eve_End]
GO
/****** Object:  Default [DF__tblSettin__Shift__6754599E]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('0') FOR [Shifts_3_enabled]
GO
/****** Object:  Default [DF__tblSettin__Contr__68487DD7]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('0') FOR [Contra]
GO
/****** Object:  Default [DF__tblSettin__Contr__693CA210]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  DEFAULT ('testpass') FOR [Contra_Password]
GO
/****** Object:  Default [DF_tblSettings_OtherSettings]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblSettings] ADD  CONSTRAINT [DF_tblSettings_OtherSettings]  DEFAULT ('') FOR [OtherSettings]
GO
/****** Object:  Default [DF__tblServic__DayPr__5DCAEF64]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblService] ADD  DEFAULT ((0)) FOR [DayPrice]
GO
/****** Object:  Default [DF__tblServic__Night__5EBF139D]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblService] ADD  DEFAULT ((0)) FOR [NightPrice]
GO
/****** Object:  Default [DF__tblRoom__Additon__5AEE82B9]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblRoom] ADD  DEFAULT ((0)) FOR [AdditonalCharge]
GO
/****** Object:  Default [DF__tblRoom__StatusT__5BE2A6F2]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblRoom] ADD  DEFAULT (getdate()) FOR [StatusTime]
GO
/****** Object:  Default [DF__tblRoom__AutoAct__5CD6CB2B]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblRoom] ADD  DEFAULT ((0)) FOR [AutoActiveIn]
GO
/****** Object:  Default [DF_tblRoom_AddlSP_Fee]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblRoom] ADD  CONSTRAINT [DF_tblRoom_AddlSP_Fee]  DEFAULT ((0)) FOR [AddlSP_Fee]
GO
/****** Object:  Default [DF_tblRoom_AddlHouse_Fee]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblRoom] ADD  CONSTRAINT [DF_tblRoom_AddlHouse_Fee]  DEFAULT ((0)) FOR [AddlHouse_Fee]
GO
/****** Object:  Default [DF__tblProduc__Entry__59FA5E80]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblProducts] ADD  CONSTRAINT [DF__tblProduc__Entry__59FA5E80]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  Default [DF__tblPremiu__Servi__59063A47]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPremiumServices] ADD  DEFAULT ((0)) FOR [Servicecharge]
GO
/****** Object:  Default [DF__tblPaymen__Total__4E88ABD4]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [TotalAmount]
GO
/****** Object:  Default [DF__tblPayment__CASH__4F7CD00D]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [CASH]
GO
/****** Object:  Default [DF__tblPayment__CARD__5070F446]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [CARD]
GO
/****** Object:  Default [DF__tblPaymen__SURCH__5165187F]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [SURCHARGE_P]
GO
/****** Object:  Default [DF__tblPaymen__SURCH__52593CB8]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [SURCHARGE_AMT]
GO
/****** Object:  Default [DF__tblPaymen__TOTAI__534D60F1]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [TOTAIL_PAID]
GO
/****** Object:  Default [DF__tblPaymen__Vouch__5441852A]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [VoucherAmount]
GO
/****** Object:  Default [DF__tblPaymen__Shift__5535A963]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [ShiftFee]
GO
/****** Object:  Default [DF__tblPaymen__CashO__5629CD9C]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [CashOut]
GO
/****** Object:  Default [DF__tblPayment__Tip__571DF1D5]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [Tip]
GO
/****** Object:  Default [DF__tblPayment__GST__5812160E]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  DEFAULT ((0)) FOR [GST]
GO
/****** Object:  Default [DF_tblPayment_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblPayment] ADD  CONSTRAINT [DF_tblPayment_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF__tblLookUp__SP_Am__4AB81AF0]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLookUp] ADD  DEFAULT ((0)) FOR [SP_Amount]
GO
/****** Object:  Default [DF__tblLookUp__House__4BAC3F29]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLookUp] ADD  DEFAULT ((0)) FOR [House_Amount]
GO
/****** Object:  Default [DF__tblLookUp__Total__4CA06362]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLookUp] ADD  DEFAULT ((0)) FOR [TotalAmount]
GO
/****** Object:  Default [DF__tblLookUp__Servi__4D94879B]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLookUp] ADD  DEFAULT ('STANDARD') FOR [ServiceType]
GO
/****** Object:  Default [DF_tblLookUp_Room]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLookUp] ADD  CONSTRAINT [DF_tblLookUp_Room]  DEFAULT (N'ROOM') FOR [Room]
GO
/****** Object:  Default [DF_tblLookUp_CreatedDate]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLookUp] ADD  CONSTRAINT [DF_tblLookUp_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  Default [DF_tblLocker_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblLocker] ADD  CONSTRAINT [DF_tblLocker_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF__tblInstant__Qty__49C3F6B7]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblInstant] ADD  DEFAULT ((1)) FOR [Qty]
GO
/****** Object:  Default [DF_tblInstant_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblInstant] ADD  CONSTRAINT [DF_tblInstant_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF__tblExtraS__Servi__48CFD27E]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblExtraService] ADD  DEFAULT ('STANDARD') FOR [ServiceType]
GO
/****** Object:  Default [DF_tblExtraService_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblExtraService] ADD  CONSTRAINT [DF_tblExtraService_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF_tblDBVersion_UpdaterInfo]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblDBVersion] ADD  CONSTRAINT [DF_tblDBVersion_UpdaterInfo]  DEFAULT ('') FOR [UpdaterInfo]
GO
/****** Object:  Default [DF_tblDBVersion_Type]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblDBVersion] ADD  CONSTRAINT [DF_tblDBVersion_Type]  DEFAULT ('VALID') FOR [Type]
GO
/****** Object:  Default [DF__tblCheckI__Statu__47DBAE45]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblCheckIn] ADD  DEFAULT ('IN') FOR [Status]
GO
/****** Object:  Default [DF_tblBookingStatus_Reason]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingStatus] ADD  CONSTRAINT [DF_tblBookingStatus_Reason]  DEFAULT ('') FOR [Reason]
GO
/****** Object:  Default [DF_tblBookingStatus_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingStatus] ADD  CONSTRAINT [DF_tblBookingStatus_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF__tblBookin__Statu__45F365D3]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookings] ADD  DEFAULT ('QUEUE') FOR [Status]
GO
/****** Object:  Default [DF__tblBookin__Total__46E78A0C]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookings] ADD  DEFAULT ((1)) FOR [TotalClient]
GO
/****** Object:  Default [DF_tblBookings_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookings] ADD  CONSTRAINT [DF_tblBookings_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF__tblBookin__Total__09DE7BCC]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Total__09DE7BCC]  DEFAULT ((0)) FOR [Total]
GO
/****** Object:  Default [DF__tblBooking__Cash__0AD2A005]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBooking__Cash__0AD2A005]  DEFAULT ((0)) FOR [Cash]
GO
/****** Object:  Default [DF__tblBooking__CARD__0BC6C43E]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBooking__CARD__0BC6C43E]  DEFAULT ((0)) FOR [CARD]
GO
/****** Object:  Default [DF__tblBookin__Surch__0CBAE877]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Surch__0CBAE877]  DEFAULT ((0)) FOR [Surcharge]
GO
/****** Object:  Default [DF__tblBookin__Surch__0DAF0CB0]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Surch__0DAF0CB0]  DEFAULT ((0)) FOR [Surcharge_Amt]
GO
/****** Object:  Default [DF__tblBookingP__Tip__0EA330E9]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookingP__Tip__0EA330E9]  DEFAULT ((0)) FOR [Tip]
GO
/****** Object:  Default [DF__tblBookin__Sp_Am__0F975522]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Sp_Am__0F975522]  DEFAULT ((0)) FOR [Sp_Amount]
GO
/****** Object:  Default [DF__tblBookin__House__108B795B]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__House__108B795B]  DEFAULT ((0)) FOR [House_amount]
GO
/****** Object:  Default [DF__tblBookin__CashO__117F9D94]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__CashO__117F9D94]  DEFAULT ((0)) FOR [CashOut]
GO
/****** Object:  Default [DF__tblBookin__Vouch__1273C1CD]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Vouch__1273C1CD]  DEFAULT ((0)) FOR [VoucherAmount]
GO
/****** Object:  Default [DF__tblBookin__Shift__1367E606]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Shift__1367E606]  DEFAULT ((0)) FOR [ShiftFee]
GO
/****** Object:  Default [DF__tblBookin__Upgra__145C0A3F]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookin__Upgra__145C0A3F]  DEFAULT ((0)) FOR [Upgrade]
GO
/****** Object:  Default [DF__tblBookingP__GST__15502E78]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF__tblBookingP__GST__15502E78]  DEFAULT ((0)) FOR [GST]
GO
/****** Object:  Default [DF_tblBookingPayments_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF_tblBookingPayments_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  Default [DF_tblBookingPayments_CareFare]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF_tblBookingPayments_CareFare]  DEFAULT ((0)) FOR [CarFare]
GO
/****** Object:  Default [DF_tblBookingPayments_EscortExtensionFees]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF_tblBookingPayments_EscortExtensionFees]  DEFAULT ((0)) FOR [EscortExtensionFees]
GO
/****** Object:  Default [DF_tblBookingPayments_CardName]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblBookingPayments] ADD  CONSTRAINT [DF_tblBookingPayments_CardName]  DEFAULT ('EFT') FOR [CardName]
GO
/****** Object:  Default [DF__tblActive__added__38996AB5]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblActiveWorker] ADD  DEFAULT (getdate()) FOR [addedtime]
GO
/****** Object:  Default [DF_tblActiveWorker_UserId]    Script Date: 10/31/2014 18:04:11 ******/
ALTER TABLE [dbo].[tblActiveWorker] ADD  CONSTRAINT [DF_tblActiveWorker_UserId]  DEFAULT ((0)) FOR [UserId]
GO


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookings ADD
	ExcludeFromReport bit NULL
GO
ALTER TABLE dbo.tblBookings SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookings ADD CONSTRAINT
	DF_tblBookings_ExcludeFromReport DEFAULT 0 FOR ExcludeFromReport
GO
ALTER TABLE dbo.tblBookings SET (LOCK_ESCALATION = TABLE)
GO
COMMIT




/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBill ADD
	UserId int NULL
GO
ALTER TABLE dbo.tblBill SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblExtraService ADD
	Shift varchar(50) NULL
GO
ALTER TABLE dbo.tblExtraService SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingPayments ADD
	Cancel_fees decimal(18, 2) NULL
GO
ALTER TABLE dbo.tblBookingPayments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_Cancel_fees DEFAULT 0 FOR Cancel_fees
GO
ALTER TABLE dbo.tblBookingPayments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

 /* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingPayments ADD
	Bond_amount decimal(18, 2) NULL
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_Bond_amount DEFAULT 0 FOR Bond_amount
GO
ALTER TABLE dbo.tblBookingPayments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblWorkers ADD
	IsEscort varchar(50) NULL
GO
ALTER TABLE dbo.tblWorkers ADD CONSTRAINT
	DF_tblWorkers_IsEscort DEFAULT 'YES' FOR IsEscort
GO
ALTER TABLE dbo.tblWorkers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookings ADD
	DisplayBookingId int NULL
GO
ALTER TABLE dbo.tblBookings ADD CONSTRAINT
	DF_tblBookings_DisplayBookingId DEFAULT 0 FOR DisplayBookingId
GO
ALTER TABLE dbo.tblBookings SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingStatus ADD
	NewId int NULL
GO
ALTER TABLE dbo.tblBookingStatus ADD CONSTRAINT
	DF_tblBookingStatus_NewId DEFAULT 0 FOR NewId
GO
ALTER TABLE dbo.tblBookingStatus SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblProducts ADD
	CodeName varchar(250) NULL
GO
ALTER TABLE dbo.tblProducts ADD CONSTRAINT
	DF_tblProducts_CodeName DEFAULT '' FOR CodeName
GO
ALTER TABLE dbo.tblProducts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


CREATE TABLE [dbo].[tblAdjustmentReport](
	[ReportID] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[TotalCash] [decimal](18, 2) NULL,
	[Card] [decimal](18, 2) NULL,
	[AdminFee] [decimal](18, 2) NULL,
	[Voucher] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[AdjustedSash] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_tblAdjustmentReport] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingPayments ADD
	DisplayBookingID int NULL
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_DisplayBookingID DEFAULT 0 FOR DisplayBookingID
GO
ALTER TABLE dbo.tblBookingPayments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT









/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblBillItems
	(
	ItemID int NOT NULL,
	BillID int NULL,
	ProductId int NULL,
	Qty int NULL,
	Price decimal(18, 2) NULL,
	Subtotal decimal(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblBillItems SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblBillItems)
	 EXEC('INSERT INTO dbo.Tmp_tblBillItems (ItemID, BillID, ProductId, Qty, Price, Subtotal)
		SELECT ItemID, BillID, ProductId, Qty, CONVERT(decimal(18, 2), Price), CONVERT(decimal(18, 2), Subtotal) FROM dbo.tblBillItems WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.tblBillItems
GO
EXECUTE sp_rename N'dbo.Tmp_tblBillItems', N'tblBillItems', 'OBJECT' 
GO
ALTER TABLE dbo.tblBillItems ADD CONSTRAINT
	aaaaatblBillItems_PK PRIMARY KEY NONCLUSTERED 
	(
	ItemID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT










/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblBill
	(
	BillID int NOT NULL,
	C_Name nvarchar(255) NULL,
	Amount decimal(18, 2) NULL,
	BillDate datetime NULL,
	Status nvarchar(255) NULL,
	UserId int NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.Tmp_tblBill SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblBill)
	 EXEC('INSERT INTO dbo.Tmp_tblBill (BillID, C_Name, Amount, BillDate, Status, UserId)
		SELECT BillID, C_Name, CONVERT(decimal(18, 2), Amount), BillDate, Status, UserId FROM dbo.tblBill WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.tblBill
GO
EXECUTE sp_rename N'dbo.Tmp_tblBill', N'tblBill', 'OBJECT' 
GO
ALTER TABLE dbo.tblBill ADD CONSTRAINT
	aaaaatblBill_PK PRIMARY KEY NONCLUSTERED 
	(
	BillID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT



/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingPayments ADD
	UtilizedVoucherAmount decimal(18, 2) NULL,
	OriginalShift varchar(50) NULL,
	PaidShift varchar(50) NULL,
	Gift decimal(18, 2) NULL
GO
ALTER TABLE dbo.tblBookingPayments
	DROP CONSTRAINT DF__tblBookin__Vouch__1273C1CD
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF__tblBookin__Vouch__1273C1CD DEFAULT 0 FOR VoucherAmount
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_UtilizedVoucherAmount DEFAULT 0 FOR UtilizedVoucherAmount
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_OriginalShift DEFAULT '' FOR OriginalShift
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_PaidShift DEFAULT '' FOR PaidShift
GO
ALTER TABLE dbo.tblBookingPayments ADD CONSTRAINT
	DF_tblBookingPayments_Gift DEFAULT 0 FOR Gift
GO
ALTER TABLE dbo.tblBookingPayments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

GO

CREATE TABLE [dbo].[tblGifts](
	[sl] [int] NOT NULL,
	[date] [datetime] NULL,
	[bookingid] [int] NULL,
	[gift_amount] [decimal](18, 2) NULL,
	[gift_type] [varchar](50) NULL,
	[userid] [int] NULL,
 CONSTRAINT [PK_tblGifts] PRIMARY KEY CLUSTERED 
(
	[sl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblBookingPayments ADD
	TOTAIL_PAID decimal(18, 2) NULL
GO
ALTER TABLE dbo.tblBookingPayments SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

