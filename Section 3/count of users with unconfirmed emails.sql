SELECT COUNT(*) as [CountOfUsersWithUnconfirmedEmails]
FROM [DStudio.Calmplete].[dbo].[Users]
WHERE EmailConfirmed = 0