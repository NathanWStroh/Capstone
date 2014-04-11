CREATE PROCEDURE [dbo].[proc_GetAllApplicationVariables]
AS
	SELECT ParameterKey as 'Key', ParameterValue as 'Value'
	from ApplicationVariables