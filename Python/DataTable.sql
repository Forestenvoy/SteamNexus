-- SteamNexus 資料表建立

USE SteamNexus;

-- DROP TABLE CPUs;
-- DROP TABLE GPUs;

-- 中央處理器 CPUs 
CREATE TABLE CPUs
(
    CPUID INT NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- CPU 名稱
    Name VARCHAR(100) NOT NULL,
    -- CPU 跑分
    Score INT NOT NULL
);

-- 顯示卡 GPUs
CREATE TABLE GPUs
(
    GPUID INT NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- GPU 名稱
    Name VARCHAR(100) NOT NULL,
    -- GPU 跑分
    Score INT NOT NULL
);

