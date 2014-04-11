CREATE TABLE [dbo].[ApplicationVariables]
(
	ParameterKey varchar(50) not NULL UNIQUE,
	ParameterValue varchar(500) not NULL,
)
