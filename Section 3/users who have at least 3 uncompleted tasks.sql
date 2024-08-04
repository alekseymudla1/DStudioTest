-- Just Ids
SELECT [Users].[UserId]
FROM [dbo].[Users] AS [Users]
INNER JOIN [dbo].[Todos] AS [Todos]
  ON [Users].[UserId] = [Todos].[UserId]
  AND [Todos].[IsCompleted] = 0
GROUP BY [Users].[UserId]
HAVING COUNT(*) >= 3

-- All data
SELECT [Users].*
FROM [Users]
WHERE [Users].[UserId] IN (
  SELECT [Users].[UserId]
  FROM [dbo].[Users] AS [Users]
  INNER JOIN [dbo].[Todos] AS [Todos]
	ON [Users].[UserId] = [Todos].[UserId]
	AND [Todos].[IsCompleted] = 0
  GROUP BY [Users].[UserId]
  HAVING COUNT(*) >= 3)
