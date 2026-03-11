CREATE PROCEDURE [dbo].[API_MCCode_GetSecurityTradingStatus]
AS
BEGIN
    SELECT Type, ID, SubType, Description, DescriptionEx, Value, Attribute1, Attribute2
    FROM dbo.MCCode
    WHERE Type = N'SecurityTradingStatus'
      AND SubType = 'CBTS.FIX.GATEWAY'
    ORDER BY Value
END