CREATE TABLE [User] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, 	
	[Name] nvarchar(254), --姓名	
	[IDCard] nvarchar(254), --证件号
	[Gender] nvarchar(254), --性别
	[BirthDate] date, --出生日期	
	[Nationality] nvarchar(254), --民族
	[PoliticalAffiliation] nvarchar(254), --政治面貌	
	[Address] nvarchar(254), --通讯地址
	[PhoneNumber] nvarchar(254), --联系电话
	[PostalCode] nvarchar(254), --邮政编码	
	[Email] nvarchar(254), --电子邮件	
	[IsDelete] integer
)


CREATE TABLE [UserExt] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT
	[UserID] integer,
	[Class] nvarchar(254), --班级
	[StudentCharacteristics] nvarchar(254), --考生特征 
	[ExaminationCardNumber] nvarchar(254), --准考证号
	[FatherName] nvarchar(254), --父亲姓名
	[FatherIDCard] nvarchar(254), --父亲身份证号
	[FatherNationality] nvarchar(254), --父亲族别
	[FatherHouseholdType] nvarchar(254), --父亲户口性质
	[FatherPhoneNumber] nvarchar(254), --父亲联系电话
	[FatherOccupation] nvarchar(254), --父亲工作单位
	[MotherName] nvarchar(254), --母亲姓名
	[MatherIDCard] nvarchar(254), --母亲身份证号
	[MotherNationality] nvarchar(254), --母亲族别
	[MotherHouseholdType] nvarchar(254), --母亲户口性质
	[MotherPhoneNumber] nvarchar(254), --母亲联系电话
	[MotherOccupation] nvarchar(254), --母亲工作单位
	[AdmissionProvince] nvarchar(254), --录取省市
	[AdmissionSchool] nvarchar(254), --录取学校
	[RegistrationState] nvarchar(254), --报名地州
	[RegistrationCity] nvarchar(254), --报名县市
	[RegistrationSchool] nvarchar(254), --报名学校 
	[HouseholdState] nvarchar(254), --报名户口地州
	[StudentState] nvarchar(254), --实际生源地州
	[Chinese] float, --语文成绩
	[PhysicsOrChemistry] float, --物理、化学成绩
	[Mathematics] float, --数学成绩
	[PoliticsOrHistory] float, --道德与法治、历史成绩
	[ForeignLanguage] float, --外语成绩
	[Total] float, --总成绩（不加体育）
	[PE] nvarchar(254), --体育是否合格，Y：合格，N：不合格
	[StudentStatusCode] nvarchar(254), --学籍号
	[StudentSource] nvarchar(254), --生源
	[HouseholdType] nvarchar(254) --户口性质
)

CREATE TABLE [Department] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, 
	[Name] nvarchar(254)
)

CREATE TABLE [Login] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, 
	[UserID] integer,
	[Password] nvarchar(254),
	[LastLoginTime] datetime,
	[LastLoginIP] nvarchar(254)
	
)


CREATE TABLE [Module](
	[ID] integer not null primary key autoincrement,
	[Name] nvarchar(254),
	[Url] nvarchar(254),
	[HotKey] nvarchar(254),
	[ParentID] integer,
	[IsAutoExpand] integer,
	[IconName] nvarchar(254),
	[Status] integer,
	[ParentName] nvarchar(254),
	[SortNo] integer
)


CREATE TABLE [Operation](
	[ID] integer not null primary key autoincrement,
	[Name] nvarchar(254),
	[ModuleID] integer,
	[Url] nvarchar(254),
	[HotKey] nvarchar(254),
	[IconName] nvarchar(254),
	[Status] integer,
	[SortNo] integer
)


CREATE TABLE [Role](
	[ID] integer not null primary key autoincrement,
	[Name] nvarchar(254),
	[Status] nvarchar(254)
)


CREATE TABLE [UserRole](
	[ID] integer not null primary key autoincrement,
	[UserID] integer,
	[RoleID] integer
)


CREATE TABLE [UserDepartment](
	[ID] integer not null primary key autoincrement,
	[UserID] integer,
	[DepartmentID] integer
)


CREATE TABLE [RoleModule](
	[ID] integer not null primary key autoincrement,
	[RoleID] integer,
	[ModuleID] integer
)


CREATE TABLE [RoleOperation](
	[ID] integer not null primary key autoincrement,
	[RoleID] integer,
	[OperationID] integer
)















CREATE TABLE [studentclass] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, 
	[StudentID] int,
	[ClassID] int
)

CREATE TABLE [enrollment] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT
	
)

CREATE TABLE [Class] (
	[ID] integer NOT NULL PRIMARY KEY AUTOINCREMENT, 
	[Name] nvarchar(254),
	[ClassType] nvarchar(254),
	[TeacherID] int --班主任
	
)