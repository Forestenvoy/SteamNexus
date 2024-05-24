USE [SteamNexus]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (10000, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (10001, N'Member')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [RoleId], [Email], [Password], [Name], [Gender], [Phone], [Birthday], [Photo]) VALUES (10103, 10000, N'dss2345593@gmail.com', N'9kVh4Ew76c6mJxr80rMk9LhlTtGwEfTxX/RDbgEA1aA=', N'郭炯德', 1, NULL, CAST(N'1999-02-02T00:00:00.0000000' AS DateTime2), N'default.jpg')
INSERT [dbo].[Users] ([UserId], [RoleId], [Email], [Password], [Name], [Gender], [Phone], [Birthday], [Photo]) VALUES (10104, 10000, N'dee18893828@gmail.com', N'n6WYLv8/gGU+ITNZ6AGvkKqLcFwjis4m85ERYdOgIhc=', N'王俊婕', 0, NULL, NULL, N'default.jpg')
INSERT [dbo].[Users] ([UserId], [RoleId], [Email], [Password], [Name], [Gender], [Phone], [Birthday], [Photo]) VALUES (10105, 10000, N'abc2345593@gmail.coom', N'URUhccfpcrLvYqBKkOLHr333nhqDvjCfNDA3rZE9Arw=', N'王薪評', 1, NULL, NULL, N'default.jpg')
INSERT [dbo].[Users] ([UserId], [RoleId], [Email], [Password], [Name], [Gender], [Phone], [Birthday], [Photo]) VALUES (10106, 10000, N'sr18893828@gmail.com', N'+UPAVMUMPKN/tpqEyB7/7JBTe6XPnhW2/ByiL96yohc=', N'李憶承', 1, N'0919385752', CAST(N'1988-12-24T00:00:00.0000000' AS DateTime2), N'c09df1bb-1448-470e-893c-8e6899f705fa.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
