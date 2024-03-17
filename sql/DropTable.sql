-- SteamNexus 刪除資料表

USE SteamNexus;

-- 有關聯就會有刪除順序問題 !! 從後面開始刪除

DROP TABLE PlayersHistory;
DROP TABLE PriceHistory;
DROP TABLE TagGroups;
DROP TABLE Tags;
DROP TABLE Games;
DROP TABLE RecommendedRequirements;
DROP TABLE MinimumRequirements;
DROP TABLE Languages;
DROP TABLE GPUs;
DROP TABLE CPUs;
