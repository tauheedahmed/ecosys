USE [EPS]
GO
/****** Object:  View [dbo].[vTemplatesStaffing]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vTemplatesStaffing]
AS
SELECT dbo.Organizations.ParentOrg, dbo.Organizations.IdMap, dbo.Staffing.OrgId, Organizations_1.Id
FROM  dbo.Organizations INNER JOIN
               dbo.Organizations Organizations_1 ON dbo.Organizations.IdMap = Organizations_1.Id INNER JOIN
               dbo.Staffing ON Organizations_1.Id = dbo.Staffing.OrgId
WHERE (dbo.Organizations.ParentOrg = 455)
GO
/****** Object:  View [dbo].[vPeople]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vPeople]
AS
SELECT dbo.People.Id, dbo.People.FName, dbo.People.LName, dbo.People.OrgId, dbo.People.WorkPhone, dbo.People.HomePhone, dbo.People.CellPhone, 
               dbo.People.Email, dbo.People.UPI, dbo.People.Address, dbo.Organizations.LicenseId, dbo.Licenses.DomainId
FROM  dbo.People INNER JOIN
               dbo.Organizations ON dbo.People.OrgId = dbo.Organizations.Id INNER JOIN
               dbo.Licenses ON dbo.Organizations.LicenseId = dbo.Licenses.Id
GO
/****** Object:  View [dbo].[vLicenseOrg]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLicenseOrg]
AS
SELECT dbo.Organizations.Name, dbo.Organizations.Id, dbo.Licenses.LicenseDate, dbo.Licenses.LicensePeriodDays, dbo.Organizations.Description, 
               dbo.Organizations.OrgType, dbo.Organizations.LicenseId, dbo.Licenses.LicenseStatus, dbo.Licenses.AccessLevel, dbo.UserIds.UserId, 
               dbo.UserIds.Password, dbo.UserIds.CreationDate, dbo.UserIds.Status, dbo.UserIds.PasswordUpdate, dbo.Licenses.DomainId, 
               dbo.Organizations.Email, dbo.Organizations.ParentOrg, ParentOrg.Name AS OrgNameP, dbo.UserIds.Type AS UserTypeId, 
               dbo.UserIds.Id AS UserIdId, dbo.UserTypes.StartForm, dbo.Licenses.Visibility AS LicVis, dbo.Organizations.Visibility AS OrgVis
FROM  dbo.Organizations INNER JOIN
               dbo.Licenses ON dbo.Organizations.LicenseId = dbo.Licenses.Id INNER JOIN
               dbo.UserIds ON dbo.Organizations.Id = dbo.UserIds.OrgId INNER JOIN
               dbo.Organizations ParentOrg ON dbo.Organizations.ParentOrg = ParentOrg.Id INNER JOIN
               dbo.UserTypes ON dbo.UserIds.Type = dbo.UserTypes.Id
GO
/****** Object:  View [dbo].[tt]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tt]
AS
SELECT TOP 100 PERCENT dbo.Timetables.Id, dbo.PSEPSteps.Seq, dbo.PSEPSteps.Id AS StepId, dbo.PSEPSteps.Name, dbo.Timetables.CompletionDate, 
               dbo.Timetables.Status, dbo.PSEPSteps.ProcsId, dbo.Timetables.PSEPStepsId, dbo.Timetables.OrgLocId, dbo.Timetables.PSEPID
FROM  dbo.Projects INNER JOIN
               dbo.ProfileServiceEvents ON dbo.Projects.PSEventsId = dbo.ProfileServiceEvents.Id INNER JOIN
               dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId INNER JOIN
               dbo.Procs ON dbo.ProfileSEProcs.ProcsId = dbo.Procs.Id INNER JOIN
               dbo.OrgLocations ON dbo.Projects.OrgLocId = dbo.OrgLocations.Id INNER JOIN
               dbo.Organizations ON dbo.OrgLocations.OrgId = dbo.Organizations.Id INNER JOIN
               dbo.Profiles ON dbo.Organizations.ProfileId = dbo.Profiles.Id INNER JOIN
               dbo.PSEPSteps ON dbo.PSEPSteps.ProcsId = dbo.Procs.Id LEFT OUTER JOIN
               dbo.Timetables ON dbo.Timetables.ProjectId = dbo.Projects.Id AND dbo.ProfileSEProcs.Id = dbo.Timetables.PSEPID
WHERE (dbo.Timetables.Id IS NOT NULL) OR
               (dbo.Timetables.OrgLocId IS NULL) AND (dbo.ProfileSEProcs.Id = 203) AND (dbo.Projects.Id = 26)
ORDER BY dbo.PSEPSteps.Seq
GO
/****** Object:  View [dbo].[QProcProcures]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[QProcProcures]
AS
SELECT     dbo.Organizations.Name AS Org, dbo.Locations.Name AS Loc, dbo.Procs.Name, dbo.ProcProcures.SGFlag, dbo.ProcProcures.ContractId, 
                      dbo.People.FName, dbo.People.LName, dbo.ProcProcures.ReqAmount, dbo.ProcProcures.BudAmount, dbo.ProcProcures.Qty, 
                      dbo.ProcProcures.TimeMeasure
FROM         dbo.ProcProcures INNER JOIN
                      dbo.OrgLocations ON dbo.ProcProcures.OrgLocId = dbo.OrgLocations.Id INNER JOIN
                      dbo.Locations ON dbo.OrgLocations.LocId = dbo.Locations.Id INNER JOIN
                      dbo.Organizations ON dbo.OrgLocations.OrgId = dbo.Organizations.Id INNER JOIN
                      dbo.PSEPStaff ON dbo.ProcProcures.PSEPSID = dbo.PSEPStaff.Id INNER JOIN
                      dbo.Procs ON dbo.PSEPStaff.ProcsId = dbo.Procs.Id INNER JOIN
                      dbo.StaffActions ON dbo.ProcProcures.ContractId = dbo.StaffActions.Id INNER JOIN
                      dbo.People ON dbo.StaffActions.PeopleId = dbo.People.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[72] 4[4] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProcProcures"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 232
               Right = 314
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "OrgLocations"
            Begin Extent = 
               Top = 6
               Left = 352
               Bottom = 106
               Right = 504
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organizations"
            Begin Extent = 
               Top = 6
               Left = 542
               Bottom = 121
               Right = 695
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Locations"
            Begin Extent = 
               Top = 6
               Left = 733
               Bottom = 121
               Right = 885
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PSEPStaff"
            Begin Extent = 
               Top = 108
               Left = 352
               Bottom = 223
               Right = 504
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Procs"
            Begin Extent = 
               Top = 126
               Left = 542
               Bottom = 241
               Right = 697
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StaffActions"
            Begin Extent = 
               Top = 126
               Left = 735
               Bottom = 241
               Right = 887
            End
           ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'QProcProcures'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 228
               Left = 352
               Bottom = 343
               Right = 504
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 2235
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'QProcProcures'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'QProcProcures'
GO
/****** Object:  View [dbo].[rptTORsV]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptTORsV]
AS
SELECT DISTINCT 
               dbo.PSEPStaff.Id AS PSEPSId, dbo.Organizations.Id AS OrgId, dbo.Organizations.Name AS OrgName, dbo.Roles.Name AS RolesName, 
               dbo.Roles.Id AS RolesId, dbo.PSEPStaff.Description AS StaffD, dbo.Procs.Id AS ProcsId, dbo.Procs.Name AS ProcsName, dbo.Roles.Seq
FROM  dbo.ProfileServiceTypes INNER JOIN
               dbo.Organizations INNER JOIN
               dbo.OrgServiceTypes ON dbo.Organizations.Id = dbo.OrgServiceTypes.OrgId ON 
               dbo.ProfileServiceTypes.Id = dbo.OrgServiceTypes.PSTId INNER JOIN
               dbo.ProfileServiceEvents ON dbo.ProfileServiceTypes.Id = dbo.ProfileServiceEvents.ProfileServicesId INNER JOIN
               dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId INNER JOIN
               dbo.Procs ON dbo.ProfileSEProcs.ProcsId = dbo.Procs.Id INNER JOIN
               dbo.PSEPStaff ON dbo.Procs.Id = dbo.PSEPStaff.ProcsId INNER JOIN
               dbo.Roles ON dbo.PSEPStaff.RolesId = dbo.Roles.Id
GO
/****** Object:  View [dbo].[rptProfTORs]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptProfTORs]
AS
SELECT DISTINCT 
                      dbo.PSEPStaff.Id AS PSEPSId, dbo.Profiles.Id AS ProfilesId, dbo.Profiles.Name AS ProfilesName, dbo.Roles.Name AS RolesName, 
                      dbo.Roles.Id AS RolesId, dbo.PSEPStaff.Description AS StaffD, dbo.Procs.Id AS ProcsId, dbo.Procs.Name AS ProcsName, dbo.Roles.Seq
FROM         dbo.ProfileServiceTypes INNER JOIN
                      dbo.Profiles ON dbo.ProfileServiceTypes.ProfilesId = dbo.Profiles.Id INNER JOIN
                      dbo.ProfileServiceEvents ON dbo.ProfileServiceTypes.Id = dbo.ProfileServiceEvents.ProfileServicesId INNER JOIN
                      dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId INNER JOIN
                      dbo.Procs ON dbo.ProfileSEProcs.ProcsId = dbo.Procs.Id INNER JOIN
                      dbo.PSEPStaff ON dbo.Procs.Id = dbo.PSEPStaff.ProcsId INNER JOIN
                      dbo.Roles ON dbo.PSEPStaff.RolesId = dbo.Roles.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProfileServiceTypes"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Profiles"
            Begin Extent = 
               Top = 6
               Left = 231
               Bottom = 121
               Right = 383
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileServiceEvents"
            Begin Extent = 
               Top = 6
               Left = 421
               Bottom = 121
               Right = 582
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileSEProcs"
            Begin Extent = 
               Top = 6
               Left = 620
               Bottom = 121
               Right = 835
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Procs"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PSEPStaff"
            Begin Extent = 
               Top = 126
               Left = 231
               Bottom = 241
               Right = 383
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Roles"
            Begin Extent = 
               Top = 126
               Left = 421
               Bottom = 241
               Right = 573
            End
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptProfTORs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptProfTORs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptProfTORs'
GO
/****** Object:  View [dbo].[rptProfServiceProcs]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptProfServiceProcs]
AS
SELECT     TOP 100 PERCENT MAX(dbo.Profiles.Id) AS ProfileId, MAX(dbo.Profiles.Name) AS ProfileName, MAX(dbo.Functions.Seq) AS FunctionSeq, 
                      MAX(dbo.Procs.Id) AS ProcsId, MAX(dbo.Procs.Name) AS ProcsName, MAX(dbo.PSEPSteps.Id) AS StepsId, MAX(dbo.PSEPSteps.Name) AS StepsName, 
                      MAX(dbo.PSEPSteps.Seq) AS StepsSeq, MAX(dbo.Functions.Id) AS FunctionsId, MAX(dbo.Functions.Name) AS FunctionsName, 
                      MAX(dbo.ServiceTypes.Id) AS ServicesId, MAX(dbo.ServiceTypes.Name) AS ServicesName, MAX(dbo.Functions.Seq) AS FunctionsSeq, 
                      MAX(dbo.ServiceTypes.Seq) AS STSeq, MAX(dbo.PSEPSteps.Description) AS StepsD, MAX(dbo.Procs.Description) AS ProcsD, 
                      MAX(dbo.Functions.description) AS FunctionsD, MAX(dbo.ServiceTypes.Description) AS ServicesD
FROM         dbo.ProfileServiceTypes INNER JOIN
                      dbo.ProfileServiceEvents ON dbo.ProfileServiceEvents.ProfileServicesId = dbo.ProfileServiceTypes.Id INNER JOIN
                      dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId INNER JOIN
                      dbo.Procs ON dbo.ProfileSEProcs.ProcsId = dbo.Procs.Id INNER JOIN
                      dbo.PSEPSteps ON dbo.Procs.Id = dbo.PSEPSteps.ProcsId INNER JOIN
                      dbo.ServiceTypes ON dbo.ProfileServiceTypes.ServiceTypesId = dbo.ServiceTypes.Id INNER JOIN
                      dbo.Functions ON dbo.Functions.Id = dbo.ServiceTypes.TypeId INNER JOIN
                      dbo.Profiles ON dbo.ProfileServiceTypes.ProfilesId = dbo.Profiles.Id
GROUP BY dbo.Profiles.Id, dbo.Functions.Id, dbo.ServiceTypes.Id, dbo.Procs.Id, dbo.PSEPSteps.Id
ORDER BY FunctionSeq, STSeq, ProcsName
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[9] 4[1] 2[83] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProfileServiceTypes"
            Begin Extent = 
               Top = 0
               Left = 435
               Bottom = 115
               Right = 606
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileServiceEvents"
            Begin Extent = 
               Top = 6
               Left = 247
               Bottom = 121
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileSEProcs"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Procs"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 361
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PSEPSteps"
            Begin Extent = 
               Top = 246
               Left = 247
               Bottom = 361
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServiceTypes"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 481
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Functions"
            Begin Extent = 
               Top = 126
               Left = 307
               Bottom = 241
               Right = 475
           ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptProfServiceProcs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Profiles"
            Begin Extent = 
               Top = 153
               Left = 640
               Bottom = 268
               Right = 808
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptProfServiceProcs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptProfServiceProcs'
GO
/****** Object:  View [dbo].[rptProcsV]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptProcsV]
AS
SELECT TOP 100 PERCENT MAX(dbo.Organizations.Id) AS OrigId, MAX(dbo.Organizations.Name) AS OrgName, MAX(dbo.Organizations.ProfileId) AS ProfileId, 
               MAX(dbo.Procs.Id) AS ProcsId, MAX(dbo.Procs.Name) AS ProcsName, MAX(dbo.PSEPSteps.Id) AS StepsId, MAX(dbo.PSEPSteps.Name) 
               AS StepsName, MAX(dbo.PSEPSteps.Seq) AS StepsSeq, MAX(dbo.Functions.Id) AS FunctionsId, MAX(dbo.Functions.Name) AS FunctionsName, 
               MAX(dbo.ServiceTypes.Id) AS ServicesId, MAX(dbo.ServiceTypes.Name) AS ServicesName, MAX(dbo.Functions.Seq) AS FunctionsSeq, 
               MAX(dbo.ServiceTypes.Seq) AS STSeq, MAX(dbo.PSEPSteps.Description) AS StepsD, MAX(dbo.Procs.Description) AS ProcsD, 
               MAX(dbo.Functions.description) AS FunctionsD, MAX(dbo.ServiceTypes.Description) AS ServicesD
FROM  dbo.Functions INNER JOIN
               dbo.ServiceTypes ON dbo.Functions.Id = dbo.ServiceTypes.TypeId INNER JOIN
               dbo.Organizations INNER JOIN
               dbo.OrgServiceTypes ON dbo.Organizations.Id = dbo.OrgServiceTypes.OrgId INNER JOIN
               dbo.ProfileServiceTypes ON dbo.OrgServiceTypes.PSTId = dbo.ProfileServiceTypes.Id AND 
               dbo.Organizations.ProfileId = dbo.ProfileServiceTypes.ProfilesId INNER JOIN
               dbo.ProfileServiceEvents INNER JOIN
               dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId ON 
               dbo.ProfileServiceTypes.Id = dbo.ProfileServiceEvents.ProfileServicesId INNER JOIN
               dbo.Procs ON dbo.ProfileSEProcs.ProcsId = dbo.Procs.Id INNER JOIN
               dbo.PSEPSteps ON dbo.Procs.Id = dbo.PSEPSteps.ProcsId ON dbo.ServiceTypes.Id = dbo.Procs.ServiceTypesId
GROUP BY dbo.Functions.Id, dbo.ServiceTypes.Id, dbo.Procs.Id, dbo.PSEPSteps.Id, dbo.Organizations.Id
ORDER BY MAX(dbo.Functions.Seq), MAX(dbo.ServiceTypes.Seq), MAX(dbo.Procs.Name)
GO
/****** Object:  View [dbo].[rptProcsIndV]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptProcsIndV]
AS
SELECT DISTINCT 
               dbo.Procs.Id, dbo.Organizations.Id AS OrigId, dbo.Organizations.Name AS OrgName, dbo.Organizations.ProfileId, dbo.Procs.Id AS ProcsId, 
               dbo.PSEPSteps.Seq AS StepsSeq, 'Task ' + CAST(dbo.ProfileSEProcs.Seq AS nvarchar(3)) + '. ' + dbo.Procs.Name AS ProcsName, 
               dbo.PSEPSteps.Id AS StepsId, 'Step ' + CAST(dbo.PSEPSteps.Seq AS nvarchar(3)) + '. ' + dbo.PSEPSteps.Name AS StepsName, 
               dbo.Functions.Id AS FunctionsId, dbo.Functions.Name AS FunctionsName, dbo.ServiceTypes.Id AS ServicesId, 
               dbo.ServiceTypes.Name AS ServicesName, dbo.Functions.Seq AS FunctionsSeq, dbo.ServiceTypes.Seq AS STSeq, 
               dbo.PSEPSteps.Description AS StepsD, dbo.Procs.Description AS ProcsD, dbo.Functions.description AS FunctionsD, 
               dbo.ServiceTypes.Description AS ServicesD, dbo.Events.Description AS EventsD, dbo.Events.Name AS EventsName, 
               dbo.ProfileServiceEvents.Id AS PSEId, CAST(dbo.ProfileSEProcs.Seq AS nvarchar(3)) AS Seqstr
FROM  dbo.Functions RIGHT OUTER JOIN
               dbo.ServiceTypes ON dbo.Functions.Id = dbo.ServiceTypes.TypeId RIGHT OUTER JOIN
               dbo.Procs ON dbo.ServiceTypes.Id = dbo.Procs.ServiceTypesId RIGHT OUTER JOIN
               dbo.Events INNER JOIN
               dbo.ProfileServiceTypes INNER JOIN
               dbo.ProfileServiceEvents INNER JOIN
               dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId ON 
               dbo.ProfileServiceTypes.Id = dbo.ProfileServiceEvents.ProfileServicesId ON dbo.Events.Id = dbo.ProfileServiceEvents.EventsId INNER JOIN
               dbo.Organizations ON dbo.ProfileServiceTypes.ProfilesId = dbo.Organizations.ProfileId INNER JOIN
               dbo.OrgServiceTypes ON dbo.Organizations.Id = dbo.OrgServiceTypes.OrgId AND dbo.ProfileServiceTypes.Id = dbo.OrgServiceTypes.PSTId ON 
               dbo.Procs.Id = dbo.ProfileSEProcs.ProcsId LEFT OUTER JOIN
               dbo.PSEPSteps ON dbo.Procs.Id = dbo.PSEPSteps.ProcsId
GO
/****** Object:  View [dbo].[rptBudR3b]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptBudR3b]
AS
SELECT     dbo.PSEPResInventory.ContractsId, dbo.PSEPResInventory.PSEPResId, dbo.PSEPResInventory.Qty, dbo.PSEPResInventory.Price, 
                      dbo.PSEPResInventory.OrgId, dbo.PSEPResInventory.LocationsId, dbo.PSEPResInventory.ServiceTypesId, dbo.PSEPResInventory.InventoryId, 
                      dbo.PSEPResInventory.ProjectId, dbo.Contracts.CommitmentDate, dbo.Contracts.StatusId, dbo.PSEPResInventory.Id, 
                      dbo.PSEPResInventory.FundsId
FROM         dbo.Contracts INNER JOIN
                      dbo.PSEPResInventory ON dbo.Contracts.Id = dbo.PSEPResInventory.ContractsId
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[10] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Contracts"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 392
               Right = 202
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PSEPResInventory"
            Begin Extent = 
               Top = 3
               Left = 444
               Bottom = 373
               Right = 599
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptBudR3b'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptBudR3b'
GO
/****** Object:  View [dbo].[rptBudR3a]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[rptBudR3a]
AS
SELECT     MAX(dbo.SARevisions.Salary) AS Salary, MAX(dbo.SARevisions.TimePerCent) AS TimePerCent, MAX(dbo.StaffActions.StartDate) AS SAStartDate, 
                      MAX(dbo.StaffActions.EndDate) AS SAEndDate, MAX(dbo.SARevisions.StartDate) AS SRStartDate, MAX(dbo.SARevisions.EndDate) AS SREndDate, 
                      MAX(dbo.StaffActions.FundsId) AS SAFundsId, MAX(dbo.StaffActions.OrgId) AS SAOrgId, MAX(dbo.StaffActions.Id) AS SAId, MAX(dbo.StaffActions.TypeId) 
                      AS Expr1, MAX(dbo.OrgStaffTypes.SalaryPeriod) AS SalaryPeriod, MAX(dbo.OrgStaffTypes.CurrId) AS CurrId
FROM         dbo.Organizations INNER JOIN
                      dbo.Funds ON dbo.Funds.OrgId = dbo.Organizations.Id LEFT OUTER JOIN
                      dbo.StaffActions ON dbo.StaffActions.OrgId = dbo.Organizations.Id LEFT OUTER JOIN
                      dbo.OrgStaffTypes ON dbo.Organizations.Id = dbo.OrgStaffTypes.OrgId AND dbo.StaffActions.TypeId = dbo.OrgStaffTypes.Id LEFT OUTER JOIN
                      dbo.SARevisions ON dbo.SARevisions.StaffActionsId = dbo.StaffActions.Id
GROUP BY dbo.Organizations.Id, dbo.Funds.Id, dbo.StaffActions.Id, dbo.SARevisions.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[78] 4[4] 2[2] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[32] 4[51] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[52] 2[20] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1[30] 4) )"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[92] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Organizations"
            Begin Extent = 
               Top = 0
               Left = 179
               Bottom = 215
               Right = 332
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Funds"
            Begin Extent = 
               Top = 278
               Left = 354
               Bottom = 459
               Right = 522
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrgStaffTypes"
            Begin Extent = 
               Top = 89
               Left = 458
               Bottom = 316
               Right = 626
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StaffActions"
            Begin Extent = 
               Top = 3
               Left = 701
               Bottom = 404
               Right = 853
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "SARevisions"
            Begin Extent = 
               Top = 389
               Left = 568
               Bottom = 504
               Right = 720
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 28
         Width = 284
         Width = 1245
         Width = 1140
         Width = 1215
         Width = 1230
         Width = 1230
         Width = 1170
         Width = 795
         Width = 1500
         Width = 1200
         Width = 1095
         Width = 1500
         Width = 1500
         Width = 1500' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptBudR3a'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 2235
         Table = 2760
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptBudR3a'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'rptBudR3a'
GO
/****** Object:  View [dbo].[HouseholdEP]    Script Date: 02/21/2014 15:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HouseholdEP]
AS
SELECT     TOP (100) PERCENT dbo.Profiles.Name AS ProfileName, dbo.Profiles.Id AS ProfileId, dbo.ProfileServiceTypes.Id AS PSTypesId, 
                      dbo.ServiceTypes.Name AS ServiceTypesName, dbo.ProfileServiceEvents.Id AS PSEId, dbo.ProfileSEProcs.Id AS PSEPId, 
                      dbo.LocTypes.Id AS LocTypesId, dbo.LocTypes.Name AS LocTypesName, dbo.ResourceTypes.Id AS ResId, dbo.ResourceTypes.Name AS ResName, 
                      dbo.PSEPRes.Description, dbo.PSEPRes.ProcsId, dbo.Procs.PSEPId AS Expr1
FROM         dbo.ResourceTypes INNER JOIN
                      dbo.PSEPRes ON dbo.ResourceTypes.Id = dbo.PSEPRes.ResTypesId INNER JOIN
                      dbo.Procs ON dbo.PSEPRes.ProcsId = dbo.Procs.Id INNER JOIN
                      dbo.LocTypes INNER JOIN
                      dbo.Profiles INNER JOIN
                      dbo.ProfileServiceTypes ON dbo.Profiles.Id = dbo.ProfileServiceTypes.ProfilesId INNER JOIN
                      dbo.ServiceTypes ON dbo.ProfileServiceTypes.ServiceTypesId = dbo.ServiceTypes.Id INNER JOIN
                      dbo.ProfileServiceEvents ON dbo.ProfileServiceTypes.Id = dbo.ProfileServiceEvents.ProfileServicesId INNER JOIN
                      dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId ON dbo.LocTypes.Id = dbo.ProfileSEProcs.LocTypesId ON 
                      dbo.Procs.Id = dbo.ProfileSEProcs.ProcsId
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[86] 4[4] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ResourceTypes"
            Begin Extent = 
               Top = 31
               Left = 8
               Bottom = 146
               Right = 163
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PSEPRes"
            Begin Extent = 
               Top = 166
               Left = 251
               Bottom = 281
               Right = 403
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Procs"
            Begin Extent = 
               Top = 194
               Left = 14
               Bottom = 309
               Right = 169
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LocTypes"
            Begin Extent = 
               Top = 383
               Left = 623
               Bottom = 498
               Right = 775
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Profiles"
            Begin Extent = 
               Top = 16
               Left = 766
               Bottom = 203
               Right = 907
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileServiceTypes"
            Begin Extent = 
               Top = 16
               Left = 515
               Bottom = 168
               Right = 733
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServiceTypes"
            Begin Extent = 
               Top = 222
               Left = 606
               Bottom = 366
               Right = 873
            End
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'HouseholdEP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileServiceEvents"
            Begin Extent = 
               Top = 12
               Left = 198
               Bottom = 127
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfileSEProcs"
            Begin Extent = 
               Top = 312
               Left = 364
               Bottom = 483
               Right = 579
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2205
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'HouseholdEP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'HouseholdEP'
GO
/****** Object:  View [dbo].[HHNeedsRes]    Script Date: 02/21/2014 15:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HHNeedsRes]
AS
SELECT TOP 100 PERCENT dbo.Organizations.Id AS OrgId, dbo.Organizations.Name AS OrgName, dbo.Profiles.Name AS ProfileName, 
               dbo.Profiles.Id AS ProfileId, dbo.ProfileServiceTypes.Id AS PSTypesId, dbo.ServiceTypes.Name AS ServiceTypesName, 
               dbo.ProfileServiceEvents.Id AS PSEId, dbo.ProfileSEProcs.Id AS PSEPId, dbo.LocTypes.Id AS LocTypesId, dbo.LocTypes.Name AS LocTypesName, 
               dbo.ResourceTypes.Id AS ResId, dbo.ResourceTypes.Name AS ResName, dbo.PSEPRes.Description, dbo.PSEPRes.ProcsId, 
               dbo.Procs.PSEPId AS Expr1
FROM  dbo.ResourceTypes INNER JOIN
               dbo.PSEPRes ON dbo.ResourceTypes.Id = dbo.PSEPRes.ResTypesId INNER JOIN
               dbo.Procs ON dbo.PSEPRes.ProcsId = dbo.Procs.Id INNER JOIN
               dbo.LocTypes INNER JOIN
               dbo.ProfileOrg INNER JOIN
               dbo.Organizations ON dbo.ProfileOrg.OrgId = dbo.Organizations.Id INNER JOIN
               dbo.Profiles ON dbo.ProfileOrg.ProfileId = dbo.Profiles.Id INNER JOIN
               dbo.ProfileServiceTypes ON dbo.Profiles.Id = dbo.ProfileServiceTypes.ProfilesId INNER JOIN
               dbo.ServiceTypes ON dbo.ProfileServiceTypes.ServiceTypesId = dbo.ServiceTypes.Id INNER JOIN
               dbo.ProfileServiceEvents ON dbo.ProfileServiceTypes.Id = dbo.ProfileServiceEvents.ProfileServicesId INNER JOIN
               dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId ON dbo.LocTypes.Id = dbo.ProfileSEProcs.LocTypesId ON 
               dbo.Procs.Id = dbo.ProfileSEProcs.ProcsId
GO
