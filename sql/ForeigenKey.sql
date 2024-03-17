-- 外來鍵關聯建立
USE SteamNexus;

-- 外來鍵約束 命名規則 FK_參照表名(外)_被參照表名(主)

-- 最低配備 ~ CPU、GPU
ALTER TABLE MinimumRequirements
ADD CONSTRAINT FK_MinimumRequirements_CPUs
FOREIGN KEY (CPUID) REFERENCES CPUs(CPUID);
ALTER TABLE MinimumRequirements
ADD CONSTRAINT FK_MinimumRequirements_GPUs
FOREIGN KEY (GPUID) REFERENCES GPUs(GPUID);

-- 建議配備 ~ CPU、GPU
ALTER TABLE RecommendedRequirements
ADD CONSTRAINT FK_RecommendedRequirements_CPUs
FOREIGN KEY (CPUID) REFERENCES CPUs(CPUID);
ALTER TABLE RecommendedRequirements
ADD CONSTRAINT FK_RecommendedRequirements_GPUs
FOREIGN KEY (GPUID) REFERENCES GPUs(GPUID);

-- 遊戲資料表 ~ 語言、最低配備、推薦配備
ALTER TABLE Games
ADD CONSTRAINT FK_Games_Languages
FOREIGN KEY (LanguageID) REFERENCES Languages(LanguageID);
ALTER TABLE Games
ADD CONSTRAINT FK_Games_MinimumRequirements
FOREIGN KEY (MinReqID) REFERENCES MinimumRequirements(MinReqID);
ALTER TABLE Games
ADD CONSTRAINT FK_Games_RecommendedRequirements
FOREIGN KEY (RecReqID) REFERENCES RecommendedRequirements(RecReqID);

-- 標籤群組表 ~ 遊戲、標籤
ALTER TABLE TagGroups
ADD CONSTRAINT FK_TagGroups_Games
FOREIGN KEY (GameID) REFERENCES Games(GameID);
ALTER TABLE TagGroups
ADD CONSTRAINT FK_TagGroups_Tags
FOREIGN KEY (TagID) REFERENCES Tags(TagID);

-- 價格歷史表 ~ 遊戲
ALTER TABLE PriceHistory
ADD CONSTRAINT FK_PriceHistory_Games
FOREIGN KEY (GameID) REFERENCES Games(GameID);

-- 遊玩人數歷史表 ~ 遊戲
ALTER TABLE PlayersHistory
ADD CONSTRAINT FK_PlayersHistory_Games
FOREIGN KEY (GameID) REFERENCES Games(GameID);