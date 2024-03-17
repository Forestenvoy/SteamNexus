-- 移除外來鍵關聯
USE SteamNexus;

-- 有關聯就會有刪除順序問題 !! 從後面開始刪除

-- 解除遊戲追蹤表的外鍵約束
ALTER TABLE GameFollows
DROP CONSTRAINT FK_GameFollows_Games;
ALTER TABLE GameFollows
DROP CONSTRAINT FK_GameFollows_Members;

-- 解除會員資料表的外鍵約束
ALTER TABLE Members
DROP CONSTRAINT FK_Members_GPUs;
ALTER TABLE Members
DROP CONSTRAINT FK_Members_CPUs;

-- 解除遊玩人數歷史表的外鍵約束
ALTER TABLE PlayersHistory
DROP CONSTRAINT FK_PlayersHistory_Games;

-- 解除價格歷史表的外鍵約束
ALTER TABLE PriceHistory
DROP CONSTRAINT FK_PriceHistory_Games;

-- 解除標籤群組表的外鍵約束
ALTER TABLE TagGroups
DROP CONSTRAINT FK_TagGroups_Tags;
ALTER TABLE TagGroups
DROP CONSTRAINT FK_TagGroups_Games;

-- 解除遊戲資料表的外鍵約束
ALTER TABLE Games
DROP CONSTRAINT FK_Games_RecommendedRequirements;
ALTER TABLE Games
DROP CONSTRAINT FK_Games_MinimumRequirements;
ALTER TABLE Games
DROP CONSTRAINT FK_Games_Languages;

-- 解除建議配備的外鍵約束
ALTER TABLE RecommendedRequirements
DROP CONSTRAINT FK_RecommendedRequirements_GPUs;
ALTER TABLE RecommendedRequirements
DROP CONSTRAINT FK_RecommendedRequirements_CPUs;

-- 解除最低配備的外鍵約束
ALTER TABLE MinimumRequirements
DROP CONSTRAINT FK_MinimumRequirements_GPUs;
ALTER TABLE MinimumRequirements
DROP CONSTRAINT FK_MinimumRequirements_CPUs;

