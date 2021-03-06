USE [EPS]
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTesting]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTesting]
@StartDate smalldatetime,
@EndDate smalldatetime,
@Status nvarchar (50),
@Results nvarchar (25),
@Comments ntext,
@Id int

AS

UPDATE TestingProgram SET
StartDate=@StartDate,
EndDate=@EndDate,
Status=@Status,
Results=@Results,
Comments=@Comments,
Mode='P'
WHERE (((Id)=@Id));
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskSteps]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskSteps]
@TaskId int,
@StepId int,
@Seq int
AS
Insert into TaskSteps (TaskId, StepId,Seq)
Values (@TaskId, @StepId, @Seq)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTask2]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTask2]
@Name nvarchar(100),
@Status nvarchar(50),
@StartTime datetime=null,
@EndTime datetime=null,
@Id int

AS

UPDATE Tasks 
SET 
Name = @Name,
Status=@Status,
StartTime=@StartTime,
EndTime=@EndTime
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTask]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTask]
@Name nvarchar(100),
@Status nvarchar(50),
@LocId int,
@OrgId int,
@ProfileSEProcsId int,
@Id int

AS

UPDATE Tasks 
SET Name = @Name,Status=@Status,
LocId=@LocId,
ProfileSEProcsId=@ProfileSEProcsId,
OrgId=@OrgId
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskResourceQty]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskResourceQty]
@Id int,
@Qty dec
as
Update TaskResources Set
Qty=@Qty
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskResource]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskResource]
@TaskResId int,
@Id int=0,
@Type nvarchar (12)='na',
@BackupsId int=0
As
if @Id !=0 and @Type = 'Procurement'
Update TaskResources
Set ProcurementsId=@Id,
InventoryId=0
Where Id=@TaskResId

else if @Id !=0 
Update TaskResources
Set InventoryId=@Id,
ProcurementsId=0
Where Id=@TaskResId

else
Update TaskResources
Set BackupsId=@BackupsId
Where Id=@TaskResId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskStaffing]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskStaffing]
@Id int,
@RolesId int,
@BackupsId int,
@PeopleId int
As
Update TaskPeople
Set PeopleId=@PeopleId,
RolesId=@RolesId,
BackupsId=@BackupsId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStaffingTaskC]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateStaffingTaskC]
@Id int,
@Action nvarchar (50)
AS

If @Action = 'Confirm' or (@Action = 'Re-Instate')
Update TaskPeople
Set OrgStatus='Registered'
WHERE Id = @Id

Else if (@Action = 'Cancel') 
Update TaskPeople
Set OrgStatus='Cancelled'
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStaffingTask]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateStaffingTask]
@Id int,
@PeopleId int,
@CallerId int,
@RolesId int,
@Desc text
AS
Update TaskPeople
Set 
PeopleId=@PeopleId,
CallerId=@CallerId,
RolesId=@RolesId,
Description=@Desc

Where TaskPeople.Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskStepsEvents]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskStepsEvents]
@TaskId int,
@StepId int =0,
@Seq int=0,
@EventId int=0,
@Caller nvarchar (50)='na'
AS
if @Caller = 'na'
Insert into TaskSteps (TaskId, StepId, Seq)
Values (@TaskId, @StepId, @Seq)

else if @Caller = 'frmTaskSteps'
Insert into TaskSteps (TaskId, StepId, Seq)
Select @TaskId, StepId, Seq  from EventSteps
inner join Steps on EventSteps.StepId=Steps.Id
Where EventId=@EventId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStep]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateStep]
@Name nvarchar(100),
@Desc ntext,
@Vis int,
@Id int

AS

UPDATE Steps SET Name = @Name, Description =@Desc,
Visibility=@Vis
Where Id=@id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStepResourceTypes]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateStepResourceTypes]
@ResourceId int,
@StepId int
AS
Insert into StepResourceTypes (StepId,ResourceTypeId)
Values (@StepId, @ResourceId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStepResourceType]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateStepResourceType]
@Comments ntext,
@Id int
AS
Update StepResourceTypes 
Set Comments=@Comments
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudCurrERs]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudCurrERs]
@Id int,
@CurrId int,
@ExchangeRate decimal (20,9)
AS
Update  BudgetCurrencies Set
CurrId=@CurrId,
ExchangeRate=@ExchangeRate
Where
Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteBudCurrERs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteBudCurrERs]
@Id int
AS
Delete
FROM BudgetCurrencies
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateBOLocs]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateBOLocs]
@BOId int,
@LocId int
as
Insert into BOLocs  (BOId, LocId)
Values (@BOId, @LocId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateUnregister]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateUnregister] 
@Id int
AS 
Update ActPeople
Set PeopleStatus = 'UnRegister',
PeopleStatusTime = GetDate()
Where  Id=@Id and PeopleStatus != 'UnRegister'
GO
/****** Object:  StoredProcedure [dbo].[eps_AddServiceProviders]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_AddServiceProviders]
@OrgId int=0,
@ResTypeId int=0
AS

Insert into ServiceProviders (OrgId, ResTypeId)
Values (@OrgId, @ResTypeId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddCourse]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddCourse]
@Name nvarchar(50),
@Desc ntext,
@OrgId int
AS
Insert into Courses
(Name, Description, OrgId)
values
(@Name, @Desc,@OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddTesting]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/* Not linked to any webform*/

CREATE PROCEDURE [dbo].[eps_AddTesting]
/*@ProcessId int,
@StartDate date,
@EndDate date,
@Status varchar (10),
@Results varchar (10),
@Comments ntext*/

AS
/*
insert into Testing
(Id, ProcessId, StartDate, EndDate, Status, Results, Comments)
values
(ProcessId=@ProcessId, StartDate=@StartDate, EndDate=@EndDate, Status=@Status, Results=@Results, Comments=@Comments)
Go*/
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteAssessOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteAssessOrg]
@OrgId int

AS
DELETE FROM AssessOrg
 WHERE OrgId = @OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteActOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteActOrg]
@OrgId int

AS
DELETE FROM ActOrg
 WHERE OrgId = @OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteCourse]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteCourse]
@Id int

AS
DELETE FROM Courses
 WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteEvents]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteEvents]
@OrgId int

AS
DELETE FROM EventOrgs WHERE OrgId = @OrgId;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProcs]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteProcs]
@Id int

AS
DELETE FROMProcs WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteServiceLoc]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteServiceLoc]
@Id int,
@ServiceId int
As
Delete from ServiceLocs Where LocId=@Id and ServiceId=@ServiceId
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteStepResourceTypes]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteStepResourceTypes]
@StepId int
AS
DELETE From StepResourceTypes
Where Id in 
(Select Id from  StepResourceTypes Where StepId=@StepId)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteStepId]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteStepId]
@Id int

AS
DELETE FROM Steps WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveEventSteps]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveEventSteps]
@EventId int
As
SELECT EventSteps.Id,  EventSteps.Seq, Steps.Name
FROM  EventSteps inner join Steps on EventSteps.StepId=Steps.Id
WHERE EventId=@EventId 
Order by EventSteps.Seq
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteTaskSteps]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteTaskSteps]
@Id int
As
DELETE From TaskSteps
Where TaskSteps.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteTaskResources]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteTaskResources]
@Id int
AS
Delete
FROM  TaskResources
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteTaskPeople]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteTaskPeople]
@Id int,
@Option nvarchar (50)

AS
if @Option = 'Delete'
DELETE FROM TaskPeople
 WHERE Id = @Id

else if @Option = 'Cancel'
Update TaskPeople
Set PeopleStatus = 'Cancellation Requested'
 WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteTaskInputs]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteTaskInputs]
@Id int
AS
Delete
FROM  TaskInputs
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteTask]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteTask]
@Id int

AS
DELETE FROM Tasks WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveActOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveActOrg]
@OrgId int
AS
SELECT ActOrg.Id, ActOrg.ActId, Activities.Activity,  Activities.Description
FROM  dbo.ActOrg  inner join Activities on ActOrg.ActId=Activities.Id
Where ActOrg.OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveInputs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveInputs] 
@Process int
AS

SELECT dbo.vInputs.Id, dbo.vInputs.ProcessId, dbo.vInputs.ResourceId, dbo.vInputs.QuantityNeeded, 
               dbo.vInputs.Name, dbo.vInputs.UnitPrice, dbo.vInputs.QuantityMeasure, dbo.vInputs.Currency
From dbo.vInputs
Where dbo.vInputs.ProcessId=@Process
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProcedures]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProcedures]
@OrgId int
As
SELECT Name, Description, Id
FROM  vProcesses
WHERE (Evnt  <> 'yes') and OrganizationId=@OrgId and (Activity='Business Continuity' or Activity='Crisis Response')
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveServiceInputs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_RetrieveServiceInputs]
@ResourceId int
As
Select 
Id, ResourceOutput,ResourceInput, InputName, Description, Supplier, ResourceDescription
from vResourceInputs
Where ResourceOutput=@ResourceId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveTesting]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveTesting]
@Process int
AS
SELECT vTesting.[Id], vTesting.[ProcessId],
convert (varchar(10), vTesting.StartDate, 101) as StartDate, 
convert (varchar(10), vTesting.EndDate, 101) as EndDate, 
vTesting.[Status], vTesting.[Results], vTesting.[Comments] 
FROM vTesting
Where vTesting.ProcessId=@Process
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateAssessOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateAssessOrg]
@CStatus nvarchar (12),
@PStatus nvarchar (12),
@Desc ntext,
@Id int

AS

UPDATE AssessOrg SET CurrentStatus = @CStatus, PlanStatus=@PStatus, Description=@Desc
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdAssessOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdAssessOrg]
@OrgId int,
@AssessId int
As
Insert into AssessOrg
(AssessId, OrgId)
Values (@AssessId, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdActOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdActOrg]
@OrgId int,
@ActId int
As
Insert into ActOrg
(ActId, OrgId)
Values (@ActId, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdatePeopleStatus]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdatePeopleStatus]
@Status nvarchar (50),
@Id int
AS
Update ActPeople
Set PeopleStatus=@Status,
PeopleStatusTime=GetDate()
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateCourse]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateCourse]
@Name nvarchar(50),
@Desc ntext,
@Id int

AS

UPDATE Courses SET Name = @Name, Description =@Desc
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateEventOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateEventOrg]
@EventId int,
@OrgId int
AS
Insert into EventOrgs (EventId, OrgId)
Values (@EventId, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateServiceLocs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateServiceLocs]
@ServiceId int,
@LocId int
as
Insert into ServiceLocs (ServiceId, LocId)
Values (@ServiceId, @LocId)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteResource]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteResource]
@Id int
AS
Delete
FROM  dbo.Resources
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateResources]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateResources]
@Id int,
@Name nvarchar (500),
@Unit  nvarchar (500),
@Qty int
AS
Update Resources Set Name=@Name
Where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdResExt]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdResExt]
@OrgId int,
@ResourceId int
As
Insert into ResourceOrg
(ResourceId, OrgId)
Values (@ResourceId, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateResourceOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateResourceOrg]
@ResourceId int,
@OrgId int
AS
Insert into ResourceOrg (OrgId,ResourceId)
Values (@OrgId, @ResourceId)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProjContractId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddProjContractId]
@Id int,
@ContractId int
 AS
Update ProjProcures
Set ContractId = @ContractId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProjectStaff]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProjectStaff]
@ProjectId int,
@PSEPSId int,
@OLPSPeopleId int
AS
Insert into ProjectStaffExc (ProjectsId,PSEPSId, OLPSSPeopleId, BackupFlag)
Values
(@ProjectId, @PSEPSId, @OLPSPeopleId, '2')
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProjectProcBud]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdateProjectProcBud]
@Id int=null,
@ProjectsId int=null,
@BudgetsId int=null,
@BudAmt dec (20,2)=null
As

if @Id is null
Insert into ProjectProcBudgets 
(ProjectsId,
BudgetsId,
BudAmt
)
Values
(@ProjectsId,@BudgetsId,@BudAmt)

else

Update ProjectProcBudgets 
Set
BudAmt=@BudAmt
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProjCOrgs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProjCOrgs]
@Id int
AS
Delete
FROM  ProjCOrgs
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProjCOId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddProjCOId]
@ContractsId int,
@OrgLocId int,
@PSEPCID int,
@ProjectId int
 AS
Insert into ProjCOrgs
(ContractsId, OrgLocId, PSEPCID, ProjectId)
Values
(@ContractsId, @OrgLocId, @PSEPCID, @ProjectId)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProfileStepResourceTypes]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProfileStepResourceTypes]
@Id int
AS
DELETE From ProfileStepResourceTypes
Where Id in 
(Select Id from  ProfileStepResourceTypes Where ProfileStepsId=@Id)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileSPResTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileSPResTypes]
@ProfileServiceProcId int=0,
@ResTypeId int =0,
@Id int=0,
@Desc ntext ='na',
@Caller nvarchar (50) ='na'
AS
If @Caller = 'frmProfileSPResTypes'
Update ProfileSPResTypes 
Set Description=@Desc
Where Id=@Id

Else
Insert into ProfileSPResTypes (ProfileServiceProcId, ResTypeId)
Values (@ProfileServiceProcId, @ResTypeId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileServiceLocs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileServiceLocs]
@LocTypeId int=0,
@ProfileServicesId int=0
AS
Insert into ProfileServiceLocs (ProfileServicesId, LocTypeId)
Values (@ProfileServicesId, @LocTypeId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateStepTypesLoc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateStepTypesLoc]
@LocTypesId int,
@Id int

AS

UPDATE ProfileSEPStepTypes 
SET 
LocTypesId=@LocTypesId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileSEPStepTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileSEPStepTypes]
@ProfileSEProcsId int,
@StepTypesId int
As
Insert into ProfileSEPStepTypes (ProfileSEProcsId, StepTypesId)
Values (@ProfileSEProcsId, @StepTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSEPSerDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileSEPSerDesc]
@Id int,
@Desc varchar (200)=null
AS
Update ProfileSEPSer
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileModel]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileModel]
@MapId int,
@ProfileServicesId int,
@EventsId int
As
Insert into ProfileEventTypes(MapId, ProfileServicesId, EventsId)
Values
(@MapId, @ProfileServicesId, @EventsId)
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddProcSARs]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_AddProcSARs]
@OrgLocId int,
@PSEPSId int,
@StaffActionsId int
 AS
Insert into ProcSARs
(OrgLocId, PSEPSId, StaffActionsId)
Values
(@OrgLocId, @PSEPSId, @StaffActionsId)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcSARSA]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateProcSARSA]
@StaffActionsId int,
@Id int
As
Update ProcSARs Set
StaffActionsId=@StaffActionsId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateServiceProcs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateServiceProcs]
@ProcId int=0,
@ResourceTypeId int=0,
@Type nvarchar (50)='Outputs'
AS
Insert into ProcResourceTypes (ProcId, ResourceTypeId, Type)
Values (@ProcId, @ResourceTypeId, @Type)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProcInput]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProcInput]
@ProcId int,
@ResourceTypeId int
AS
Delete from ProcResourceTypes
Where ProcId=@ProcId and ResourceTypeId=@ResourceTypeId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProcessSteps]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProcessSteps]
@ProcessId int,
@ServerProcess int,
@Stage nvarchar (50)
AS
Insert into ProcessSteps (ProcessId, Stage, ServerProcess)
Values (@ProcessId, @Stage, @ServerProcess)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteStep]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteStep]
@Id int

AS
DELETE FROM ProcessSteps WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProcessStep]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProcessStep]
@ProcessId int,
@Stage nvarchar (50)
AS
DELETE FROM ProcessSteps WHERE ProcessId = @ProcessId and  Stage=@Stage and ServerProcess is not null;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProcedures]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProcedures]
@Name nvarchar(80),
@Desc ntext,
@Id int

AS

UPDATE Processes SET Processes.Name = @Name, Processes.Description =@Desc
WHERE (((Processes.Id)=@Id));
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProcsWorkProgram]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProcsWorkProgram]
@OrgId int
AS
Select Id, Name from Processes 
Where OrgId=@OrgId
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteOrgLocSEPSteps]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteOrgLocSEPSteps]
@Id int
 AS

Delete from OrgLocSEPSteps
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOrgLocSEProcs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOrgLocSEProcs]
@Id int
 AS

Delete from OrgLocSEProcs
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOrgLocRoom]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_AddOrgLocRoom]
@OrgLocationsId int,
@Name varchar(50)=null
As
insert into OrgLocRooms (OrgLocationsId, [Name])
Values (@OrgLocationsId, @Name)
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOLPSSPeople]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOLPSSPeople]
@Id int
AS
Delete
FROM  OLPSSPeople
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddOLPSEPSSPeople]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_AddOLPSEPSSPeople]
@OrgLocsId int,
@PSEPSSId int,
@StaffActionsId int
 AS
Insert into OLPSSPeople
(OrgLocationsId, PSEPSSId, StaffActionsId)
Values
(@OrgLocsId, @PSEPSSId, @StaffActionsId)
GO
/****** Object:  StoredProcedure [dbo].[junkwms_RetrievePSResources]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[junkwms_RetrievePSResources]
@ProfileServicesId int,
@RType int
As

SELECT  ProfileServiceResources.Id,
ResourceTypes.Name,
ProfileServiceResources.Description as 'Desc', 
ProfileServiceResources.LocTypesId
From
ProfileServiceResources inner join 
ResourceTypes on ProfileServiceResources.ResourceTypesId=ResourceTypes.Id

WHERE ProfileServiceResources.ProfileServiceTypesId =@ProfileServicesId and
ResourceTypes.Type = @RType
Order by ProfileServiceResources.LocTypesId, ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[junkfms_RetrieveProcSARs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[junkfms_RetrieveProcSARs]
@PSEPSID int,
@PSEPID int,
@OrgLocId int,
@ProjectId int=null
 AS
if (@ProjectId is null)
Select ProcProcures.Id, 
ProcProcures.Description, ProcProcures.ContractId as StaffActionsId,
People.FName + ' ' + People.LName as PeopleName,
'Backup' = 
Case
When ProcProcures.BkupFlag is null then  ''
Else ' (Backup)'
End,
StaffTypes.Name as StaffType, OrgStaffTypes.Id as OSTId
From
ProcProcures inner join
StaffActions  on StaffActions.Id=ProcProcures.ContractId  left outer join
People on StaffActions.PeopleId=People.Id left outer join
OrgStaffTypes on OrgStaffTypes.Id=StaffActions.TypeId left outer join
StaffTypes on StaffTypes.Id=OrgStaffTypes.StaffTypesId
Where 
ContractId is not null and 
ProcProcures.PSEPSID=@PSEPSID and 
ProcProcures.PSEPID=@PSEPID and
ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.SGFlag is null  and
ProjectId=null

Union

Select ProcProcures.Id, 
ProcProcures.Description, null as StaffActionsId,
'New Appointment Request' as PeopleName, 
'Backup' = 
Case
When ProcProcures.BkupFlag is null then  ''
Else ' (Backup)'
End,
null as StaffType,
OrgStaffTypes.Id as OSTId
From
ProcProcures inner join
OrgStaffTypes on  OrgStaffTypes.Id=ProcProcures.TypeId
Where 
ContractId is null and 
ProcProcures.PSEPSID=@PSEPSID and
ProcProcures.PSEPID=@PSEPID and
ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.SGFlag is null  and
ProjectId=null

Order by PeopleName

Else -- i.e. if Project Task
Select ProcProcures.Id, 
ProcProcures.Description, ProcProcures.ContractId as StaffActionsId,
People.FName + ' ' + People.LName as PeopleName,
'Backup' = 
Case
When ProcProcures.BkupFlag is null then  ''
Else ' (Backup)'
End,
StaffTypes.Name as StaffType,  OrgStaffTypes.Id as OSTId
From
ProcProcures inner join
StaffActions  on StaffActions.Id=ProcProcures.ContractId  left outer join
People on StaffActions.PeopleId=People.Id left outer join
OrgStaffTypes on OrgStaffTypes.Id=StaffActions.TypeId left outer join
StaffTypes on StaffTypes.Id=OrgStaffTypes.StaffTypesId
Where
ContractId is not null and 
ProcProcures.PSEPSID=@PSEPSID and 
ProcProcures.PSEPID=@PSEPID and
ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.SGFlag is null and
ProjectId=@ProjectId

Union

Select ProcProcures.Id, 
ProcProcures.Description, null as StaffActionsId,
'Unidentified' as PeopleName, 
'Backup' = 
Case
When ProcProcures.BkupFlag is null then  ''
Else ' (Backup)'
End,
null as StaffType,
OrgStaffTypes.Id as OSTId
From
ProcProcures  inner join
OrgStaffTypes on  OrgStaffTypes.Id=ProcProcures.TypeId
Where
ContractId is null and 
ProcProcures.PSEPSID=@PSEPSID and 
ProcProcures.PSEPID=@PSEPID and
ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.SGFlag is null  and
ProjectId=@ProjectId

Order by PeopleName
GO
/****** Object:  StoredProcedure [dbo].[junkfms_RetreiveContractSupplies]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[junkfms_RetreiveContractSupplies]
@Id int
AS
Select Description, LocationsFlag from ContractSupplies
where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateService]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateService]
@Id int,
@Name nvarchar(100),
@Desc ntext,
@Vis int,
@Type int,
@OrgId int
AS
Update Services
Set Name=@Name, 
Description=@Desc,
Visibility=@Vis,
SupplierOrganization=@OrgId,
Type=@Type
Where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateRoleSkills]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateRoleSkills]
@RoleId int,
@SkillId int
AS

Insert into RoleSkills (RoleId, SkillId )
Values (@RoleId, @SkillId )
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileSPC]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileSPC]
@ProfileServiceProcId int=0,
@ContactTypeId int =0,
@Id int=0,
@Desc ntext ='na',
@Caller nvarchar (50) ='na'
AS
If @Caller = 'frmProfileSPC'
Update ProfileSPC 
Set Description=@Desc
Where Id=@Id

Else
Insert into ProfileSPC (ProfileServiceProcId,ContactTypeId)
Values (@ProfileServiceProcId, @ContactTypeId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileSP]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileSP]
@ProfileServicesId int=0,
@ProfileServiceLocsId int=0,
@ProcessId int,
@ProcType nvarchar(50)=null
AS

if @ProfileServiceLocsId=0
Insert into ProfileServiceProcs (ProfileServicesId,  ProcessId, Type)
Values (@ProfileServicesId,  @ProcessId, @ProcType)

else
Insert into ProfileServiceProcs (ProfileServiceLocsId,  ProcessId, Type)
Values (@ProfileServiceLocsId,  @ProcessId, @ProcType)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateDeadline]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateDeadline]
@Id int,
@Client nvarchar (50),
@Deadline nvarchar (50),
@AccDelay nvarchar (50),
@Value nvarchar (50),
@Impact nvarchar (15),
@Mag nvarchar (15),
@Loc int
AS
Update ResourceOutputDeadlines
Set Client=@Client, Deadline=@Deadline, AcceptableDelay=@AccDelay, ImpactValue=@Value, TypeOfImpact=@Impact, ImpactMagnitude=@Mag, LocationId=@Loc
Where (ResourceOutputDeadlines.Id=@Id);
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileSEPSSer]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileSEPSSer]
@ProfileSEPStepTypesId int,
@ServiceTypesId int
AS
Insert into ProfileSEPSSer ( ProfileSEPStepTypesId, ServiceTypesId)
Values (@ProfileSEPStepTypesId, @ServiceTypesId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfileOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfileOrg]
@ProfileId int,
@OrgId int
AS
Insert into ProfileOrg (ProfileId,OrgId)
Values (@ProfileId, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProfile]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateProfile]
@Name nvarchar (50),
@Desc ntext,
@Vis int,
@PeopleId int,
@AllHH int=null,
@Status int,
@Id int
AS
Update Profiles
Set Name=@Name, 
Description=@Desc,
Visibility=@Vis,
PeopleId=@PeopleId,
Households=@AllHH,
Status=@Status
Where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateProcs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateProcs]
@Name nvarchar(50),
@Vis int,
@Id int

AS

UPDATE Procs SET Name = @Name, Visibility=@Vis
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateContactType]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateContactType]
@Name nvarchar(100),
@Desc ntext,
@Vis int,
@Id int

AS

UPDATE Profiles SET Name = @Name, Description =@Desc, Visibility=@Vis
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateContact]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateContact]
@Id int,
@Name nvarchar (50)='na',
@RegularPhone nvarchar (50)='na',
@CellPhone nvarchar (50)='na',
@Email nvarchar (50)='na',
@Address nvarchar (50)='na',
@Caller nvarchar (50)='frmUpdContact'
AS
if @Caller = 'frmUpdContact'
Update Contacts
Set 
Name=@Name,
RegularPhone=@RegularPhone,
CellPhone=@CellPhone,
Email=@Email,
Address=@Address
Where Id=@Id
else if  @Caller = 'frmContacts'
Update Contacts
Set 
Name=@Name,
RegularPhone=@RegularPhone,
CellPhone=@CellPhone
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateBackups]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateBackups]
@Id int,
@Resource int,
@Backup int,
@Timing nvarchar (50),
@Retention nvarchar (50),
@Scope nvarchar (50)
AS
Update ResourceBackups
Set Resource=@Resource,
BackupResource=@Backup,
Timing=@Timing,
RetentionPeriod=@Retention,
Scope=@Scope
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdatePeopleRoles]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdatePeopleRoles]
@RoleId int,
@PeopleId int
AS
Insert into PeopleRoles (PeopleId,RoleId)
Values (@PeopleId, @RoleId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdatePeople]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdatePeople]
 
@PeopleId int,
@Email nvarchar (50),
@HPhone nvarchar(50),
@CPhone nvarchar(50),
@WPhone nvarchar(50)

AS

Update People
Set
HomePhone=@HPhone, 
WorkPhone=@WPhone, 
CellPhone=@CPhone, 
Email=@Email
Where Id=@PeopleId;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateOrgProfile]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateOrgProfile]
@OrgId int,
@ProfileId int
 AS
Update Organizations Set ProfileId=@ProfileId 
Where Id=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateMenuMsg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateMenuMsg]
@Msg ntext
AS

UPDATE MenuMessage SET Message = @Msg
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateLocTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateLocTypes]
@Name nvarchar(50),
@Desc nvarchar (300),
@Vis int,
@Id int

AS

UPDATE LocTypes SET Name = @Name, Description =@Desc, Visibility=@Vis
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateLocsfromProfiles]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateLocsfromProfiles]
@OrgId int,
@LocId int,
@Name nvarchar (50),
@ServiceId int
AS

Insert into Locations (Name, Id, OrgId)
Values (@Name,@LocId, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateLoc]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateLoc]
@Name nvarchar(100),
@Desc ntext,
@Vis int,
@Id int

AS

UPDATE Locations SET Name = @Name, Description =@Desc, Visibility=@Vis
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateLicUserTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateLicUserTypes]
@LicenseId int,
@UserTypeId int,
@UserTypeMax int
 AS
Insert into LicenseUserTypes 
(LicenseId, UserTypeId, UserTypeMax)
Values (@LicenseId,@UserTypeId, @UserTypeMax)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateLicense]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateLicense]
@LicStatus nvarchar(50),
@LicDate datetime,
@LicenseId int,
@DomainId int,
@Vis int

AS

UPDATE Licenses 
SET 
LicenseStatus=@LicStatus,
LicenseDate=@LicDate,
DomainId=@DomainId,
Visibility=@Vis
Where Id=@LicenseId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateInventory]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateInventory]
@Desc nvarchar (300),
@Id int,
@StatusId int,
@Qty float = null,
@LocId int=0,
@SubLoc nvarchar (50),
@ResTypeId int=0,
@VisId int
AS
Update Inventory
Set
Description=@Desc,  
StatusId=@StatusId,
LocId=@LocId,
ResTypeId=@ResTypeId,
Visibility=@VisId,
Qty=@Qty,
SubLocation=@SubLoc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveUserTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveUserTypes]
AS
Select Id, Name from UserTypes
Where StatusUserTypes is null
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveUsers]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveUsers]
@OrgId int,
@UserTypeId int,
@LicenseId int = 0,
@Id int=0,
@Caller nvarchar (50)='frmMainSec' 
As
if @Id=0
SELECT UserIds.Id, UserIds.OrgId, UserIds.Password, UserIds.PeopleId, Organizations.Name, 
People.FName + ' ' +  People.LName as PersonName,
 UserIds.Type as UserTypeId, UserTypes.Name as UserTypeName, UserIds.Status, UserIds.UserId, Organizations.Email,
ParentOrg
from UserIds inner join Organizations on  UserIds.OrgId = Organizations.Id
inner join UserTypes on UserIds.Type=UserTypes.Id
 left outer join People on UserIds.PeopleId=People.Id
WHERE Organizations.Id=@OrgId and  UserIds.Type=@UserTypeId
Order by ParentOrg, Organizations.Name,UserIds.UserId

else
SELECT Id, OrgId, Password, PeopleId, Status, UserId
from UserIds
WHERE Id=@Id


/*
else if @Caller = 'frmMainHost'
SELECT UserIds.Id, UserIds.OrgId, UserIds.Password, UserIds.PeopleId, Organizations.Name,
 UserIds.Type as UserTypeId, UserTypes.Name as UserTypeName, UserIds.Status, UserIds.UserId, Organizations.Email,
ParentOrg
from UserIds inner join Organizations on  UserIds.OrgId = Organizations.Id
inner join UserTypes on UserIds.Type=UserTypes.Id
 left outer join People on UserIds.PeopleId=People.Id
WHERE Organizations.LicenseId=@OrgId and  UserIds.Type=@UserTypeId
Order by ParentOrg, Organizations.Name,UserIds.UserId*/
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProcSer]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProcSer]
@PSEPID int
As

SELECT 
ProfileSEPSSer.Id, ProfileSEPSSer.ServiceTypesId as ServiceTypesId, 
ServiceTypes.Name as ServiceName,
Events.Name + ' (' + Procs.Name + '): ' + ProfileSEPSSer.Description as Description
From 
ProfileServiceEvents inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileSEPStepTypes on ProfileSEPStepTypes.ProfileSEProcsId=ProfileSEProcs.Id inner join
ProfileSEPSSer on  ProfileSEPSSer.ProfileSEPStepTypesId=ProfileSEPStepTypes.Id inner join
ServiceTypes on ServiceTypes.Id=ProfileSEPSSer.ServiceTypesId inner join
Procs on  ProfileSEProcs.ProcsId=Procs.Id inner join
StepTypes on ProfileSEPStepTypes.StepTypesId=StepTypes.Id
Where ProfileSEPStepTypes.ProfileSEProcsId=@PSEPID
Order by ServiceTypes.Name, ProfileServiceEvents.Id, ProfileSEProcs.Seq, ProfileSEPStepTypes.Seq
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProcResourceTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProcResourceTypes]
@ProcId int=0,
@ResourceTypeId int=0,
@Type nvarchar (50)='Inputs'
As
if @Type='Outputs'
SELECT ProcResourceTypes.Id, ProcId, ResourceTypeId, Processes.Name, ProcResourceTypes.Comments
FROM  ProcResourceTypes inner join ResourceTypes on ProcResourceTypes.ResourceTypeId=ResourceTypes.Id
inner join Processes on ProcResourceTypes.ProcId=Processes.Id
WHERE ResourceTypeId=@ResourceTypeId and ProcResourceTypes.Type=@Type
Order by Processes.Name
Else
SELECT ProcResourceTypes.Id, ProcId, ResourceTypeId, Name, ProcResourceTypes.Comments
FROM  ProcResourceTypes inner join ResourceTypes on ProcResourceTypes.ResourceTypeId=ResourceTypes.Id
WHERE ProcId=@ProcId 
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProcRes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProcRes]
@PSEPID int
As

SELECT 
ProfileSEPSRes.Id, ProfileSEPSRes.ResTypesId as ResTypesId, 
ResourceTypes.Name as ResourceName,
Events.Name + ' (' + Procs.Name + '): ' + ProfileSEPSRes.Description as Description
From 
ProfileServiceEvents inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileSEPStepTypes on ProfileSEPStepTypes.ProfileSEProcsId=ProfileSEProcs.Id inner join
ProfileSEPSRes on  ProfileSEPSRes.ProfileSEPStepTypesId=ProfileSEPStepTypes.Id inner join
ResourceTypes on ResourceTypes.Id=ProfileSEPSRes.ResTypesId inner join
Procs on  ProfileSEProcs.ProcsId=Procs.Id inner join
StepTypes on ProfileSEPStepTypes.StepTypesId=StepTypes.Id
Where ProfileSEPStepTypes.ProfileSEProcsId=@PSEPID
Order by  ResourceTypes.Name, ProfileServiceEvents.Id, ProfileSEProcs.Seq, ProfileSEPStepTypes.Seq
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveStepTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveStepTypes]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As

SELECT StepTypes.Id, StepTypes.Name, StepTypes.Visibility
FROM StepTypes inner join Organizations on StepTypes.OrgId=Organizations.Id inner join Licenses on Organizations.LicenseId=Licenses.Id
WHERE StepTypes.Visibility =1 or StepTypes.OrgId=@OrgId or
StepTypes.Visibility=2 and DomainId=@DomainId or
StepTypes.Visibility=3 and LicenseId=@LicenseId or 
StepTypes.Visibility=4 and ParentOrg=@OrgIdP 
Order by StepTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveSteps]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveSteps]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
SELECT  Steps.Id, Steps.Name, Steps.Description
FROM  Steps inner join
Organizations on Steps.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
WHERE Steps.OrgId=@OrgId or
Steps.Visibility=1 or
Steps.Visibility=2 and DomainId=@DomainId or
Steps.Visibility=3 and LicenseId=@LicenseId or
Steps.Visibility=4 and ParentOrg=@OrgIdP
Order by Steps.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveStepRoles]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_RetrieveStepRoles]
@StepId int
As
SELECT StepRoles.Id, StepId, RoleId, Name
FROM  StepRoles inner join Roles on StepRoles.RoleId=Roles.Id
WHERE StepId=@StepId
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveSkillsAll]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveSkillsAll]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
SELECT Skills.Id, Skills.Name, null as Description
FROM Skills inner join
Organizations on Skills.OrgId = Organizations.Id inner join
Licenses on Licenses.Id=Organizations.LicenseId 
Where (Skills.Visibility=1 or Skills.OrgId=@OrgId or
(Skills.Visibility=2 and Licenses.DomainId=@DomainId) or
(Skills.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Skills.Visibility=4 and Organizations.ParentOrg=@OrgIdP) )
Order by Skills.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveSkills]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveSkills]
@OrgId int

AS
SELECT Skills.Name, Skills.Visibility,Skills.Id
From Skills inner join Organizations on Skills.OrgId=Organizations.Id
Where OrgId=@OrgId
Order by Skills.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveSkillCourses]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveSkillCourses]
@SkillId int
As
Select SkillCourses.Id, SkillCourses.SkillId,Projects.Name, SkillCourses.ProjectId,
Tasks.OrgId, Organizations.Name as ProviderName, Organizations.Id as ProviderId,
LicOrg.Name as ProviderLicName, LicOrg.LicenseId as SupplierLicId, Organizations.Email
From SkillCourses inner join 
Projects on SkillCourses.ProjectId =Projects.Id inner join 
Tasks on Projects.TaskId=Tasks.Id inner join
ProfileSEProcs on Tasks.ProfileSEProcsId=ProfileSEProcs.Id inner join
ProjectTypes on ProfileSEProcs.ProjectTypesId=ProjectTypes.Id inner join
Organizations on Tasks.OrgId = Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id inner join 
Organizations LicOrg on Licenses.OrgId=LicOrg.Id
Where SkillCourses.SkillId=@SkillId and ProjectTypes.Id=3
Order by ProviderName,Projects.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveServiceOrgs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_RetrieveServiceOrgs]
@Service int
 AS

SELECT Organizations.Id,  Organizations.Name, Organizations.Description, Organizations.OrgType,
Phone, Email, Address, PeopleId, Organizations.LocId
FROM Organizations
Where CreatorService=@Service
Order by OrgType, Name
GO
/****** Object:  StoredProcedure [dbo].[eps_retrieveRolesRequired]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_retrieveRolesRequired]
@OrgId int
As
SELECT Distinct Roles.Id,  Roles.Name AS RoleName
FROM  Roles INNER JOIN
               StepRoles ON Roles.Id = StepRoles.RoleId
	INNER JOIN TaskSteps on StepRoles.StepId=TaskSteps.StepId
	inner join Tasks on Tasks.Id=TaskSteps.TaskId
	inner join Resources on Resources.Id=Tasks.ResourceId
Where Resources.SupplierOrganization=@OrgId
Order by RoleName
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveRoleSkills]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveRoleSkills]
@RoleId int
As
Select RoleSkills.Id, RoleSkills.SkillId, Skills.Name
From RoleSkills inner join Skills on RoleSkills.SkillId = Skills.Id
Where RoleSkills.RoleId=@RoleId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveQtyMeasure]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveQtyMeasure]
@ServiceTypesId int
 AS
Select QtyMeasuresId from ServiceTypes
Where Id=@ServiceTypesId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileSProcs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileSProcs]
@ProfileServiceId int=0, -- not zero means called by Profile Type "Producer"
@ProfileServiceLocId int=0, -- not zero means called by Profile Type "Consumer"
@OrgId int=0,
@TaskType nvarchar(50)='na',
@ProcType nvarchar(50)='na'
As
If @OrgId=0 and @ProfileServiceLocId=0-- i.e. the profile for a given service for producers  is being set
SELECT ProfileServiceProcs.Id, 
ProfileServiceProcs.ProcessId, ProfileServiceProcs.Description,
Processes.Name as ProcName
From
ProfileServiceProcs 
inner join Processes on ProfileServiceProcs.ProcessId=Processes.Id
WHERE ProfileServicesId=@ProfileServiceId and ProfileServiceProcs.Type=@ProcType 
Order by Processes.Name

Else if @OrgId=0 -- i.e. the profile for a given service for consumers  is being set
SELECT ProfileServiceProcs.Id, 
ProfileServiceProcs.ProcessId, ProfileServiceProcs.Description,
Processes.Name as ProcName
From
ProfileServiceProcs 
inner join Processes on ProfileServiceProcs.ProcessId=Processes.Id
WHERE ProfileServiceLocsId=@ProfileServiceLocId 
Order by Processes.Name

Else
SELECT DISTINCT dbo.Processes.Id as ProcessId, dbo.Processes.Name as ProcName, null as Description, null as Id
FROM  dbo.ProfileOrg INNER JOIN
               dbo.ProfileServices ON dbo.ProfileOrg.ProfileId = dbo.ProfileServices.ProfileId INNER JOIN
               dbo.ResourceTypes ON dbo.ProfileServices.ResTypeId = dbo.ResourceTypes.Id INNER JOIN
               dbo.ProfileServiceProcs ON dbo.ProfileServices.Id = dbo.ProfileServiceProcs.ProfileServicesId INNER JOIN
               dbo.Processes ON dbo.ProfileServiceProcs.ProcessId = dbo.Processes.Id
WHERE ProfileOrg.OrgId=@OrgId and  ProfileServiceProcs.Type=@TaskType
ORDER BY Processes.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileSPResTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileSPResTypes]
@Id int=0,
@OrgId int=0,
@ProcId int=0,
@LocId int =0,
@OrgIdP int=0,
@LicenseId int=0,
@DomainId int=0
As

if @Id !=0
SELECT ProfileSPResTypes.Id, ProfileSPResTypes.ProfileServiceProcId,
ProfileSPResTypes.ResTypeId, ProfileSPResTypes.Description,
ResourceTypes.Name as ResTypeName
From
ProfileSPResTypes inner join 
ResourceTypes on ProfileSPResTypes.ResTypeId=ResourceTypes.Id
WHERE ProfileSPResTypes.ProfileServiceProcId =@Id 
Order by ResourceTypes.Name

Else if @ProcId !=0 -- Organization type is Producer
SELECT Distinct Roles.Id as ResTypeId, Max(Roles.Name) as ResTypeName,
'0' as Id, '0' as ProfileServiceProcId, 'na' as Description
From ProfileOrg inner join
ProfileServices ON ProfileOrg.ProfileId = ProfileServices.ProfileId INNER JOIN
ResourceTypes ON ProfileServices.ResTypeId = ResourceTypes.Id INNER JOIN
ProfileServiceProcs ON ProfileServices.Id = ProfileServiceProcs.ProfileServicesId inner join 
ProfileSPResTypes on ProfileServiceProcs.Id=ProfileSPResTypes.ProfileServiceProcId inner join 
ResourceTypes as Roles on ProfileSPResTypes.ResTypeId=Roles.Id
Where  
ProfileOrg.OrgId=@OrgId and ProfileServiceProcs.ProcessId=@ProcId
GROUP BY Roles.Id
ORDER BY ResTypeName


else 
SELECT Distinct Roles.Id as ResTypeId, Max(Roles.Name) as ResTypeName,
'0' as Id, '0' as ProfileServiceProcId, 'na' as Description
From ProfileOrg inner join
ProfileServices ON ProfileOrg.ProfileId = ProfileServices.ProfileId INNER JOIN
ProfileServiceLocs on ProfileServices.Id=ProfileServiceLocs.ProfileServicesId inner join
ProfileServiceProcs on ProfileServiceLocs.Id=ProfileServiceProcs.ProfileServiceLocsId inner join
ProfileSPResTypes on ProfileServiceProcs.Id=ProfileSPResTypes.ProfileServiceProcId inner join 
ResourceTypes as Roles on ProfileSPResTypes.ResTypeId=Roles.Id
Where  ProfileOrg.OrgId=@OrgId and ProfileServiceLocs.LocTypeId=@LocId   
GROUP BY Roles.Id
ORDER BY ResTypeName
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileSPC]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileSPC]
@Id int=0,
@OrgId int=0,
@ContactTypeId int =0,
@ProcId int=0
As

if @Id !=0
SELECT ProfileSPC.Id, ProfileSPC.ProfileServiceProcId,
ProfileSPC.ContactTypeId, ProfileSPC.Description,
Profiles.Name as ContactTypeName
From
ProfileSPC inner join Profiles on ProfileSPC.ContactTypeId=Profiles.Id
WHERE ProfileSPC.ProfileServiceProcId =@Id 
Order by Profiles.Name

Else
SELECT Distinct Roles.Id as ResourceTypeId, Max(Roles.Name) as ResourceTypeName,
'0' as Id, '0' as ProfileServiceProcId, 'na' as Description
From ProfileOrg inner join
ProfileServices ON ProfileOrg.ProfileId = ProfileServices.ProfileId INNER JOIN
               ResourceTypes ON ProfileServices.ResTypeId = ResourceTypes.Id INNER JOIN
               ProfileServiceProcs ON ProfileServices.Id = ProfileServiceProcs.ProfileServicesId
inner join ProfileSPResTypes on ProfileServiceProcs.Id=ProfileSPResTypes.ProfileServiceProcId
inner join ResourceTypes as Roles on ProfileSPResTypes.ResTypeId=Roles.Id
Where  ProfileOrg.OrgId=@OrgId and ResourceTypes.Id=@ContactTypeId
and ProfileServiceProcs.ProcessId=@ProcId
GROUP BY Roles.Id
ORDER BY ResourceTypeName
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileSLocs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileSLocs]
@ProfileServiceId int=0,
@OrgId int=0,
@ResTypeId int=0
As
If @OrgId=0
SELECT ProfileServiceLocs.Id, 
ProfileServiceLocs.LocTypeId, ProfileServiceLocs.Description,
LocTypes.Name as LocName
From
ProfileServiceLocs 
inner join LocTypes on ProfileServiceLocs.LocTypeId=LocTypes.Id
WHERE ProfileServicesId=@ProfileServiceId 
Order by LocTypes.Name

Else if @ProfileServiceId=0
SELECT DISTINCT LocTypes.Id AS LocTypeId, MAX(ProfileServiceLocs.Id) AS Id, 'na' AS Description, MAX(LocTypes.Name) 
               AS LocName, MAX(ProfileOrg.OrgId) AS OrgId, MAX(ResourceTypes.Id) AS Expr1
FROM  ProfileOrg INNER JOIN
               ProfileServices ON ProfileOrg.ProfileId = ProfileServices.ProfileId INNER JOIN
               ResourceTypes ON ProfileServices.ResTypeId = ResourceTypes.Id INNER JOIN
               ProfileServiceLocs ON ProfileServices.Id = ProfileServiceLocs.ProfileServicesId INNER JOIN
               LocTypes ON ProfileServiceLocs.LocTypeId =LocTypes.Id
WHERE ProfileOrg.OrgId=@OrgId and ResourceTypes.Id=@ResTypeId 
GROUP BY LocTypes.Id
ORDER BY LocTypes.LocName
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileSEPSSer]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileSEPSSer]
@Id int=0
As
SELECT  ProfileSEPSSer.Id, ProfileSEPStepTypesId,
ServiceTypesId, ProfileSEPSSer.Description,
ServiceTypes.Name
From
ProfileSEPSSer inner join 
ServiceTypes on ProfileSEPSSer.ServiceTypesId=ServiceTypes.Id
WHERE ProfileSEPSSer.ProfileSEPStepTypesId =@Id 
Order by ServiceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileSEPSRes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileSEPSRes]
@Id int=0
As
SELECT  ProfileSEPSRes.Id, ProfileSEPStepTypesId,
ResTypesId, ProfileSEPSRes.Description,
ResourceTypes.Name
From
ProfileSEPSRes inner join 
ResourceTypes on ProfileSEPSRes.ResTypesId=ResourceTypes.Id
WHERE ProfileSEPSRes.ProfileSEPStepTypesId =@Id 
Order by ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfilesAll]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfilesAll]
@Type nvarchar (50),
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
SELECT Profiles.Id, Profiles.Name, Profiles.Description 
from Organizations inner join Profiles on
Organizations.Id=Profiles.OrgId inner join 
Licenses on Organizations.LicenseId=Licenses.Id
WHERE Type=@Type and (Profiles.Visibility=1 or
(Profiles.Visibility=2 and Licenses.DomainId=@DomainId) or 
(Profiles.Visibility=3 and Organizations.LicenseId=@LicenseId) or 
(Profiles.Visibility =4 and Organizations.ParentOrg=@OrgIdP) or 
(Profiles.Visibility=5 and Profiles.OrgId=@OrgId) )
 
Order by Profiles.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveProfileOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveProfileOrg]
@OrgId int=0
As
SELECT ProfileOrg.Id, ProfileOrg.ProfileId, Profiles.Name 
from 
ProfileOrg inner join 
Profiles on  ProfileOrg.ProfileId=Profiles.Id
WHERE ProfileOrg.OrgId=@OrgId
Order by Profiles.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrievePeopleRoles]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrievePeopleRoles]
@PeopleId int
As
SELECT PeopleRoles.Id, PeopleRoles.PeopleId, PeopleRoles.RoleId, Roles.Name, Organizations.Name as RoleOrgName
FROM  PeopleRoles inner join Roles on PeopleRoles.RoleId=Roles.Id
inner join Organizations on Roles.OrgId = Organizations.Id
WHERE PeopleRoles.PeopleId=@PeopleId
Order by Organizations.Name, Roles.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrievePeopleRoleMatchD]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrievePeopleRoleMatchD]
@DomainId int,
@RoleId int
As
SELECT Distinct People.Id, People.OrgId, People.FName + People.LName as Name, People.WorkPhone, People.HomePhone, People.CellPhone, 
               People.Email
FROM  People INNER JOIN
               PeopleRoles ON People.Id = PeopleRoles.PeopleId inner join Organizations on People.OrgId=Organizations.Id
	inner join Licenses on Organizations.LicenseId=Licenses.Id
Where Licenses.DomainId=@DomainId and PeopleRoles.RoleId=@RoleId 
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrievePeopleRoleMatch]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrievePeopleRoleMatch]
@LicenseId int,
@RoleId int
As
SELECT Distinct People.Id, People.OrgId, People.FName + People.LName as Name, People.WorkPhone, People.HomePhone, People.CellPhone, 
               People.Email
FROM  People INNER JOIN
               PeopleRoles ON People.Id = PeopleRoles.PeopleId inner join Organizations on People.OrgId=Organizations.Id
Where Organizations.LicenseId=@LicenseId and PeopleRoles.RoleId=@RoleId 
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrievePeopleList]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrievePeopleList]
@Visibility nvarchar (50)='Yes',
@DomainId int=0,
@LicenseId int=0,
@OrgIdP int=0,
@OrgId int
AS
If @Visibility='Yes'
Select People.Id, People.Fname + ' ' + People.LName as Name from People
 inner join Organizations on People.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where
(People.Visibility=1)
or (People.Visibility =2 and Licenses.DomainId= @DomainId)
or (People.Visibility=3 and Organizations.LicenseId= @LicenseId)
or (People.Visibility=4 and Organizations.ParentOrg= @OrgIdP)
or (People.Visibility=5 and People.OrgId= @OrgId)
Order by People.LName

Else
Select People.Id, People.Fname + ' ' + People.LName as Name from People
 inner join Organizations on People.OrgId=Organizations.Id
Where
People.OrgId= @OrgId
Order by People.LName
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveOrgSteps]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveOrgSteps]
@OrgId int
AS
Begin
Delete From OrgSteps
Where OrgId=@OrgId
End

Begin
Insert into OrgSteps (OrgId, StepId, Type)
(SELECT dbo.ProfileOrg.OrgId, ProfileSteps.StepId, 'Profile'
FROM  dbo.ProfileOrg INNER JOIN
               dbo.ProfileSteps ON dbo.ProfileOrg.ProfileId = dbo.ProfileSteps.ProfileId 
WHERE dbo.ProfileOrg.OrgId =@OrgId)
End
Begin
Insert into OrgSteps (OrgId, StepId, Type, Seq)
(SELECT EventOrgs.OrgId, EventSteps.StepId, 'Events', Seq
FROM  dbo.EventOrgs INNER JOIN
               dbo.EventSteps ON dbo.EventOrgs.EventId = dbo.EventSteps.EventId 
WHERE dbo.EventOrgs.OrgId =@OrgId)
End
Begin
Select Distinct OrgSteps.StepId as Id, Steps.StageId, Stages.Name as StageName, OrgSteps.Seq, OrgSteps.Type,
OrgSteps.OrgId,  Steps.Name
From
OrgSteps inner join Steps on OrgSteps.StepId=Steps.Id inner join Stages on Steps.StageId=Stages.Id
Where OrgSteps.OrgId =@OrgId and ((Steps.StageId=2)  or (Steps.StageId=3))
Order by Steps.StageId, OrgSteps.Type, OrgSteps.Seq
End
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveOrgs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveOrgs]
@Caller nvarchar (50),
@OrgId int=0,
@OrgIdP int=0,
@LocId int=0,
@ResTypeId int=0,
@OrgType nvarchar (50)='na',
@UserTypeId int=0,
@DomainId int=0,
@LicenseId int=null
 AS
if @Caller = 'Orgs'
SELECT Organizations.Id,  Organizations.Name, Organizations.Description,
Phone, Email, Address, PeopleId, Organizations.LocId, ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations
Where ParentOrg=@OrgId and OrgType=@OrgType
Order by Name
else if @Caller = 'Main'
SELECT Organizations.Id,  
Organizations.Name, 
Organizations.Description, 
Phone, 
Email, 
Address, 
PeopleId, 
Organizations.LocId,  
ParentOrg, 
LicenseId, 
Organizations.Visibility
FROM Organizations
Where Id=@OrgId 
Order by Name
else if @Caller = 'Security'
SELECT Distinct Organizations.Id,  Organizations.Name as OrgName,
Phone, Email, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations inner join Licenses on Licenses.Id=Organizations.LicenseId inner join  UserIds on UserIds.OrgId=Organizations.Id
Where LicenseId=@LicenseId and UserIds.Type=@UserTypeId
Order by Name
else if @Caller = 'Locs'
SELECT Organizations.Id,  Organizations.Name as OrgName,
Phone, Email, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations 
Where Organizations.LocId=@LocId  
Order by Name

else if @Caller = 'Host'
SELECT Organizations.Id,  Organizations.Name, Organizations.Description, 
Phone, Email, Address, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations
Where Status='New' 
Order by Name

else if @Caller = 'OrgsAll'
SELECT Organizations.Id,  Organizations.Name, Organizations.Description, 
Phone, Email, Address, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations
Order by Name

else if @Caller='OrgsAllCheck'
Select ServiceProviders.OrgId  from ServiceProviders inner join
Organizations on ServiceProviders.OrgId=Organizations.Id
Where ServiceProviders.OrgId=@OrgId
and ServiceProviders.ResTypeId=@ResTypeId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveOrgProfile]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveOrgProfile]
@OrgId int
 AS
Select ProfileId, Profiles.Name
from Organizations inner join
Profiles on Organizations.ProfileId=Profiles.Id 
Where (Organizations.Id=@OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveMain]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveMain]
@OrgId int
 AS
Select Domains.Name from
Domains inner join Licenses on
Domains.Id=Licenses.DomainId
 inner join Organizations on
Organizations.LicenseId=Licenses.Id
Where Organizations.Id=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveLocSProcs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveLocSProcs]
@OrgId int,
@LocId int,
@ProfileId int,
@TaskType nvarchar (50)

 AS
SELECT DISTINCT dbo.Processes.Id, dbo.Processes.Name, dbo.ProfileServiceProcs.Type, dbo.Services.Type AS Expr1
FROM  dbo.OrgLocServices INNER JOIN
               dbo.OrgLocations ON dbo.OrgLocServices.OrgLocationsId = dbo.OrgLocations.Id INNER JOIN
               dbo.Services ON dbo.OrgLocServices.ServicesId = dbo.Services.Id INNER JOIN
               dbo.ProfileServices INNER JOIN
               dbo.ProfileServiceProcs ON dbo.ProfileServiceProcs.ProfileServicesId = dbo.ProfileServices.Id INNER JOIN
               dbo.Processes ON dbo.ProfileServiceProcs.ProcessId = dbo.Processes.Id ON dbo.Services.Type = dbo.ProfileServices.ResTypeId
Where
OrgLocations.OrgId=@OrgId and  
OrgLocations.LocId=@LocId and 
ProfileServices.ProfileId=@ProfileId and
ProfileServiceProcs.Type=@TaskType
Order by Processes.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveLocServices]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveLocServices]
@OrgId int = 0,
@OrgIdP int=0,
@LicenseId int =0,
@DomainId int = 0,
@RoleId int=0,
@LocId int=0,
@Caller nvarchar (50)
AS
if (@Caller = 'frmMainOrgs') or  (@Caller ='frmOrgs') or (@Caller='frmMainEPS')
SELECT Services.Id, Services.Name, Services.Description, Services.SupplierOrganization, Services.Visibility, Services.Type,
Organizations.Name as OrgNamet
FROM  Services inner join Organizations on Services.SupplierOrganization = Organizations.Id 
inner join ResourceTypes on Services.Type=ResourceTypes.Id
Where Services.SupplierOrganization=@OrgId or Organizations.ParentOrg=@OrgId
Order by Services.Name

else if  (@Caller = 'frmLocs') 
SELECT Services.Id, Services.Name, Services.Description, Services.SupplierOrganization, Services.Visibility, Services.Type,
Organizations.Name as OrgNamet
FROM  
Services inner join 
Organizations on Services.SupplierOrganization = Organizations.Id inner join
ResourceTypes on Services.Type=ResourceTypes.Id inner join
OrgLocations on Services.SupplierOrganization=OrgLocations.OrgId inner join
OrgLocServices on OrgLocations.Id=OrgLocServices.OrgLocationsId
Where ((Services.SupplierOrganization=@OrgId) or (Organizations.ParentOrg=@OrgId))
and OrgLocations.LocId=@LocId
Order by Services.Name

else if  @Caller = 'frmMainTrg'
SELECT Services.Id, Services.Name, Services.Description, Services.SupplierOrganization, Services.Type,
Organizations.Name  as ServiceOrgName,
'na' as LicOrgId, 'na' as LicOrgName 
FROM  Services inner join Organizations on Services.SupplierOrganization = Organizations.Id
inner join ResourceTypes on Services.Type=ResourceTypes.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
inner join ResourceTypes as PType on PType.Id=ResourceTypes.ParentId
Where 
((Services.Visibility=1) or
(Services.Visibility=2 and Licenses.DomainId=@DomainId) or
(Services.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Services.Visibility=4 and Organizations.ParentOrg=@OrgIdP) or
(Services.Visibility=5 and Organizations.Id=@OrgId))
and  PType.Id=47--i.e. Training

else if  @Caller = 'frmPeopleCourses'
SELECT Services.Id, Services.Name, Services.Description, Services.SupplierOrganization, Services.Type,
ResourceTypes.Timetable, Organizations.Name  as OrgNamet 
FROM 
Resources
inner join Organizations on Services.SupplierOrganization = Organizations.Id 
inner join Licenses on Organizations.LicenseId=Licenses.Id 
inner join ResourceTypes on Resources.Type=ResourceTypes.Id
inner join ResourceTypes as PType on PType.Id=ResourceTypes.ParentId 
Where (Licenses.DomainId=@DomainId) and PType.Id=47--i.e. Training
else if  @Caller = 'Role'
SELECT Services.Id, Services.Name, Services.Description, Services.SupplierOrganization, Services.Type
FROM 
Services
inner join RoleResources on RoleResources.ResourceId=Services.Id
inner join ResourceTypes on Services.Type=ResourceTypes.Id
Where (RoleResources.RoleId=@RoleId)
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveLocations]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveLocations]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
SELECT Locations.Id, Locations.Name
FROM  Locations inner join Organizations on Locations.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
WHERE
(Locations.Visibility=1)
or (Locations.Visibility =2 and Licenses.DomainId= @DomainId)
or (Locations.Visibility=3 and Organizations.LicenseId= @LicenseId)
or (Locations.Visibility=4 and Organizations.ParentOrg= @OrgIdP)
or (Locations.Visibility=5 and Locations.OrgId= @OrgId)
Order by Locations.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveLicUserTypes]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveLicUserTypes]
@LicenseId int
 AS
Select UserTypes.Id, UserTypes.Name as UserTypesName,  UserTypeId, UserTypeMax
from LicenseUserTypes right outer join UserTypes
on LicenseUserTypes.UserTypeId=UserTypes.Id 
where  LicenseId=@LicenseId or LicenseId is Null
Order by UserTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveInventoryStatus]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveInventoryStatus]

 AS
Select Id, Name from InventoryStatus
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveInventory]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveInventory]

@Id int =0,
@TaskResId int=0,
@OrgId int=0,
@ResTypeId int=0,
@OrgIdP int=0,
@LicenseId int=0,
@DomainId int=0,
@Mode nvarchar (10)='na',
@ResTypesId int = 0,
@Caller int = null -- 

 AS
if @Caller = 1  -- i.e. called by frmInventory
SELECT 
I.Id, 
ResourceTypes.Name as ResName, Organizations.Name as OrgName,
I.ResTypeId, I.LocId,I.StatusId, I.OrgId,
'LocName'=
Case
When I.LocId is not null then Locations.Name else 'Undefined'
End, 
Locations.Name as LocName, InventoryStatus.Name as Status, 
QtyMeasures.NamePlural as QtyMeasureName, I.Name as 'ItemName', I.Qty,
I.SubLocation,
'LocSeq'=
Case
When I.LocId is not null then 1 else 2
End
from
Inventory as I inner join
Organizations on I.OrgId=Organizations.Id inner join
InventoryStatus on InventoryStatus.Id=I.StatusId inner join
ResourceTypes on ResourceTypes.Id=I.ResTypeId inner join 
QtyMeasures on ResourceTypes.QtyMeasuresId =QtyMeasures.Id left outer join
Locations on Locations.Id=I.LocId
Where I.OrgId=@OrgId
Order by LocSeq, ResourceTypes.Name, I.Name, Organizations.Name, 
Locations.Name, I.SubLocation

else if @Id !=0 -- i.e. called by frmUpdInventory to update
SELECT 
I.Id,--0 
I.Name,--1
 I.Description,--2 
I.LocId,--3
I.ResTypeId,--4
I.StatusId, --5
I.Visibility,--6
I.OrgId,--7
QtyMeasures.NamePlural,--8
I.SubLocation,--9
I.Qty
from
Inventory as I inner join
ResourceTypes on ResourceTypes.Id=I.ResTypeId inner join
QtyMeasures on ResourceTypes.QtyMeasuresId =QtyMeasures.Id 
Where I.Id=@Id
Order by I.Name

else if (@ResTypesId is null)

if @DomainId!=0 -- i.e. called for read purposes only
SELECT I.Id, I.Name, I.Description, 
I.ResTypeId, I.LocId,I.StatusId, I.OrgId,
Locations.Name as LocName, InventoryStatus.Name as Status
from
Inventory as I inner join
Organizations on I.OrgId=Organizations.Id inner join
Licenses on Licenses.Id=Organizations.LicenseId inner join
InventoryStatus on InventoryStatus.Id=I.StatusId inner join
ResourceTypes on ResourceTypes.Id=I.ResTypeId left outer join
Locations on Locations.Id=I.LocId
Where
I.ResTypeId=@ResTypesId and
(I.Visibility='1'
or I.Visibility='2' and Licenses.DomainId=@DomainId
or I.Visibility='3' and Organizations.LicenseId=@LicenseId
or I.Visibility='4' and Organizations.ParentOrg=@OrgIdP
or I.Visibility='5' and Organizations.Id=@OrgId)
Order by I.Name

else 

if @DomainId!=0 -- i.e. called for read purposes only
SELECT I.Id, I.Name, I.Description, 
I.ResTypeId, I.LocId,I.StatusId, I.OrgId,
Locations.Name as LocName, InventoryStatus.Name as Status
from
Inventory as I inner join
Organizations on I.OrgId=Organizations.Id inner join
Licenses on Licenses.Id=Organizations.LicenseId inner join
InventoryStatus on InventoryStatus.Id=I.StatusId inner join
ResourceTypes on ResourceTypes.Id=I.ResTypeId left outer join
Locations on Locations.Id=I.LocId
Where
(I.Visibility='1'
or I.Visibility='2' and Licenses.DomainId=@DomainId
or I.Visibility='3' and Organizations.LicenseId=@LicenseId
or I.Visibility='4' and Organizations.ParentOrg=@OrgIdP
or I.Visibility='5' and Organizations.Id=@OrgId)
Order by I.Name

else if @OrgId !=0 -- i.e. called by frmInventory
SELECT I.Id, I.Name, I.Description, 
I.ResTypeId, I.LocId,I.StatusId, 
Locations.Name as LocName, InventoryStatus.Name as Status
from
Inventory as I inner join
Organizations on I.OrgId=Organizations.Id inner join
InventoryStatus on InventoryStatus.Id=I.StatusId inner join
ResourceTypes on ResourceTypes.Id=I.ResTypeId left outer join
Locations on Locations.Id=I.LocId
Where I.OrgId=@OrgId
Order by I.Name


else if @Id !=0 -- i.e. called by frmUpdInventory to update
SELECT 
I.Id, 
I.Name,
 I.Description, 
I.LocId,
I.ResTypeId,
I.StatusId, 
I.Visibility,
I.OrgId
from
Inventory as I
Where I.Id=@Id
Order by I.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveFY]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveFY]
@OrgId int
As
Select 
--Convert(Char(12), Max(AccountPeriods.StartDate), 107) as Start
Max(Name)
from FiscalYears 
Where OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveActivities]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveActivities]
@OrgId int
 AS
Select Activity from OrgActivities
where OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteUser]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteUser]
@Id int

AS
DELETE FROM UserIds WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteStepRoles]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteStepRoles]
@StepId int
AS
DELETE From StepRoles
Where Id in 
(Select  StepRoles.Id from  StepRoles inner join Roles on StepRoles.RoleId=Roles.Id  Where StepId=@StepId)
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveEventProcs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveEventProcs]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int

 AS
SELECT Procs.Id, Procs.Name 
from Procs inner join
Organizations on Procs.OrgId=Organizations.Id inner join
Licenses on   Organizations.LicenseId=Licenses.Id
Where Procs.Visibility=1 or
Procs.Visibility=2 and Licenses.DomainId=@DomainId or
Procs.Visibility=3 and Organizations.LicenseId=@LicenseId or
Procs.Visibility=4 and Organizations.ParentOrg=@OrgIdP
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveEventOrg]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_RetrieveEventOrg]
@OrgId int
As
SELECT EventOrgs.Id, EventId, Name, Description 
FROM  EventOrgs inner join Events on EventId=Events.Id
WHERE EventOrgs.OrgId=@OrgId
Order by Events.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveEmailPeopleAct]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveEmailPeopleAct]
@ActId int
AS
Select People.Email
FROM ActPeople INNER JOIN
               People ON ActPeople.PeopleId = People.Id
Where ActPeople.ActivationId=@ActId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveEmailPeople]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveEmailPeople]
@OrgIdt int
AS
Select People.Email
FROM  Staffing INNER JOIN
               People ON Staffing.PeopleId = People.Id
Where Staffing.OrgId=@OrgIdt
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveEmailOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveEmailOrg]
@OrgId int,
@OrgType nvarchar (50)
AS
Select Email from Organizations  

Where ParentOrg=@OrgId and OrgType=@OrgType  and Email <> ''
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveDomainName]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveDomainName] 
@DomainId int
AS
Select Name from Domains
Where Id=@DomainId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveContactTypes]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveContactTypes]
@Function nvarchar (50),
@OrgId int=0,
@OrgIdP int = 0,
@LicenseId int = 0,
@DomainId int = 0
As
If @Function = 'Lookup'-- caller = frmProfilesAll 
SELECT Profiles.Id,  Profiles.Name as ServiceTypesName,  Profiles.Description
FROM Profiles
inner join Organizations on Profiles.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where  Profiles.Visibility=1
or ( Profiles.Visibility=2 and DomainId=@DomainId)
or ( Profiles.Visibility=3 and  LicenseId=@LicenseId)
or ( Profiles.Visibility=4 and ParentOrg=@OrgIdP)
or ( Profiles.Visibility=5 and  Profiles.OrgId=@OrgId)
Order by  Profiles.Name

Else if @Function='Update' -- caller = frmProfilesAll 
SELECT Profiles.Name, Profiles.Description, Profiles.Id, Profiles.Visibility
FROM Profiles 
Where Profiles.OrgId=@OrgId
Order by Profiles.Name
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveConsumerPlan]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveConsumerPlan]
@OrgId int
As
Select  Distinct LocTypes.Id, Max(LocTypes.Name) as Name, Max(LocTypes.Seq) as Seq  from
ProfileOrg inner join 
Profiles on ProfileOrg.ProfileId=Profiles.Id inner join
ProfileServices on ProfileServices.ProfileId=Profiles.Id inner join
ProfileServiceLocs on ProfileServices.Id=ProfileServiceLocs.ProfileServicesId inner join
LocTypes on ProfileServiceLocs.LocTypeId=LocTypes.Id
Where ProfileOrg.OrgId=@OrgId
Group by LocTypes.Id
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveCommitments]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveCommitments]
@ServiceId  int
 AS


SELECT dbo.ResourceOutputDeadlines.Id, ResourceOutputDeadlines.ServiceId, dbo.ResourceOutputDeadlines.Deadline, dbo.ResourceOutputDeadlines.TypeOfImpact, 
               dbo.ResourceOutputDeadlines.ImpactMagnitude, dbo.ResourceOutputDeadlines.AcceptableDelay, dbo.ResourceOutputDeadlines.Client, 
               dbo.ResourceOutputDeadlines.ImpactValue, dbo.ResourceOutputDeadlines.LocationId, dbo.Services.SupplierOrganization
FROM  dbo.Organizations INNER JOIN
               dbo.Services ON dbo.Organizations.Id = dbo.Services.SupplierOrganization INNER JOIN
               dbo.ResourceOutputDeadlines ON dbo.Services.Id = dbo.ResourceOutputDeadlines.ServiceId
Where ServiceId=@ServiceId
GO
/****** Object:  StoredProcedure [dbo].[eps_RetrieveClientTypes]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_RetrieveClientTypes]
as

Select Id, Name from ClientTypes
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteStaffing]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteStaffing]
@Id int
AS
Delete
FROM  Staffing
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteSSContracts]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteSSContracts]
@Id int
AS
Delete
FROM  StepSContracts
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteSkill]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteSkill]
@Id int

AS
DELETE FROM Skills WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteServices]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteServices]
@Id int

AS
DELETE FROM Services WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteRoleSkills]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteRoleSkills]
@RoleId int
AS
DELETE From RoleSkills
Where RoleId  = @RoleId
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProject]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProject]
@Id int
As
Delete from Projects
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProfileServiceEvents]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteProfileServiceEvents]
@Id int
 AS
Delete from ProfileServiceEvents
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProfileService]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProfileService]
@Id int
 AS
Delete FROM  ProfileServiceTypes
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProfileProject]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProfileProject]
@Id int
 AS
Delete FROM  ProfileProjectTypes
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProfileOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProfileOrg]
@OrgId int=0,
@Id int =0
As
if @Id=0
DELETE FROM ProfileOrg
WHERE OrgId  = @OrgId
else
Delete from ProfileOrg
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProfile]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteProfile]
@Id int

AS
DELETE FROM Profiles WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteProcureInv]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteProcureInv]
@Id int
AS
Delete
FROM  ProcureInventory
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeletePeopleSkills]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeletePeopleSkills]
@PeopleId int

AS
DELETE FROM PeopleSkills WHERE PeopleId = @PeopleId;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeletePeopleRoles]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeletePeopleRoles]
@PeopleId int
AS
DELETE From PeopleRoles
Where PeopleRoles.Id in 
(Select PeopleRoles.Id from PeopleRoles inner join Roles on PeopleRoles.RoleId = Roles.Id 
Where PeopleId=@PeopleId)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteOrg]
@Id int
AS
Delete
FROM  Organizations
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteLicenseUserTypes]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteLicenseUserTypes] 
@LicenseId int
As
Delete from LicenseUserTypes
Where LicenseId=@LicenseId
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteInventory]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteInventory]
@Id int

AS
Delete from Inventory Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteEventId]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteEventId]
@Id int
AS
DELETE FROM Events WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteDeadline]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteDeadline]
@Id int

AS
DELETE FROM ResourceOutputDeadlines
 WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteContactType]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_DeleteContactType]
@Id int
As
Delete from ContactTypes Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_DeleteBackup]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_DeleteBackup]
@Id int
AS
Delete
FROM  ResourceBackups
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddUserId]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddUserId]
@User  nvarchar(50),
@OrgId int,
@Status nvarchar(50),
@Type nvarchar (50),
@Pd nvarchar (50),
@PeopleId int
as
Insert into UserIds (UserId, OrgId, CreationOrg, Status, Type, Password, PeopleId, CreationDate, PasswordUpdate)
 Values (@User, @OrgId, @OrgId, @Status, @Type, @Pd, @PeopleId, GETDATE(),GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[eps_AddSkills]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddSkills]
@Visibility int,
@Name nvarchar(50),
@OrgId int
As
Insert into Skills
(Name,OrgId, Visibility)
values
(@Name,@OrgId, @Visibility)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddContractProcures]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddContractProcures]
@ContractId int,
@ProcurementsId int
as
Insert into ContractProcures (ContractId, ProcurementsId )
Values
(@ContractId,  @ProcurementsId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddContactType]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddContactType]
@Name nvarchar(100),
@Desc ntext,
@ParentId int = null,
@OrgId int,
@Vis int
AS
Insert into Profiles
(Name, Description, OrgId, Visibility)
values
(@Name, @Desc, @OrgId, @Vis)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddContact]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddContact]
@OrgId int,
@Name nvarchar (50), 
@Address nvarchar (50)='na',
@RegularPhone nvarchar (50), 
@CellPhone nvarchar (50), 
@Email nvarchar (50)='na',
@ProfileId int=0,
@Caller nvarchar (50)='na'

AS
if @Caller='frmContacts'
Insert into Contacts (Name,RegularPhone, CellPhone, OrgId, ProfileId)
Values (@Name,  @RegularPhone, @CellPhone, @OrgId,@ProfileId)
else
Insert into Contacts (Name, Address, RegularPhone, CellPhone, Email, OrgId)
Values (@Name, @Address, @RegularPhone, @CellPhone, @Email, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddBackups]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_AddBackups]
@Resource int,
@Backup int,
@Timing nvarchar (50),
@Retention nvarchar (50),
@Scope nvarchar (50)
AS
Insert into  ResourceBackups
 (Resource, BackupResource, Timing, RetentionPeriod, Scope)
Values (@Resource, @Backup, @Timing, @Retention, @Scope)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddServiceId]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddServiceId]
@OrgId int,
@Name nvarchar (50),
@ResTypeId int,
@Vis int=4
AS
insert into Services (Name, SupplierOrganization, Visibility, Type)
Values
(@Name, @OrgId, @Vis, @ResTypeId);
GO
/****** Object:  StoredProcedure [dbo].[eps_AddService]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddService]
@OrgId int,
@Name nvarchar (50),
@Desc ntext=null,
@Vis int,
@Type int
AS
insert into Services (Name, Description, SupplierOrganization, Visibility, Type)
Values
(@Name, @Desc, @OrgId, @Vis, @Type);
GO
/****** Object:  StoredProcedure [dbo].[eps_AddProfile]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_AddProfile]
@OrgId int,
@Name nvarchar (50),
@Vis int,
@Desc ntext,
@Type nvarchar (50),
@PeopleId int,
@AllHH int=null,
@Status int
AS
insert into Profiles (Name, Description, OrgId, Visibility, Type, PeopleId, Households, Status)
Values
(@Name, @Desc, @OrgId, @Vis, @Type, @PeopleId, @AllHH, @Status)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddProcureInventory]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddProcureInventory]
@ProcurementsId int,
@InventoryId int

AS
Insert into ProcureInventory
(ProcurementsId,InventoryId)
Values
(@ProcurementsId,@InventoryId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddOrgLocSEPSteps]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddOrgLocSEPSteps]
@OrgLocSEProcsId int,
@ProfileSEProcsId int
AS
Insert into OrgLocSEPSteps (ProfileSEPStepsId, OrgLocSEProcsId, StepsId) 
Select ProfileSEPStepTypes.Id, @OrgLocSEProcsId, ProfileSEPStepTypes.StepTypesId
from 
ProfileSEPStepTypes inner join
ProfileSEProcs on ProfileSEProcs.Id=ProfileSEPStepTypes.ProfileSEProcsId
Where ProfileSEProcsId=@ProfileSEProcsId
GO
/****** Object:  StoredProcedure [dbo].[eps_AddLoc]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddLoc]
@Name nvarchar(100),
@Desc ntext,
@OrgId int,
@Vis int,
@StatesId int=null,
@CountriesId int=null
AS
Insert into Locations
(Name, Description, OrgId, Visibility, StatesId, CountriesId)
values
(@Name, @Desc, @OrgId, @Vis, @StatesId, @CountriesId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddLicense]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddLicense]
@OrgId int
As
Insert into Licenses (OrgId)
Values(@OrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddInventory]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddInventory]
@Desc nvarchar (300),
@ResTypeId int,
@OrgId int,
@StatusId int,
@VisId int,
@Qty float=null,
@SubLoc nvarchar (50),
@LocId int =0
AS
Insert into Inventory
(SubLocation, Description,  StatusId, LocId,ResTypeId, Qty, OrgId, Visibility)
values
(@SubLoc, @Desc,  @StatusId, @LocId, @ResTypeId, @Qty, @OrgId, @VisId)
GO
/****** Object:  StoredProcedure [dbo].[eps_AddDeadline]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_AddDeadline]
@ServiceId int,
@Client nvarchar (50),
@Deadline nvarchar (50),
@AccDelay nvarchar (50),
@Value nvarchar (50),
@Impact nvarchar (15),
@Mag nvarchar (15),
@Loc Int
AS
insert into ResourceOutputDeadlines (ServiceId, Client, Deadline, AcceptableDelay,  ImpactValue, TypeOfImpact, ImpactMagnitude, LocationId)
Values
(@ServiceId, @Client, @Deadline, @AccDelay, @Value, @Impact, @Mag, @Loc)
GO
/****** Object:  StoredProcedure [dbo].[ams_UpdatePSOrgs]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_UpdatePSOrgs]
@OrgId int,
@PSTId int
As
Insert into OrgServiceTypes (OrgId, PSTID) Values
(@OrgId, @PSTId)
GO
/****** Object:  StoredProcedure [dbo].[ams_UpdateOrgFlags]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_UpdateOrgFlags]
@OrgIdC int,
@FlagTypesId int
AS
Insert into OrgFlags (OrgId, FlagTypesId)
Values
(@OrgIdC, @FlagTypesId)
GO
/****** Object:  StoredProcedure [dbo].[ams_UpdateOrg]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_UpdateOrg]
@Id int,
@Name nvarchar (70),
@Desc ntext,
@Phone nvarchar (50),
@Email nvarchar (50),
@Addr ntext,
@LocId int = null,
@Vis int=5,
@ProfileId int=null,
@CurrenciesId int = null
AS
if @CurrenciesId is not null

Update Organizations
Set Name=@Name, Description=@Desc, Phone=@Phone, 
Email=@Email ,Address=@Addr, LocId=@LocId, Visibility=@Vis,
ProfileId=@ProfileId,
CurrId=@CurrenciesId
Where Id=@Id

else
Update Organizations
Set Name=@Name, Description=@Desc, Phone=@Phone, 
Email=@Email ,Address=@Addr, LocId=@LocId, Visibility=@Vis,
ProfileId=@ProfileId
Where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[ams_UpdateBudFlags]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_UpdateBudFlags]
@BudgetsId int,
@FlagTypesId int
AS
Insert into BudFlags (BudgetsId, FlagTypesId)
Values
(@BudgetsId, @FlagTypesId)
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveVisibility]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveVisibility] 
@Vis int,
@VisForm int=1
AS
Select Id, Name from Visibility
Where Id >=@Vis and
Id >=@VisForm
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveUserIdName]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveUserIdName]
@UserId nvarchar (50)
As
Select  UserIds.PeopleId,  LName, Fname, CellPhone, HomePhone, WorkPhone, Address, Email, Visibility
 from UserIds  inner join People on UserIds.PeopleId=People.Id 
Where UserId = @UserId and UserIds.Status='Active'
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveSLocations]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_RetrieveSLocations]
@OrgLocationsId int
As
Select SLocations.Id, SLocations.Name
from SLocations
Where SLocations.OrgLocationsId=@OrgLocationsId
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveProfileServices]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveProfileServices]
@ProfileIdC int
As
SELECT ProfileServiceTypes.Id, ServiceTypes.Name

FROM  
ProfileServiceTypes  INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id 
Where 
ProfileServiceTypes.ProfilesId=@ProfileIdC
Order by ProfileServiceTypes.Seq
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgServices]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgServices]
@OrgIdC int
As
SELECT dbo.ServiceTypes.Id, dbo.ServiceTypes.Name, dbo.OrgServiceTypes.Id AS OSTId, dbo.OrgServiceTypes.OrgId
FROM  dbo.OrgServiceTypes INNER JOIN
               dbo.ProfileServiceTypes ON dbo.OrgServiceTypes.PSTId = dbo.ProfileServiceTypes.Id INNER JOIN
               dbo.Organizations ON dbo.OrgServiceTypes.OrgId = dbo.Organizations.Id INNER JOIN
               dbo.ServiceTypes ON dbo.ProfileServiceTypes.ServiceTypesId = dbo.ServiceTypes.Id
Where 
Organizations.Id=@OrgIdC
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgs]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgs]
@Caller nvarchar (50),
@OrgId int=0,
@OrgIdP int=0,
@LocId int=0,
@ResTypeId int=0,
@OrgType nvarchar (50)='na',
@UserTypeId int=0,
@DomainId int=0,
@LicenseId int=null
 AS
if @Caller = 'Orgs'
SELECT Organizations.Id,  Organizations.Name, Organizations.Description,
Phone, Email, Address, PeopleId, Organizations.LocId, ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations
Where ParentOrg=@OrgId and OrgType=@OrgType
Order by Name
else if @Caller = 'Main'
SELECT Organizations.Id,  
Organizations.Name, 
Organizations.Description, 
Phone, 
Email, 
Address, 
PeopleId, 
Organizations.LocId,  
ParentOrg, 
LicenseId, 
Organizations.Visibility
FROM Organizations
Where Id=@OrgId 
Order by Name
else if @Caller = 'Security'
SELECT Distinct Organizations.Id,  Organizations.Name as OrgName,
Phone, Email, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations inner join Licenses on Licenses.Id=Organizations.LicenseId inner join  UserIds on UserIds.OrgId=Organizations.Id
Where LicenseId=@LicenseId and UserIds.Type=@UserTypeId
Order by Name
else if @Caller = 'Locs'
SELECT Organizations.Id,  Organizations.Name as OrgName,
Phone, Email, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations 
Where Organizations.LocId=@LocId  
Order by Name

else if @Caller = 'Host'
SELECT Organizations.Id,  Organizations.Name, Organizations.Description, 
Phone, Email, Address, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations
Where Status='New' 
Order by Name

else if @Caller = 'OrgsAll'
SELECT Organizations.Id,  Organizations.Name, Organizations.Description, 
Phone, Email, Address, Organizations.PeopleId, Organizations.LocId,  ParentOrg, LicenseId, Organizations.Visibility
FROM Organizations
Order by Name

else if @Caller='OrgsAllCheck'
Select ServiceProviders.OrgId  from ServiceProviders inner join
Organizations on ServiceProviders.OrgId=Organizations.Id
Where ServiceProviders.OrgId=@OrgId
and ServiceProviders.ResTypeId=@ResTypeId
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsWPS]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsWPS]
@OrgId int = null,
@OrgLocId int = null
 AS
if @OrgId is not null
Select Count(*)
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='WPS')
else
Select Count(*)
from
OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='WPS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsTRS]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsTRS]
@OrgId int = null,
@OrgLocId int = null
 AS
if @OrgId is not null
Select Count(*)
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='TRS')
else
Select Count(*)
from
OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='TRS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsSAS]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsSAS]
	-- Add the parameters for the stored procedure here
	@OrgId int=null,
	@OrgLocId int=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if @OrgId is not null
Select Count(*)--, 
--FlagTypesId
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='SAS')
else
Select Count(*)--, 
--FlagTypesId
from 

OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='BDS')

END
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsPRS]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsPRS]
@OrgId int = null,
@OrgLocId int = null
 AS
if @OrgId is not null
Select Count(*)
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='PRS')
else
Select Count(*)
from
OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='PRS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsPRC]    Script Date: 02/21/2014 15:49:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsPRC]
@OrgId int=null,
@OrgLocId int=null
 AS
if @OrgId is not null
Select Count(*)--, 
--FlagTypesId
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='PRC')
else
Select Count(*)--, 
--FlagTypesId
from 

OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='PRC')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsEPS]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsEPS]
@OrgId int = null,
@OrgLocId int = null
 AS
if @OrgId is not null
Select Count(*)
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='EPS')
else
Select Count(*)
from
OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='EPS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsBRS]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsBRS]
@OrgId int=null,
@OrgLocId int=null
 AS
if @OrgId is not null
Select Count(*)--, 
--FlagTypesId
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='BRS')
else
Select Count(*)--, 
--FlagTypesId
from 

OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='BRS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsBMS]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsBMS]
@OrgId int=null,
@OrgLocId int=null
 AS
if @OrgId is not null
Select Count(*)--, 
--FlagTypesId
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='BMS')
else
Select Count(*)--, 
--FlagTypesId
from 

OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='BMS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgFlagsBDS]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrgFlagsBDS]
@OrgId int=null,
@OrgLocId int=null
 AS
if @OrgId is not null
Select Count(*)--, 
--FlagTypesId
from FlagTypes left outer join
OrgFlags on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgId=@OrgId and FlagTypes.Code='BDS')
else
Select Count(*)--, 
--FlagTypesId
from 

OrgLocations inner join
Organizations on OrgLocations.OrgId=Organizations.Id inner join
OrgFlags on Organizations.Id=OrgFlags.OrgId inner join
FlagTypes on FlagTypes.Id=OrgFlags.FlagTypesId
Where (OrgLocations.Id=@OrgLocId and FlagTypes.Code='BDS')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrgData]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ams_RetrieveOrgData]
@OrgId int
 AS
Select 
ProfileId,--0, 
Profiles.Name,--1
Organizations.Name, --2
Organizations.ParentOrg,--3
Organizations.Visibility as OrgVis--4

from Organizations inner join
Profiles on Organizations.ProfileId=Profiles.Id 
Where (Organizations.Id=@OrgId)
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveOrg]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_RetrieveOrg]
@Id int = null,
@LicenseId int=null
AS
if @LicenseId is null

SELECT   
Organizations.Name, --0
Organizations.Description, --1
Phone, --2
Email, --3
Address, --4
Organizations.LocId,  --5
Organizations.Visibility, --6
Organizations.ProfileId, ---7
Organizations.BudMod, --8
Organizations.CurrId--9
FROM Organizations
Where Id=@Id
else
 Select
Organizations.Id,
Organizations.Name
FROM Organizations
Where LicenseId=@LicenseId
GO
/****** Object:  StoredProcedure [dbo].[ams_Retrievemsg]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_Retrievemsg]
AS
Select Message from MenuMessage
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveLicVis]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveLicVis]
@LicenseId int
 AS
Select  Visibility, OrgId from Licenses
Where Id=@LicenseId
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveLicenses]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveLicenses]
@ActId int=0
As
if @ActId = 0
SELECT Licenses.LicenseDate, LicenseStatus, Organizations.Name as OrgName, OrgId, Organizations.Email,
Licenses.Id, Licenses.DomainId, Licenses.Visibility, Organizations.ProfileId
FROM Licenses inner join Organizations on Licenses.OrgId = Organizations.Id
Order By LicenseStatus, Organizations.Name
else
SELECT Licenses.LicenseDate, LicenseStatus, Organizations.Name as OrgName, OrgId, Licenses.Id, Licenses.DomainId, Licenses.Visibility
FROM Licenses inner join Organizations on Licenses.OrgId = Organizations.Id
Where ActId=@ActId
Order By Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveLicenseOrgs]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_RetrieveLicenseOrgs]

@LicenseId int
As
Select Organizations.Id, 
Organizations.Name, Organizations.CreatorOrg, 
Profiles.Id as ProfileIdC, Profiles.Name as ProfileNameC,
Organizations.ParentOrg as OrgIdPC,
Organizations.LicenseId as LicenseIdC,
Licenses.DomainId as DomainIdC
from
Organizations inner join
Licenses on Organizations.LicenseId=Licenses.Id left outer  join
Profiles on Organizations.ProfileId=Profiles.Id
Where 
Organizations.LicenseId=@LicenseId and
(Organizations.OrgType is null or 
Organizations.OrgType !='Household')
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveLicenseOrg]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveLicenseOrg]
@UserId nvarchar(50)=null,
@OrgId int = null
As
if @OrgId is null

SELECT 
Organizations.Id, --0
Organizations.Name, --1
Organizations.ParentOrg,--2
Licenses.LicenseDate, --3
Licenses.LicensePeriodDays, --4
UserIds.UserId,  --5
UserIds.Password,--6
Organizations.LicenseId,--7
Licenses.LicenseStatus, --8
UserTypes.StartForm,--9
Licenses.AccessLevel,--10
UserIds.PasswordUpdate, --11
UserIds.Status, --12
Licenses.DomainId, --13
People.Email, --14
ParentOrg.Name as OrgNameP, --15
UserIds.Type as UserTypeId, --16
UserIds.Id as UserIdId,--17
Organizations.Visibility as OrgVis,--18
People.FName + ' ' + People.LName as PeopleName,--19
UserIds.CreationOrg, --20
People.USerLevel --21
FROM  Organizations
INNER JOIN  Licenses ON Organizations.LicenseId = Licenses.Id 
INNER JOIN UserIds ON Organizations.Id = UserIds.OrgId 
INNER JOIN Organizations ParentOrg ON Organizations.ParentOrg = ParentOrg.Id 
INNER JOIN UserTypes ON UserIds.Type = UserTypes.Id
LEFT OUTER JOIN People ON UserIds.PeopleId=People.Id
Where UserId=@UserId

else

SELECT 
Organizations.Name, --0
Organizations.ParentOrg,--1
Organizations.Visibility as OrgVis--2
FROM  Organizations
Where Id=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveFlagTypes]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_RetrieveFlagTypes]
@Type int = 1
As
SELECT dbo.FlagTypes.Id, dbo.FlagTypes.Name, Code, FlagTypes.Description
FROM  FlagTypes
Where FlagTypes.Type=@Type
Order by  FlagTypes.SeqA, FlagTypes.SeqB, FlagTypes.Code
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveFlagsMgr]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_RetrieveFlagsMgr]
@OrgLocId int,
@PeopleId int
As
SELECT Count(*)
FROM  
OrgLocMgrs inner join
StaffActions on OrgLocMgrs.StaffActionsId=StaffActions.Id inner join
People on StaffActions.PeopleId=People.Id
WHERE OrgLocMgrs.OrgLocId = @OrgLocId and PeopleId=@PeopleId
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveCOrg]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveCOrg]
@COrgId int
As
Select  
Organizations.Name
From
Organizations 
Where Id = @COrgId
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveBudFlagsPAY]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveBudFlagsPAY]
@BudgetsId int
 AS
Select Count(*)
from FlagTypes left outer join
BudFlags on FlagTypes.Id=BudFlags.FlagTypesId
Where (BudFlags.BudgetsId=@BudgetsId and FlagTypes.Code='PAY')
GO
/****** Object:  StoredProcedure [dbo].[ams_RetrieveBudFlagsBDR]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_RetrieveBudFlagsBDR]
@BudgetsId int
 AS
Select Count(*)
from FlagTypes left outer join
BudFlags on FlagTypes.Id=BudFlags.FlagTypesId
Where (BudFlags.BudgetsId=@BudgetsId and FlagTypes.Code='BDR')
GO
/****** Object:  StoredProcedure [dbo].[ams_DeletePSOrgs]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ams_DeletePSOrgs]
@Id int

AS
DELETE FROM OrgServiceTypes WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[ams_AddOrg]    Script Date: 02/21/2014 15:49:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ams_AddOrg]
@Creator int,
@ParentOrg int,
@Name nvarchar (70),
@Desc ntext,
@Phone nvarchar (50),
@Email nvarchar (50),
@LicenseId int=null,
@CurrenciesId int=null,
@Addr ntext,
@OrgType nvarchar (50)='na',
@LocId int=null,
@ProfileId int = null,
@Vis int=5
 AS
if @CurrenciesId is not null
Insert into Organizations
(CreatorOrg, ParentOrg, Name, Description, Phone, Email, 
Address, LicenseId, OrgType,  LocId, Visibility, ProfileId, CurrId)
values (@Creator, @ParentOrg, @Name, @Desc, @Phone, 
@Email, @Addr, @LicenseId, @OrgType,@LocId, @Vis, @ProfileId, @CurrenciesId )
else 

Insert into Organizations
(CreatorOrg, ParentOrg, Name, Description, Phone, Email, 
Address, LicenseId, OrgType,  LocId, Visibility, ProfileId)
values (@Creator, @ParentOrg, @Name, @Desc, @Phone, 
@Email, @Addr, @LicenseId, @OrgType,@LocId, @Vis, @ProfileId)
GO
/****** Object:  StoredProcedure [dbo].[RetrieveTaskBudgets]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[RetrieveTaskBudgets]
@Id  int
 AS

Select  
--TaskBudgets.Description, --0
TaskBudgets.Qty,--1xx
TaskBudgets.BudgetsId,--2xx
--TaskBudgets.ContractId, --3
--TaskBudgets.TypeId, --4
TaskBudgets.Price, --5xx
TimeMeasure, --6xx
Organizations.Name, --7
Budgets.Name, --8xx
'Status'=--9xx
Case
When Budgets.Status = 1 then 'Open'
Else 'Closed'
End,
TaskBudgets.ReqAmount, --10xx
TaskBudgets.BudAmount --11xx
--TaskBudgets.BkupFlag --12
From 
TaskBudgets inner join
Budgets on TaskBudgets.BudgetsId=Budgets.Id inner join
OrgLocations on TaskBudgets.OrgLocId=OrgLocations.Id inner join
Organizations on OrgLocations.OrgId=Organizations.Id
Where TaskBudgets.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[RetrieveOrgPSEPRDesc]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[RetrieveOrgPSEPRDesc]
@PSEPResId int,
@OrgId int
AS

if Exists (Select OrgPSEPRDesc.Id from OrgPSEPRDesc Where OrgPSEPRDesc.OrgId=@OrgId)

Select 
OrgPSEPRDesc.Description as Descr,
'Org' as Srce
from PSEPRes inner join 
OrgPSEPRDesc on PSEPRes.Id=OrgPSEPRDesc.PSEPResId
Where (PSEPRes.Id=@PSEPResId and OrgPSEPRDesc.OrgId=@OrgId)

else

Select 
PSEPRes.Description as Descr,
'Model' as Srce
from PSEPRes 
Where PSEPRes.Id=@PSEPResId
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProcSReq]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddProcSReq]
@PSEPSID  int,
@PSEPID  int,
@StaffActionId int=null,
@Desc varchar (300)=null,
@BudgetsId int=null,
@ProjectId int=null,
@Time decimal (20,2)=0,
@Price decimal (20,2) = 0,
@TypeId int = null,
@OrgLocId int,
@TimeMeasure int =0,
@ReqAmount decimal (20,2)=null
AS
Insert into ProcProcures
(PSEPID, PSEPSID, ContractId, Description, Qty, OrgLocId, BudgetsId,
ProjectId, Price, TypeId, TimeMeasure, ReqAmount)
values
(@PSEPID, @PSEPSID, @StaffActionId, @Desc,@Time, @OrgLocId, @BudgetsId,
@ProjectId, @Price, @TypeId, @TimeMeasure, @ReqAmount)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProcPReq]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_AddProcPReq]
@OrgLocId int,
@Desc varchar (300)=null,
@PSEPSID  int,
@PSEPID int,
@ProjectId int=null,
@ContractId  int=null,
@BudgetsId int=null,
@Qty decimal (20,2)=null,
@Price decimal (20,2) = null,
@ReqAmount  decimal (20,2)=null,
@BkupFlag int=null, 
@TypeId int

AS
Insert into ProcProcures
(PSEPID, PSEPSID, ContractId, Description, BudgetsId, Qty, OrgLocId, SGFlag,
ProjectId, Price, ReqAmount, BkupFlag, TypeId)
values
(@PSEPID, @PSEPSID, @ContractId, @Desc,@BudgetsId, @Qty, @OrgLocId, '0',
@ProjectId, @Price, @ReqAmount, @BkupFlag, @TypeId)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProcPay]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddProcPay]
@ProcProcuresId int,
@PayAmt float=null,
@Status int=null,
@Qty float = null,
@ReqDate datetime
As
Insert into Payments 
(ProcProcuresId,
Status,
PaymentAmount,
Qty,
ReqDate)
Values
(@ProcProcuresId,
@Status,
@PayAmt,
@Qty,
@ReqDate)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProcContractId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddProcContractId]
@Id int,
@ContractId int
 AS
Update ProcProcures
Set ContractId = @ContractId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_AddOrgSelId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddOrgSelId]
@ContractId int,
@OrgSelId int
 AS
Update Contracts
Set
OrgIdSupplier=@OrgSelId
Where Id=@ContractId
GO
/****** Object:  StoredProcedure [dbo].[fms_AddOrg]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddOrg]
@Creator int,
@ParentOrg int,
@Name nvarchar (70),
@Desc ntext,
@Phone nvarchar (50),
@Email nvarchar (50),
@LicenseId int,
@Addr ntext,
@OrgType nvarchar (50)='na',
@LocId int=null,
@ProfileId int,
@Vis int=5
 AS
 if (@OrgType='Student Batch') or (@OrgType = 'Teacher Group')
Insert into Organizations
(Name, Description, Phone, Email, Address, LicenseId, OrgType,  LocId, CreatorService, Visibility)
values (@Name, @Desc, @Phone, @Email, @Addr, @LicenseId, @OrgType, @LocId, @Creator, @Vis )
else
Insert into Organizations
(CreatorOrg, ParentOrg, Name, Description, Phone, Email, 
Address, LicenseId, OrgType,  LocId, Visibility)
values (@Creator, @ParentOrg, @Name, @Desc, @Phone, 
@Email, @Addr, @LicenseId, @OrgType,@LocId, @Vis )
GO
/****** Object:  StoredProcedure [dbo].[fms_AddOLPSEPCPeople]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddOLPSEPCPeople]
@OrgLocId int,
@PSEPCID int,
@ClientActionsId int
 AS
Insert into OLPCPeople
(OrgLocId, PSEPCID, ClientActionsId)
Values
(@OrgLocId, @PSEPCID, @ClientActionsId)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddOLPSEPCOId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddOLPSEPCOId]
@ContractsId int,
@OrgLocId int,
@PSEPCID int
 AS
Insert into OLPCOrgs
(ContractsId, OrgLocId, PSEPCID)
Values
(@ContractsId, @OrgLocId, @PSEPCID)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddFundCurrencies]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_AddFundCurrencies]
@CurrId int,
@FundsId int,
@OrgId int,
@FY int,
@ExchangeRate decimal (20,9)
AS
Insert into FundCurrencies
(FundsId, CurrId, ExchangeRate, OrgId, FY)
Values
(@FundsId, @CurrId, @ExchangeRate, @OrgId, @FY)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddFund]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_AddFund]

@Name nvarchar(50),
@OrgId int,
@Status int,
@CurrenciesId int,
@Amt dec (20,2)=null,
@StartDate smalldatetime=null,
@EndDate smalldatetime=null
AS
Insert into Funds
(Name,  OrgId,  Status, CurrenciesId, Amount,
StartDate, EndDate)
Values
(@Name,  @OrgId,  @Status,  @CurrenciesId,  @Amt,
@StartDate, @EndDate)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddCurrencies]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddCurrencies]
@NameS nvarchar(150),
@NameP nvarchar (150), 
@Code nvarchar (3),
@Status int=null

AS

Insert into Currencies (Name,NamePlural, Code, Status)
Values (@NameS, @NameP, @Code,@Status)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddContractS]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddContractS]
@Name nvarchar(100),
@Desc nvarchar (300),
@OrgId int,
@ProcMethod int,
@StatusId int,
@PayTerms int,
@Vis int,
@Type int =null,
@OrgIdSupplier int = null,
@HHFlag int=null,
@ComDate smalldatetime=null,
@CurrId int
AS
Insert into Contracts
(Name, Description,StatusId, ProcureMethodId, OrgId, OrgIdClient,
PayTerms, Visibility, OrgIdSupplier, OrgIndFlag, HHFlag, CommitmentDate, CurrId)
values
(@Name, @Desc,@StatusId, @ProcMethod, @OrgId, @OrgId,
@PayTerms, @Vis, @OrgIdSupplier, @Type, @HHFlag, @ComDate, @CurrId)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddContractC]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddContractC]
@Name nvarchar(100),
@Desc nvarchar (300),
@OrgId int,
@ProcMethod int,
@StatusId int,
@PayTerms int,
@Vis int,
@OrgIdClient int = null
AS
Insert into Contracts
(Name, Description,StatusId, ProcureMethodId, OrgId, OrgIdSupplier,
PayTerms, Visibility,  OrgIdClient)
values
(@Name, @Desc,@StatusId, @ProcMethod, @OrgId, @OrgId,
@PayTerms, @Vis, @OrgIdClient)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddContact]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddContact]
@OrgId int,
@Name nvarchar (50), 
@Address nvarchar (50)='na',
@RegularPhone nvarchar (50), 
@CellPhone nvarchar (50), 
@Email nvarchar (50)='na',
@ProfileId int=0,
@Caller nvarchar (50)='na'

AS
if @Caller='frmContacts'
Insert into Contacts (Name,RegularPhone, CellPhone, OrgId, ProfileId)
Values (@Name,  @RegularPhone, @CellPhone, @OrgId,@ProfileId)
else
Insert into Contacts (Name, Address, RegularPhone, CellPhone, Email, OrgId)
Values (@Name, @Address, @RegularPhone, @CellPhone, @Email, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddClientAction]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddClientAction]
@PeopleId int,
@Status int,
@OrgId int
AS
Insert into ClientActions (
PeopleId,
Status,
OrgId)
Values
(
@PeopleId,
@Status,
@OrgId
)
GO
/****** Object:  StoredProcedure [dbo].[fms_AddBudget]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_AddBudget]
@OrgId int,
@Status int,
@Amt dec (20,2)=null,
@FY int=null,
@FundsId int
AS

Insert into Budgets
(OrgId,  Status, Amount,
FY, FundsId)
Values
(@OrgId,  @Status,  @Amt, @FY, @FundsId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTasksfromProfiles]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTasksfromProfiles]
@OrgId int,
@LocId int,
@ProfileSEventsId int

AS

Insert into Tasks (ProfileSEProcsId, Name, Status, OrgId, LocId)
Select ProfileSEProcs.Id, Events.Name + ' (' + Procs.Name + ')' as Name, 'Planned',
@OrgId, @LocId
From
Organizations inner join 
ProfileServiceTypes on Organizations.ProfileId=ProfileServiceTypes.ProfilesId inner join
ProfileServiceEvents on ProfileServiceTypes.Id=ProfileServiceEvents.ProfileServicesId inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
Procs on Procs.Id=ProfileSEProcs.ProcsId
Where Organizations.Id=@OrgId and 
ProfileSEProcs.ProfileSEventsId=@ProfileSEventsId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskServicesfromProfiles]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskServicesfromProfiles]
@TaskId int

AS
Insert into TaskServices ( ServiceTypesId,TaskId)
Select Distinct  ProfileSEPSSer.ServiceTypesId, @TaskId
From
Organizations inner join 
ProfileServiceTypes on Organizations.ProfileId=ProfileServiceTypes.ProfilesId inner join
ProfileServiceEvents on ProfileServiceTypes.Id=ProfileServiceEvents.ProfileServicesId inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileSEPStepTypes on ProfileSEPStepTypes.ProfileSEProcsId=ProfileSEProcs.Id inner join
ProfileSEPSSer on ProfileSEPSSer.ProfileSEPStepTypesId =ProfileSEPStepTypes.Id inner join
Tasks on Tasks.ProfileSEProcsId=ProfileSEProcs.Id
Where Tasks.Id=@TaskId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskResourcesfromProfiles]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskResourcesfromProfiles]
@TaskId int

AS
Insert into TaskResources ( ResTypesId,TaskId)
Select Distinct  ProfileSEPSRes.ResTypesId, @TaskId
From
Organizations inner join 
ProfileServiceTypes on Organizations.ProfileId=ProfileServiceTypes.ProfilesId inner join
ProfileServiceEvents on ProfileServiceTypes.Id=ProfileServiceEvents.ProfileServicesId inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileSEPStepTypes on ProfileSEPStepTypes.ProfileSEProcsId=ProfileSEProcs.Id inner join
ProfileSEPSRes on ProfileSEPSRes.ProfileSEPStepTypesId =ProfileSEPStepTypes.Id inner join
Tasks on Tasks.ProfileSEProcsId=ProfileSEProcs.Id
Where Tasks.Id=@TaskId
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStepRoles]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateStepRoles]
@RoleId int,
@StepId int
AS
Insert into StepRoles (StepId,RoleId)
Values (@StepId, @RoleId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdatePSEProcs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdatePSEProcs]
@ProfileSEventsId int,
@ProcsId int
As
Insert into ProfileSEProcs (ProcsId, ProfileSEventsId)
Values (@ProcsId, @ProfileSEventsId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateStaffing]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateStaffing]
@Id int,
@PeopleId int,
@CallerId int = 0,
@RolesId int,
@Desc ntext,
@BackupsId int
AS
Update Staffing
Set 
PeopleId=@PeopleId,
CallerId=@CallerId,
RolesId=@RolesId,
Description=@Desc,
BackupsId=@BackupsId

Where Staffing.Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateSkills]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateSkills]
@Name nvarchar(50),
@Visibility int,
@Id int

AS

UPDATE Skills SET Name = @Name, Visibility=@Visibility
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateServInputs]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateServInputs]
@ResourceOutput int,
@ResourceInput int
AS
Insert into ResourceInputs (ResourceOutput, ResourceInput)
Values (@ResourceOutput, @ResourceInput)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateServicesfromProfiles]    Script Date: 02/21/2014 15:49:40 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateServicesfromProfiles]
@OrgId int,
@Name nvarchar (50),
@ResTypeId int
AS

Insert into Services (Name, SupplierOrganization, Type)
Values (@Name, @OrgId, @ResTypeId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdUserIdsLic]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdUserIdsLic]
@OrgId int,
@UserId nvarchar (50),
@ClientOrgId int
As
Insert into UserIds (UserId, OrgId, CreationOrg, Type, Status, CreationDate, PasswordUpdate, PeopleId)
(Select @UserId,@ClientOrgId, @OrgId, '19', 'Active', GETDATE(),GETDATE(),
Max(Id) from People
Where People.OrgId=@ClientOrgId)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveActTransType]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveActTransType]
@Id int
AS
Select Id, Name
From 
ActTransTypes
Where
Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveActs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveActs]
@TransTypesId int,
@OrgId int, 
@OrgIdP int,
@LicenseId int,
@DomainId int

As
Select  AccountsId1, AccountsId2
From
ActRules inner join
Organizations on ActRules.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
TransTypesId=@TransTypesId and
(ActRules.OrgId=@OrgId or
ActRules.Visibility=1 or
(ActRules.Visibility=2 and Licenses.DomainId=@DomainId) or
(ActRules.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(ActRules.Visibility=4 and Organizations.ParentOrg=@OrgIdP))
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveActPeriodsOrg]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveActPeriodsOrg]
@OrgId int
As
SELECT Max(ActPeriods.Id) as Id, 
Convert(Char(12), StartDate,107) as StartDate,
Convert(Char(12),EndDate,107) as EndDate
FROM 
ActPeriods inner join 
ActPeriodsOrg on ActPeriods.Id=ActPeriodsOrg.ActPeriodsId inner join 
Organizations on ActPeriodsOrg.OrgId=Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id
Where 
ActPeriodsOrg.OrgId=@OrgId and 
ActPeriodsOrg.Type=null and
ActPeriodsOrg.Status=1
Group By ActPeriods.StartDate, ActPeriods.EndDate
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveActPeriods]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveActPeriods]
@Id int
As
Select Convert(Char(12), StartDate,107) as StartDate,
Convert(Char(12), EndDate,107) as EndDate
from ActPeriods
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveActBalDr]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveActBalDr]
@ActsId int,
@SubActsId  int
As
Select 
Sum(Amt)
From
ActJournals
Where
ActsDr=@ActsId and
SubActsDr=@SubActsId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveActBalCr]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveActBalCr]
@ActsId int,
@SubActsId  int
As
Select 
Sum(Amt)
From
ActJournals
Where
ActsCr=@ActsId and
SubActsCr=@SubActsId
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteProcProcure]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteProcProcure]
@Id int

AS
DELETE FROM ProcProcures where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteOrg]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteOrg]
@Id int

AS
DELETE FROM Organizations WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteFund]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteFund]
@Id int

AS
DELETE FROM Funds WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContractSuppliesStates]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_DeleteContractSuppliesStates]
@CSSId int
AS

Delete from ContractSuppliesStates
Where ContractSuppliesStates.Id=@CSSId
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContractSuppliesLocs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_DeleteContractSuppliesLocs]
@CSLId int
AS

Delete from ContractSuppliesLocs
Where ContractSuppliesLocs.Id=@CSLId
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContractSuppliesCountries]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_DeleteContractSuppliesCountries]
@CSCId int
AS

Delete from ContractSuppliesCountries
Where ContractSuppliesCountries.Id=@CSCId
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContractSupplies]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_DeleteContractSupplies]
@Id int

AS
Delete from ContractSupplies
Where ContractSupplies.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContractProcure]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteContractProcure]
@Id int

AS
Update ProcProcures
Set ContractId=null
Where ProcProcures.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContract]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteContract]
@Id int

AS
DELETE FROM Contracts where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteContact]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteContact]
@Id int =0
--@OrgId int=0,
--@ProfileId int=0,
--@Type nvarchar (10)
As
--if @Type = 'Contact'
Delete from Contacts Where Id=@Id

/*else if @Type='Profile'
Insert into Contacts (OrgId, ProfileId, CancelFlag)
Values (@OrgId, @ProfileId, '1')*/
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteClientAction]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteClientAction]
@Id int
AS
Delete
FROM  ClientActions
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdPeopleLic]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdPeopleLic]
@ClientOrgId int,
@Vis int=3
as
Insert into People
 (FName, LName, Email, WorkPhone, Address, Visibility, OrgId)
(Select FName, LName, Email, Phone, Address,@Vis, @ClientOrgId
From Organizations 
Where Id=@ClientOrgId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateUserIds]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateUserIds]
@pw nvarchar (12),
@userId nvarchar (50),
@Id int 
 AS
Update UserIds
Set UserId=@userId,
Password=@pw
Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateUserId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateUserId]
@User  nvarchar(50),
@OrgId int,
@Status nvarchar(50),
@Pd nvarchar (50),
@PeopleId int,
@Id int

AS

UPDATE UserIds SET 
UserId=@User,
OrgId=@OrgId,
Status=@Status,
Password=@Pd,
PeopleId=@PeopleId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskStaffingfromProfiles]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskStaffingfromProfiles]
@Type nvarchar (50),
@TaskId int

AS
If @Type='Staff'
Insert into TaskPeople ( RolesId,TaskId, Type)
Select Distinct  ProfileSEPSStaff.RolesId, @TaskId,  @Type
From
Organizations inner join 
ProfileServiceTypes on Organizations.ProfileId=ProfileServiceTypes.ProfilesId inner join
ProfileServiceEvents on ProfileServiceTypes.Id=ProfileServiceEvents.ProfileServicesId inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileSEPStepTypes on ProfileSEPStepTypes.ProfileSEProcsId=ProfileSEProcs.Id inner join
ProfileSEPSStaff on ProfileSEPSStaff.ProfileSEPStepTypesId =ProfileSEPStepTypes.Id inner join
Tasks on Tasks.ProfileSEProcsId=ProfileSEProcs.Id
Where Tasks.Id=@TaskId

Else if @Type='Clients'
Insert into TaskPeople ( RolesId,TaskId, Type)
Select Distinct  ProfileSEProcs.RolesId, @TaskId, @Type
From
Organizations inner join 
ProfileServiceTypes on Organizations.ProfileId=ProfileServiceTypes.ProfilesId inner join
ProfileServiceEvents on ProfileServiceTypes.Id=ProfileServiceEvents.ProfileServicesId inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
Tasks on Tasks.ProfileSEProcsId=ProfileSEProcs.Id
Where Tasks.Id=@TaskId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudgetsClosed]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudgetsClosed]
@OrgId int,
@PeriodInd int=0
AS

Select Budgets.Id,
Funds.Name,
Budgets.FY
From 
Budgets inner join
Funds on Budgets.FundsId=Funds.Id
Where Budgets.OrgId=@OrgId and Budgets.Status=2
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudgets]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudgets]
@OrgId int
AS
Select 

Budgets.Id as Id, --0
Funds.Name as SOF,--1
Budgets.FY  as FY,--2
Currencies.NamePlural as CurrCode,--3
Currencies.Id as OrgCurrId,--4
Budgets.Amount,--5
Budgets.Status as 'StatusId',--6
'Status' = 
CASE 
WHEN Budgets.Status = 0 then 'Created'
WHEN Budgets.Status = 1 then 'Open'
ELSE 'Closed'
        END
From 
Budgets inner join.
Organizations on Budgets.OrgId=Organizations.Id inner join
Funds on Budgets.FundsId=Funds.Id inner join
Currencies on Organizations.CurrId=Currencies.Id 
Where Budgets.OrgId=@OrgId and
(Budgets.Status !=3) 
Order by Budgets.FY, Funds.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudgetFY]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudgetFY]
@FundsId int, 
@FY int,
@OrgId int
AS
Select Budgets.Id
From 
Budgets
Where
Budgets.OrgId=@OrgId and FY=@FY
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudget]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudget]
@BudgetsId int
AS
Select
Funds.Name + ' (FY' + CAST(Budgets.FY AS varchar) + ')',--0 
Budgets.Status,--1 
Funds.CurrenciesId,--2 
Budgets.Amount, --3
CONVERT(varchar(10), Budgets.StartDate, 101),--4
CONVERT(varchar(10), Budgets.EndDate, 101),--5
FY--6
From 
Budgets inner join
Funds on Funds.Id=Budgets.FundsId
Where  
Budgets.Id=@BudgetsId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudCurrERs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudCurrERs]
@BudgetsId  int,
@BudCurrId int
 AS

Select  BudgetCurrencies.Id, Currencies.Id as CurrId, Currencies.Name, 
BudgetCurrencies.ExchangeRate,
BudgetCurrencies.BudgetsId

From Currencies inner  join
BudgetCurrencies on BudgetCurrencies.CurrId=Currencies.Id
Where
(BudgetCurrencies.BudgetsId=@BudgetsId) 
Union
Select  null  as Id, Currencies.Id as CurrId, Currencies.Name, 
null as ExchangeRate,
null as BudgetsId

From Currencies 
Where( Currencies.Id  not in
(Select CurrId From 
Currencies inner  join
BudgetCurrencies on BudgetCurrencies.CurrId=Currencies.Id
Where
BudgetCurrencies.BudgetsId=@BudgetsId)) and
Currencies.Id != @BudCurrId

Order by Currencies.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBORevisions]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBORevisions]
@BDOId  int
 AS
Select  BOAmts.Id, 
BOJournals.UDate as Date,
BOJournals.Description, 
BOAmts.Amount,
BOJournalsId
from 
BOAmts inner join
BOJournals on BOAmts.BOJournalsId=BOJournals.Id
Where BudOrgsId=@BDOId
Order by UDate
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBOLocs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBOLocs]
@BOId  int
 AS
Select  BOLocs.Id, Locations.Name, Locations.Id as LocId
from 
BOLocs inner join
Locations on BOLocs.LocId=Locations.Id
Where BOLocs.BOId=@BOId
GO
/****** Object:  StoredProcedure [dbo].[fms_retrieveBOJournalsId]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_retrieveBOJournalsId]
@BudgetsId int
As
SELECT 
Max(Id) from BOJournals
Where BudgetsId=@BudgetsId
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBOJournals]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBOJournals]
@Desc nvarchar (500)=null,
@BudgetsId int
As
Insert into BOJournals (Description, BudgetsId, UDate)
Values (@Desc, @BudgetsId, Getdate())
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBOJournal]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBOJournal]
@Desc nvarchar (500)=null,
@BOJournalsId int
As
Update BOJournals Set
Description=@Desc
Where Id=@BOJournalsId
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBOAmts]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBOAmts]
@BOJournalsId int,
@BOId int,
@CurrAmt dec (20,2)=null
As

Insert into BOAmts (BOJournalsId, BudOrgsId, Amount)
Values  (@BOJournalsId, @BOId, @CurrAmt)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdActJournals]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdActJournals]
@ActLedgersId int,
@OrgId int,
@Amt dec (20,2),
@ActsDr int,
@SubActsDr int=null,
@ActsCr int,
@SubActsCr int=null,
@Desc nvarchar(300)=null
As
Insert into ActJournals (
TransactionDate,
ActLedgersId,
OrgId,
Amt,
ActsDr,
SubActsDr,
ActsCr,
SubActsCr,
Description)
Values (
GetDate(),
@ActLedgersId,
@OrgId,
@Amt,
@ActsDr,
@SubActsDr,
@ActsCr,
@SubActsCr,
@Desc
)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveTSSA]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveTSSA]
@StaffActionsId int
As

SELECT
ProcProcures.Id as Id,
Procs.Name as ProcName,
Projects.Name as ProjectName,
Roles.Name as RoleName,
Budgets.Name as BudName,
ProcProcures.Qty as Hours

From
ProcProcures  inner join
PSEPStaff on ProcProcures.PSEPSID=PSEPStaff.Id inner join
Roles on Roles.Id=PSEPStaff.RolesId inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
Budgets on ProcProcures.BudgetsId=Budgets.Id  left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where  ProcProcures.ContractId=@StaffActionsId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveTSApprove]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveTSApprove]
@ProcProcuresId int
As
SELECT 
ProcProcuresId,
/* Convert (varchar, ActPeriods.StartDate, 101) as StartDate,  
Convert (varchar, ActPeriods.EndDate, 101) as EndDate,*/
convert(Char(12), StartDate,107) as StartDate,
Convert(Char(12), EndDate,107) as EndDate,
Timesheets.Id,
Timesheets.Hours, Status
From
ProcProcures inner join
Timesheets on Timesheets.ProcProcuresId=ProcProcures.Id inner join
ActPeriods on ActPeriods.Id=Timesheets.ActPeriodsId

Where  ProcProcures.Id=@ProcProcuresId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveTS]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveTS]
@StaffActionsId int,
@YrMth int
As
SELECT 
Timesheets.Id,
Timesheets.Hours,
Procs.Name as ProcName,
Projects.Name as ProjectName,
Roles.Name as RoleName,
ProcProcures.Id as ProcProcuresId,
Budgets.Name as BudName
From
ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSID=PSEPStaff.Id inner join
Roles on Roles.Id=PSEPStaff.RolesId inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId AND 
ProfileSEProcs.Id=ProcProcures.PSEPID inner join
Budgets on ProcProcures.BudgetsId=Budgets.Id  inner join
Timesheets on Timesheets.ProcProcuresId=ProcProcures.Id  left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where  ProcProcures.ContractId=@StaffActionsId and Timesheets.YrMth=@YrMth


Union

SELECT 
null as Id,
null as Hours,
Procs.Name as ProcName,
Projects.Name as ProjectName,
Roles.Name as RoleName,
ProcProcures.Id as ProcProcuresId,
Budgets.Name as BudName
From
ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSID=PSEPStaff.Id inner join
Roles on Roles.Id=PSEPStaff.RolesId inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
Budgets on ProcProcures.BudgetsId=Budgets.Id  left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where  
(ProcProcures.Id not in 
(Select ProcProcures.Id 
From 
ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSID=PSEPStaff.Id inner join
Roles on Roles.Id=PSEPStaff.RolesId inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
Timesheets on Timesheets.ProcProcuresId=ProcProcures.Id  left outer join
Projects on ProcProcures.ProjectId=Projects.Id
Where  ProcProcures.ContractId=@StaffActionsId and Timesheets.YrMth=@YrMth))
and
(ProcProcures.ContractId=@StaffActionsId)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveSOF]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveSOF]
@OrgId int
AS
Select 
Budgets.Id as Id,
Budgets.Name as Name,
Budgets.Seq as Seq
From 
Budgets
Where (Budgets.OrgId=@OrgId and
Budgets.PeriodInd = 1)

Union
Select 
0 as Id,
'Regular Budget' as Name,
0 as Seq
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveQtyMName]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveQtyMName]
@SGFlag int,
@Id int
 AS
if @SGFlag = 0
Select QtyMeasuresSer.Name
 from 
ServiceTypes inner join
QtyMeasuresSer on QtyMeasuresSer.Id=ServiceTypes.QtyMeasuresId
Where ServiceTypes.Id=@Id

else
Select QtyMeasures.Name 
from 
ResourceTypes inner join
QtyMeasures on QtyMeasures.Id=ResourceTypes.QtyMeasuresId
Where ResourceTypes.Id=@Id

SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePSEPResInvS]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrievePSEPResInvS]
@ContractId int
 AS
Select PSEPResInventory.Id, 
PSEPResInventory.Description,
Organizations.Name as 'OrgName',
Locations.Name as 'LocName',
ResourceTypes.Name as Items,
'' Locationsflag,
PSEPResInventory.Qty,
QtyMeasures.NamePlural as Measure,
PSEPResInventory.Price,
PSEPResInventory.Qty * PSEPResInventory.Price as Cost
From
PSEPResInventory left outer join
Inventory on PSEPResInventory.InventoryId=Inventory.Id inner join
Contracts on PSEPResInventory.ContractsId=Contracts.Id inner join
Organizations on.PSEPResInventory.OrgId=Organizations.Id inner join
Locations on PSEPResInventory.LocationsId=Locations.Id inner join
PSEPRes on PSEPResInventory.PSEPResId=PSEPRes.Id inner join
ResourceTypes on PSEPRes.ResTypesId=ResourceTypes.Id inner join
QtyMeasures on ResourceTypes.QtyMeasuresId=QtyMeasures.Id

Where 
PSEPResInventory.ContractsId=@ContractId and ResourceTypes.Type = 1
Order by Items, Locations.Name, Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePSEPResInvRequests]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrievePSEPResInvRequests]
@LicenseId int
 AS

Select PSEPResInventory.Id,
ResourceTypes.Name as ResTypeName,
Organizations.Name as OrgName,
Locations.Name as LocName
From
PSEPResInventory inner join
PSEPRes on PSEPResInventory.PSEPResId=PSEPRes.Id inner join
ResourceTypes on ResourceTypes.Id=PSEPRes.ResTypesId inner join
Organizations on PSEPResInventory.OrgId=Organizations.Id inner join
Locations on PSEPResInventory.LocationsId=Locations.Id 
Where Organizations.LicenseId=@LicenseId and ContractsId is null
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePSEPResInvG]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrievePSEPResInvG]
@ContractId int
 AS
Select PSEPResInventory.Id, 
PSEPResInventory.Description,
Organizations.Name as 'OrgName',
Locations.Name as 'LocName',
ResourceTypes.Name as Items,
'' Locationsflag,
PSEPResInventory.Qty,
QtyMeasures.NamePlural as Measure,
PSEPResInventory.Price,
PSEPResInventory.Qty * PSEPResInventory.Price as Cost
From
PSEPResInventory left outer join
Inventory on PSEPResInventory.InventoryId=Inventory.Id inner join
Contracts on PSEPResInventory.ContractsId=Contracts.Id inner join
Organizations on.PSEPResInventory.OrgId=Organizations.Id inner join
Locations on PSEPResInventory.LocationsId=Locations.Id inner join
PSEPRes on PSEPResInventory.PSEPResId=PSEPRes.Id inner join
ResourceTypes on PSEPRes.ResTypesId=ResourceTypes.Id inner join
QtyMeasures on ResourceTypes.QtyMeasuresId=QtyMeasures.Id

Where 
PSEPResInventory.ContractsId=@ContractId and ResourceTypes.Type = 0
Order by Items, Locations.Name, Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePSEPResInventory]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrievePSEPResInventory]
@ContractId int
 AS
Select PSEPResInventory.Id, 
PSEPResInventory.Description,
Organizations.Name as 'OrgName',
Locations.Name as 'LocName',
ResourceTypes.Name as Items,
'' Locationsflag,
PSEPResInventory.Qty,
QtyMeasures.NamePlural as Measure,
PSEPResInventory.Price,
PSEPResInventory.Qty * PSEPResInventory.Price as Cost
From
PSEPResInventory left outer join
Inventory on PSEPResInventory.InventoryId=Inventory.Id inner join
Contracts on PSEPResInventory.ContractsId=Contracts.Id inner join
OrgLocations on  PSEPResInventory.OrgLocId=OrgLocations.Id inner join
Organizations on.OrgLocations.OrgId=Organizations.Id inner join
Locations on OrgLocations.LocId=Locations.Id inner join
PSEPRes on PSEPResInventory.PSEPResId=PSEPRes.Id inner join
ResourceTypes on PSEPRes.ResTypesId=ResourceTypes.Id inner join
QtyMeasures on ResourceTypes.QtyMeasuresId=QtyMeasures.Id

Where 
PSEPResInventory.ContractsId=@ContractId 
Order by Items, Locations.Name, Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcurePay]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcurePay]
@Id  int
 AS

Select  
ProcProcures.Description, --0
Currencies.NamePlural --1

/*ProcProcures.ContractId,
SuggestedRate, 
TimeMeasure, 

SGFlag,
Qty, 
'Type'=
Case
When SGFlag =0  then ServiceTypes.Name else
ResourceTypes.Name
End*/

From 
ProcProcures inner join
Budgets on ProcProcures.BudgetsId=Budgets.Id left outer  join
Currencies on Currencies.Id=Budgets.CurrenciesId /* left outer join
PSEPSer on ProcProcures.PSEPSID=PSEPSer.Id left Outer join
PSEPRes on ProcProcures.PSEPSID=PSEPRes.Id left Outer join
ServiceTypes on PSEPSer.ServiceTypesId=ServiceTypes.Id left outer join
ResourceTypes on PSEPRes.ResTypesId=ResourceTypes.Id*/
Where ProcProcures.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcurementStatus]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcurementStatus]

 AS
Select Id, Name from ProcurementStatus
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcureInv]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcureInv]
@Id int
As
Select ProcureInventory.id, Inventory.Id as InventoryId, Inventory.Name as Goods,
Locations.Name as LocName
from 
ProcureInventory inner join
Inventory on ProcureInventory.InventoryId=Inventory.Id inner join
Locations on Inventory.LocId=Locations.Id
Where ProcureInventory.ProcurementsId=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcSReqSA]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcSReqSA]
@StaffActionId  int,
@BudgetsId int=null
 AS

Select  
'Name' = --0 
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,

'AptStatus' = --1 
Case	
When StaffActions.Status is null then 'New Appointment Request'
		When StaffActions.Status =  0 then  'Appointment Action Requested'   
		When StaffActions.Status = 1 then 'Appointment Action  in Process'   
		When StaffActions.Status = 2  then 'Appointed'
		When StaffActions.Status = 3  then 'Terminated'
		When StaffActions.Status = 4 then 'Appointment Request Rejected'
Else '??'
End,
'Salary'=--2
Case
When StaffActions.CurrId=Budgets.CurrenciesId then StaffActions.Salary
When BudgetCurrencies.ExchangeRate is null then Salary
Else StaffActions.Salary * BudgetCurrencies.ExchangeRate
End,
Currencies.NamePlural as CurrName,-- 3 
OrgSTPayGrades.SalaryMax as SalaryMax,--4 
OrgSTPayGrades.SalaryMin as SalaryMin,--5 
'SalaryPeriod' = --6 
Case
When OrgStaffTypes.SalaryPeriod is null then 'Unknown'
When OrgStaffTypes.SalaryPeriod = 0 then 'Year'
When OrgStaffTypes.SalaryPeriod = 1 then 'Month' 
When OrgStaffTypes.SalaryPeriod = 2 then 'Week'
When OrgStaffTypes.SalaryPeriod = 3  then 'Day'
When OrgStaffTypes.SalaryPeriod = 4 then 'Hour'
Else '??'
End,
OrgSTPayGrades.OvertimeRate as OvertimeRate,--7 
StaffActions.Status, -- 8
StaffActions.TypeId, --9
StaffActions.OrgId as OrgIdSA, --10
StaffActions.Id as Contractd, --11
StaffTypes.Name as StaffType, --12
Organizations.Name as OrgName,--13
BudgetCurrencies.ExchangeRate--14

From 
StaffActions inner join
OrgStaffTypes on  StaffActions.TypeId = OrgStaffTypes.Id inner join
Organizations on StaffActions.OrgId=Organizations.Id inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id left outer join
OrgSTPayGrades on OrgSTPayGrades.OrgStaffTypesId=OrgStaffTypes.Id and StaffActions.PayGradeId=OrgSTPayGrades.id left outer join
Currencies on Currencies.Id=OrgStaffTypes.CurrId left outer join
BudgetCurrencies on BudgetCurrencies.BudgetsId=@BudgetsId and BudgetCurrencies.CurrId=Currencies.Id  left outer join
Budgets on Budgets.Id=@BudgetsId left outer join
People on StaffActions.PeopleId=People.Id 
Where
(StaffActions.Id = @StaffActionId )
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcSReq]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcSReq]
@Id  int
 AS

Select  
ProcProcures.Description, --0
--ProcProcures.Qty,--1
ProcProcures.ContractId, --3
ProcProcures.TypeId, --4
--ProcProcures.Price, --5
--TimeMeasure, --6
Organizations.Name, --7
/*'Status'=--9
Case
When Budgets.Status = 1 then 'Open'
Else 'Closed'
End,*/
--ProcProcures.ReqAmount, --10
--ProcProcures.BudAmount, --11
ProcProcures.BkupFlag --12
From 
ProcProcures inner join
OrgLocations on ProcProcures.OrgLocId=OrgLocations.Id inner join
Organizations on OrgLocations.OrgId=Organizations.Id
Where ProcProcures.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcProcures]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcProcures]
@PSEPResID int,
@PSEPID int,
@BudgetsId int = null,
@OrgLocId int,
@ProjectId int=null

 AS

--**************************************
if @ProjectId is null and @BudgetsId  is not null
--**************************************
Select ProcProcures.Id, 
ProcProcures.BkupFlag, ProcProcures.Description,
'SupplierName' = 
Case
When ProcProcures.ContractId is null then  'Unidentified'
When Contracts.OrgIndFlag = 1 then People.FName + ' ' + People.LName 
When  Contracts.OrgIndFlag = 0 and Contracts.OrgIndFlag = 0 then Organizations.Name
Else '?'
End,
'Backup' = 
Case
When ProcProcures.BkupFlag is null then ''
Else  ' (Backup)'
End,
'Title' = 
Case
When ProcProcures.ContractId is null then 'Untitled'
else Contracts.Name
End,
Contracts.Id as ContractId
From
ProcProcures  left outer join
Contracts on ProcProcures.ContractId=Contracts.Id left outer join
Organizations on Contracts.OrgIdSupplier=Organizations.Id  left outer join
People on Contracts.OrgIdSupplier=People.Id 

Where 
ProcProcures.BudgetsId=@BudgetsId and
ProcProcures.PSEPSID=@PSEPResID and
ProcProcures.PSEPID=@PSEPID and
SGFlag is not null
and ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.ProjectId is null
Order by ProcProcures.BkupFlag, Organizations.Name


--**************************************
else if @ProjectId is null 
--**************************************
Select ProcProcures.Id, 
ProcProcures.BkupFlag, ProcProcures.Description,
'SupplierName' = 
Case
When ProcProcures.ContractId is null then  'Unidentified'
When Contracts.OrgIndFlag = 1 then People.FName + ' ' + People.LName 
When  Contracts.OrgIndFlag = 0 and Contracts.OrgIndFlag = 0 then Organizations.Name
Else '?'
End,
'Backup' = 
Case
When ProcProcures.BkupFlag is null then  ''
Else  ' (Backup)'
End,
 Contracts.Id as ContractId,
'Title' = 
Case
When ProcProcures.ContractId is null then  'Untitled'
else Contracts.Name
End
From
ProcProcures  left outer join
Contracts on ProcProcures.ContractId=Contracts.Id left outer join
Organizations on Contracts.OrgIdSupplier=Organizations.Id  left outer join
People on Contracts.OrgIdSupplier=People.Id 

Where 
ProcProcures.BudgetsId is null and
ProcProcures.PSEPSID=@PSEPResID and
ProcProcures.PSEPID=@PSEPID and
 SGFlag is not null
and ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.ProjectId is null
Order by ProcProcures.BkupFlag, Organizations.Name


--**************************************
Else 
--**************************************
Select ProcProcures.Id, 
ProcProcures.BkupFlag, ProcProcures.Description,
'SupplierName' = 
Case
When ProcProcures.ContractId is null then  'Unidentified'
When Contracts.OrgIndFlag = 1 then People.FName + ' ' + People.LName 
When  Contracts.OrgIndFlag = 0 and Contracts.OrgIndFlag = 0 then Organizations.Name
Else '?'
End,
'Backup' = 
Case
When ProcProcures.BkupFlag is null then  ''
Else ' (Backup)'
End,
 Contracts.Id as ContractId,
--ProcProcures.BOId,
'Title' = 
Case
When ProcProcures.ContractId is null then  'Untitled'
else Contracts.Name
End
From
ProcProcures  left outer join
Contracts on ProcProcures.ContractId=Contracts.Id left outer join
Organizations on Contracts.OrgIdSupplier=Organizations.Id left outer join 
People on Contracts.OrgIdSupplier=People.Id

Where 

ProcProcures.PSEPSID=@PSEPResID and 
ProcProcures.PSEPID=@PSEPID and
SGFlag is not null
and ProcProcures.OrgLocId=@OrgLocId  and
ProcProcures.ProjectId=@ProjectId
Order by ProcProcures.BkupFlag, Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcProcure]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcProcure]
@Id  int
--@Mode nvarchar (50)='Display'
 AS

Select  ProcProcures.Description,--0
ProcProcures.Qty,--1
ProcProcures.Price,--2
'ContractId'=--3
Case
When ProcProcures.ContractId is null then null
Else ProcProcures.ContractId
End,
'ProcStatus'=--12
Case
When ProcProcures.StatusId = 1 then 'Requested'
When ProcProcures.StatusId = 2 then 'Charged'
When ProcProcures.StatusId = 3 then 'Cancelled'
Else 'Requested'
End,--4
Currencies.Name, --5
Organizations.Name, --6
Budgets.Name, --7
'Status'=--8
Case
When Budgets.Status = 1 then 'Open'
Else 'Closed'
End,
ProcProcures.ReqAmount,--9
ProcProcures.BudAmount,--10
ProcProcures.BkupFlag --11

From ProcProcures inner join
OrgLocations on ProcProcures.OrgLocId=OrgLocations.Id inner join 
Organizations on OrgLocations.OrgId=Organizations.Id left outer join
Budgets on ProcProcures.BudgetsId=Budgets.Id left outer join
Currencies on Budgets.CurrenciesId=Currencies.Id left outer join 
Contracts on ProcProcures.ContractId=Contracts.Id 
Where ProcProcures.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcPay]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcPay]
@Id  int
 AS

Select  
Payments.PaymentAmount, --0
Payments.Status,
Payments.ReqDate
From 
Payments
Where Payments.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveProcMethods]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveProcMethods]

 AS
Select Id, Name from ProcurementMethods
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePayTerms]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrievePayTerms]

 AS
Select Id, Name from PaymentTerms
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePayMethods]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrievePayMethods]

 AS
Select Id, Name from PayMethods
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrievePayments]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrievePayments]
@ProcProcuresId  int
 AS

Select 
Payments.Id,
Payments.ReqDate, 
PaymentAmount as PaymentAmt,
Currencies.NamePlural as CurName,
'Status'=
Case
When Payments.Status is null then 'Requested'
Else 'Paid'
End

From 
Payments inner join
ProcProcures on Payments.ProcProcuresId=ProcProcures.Id inner join
Budgets on Budgets.Id=ProcProcures.BudgetsId inner join
Currencies on Budgets.CurrenciesId=Currencies.Id
Where ProcProcures.Id=@ProcProcuresId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveOrgs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveOrgs]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int

AS

Select Organizations.Id, 
Organizations.Name, Organizations.CreatorOrg
from
Organizations inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where 
Organizations.Id=@OrgId or
Organizations.CreatorOrg=@OrgId or
Organizations.Visibility='1' 
or (Organizations.Visibility='2' and Licenses.DomainId=@DomainId)
or (Organizations.Visibility='3' and Organizations.LicenseId=@LicenseId)
or (Organizations.Visibility='4' and Organizations.ParentOrg=@OrgIdP)
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveOrganizations]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveOrganizations]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int,
@Type int = null

AS
if @Type is null

Select Organizations.Id, 
Organizations.Name, Organizations.CreatorOrg
from
Organizations inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 Organizations.ParentOrg != @OrgIdP and 
(Organizations.Id=@OrgId or
Organizations.CreatorOrg=@OrgId or
Organizations.Visibility='1' 
or (Organizations.Visibility='2' and Licenses.DomainId=@DomainId)
or (Organizations.Visibility='3' and Organizations.LicenseId=@LicenseId)
or (Organizations.Visibility='4' and Organizations.ParentOrg=@OrgIdP))
Order by Organizations.Name

Else if @Type = 1
Select Organizations.Id, 
Organizations.Name, Organizations.CreatorOrg
from
Organizations inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where 
 Organizations.ParentOrg = @OrgIdP and
(Organizations.Id=@OrgId or
Organizations.CreatorOrg=@OrgId or
Organizations.Visibility='1' 
or (Organizations.Visibility='2' and Licenses.DomainId=@DomainId)
or (Organizations.Visibility='3' and Organizations.LicenseId=@LicenseId)
or (Organizations.Visibility='4' and Organizations.ParentOrg=@OrgIdP))
Order by Organizations.Name

Else
Select Organizations.Id, 
Organizations.Name, Organizations.CreatorOrg
from
Organizations inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where 
 Organizations.ParentOrg = @OrgIdP and
(Organizations.Id=@OrgId or
Organizations.CreatorOrg=@OrgId or
Organizations.Visibility='1' 
or (Organizations.Visibility='2' and Licenses.DomainId=@DomainId)
or (Organizations.Visibility='3' and Organizations.LicenseId=@LicenseId)
or (Organizations.Visibility='4' and Organizations.ParentOrg=@OrgIdP))
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveOrg]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveOrg]
@Id int
AS

SELECT   
Organizations.Name, --0
Organizations.Description, --1
Phone, --2
Email, --3
Address, --4
Organizations.LocId,  --5
Organizations.Visibility, --6
Organizations.ProfileId --7
FROM Organizations
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveOLPSEPDesc]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_RetrieveOLPSEPDesc]
@Id int
AS
Select ProcProcures.Description from ProcProcures
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveFundStatus]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveFundStatus]
@OrgId int, 
@OrgIdP int,
@LicenseId int,
@DomainId int
AS
Select FundStatus.Id,  FundStatus.Name

From 
FundStatus  inner join
Organizations on FundStatus.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 FundStatus.OrgId=@OrgId or
FundStatus.Visibility=1 or
(FundStatus.Visibility=2 and Licenses.DomainId=@DomainId) or
(FundStatus.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(FundStatus.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveFundsAll]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveFundsAll]
@OrgId int, 
@OrgIdP int,
@LicenseId int,
@DomainId int
AS
Select Funds.Id,  Funds.Name

From 
Funds  inner join
Organizations on Funds.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 Funds.OrgId=@OrgId or
Funds.Visibility=1 or
(Funds.Visibility=2 and Licenses.DomainId=@DomainId) or
(Funds.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Funds.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveFunds]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveFunds]
@OrgId int
AS
Select Id, Name, Status, Visibility
From 
Funds
Where
 Funds.OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveFundOrgs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveFundOrgs]
@OrgId int
AS
Select 
Funds.Id as Id,
Funds.Name Name
From 
FundOrgs inner join 
Funds on FundOrgs.FundsId=Funds.Id 
Where FundOrgs.OrgId=@OrgId 
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveFund]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveFund]
@FundsId int
AS
Select 
Name,--0
Status, --1
Visibility,--2
CurrenciesId,--3
Amount,--4
CONVERT(varchar(10), StartDate, 101),--4
CONVERT(varchar(10), EndDate, 101)--5
From 
Funds
Where
Funds.Id=@FundsId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveFiscalYears]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveFiscalYears]
@OrgId int, 
@OrgIdP int,
@LicenseId int,
@DomainId int
AS
Select FiscalYears.Id,  FiscalYears.Name

From 
FiscalYears  inner join
Organizations on FiscalYears.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 FiscalYears.OrgId=@OrgId or
FiscalYears.Visibility=1 or
(FiscalYears.Visibility=2 and Licenses.DomainId=@DomainId) or
(FiscalYears.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(FiscalYears.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveCurrencies]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveCurrencies]
--@OrgId int, 
--@OrgIdP int,
--@LicenseId int,
--@DomainId int
AS
Select Currencies.Id,  Currencies.Name,
Currencies.NamePlural, Currencies.Code, 
'Status'=
Case
When Currencies.Status is null then 0 else 1
End
From 
Currencies--  inner join
/*Organizations on Currencies.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 Currencies.OrgId=@OrgId or
Currencies.Visibility=1 or
(Currencies.Visibility=2 and Licenses.DomainId=@DomainId) or
(Currencies.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Currencies.Visibility=4 and Organizations.ParentOrg=@OrgIdP)*/
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractSuppliesStates]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[fms_RetrieveContractSuppliesStates]
@ContractSuppliesId int,
@CountriesId int
As
SELECT States.Id, States.Name, 
ContractSuppliesStates.LocsFlag,
ContractSuppliesStates.Id as CSSId
from 
ContractSuppliesStates inner join
States on ContractSuppliesStates.StatesId= States.Id 
Where  
ContractSuppliesId=@ContractSuppliesId and
States.CountriesId=@CountriesId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractSuppliesLocs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractSuppliesLocs]
@ContractSuppliesId int,
@StatesId int=null,
@CountriesId int=null
As
if @StatesId is not null

SELECT Locations.Id, Locations.Name,
'' as LocsFlag,
ContractSuppliesLocs.Id as CSSId
from 
ContractSuppliesLocs inner join
Locations on ContractSuppliesLocs.LocsId= Locations.Id 
Where  
ContractSuppliesId=@ContractSuppliesId and
Locations.StatesId=@StatesId

else


SELECT Locations.Id, Locations.Name,
'' as LocsFlag,
ContractSuppliesLocs.Id as CSSId
from 
ContractSuppliesLocs inner join
Locations on ContractSuppliesLocs.LocsId= Locations.Id 
Where  
ContractSuppliesId=@ContractSuppliesId and
Locations.CountriesId=@CountriesId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractSuppliesCountries]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractSuppliesCountries]
@ContractSuppliesId int
As
SELECT Countries.Id, Countries.Name, 
ContractSuppliesCountries.StatesFlag,
StateTypes.Name as StateType,
ContractSuppliesCountries.Id as CSCId,
Countries.LocsFlag
from 
ContractSuppliesCountries inner join
Countries on ContractSuppliesCountries.CountriesId= Countries.Id inner join
StateTypes on Countries.StateTypesId=StateTypes.Id
Where  
ContractSuppliesId=@ContractSuppliesId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractSupplies]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractSupplies]
@ContractId int
 AS
Select ContractSupplies.Id, 
ContractSupplies.Description,
'' as 'OrgName',
'' as 'LocName',
ResourceTypes.Name as Items,
LocationsFlag,

'' as Qty,
'' as Measure,
'' as Price,
'' as Total,
'' as Budget 


From
ContractSupplies inner join
Contracts on ContractSupplies.ContractsId=Contracts.Id inner join
ResourceTypes on ContractSupplies.ResourceTypesId=ResourceTypes.Id
Where 
ContractSupplies.ContractsId=@ContractId 
Order by Items
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractsSupplier]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractsSupplier]
@OrgId int,
@OrgIdP int=null,
@LicenseId int=null,
@DomainId int=null,
@HHFlag int=null
AS
if @HHFlag is null and @LicenseId=null
Select Contracts.Id, Contracts.StatusId, 
ContractsStatus.Name as Status,
Contracts.Name,
Contracts.OrgIdSupplier,
'SupplierName'=
Case
When Contracts.OrgIdSupplier is null then 'Supplier not Identified' 
When Contracts.OrgIndFlag = 0 then OrgSupplier.Name
Else People.Fname + ' ' + People.LName
End,
Contracts.OrgId,
--Currencies.Name as CurrName
'Here' as CurrName
From Contracts inner join
Currencies on Contracts.CurrId=Currencies.Id inner join
ContractsStatus on Contracts.StatusId=ContractsStatus.Id  inner join
Organizations on Contracts.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id left outer join
Organizations OrgSupplier on Contracts.OrgIdSupplier=OrgSupplier.Id left outer join
People on  Contracts.OrgIdSupplier=People.Id
Where Contracts.OrgIdClient=@OrgId and Contracts.HHFlag is null
Order by SupplierName, ContractsStatus.Seq

Else if @HHFlag is null
Select Contracts.Id, Contracts.StatusId, 
ContractsStatus.Name as Status,
Contracts.Name,
Organizations.Id as OrgIdSupplier,
Organizations.Name as SupplierName,
Contracts.OrgId, 
'' as CurrName
From Contracts left outer join
ContractsStatus on Contracts.StatusId=ContractsStatus.Id  left outer join
Organizations on Contracts.OrgIdSupplier=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where Contracts.HHFlag is null and
(Contracts.OrgId= @OrgId or
Contracts.Visibility=1 or
(Contracts.Visibility=2 and Licenses.DomainId=@DomainId) or
(Contracts.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Contracts.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
)
Order by Organizations.Name, ContractsStatus.Seq

else if @LicenseId=null
Select Contracts.Id, Contracts.StatusId, 
ContractsStatus.Name as Status,
Contracts.Name,
Contracts.OrgIdSupplier,
'SupplierName'=
Case
When Contracts.OrgIdSupplier is null then 'Supplier not Identified' 
When Contracts.OrgIndFlag = 0 then OrgSupplier.Name
Else People.Fname + ' ' + People.LName
End,
Contracts.OrgId,
Currencies.Name as CurrName
From Contracts inner join
Currencies on Contracts.CurrId=Currencies.Id inner join
ContractsStatus on Contracts.StatusId=ContractsStatus.Id  inner join
Organizations on Contracts.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id left outer join
Organizations OrgSupplier on Contracts.OrgIdSupplier=OrgSupplier.Id left outer join
People on  Contracts.OrgIdSupplier=People.Id
Where Contracts.OrgIdClient=@OrgId and Contracts.HHFlag=@HHFlag
Order by SupplierName, ContractsStatus.Seq

Else 
Select Contracts.Id, Contracts.StatusId, 
ContractsStatus.Name as Status,
Contracts.Name,
Organizations.Id as OrgIdSupplier,
Organizations.Name as SupplierName,
Contracts.OrgId, 
'' as CurrName
From Contracts left outer join
ContractsStatus on Contracts.StatusId=ContractsStatus.Id  left outer join
Organizations on Contracts.OrgIdSupplier=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where Contracts.HHFlag=@HHFlag and
(Contracts.OrgId=@OrgId or
Contracts.Visibility=1 or
(Contracts.Visibility=2 and Licenses.DomainId=@DomainId) or
(Contracts.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Contracts.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
)
Order by Organizations.Name, ContractsStatus.Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractsStatus]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractsStatus]

 AS
Select Id, Name from ContractsStatus
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractsProvider]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractsProvider]
@OrgId int
AS
Select Contracts.Id, Contracts.StatusId, 
ContractsStatus.Name as Status,
Contracts.Name,
Contracts.OrgIdSupplier,
'SupplierName'=
Case
When Contracts.OrgIdSupplier is null then 'Supplier not Identified' 
When Contracts.OrgIndFlag = 0 then OrgSupplier.Name
Else People.Fname + ' ' + People.LName
End,
Contracts.OrgId,
Currencies.NamePlural as CurrName
From Contracts inner join
Currencies on Contracts.CurrId=Currencies.Id inner join
ContractsStatus on Contracts.StatusId=ContractsStatus.Id  inner join
Organizations on Contracts.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id left outer join
Organizations OrgSupplier on Contracts.OrgIdSupplier=OrgSupplier.Id left outer join
People on  Contracts.OrgIdSupplier=People.Id
Where Contracts.OrgId=@OrgId and Contracts.HHFlag is null
Order by SupplierName, ContractsStatus.Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractsClient]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractsClient]
@OrgId int
AS
Select Contracts.Id, Contracts.StatusId, 
ContractsStatus.Name as Status,
Contracts.Name,
Organizations.Id as OrgIdClient,
Organizations.Name as ClientName,
Contracts.OrgId
From Contracts inner join
ContractsStatus on Contracts.StatusId=ContractsStatus.Id  left outer join
Organizations on Contracts.OrgIdClient=Organizations.Id
Where
Contracts.OrgIdSupplier=@OrgId
Order by Organizations.Name, ContractsStatus.Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContractC]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContractC]
@Id  int
 AS

Select  Contracts.Id,  
Contracts.Name,
Contracts.Description,
Contracts.StatusId,
Contracts.Visibility,
Contracts.OrgId,--5
Contracts.OrgIdClient, --6
Contracts.PayTerms,
Contracts.ProcureMethodId,
Organizations.Name as ClientName--9
From Contracts left outer  join
Organizations on Organizations.Id=Contracts.OrgIdClient
Where Contracts.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContract]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContract]
@Id  int
 AS

Select  Contracts.Id,  
Contracts.Name,
Contracts.Description,
Contracts.StatusId,
Contracts.Visibility,
Contracts.OrgId,--5
Contracts.OrgIdSupplier, --6
Contracts.PayTerms,
Contracts.ProcureMethodId,
'SupplierName' =--9
Case
When Contracts.OrgIdSupplier is null Then 'Unidentified'
When Contracts.OrgIndFlag = 0 Then  
Organizations.Name
Else People.FName + ' ' +  People.LName
End,
ContractsStatus.Name as Status,--10
Contracts.OrgIndFlag as Type,--11
Convert(CHAR(128), Contracts.CommitmentDate, 1 ) as CommitmentDate,
Contracts.CurrId as CurrId
 --12
From Contracts
inner join ContractsStatus on Contracts.StatusId= ContractsStatus.Id
left outer  join
Organizations on Organizations.Id=Contracts.OrgIdSupplier
left outer join 
People on  .People.Id=Contracts.OrgIdSupplier 
Where Contracts.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveContacts]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveContacts]
@OrgId int
AS
Select Contacts.OrgId, Contacts.Id, Contacts.Name, Contacts.CellPhone,Contacts.Address, Contacts.Email, 
               Contacts.RegularPhone, Contacts.ProfileId, 'Contact' as Type
from 
Contacts where orgid =@OrgId-- and CancelFlag is null 

/*union
Select @OrgId as OrgId,'0', Profiles.Name, null, null,null, null, Profiles.Id, 'Profile'
from 
Profiles
Where (Id=51 --i.e. doctor
or Id=31) -- i.e. police emergency 
and Id not in (select profileid from contacts where orgid =@OrgId)

union
Select @OrgId as OrgId,'0', Profiles.Name, null, null,null, null, Profiles.Id, 'Profile'
FROM 
 ProfileOrg inner join 
ProfileServices on ProfileOrg.ProfileId=ProfileServices.ProfileId inner join 
ProfileServiceLocs on ProfileServices.Id=ProfileServiceLocs.ProfileServicesId inner join
ProfileServiceProcs on ProfileServiceLocs.Id=ProfileServiceProcs.ProfileServiceLocsId inner join
ProfileSPResTypes on ProfileSPResTypes.ProfileServiceProcId = ProfileServiceProcs.Id inner join
ResourceTypes on ProfileSPResTypes.ResTypeId=ResourceTypes.Id inner join
Profiles on Profiles.Id=ResourceTypes.ProfileId  
Where ProfileOrg.OrgId=@OrgId and Profiles.Id not in (select profileid from contacts where orgid =@OrgId)*/
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveClientActions]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveClientActions]
@OrgId int
As

SELECT  ClientActions.Id,
ClientActions.Status, 
PeopleId, FName + ' ' + LName as  Name
From
ClientActions inner join 
People on ClientActions.PeopleId=People.Id
Where ClientActions.OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveClientAction]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveClientAction]
@Id int
As

SELECT  
PeopleId,
People.FName + ' ' + People.LName,
ClientActions.Status
From
ClientActions inner join 
People on ClientActions.PeopleId=People.Id
Where ClientActions.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudTypes]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudTypes]
@OrgId int, 
@OrgIdP int,
@LicenseId int,
@DomainId int
AS
Select BudgetTypes.Id,  BudgetTypes.Name

From 
BudgetTypes  inner join
Organizations on BudgetTypes.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 BudgetTypes.OrgId=@OrgId or
BudgetTypes.Visibility=1 or
(BudgetTypes.Visibility=2 and Licenses.DomainId=@DomainId) or
(BudgetTypes.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(BudgetTypes.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudStatus]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudStatus]
@OrgId int, 
@OrgIdP int,
@LicenseId int,
@DomainId int,
@BRS int
AS
if @BRS = 1
Select BudStatus.Id,  BudStatus.Name

From 
BudStatus  inner join
Organizations on BudStatus.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
 BudStatus.OrgId=@OrgId or
BudStatus.Visibility=1 or
(BudStatus.Visibility=2 and Licenses.DomainId=@DomainId) or
(BudStatus.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(BudStatus.Visibility=4 and Organizations.ParentOrg=@OrgIdP)

else

Select BudStatus.Id,  BudStatus.Name

From 
BudStatus  inner join
Organizations on BudStatus.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
  
BudStatus.OrgId=@OrgId and BudStatus.Name <> 'Open' or
BudStatus.Visibility=1 and BudStatus.Name <> 'Open' or
(BudStatus.Visibility=2 and BudStatus.Name <> 'Open' and Licenses.DomainId=@DomainId) or
(BudStatus.Visibility=3 and BudStatus.Name <> 'Open' and Organizations.LicenseId=@LicenseId) or
(BudStatus.Visibility=4 and BudStatus.Name <> 'Open' and Organizations.ParentOrg=@OrgIdP)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudStaffWS]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudStaffWS]

--@PSEPSID int,
@PSEPID int,
@OrgLocId int,
@BudgetsId int = null,
@ProjectId int=null
AS
--if @ProjectId is null
Select 
ProcProcures.Id,
Roles.Name as Role,
'StaffName'=
Case
When People.Id is null then 'Unidentified'
Else People.FName + ' ' + People.LName
End,
BudAmount,
ReqAmount

From ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSId=PSEPStaff.Id inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
StaffActions on ProcProcures.ContractId=StaffActions.Id inner join
People on StaffActions.PeopleId=People.Id inner join
OrgStaffTypes on StaffActions.TypeId = OrgStaffTypes.Id  inner join
Roles on PSEPStaff.RolesId = Roles.Id inner join
Budgets on ProcProcures.BudgetsId=Budgets.Id  left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where (ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BudgetsId=@BudgetsId and
ProfileSEProcs.Id = @PSEPID and
ProjectId is null and @ProjectId is null) and
ProcProcures.SGFlag is null 
or
 (ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BudgetsId=@BudgetsId and
ProfileSEProcs.Id = @PSEPID and
ProcProcures.SGFlag is null and
ProjectId =@ProjectId)
/*
Union

Select 
ProcProcures.Id, 
'TaskName' = 
Case
When Projects.Name is null then Procs.Name
else Projects.Name
End,
'Unidentified' as 'StaffName',
BudAmount,
 
'Qty' =
Case
When ProcProcures.Qty  is null then 0
Else ProcProcures.Qty
End,


'QtyMeasure'  = 

Case
When ProcProcures.TimeMeasure is null then 'Unknown'
When ProcProcures.TimeMeasure = 0 then 'Years'
When ProcProcures.TimeMeasure = 1 then 'Months' 
When ProcProcures.TimeMeasure = 2  then 'Weeks'
When ProcProcures.TimeMeasure = 3 then 'Days'
When ProcProcures.TimeMeasure = 3 then 'Hours'
Else '??'
End,
'PriceHours' =
Case
When OrgStaffTypes.SalaryPeriod is null then 0 
When OrgStaffTypes.SalaryPeriod = 0 then 12 * 4 * 5 * 8
When OrgStaffTypes.SalaryPeriod = 1 then 4 * 5 * 8
When OrgStaffTypes.SalaryPeriod = 2  then 5 * 8 
When OrgStaffTypes.SalaryPeriod = 3 then 8 
When OrgStaffTypes.SalaryPeriod = 4 then 1 
Else 0
End,
'QtyHours' =
Case
When ProcProcures.TimeMeasure is null then 0
When  ProcProcures.TimeMeasure  = 0 then 12 * 4 * 5 * 8
When  ProcProcures.TimeMeasure = 1 then 4 * 5 * 8
When ProcProcures.TimeMeasure  = 2  then 5 * 8
When  ProcProcures.TimeMeasure = 3 then 8
When ProcProcures.TimeMeasure  = 4 then 1
Else  0
End,
'Price' =
Case
When ProcProcures.SuggestedRate is null then 0
Else ProcProcures.SuggestedRate
End,
'ExchangeRate' = 
Case
When  BudgetCurrencies.ExchangeRate is null then 1
else  BudgetCurrencies.ExchangeRate
End

From ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSId=PSEPStaff.Id inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
OrgStaffTypes on ProcProcures.TypeId = OrgStaffTypes.Id  inner join
Currencies on OrgStaffTypes.CurrId=Currencies.Id inner join
Roles on PSEPStaff.RolesId = Roles.Id inner join
BudOrgs on ProcProcures.BOId=BudOrgs.Id inner join 
Budgets on BudOrgs.BudgetsId=Budgets.Id left outer join
BudgetCurrencies on Budgets.Id=BudgetCurrencies.BudgetsId 
and OrgStaffTypes.CurrId =BudgetCurrencies.CurrId left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where 
(ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BOId=@BOId and
PSEPSID=@PSEPSID and
--OrgStaffTypes.Id=@OrgStaffTypesId  and
ProcProcures.SGFlag  is null and -- SGFlag condition is changed from 3 
ProjectId is null)--ProjectId condition is new)

or 
(ProcProcures.OrgLocId =@OrgLocId and
ProcProcures.BOId=@BOId and
PSEPSID=@PSEPSID and
ProcProcures.SGFlag is null and
--OrgStaffTypes.Id is null and
ProjectId is null)--ProjectId condition is new)

--*************************************************
else --I.E. IF PROJECT ID IS NOT NULL
--*************************************************

Select 
ProcProcures.Id, 
'TaskName' = 
Case
When Projects.Name is null then Procs.Name
else Projects.Name
End,
'StaffName'=
Case
When People.Id is null then 'Unidentified'
Else People.FName + ' ' + People.LName
End,
BudAmount,
'Qty' =
Case
When ProcProcures.Qty  is null then 0
Else ProcProcures.Qty
End,

'QtyMeasure'  = 

Case
When ProcProcures.TimeMeasure is null then 'Unknown'
When ProcProcures.TimeMeasure = 0 then 'Years'
When ProcProcures.TimeMeasure = 1 then 'Months' 
When ProcProcures.TimeMeasure = 2  then 'Weeks'
When ProcProcures.TimeMeasure = 3 then 'Days'
When ProcProcures.TimeMeasure = 4 then 'Hours'
Else '??'
End,
'PriceHours' =
Case
When OrgStaffTypes.SalaryPeriod is null then 0 
When OrgStaffTypes.SalaryPeriod = 0 then 12 * 4 * 5 * 8
When OrgStaffTypes.SalaryPeriod = 1 then 160
When OrgStaffTypes.SalaryPeriod = 2  then 40 
When OrgStaffTypes.SalaryPeriod = 3 then 8 
When OrgStaffTypes.SalaryPeriod = 4 then 1 
Else 0
End,
'QtyHours' =
Case
When ProcProcures.TimeMeasure is null then 0
When  ProcProcures.TimeMeasure  = 0 then 12 * 4 * 5 * 8
When  ProcProcures.TimeMeasure = 1 then 4 * 5 * 8
When ProcProcures.TimeMeasure  = 2  then 5 * 8
When  ProcProcures.TimeMeasure = 3 then 8
When ProcProcures.TimeMeasure  = 4 then 1
Else  0
End,
'Price' = 
Case
When StaffActions.Salary is null then 0 else  StaffActions.Salary
End,

'ExchangeRate' = 
Case
When  BudgetCurrencies.ExchangeRate is null then 1
else  BudgetCurrencies.ExchangeRate
End
From ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSId=PSEPStaff.Id inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
StaffActions on ProcProcures.ContractId=StaffActions.Id inner join
People on StaffActions.PeopleId=People.Id inner join
OrgStaffTypes on StaffActions.TypeId = OrgStaffTypes.Id  inner join
Currencies on OrgStaffTypes.CurrId=Currencies.Id inner join
Roles on PSEPStaff.RolesId = Roles.Id inner join
BudOrgs on ProcProcures.BOId=BudOrgs.Id inner join 
Budgets on BudOrgs.BudgetsId=Budgets.Id left outer join
BudgetCurrencies on Budgets.Id=BudgetCurrencies.BudgetsId
and OrgStaffTypes.CurrId =BudgetCurrencies.CurrId left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where (ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BOId=@BOId and
ProcProcures.SGFlag is null and
PSEPSID=@PSEPSID and

--OrgStaffTypes.Id=@OrgStaffTypesId and
ProjectId = @ProjectId)--ProjectId condition is new
or

(ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BOId=@BOId and
ProcProcures.SGFlag  is null and -- SGFlag condition is changed from 3 
OrgStaffTypes.Id is null and
PSEPSID=@PSEPSID and
ProjectId = @ProjectId)--ProjectId condition is new)

Union

Select 
ProcProcures.Id, 
'TaskName' = 
Case
When Projects.Name is null then Procs.Name
else Projects.Name
End,
'Unidentified' as 'StaffName',
BudAmount,
 
'Qty' =
Case
When ProcProcures.Qty  is null then 0
Else ProcProcures.Qty
End,


'QtyMeasure'  = 

Case
When ProcProcures.TimeMeasure is null then 'Unknown'
When ProcProcures.TimeMeasure = 0 then 'Years'
When ProcProcures.TimeMeasure = 1 then 'Months' 
When ProcProcures.TimeMeasure = 2  then 'Weeks'
When ProcProcures.TimeMeasure = 3 then 'Days'
When ProcProcures.TimeMeasure = 3 then 'Hours'
Else '??'
End,
'PriceHours' =
Case
When OrgStaffTypes.SalaryPeriod is null then 0 
When OrgStaffTypes.SalaryPeriod = 0 then 12 * 4 * 5 * 8
When OrgStaffTypes.SalaryPeriod = 1 then 4 * 5 * 8
When OrgStaffTypes.SalaryPeriod = 2  then 5 * 8 
When OrgStaffTypes.SalaryPeriod = 3 then 8 
When OrgStaffTypes.SalaryPeriod = 4 then 1 
Else 0
End,
'QtyHours' =
Case
When ProcProcures.TimeMeasure is null then 0
When  ProcProcures.TimeMeasure  = 0 then 12 * 4 * 5 * 8
When  ProcProcures.TimeMeasure = 1 then 4 * 5 * 8
When ProcProcures.TimeMeasure  = 2  then 5 * 8
When  ProcProcures.TimeMeasure = 3 then 8
When ProcProcures.TimeMeasure  = 4 then 1
Else  0
End,
'Price' =
Case
When ProcProcures.SuggestedRate is null then 0
Else ProcProcures.SuggestedRate
End,
'ExchangeRate' = 
Case
When  BudgetCurrencies.ExchangeRate is null then 1
else  BudgetCurrencies.ExchangeRate
End

From ProcProcures inner join
PSEPStaff on ProcProcures.PSEPSId=PSEPStaff.Id inner join
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId inner join
OrgStaffTypes on ProcProcures.TypeId = OrgStaffTypes.Id  inner join
Currencies on OrgStaffTypes.CurrId=Currencies.Id inner join
Roles on PSEPStaff.RolesId = Roles.Id inner join
BudOrgs on ProcProcures.BOId=BudOrgs.Id inner join 
Budgets on BudOrgs.BudgetsId=Budgets.Id left outer join
BudgetCurrencies on Budgets.Id=BudgetCurrencies.BudgetsId 
and OrgStaffTypes.CurrId =BudgetCurrencies.CurrId left outer join
Projects on ProcProcures.ProjectId=Projects.Id

Where 
(ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BOId=@BOId and
PSEPSID=@PSEPSID and
--OrgStaffTypes.Id=@OrgStaffTypesId  and
ProcProcures.SGFlag  is null and -- SGFlag condition is changed from 3 
ProjectId = @ProjectId)--ProjectId condition is new)

or 
(ProcProcures.OrgLocId =@OrgLocId and
ProcProcures.BOId=@BOId and
PSEPSID=@PSEPSID and
ProcProcures.SGFlag is null and
--OrgStaffTypes.Id is null and
ProjectId = @ProjectId)--ProjectId condition is new)*/
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudSerWS]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudSerWS]
@PSEPID int,
@OrgLocId int,
@BudgetsId int = null,
@ProjectId int=null
AS
Select 
ProcProcures.Id, 
ResourceTypes.Name as ResTypeName,
'ContractTitle'=
Case
When Contracts.Id is null then 'Unidentified'
Else Contracts.Name
End,
ProcProcures.BudAmount, 
ProcProcures.ReqAmount

From 
ProcProcures inner join 
Budgets on ProcProcures.BudgetsId=Budgets.Id inner join
PSEPRes on ProcProcures.PSEPSId=PSEPRes.Id inner join
ResourceTypes on ResourceTypes.Id=PSEPRes.ResTypesId inner join
Procs on PSEPRes.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.Id=ProfileSEProcs.ProcsId  left outer join
Contracts on ProcProcures.ContractId=Contracts.Id left outer join
Projects on ProcProcures.ProjectId=Projects.Id


Where (ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BudgetsId=@BudgetsId and
ProfileSEProcs.Id = @PSEPID and
ProcProcures.SGFlag is not null and
ProjectId is null and @ProjectId is null)
or
 (ProcProcures.OrgLocId=@OrgLocId and
ProcProcures.BudgetsId=@BudgetsId and
ProfileSEProcs.Id = @PSEPID and
ProcProcures.SGFlag is not null and
ProjectId =@ProjectId and @ProjectId is not null)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudProjProcs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudProjProcs]
@ProjectsId int=null,
@BudOLServicesId int,
@ProfileSEProcsId int,
@OrgId int,
@LocationsId int
AS
if @ProjectsId is not null
Select BudAmt from
BudProjProcs
Where
ProjectsId=@ProjectsId and
BudOLServicesId=@BudOLServicesId and
ProfileSEProcsId=@ProfileSEProcsId and
BudProjProcs.OrgId = @OrgId and BudProjProcs.LocationsId = @LocationsId 

Else
Select BudAmt from
BudProjProcs
Where
ProjectsId is null and
BudOLServicesId=@BudOLServicesId and
ProfileSEProcsId=@ProfileSEProcsId and
BudProjProcs.OrgId = @OrgId and BudProjProcs.LocationsId = @LocationsId
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateTimetable]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateTimetable]
@Id int,
@CompletionDate smalldatetime=null,
@Status nvarchar (10)
as
Update Timetables
Set
CompletionDate=@CompletionDate,
Status=@Status
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteBudget]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteBudget]
@Id int

AS
DELETE FROM Budgets WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSEProcsSeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileSEProcsSeqNo]
@Id int,
@Seq int = 99
AS
Update ProfileSEProcs
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSEProcs]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileSEProcs]
@Id int,
@ProcsId int,
@Name varchar (300),
@Timetables int,
@ProjectTypesId int,
@Costs int
As

Update ProfileSEProcs 
Set 
ProcsId=@ProcsId,
Name=@Name,
ProjectTypesId=@ProjectTypesId,
Timetables=@Timetables,
Costs=@Costs
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProject]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProject]
@Id int
AS
Delete from Projects
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateStep]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateStep]
@Name nvarchar(80),
@Desc nvarchar(500),
@Id int

AS

UPDATE PSEPSteps
SET Name = @Name,
Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateSSeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateSSeqNo]
@Id int,
@Seq int
AS
Update ServiceTypes
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateSkillCourses]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateSkillCourses]
@ProjectId int,
@SkillId int
AS

Insert into SkillCourses (ProjectId, SkillId )
Values (@ProjectId, @SkillId )
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateSESeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateSESeqNo]
@Id int,
@Seq int
AS
Update ServiceEvents
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateServiceType]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateServiceType]
@Name varchar(100),
@PJName varchar(20),
@PJNameS varchar(20),
@FunctionId int,
@Id int,
@QtyMeasuresId int,
@Desc nvarchar (500),
@Seq int=99,
@HHFlag int=null

AS

UPDATE ServiceTypes SET
Name = @Name, 
Description=@Desc,
ProjName = @PJName, 
ProjNameS = @PJNameS, 
QtyMeasuresId=@QtyMeasuresId,
TypeId =@FunctionId, Seq=@Seq, HouseholdFlag=@HHFlag
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateServiceEvents]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateServiceEvents]
@ServicesId int,
@EventsId int
As
Insert into ServiceEvents (ServicesId, EventsId)
Values (@ServicesId, @EventsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateSEProcsSeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateSEProcsSeqNo]
@Id int,
@Seq int
AS
Update SEProcs
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateResourceTypes]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateResourceTypes]
@Name nvarchar(100),
@Visibility int,
@Desc nvarchar(500),
@ParentId int,
@Id int,
@QtyMeasure int

AS

UPDATE ResourceTypes SET Name = @Name, 
QtyMeasuresId=@QtyMeasure,
ParentId =@ParentId,
Visibility=@Visibility,
Description=@Desc
Where Id=@id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSSeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSSeqNo]
@Id int,
@Seq int
AS
Update ProfileServiceTypes
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSModelEvents]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSModelEvents]
@ProfileServicesId int,
@EventsId int,
@MapPSEId int
As
Insert into ProfileServiceEvents (ProfileServicesId, EventsId, MapId)
Values (@ProfileServicesId, @EventsId, @MapPSEId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEResourcesDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEResourcesDesc]
@LocTypesId int,
@Desc nvarchar (500),
@Id int
AS
Update PSEResources 
Set LocTypesId=@LocTypesId,
Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEResources]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEResources]
@ProfilesId int,
@ServiceTypesId int,
@EventsId int,
@ResourceTypesId int
As

insert into PSEResources
(ProfilesId, ServiceTypesId, EventsId, ResourceTypesId)
Values
(@ProfilesId, @ServiceTypesId, @EventsId, @ResourceTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPStaffDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPStaffDesc]
@Desc ntext,
@Id int
 AS

Update PSEPStaff 
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPSStaffDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPSStaffDesc]

@Id int
 AS

Update ProfileSEPSStaff 
Set Description='z'
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPSPeople]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPSPeople]
@PeopleId int=null,
@Qty decimal (20,2) = null,
@TimeMeasure int=null,
@FundsId int=null,
@Id int
AS
Update PSEPSPeople
Set 
@PeopleId=@PeopleId,
Qty=@Qty,
TimeMeasure=@TimeMeasure,
FundsId=@FundsId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPSerDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPSerDesc]
@Id int,
@Desc varchar (200)=null
AS
Update PSEPSer
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPSer]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPSer]
@ProcsID int,
@ServiceTypesId int
AS
Insert into PSEPSer ( ProcsID, ServiceTypesId)
Values (@ProcsID, @ServiceTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPResOutputs]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPResOutputs]
@PSEPID int,
@ResTypesId int
AS
Insert into PSEPResOutputs ( PSEPID, ResourceTypesId)
Values (@PSEPID, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPResDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPResDesc]
@Id int,
@Desc varchar (200) =null
AS
Update PSEPRes
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPRes]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPRes]
@ProcsId int,
@ResTypesId int
AS
Insert into PSEPRes ( ProcsId, ResTypesId)
Values (@ProcsId, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPModelClients]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPModelClients]
@ProfileSEventsId int
As
Insert into PSEPClients (
PSEPID, 
Type,
TypesOfDeadlinesId,
AcceptableSlip,
TypesOfImpactId,
TypesOfImpactMagnitudeId,
DollarCostSlip,
LocTypesId,
RolesId,
Description)
Select 
ProfileSEProcs.Id, 
PSEPClients.Type,
PSEPClients.TypesOfDeadlinesId,
PSEPClients.AcceptableSlip,
PSEPClients.TypesOfImpactId,
PSEPClients.TypesOfImpactMagnitudeId,
PSEPClients.DollarCostSlip,
PSEPClients.LocTypesId,
PSEPClients.RolesId,
PSEPClients.Description
From
ProfileSEProcs inner join
ProfileSEProcs as PS2 on ProfileSEProcs.MapId=PS2.Id inner join
PSEPClients on PSEPClients.PSEPID=PS2.Id 

Where 
ProfileSEProcs.ProfileSEventsId=@ProfileSEventsId
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPClientEvents]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPClientEvents]
@PSEPClientsId int,
@EventsId int
As
Insert into PSEPClientEvents (PSEPClientsId, EventsId)
Values(@PSEPClientsId, @EventsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEPCImpactDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdatePSEPCImpactDesc]
@Desc varchar (500),
@Id int
 AS

Update PSEPClientEvents
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEClientStds]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdatePSEClientStds]
@Id int,
@TypesOfDeadlinesId int,
@AcceptableSlip varchar (50),
@TypesOfImpactId int,
@TypesOfImpactMagnitudeId int,
@DollarCostSlip int=0,
@Type int

As

Update PSEClients 
Set 
Type=@Type,
TypesOfDeadlinesId=@TypesOfDeadlinesId,
AcceptableSlip=@AcceptableSlip,
TypesOfImpactId=@TypesOfImpactId,
TypesOfImpactMagnitudeId=@TypesOfImpactMagnitudeId,
DollarCostSlip=@DollarCostSlip
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePSEClientDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdatePSEClientDesc]
@Desc varchar (200),
@Id int
 AS

Update PSEClients
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProjTypesPSEP]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProjTypesPSEP]
@Id int,
@Seq int
AS
Update ProjTypesPSEP 
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProjOLPSEP]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProjOLPSEP]
@ProjectsId int,
@PSEPID int,
@OrgLocationsId int,
@EndDate smalldatetime=null,
@EndStatus int,
@StartDate smalldatetime=null,
@StartStatus int 
as
Update ProjOLPSEP
Set
EndDate=@EndDate,
EndStatus=@EndStatus,
StartDate=@StartDate,
StartStatus=@StartStatus

Where
ProjectsId = @ProjectsId and
ProfileSEProcsId = @PSEPID and
OrgLocationsId = @OrgLocationsId
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProjectType]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProjectType]
@Name nvarchar(50),
@Nameshort nvarchar(50),
@Seq int,
@Vis int,
@Id int

AS

UPDATE ProjectTypes 
SET
Name = @Name,
Nameshort = @Nameshort,
Seq=@Seq,
Visibility=@Vis

WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProjectsPeople]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProjectsPeople]
@ProjectId int,
@PeopleId int
AS

Insert into ProjectsPeople (ProjectsId, PeopleId )
Values (@ProjectId, @PeopleId )
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProjectC]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProjectC]
@Status int,
@Id int

AS
if @Status = 1
UPDATE Projects
 SET 
Status ='Started'
WHERE Id=@Id;

else if @Status = 2
UPDATE Projects
 SET 
Status ='Completed'
WHERE Id=@Id;

else if @Status = 3
UPDATE Projects
 SET 
Status ='Cancelled'
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProject]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProject]
@Name nvarchar(300),
@Desc nvarchar(500) =null,
@Vis int,
@StartTime smalldatetime=null,
@EndTime smalldatetime=null,
@Status nvarchar(10)=null,
@Id int

AS
if @Status is null
UPDATE Projects SET Name = @Name,
Description=@Desc,
 Visibility=@Vis, StartTime=@StartTime,
EndTime=@EndTime
WHERE Id=@Id;
else
UPDATE Projects SET Name = @Name, 
Description=@Desc,
Visibility=@Vis, StartTime=@StartTime,
EndTime=@EndTime, Status=@Status
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSESeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileSESeqNo]
@Id int,
@Seq int
AS
Update ProfileServiceEvents
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileServiceTypes]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileServiceTypes]
@ProfilesId int,
@ServiceTypesId int
AS
Insert into ProfileServiceTypes (ProfilesId, ServiceTypesId)
Values (@ProfilesId, @ServiceTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileServiceEvents]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileServiceEvents]
@ProfileServicesId int,
@EventsId int
As
Insert into ProfileServiceEvents (ProfileServicesId, EventsId)
Values (@ProfileServicesId, @EventsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSeqNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdateProfileSeqNo]
@Id int,
@Seq int
AS
Update Profiles
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSEPStepNo]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileSEPStepNo]
@Id int,
@Seq int
AS
Update PSEPSteps 
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProfileSEPSRes]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProfileSEPSRes]
@ProfileSEPStepTypesId int,
@ResTypesId int
AS
Insert into ProfileSEPSRes ( ProfileSEPStepTypesId, ResTypesId)
Values (@ProfileSEPStepTypesId, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOLPSEPClient]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOLPSEPClient]
@Id int

AS
DELETE FROM OLSEProcClients WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOLPProject]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOLPProject]
@Id int
AS
DELETE From OLPProjects
Where Id  = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOLPPPeople]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOLPPPeople]
@Id int
AS
Delete
FROM  OLPPPeople
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOLPCPeople]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOLPCPeople]
@Id int
AS
Delete
FROM  OLPCPeople
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOLPCOrgs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOLPCOrgs]
@Id int
AS
Delete
FROM  OLPCOrgs
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteLocId]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_DeleteLocId]
@Id int
AS
DELETE FROM Locations WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteEvent]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteEvent]
@Id int

AS
DELETE FROM Events WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteBudOrgClients]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeleteBudOrgClients]
@Id int

AS
DELETE FROM BudOrgClients WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteBOOutputs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeleteBOOutputs]
@ID int
 AS
Delete from BudOrgsOutputs 
Where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[wms_AddTimetable]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddTimetable] 
@PSEPStepsId int,
@PSEPID int,
@OrgId int,
@LocationsId int,
@ProjectId int,
@CompletionDate smalldatetime=null,
@Status nvarchar (10)
AS
Insert into Timetables 
(PSEPStepsId, ProjectId, OrgId, LocationsId,  CompletionDate, Status,PSEPID )
Values
(@PSEPStepsId, @ProjectId, @OrgId, @LocationsId, @CompletionDate, @Status, @PSEPID)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddStep]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddStep]
@ProcsId int,
@LocTypesId int=null,
@Name nvarchar(80),
@Desc nvarchar(500)
AS
Insert into PSEPSteps
(ProcsId,LocTypesId, Name, Description, Seq)
values
(@ProcsId, @LocTypesId, @Name,@Desc, '99')
GO
/****** Object:  StoredProcedure [dbo].[wms_AddServiceType]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddServiceType]
@Name varchar(100),
@PJName nvarchar(20),
@PJNameS nvarchar(20),
@FunctionId int,
@OrgId int,
@Vis int,
@QtyMeasuresId int,
@Desc nvarchar (500),
@Seq int=99,
@HHFlag int = null
AS
Insert into ServiceTypes
(Name, TypeId, Description, OrgId, Visibility, QtyMeasuresId, Seq, ProjName, ProjNameS, HouseholdFlag)
values
(@Name, @FunctionId, @Desc, @OrgId,  @Vis, @QtyMeasuresId, @Seq, @PJName, @PJNameS, @HHFlag)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddResourceTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddResourceTypes]
@Name nvarchar(100),
@ParentId int,
@Visibility int,
@OrgId int,
@QtyMeasure int,
@RType int = 0,
@Desc nvarchar(500)
AS
Insert into ResourceTypes
(Name,  Description, ParentId, OrgId, Visibility, QtyMeasuresId, Type)
values
(@Name, @Desc, @ParentId, @OrgId, @Visibility, @QtyMeasure, @RType)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddPSEvents]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddPSEvents]
@ProfileServicesId int,
@EventsId int
As

Insert into ProfileServiceEvents
(ProfileServicesId, EventsId, Seq)

Values
(@ProfileServicesId, @EventsId, '99')
GO
/****** Object:  StoredProcedure [dbo].[wms_AddPSEPStaff]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddPSEPStaff]
@ProcsId int,
@RolesId int =0
AS
Insert into PSEPStaff (ProcsId, RolesId)
Values (@ProcsId, @RolesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddPSEPSPeople]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddPSEPSPeople]
@PSEPSID  int,
@PeopleId int=null,
@ProjectId int=null,
@OrgId int,
@LocationsId int,
@StaffActionsId int=null
AS
Insert into PSEPSPeople
(PSEPSID, PeopleId, OrgId, LocationsId, 
ProjectId, StaffActionsId)
values
(@PSEPSID, @PeopleId,@OrgId, @LocationsId,
@ProjectId, @StaffActionsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddPSEPResInv]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddPSEPResInv]
@PSEPResID int,
@BudgetsId int = null,
@OrgId int,
@LocationsId int,
@InventoryId int=null,
@ProjectId int=null,
@ContractsId int=null,
@StartDate smalldatetime = null
AS
Insert into PSEPResInventory
(PSEPResID, InventoryId, OrgId, LocationsId, ContractsId, 
ProjectId, StartDate)
values
(@PSEPResID, @InventoryId,@OrgId, @LocationsId, @ContractsId,
@ProjectId, @StartDate)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddPSEClients]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_AddPSEClients]
@PSEID int,
@ClientsId int

As

Insert into PSEClients 
(ProfileServiceEventsId, ClientsId)
Values
(@PSEID, @ClientsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProjOrgLoc]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_AddProjOrgLoc] 
@ProjectId int,
@OrgLocationsId int
as
Insert into ProjOrgLoc
(ProjectsId, OrgLocationsId)
Values
(@ProjectId, @OrgLocationsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProjOLPSEP]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddProjOLPSEP] 
@ProjectId int,
@PSEPID int,
@OrgLocationsId int,

@EndDate smalldatetime=null,
@EndStatus int,
@StartDate smalldatetime=null,
@StartStatus int
as
Insert into ProjOLPSEP
(ProjectsId, OrgLocationsId, ProfileSEProcsId, StartDate, EndDate, StartStatus, EndStatus)
Values
(@ProjectId, @OrgLocationsId, @PSEPID, @StartDate, @EndDate, @StartStatus, @EndStatus)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProjectTypesPSEP]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddProjectTypesPSEP]
@ProjTypesId int,
@PSEPId int,
@ProfileId int
AS
Insert into ProjTypesPSEP (
ProjectTypesId, PSEPId, ProfileId)
Values
(@ProjTypesId,@PSEPId, @ProfileId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProjectType]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddProjectType]
@Name nvarchar(50),
@Nameshort nvarchar (50),
@Seq int = 0,
@OrgId int,
@Vis int
AS
Insert into ProjectTypes
(Name, Nameshort, Seq, Visibility,OrgId)
values
(@Name, @Nameshort, @Seq, @Vis, @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProject]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddProject]
@Name varchar(300),
@Desc nvarchar(500)=null,
@PSEventsId int,
@Status varchar(10)='Planned',
@StartTime smalldatetime=null,
@EndTime smalldatetime=null,
@OrgId int,
@LocationsId int,
@Vis int
AS
Insert into Projects
(Name, Description, Status, Visibility, StartTime, EndTime, OrgId, LocationsId, PSEventsId)
values
(@Name, @Desc, @Status,  @Vis, @StartTime, @EndTime, @OrgId, @LocationsId, @PSEventsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProfileSEProcs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddProfileSEProcs]
@ProfileSEventsId int,
@ProcsId int,
@Name varchar (300),
@Timetables int=null,
@ProjectTypesId int=null,
@Costs int=null
As

Insert into ProfileSEProcs 
(ProfileSEventsId, ProcsId,
Name,
Timetables,
ProjectTypesId,
Costs)

Values
(@ProfileSEventsId, @ProcsId,
@Name,
@Timetables,
@ProjectTypesId,
@Costs)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProfileProjectTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddProfileProjectTypes]
@ProfilesId int,
@ProjectTypesId int
AS
Insert into ProfileProjectTypes (
ProjectTypesId, ProfilesId)
Values
(@ProjectTypesId,@ProfilesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProcs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddProcs]

@Name varchar (300),
@Desc varchar (500),
@Vis  int,
@Services int,
@PeopleId int=null,
@OrgId int
As

Insert into Procs 
(
Name,
Description,
Visibility, 
ServiceTypesId,
PeopleId,
OrgId
)
Values
(
@Name,
@Desc,
@Vis,
@Services,
@PeopleId,
@OrgId
)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddProcClient]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddProcClient]
@ProfilesId int,
@ProcsId int

As

Insert into ProcClients 
(ProfilesId, ProcsId)
Values
(@ProfilesId, @ProcsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOrgPSEPSDesc]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_AddOrgPSEPSDesc]
@Desc ntext=null,
@PSEPStaffId int,
@OrgId int
AS
insert into OrgPSEPStaff (OrgId, PSEPStaffId, Description)
Values
(@OrgId, @PSEPStaffId, @Desc)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOrgPSEPRDesc]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddOrgPSEPRDesc]
@Desc ntext=null,
@PSEPRId int,
@OrgId int
AS
insert into OrgPSEPRes (OrgId, PSEPResId, Description)
Values
(@OrgId, @PSEPRId, @Desc)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOrgLocSEvents]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddOrgLocSEvents]
@OrgLocId int,
@ProfileServiceEventsId int
AS
Insert into OrgLocSEvents (OrgLocId, ProfileServiceEventsId) 
Values (@OrgLocId,  @ProfileServiceEventsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOrgLocServiceTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddOrgLocServiceTypes]
@OrgLocId int,
@ServiceTypesId int
AS
Insert into OrgLocServiceTypes (OrgLocId, ServiceTypesId) 
Values (@OrgLocId, @ServiceTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOrgLocSEProcs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddOrgLocSEProcs]
@OrgLocSEventsId int,
@ProfileSEventsId int
AS
Insert into OrgLocSEProcs (ProfileSEProcsId, OrgLocSEventsId, ProcsId) 
Select ProfileSEProcs.Id, @OrgLocSEventsId, ProfileSEProcs.ProcsId
from 
ProfileSEProcs inner join
ProfileServiceEvents on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId
Where ProfileSEventsId=@ProfileSEventsId
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOLPSEPClient]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddOLPSEPClient]
@OrgLocId int = null,
@ClientProfilesId int = null,
@BudgetsId int=null,
@ProfileServicesId int = null,
@ProjectId int=null
AS
insert into OLSEProcClients
(ProfileServicesId, BudgetsId, OrgLocationsId, ProjectId, ClientProfilesId)
Values
(@ProfileServicesId, @BudgetsId, @OrgLocId, @ProjectId, @ClientProfilesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddOLPProjects]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddOLPProjects]
@ProjectId int,
@OrgLocId int,
@PSEPID int
AS

Insert into OLPProjects
(
ProjectId,
OrgLocId,
PSEPID
)
Values
(@ProjectId,
@OrgLocId,
@PSEPID)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddLocType]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddLocType]
@Name nvarchar(50),
@Desc nvarchar (300),
@Vis int,
@OrgId int
AS
Insert into LocTypes
(Name, Description,  OrgId, Visibility)
values
(@Name, @Desc,  @OrgId, @Vis)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddInventory]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddInventory]
@Desc nvarchar (300),
@ResTypeId int,
@SLocId int,
@StatusId int,
@VisId int,
@Qty float=null
AS
Insert into Inventory
(SLocId, Description,  StatusId, ResTypeId, Qty, Visibility)
values
(@SLocId, @Desc,  @StatusId, @ResTypeId, @Qty, @VisId)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddEvent]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_AddEvent]
@Name nvarchar(50),
@Desc ntext,
@Vis int, 
@OrgId int,
@ServicesId int,
@HHFlag int = null
AS
Insert into Events
(Name, Description,  OrgId, Visibility, ServicesId, HouseholdFlag)
values
(@Name, @Desc,@OrgId, @Vis, @ServicesId, @HHFlag)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddClient]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[wms_AddClient]
@Name nvarchar(100),
@Vis int, 
@OrgId int
AS
Insert into Clients
(Name, OrgId, Visibility)
values
(@Name, @OrgId, @Vis)
GO
/****** Object:  StoredProcedure [dbo].[wms_AddBudOrgClients]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_AddBudOrgClients]
@BudOrgsId int,
@ClientsId int
AS
Insert into BudOrgClients 
(BudOrgsId, ClientsId)
Values
(@BudOrgsId, @ClientsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_addBOOutputs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_addBOOutputs]
@BudOrgsId int, 
@ResTypesId int
AS
Insert into BudOrgsOutputs (ResTypesId, BudOrgsId)
Values
(@ResTypesId, @BudOrgsId)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudOLServiceAmt]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudOLServiceAmt]
@Id int=null,
@ServiceTypesId int=null,
@LocationsId int=null,
@BudOrgsId int=null,
@BudAmt dec (20,2)=null
As

if @Id is null
Insert into BudOLServices 
(
ServiceTypesId, LocationsId,
BudOrgsId,
BudAmt
)
Values
(@ServiceTypesId,@LocationsId,@BudOrgsId,@BudAmt)

else

Update BudOLServices 
Set
BudAmt=@BudAmt
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudgetsOpen]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudgetsOpen]
@BudgetsId int
AS
Update  Budgets Set
Status=1
Where
Id=@BudgetsId
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudgetsClose]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudgetsClose]
@BudgetsId int
AS
Update  Budgets Set
Status=3
Where
Id=@BudgetsId
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudget]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudget]
@Id int,
@Status int,
@CurrenciesId int,
@Amt dec (20,2)=null,
@FundsId int
AS
Update  Budgets Set

Status=@Status,
CurrenciesId=@CurrenciesId,
Amount=@Amt,
FundsId=@FundsId
Where
Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_AddPSEPResInventory]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddPSEPResInventory]
@Id int,
@ContractId int
AS
Update PSEPResInventory
Set ContractsId=@ContractId
Where PSEPResInventory.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_AddProjCPeople]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_AddProjCPeople]
@ProjectId int,
@OrgLocId int,
@PSEPCID int,
@ClientActionsId int
 AS
Insert into ProjCPeople
(ProjectId, OrgLocId, PSEPCID, ClientActionsId)
Values
(@ProjectId, @OrgLocId, @PSEPCID, @ClientActionsId)
GO
/****** Object:  StoredProcedure [dbo].[eps_UpdateTaskPeopleAuto]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eps_UpdateTaskPeopleAuto]
@ServiceId int,
@TaskId int
 AS
Insert into TaskPeople (PeopleId, TaskId, OrgStatus, RolesId, Description)
Select Staffing.PeopleId,@TaskId, 'Actual', Staffing.RolesId, Staffing.Description
From Services inner join Organizations on
Services.SupplierOrganization=Organizations.Id
inner join Staffing on Organizations.Id=Staffing.OrgId
Where Services.Id=@ServiceId
GO
/****** Object:  StoredProcedure [dbo].[UpdateProcResOutputs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[UpdateProcResOutputs]
@ProcsId int,
@ResTypesId int
AS
Insert into ProcResOutputs (ProcsId, ResourceTypesId)
Values (@ProcsId, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdateStaffType]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdateStaffType]
@Id int,
@Name nvarchar (50),
@Vis int

AS
Update StaffTypes
Set
Name=@Name,
Visibility=@Vis
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdateStaffAction]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdateStaffAction]
@Id int,
@TypeId int,
@LocId int,
@PM int,
@PeopleId int=null,
@Vis int,
@Status int=null,
@RolesId int=null,
@FundsId int=null,
@StartDate smalldatetime=null,
@EndDate smalldatetime=null

AS
Update StaffActions
Set
TypeId=@TypeId,
LocId=@LocId,
PayMethod=@PM,

PeopleId=@PeopleId,
StartDate=@StartDate,
EndDate=@EndDate,
Visibility=@Vis,
Status=@Status,
RolesId=@RolesId,
FundsId=@FundsId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_updateSARevisions]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_updateSARevisions]
@EndDate smalldatetime,
@StaffActionsId int

AS

Update SARevisions 
Set 
EndDate=@EndDate,
Status=null

Where StaffActionsId = @StaffActionsId and EndDate is null and
SARevisions.Id < (Select Max(SARevisions.Id) from SARevisions
Where StaffActionsId=@StaffActionsId)
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdateRoles]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_UpdateRoles]
@Name nvarchar(50),
@ParentId int,
@Visibility int,
@Seq int,
@Id int

AS

UPDATE Roles SET Name = @Name, ParentId=@ParentId, Visibility=@Visibility, Seq=@Seq
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdatePeople]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdatePeople]
 
@PeopleId int,
@FName nvarchar(50),
@LName nvarchar(50),
@Addr ntext,
@Email nvarchar (50),
@HPhone nvarchar(50),
@CPhone nvarchar(50),
@WPhone nvarchar(50),
@Vis int,
@UserLevel int=null

AS
if @UserLevel is null
Update People
Set
FName=@FName, 
LName=@LName, 
Address=@Addr, 
HomePhone=@HPhone, 
WorkPhone=@WPhone, 
CellPhone=@CPhone, 
Email=@Email,
Visibility=@Vis
Where Id=@PeopleId;

else

Update People
Set
FName=@FName, 
LName=@LName, 
Address=@Addr, 
HomePhone=@HPhone, 
WorkPhone=@WPhone, 
CellPhone=@CPhone, 
Email=@Email,
Visibility=@Vis,
UserLevel=@UserLevel
Where Id=@PeopleId;
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdatePayGrade]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdatePayGrade]
@Id int,
@Name nvarchar (50),
@Status int=null,
@SalMax dec (20,2)=null,
@SalMin dec (20,2)=null,
@SalAve dec (20,2)=null,
@Ovt dec (20,2)=null

AS
Update OrgSTPayGrades
Set
Name=@Name,
Status=@Status,
SalaryMax=@SalMax,
SalaryMin=@SalMin,
SalaryAve=@SalAve,
OvertimeRate=@Ovt
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdateOrgSTPayGradesSeq]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdateOrgSTPayGradesSeq]
@Id int,
@Seq int
AS
Update OrgSTPayGrades
Set Seq=@Seq
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdateOrgStaffTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdateOrgStaffTypes]
@OrgId int,
@StaffTypesId int
As
Insert into OrgStaffTypes (OrgId, StaffTypesId)
Values (@OrgId, @StaffTypesId)
GO
/****** Object:  StoredProcedure [dbo].[hrs_UpdateOrgStaffType]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_UpdateOrgStaffType]
@Id int,
@Status int=null,
@Seq int=null,
@CurrenciesId int,
@SalPeriod int=null,
@PaymentBasis int=null

AS
Update OrgStaffTypes
Set
Status=@Status,
CurrId=@CurrenciesId, 
Seq=@Seq,
SalaryPeriod=@SalPeriod,
PaymentBasis=@PaymentBasis
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffTypesAll]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffTypesAll]
@DomainId int,
@LicenseId int,
@OrgIdP int,
@OrgId int
As
SELECT  StaffTypes.Id, StaffTypes.Name,  StaffTypes.Visibility
FROM   StaffTypes inner join
Organizations on  StaffTypes.OrgId=Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id
Where 
( StaffTypes.Visibility = 1 or
 StaffTypes.Visibility=2 and Licenses.DomainId=@DomainId or
 StaffTypes.Visibility=3 and Organizations.LicenseId=@LicenseId or
 StaffTypes.Visibility=4 and Organizations.ParentOrg=@OrgIdP or
 StaffTypes.OrgId=@OrgId)
Order by  StaffTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffTypes]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
SELECT StaffTypes.Id, StaffTypes.Name
FROM StaffTypes
inner join Organizations on StaffTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where  StaffTypes.Visibility=1 or StaffTypes.OrgId=@OrgId
or ( StaffTypes.Visibility=2 and DomainId=@DomainId)
or ( StaffTypes.Visibility=3 and  LicenseId=@LicenseId)
or ( StaffTypes.Visibility=4 and ParentOrg=@OrgIdP)
Order by  StaffTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffTypeDetails]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffTypeDetails]
@OrgStaffTypesId int
As
SELECT 

Currencies.NamePlural as CurrName, --0
'SalaryPeriod' =  --1
Case
When OrgStaffTypes.SalaryPeriod is null then 'Unknown'
When OrgStaffTypes.SalaryPeriod = 0 then 'Year'
When OrgStaffTypes.SalaryPeriod = 1 then 'Month' 
When OrgStaffTypes.SalaryPeriod = 2 then 'Week' 
When OrgStaffTypes.SalaryPeriod = 3  then 'Day'
When OrgStaffTypes.SalaryPeriod = 4 then 'Hour'
Else '??'
End,
OrgSTPayGrades.SalaryAve--2
FROM OrgStaffTypes inner join
Currencies on OrgStaffTypes.CurrId=Currencies.Id inner join
OrgSTPayGrades on OrgSTPayGrades.OrgStaffTypesId=OrgStaffTypes.Id inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id 
Where  OrgStaffTypes.Id=@OrgStaffTypesId
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffSalary]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffSalary]
@Id  int
 AS

Select
SARevisions.Id,--0
Convert(CHAR(128), SARevisions.StartDate, 101 ) as StartDate,--1
SARevisions.Salary,--2
OrgSTPayGrades.Id as OrgSTPayGradesId,--3
OrgSTPayGrades.Name as 'PayGradeTitle'--4
from
SARevisions inner join
OrgSTPayGrades on OrgSTPayGrades.Id=SARevisions.PayGradeId
Where 
SARevisions.StartDate=(Select Max(SARevisions.StartDate) from SARevisions
Where SARevisions.StaffActionsId=@Id)
and SARevisions.StaffActionsId=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffActionsProc]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffActionsProc]
@OrgId int,
@OrgIdP int=null,
@LicenseId int=null,
@DomainId int=null
As
SELECT  'Status'  =--0
	Case
		When StaffActions.Status =  0 then  'Planned'   
		When StaffActions.Status = 1 then 'Active'   
		When StaffActions.Status = 2  then 'Closed'
		When StaffActions.Status = 3  then 'Terminated'
		Else '??'
	End,
StaffActions.Id, --1 
Cast (StaffTypes.Name as varchar(300)) as StaffType,--2
StaffActions.Id, StaffTypes.Name as STName,--3

'Name' = --4
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,

StaffActions.OrgId as OrgIdSA,--5
Organizations.Name as OrgName,--6,
StaffActions.PeopleId,--7
OrgStaffTypes.Id as OrgSTId
From
StaffActions left outer join 
People on StaffActions.PeopleId=People.Id inner join
OrgStaffTypes on StaffActions.TypeId=OrgStaffTypes.Id inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id inner join
Organizations on StaffActions.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where 
(StaffActions.OrgId=@OrgId or
StaffActions.Visibility=1 or
(StaffActions.Visibility=2 and Licenses.DomainId=@DomainId) or
(StaffActions.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(StaffActions.Visibility=4 and Organizations.ParentOrg=@OrgIdP))
and StaffActions.Status > 0
and StaffActions.Status < 3

Order by Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffActionsNew]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[hrs_RetrieveStaffActionsNew]
@OrgId int
As

SELECT Max(Id) from StaffActions where OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffActionsApt]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffActionsApt]
@OrgStaffTypesId  int
As

SELECT  'Status'  =
Case		
	When StaffActions.Status is null then 'New Appointment Request'
	When StaffActions.Status =  0 then  'Planned'   
	When StaffActions.Status = 1 then 'Active'   
	When StaffActions.Status =2  then 'Closed'
	When StaffActions.Status = 3  then 'Terminated'
	Else '??'
End,
StaffActions.Id, Cast (StaffTypes.Name as varchar(300)) as StaffType,

'Name' = 
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,
StaffActions.OrgId as OrgIdSA,
People.Id as PeopleId,
Roles.Name as RoleName
From
StaffActions inner join
OrgStaffTypes on StaffActions.TypeId=OrgStaffTypes.Id   inner join
StaffTypes on OrgStaffTypes.StaffTypesId =StaffTypes.Id  left outer join 
People on StaffActions.PeopleId=People.Id left  outer join
Roles on StaffActions.RolesId=Roles.Id
Where StaffActions.TypeId =@OrgStaffTypesId
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffActions]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffActions]
@OrgId int,
@StaffTypesId int,
@OrgIdP int=null,
@LicenseId int=null,
@DomainId int=null
As

if (@LicenseId=null)

SELECT  'Status'  =
	Case		
		When StaffActions.Status is null then 'New Appointment  Request'
		When StaffActions.Status =  0 then  'Planned'   
		When StaffActions.Status = 1 then 'Active'   
		When StaffActions.Status = 2  then 'Closedted'
		When StaffActions.Status = 3  then 'Terminated'
		Else '??'
	End,
StaffActions.Id, Cast (StaffTypes.Name as varchar(300)) as StaffType,

'Name' = 
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,
StaffActions.OrgId as OrgIdSA,
Roles.Name as RoleName
From
StaffActions left outer join 
People on StaffActions.PeopleId=People.Id inner join
StaffTypes on StaffActions.TypeId=StaffTypes.Id left  outer join
Roles on StaffActions.RolesId=Roles.Id
Where StaffActions.OrgId=@OrgId and
StaffActions.TypeId =@StaffTypesId

Else

SELECT  'Status'  =
	Case
		When StaffActions.Status is null then 'New Appointment  Request'
		When StaffActions.Status =  0 then  'Planned'   
		When StaffActions.Status = 1 then 'Active'   
		When StaffActions.Status = 2  then 'Closedted'
		When StaffActions.Status = 3  then 'Terminated'
		Else '??'
	End,
StaffActions.Id, Cast (StaffTypes.Name as varchar(300)) as StaffType,
StaffActions.Id, StaffTypes.Name as STName,

'Name' = 
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,

StaffActions.OrgId as OrgIdSA,
Organizations.Name as OrgName
From
StaffActions left outer join 
People on StaffActions.PeopleId=People.Id inner join
StaffTypes on StaffActions.TypeId=StaffTypes.Id inner join
Organizations on StaffActions.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where 
StaffActions.TypeId =@StaffTypesId and
(StaffActions.OrgId=@OrgId or
StaffActions.Visibility=1 or
(StaffActions.Visibility=2 and Licenses.DomainId=@DomainId) or
(StaffActions.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(StaffActions.Visibility=4 and Organizations.ParentOrg=@OrgIdP))
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffActionProc]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffActionProc]
@Id int
As

SELECT  
PeopleId,
'PeopleName' = 
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,
StaffActions.TypeId,
StaffActions.LocId,
StaffActions.Visibility,
StaffActions.PayMethod,
'StatusName' =
Case
		When StaffActions.Status is null then 'New Appointment  Request'
		When StaffActions.Status =  0 then  'Planned'   
		When StaffActions.Status = 1 then 'Active'   
		When StaffActions.Status = 2  then 'Closedted'
		When StaffActions.Status = 3  then 'Terminated'
Else '??'
End,
StaffActions.Status,
StaffActions.Salary,
StaffActions.PayGradeId,
ProcProcures.Qty, ProcProcures.Description
From
ProcProcures left outer join
StaffActions on ProcProcures.ContractId=StaffActions.Id left outer  join 
People on StaffActions.PeopleId=People.Id
Where ProcProcures.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveStaffAction]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveStaffAction]
@Id int
As

SELECT  
PeopleId,--0
'PeopleName' = --1
Case
When People.FName + ' ' + People.LName is not null then People.FName + ' ' + People.LName
Else 'Unidentified'
End,
StaffActions.TypeId,--2
StaffActions.LocId,--3
StaffActions.Visibility,--4
StaffActions.PayMethod,--5
'StatusName' =--6
Case
		When StaffActions.Status is null then 'New Appointment  Request'
		When StaffActions.Status =  0 then  'Appointment Action Requested'   
		When StaffActions.Status = 1 then 'Appointment Action  in Process'   
		When StaffActions.Status = 2  then 'Appointed'
		When StaffActions.Status = 3  then 'Terminated'
		When StaffActions.Status = 4 then 'Appointment Request Rejected'
Else '??'
End,

StaffActions.Status,--7
StaffActions.Salary,--8
StaffActions.PayGradeId,--9
StaffActions.RolesId, --10  
Convert(CHAR(128), StaffActions.StartDate, 101 ) as StartDate,--11  
Convert(CHAR(128), StaffActions.EndDate, 101 ) as StartDate,--12
StaffActions.FundsId--13


From
StaffActions left outer  join 
People on StaffActions.PeopleId=People.Id 
Where StaffActions.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveSCs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveSCs]
@PeopleId int
As

SELECT  StaffActions.Id, StaffTypes.Name as STName,StaffActions.Description,
StaffActions.StartDate,
'StatusName' =--6
Case
		When StaffActions.Status is null then 'New Appointment  Request'
		When StaffActions.Status =  0 then  'Planned'   
		When StaffActions.Status = 1 then 'Active'   
		When StaffActions.Status = 2  then 'Closedted'
		When StaffActions.Status = 3  then 'Terminated'
Else '??'
End,
StaffActions.OrgId as AptOrgId, Organizations.Name as AptOrgName
From
StaffActions inner join 
People on StaffActions.PeopleId=People.Id inner join
OrgStaffTypes on  StaffActions.TypeId=OrgStaffTypes.Id inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id inner join
Organizations on  Organizations.Id=StaffActions.OrgId
Where StaffActions.PeopleId=@PeopleId
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveSARevised]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveSARevised]
@StaffActionsId  int
 AS

Select
SARevisions.Id,--0
SARevisions.StartDate,--Convert(CHAR(128), SARevisions.StartDate, 1 ) as StartDate,--1
SARevisions.Salary,--2
OrgSTPayGrades.Id as OrgSTPayGradesId,--3
OrgSTPayGrades.Name as 'PayGradeTitle'--4
from
SARevisions inner join
OrgSTPayGrades on OrgSTPayGrades.Id=SARevisions.PayGradeId
Where 
SARevisions.StartDate=(Select Max(SARevisions.StartDate) from SARevisions)
and SARevisions.StaffActionsId=@StaffActionsId
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveSAPeople]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveSAPeople]
@PeopleId int
As

SELECT  
StaffActions.Id,
Organizations.Name as OrgName
From
StaffActions inner join
Organizations on StaffActions.OrgId = Organizations.Id
Where StaffActions.PeopleId=@PeopleId
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveRolesAll]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveRolesAll]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As

SELECT Roles.Name, Roles.Id, Roles.Visibility, Roles.ParentId, Roles.Seq
FROM Roles inner join Organizations on Organizations.Id=Roles.OrgId
inner join Licenses on Organizations.LicenseId=Licenses.Id
WHERE Roles.Visibility=1 or Roles.OrgId=@OrgId 
or (Roles.Visibility=2 and DomainId=@DomainId)
or (Roles.Visibility=3 and LicenseId=LicenseId)
or (Roles.Visibility=4 and Organizations.ParentOrg=@OrgIdP)
Order by Roles.Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrievePeople]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrievePeople]
@OrgId int = null,
@OrgIdP int = null,
@LicenseId int = null,
@DomainId int = null,
@ServiceTypesId int = null,
@PeopleServiceFlag int = null

 AS
if @PeopleServiceFlag is not null
SELECT People.Id,  People.UPI,  People.FName,  People.LName, People.WorkPhone,  People.HomePhone,  People.CellPhone, 
 People.Email,   People.Address,
People.Visibility, People.OrgId, People.UserLevel
from People 
order by LName, FName
else
if @ServiceTypesId is null
SELECT People.Id,  People.UPI,  People.FName,  People.LName, People.WorkPhone,  People.HomePhone,  People.CellPhone, 
 People.Email,   People.Address,
People.Visibility, People.OrgId, People.UserLevel
from People inner join
Organizations on People.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where People.Visibility=1 or
People.Visibility=2 and Licenses.DomainId=@DomainId or
People.Visibility=3 and Organizations.LicenseId=@LicenseId or
People.Visibility=4 and Organizations.ParentOrg=@OrgIdP
Order by People.LName

else
SELECT People.Id,  People.FName + People.LName as Name
from People inner join
Organizations on People.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where People.Visibility=1 or
People.Visibility=2 and Licenses.DomainId=@DomainId or
People.Visibility=3 and Organizations.LicenseId=@LicenseId or
People.Visibility=4 and Organizations.ParentOrg=@OrgIdP
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrievePayGrades]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrievePayGrades]
@OrgStaffTypesId int

 AS
SELECT OrgSTPayGrades.Id, OrgSTPayGrades.Name 
from OrgSTPayGrades inner join
OrgStaffTypes on OrgSTPayGrades.OrgStaffTypesId=OrgStaffTypes.Id

Where OrgStaffTypes.Id=@OrgStaffTypesId
Order by OrgSTPayGrades.Seq
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrievePayGrade]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrievePayGrade]
@Id int
As

SELECT  
Currencies.Name,--0
SalaryMin,--1
SalaryMax,--2
SalaryAve,--3
'SalaryPeriod' = --4 
Case
When OrgStaffTypes.SalaryPeriod is null then 'Unknown'
When OrgStaffTypes.SalaryPeriod = 0 then 'Year'
When OrgStaffTypes.SalaryPeriod = 1 then 'Month' 
When OrgStaffTypes.SalaryPeriod = 2  then 'Day'
When OrgStaffTypes.SalaryPeriod = 3 then 'Hour'
Else '??'
End,
OvertimeRate--5
from
OrgSTPayGrades inner join
OrgStaffTypes on OrgSTPayGrades.OrgStaffTypesId=OrgStaffTypes.Id inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id inner join
Currencies on OrgStaffTypes.CurrId=Currencies.Id 

Where 
OrgSTPayGrades.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveOSTPayGrade]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveOSTPayGrade]
@Id int
As
Select 
OrgSTPayGrades.Name, --0
OrgSTPayGrades.Status, --1
OrgSTPayGrades.SalaryMax, --2
OrgSTPayGrades.SalaryMin, --3
OrgSTPayGrades.SalaryAve,--4
OrgSTPayGrades.OvertimeRate--5

From
OrgSTPayGrades
Where
OrgSTPayGrades.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveOrgSTPayGrades]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveOrgSTPayGrades]
@OrgSTId int

 AS
SELECT OrgSTPayGrades.Id, OrgSTPayGrades.Name, 
OrgSTPayGrades.Status, OrgSTPayGrades.Seq
from OrgSTPayGrades inner join
OrgStaffTypes on OrgSTPayGrades.OrgStaffTypesId=OrgStaffTypes.Id inner join
Organizations on OrgStaffTypes.OrgId=Organizations.Id inner join
Licenses on   Organizations.LicenseId=Licenses.Id
Where OrgStaffTypes.Id=@OrgSTId
Order by OrgSTPayGrades.Seq
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveOrgStaffTypes]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveOrgStaffTypes]
@OrgId int
As
SELECT 
OrgStaffTypes.Id,
 StaffTypes.Id as StaffTypeId,
StaffTypes.Name,
Currencies.NamePlural as CurrName, 
'SalaryPeriod' = 
Case
When OrgStaffTypes.SalaryPeriod is null then 'Unknown'
When OrgStaffTypes.SalaryPeriod = 0 then ' Year'
When OrgStaffTypes.SalaryPeriod = 1 then 'Month' 
When OrgStaffTypes.SalaryPeriod = 2  then 'Fortnight'
When OrgStaffTypes.SalaryPeriod = 3  then 'Week'
When OrgStaffTypes.SalaryPeriod = 4 then 'Day'
When OrgStaffTypes.SalaryPeriod = 5 then 'Hour'
Else '??'
End,
OrgStaffTypes.CurrId
FROM OrgStaffTypes inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id inner join
Currencies on Currencies.Id=OrgStaffTypes.CurrId
Where  OrgStaffTypes.OrgId=@OrgId
Order by  OrgStaffTypes.Seq, StaffTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[hrs_RetrieveOrgStaffType]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_RetrieveOrgStaffType]
@Id int
As
SELECT 
StaffTypes.Name,--0,
Status,--1
CurrId, --2
SalaryPeriod, --3
Seq, --4
PaymentBasis --5
FROM OrgStaffTypes inner join
StaffTypes on OrgStaffTypes.StaffTypesId=StaffTypes.Id
Where OrgStaffTypes.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_DeleteStaffType]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_DeleteStaffType]
@Id int

AS
DELETE FROM StaffTypes WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[hrs_DeleteStaffAction]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_DeleteStaffAction]
@Id int
AS
Delete
FROM  StaffActions
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[hrs_DeleteSARevisions]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_DeleteSARevisions]
@StartDate smalldatetime,
@StaffActionsId int

AS
DELETE FROM SARevisions 
WHERE 
StartDate >= @StartDate and StaffActionsId=@StaffActionsId
GO
/****** Object:  StoredProcedure [dbo].[hrs_DeletePeople]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_DeletePeople]
@Id int
AS
Delete
FROM  People
WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[hrs_DeleteOSTPayGrade]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_DeleteOSTPayGrade]
@Id int

AS
DELETE FROM OrgSTPayGrades
 WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[hrs_DeleteOrgStaffTypes]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_DeleteOrgStaffTypes]
@Id int
AS
DELETE FROM OrgStaffTypes WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddStaffType]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_AddStaffType]
@Name nvarchar (50),
@Vis int,
@OrgId int
AS
Insert into StaffTypes (
Name,
Visibility,
OrgId)
Values
(
@Name,
@Vis,
@OrgId
)
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddStaffAction]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_AddStaffAction]
@PeopleId int=null,
@TypeId int=null,
@LocId int=null,
@Status int=null,
@PayGrade int=null,
@Sal dec (20,2)=null,
@RolesId int=null,
@FundsId int=null,
@PM int=null,
@Vis int=null,
@CurrId int=null,
@StartDate smalldatetime,
@EndDate smalldatetime,
@OrgId int=null
AS
Insert into StaffActions (
PeopleId,
TypeId,
LocId,
Status,
PayMethod,
PayGradeId,
Salary,
RolesId,
FundsId,
Visibility,
CurrId,
StartDate,
EndDate,
OrgId)
Values
(
@PeopleId,
@TypeId,
@LocId,
@Status,
@PM,
@PayGrade,
@Sal,
@RolesId,
@FundsId,
@Vis,
@CurrId,
@StartDate,
@EndDate,
@OrgId
)
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddSARevisions]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_AddSARevisions]
@StaffActionsId  int,
@StartDate smalldatetime,
@Salary float,
@PayGradeId int
 AS
Insert into SARevisions (StaffActionsId, StartDate,Salary,PayGradeId, SARevisions.Status)
Values (@StaffActionsId, @StartDate, @Salary, @PayGradeId, 1)
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddRoles]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hrs_AddRoles]
@Visibility int,
@Name nvarchar(50),
@OrgId int,
@ParentId int,
@Seq int = 99
As
Insert into Roles
(Name,OrgId, Visibility, ParentId, Seq)
values
(@Name,@OrgId, @Visibility, @ParentId, @Seq)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateTSA]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateTSA]

@Id int,
@Status int
As
Update Timesheets Set
Status=@Status
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateTS]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateTS]
@StaffActionsId int=null,
@ProcProcuresId int=null,
@YrMth int = null,
@Id int=null,
@Hours dec (20,2)=null
As
if (@Id=null and @Hours !=null)
Insert into Timesheets (
StaffActionsId, YrMth, ProcProcuresId, Hours)
Values
(@StaffActionsId, @YrMth, @ProcProcuresId, @Hours)

else if @Id !=null
Update Timesheets Set
Hours=@Hours
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdatePSEPResInv]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdatePSEPResInv]
@Qty float = null,
@Price float = null,
@BudgetsId int = null,
@BackupFlag int = 0,
@Id int
AS
if @BudgetsId is null 
Update PSEPResInventory
Set
Qty=@Qty, 
Price=@Price,
BackupFlag = @BackupFlag
Where Id=@Id

else

Update PSEPResInventory
Set
Qty=@Qty, 
Price=@Price,
BackupFlag=@BackupFlag,
BudgetsId=@BudgetsId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcSARAll]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateProcSARAll]
@Id int,
@ContractId int
As
Update ProcProcures 
Set
ContractId=@ContractId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcProcuresWS]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateProcProcuresWS]
@BudAmount decimal (20,4)=null,
@Id int
 AS
Update ProcProcures
Set
BudAmount=@BudAmount
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcPReqStatus]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[fms_UpdateProcPReqStatus]
@Id int
As
Update ProcProcures Set
StatusId=2
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcPReq]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdateProcPReq]
@Id int,
@ContractId int=null,
@Desc varchar (300)=null,
@Price decimal (20,2) = null,
@Qty decimal (20,2) = null,
@BudgetsId int = null,
@ReqAmount decimal (20,2)=null,
@BkupFlag int=null
As
if @BudgetsId is null
Update ProcProcures Set
Description=@Desc,
ContractId=@ContractId,
Qty=@Qty,
ReqAmount=@ReqAmount,
Price=@Price,
BkupFlag=@BkupFlag

Where Id=@Id

else
Update ProcProcures Set
Description=@Desc,
ContractId=@ContractId,
Qty=@Qty,
BudgetsId=@BudgetsId,
ReqAmount=@ReqAmount,
Price=@Price,
BkupFlag=@BkupFlag
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcPay]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateProcPay]
@Id int,
@ProcProcuresId int,
@PayAmt float=null,
@Status int=null,
@Qty float = null,
@ReqDate datetime
As
Update Payments Set
ProcProcuresId=@ProcProcuresId,
Status=@Status,
PaymentAmount=@PayAmt,
Qty=@Qty,
ReqDate=@ReqDate
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateOrg]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateOrg]
@Id int,
@Name nvarchar (70)='t1n',
@Desc ntext='t1d',
@Phone nvarchar (50)='t1d',
@Email nvarchar (50)='t1d',
@Addr ntext='t1a',
@LocId int = null,
@ProfileId int = null,
@Vis int=5
AS
if @ProfileId is null
Update Organizations
Set Name=@Name, Description=@Desc, Phone=@Phone, 
Email=@Email ,Address=@Addr, LocId=@LocId, Visibility=@Vis
Where Id=@Id;

else
Update Organizations
Set Name=@Name, Description=@Desc, Phone=@Phone, 
Email=@Email ,Address=@Addr, LocId=@LocId, Visibility=@Vis,
ProfileId=@ProfileId
Where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateFunds]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateFunds]
@Id int,
@Name nvarchar (150),
@Status int,
@Vis int
AS
Update  Funds Set
Name=@Name, 
Status=@Status,
Visibility=@Vis
Where
Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateFund]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[fms_UpdateFund]
@Id int,
@Name nvarchar (50),
@Status int,
@CurrenciesId int,
@Amt dec (20,2)=null,
@StartDate smalldatetime=null,
@EndDate smalldatetime=null
AS
Update  Funds Set
Name=@Name,
Status=@Status,
CurrenciesId=@CurrenciesId,
Amount=@Amt,
StartDate=@StartDate,
EndDate=@EndDate
Where
Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateCurrencies]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdateCurrencies]
@Id int,
@NameS nvarchar (150),
@NameP nvarchar (150),
@Code nvarchar (3),
@Status int=null
AS
Update  Currencies Set
Name =@NameS, 
NamePlural=@NameP, 
Code=@Code,
Status=@Status
Where
Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateCSStatesFlag]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[fms_UpdateCSStatesFlag]
@Id int,
@LocsFlag int= null
AS

Update ContractSuppliesStates
Set
LocsFlag=@LocsFlag
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateCSCountriesFlag]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_UpdateCSCountriesFlag]
@Id int,
@StatesFlag int= null
AS

Update ContractSuppliesCountries
Set
StatesFlag=@StatesFlag
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateContractSuppliesStates]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[fms_UpdateContractSuppliesStates]
@StatesId int,
@ContractSuppliesId int
AS

Insert into ContractSuppliesStates (ContractSuppliesId,StatesId)
Values(@ContractSuppliesId,@StatesId)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateContractSuppliesLocs]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[fms_UpdateContractSuppliesLocs]
@LocsId int,
@ContractSuppliesId int
AS

Insert into ContractSuppliesLocs (ContractSuppliesId,LocsId)
Values(@ContractSuppliesId,@LocsId)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateContractSuppliesCountries]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateContractSuppliesCountries]
@CountriesId int,
@ContractSuppliesId int
AS

Insert into ContractSuppliesCountries (ContractSuppliesId,CountriesId)
Values(@ContractSuppliesId,@CountriesId)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateContractS]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateContractS]
@Id int,
@Name nvarchar (100),
@Desc nvarchar (300),
@PayTerms int,
@StatusId int,
@ProcureMethodId int,
@Vis int,
@OrgIdSupplier int = null,
@Type int = null,
@ComDate smalldatetime=null,
@CurrId int
As
if @Type is not null

Update Contracts Set
Name=@Name,
Description=@Desc,
PayTerms=@PayTerms,
StatusId=@StatusId,
ProcureMethodId=@ProcureMethodId,
Visibility=@Vis,
OrgIdSupplier=@OrgIdSupplier,
OrgIndFlag=@Type,
CommitmentDate=@ComDate,
CurrId=@CurrId
Where Id=@Id

else

Update Contracts Set
Name=@Name,
Description=@Desc,
PayTerms=@PayTerms,
StatusId=@StatusId,
ProcureMethodId=@ProcureMethodId,
Visibility=@Vis,
CommitmentDate=@ComDate,
CurrId=@CurrId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateContractC]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateContractC]
@Id int,
@Name nvarchar (100),
@Desc nvarchar (300),
@PayTerms int,
@StatusId int,
@ProcureMethodId int,
@Vis int,
@OrgIdClient int = null
As
Update Contracts Set
Name=@Name,
Description=@Desc,
PayTerms=@PayTerms,
StatusId=@StatusId,
ProcureMethodId=@ProcureMethodId,
Visibility=@Vis,
OrgIdClient=@OrgIdClient
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateContact]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateContact]
@Id int,
@Name nvarchar (50)='na',
@RegularPhone nvarchar (50)='na',
@CellPhone nvarchar (50)='na',
@Email nvarchar (50)='na',
@Address nvarchar (50)='na',
@Caller nvarchar (50)='frmUpdContact'
AS
if @Caller = 'frmUpdContact'
Update Contacts
Set 
Name=@Name,
RegularPhone=@RegularPhone,
CellPhone=@CellPhone,
Email=@Email,
Address=@Address
Where Id=@Id
else if  @Caller = 'frmContacts'
Update Contacts
Set 
Name=@Name,
RegularPhone=@RegularPhone,
CellPhone=@CellPhone
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateClientAction]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateClientAction]
@Status int,
@Id int
AS
Update ClientActions
Set
Status=@Status
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudProjProcs]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[fms_UpdateBudProjProcs]
@Id int=null,
@ProjectsId int = null,
@PSEPId int,
@OrgId int,
@LocationsId int,
@BudOLServicesId int,
@BudAmt dec (20,2)=null,
@Flag int=null
As

if @ProjectsId is not null and @Flag is not null

Update BudProjProcs
Set
BudAmt=@BudAmt
Where 
ProjectsId = @ProjectsId and
BudOLServicesId=@BudOLServicesId and 
ProfileSEProcsId=@PSEPId and
BudProjProcs.OrgId = @OrgId and BudProjProcs.LocationsId = @LocationsId 

else if @ProjectsId is not null and @BudAmt is not null

Insert into BudProjProcs 
(ProjectsId,
OrgId,
LocationsId,
ProfileSEProcsId,
BudOLServicesId,
BudAmt
)
Values
(@ProjectsId,@OrgId,
@LocationsId,@PSEPId,@BudOLServicesId,   @BudAmt)

else if @Flag is not null

Update BudProjProcs 
Set
BudAmt=@BudAmt
Where 
ProjectsId is null and
BudOLServicesId=@BudOLServicesId and 
ProfileSEProcsId=@PSEPId and
BudProjProcs.OrgId = @OrgId and BudProjProcs.LocationsId = @LocationsId 

else if @BudAmt is not null

Insert into BudProjProcs 
(OrgId,
LocationsId,
ProfileSEProcsId,
BudOLServicesId,
BudAmt
)
Values
(@OrgId,
@LocationsId,@PSEPId,@BudOLServicesId, @BudAmt)
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveTypesOfImpactMagnitude]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveTypesOfImpactMagnitude]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
Select TypesOfImpactMagnitude.Id, TypesOfImpactMagnitude.Name
FROM  TypesOfImpactMagnitude inner join
Organizations on TypesOfImpactMagnitude.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
WHERE TypesOfImpactMagnitude.OrgId=@OrgId or
TypesOfImpactMagnitude.Visibility=1 or
TypesOfImpactMagnitude.Visibility=2 and DomainId=@DomainId or
TypesOfImpactMagnitude.Visibility=3 and LicenseId=@LicenseId or
TypesOfImpactMagnitude.Visibility=4 and ParentOrg=@OrgIdP
Order by TypesOfImpactMagnitude.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveTypesOfImpact]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveTypesOfImpact]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
Select TypesOfImpact.Id, TypesOfImpact.Name
FROM  TypesOfImpact inner join
Organizations on TypesOfImpact.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
WHERE TypesOfImpact.OrgId=@OrgId or
TypesOfImpact.Visibility=1 or
TypesOfImpact.Visibility=2 and DomainId=@DomainId or
TypesOfImpact.Visibility=3 and LicenseId=@LicenseId or
TypesOfImpact.Visibility=4 and ParentOrg=@OrgIdP
Order by TypesOfImpact.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveTypesOfDeadlines]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveTypesOfDeadlines]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
Select TypesOfDeadlines.Id, TypesOfDeadlines.Name
FROM  TypesOfDeadlines inner join
Organizations on TypesOfDeadlines.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
WHERE TypesOfDeadlines.OrgId=@OrgId or
TypesOfDeadlines.Visibility=1 or
TypesOfDeadlines.Visibility=2 and DomainId=@DomainId or
TypesOfDeadlines.Visibility=3 and LicenseId=@LicenseId or
TypesOfDeadlines.Visibility=4 and ParentOrg=@OrgIdP
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveTimetable]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveTimetable]
@PSEPId int,
@ProjectId int,
@OrgId int,
@LocationsId int
As
SELECT 
MAX(dbo.PSEPSteps.Id) AS StepId, MAX(dbo.Timetables.Id) AS Id, MAX(dbo.PSEPSteps.Seq) AS Seq, 
               MAX(dbo.PSEPSteps.Name) AS Name, MAX(dbo.Timetables.CompletionDate) AS CompletionDate, MAX(dbo.Timetables.Status) AS Status
FROM  dbo.Projects INNER JOIN
               dbo.ProfileServiceEvents ON dbo.Projects.PSEventsId = dbo.ProfileServiceEvents.Id INNER JOIN
               dbo.ProfileSEProcs ON dbo.ProfileServiceEvents.Id = dbo.ProfileSEProcs.ProfileSEventsId INNER JOIN
               dbo.Procs ON dbo.ProfileSEProcs.ProcsId = dbo.Procs.Id INNER JOIN
               dbo.PSEPSteps ON dbo.PSEPSteps.ProcsId = dbo.Procs.Id LEFT OUTER JOIN
               dbo.Timetables ON dbo.Timetables.ProjectId = dbo.Projects.Id AND dbo.Timetables.PSEPID = dbo.ProfileSEProcs.Id AND 
               dbo.Timetables.PSEPStepsId = dbo.PSEPSteps.Id
WHERE (dbo.Timetables.ProjectId = @ProjectId AND 
Timetables.OrgId = @OrgId AND Timetables.LocationsId = @LocationsId AND
Timetables.PSEPID = @PSEPId AND Timetables.Id IS NOT NULL) OR
               (dbo.Timetables.Id IS NULL  AND ProfileSEProcs.Id = @PSEPId AND Projects.Id = @ProjectId)
Group by PSEPSteps.Id
ORDER BY Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveTimesheetAdd]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveTimesheetAdd]
@PeopleId int
As
Select Tasks.Name as TaskName, Projects.Name as ProjectsName
From
StaffTasks inner join
Tasks on StaffTasks.TaskId=Tasks.Id inner join
Projects on StaffTasks.ProjectId=Projects.Id
Where StaffTasks.PeopleId=@PeopleId and
StaffTasks.Status=1 -- i.e. open
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveTasks]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveTasks]
@ProjectId int
 AS
Select ProfileSEProcs.Id, ProfileSEProcs.Name as PSEPName

From
ProfileServiceEvents inner join
Projects on ProfileServiceEvents.Id=Projects.PSEventsId inner join
ProfileSEProcs on  ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId

Where 
Projects.Id=@ProjectId 

Order by ProfileSEProcs.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveStates]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveStates]
@CountriesId int=0,
@Status int=null
AS

Select Id, Name
from States
Where CountriesId=@CountriesId and Status = @Status
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveStaffTasks]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveStaffTasks]
@PeopleId int
As
SELECT 
OLPPPeople.Id,
People.FName + ' ' + People.LName AS Name,
StaffActions.PeopleId,  
OLPPPeople.StartDate, OLPPPeople.EndDate, OLPPPeople.StartStatus, OLPPPeople.EndStatus,
OLPPPeople.BkupFlag, Roles.Name AS RoleName, 
ProjectTypes.Nameshort + ': ' + Projects.Name AS ProjectName,
Locations.Name as LocationName,
Events.Name + ' (' + Procs.Name + ')' as ProcName
FROM  OLPSPeople INNER JOIN
               PSEPStaff ON OLPSPeople.PSEPSID = PSEPStaff.Id INNER JOIN
               ProfileSEProcs ON ProfileSEProcs.Id = PSEPStaff.PSEPID INNER JOIN
               OLPPPeople ON OLPPPeople.OLPSPID = OLPSPeople.Id INNER JOIN
               StaffActions ON OLPSPeople.StaffActionsId = StaffActions.Id INNER JOIN
               People ON People.Id = StaffActions.PeopleId INNER JOIN
               Roles ON PSEPStaff.RolesId = Roles.Id INNER JOIN
              OrgLocations on OLPSPeople.OrgLocId=OrgLocations.Id inner join
	Locations on OrgLocations.LocId=Locations.Id inner join 
	Projects on Projects.Id=OLPPPeople.ProjectId inner join
	ProjectTypes on Projects.Type=ProjectTypes.Id inner join
	Procs on Procs.Id=ProfileSEProcs.ProcsId inner join
	ProfileServiceEvents on ProfileSEProcs.ProfileSEventsId=EventsId inner join
	Events on ProfileServiceEvents.EventsId=Events.Id
WHERE (StaffActions.PeopleId = @PeopleId)
Order by Locations.Name, ProjectName, ProcName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveSEvents]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveSEvents]
@ServicesId int
As
SELECT
ServiceEvents.Id,
Events.Id as EventsId, 
 Events.Name,
Events.Description,
Events.OrgId, Events.Visibility,
ServiceEvents.Seq
From
ServiceEvents inner join
Events on Events.Id=ServiceEvents.EventsId
WHERE ServiceEvents.ServicesId=@ServicesId 
Order by ServiceEvents.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveServiceTypes]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveServiceTypes]
@OrgId int,
@OrgIdP int = 0,
@LicenseId int = 0,
@DomainId int = 0, 
@PeopleId int = null,
@HHFlag int=null
As
if @HHFlag is not null
SELECT  ServiceTypes.Id,  ServiceTypes.Name, ServiceTypes.QtyMeasuresId,
ServiceTypes.Seq, ParentId,
ServiceTypes.ProjName, ServiceTypes.ProjNameS,
ServiceTypes.TypeId as FunctionId, ServiceTypes.Description,
HouseholdFlag as HHFlag
FROM ServiceTypes
inner join Organizations on ServiceTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where  ServiceTypes.HouseholdFlag=@HHFlag
Order by  ServiceTypes.HouseholdFlag, ServiceTypes.Seq, ServiceTypes.Name

else

if @PeopleId is not null
SELECT  ServiceTypes.Id,  ServiceTypes.Name, ServiceTypes.QtyMeasuresId,
ServiceTypes.Seq, ParentId,
ServiceTypes.ProjName, ServiceTypes.ProjNameS,
ServiceTypes.TypeId as FunctionId, ServiceTypes.Description,
HouseholdFlag as HHFlag
FROM ServiceTypes inner join 
Organizations on ServiceTypes.OrgId=Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id inner join
PeopleServiceTypes on ServiceTypes.Id=PeopleServiceTypes.ServiceTypesId
Where PeopleServiceTypes.PeopleId=@PeopleId 
Order by  ServiceTypes.HouseholdFlag, ServiceTypes.Seq, ServiceTypes.Name
 
Else if @Domainid != 0
SELECT  ServiceTypes.Id,  ServiceTypes.Name, ServiceTypes.QtyMeasuresId,
ServiceTypes.Seq, ParentId,
ServiceTypes.ProjName, ServiceTypes.ProjNameS,
ServiceTypes.TypeId as FunctionId, ServiceTypes.Description,
HouseholdFlag as HHFlag
FROM ServiceTypes
inner join Organizations on ServiceTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where  ServiceTypes.Visibility=1
or ( ServiceTypes.Visibility=2 and DomainId=@DomainId)
or ( ServiceTypes.Visibility=3 and  LicenseId=@LicenseId)
or ( ServiceTypes.Visibility=4 and ParentOrg=@OrgIdP)
or ( ServiceTypes.Visibility=5 and  ServiceTypes.OrgId=@OrgId)
Order by  ServiceTypes.HouseholdFlag, ServiceTypes.Seq, ServiceTypes.Name

Else

SELECT ServiceTypes.Name, ServiceTypes.Description, ServiceTypes.Id, ServiceTypes.ParentId,
Visibility as VisId, ServiceTypes.QtyMeasuresId, ServiceTypes.Seq, ServiceTypes.ProjName, ServiceTypes.ProjNameS,
ServiceTypes.TypeId as FunctionId, ServiceTypes.Description,
HouseholdFlag as HHFlag
FROM 
ServiceTypes inner join
 Visibility on ServiceTypes.Visibility=Visibility.Id 
Where ServiceTypes.OrgId=@OrgId 
Order by  ServiceTypes.HouseholdFlag, ServiceTypes.Seq, ServiceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveSEProcsUpd]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveSEProcsUpd]
@Id int
 AS
Select
SEProcs.ProcsId,--0
Procs.ServiceTypesId--1
from SEProcs inner join
Procs on SEProcs.ProcsId=Procs.Id
Where SEProcs.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveSEProcs]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveSEProcs]
@ServiceEventsId int
 AS
Select Id,  Seq
From SEProcs
Where SEProcs.ServiceEventsId=@ServiceEventsId
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveSCLocs]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveSCLocs]
@StaffActionsId int,
@OrgId int
 AS

Select Locations.Id, Locations.Name
From
OLPSPeople inner join  
PSEPStaff on OLPSPeople.PSEPSID =PSEPStaff.Id inner join
ProfileSEProcs on ProfileSEProcs.Id=PSEPStaff.PSEPID inner join
ProfileServiceEvents on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileServiceTypes on ProfileServiceEvents.ProfileServicesId=ProfileServiceTypes.Id inner join
OrgLocations on  OrgLocations.Id=OLPSPeople.OrgLocId inner join
Organizations on  OrgLocations.OrgId=Organizations.Id inner join
Locations on Locations.Id=OrgLocations.LocId 
Where OLPSPeople.StaffActionsId=@StaffActionsId and 
OrgLocations.OrgId=@OrgId
Group by Locations.Id, Locations.Name
Order by Locations.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveRoles]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveRoles]
@DomainId int,
@LicenseId int,
@OrgIdP int,
@OrgId int

As

Select Roles.Id, Roles.Name, Roles.ParentId, Roles.Visibility
 from Roles inner join Organizations
on Roles.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where Roles.Visibility=1 or Roles.OrgId=5 
or (Roles.Visibility =2 and Licenses.DomainId= @DomainId)
or (Roles.Visibility=3 and Organizations.LicenseId= @LicenseId)
or (Roles.Visibility=4 and Organizations.ParentOrg= @OrgIdP)
Order by Roles.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveResTypesAll]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[wms_RetrieveResTypesAll]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int,
@RType int 

AS

SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes
inner join Organizations on ResourceTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id 
Where (ResourceTypes.Type = @RType) and 
(ResourceTypes.Visibility=1 or ResourceTypes.OrgId=@OrgId
or ( ResourceTypes.Visibility=2 and DomainId=@DomainId)
or ( ResourceTypes.Visibility=3 and  LicenseId=@LicenseId)
or ( ResourceTypes.Visibility=4 and ParentOrg=@OrgIdP))
Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveResourceTypesO]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_RetrieveResourceTypesO]
@ProcsId int,
@RType int
As
SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes
inner join ProcResOutputs on ResourceTypes.Id=ProcResOutputs.ResTypesId
Where (ResourceTypes.Type = @RType) and
ProcResOutputs.ProcsId=@ProcsId
Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveResourceTypesI]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_RetrieveResourceTypesI]
@ProcsId int,
@RType int
As
SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes
inner join ProcRes on ResourceTypes.Id=ProcRes.ResTypesId
Where (ResourceTypes.Type = @RType) and
ProcRes.ProcsId=@ProcsId
Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveResourceTypes]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveResourceTypes]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int,
@RType int =null,
@HHFlag int=null
As
If @HHFlag is not null

SELECT Max(ResourceTypes.Id) as Id,  
Max(ResourceTypes.Name) as Name, 
Max(ResourceTypes.Visibility) as Visibility, 
Max(ResourceTypes.ParentId) as ParentId,
Max(ResourceTypes.QtyMeasuresId) as QtyMeasuresId,
Max(ResourceTypes.Type) as Type
FROM ResourceTypes inner join 
PSEResources on PSEResources.ResourceTypesId=ResourceTypes.Id inner join 
Organizations on ResourceTypes.OrgId=Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id 
Where 
ResourceTypes.Visibility=1 or ResourceTypes.OrgId=@OrgId
or ( ResourceTypes.Visibility=2 and DomainId=@DomainId)
or ( ResourceTypes.Visibility=3 and  LicenseId=@LicenseId)
or ( ResourceTypes.Visibility=4 and ParentOrg=@OrgIdP)
Group by ResourceTypes.Id
Order by  Type, Name

else If @Domainid != 0 and @RType is not null

SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes
inner join Organizations on ResourceTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id inner join
ProfileResourceTypes on Organizations.ProfileId=ProfileResourceTypes.ProfilesId and 
ProfileResourceTypes.ResourceTypesId=ResourceTypes.ParentId
Where (ResourceTypes.Type = @RType) and 
(ResourceTypes.Visibility=1 or ResourceTypes.OrgId=@OrgId
or ( ResourceTypes.Visibility=2 and DomainId=@DomainId)
or ( ResourceTypes.Visibility=3 and  LicenseId=@LicenseId)
or ( ResourceTypes.Visibility=4 and ParentOrg=@OrgIdP))
Order by  ResourceTypes.Name

Else If @Domainid != 0

SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes inner join
Organizations on ResourceTypes.OrgId=Organizations.Id inner join
ProfileResourceTypes on Organizations.ProfileId=ProfileResourceTypes.ProfilesId and 
ProfileResourceTypes.ResourceTypesId=ResourceTypes.ParentId inner join 
Licenses on Organizations.LicenseId=Licenses.Id
Where ResourceTypes.Visibility=1 or ResourceTypes.OrgId=@OrgId
or ( ResourceTypes.Visibility=2 and DomainId=@DomainId)
or ( ResourceTypes.Visibility=3 and  LicenseId=@LicenseId)
or ( ResourceTypes.Visibility=4 and ParentOrg=@OrgIdP)
Order by  ResourceTypes.Name

Else 

SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes inner join
Organizations on ResourceTypes.OrgId=Organizations.Id inner join
ProfileResourceTypes on Organizations.ProfileId=ProfileResourceTypes.ProfilesId and 
ProfileResourceTypes.ResourceTypesId=ResourceTypes.ParentId inner join 
Licenses on Organizations.LicenseId=Licenses.Id

Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSModelEvents]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSModelEvents] 
@PSModelId int
AS
Select Events.Id, Events.Name,  
ProfileServiceEvents.Id as MapPSEId
from 
Events inner join
ProfileServiceEvents on ProfileServiceEvents.EventsId=Events.Id
Where ProfileServiceEvents.ProfileServicesId=@PSModelId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEResources]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEResources]
@ProfilesId int,
@EventsId int
As

SELECT  PSEResources.Id, pseresources.description as "desc"
From
PSEResources inner join
ProfileServiceEvents on PSEResources.ProfileServiceEventsId=ProfileServiceEvents.Id inner join
ProfileServiceTypes on  ProfileServiceTypes.Id=ProfileServiceEvents.ProfileServicesId

/*WHERE ProfileServiceEvents.EventsId =@EventsId
and 
ProfileServiceTypes.ProfilesId=@ProfilesId*/
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEResDesc]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEResDesc]
@ProfilesId int,
@ServiceTypesId int,
@EventsId int,
@RType int
As

SELECT  PSEResources.Id,
ResourceTypes.Name,
PSEResources.Description as 'Desc', 
PSEResources.LocTypesId
From
PSEResources inner join 
ResourceTypes on PSEResources.ResourceTypesId=ResourceTypes.Id

WHERE PSEResources.ProfilesId=@ProfilesId and
ServiceTypesId =@ServiceTypesId and
EventsId =@EventsId and ResourceTypes.Type=@RType
Order by PSEResources.LocTypesId, ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPSteps]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPSteps]
@ProcsId int
 AS
/*Select Max(ProfileSEPStepTypes.Id) as Id,  Max(ProfileSEPStepTypes.Seq) as  Seq, Max(StepTypes.Name) as Name,
Count(ProfileSEPSStaff.Id) as RoleCount,  
Count(ProfileSEPSSer.Id) as SerCount, 
Count(ProfileSEPSRes.Id) as ResCount
From
ProfileSEPStepTypes inner join
StepTypes on ProfileSEPStepTypes.StepTypesId=StepTypes.Id inner join
ProfileSEPSStaff on ProfileSEPSStaff.ProfileSEPStepTypesId=ProfileSEPStepTypes.Id inner join
ProfileSEPSSer on ProfileSEPSSer.ProfileSEPStepTypesId=ProfileSEPStepTypes.Id inner join
ProfileSEPSRes on ProfileSEPSRes.ProfileSEPStepTypesId=ProfileSEPStepTypes.Id
Where ProfileSEProcsId=@ProfileSEProcsId
Group by ProfileSEPStepTypes.Id, ProfileSEPStepTypes.Seq
Order by ProfileSEPStepTypes.Seq
GO*/
Select PSEPSteps.Id as Id,  PSEPSteps.Seq, PSEPSteps.Name, PSEPSteps.Description,
'1'  as RoleCount,  
'1' as SerCount, 
'1' as ResCount
From
PSEPSteps
Where ProcsId=@ProcsId
Order by PSEPSteps.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPStaff]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPStaff]
@ProcsId int
As
SELECT PSEPStaff.Id, PSEPStaff.ProcsId,
PSEPStaff.RolesId, PSEPStaff.Description,
Roles.Name as RoleName
From
PSEPStaff inner join Roles on PSEPStaff.RolesId=Roles.Id
WHERE PSEPStaff.ProcsId=@ProcsId
Order by Roles.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPSPeople]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPSPeople]
@PSEPSID int = null,
@OrgId int,
@LocationsId int,
@ProjectId int=null
AS

if (@ProjectId is not null)

Select PSEPSPeople.Id, 
PSEPSPeople.Description, 
PSEPSPeople.PeopleId, 
'PeopleName'=
Case
when PSEPSPeople.PeopleId is null then 'Vacant'
Else  
People.FName + ' ' + People.LName
End,
'Backup' = 
Case
When PSEPSPeople.BackupSeq is null then  ''
Else ' (Backup)'
End,
PSEPSPeople.Qty,
PSEPSPeople.TimeMeasure,
PSEPSPeople.PayGrade,
PSEPSPeople.StaffType,
PSEPSPeople.FundsId,
PSEPSPeople.OrgId

From
PSEPSPeople left outer join 
People on PSEPSPeople.PeopleId=People.Id 
Where 
(PSEPSPeople.PSEPSID=@PSEPSID and
PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId=@ProjectId )
or
(PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId=@ProjectId )
or
(PSEPSPeople.PSEPSID is null and
PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId=@ProjectId )

Order by PeopleName

else

Select PSEPSPeople.Id, 
PSEPSPeople.Description, PSEPSPeople.PeopleId,
'PeopleName'=
Case
when PSEPSPeople.PeopleId is null then 'Vacant'
Else  
People.FName + ' ' + People.LName
End,
'Backup' = 
Case
When PSEPSPeople.BackupSeq is null then  ''
Else ' (Backup)'
End,
PSEPSPeople.Qty,
PSEPSPeople.TimeMeasure,
PSEPSPeople.PayGrade,
PSEPSPeople.StaffType,
PSEPSPeople.FundsId,
PSEPSPeople.OrgId

From
PSEPSPeople left outer join
People on PSEPSPeople.PeopleId=People.Id 
Where 
(PSEPSPeople.PSEPSID=@PSEPSID and
PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId is null)
or 
(PSEPSPeople.PSEPSID is null and
PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId is null)

Order by PSEPSPeople.BackupSeq, PeopleName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPSPBud]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPSPBud]
@PSEPSID int = null,
@OrgId int,
@LocationsId int,
@BudgetsId int = null,
@ProjectId int=null
AS

if (@ProjectId is not null)

Select 
Max(PSEPSPeople.Id) as Id, 
Max(PSEPSPeople.PeopleId) as PeopleId,
'PeopleName'=
Case
when Max(PSEPSPeople.PeopleId) is null then 'Vacant'
Else  
Max(People.FName) + ' ' + Max(People.LName)
End,
'Backup' = 
Case
When Max(PSEPSPeople.BackupSeq) is null then  ''
Else ' (Backup)'
End,
Max(PSEPSPeople.Qty) as Qty,
Max(PSEPSPeople.TimeMeasure) as TimeMeasure,
Max(PSEPSPeople.PayGrade) as PayGrade,
Max(PSEPSPeople.StaffType) as StaffTyp,
Sum(TaskBudgets.BudAmt) as BudAmt,
Max(TaskBudgets.Price) as Price,
Max(ProfileSEProcs.Name) as Process,
Max(ProfileSEProcs.Seq) as Seq,
Max(Roles.Name) as Role

From
PSEPSPeople inner join
Projects on PSEPSPeople.ProjectId=Projects.Id inner join
ProfileServiceEvents on Projects.PSEventsId=ProfileServiceEvents.Id inner join
ProfileSEProcs on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
Procs on ProfileSEProcs.ProcsId=Procs.Id inner join
PSEPStaff on PSEPStaff.ProcsId=Procs.Id and PSEPSPeople.PSEPSId=PSEPStaff.Id inner join
Roles on PSEPStaff.RolesId=Roles.Id left outer join 
People on PSEPSPeople.PeopleId=People.Id left outer join
TaskBudgets on PSEPSPeople.Id=TaskBudgets.PSEPSPeopleId 
Where 
(PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId=@ProjectId and TaskBudgets.Id is null)
or
(PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId=@ProjectId and TaskBudgets.BudgetsId = @BudgetsId)


Group by PSEPSPeople.Id
Order by Seq, Role, PeopleName

else

Select PSEPSPeople.Id, 
PSEPSPeople.Description, PSEPSPeople.PeopleId,
'PeopleName'=
Case
when PSEPSPeople.PeopleId is null then 'Vacant'
Else  
People.FName + ' ' + People.LName
End,
'Backup' = 
Case
When PSEPSPeople.BackupSeq is null then  ''
Else ' (Backup)'
End,
PSEPSPeople.Qty,
PSEPSPeople.TimeMeasure,
PSEPSPeople.PayGrade,
PSEPSPeople.StaffType,

TaskBudgets.BudAmt,
TaskBudgets.Price
From
PSEPSPeople left outer join
People on PSEPSPeople.PeopleId=People.Id left outer join
TaskBudgets on PSEPSPeople.Id=TaskBudgets.PSEPSPeopleId
Where 
(PSEPSPeople.PSEPSID=@PSEPSID and
PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and
ProjectId is null)
or 
(PSEPSPeople.PSEPSID is null and
PSEPSPeople.OrgId=@OrgId and
PSEPSPeople.LocationsId=@LocationsId and

ProjectId is null)

Order by PSEPSPeople.BackupSeq, PeopleName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPRInv]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPRInv]
@PSEPResID int,
@ProjectId int = null,
@OrgId int,
@LocationsId int
AS
if (@ProjectId is null)

Select PSEPResInventory.Id, 
'ItemName'=
Case
When PSEPResInventory.InventoryId is not null then Inventory.Name 
When PSEPResInventory.ContractsId is not null then Contracts.Name
else 'To Be Identified'
End,
PSEPResInventory.Qty,
PSEPResInventory.Price,
Organizations.Name as OrgName,
Locations.Name as LocName,
'Sublocation'=
Case
When PSEPResInventory.InventoryId is not null then 
Inventory.Sublocation
else ' '
End,
InventoryStatus.Name as Status,
PSEPResInventory.BackupFlag,
PSEPResInventory.BudgetsId
From
PSEPResInventory left outer join
Inventory on PSEPResInventory.InventoryId=Inventory.Id inner join
PSEPRes on PSEPResInventory.PSEPResId=PSEPRes.Id inner join
ResourceTypes on ResourceTypes.Id=PSEPRes.ResTypesId left outer join
Organizations on Inventory.OrgId=Organizations.Id left outer join
Locations on Inventory.LocId=Locations.Id left outer join
InventoryStatus on Inventory.StatusId=InventoryStatus.Id left outer join
Contracts on  PSEPResInventory.ContractsId=Contracts.Id
Where 
PSEPResInventory.PSEPResID=@PSEPResID and
PSEPResInventory.OrgId = @OrgId and PSEPResInventory.LocationsId = @LocationsId and
ProjectId is null

Order by  Inventory.Name, PSEPResInventory.BackupFlag

Else

Select PSEPResInventory.Id, 
'ItemName'=
Case
When PSEPResInventory.InventoryId is not null then Inventory.Name
When PSEPResInventory.ContractsId is not null then Contracts.Name
else 'To Be Identified'
End,
Organizations.Name as OrgName,
Locations.Name as LocName,
'Sublocation'=
Case
When PSEPResInventory.InventoryId is not null then 
Inventory.Sublocation
else ' '
End,
PSEPResInventory.Qty,
PSEPResInventory.Price,

InventoryStatus.Name as Status,
'BackupFlag'=
Case
When PSEPResInventory.BackupFlag is null then 0
else PSEPResInventory.BackupFlag
End,
PSEPResInventory.BudgetsId
From
PSEPResInventory left outer join
Inventory on PSEPResInventory.InventoryId=Inventory.Id inner join
PSEPRes on PSEPResInventory.PSEPResId=PSEPRes.Id inner join
ResourceTypes on ResourceTypes.Id=PSEPRes.ResTypesId left outer join
Organizations on Inventory.OrgId=Organizations.Id left outer join
Locations on Inventory.LocId=Locations.Id left outer join
InventoryStatus on Inventory.StatusId=InventoryStatus.Id left outer join
Contracts on  PSEPResInventory.ContractsId=Contracts.Id
Where 
PSEPResInventory.PSEPResID=@PSEPResID and
PSEPResInventory.OrgId = @OrgId and PSEPResInventory.LocationsId = @LocationsId and 
ProjectId=@ProjectId 

Order by  Inventory.Name, PSEPResInventory.BackupFlag
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPRes]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPRes]
@ProcsId int = null,
@RType int = 0
As

SELECT  PSEPRes.Id,
ResTypesId, PSEPRes.Description,
ResourceTypes.Name as ResourceName
From
PSEPRes inner join 
ResourceTypes on PSEPRes.ResTypesId=ResourceTypes.Id

WHERE PSEPRes.ProcsId =@ProcsId and ResourceTypes.Type=@RType
Order by ResourceTypes.Name

/*SELECT  ProcRes.Id,
ResTypesId, ProcRes.Description,
ResourceTypes.Name as ResourceName
From
ProcRes inner join 
ResourceTypes on ProcRes.ResTypesId=ResourceTypes.Id

WHERE ProcRes.ProcsId =@ProcsId and ResourceTypes.Type=@RType
Order by ResourceTypes.Name*/
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPProjectTypes]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPProjectTypes]
@ProjTypesId int,
@ProfilesId int
 AS
Select ProjTypesPSEP.Id, ProjTypesPSEP.Seq, ProfileSEProcs.Name
From 
ProfileSEProcs inner join
ProjTypesPSEP on ProjTypesPSEP.PSEPId=ProfileSEProcs.Id inner join
ProfileServiceEvents on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id  inner join
ProfileServiceTypes on ProfileServiceEvents.ProfileServicesId=ProfileServiceTypes.Id
Where ProjTypesPSEP.ProjectTypesId=@ProjTypesId and
ProfileServiceTypes.ProfilesId=@ProfilesId
Order by ProjTypesPSEP.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPProj]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPProj]
@ProjTypesId int,
@PSEPId int,
@ProfileId int
 AS
Select ProfileSEProcs.Id
From ProfileSEProcs inner join
ProjTypesPSEP on ProjTypesPSEP.PSEPId=ProfileSEProcs.Id

Where ProjTypesPSEP.ProjectTypesId=@ProjTypesId and
ProjTypesPSEP.PSEPId = @PSEPId and
ProjTypesPSEP.ProfileId = @ProfileId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPO]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPO]
@PSEPID int,
@RType int=null
AS

if @RType is not null

Select PSEPResOutputs.Id,
ResourceTypes.Name,
QtyMeasures.Name as QtyMeasure,
'' as Qty,
'' as QtyId,
'' as "Desc"
From
PSEPResOutputs inner join
ResourceTypes on PSEPResOutputs.ResourceTypesId=ResourceTypes.Id inner join 
QtyMeasures on QtyMeasures.Id=ResourceTypes.QtyMeasuresId 
Where PSEPResOutputs.PSEPID=@PSEPID and 
ResourceTypes.Type=@RType

else
Select PSEPResOutputs.Id,
ResourceTypes.Name,
QtyMeasures.Name as QtyMeasure,
OLSEPOutputQty.Qty as Qty,
OLSEPOutputQty.Id as QtyId,
'' as "Desc"
From
PSEPResOutputs inner join
ResourceTypes on PSEPResOutputs.ResourceTypesId=ResourceTypes.Id inner join
QtyMeasures on QtyMeasures.Id=ResourceTypes.QtyMeasuresId left outer join
OLSEPOutputQty on OLSEPOutputQty.PSEPResOutputsId=PSEPResOutputs.Id
 
Where PSEPResOutputs.PSEPID=@PSEPID
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPDetail]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPDetail]
@PSEPID int
 AS
Select
Sum(PSEPStaff.Id) as StaffCount, --0
Sum(PSEPRes.Id) as OtherCount,--1
Sum (PSEPSteps.Id) as StepCount, --2
Sum (PSEPResOutputs.Id) as OutputCount--3
FROM ProfileSEProcs Left Outer Join
	Procs on ProfileSEProcs.ProcsId = Procs.Id Left Outer Join
	PSEPStaff on PSEPStaff.ProcsId=Procs.Id Left Outer Join
	PSEPSteps on PSEPSteps.ProcsId=Procs.Id Left Outer Join
	PSEPRes on PSEPRes.ProcsId=Procs.Id left outer join
	PSEPResOutputs on PSEPResOutputs.PSEPID = ProfileSEProcs.Id 
WHERE ProfileSEProcs.Id = @PSEPID
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPCImpact]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPCImpact]
@PSEPClientsId int
As
SELECT PSEPClientEvents.Id, 
PSEPClientEvents.EventsId, PSEPClientEvents.Description,
Events.Name as Name
From
PSEPClientEvents inner join Events on PSEPClientEvents.EventsId=Events.Id
WHERE PSEPClientEvents.PSEPClientsId=@PSEPClientsId
Order by Events.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEPAll]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEPAll]
@ProfileId int
 AS
Select ProfileSEProcs.Id,  ProfileSEProcs.Seq, 
ProfileSEProcs.Name, ProfileSEProcs.Timetables
From ProfileSEProcs inner join
ProfileServiceEvents on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id inner join
ProfileServiceTypes on ProfileServiceEvents.ProfileServicesId=ProfileServiceTypes.Id
Where ProfileServiceTypes.ProfilesId=@ProfileId
Order by ProfileSEProcs.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEId]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEId]
@ProfileServicesId int,
@EventsId int,
@MapPSEId int
 AS
Select Max(ProfileServiceEvents.Id)
from
ProfileServiceEvents
Where 
ProfileServicesId=@ProfileServicesId and
EventsId=@EventsId and
MapId=@MapPSEId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEClientsUpd]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_RetrievePSEClientsUpd]
@Id int
 AS
Select
Type, --0
TypesOfDeadlinesId,--1
AcceptableSlip,--2
TypesOfImpactId,--3
TypesOfImpactMagnitudeId,--4
DollarCostSlip,--5
ProfileServiceEventsId--6
from PSEClients
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePSEClients]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrievePSEClients]
@PSEID int
As
SELECT PSEClients.Id, PSEClients.ProfileServiceEventsId,
PSEClients.ClientsId, PSEClients.Description,
Clients.Name as ClientsName
From
PSEClients inner join 
Clients on PSEClients.ClientsId=Clients.Id
WHERE PSEClients.ProfileServiceEventsId=@PSEID
Order by Clients.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjTypeServiceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjTypeServiceTypes]
@ProfileId int
As
SELECT  ServiceTypes.Id,
ServiceTypes.Name
FROM 
ProfileServiceTypes inner join 
ServiceTypes on ProfileServiceTypes.ServiceTypesId= ServiceTypes.Id
WHERE ProfileServiceTypes.ProfilesId=@ProfileId
Order by ServiceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjPeopleAdd]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjPeopleAdd]
@OrgLocId int,
@PSEPID int
As

SELECT 
ProcSARs.Id, Roles.Name as RoleName,
PeopleId, People.FName + ' ' + People.LName as Name

From 

ProcSARs inner join
PSEPStaff on PSEPStaff.Id=PSEPSID inner join
Roles on PSEPStaff.RolesId=Roles.Id inner join
StaffActions on ProcSARs.StaffActionsId=StaffActions.Id inner join
People on StaffActions.PeopleId=People.Id
Where PSEPStaff.PSEPID=@PSEPID and
ProcSARs.OrgLocId=@OrgLocId 
Order by People.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjOLPSEP]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjOLPSEP]
@ProjectsId int = null,
@OrgId int = null,
@LocationsId int = null
AS

SELECT  
ProfileSEProcsId,
StartDate as StartDate,
EndDate as CompletionDate,
StartStatus as StartStatus,
EndStatus as EndStatus
FROM 
ProjOLPSEP
Where
ProjectsId=@ProjectsId and 
OrgId=@OrgId and LocationsId=@LocationsId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjectTypes]
@DomainId int,
@LicenseId int,
@OrgIdP int,
@OrgId int
As
SELECT .ProjectTypes.Name,ProjectTypes.Id, ProjectTypes.Visibility as Vis, 
ProjectTypes. Nameshort,--ProjectTypes.ServiceTypesId as Ser,
ProjectTypes.Seq
FROM  ProjectTypes inner join Organizations on ProjectTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where ProjectTypes.Visibility = 1 or
ProjectTypes.Visibility=2 and Licenses.DomainId=@DomainId or
ProjectTypes.Visibility=3 and Organizations.LicenseId=@LicenseId or
ProjectTypes.Visibility=4 and Organizations.ParentOrg=@OrgIdP or
ProjectTypes.OrgId=@OrgId
Order by ProjectTypes.Seq, ProjectTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectType]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjectType]

@PSEPId int,
@ProfileId int
 AS
Select ProjectTypes.Id, ProjectTypes.Name
From ProfileSEProcs inner join
ProjTypesPSEP on ProjTypesPSEP.PSEPId=ProfileSEProcs.Id inner join
ProjectTypes on ProjTypesPSEP.ProjectTypesId=ProjectTypes.Id

Where 
ProjTypesPSEP.PSEPId = @PSEPId and
ProjTypesPSEP.ProfileId = @ProfileId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectStepsNew]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjectStepsNew]
@PSEPID int
AS
SELECT  null as Id, ProfileSEPStepTypes.Seq, StepTypes.Name, 
 null as 'CompletionDate', null as 'Status', ProfileSEPStepTypes.Id as StepId
FROM  Organizations inner join
               ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
               ProfileServiceEvents ON ProfileServiceTypes.Id = ProfileServiceEvents.ProfileServicesId INNER JOIN
	ProfileSEProcs on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id inner join
	ProfileSEPStepTypes on ProfileSEPStepTypes.ProfileSEProcsId = ProfileSEProcs.Id inner join
StepTypes on ProfileSEPStepTypes.StepTypesId = StepTypes.Id
WHERE   ProfileSEProcs.Id = @PSEPID
Order by ProfileSEPStepTypes.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectsPlan]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjectsPlan]
@PSEventId int=null,
@PSEPId int=null,
@OrgId int,
@LocationsId int
AS
if @PSEventId is not null

Select Projects.Id as Id, Projects.Name as 'PName', Projects.Status, 
Projects.Visibility as Vis,
null as ProjectsPeopleId, Organizations.Name as MgrName,
Locations.Name as LocName,
null as 'ExtFlag'
From
Projects  inner join
Organizations on Organizations.Id=Projects.OrgId inner join
Locations on Locations.Id=Projects.LocationsId inner join
ProfileServiceEvents on Projects.PSEventsId=ProfileServiceEvents.Id inner join
Events on ProfileServiceEvents.EventsId=Events.Id
Where 
Projects.OrgId = @OrgId and Projects.LocationsId = @LocationsId and
Projects.PSEventsId = @PSEventId and
(Projects.Status = 'Started' or Projects.Status = 'Planned') 

Union

Select Projects.Id as Id, Projects.Name + ' (External)' as 'PName', Projects.Status, 
Projects.Visibility as Vis,
null as ProjectsPeopleId, Organizations.Name as MgrName,
Locations.Name as LocName,
'1' as 'ExtFlag'
From
Projects  inner join
Organizations on Organizations.Id=Projects.OrgId inner join
Locations on Locations.Id=Projects.LocationsId inner join
ProfileServiceEvents on Projects.PSEventsId=ProfileServiceEvents.Id inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
ProjOrgLoc on ProjOrgLoc.ProjectsId=Projects.Id
Where 
Projects.OrgId != @OrgId and Projects.LocationsId ! = @LocationsId and
ProjOrgLoc.OrgId=@OrgId and ProjOrgLoc.LocationsId = @LocationsId and
Projects.PSEventsId=@PSEventId and
(Projects.Status = 'Started' or Projects.Status = 'Planned') 
Order by PName

else

Select Projects.Id as Id, Projects.Name as 'PName', Projects.Status, 
Projects.Visibility as Vis,
null as ProjectsPeopleId, Organizations.Name as MgrName,
Locations.Name as LocName, 
Events.Name as 'Type',
ProfileSEProcs.Name as PSEPName,
ProfileSEProcs.Id as PSEPId, 
'x' as BudFlag

From
Projects  inner join
Organizations on Organizations.Id=Projects.OrgId inner join
Locations on Locations.Id=Projects.LocationsId inner join
ProfileServiceEvents on Projects.PSEventsId=ProfileServiceEvents.Id inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
ProfileSEProcs on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id

Where 
Projects.OrgId = @OrgId and Projects.LocationsId = @LocationsId
and (Projects.Status = 'Started' or Projects.Status = 'Planned') 

Union

Select Projects.Id as Id, Projects.Name + ' (External)' as 'PName', Projects.Status, 
Projects.Visibility as Vis,
null as ProjectsPeopleId, Organizations.Name as MgrName,
Locations.Name as LocName,
Events.Name as 'Type',
ProfileSEProcs.Name as PSEPName,
ProfileSEProcs.Id as PSEPId,
'x' as BudFlag

From

Projects  inner join
Organizations on Organizations.Id=Projects.OrgId inner join
Locations on Locations.Id=Projects.LocationsId inner join
ProfileServiceEvents on Projects.PSEventsId=ProfileServiceEvents.Id inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
ProjOrgLoc on ProjOrgLoc.ProjectsId=Projects.Id inner join
ProfileSEProcs on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id

Where 
Projects.OrgId != @OrgId and Projects.LocationsId ! = @LocationsId and
ProjOrgLoc.OrgId=@OrgId and ProjOrgLoc.LocationsId = @LocationsId and
(Projects.Status = 'Started' or Projects.Status = 'Planned') 

Order by Events.Name, PName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectsO]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjectsO]
@PSEventsId int,
@OrgLocId int,
@DomainId int,
@LicenseId int,
@OrgIdP int
AS
SELECT Projects.Id, Projects.Name as ProjName,
Projects.Status, Organizations.Name as MgrName, Locations.Name as LocName
FROM Projects inner join
OrgLocations on Projects.OrgLocId=OrgLocations.Id inner join
Organizations on Organizations.Id=OrgLocations.OrgId inner join
Locations on OrgLocations.LocId=Locations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where Projects.PSEventsId=@PSEventsId and
Projects.OrgLocId!= @OrgLocId and
(Projects.Visibility=1 or
Projects.Visibility=2 and Licenses.DomainId=@DomainId or
Projects.Visibility=3 and Organizations.LicenseId=@LicenseId or 
Projects.Visibility=4 and Organizations.ParentOrg  = @OrgIdP)
and Projects.Status != 'Cancelled' and Projects.Status !='Completed'
Order by Organizations.Name, Locations.Name, Projects.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectsInd]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjectsInd]
@PeopleId int = null,
@PSEventId int,
@OrgLocId int
AS
Select Projects.Id as Id, Projects.Name as Name, Projects.Status, Projects.Visibility as Vis,
null as ProjectsPeopleId, Organizations.Name as MgrName,
Locations.Name as LocName
From
Projects  inner join
OrgLocations on Projects.OrgLocId=OrgLocations.Id inner join
Organizations on Organizations.Id=OrgLocations.OrgId inner join
Locations on Locations.Id=OrgLocations.LocId
Where 
Projects.OrgLocId=@OrgLocId and
Projects.PSEventsId=@PSEventId and
(Projects.Status = 'Started' or Projects.Status = 'Planned') 

Order by Organizations.Name, Locations.Name, Projects.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjects]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjects]
@PSEventsId int,
@OrgLocId int
AS
SELECT Max(Projects.Id) as Id, Max(Projects.Name) as ProjName,
Max(Projects.Status) as Status, Count(ProjectClients.Id) as ClientsCount
FROM Projects left outer join
ProjectClients on Projects.Id=ProjectClients.ProjectId
Where (Projects.PSEventsId=@PSEventsId and
Projects.OrgLocId= @OrgLocId and
Projects.Status != 'Planned' and
Projects.Status != 'Started')
Group by Projects.Id
Order by ProjName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjectClients]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[wms_RetrieveProjectClients]
@ProjectId int
AS
SELECT ProjectClients.Id, Clients.Name as ClientsName,
ProjectClients.Description

from
Clients inner join
ProjectClients on ProjectClients.ClientsId=Clients.Id 

Where
ProjectClients.ProjectId=@ProjectId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjdata]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjdata]
@Id int
 AS
Select Name, Status, Visibility, 
Convert(CHAR(128), Projects.StartTime, 101 ) as StartTime,
Convert(CHAR(128), Projects.EndTime, 101 ) as EndTime,
Description
From Projects
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProjCOrgs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProjCOrgs]
@OrgLocId int,
@PSEPCID int,
@ProjectId int
As

SELECT 
ProjCOrgs.Id,
Organizations.Id as OrgIdClient, Organizations.Name

From 

ProjCOrgs inner join
Contracts on ProjCOrgs.ContractsId=Contracts.Id inner join
Organizations on Contracts.OrgIdClient=Organizations.Id
Where ProjCOrgs.PSEPCID=@PSEPCID and
ProjCOrgs.OrgLocId=@OrgLocId and
ProjectId=@ProjectId
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfProjTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfProjTypes]
@Id int=0
As

SELECT  ProfileProjectTypes.Id,  ProjectTypesId,
ProjectTypes.Name, ProjectTypes.Nameshort, ProjectTypes.Seq, ProjectTypes.Visibility as Vis
FROM ProfileProjectTypes inner join 
ProjectTypes on ProfileProjectTypes.ProjectTypesId= ProjectTypes.Id 
WHERE ProfileProjectTypes.ProfilesId=@Id 
Order by ProjectTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfileSEvents]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfileSEvents]
@ProfileServicesId int
As
SELECT
ProfileServiceEvents.Id,
Events.Id as EventsId, 
'Name' = 
Case
When ProfileServiceEvents.MapId is null Then Events.Name
When  Profiles.Name is null Then Events.Name
Else Events.Name + ' (from domain '
+ Profiles.Name + ')'
End,
Events.Description,
Events.OrgId, Events.Visibility,
ProfileServiceEvents.Seq
From
ProfileServiceEvents inner join
Events on Events.Id=ProfileServiceEvents.EventsId left outer join
ProfileServiceEvents As MapPSE on MapPSE.Id=ProfileServiceEvents.MapId left outer join
ProfileServiceTypes on MapPSE.ProfileServicesId=ProfileServiceTypes.Id left outer join
Profiles on Profiles.Id=ProfileServiceTypes.ProfilesId
WHERE ProfileServiceEvents.ProfileServicesId=@ProfileServicesId 
Order by ProfileServiceEvents.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfileServiceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfileServiceTypes]
@Id int=0
As
SELECT  ProfileServiceTypes.Id,  ProfileServiceTypes.ServiceTypesId,
ServiceTypes.Name,
ServiceTypes.Name, ProfileServiceTypes.Description, ProfileServiceTypes.Seq
FROM 
ProfileServiceTypes inner join 
ServiceTypes on ProfileServiceTypes.ServiceTypesId= ServiceTypes.Id
WHERE ProfileServiceTypes.ProfilesId=@Id 
Order by ProfileServiceTypes.Seq, ServiceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfileSEProcsUpd]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfileSEProcsUpd]
@Id int
 AS
Select
ProfileSEProcs.ProcsId,--0
ProfileSEProcs.Name,--1
ProfileSEProcs.LocTypesId,--2
ProfileSEProcs.ProjectTypesId,--3
ProfileSEProcs.Timetables,--4
ProfileSEProcs.Costs,--5
Procs.ServiceTypesId--6
from ProfileSEProcs inner join
Procs on ProfileSEProcs.ProcsId=Procs.Id
Where ProfileSEProcs.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfileSEProcs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfileSEProcs]
@ProfileSEventsId int
AS
Select 
Id,  
Seq, 
Name, 
Timetables, 
ProcsId,
null as 'ProjOLPSEPFlag'
From ProfileSEProcs
Where ProfileSEProcs.ProfileSEventsId=@ProfileSEventsId
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfilesAll]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfilesAll]
@ProfileType nvarchar(10)='Consumer'
As

if @ProfileType='Consumer'

SELECT Profiles.Id, Profiles.Name, Profiles.Description, Profiles.Households as AllHH 
from Profiles
WHERE (Type=@ProfileType and Status=0 )
Order by profiles.households, Profiles.Seq, Profiles.Name

else
SELECT Profiles.Id, Profiles.Name, Profiles.Description 
from Profiles
WHERE (Type=@ProfileType and Status=0)
Order by Profiles.Seq, Profiles.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfileModels]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProfileModels] 
@ServiceId int
AS
Select ProfileServiceTypes.Id, Profiles.Name from 
Profiles inner join
ProfileServiceTypes on ProfileServiceTypes.ProfilesId=Profiles.Id
Where ProfileServiceTypes.ServiceTypesId=@ServiceId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProfileInvTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[wms_RetrieveProfileInvTypes]
@OrgId int
As

SELECT Max(ResourceTypes.Id) as Id,  Max(ResourceTypes.Name) as Name

FROM Organizations inner join
Profiles on Organizations.ProfileId=Profiles.Id inner join
ProfileServiceTypes on ProfileServiceTypes.ProfilesId=Profiles.Id inner join
ProfileServiceEvents on ProfileServiceEvents.ProfileServicesId=ProfileServiceTypes.Id inner join
ProfileSEProcs on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id inner join
Procs on ProfileSEProcs.ProcsId=Procs.Id inner join
PSEPRes on Procs.Id=PSEPRes.ProcsId inner join
ResourceTypes on PSEPRes.ResTypesId=ResourceTypes.Id 

Where Organizations.Id=@OrgId and 
ResourceTypes.Type = 0
Group by ResourceTypes.Id, ResourceTypes.Name
Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcsUpd]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcsUpd]
@Id int
 AS
Select
Name, Description, Visibility, ServiceTypesId, PeopleId

from Procs
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcStaff]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcStaff]
@PSEPID int
As
SELECT PSEPStaff.Id, Roles.Name as RoleName, PSEPStaff.Description, PSEPStaff.ProcsId,
PSEPStaff.RolesId

From
PSEPStaff inner join 
Roles on PSEPStaff.RolesId=Roles.Id inner join
ProfileSEProcs on ProfileSEProcs.ProcsId=PSEPStaff.ProcsId
WHERE ProfileSEProcs.Id=@PSEPID
Order by Roles.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcs]
@DomainId int = null,
@LicenseId int = null,
@OrgIdP int = null,
@ServiceTypesId int = null,
@OrgId int,
@PeopleId int = null
As
if @PeopleId is not null
SELECT Procs.Name,Procs.Id, 
People.FName + ' ' + People.LName as PeopleName, Procs.PeopleId
FROM  Procs inner join 
Organizations on Procs.OrgId=Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id inner join
ServiceTypes on Procs.ServiceTypesId=ServiceTypes.Id left outer join
People on Procs.PeopleId=People.Id
Where Procs.PeopleId=@PeopleId and 
Procs.ServiceTypesId=@ServiceTypesId

Order by ServiceTypes.Name, Procs.Name


else if @DomainId is not null and @ServiceTypesId is not null
SELECT Procs.Name,Procs.Id, 
People.FName + ' ' + People.LName as PeopleName, Procs.PeopleId
FROM  Procs inner join 
Organizations on Procs.OrgId=Organizations.Id inner join 
Licenses on Organizations.LicenseId=Licenses.Id inner join
ServiceTypes on Procs.ServiceTypesId=ServiceTypes.Id left outer join
People on Procs.PeopleId=People.Id
Where Procs.ServiceTypesId=@ServiceTypesId and 
(Procs.Visibility = 1 or
Procs.Visibility=2 and Licenses.DomainId=@DomainId or
Procs.Visibility=3 and Organizations.LicenseId=@LicenseId or
Procs.Visibility=4 and Organizations.ParentOrg=@OrgIdP or
Procs.OrgId=@OrgId)
Order by ServiceTypes.Name, Procs.Name

else if @DomainId is not null
SELECT Procs.Name,Procs.Id, Procs.Visibility, ServiceTypes.Name as ServiceTypesName
FROM  Procs inner join Organizations on Procs.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id left outer join
ServiceTypes on Procs.ServiceTypesId=ServiceTypes.Id
Where 
(Procs.Visibility = 1 or
Procs.Visibility=2 and Licenses.DomainId=@DomainId or
Procs.Visibility=3 and Organizations.LicenseId=@LicenseId or
Procs.Visibility=4 and Organizations.ParentOrg=@OrgIdP or
Procs.OrgId=@OrgId)
Order by ServiceTypes.Name, Procs.Name

Else
SELECT Procs.Name,Procs.Id, People.FName + ' ' + People.LName as PeopleName, Procs.PeopleId
FROM  Procs left outer join
People on Procs.PeopleId=People.Id
Where Procs.OrgId=@OrgId and
Procs.ServiceTypesId=@ServiceTypesId
Order by Procs.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcResTypesO]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcResTypesO]
@ProcsId int,
@RType int = 0
As
SELECT ProcResOutputs.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId,
QtyMeasures.Name as QtyMeasure,
'' as Qty,
'' as QtyId,
ProcResOutputs.Description as "Desc"
FROM ResourceTypes inner join 
ProcResOutputs on ProcResOutputs.ResTypesId=ResourceTypes.Id inner join 
QtyMeasures on QtyMeasures.Id=ResourceTypes.QtyMeasuresId 
Where (ResourceTypes.Type = @RType) and
ProcResOutputs.ProcsId=@ProcsId
Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcResTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcResTypes]
@ProcsId int,
@RType int = 0
As
SELECT ResourceTypes.Id,  ResourceTypes.Name, ResourceTypes.Visibility, 
ResourceTypes.ParentId,
ResourceTypes.QtyMeasuresId
FROM ResourceTypes inner join 
ProcRes on ProcRes.ResTypesId=ResourceTypes.Id
Where (ResourceTypes.Type = @RType) and
ProcRes.ProcsId=@ProcsId
Order by  ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcRes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcRes]
@PSEPId int,
@RType int = 0
As

SELECT
PSEPRes.Id, --0
ResourceTypes.Name as ResourceName,--1
PSEPRes.ResTypesId, --2
PSEPRes.Description as Description,--3
'QtyMeasure' =--4
Case
When ResourceTypes.QtyMeasuresId  is not null then QtyMeasures.Name
Else 'na'
End,
'QtyMeasurePl' =--5
Case
When ResourceTypes.QtyMeasuresId  is not null then QtyMeasures.NamePlural
Else 'na'
End,
ResourceTypes.Type as ResTypesType--6

From 
Procs  inner join
ProfileSEProcs on ProfileSEProcs.ProcsId=Procs.Id inner join
PSEPRes on  PSEPRes.ProcsId=Procs.Id inner join
ResourceTypes on ResourceTypes.Id=PSEPRes.ResTypesId left outer join
QtyMeasures on ResourceTypes.QtyMeasuresId=QtyMeasures.Id
Where ProfileSEProcs.Id=@PSEPId 
Order by ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcFlags]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcFlags]
@PSEPID int
As

SELECT 
StaffFlag, --0
ResFlag, --1
StepsFlag--2 
From PRocs inner join
ProfileSEProcs on
ProfileSEProcs.ProcsId=Procs.Id

Where ProfileSEProcs.Id=@PSEPID
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcClient]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcClient]
@ProcsId int
As
SELECT ProcClients.Id, ProcClients.ProcsId,
ProcClients.ProfilesId, ProcClients.Description,
Profiles.Name as ProfileName
From
ProcClients inner join Profiles on ProcClients.ProfilesId=Profiles.Id
WHERE ProcClients.ProcsId=@ProcsId
Order by Profiles.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveProcCImpact]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveProcCImpact]
@ProcClientsId int
As
SELECT ProcClientEvents.Id, 
ProcClientEvents.EventsId, ProcClientEvents.Description,
Events.Name as Name
From
ProcClientEvents inner join Events on ProcClientEvents.EventsId=Events.Id
WHERE ProcClientEvents.ProcClientsId=@ProcClientsId
Order by Events.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePeopleServiceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrievePeopleServiceTypes]
@PeopleId int
AS
SELECT 
PeopleServiceTypes.ServiceTypesId as ServiceTypesId,
PeopleServiceTypes.PeopleId as PeopleId,
ServiceTypes.Name
FROM
PeopleServiceTypes inner join 
ServiceTypes on PeopleServiceTypes.ServiceTypesId=ServiceTypes.Id
Where PeopleServiceTypes.PeopleId=@PeopleId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrievePCRolesAll]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_RetrievePCRolesAll]
@ProcsId int
As

SELECT Roles.Name, Roles.Id, Roles.Visibility, Roles.ParentId, Roles.Seq
FROM Roles inner join ProcClients on ProcClients.RolesId=Roles.Id
WHERE ProcClients.ProcsId=@ProcsId
Order by Roles.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgServiceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_RetrieveOrgServiceTypes]
@OrgId int, 
@EPSFlag int=null
As
if @EPSFlag is null
SELECT
ServiceTypes.Id,
ServiceTypes.Id as Id,--0
ServiceTypes.Name as Name,--1 
ProfileServiceTypes.Id AS PSTId,--2
ServiceTypes.ProjName, --3 
ServiceTypes.ProjNameS --4
FROM 
Organizations INNER JOIN
ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
OrgServiceTypes ON ProfileServiceTypes.Id = OrgServiceTypes.PSTId AND 
OrgServiceTypes.OrgId = Organizations.Id INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id inner join 
Functions on ServiceTypes.TypeId=Functions.Id

WHERE Organizations.Id = @OrgId 
ORDER BY Functions.Seq, ServiceTypes.Seq

else

SELECT    
ServiceTypes.Id as Id, --0
ServiceTypes.Name as Name, --1
ProfileServiceTypes.Id AS PSTId, --2
ServiceTypes.ProjName, --3 
ServiceTypes.ProjNameS --4
FROM 
Organizations INNER JOIN
ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
OrgServiceTypes ON ProfileServiceTypes.Id = OrgServiceTypes.PSTId AND 
OrgServiceTypes.OrgId = Organizations.Id INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id inner join 
Functions on ServiceTypes.TypeId=Functions.Id

WHERE Organizations.Id = @OrgId and ServiceTypes.TypeId = 1
ORDER BY ServiceTypes.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgPSEPSDesc]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_RetrieveOrgPSEPSDesc]
@Id int,
@OrgId int
AS

if Exists (Select OrgPSEPStaff.Id from OrgPSEPStaff Where OrgPSEPStaff.OrgId=@OrgId)

Select 
OrgPSEPStaff.Description as Descr,
'Org' as Srce
from PSEPStaff inner join 
OrgPSEPStaff on PSEPStaff.Id=OrgPSEPStaff.PSEPStaffId
Where (PSEPStaff.Id=@Id and OrgPSEPStaff.OrgId=@OrgId)

else

Select 
PSEPStaff.Description as Descr,
'Model' as Srce
from PSEPStaff 
Where PSEPStaff.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgPSEPRDesc]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgPSEPRDesc]
@PSEPResId int,
@OrgId int
AS

if Exists (Select OrgPSEPRes.Id from OrgPSEPRes Where OrgPSEPRes.OrgId=@OrgId)

Select 
OrgPSEPRes.Description as Descr,
'Org' as Srce
from OrgPSEPRes inner join 
PSEPRes on PSEPRes.Id=OrgPSEPRes.PSEPResId
Where (PSEPRes.Id=@PSEPResId and OrgPSEPRes.OrgId=@OrgId)

else

Select 
PSEPRes.Description as Descr,
'Model' as Srce
from PSEPRes 
Where PSEPRes.Id=@PSEPResId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgLocSEvents]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgLocSEvents]
@OrgLocId int,
@ProfileServicesId int
 AS
SELECT  ProfileServiceEvents.Id, Events.Name
FROM  OrgLocations INNER JOIN
               Organizations ON OrgLocations.OrgId=Organizations.Id inner join
               ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
               ProfileServiceEvents ON ProfileServiceTypes.Id = ProfileServiceEvents.ProfileServicesId INNER JOIN
               Events ON Events.Id = ProfileServiceEvents.EventsId
WHERE OrgLocations.Id = @OrgLocId and
 ProfileServiceEvents.ProfileServicesId = @ProfileServicesId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveBudOLServices]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveBudOLServices]
@LocationsId int,
@ServiceTypesId int,
@BudOrgsId int 
As

SELECT 
Id, Budamt
FROM  BudOLServices 
WHERE  BudOrgsId = @BudOrgsId and LocationsId=@LocationsId and ServiceTypesId=@ServiceTypesId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveBOOutputs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveBOOutputs]
@BudOrgsId int
AS

Select BudOrgsOutputs.Id,
ResourceTypes.Name,
QtyMeasures.Name as QtyMeasure,
BudOrgsOutputs.Qty as Qty,
BudOrgsOutputs.Description as "Desc",
'' as QtyId
From
BudOrgsOutputs inner join
ResourceTypes on BudOrgsOutputs.ResTypesId=ResourceTypes.Id inner join
QtyMeasures on QtyMeasures.Id=ResourceTypes.QtyMeasuresId 
 
Where BudOrgsOutputs.BudOrgsId=@BudOrgsId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteStep]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteStep]
@Id int
AS
DELETE From PSEPSteps
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteSkillCourses]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_DeleteSkillCourses]
@SkillId int
AS
DELETE From SkillCourses
Where SkillId  = @SkillId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteServiceType]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteServiceType]
@Id int

AS
DELETE FROM ServiceTypes WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteServiceEvents]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteServiceEvents]
@Id int

AS
DELETE FROM ServiceEvents  WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteResourceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_DeleteResourceTypes]
@Id int

AS
DELETE FROM ResourceTypes WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEResources]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeletePSEResources]
@Id int
 AS
Delete FROM  PSEResources
WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPStaff]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeletePSEPStaff]
@Id int

AS
DELETE FROM PSEPStaff WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPSPeople]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[wms_DeletePSEPSPeople]
@Id int

AS
DELETE FROM PSEPSPeople where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPSer]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeletePSEPSer]
@Id int

AS
DELETE FROM PSEPSer WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPResOutputs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[wms_DeletePSEPResOutputs]
@ID int
 AS
Delete from PSEPResOutputs 
Where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPResInv]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeletePSEPResInv]
@Id int

AS
DELETE FROM PSEPResInventory where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPRes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeletePSEPRes]
@Id int

AS
DELETE FROM PSEPRes 
 WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEPClientImpact]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeletePSEPClientImpact]
@Id int
As
Delete from PSEPClientEvents
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePSEClient]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeletePSEClient]
@Id int

AS
DELETE FROM PSEClients WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProjTypesPSEP]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProjTypesPSEP]
@Id int

AS
DELETE FROM ProjTypesPSEP WHERE Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProjOrgLoc]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_DeleteProjOrgLoc]
@ProjectsId int,
@OrgId int,
@LocationsId int
AS
Delete from ProjOrgLoc
Where ProjectsId=@ProjectsId and
OrgId = @OrgId and LocationsId = @LocationsId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProfProjectTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProfProjectTypes]
@Id int
AS
Delete from ProfileProjectTypes
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProfileSEProcs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProfileSEProcs]
@Id int
AS
DELETE From ProfileSEProcs
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProcs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteProcs]
@Id int
AS
Delete from Procs
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProcResOutputs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeleteProcResOutputs]
@ID int
 AS
Delete from ProcResOutputs 
Where ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProcClientImpact]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeleteProcClientImpact]
@Id int
As
Delete from ProcClientEvents
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteProcClient]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeleteProcClient]
@Id int
As
Delete from ProcClients
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_DeletePeopleServiceTypes]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[wms_DeletePeopleServiceTypes]
@PeopleId int,
@ServiceTypesId int
AS
Delete from 
PeopleServiceTypes

Where PeopleServiceTypes.PeopleId=@PeopleId and PeopleServiceTypes.ServiceTypesId=@ServiceTypesId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOrgLocSEvents]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOrgLocSEvents]
@OrgLocId int,
@ProfileServiceEventsId int
 AS

Delete from OrgLocSEvents
Where 
ProfileServiceEventsId=@ProfileServiceEventsId
 and
OrgLocId=@OrgLocId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOrgLocServices]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOrgLocServices]
@OrgLocId int
 AS

Delete from OrgLocServiceTypes
Where OrgLocId=@OrgLocId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOrgLocMgrs]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOrgLocMgrs]
@OrgLocId int,
@StaffActionsId int
 AS

Delete from OrgLocMgrs
Where OrgLocId=@OrgLocId and StaffActionsId=@StaffActionsId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOrgLocId]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_DeleteOrgLocId]
@OrgId int,
@LocId int
 AS
Delete from OrgLocations
Where OrgId=@OrgId and LocId=@LocId
GO
/****** Object:  StoredProcedure [dbo].[wms_DeleteOrgLocation]    Script Date: 02/21/2014 15:49:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_DeleteOrgLocation]
@Id int
 AS
Delete from Orglocations
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddPeople]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_AddPeople]
 
@FName nvarchar(50),
@LName nvarchar(50),
@Email nvarchar (50),
@HPhone nvarchar(50),
@CPhone nvarchar(50),
@WPhone nvarchar(50),
--@Birthdate nvarchar(10),
@OrgId int,
@Addr ntext,
@Vis int,
@UserLevel int=null
AS
insert into People
(FName,  LName, Address, HomePhone, WorkPhone, CellPhone, Email, OrgId, Visibility, UserLevel)
values
(@FName, @LName, @Addr, @HPhone, @WPhone, @CPhone, @EMail, @OrgId, @Vis, @UserLevel)

-- (@FName, @LName, @Address, @HPhone, @WPhone, @CPhone, convert(smalldatetime,@Birthdate,101), @OrgId)
GO
/****** Object:  StoredProcedure [dbo].[hrs_AddPayGrade]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[hrs_AddPayGrade]
@Name nvarchar (50),
@Status int=null,
@OrgStaffTypesId int,
@SalMax dec (20,2)=null,
@SalMin dec (20,2)=null,
@SalAve dec (20,2)=null,
@Ovt  dec (20,2)=null
AS
Insert into OrgSTPayGrades (
Name,
Status,
OrgStaffTypesId,
SalaryMax,
SalaryMin,
SalaryAve,
OvertimeRate
)
Values
(
@Name,
@Status,
@OrgStaffTypesId,
@SalMax,
@SalMin,
@SalAve,
@Ovt
)
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateProcSReq]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateProcSReq]
@Id int,
@StaffActionId int=null,
@Desc varchar (300),
@BudgetsId int=null,
@Time decimal (20,2)=0,
@Price decimal (20,2) = 0,
@TimeMeasure int=0,
@TypeId int = null,
@ReqAmount decimal (20,2) = null,
@BkupFlag int = null
As
if @BudgetsId is null

Update ProcProcures Set
Description=@Desc,
ContractId=@StaffActionId,
Qty=@Time,
TypeId=@TypeId,
Price=@Price,
TimeMeasure=@TimeMeasure,
ReqAmount=@ReqAmount,
BkupFlag = @BkupFlag
Where Id=@Id

else

Update ProcProcures Set
Description=@Desc,
ContractId=@StaffActionId,
Qty=@Time,
BudgetsId=@BudgetsId,
TypeId=@TypeId,
Price=@Price,
TimeMeasure=@TimeMeasure,
ReqAmount=@ReqAmount,
BkupFlag = @BkupFlag
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcs]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProcs]
@Id int,
@Vis int = null,
@Name varchar (300),
@Desc varchar (500) = null,
@Services int = null,
@PeopleId int = null
As

if @PeopleId is null
Update Procs
Set 

Name=@Name,
Description=@Desc
Where Id=@Id

Else

Update Procs
Set 

Name=@Name,
Description=@Desc,
Visibility=@Vis,
ServiceTypesId=@Services,
PeopleId=@PeopleId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcResOutputs]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProcResOutputs]
@ProcsId int,
@ResTypesId int
AS
Insert into ProcResOutputs ( ProcsId, ResTypesId)
Values (@ProcsId, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcResDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[wms_UpdateProcResDesc]
@ProcsID int,
@ResTypesId int
AS
Insert into ProcRes ( ProcsID, ResTypesId)
Values (@ProcsID, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcRes]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProcRes]
@ProcsID int,
@ResTypesId int
AS
Insert into ProcRes ( ProcsID, ResTypesId)
Values (@ProcsID, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcOutputDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROCEDURE [dbo].[wms_UpdateProcOutputDesc]
@Id int,
@Desc nvarchar(500) =null
AS
Update ProcResOutputs
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcFlags]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateProcFlags]
@Id int
As
Update Procs
Set 
StepsFlag = (Select Count(PSEPSteps.Id) From PSEPSteps Where ProcsId=@Id)
Where Id=@Id
Update Procs
Set
StaffFlag = (Select Count(PSEPStaff.Id) From PSEPStaff Where ProcsId=@Id)
Where Id=@Id
Update Procs
Set 
ResFlag = (Select Count(PSEPRes.Id) From PSEPRes Where ProcsId=@Id)
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcClientEvents]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateProcClientEvents]
@ProcClientsId int,
@EventsId int
As
Insert into ProcClientEvents (ProcClientsId, EventsId)
Values(@ProcClientsId, @EventsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcClientDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[wms_UpdateProcClientDesc]
@Desc varchar (200),
@Id int
 AS

Update ProcClients
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateProcCImpactDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdateProcCImpactDesc]
@Desc varchar (500),
@Id int
 AS

Update ProcClientEvents
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdatePeopleServiceTypes]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
Create PROCEDURE [dbo].[wms_UpdatePeopleServiceTypes]
@PeopleId int,
@ResTypesId int
AS
Insert into PeopleServiceTypes (PeopleId, ServiceTypesId)
Values (@PeopleId, @ResTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateOrgPSEPSDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdateOrgPSEPSDesc]
@Id int,
@Desc ntext=null,
@OrgId int
AS
Update OrgPSEPStaff
Set 
Description=@Desc
Where PSEPStaffId=@Id and OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateOrgPSEPRDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateOrgPSEPRDesc]
@PSEPResId int,
@Desc ntext=null,
@OrgId int
AS
Update OrgPSEPRes
Set 
Description=@Desc
Where OrgPSEPRes.PSEPResId=@PSEPResId and OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateOrgLocMgrs]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateOrgLocMgrs]
@OrgLocId int,
@StaffActionsId int
As
Insert into OrgLocMgrs (OrgLocId, StaffActionsId)
Values (@OrgLocId, @StaffActionsId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateOrgLocations]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateOrgLocations]
@OrgId int,
@LocId int
as
Insert into OrgLocations (OrgId, LocId)
Values (@OrgId, @LocId)
GO
/****** Object:  StoredProcedure [dbo].[wms_updateOLSEPOutputQty]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_updateOLSEPOutputQty]
@PSEPResOutputsId int=null,
@Qty dec (20,2)=null,
@Id int = null
As
if (@Id=null and @Qty !=null)
Insert into OLSEPOutputQty (
PSEPResOutputsId, Qty)
Values
(@PSEPResOutputsId, @Qty)

else if @Id !=null
Update OLSEPOutputQty Set
Qty=@Qty
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateInventory]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_UpdateInventory]
@Desc nvarchar (300),
@Id int,
@StatusId int,
@Qty float = null,
@SLocId int,
@ResTypeId int=0,
@VisId int
AS
Update Inventory
Set
Description=@Desc,  
StatusId=@StatusId,
ResTypeId=@ResTypeId,
Visibility=@VisId,
Qty=@Qty,
SLocId=@SLocId
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateEvent]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateEvent]
@Name nvarchar(50),
@Desc ntext,
@Vis int,
@HHFlag int=null,
@Id int

AS

UPDATE Events SET Name = @Name, Visibility=@Vis, Description =@Desc,
HouseholdFlag=@HHFlag
WHERE Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateContractSuppliesDesc]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_UpdateContractSuppliesDesc]
@Id int,
@Desc ntext,
@URL nvarchar(500),
@LocsFlag int=null	
AS
Update ContractSupplies 
Set 
Description=@Desc,
URL=@URL,
LocationsFlag=@LocsFlag
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateContractSupplies]    Script Date: 02/21/2014 15:49:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdateContractSupplies]
@ContractsId int,
@ResourceTypesId int
AS
Insert into ContractSupplies (ContractsId, ResourceTypesId)
Values (@ContractsId, @ResourceTypesId)
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateBudOrgsOutputsDesc]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROCEDURE [dbo].[wms_UpdateBudOrgsOutputsDesc]
@Id int,
@Desc nvarchar(500) =null,
@Qty dec=null
AS
Update BudOrgsOutputs
Set 
Description=@Desc,
Qty=@Qty
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_UpdateBudOrgClientsDesc]    Script Date: 02/21/2014 15:49:45 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_UpdateBudOrgClientsDesc]
@Desc varchar (200),
@Id int
 AS

Update BudOrgClients
Set Description=@Desc
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgLocSEProcs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgLocSEProcs]
@OrgLocId int = null,
@ProfileServicesId int = null,
@PSEPID int = null
AS
SELECT  
ProfileSEProcs.Id,
ProfileSEProcs.Name,
Procs.StaffFlag as StaffFlag, 
Procs.ResFlag as ResFlag,
'' as 'ResOutputsFlag',
'' as 'ClientsFlag',
ProfileSEProcs.Seq,
'' as BudFlag

FROM  OrgLocations INNER JOIN
	Organizations ON OrgLocations.OrgId=Organizations.Id inner join
	ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
	ProfileServiceEvents ON ProfileServiceTypes.Id = ProfileServiceEvents.ProfileServicesId INNER JOIN
	ProfileSEProcs on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id Left Outer Join
	Procs on ProfileSEProcs.ProcsId = Procs.Id
WHERE OrgLocations.Id = @OrgLocId and
ProfileServiceEvents.ProfileServicesId = @ProfileServicesId
Order by ProfileSEProcs.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgLocMgrs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgLocMgrs]
@OrgLocId int
As
SELECT StaffActions.Id, People.FName + " " + People.LName as Name,
StaffTypes.Name as Type,
Organizations.Name as OrgName
FROM  
OrgLocMgrs INNER JOIN
OrgLocations on OrgLocMgrs.OrgLocId=OrgLocations.Id inner join
StaffActions on OrgLocMgrs.StaffActionsId=StaffActions.Id  inner join
People on StaffActions.PeopleId=People.Id inner join
OrgStaffTypes on StaffActions.TypeId=OrgStaffTypes.Id   inner join
StaffTypes on OrgStaffTypes.StaffTypesId =StaffTypes.Id inner join
Organizations on OrgLocations.OrgId=Organizations.id
WHERE OrgLocMgrs.OrgLocId = @OrgLocId
Order by People.Lname, People.FName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgLocationsInd]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgLocationsInd]
@OrgId int,
@PeopleId int
As
Select Max(OrgLocations.Id) as Id, Max(OrgLocations.LocId) as LocId, 
Max(Organizations.Name) as MgrName,
Max(Locations.Name) as LocName,
Max(Organizations.ProfileId) as ProfileId,
Max(ServiceTypes.Name) as ServiceName, 
Max(ProfileServiceTypes.ProfilesId) as ProfileId, 
Max(ServiceTypes.ProjName) as PJName, 
Max(ServiceTypes.ProjNameS) as PJNameS,
Max(ProfileServiceEvents.Id) as PSEId,
Max(Events.Name) as EventName
from 
ProcProcures inner join
OrgLocations on OrgLocations.Id=ProcProcures.OrgLocId  inner join 
Organizations on  OrgLocations.OrgId= Organizations.Id inner join
Locations on OrgLocations.LocId=Locations.Id inner join
StaffActions  on StaffActions.Id=ProcProcures.ContractId  inner join
People on StaffActions.PeopleId=People.Id  inner join
PSEPStaff on ProcProcures.PSEPSID=PSEPStaff.Id inner join 
Procs on PSEPStaff.ProcsId=Procs.Id inner join
ProfileSEProcs on Procs.ID=ProfileSEProcs.ProcsId and ProfileSEProcs.Id=ProcProcures.PSEPID  inner join
ProfileServiceEvents on ProfileSEProcs.ProfileSEventsId=ProfileServiceEvents.Id inner join
Events on ProfileServiceEvents.EventsId=Events.Id inner join
ProfileServiceTypes on ProfileServiceEvents.ProfileServicesId=ProfileServiceTypes.Id inner join
ServiceTypes on ProfileServiceTypes.ServiceTypesId=ServiceTypes.Id

--ProjTypesPSEP on ProjTypesPSEP.PSEPId=ProfileSEProcs.Id inner join
--ProjectTypes on ProjTypesPSEP.ProjectTypesId=ProjectTypes.Id inner join


Where 
StaffActions.PeopleId=@PeopleId and 
ProcProcures.SGFlag is null
Group by ServiceTypes.Id, OrgLocations.Id, ServiceTypes.Id, Events.Id, ProfileServiceEvents.Id
Order by Max(Organizations.Name), Max(Locations.Name),  Max(ServiceTypes.Seq) Desc , Max (ProfileServiceEvents.Seq)
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgLocations]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgLocations]
@OrgId int
As
Select 
OrgLocations.Id,--0 
Locations.Name, --1
Organizations.ProfileId as ProfileId,--2
Locations.Id as LocationsId--3
from 
OrgLocations inner join 
Locations on OrgLocations.LocId=Locations.Id inner join
Organizations on OrgLocations.OrgId=Organizations.Id 
Where OrgLocations.OrgId = @OrgId
Order by Locations.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgInventory]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgInventory]
@SLocId int=0
AS
SELECT Inventory.Id, ResourceTypes.Name
from
Inventory inner join
ResourceTypes on ResourceTypes.Id=Inventory.ResTypeId inner join
SLocations on Inventory.SLocId=SLocations.Id 
Where SLocId=@SLocId
Order by ResourceTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPSSPeople]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPSSPeople]
@OrgLocsId int,
@PSEPSSID int
As

SELECT 
PeopleId, People.FName + ' ' + People.LName as Name, BkupFlag,
OLPSSPeople.Id
From 

OLPSSPeople inner join
StaffActions on OLPSSPeople.StaffActionsId=StaffActions.Id inner join
People on StaffActions.PeopleId=People.Id
Where OLPSSPeople.PSEPSSID=@PSEPSSID and
OLPSSPeople.OrgLocationsId=@OrgLocsId 
Order by BkupFlag, People.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPSPeople]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPSPeople]
@OrgLocId int,
@PSEPSID int
As

SELECT 
OLPSPeople.Id,
PeopleId, People.FName + ' ' + People.LName as Name, BkupFlag

From 

OLPSPeople inner join
StaffActions on OLPSPeople.StaffActionsId=StaffActions.Id inner join
People on StaffActions.PeopleId=People.Id
Where OLPSPeople.PSEPSID=@PSEPSID and
OLPSPeople.OrgLocId=@OrgLocId 
Order by BkupFlag, People.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPSEvents]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPSEvents]
@ProfileServicesId int
AS
Select ProfileServiceEvents.Id as Id, Events.Name as Name
From
Events inner join
ProfileServiceEvents on ProfileServiceEvents.EventsId=Events.Id 

Where ProfileServicesId=@ProfileServicesId
Order by Events.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPSEPClient]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPSEPClient]
@OrgLocId int = null,
@ProfileServicesId int,
@BudgetsId int=null,
@ProjectId int = null
AS
if @ProjectId is null

SELECT OLSEProcClients.Id, Profiles.Name as ProfileName,
'' as Description 

from
Profiles inner join
OLSEProcClients on OLSEProcClients.ClientProfilesId=Profiles.Id inner join
ProfileServiceTypes on OLSEProcClients.ProfileServicesId=ProfileServiceTypes.Id

Where
OLSEProcClients.OrgLocationsId=@OrgLocId and
OLSEProcClients.BudgetsId=@BudgetsId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLProjTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLProjTypes]
@ProfilesId int=0,
@OrgLocId int=0,
@OrgId int=0,
@OrgIdP int=0,
@LicenseId int=0,
@DomainId int=0
As
if @OrgLocId !=0
SELECT Distinct ProjectTypes.Id, ProjectTypes.Name
FROM  ProjectTypes inner join 
ProfileSEProcs on ProfileSEProcs.ProjectTypesId=ProjectTypes.Id inner join 
ProfileServiceEvents on ProfileServiceEvents.Id=ProfileSEProcs.ProfileSEventsId inner join
ProfileServiceTypes on ProfileServiceEvents.ProfileServicesId=ProfileServiceTypes.Id 
Where ProfileServiceTypes.ProfilesId=@ProfilesId and 
ProfileServiceTypes.Id not in (Select OrgLocServiceTypes.ServiceTypesId as Id
from  OrgLocServiceTypes where
OrgLocId=@OrgLocId) and
ProfileServiceEvents.Id not in (Select OrgLocSEvents.ProfileServiceEventsId as Id
from OrgLocSEvents where
OrgLocId=@OrgLocId) 
Order by ProjectTypes.Name

Else
Select Distinct ProjectTypes.Id, ProjectTypes.Name
From
ProjectTypes inner join
Organizations on ProjectTypes.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where ProjectTypes.Visibility = 1 or
ProjectTypes.Visibility=2 and Licenses.DomainId=@DomainId or
ProjectTypes.Visibility=3 and Organizations.LicenseId=@LicenseId or
ProjectTypes.Visibility=4 and Organizations.ParentOrg=@OrgIdP or
ProjectTypes.OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPProjects]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPProjects]
@PSEPID int,
@OrgLocId int
AS
SELECT Projects.Id, Projects.Name, Projects.Status, Projects.Visibility as Vis,
OLPProjects.Id as OLPProjectsId
FROM 
OLPProjects inner join 
OrgLocations on OrgLocations.Id=OLPProjects.OrgLocId  inner join
Projects on Projects.Id=OLPProjects.ProjectId
Where OrgLocations.Id=@OrgLocId and
OLPPRojects.PSEPID=@PSEPID
Order by Projects.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPPPeople]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPPPeople]
@PSEPID int,
@ProjectId int,
@OrgLocId int
As

SELECT
OLPPPeople.Id, 
PeopleId, People.FName + ' ' + People.LName as Name,
OLPPPeople.StartDate, OLPPPeople.EndDate, OLPPPeople.StartStatus,
OLPPPeople.EndStatus, OLPPPeople.BkupFlag, Roles.Name as RoleName

From
ProcSARs inner join 
PSEPStaff on ProcSARs.PSEPSID=PSEPStaff.Id inner join
ProfileSEProcs on ProfileSEProcs.Id=PSEPStaff.PSEPID inner join
OLPPPeople on OLPPPeople.ProcSARsId=ProcSARs.Id inner join
StaffActions on ProcSARs.StaffActionsId=StaffActions.Id inner join
People on People.Id=StaffActions.PeopleId inner join
Roles on PSEPStaff.RolesId=Roles.Id

Where ProfileSEProcs.Id=@PSEPID and
OLPPPeople.ProjectId=@ProjectId and 
ProcSARs.OrgLocId=@OrgLocId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPPPAddR]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPPPAddR]
@PSEPID int,
@ProjectId int,
@OrgLocId int,
@StaffingType varchar (10), 
@ProcSARsId int
As

SELECT
OLPPPeople.Id

From
ProcSARs inner join 
PSEPStaff on ProcSARs.PSEPSID=PSEPStaff.Id inner join
ProfileSEProcs on ProfileSEProcs.Id=PSEPStaff.PSEPID inner join
OLPPPeople on OLPPPeople.ProcSARsId=ProcSARs.Id inner join
StaffActions on ProcSARs.StaffActionsId=StaffActions.Id inner join
People on People.Id=StaffActions.PeopleId inner join
Roles on PSEPStaff.RolesId=Roles.Id

Where ProfileSEProcs.Id=@PSEPID and
OLPPPeople.ProjectId=@ProjectId and 
ProcSARs.OrgLocId=@OrgLocId and
OLPPPeople.ProcSARsId=@ProcSARsId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOLPCOrgs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOLPCOrgs]
@OrgLocId int,
@PSEPCID int
As

SELECT 
OLPCOrgs.Id,
Organizations.Id as OrgIdClient, Organizations.Name

From 

OLPCOrgs inner join
Contracts on OLPCOrgs.ContractsId=Contracts.Id inner join
Organizations on Contracts.OrgIdClient=Organizations.Id
Where OLPCOrgs.PSEPCID=@PSEPCID and
OLPCOrgs.OrgLocId=@OrgLocId 
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveLocTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveLocTypes]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
AS
Select LocTypes.Id, LocTypes.Name 
from
 LocTypes inner join
Organizations on LocTypes.OrgId=Organizations.Id inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where
LocTypes.OrgId=@OrgId or
LocTypes.Visibility = 1 or
LocTypes.Visibility=2 and Licenses.DomainId=@DomainId or
LocTypes.Visibility=3 and Organizations.LicenseId=@LicenseId or
LocTypes.Visibility=4 and Organizations.ParentOrg=@OrgIdP 

Order by LocTypes.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveLocsAll]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveLocsAll]
@OrgId int,
@OrgIdP int,
@LicenseId int,
@DomainId int
As
SELECT Locations.Id, Locations.Name, Locations.Description, Locations.Visibility
FROM  Locations inner join Organizations on Locations.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
WHERE
(Locations.Visibility=1)
or (Locations.Visibility =2 and Licenses.DomainId= @DomainId)
or (Locations.Visibility=3 and Organizations.LicenseId= @LicenseId)
or (Locations.Visibility=4 and Organizations.ParentOrg= @OrgIdP)
or (Locations.Visibility=5 and Locations.OrgId= @OrgId)
Order by Locations.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveLocs]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveLocs]
@StatesId int=null,
@CountriesId int=null,
@LocTypeId int=null
AS
if @StatesId is not null
Select Id, Name
from Locations
Where StatesId=@StatesId and
LocTypeId=@LocTypeId
Order by Name

else
Select Id, Name
from Locations
Where CountriesId=@CountriesId and
LocTypeId=@LocTypeId
Order by Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveLocations]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveLocations]
@OrgId int
As
Select 
Locations.Id,--0 
Locations.Name
from 
OrgLocations inner join 
Locations on OrgLocations.LocId=Locations.Id 
Where OrgLocations.OrgId = @OrgId
Order by Locations.seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveHHContractSupplies]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveHHContractSupplies]
@CountriesId int =null,
@StatesId int = null,
@LocsId int = null
As

SELECT 
ResourceTypes.Id as Id, 
ResourceTypes.Name as ResName,
Contracts.Name as ContractName,
Organizations.Name as OrgName,
ContractSupplies.Description as ContractDesc

from 
Contracts inner join
ContractSupplies on ContractSupplies.ContractsId=Contracts.Id inner join
ResourceTypes on ContractSupplies.ResourceTypesId=ResourceTypes.Id inner join
Organizations on Contracts.OrgIdSupplier=Organizations.Id 
Where 
ContractSupplies.LocationsFlag is not null and
OrgIndFlag =0

Union

SELECT ResourceTypes.Id as Id, 
ResourceTypes.Name as ResName,
Contracts.Name as ContractName,
Organizations.Name as OrgName,
ContractSupplies.Description as ContractDesc
from 
Contracts inner join
ContractSupplies on ContractSupplies.ContractsId=Contracts.Id inner join
ResourceTypes on ContractSupplies.ResourceTypesId=ResourceTypes.Id inner join
Organizations on Contracts.OrgIdSupplier=Organizations.Id inner join
ContractSuppliesCountries on ContractSuppliesCountries.ContractSuppliesId=ContractSupplies.Id

Where ContractSuppliesCountries.StatesFlag is not null and
ContractSuppliesCountries.CountriesId=@CountriesId and
OrgIndFlag = 0

Union

SELECT ResourceTypes.Id as Id, 
ResourceTypes.Name as ResName,
Contracts.Name as ContractName,
Organizations.Name as OrgName,
ContractSupplies.Description as ContractDesc
from
Contracts inner join 
ContractSupplies on ContractSupplies.ContractsId=Contracts.Id inner join
ContractSuppliesStates on ContractSuppliesStates.ContractSuppliesId=ContractSupplies.Id inner join 
ResourceTypes on ContractSupplies.ResourceTypesId=ResourceTypes.Id inner join 
Organizations on Contracts.OrgIdSupplier=Organizations.Id 

Where ContractSuppliesStates.LocsFlag is not null and
ContractSuppliesStates.StatesId=@StatesId and @StatesId is not null and
OrgIndFlag = 0

Union

SELECT ResourceTypes.Id as Id, 
ResourceTypes.Name as ResName,
Contracts.Name as ContractName,
Organizations.Name as OrgName,
ContractSupplies.Description as ContractDesc
from

Contracts inner join 
ContractSupplies on ContractSupplies.ContractsId=Contracts.Id inner join
ContractSuppliesLocs on ContractSuppliesLocs.ContractSuppliesId=ContractSupplies.Id inner join 
ResourceTypes on ContractSupplies.ResourceTypesId=ResourceTypes.Id inner join
Organizations on Contracts.OrgIdSupplier=Organizations.Id 

Where ContractSuppliesLocs.LocsId=@LocsId and @LocsId is not null and 
OrgIndFlag = 0
Order by ResName, ContractName
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveEventsAll]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveEventsAll]
@OrgId int=null, 
@OrgIdP int=null,
@LicenseId int=null,
@DomainId int=null,
@HHFlag int=null
As

if @HHFlag = 1 
SELECT Events.Id, 
Events.Name,
Events.Description, Events.Visibility, Events.HouseholdFlag, Events.Type

FROM  Events 
Where Events.HouseholdFlag=@HHFlag
Order by Events.Seq, Events.Name

else

if @OrgId is not null

SELECT Events.Id, 
Events.Name,
Events.Description, Events.Visibility, Events.HouseholdFlag, Events.Type
FROM  Events inner join
Organizations on Events.OrgId=Organizations.Id  inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where (Events.OrgId=@OrgId and Events.HouseholdFlag is null) or
Events.Visibility=1 or
(Events.Visibility=2 and Licenses.DomainId=@DomainId and Events.HouseholdFlag is null) or
(Events.Visibility=3 and Organizations.LicenseId=@LicenseId and Events.HouseholdFlag is null) or
(Events.Visibility=4 and Organizations.ParentOrg=@OrgIdP and Events.HouseholdFlag is null)

Order by Events.Seq, Events.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveEvents]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveEvents]
@OrgId int=0,
@OrgIdP int =0,
@LicenseId int=0,
@DomainId int =0,
@Caller nvarchar (50) = 'Coop'
AS
if @Caller='Coop'
Select Id, Name, Description, Type, Visibility from Events
Where OrgId=@OrgId

else
Select  Events.Id,  Events.Name,  Events.Description,  Events.Type,   Events.Visibility 
from Events
inner join Organizations on  Events.OrgId=Organizations.Id
inner join Licenses on Organizations.LicenseId=Licenses.Id
Where Events.Visibility=1
or (Licenses.DomainId=@DomainId and Events.Visibility=2)
or (Organizations.LicenseId=@LicenseId and Events.Visibility=3) 
or (Organizations.ParentOrg=@OrgIdP and Events.Visibility=4)
or (Organizations.Id=@OrgId and Events.Visibility=5)
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveCountries]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveCountries]
@Status int= null
AS

Select Id, Name

from Countries
Where Status = @Status
Order by Seq, Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveClientsAll]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[wms_RetrieveClientsAll]
@OrgId int=null, 
@OrgIdP int=null,
@LicenseId int=null,
@DomainId int=null
As

SELECT Clients.Id, 
Clients.Name
FROM  Clients inner join
Organizations on Clients.OrgId=Organizations.Id  inner join
Licenses on Organizations.LicenseId=Licenses.Id
Where (Clients.OrgId=@OrgId) or
Clients.Visibility=1 or
(Clients.Visibility=2 and Licenses.DomainId=@DomainId) or
(Clients.Visibility=3 and Organizations.LicenseId=@LicenseId) or
(Clients.Visibility=4 and Organizations.ParentOrg=@OrgIdP)

Order by Clients.Name
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveBudOrgClients]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[wms_RetrieveBudOrgClients]
@BudOrgsId int
AS
SELECT BudOrgClients.Id, Clients.Name as ClientsName,
BudOrgClients.Description

from
Clients inner join
BudOrgClients on BudOrgClients.ClientsId=Clients.Id 

Where
BudOrgClients.BudOrgsId=@BudOrgsId
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveBudOLServiceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveBudOLServiceTypes]
@BudOrgsId int, 
@EPSFlag int=null
As
if @EPSFlag is null
SELECT
ServiceTypes.Id as Id,--0
ServiceTypes.Name as Name,--1 
ProfileServiceTypes.Id AS PSTId,--2
ServiceTypes.ProjName AS PJName,--3 
ServiceTypes.ProjNameS AS PJNameS,--4
'' as BudOLServicesId,--5
'0' as BudAmt
FROM 
BudOrgs inner join
Organizations ON BudOrgs.OrgId = Organizations.Id INNER JOIN
ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
OrgServiceTypes ON ProfileServiceTypes.Id = OrgServiceTypes.PSTId AND 
OrgServiceTypes.OrgId = Organizations.Id INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id inner join 
Functions on ServiceTypes.TypeId=Functions.Id
WHERE BudOrgs.Id = @BudOrgsId
ORDER BY Functions.Seq, ServiceTypes.Seq

else

SELECT
ServiceTypes.Id as Id,--0
ServiceTypes.Name as Name,--1 
ProfileServiceTypes.Id AS PSTId,--2
ServiceTypes.ProjName AS PJName,--3 
ServiceTypes.ProjNameS AS PJNameS,--4
'' as BudOLServicesId,--5
'0' as BudAmt
FROM 
BudOrgs inner join
Organizations ON BudOrgs.OrgId = Organizations.Id INNER JOIN
ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
OrgServiceTypes ON ProfileServiceTypes.Id = OrgServiceTypes.PSTId AND 
OrgServiceTypes.OrgId = Organizations.Id INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id inner join 
Functions on ServiceTypes.TypeId=Functions.Id
WHERE BudOrgs.Id = @BudOrgsId and ServiceTypes.TypeId = 1
ORDER BY ServiceTypes.Seq
GO
/****** Object:  StoredProcedure [dbo].[wms_RetrieveOrgLocServiceTypes]    Script Date: 02/21/2014 15:49:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[wms_RetrieveOrgLocServiceTypes]
@LocationsId int,
@BudOrgsId int, 
@EPSFlag int=null
As
if @EPSFlag is null
SELECT
ServiceTypes.Id,
ServiceTypes.Id as Id,--0
ServiceTypes.Name as Name,--1 
ProfileServiceTypes.Id AS PSTId,--2
ServiceTypes.ProjName AS PJName,--3 
ServiceTypes.ProjNameS AS PJNameS,--4
BudOLServices.Id as BudOLServicesId,--5
BudOLServices.BudAmt as BudAmt
FROM 
BudOrgs inner join
BudOLServices on BudOLServices.BudOrgsId=BudOrgs.Id inner join
Organizations ON BudOrgs.OrgId = Organizations.Id INNER JOIN
ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
OrgServiceTypes ON ProfileServiceTypes.Id = OrgServiceTypes.PSTId AND 
OrgServiceTypes.OrgId = Organizations.Id INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id inner join 
Functions on ServiceTypes.TypeId=Functions.Id
WHERE BudOLServices.BudOrgsId = @BudOrgsId and BudOLServices.LocationsId=@LocationsId
ORDER BY Functions.Seq, ServiceTypes.Seq

/*else

SELECT    
ServiceTypes.Id as Id, --0
ServiceTypes.Name as Name, --1
ProfileServiceTypes.Id AS PSTId, --2
ServiceTypes.ProjName AS PJName, --3
ServiceTypes.ProjNameS AS PJNameS,--4
BudOLServices.Id as BudOLServicesId,--5
BudOLServices.BudAmt as BudAmt
FROM  BudOrgs inner join
BudOLServices on BudOLServices.BudOrgsId=BudOrgs.Id inner join
OrgLocations on BudOLServices.LocationsId=OrgLocations.LocId and BudOrgs.OrgId=OrgLocations.OrgId inner join 
Locations on BudOLServices.LocationsId=Locations.Id INNER JOIN
Organizations ON OrgLocations.OrgId = Organizations.Id INNER JOIN
ProfileServiceTypes ON ProfileServiceTypes.ProfilesId = Organizations.ProfileId INNER JOIN
OrgServiceTypes ON ProfileServiceTypes.Id = OrgServiceTypes.PSTId AND 
OrgServiceTypes.OrgId = Organizations.Id INNER JOIN
ServiceTypes ON ProfileServiceTypes.ServiceTypesId = ServiceTypes.Id 
WHERE (OrgLocations.Id = @OrgLocId) and ServiceTypes.TypeId = 1
ORDER BY ServiceTypes.Seq*/
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudOrgsCAmt]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudOrgsCAmt]
@BOId int
As

Update BudOrgs Set
AmtChange=(Select Sum(BOAmts. Amount) from BOAmts where BudOrgsId=@BOId)
Where BudOrgs.Id=@BOId
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudOrgsAmt]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudOrgsAmt]
@Id int,
@OrigAmt dec (20,2)=null
As

Update BudOrgs 
Set
OrigAmt=@OrigAmt
Where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[fms_UpdateBudOrgs]    Script Date: 02/21/2014 15:49:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_UpdateBudOrgs]
@OrgId int,
@BudgetsId int
As
Insert into BudOrgs (OrgId, BudgetsId)
Values (@OrgId, @BudgetsId)
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudOrgsWP]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudOrgsWP]
@OrgId int
AS
Select 
BudOrgs.Id as Id, --0
Organizations.Name as BOrgName,--1
Budgets.Name  as BudName,--2
Currencies.NamePlural as CurrCode,--+  '(' + Max(Currencies.Code) + ')' as CurrCode,--3
'Status'=
Case Budgets.Status--4
When 1 then 'Open'
When 2 then 'Closed'
Else 'Created'
End,
Currencies.Id as BudCurrId,--5
Budgets.Id as BudgetsId,--6
'Sorter'=
Case
When BudOrgs.OrgId = Budgets.OrgId then 1 else 2
End,
'BudAmt'=
Case
When Budgets.Amount is null then 0
Else Budgets.Amount
End

From 
BudOrgs inner join
Budgets on BudOrgs.BudgetsId=Budgets.Id  inner join.
Organizations on Budgets.OrgId=Organizations.Id inner join
Currencies on Budgets.CurrenciesId=Currencies.Id 
Where BudOrgs.OrgId=@OrgId 
Order by Sorter, Budgets.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudOrgsSel]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudOrgsSel]
@BudgetsId int,
@OrgId int
AS
Select 
BudOrgs.Id
From 
BudOrgs 
Where BudOrgs.BudgetsId=@BudgetsId and BudOrgs.OrgId=@OrgId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudOrgsD]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudOrgsD]
@BudgetsId int
AS
Select 
BudOrgs.Id as Id,--0
Organizations.Name as OrgName,--1
Funds.Name + ' (FY' + CAST(Budgets.FY AS varchar) + ')' as BudName,--2
BudOrgs.OrigAmt as OrigAmt,--3
'CurrAmt'=--4
Case
When BudOrgs.OrigAmt is null and  BudOrgs.AmtChange is null then null
When  BudOrgs.OrigAmt is null and  BudOrgs.AmtChange is not null then BudOrgs.AmtChange
When  BudOrgs.OrigAmt is not null and  BudOrgs.AmtChange is null then BudOrgs.OrigAmt
Else  BudOrgs.OrigAmt +  BudOrgs.AmtChange
End,
'0' as Req,--5
Organizations.Id as BDOrgId--6


From 
BudOrgs inner join 
Budgets on BudOrgs.BudgetsId=Budgets.Id inner join
Funds on Budgets.FundsId=Funds.Id inner join
Organizations on BudOrgs.OrgId=Organizations.Id 

Where BudOrgs.BudgetsId=@BudgetsId
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBudOrgs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBudOrgs]
@OrgId int
AS
Select 
Budgets.Id as Id,
Budgets.Name Name
From 
BudOrgs inner join 
Budgets on BudOrgs.BudgetsId=Budgets.Id 
Where BudOrgs.OrgId=@OrgId 
Order by Seq
GO
/****** Object:  StoredProcedure [dbo].[fms_RetrieveBOJournal]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_RetrieveBOJournal]
@BOJournalsId  int
 AS
Select 
Organizations.Name as BDOrgName,
BOAmts.Amount as BDAmount
from 
BOAmts inner join
BudOrgs on BOAmts.BudOrgsId=BudOrgs.Id inner join
Organizations on BudOrgs.OrgId=Organizations.id
Where BOAmts.BOJournalsId=@BOJournalsId
Order by Organizations.Name
GO
/****** Object:  StoredProcedure [dbo].[fms_DeleteBudOrgs]    Script Date: 02/21/2014 15:49:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[fms_DeleteBudOrgs]
@Id int
AS

Delete BudOrgs
Where Id=@Id
GO
