-- 在你的 mydb 練習

USE mydb;

-- 遊戲資訊表
CREATE TABLE Games
(
    GameID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 名稱
    Name nvarchar(100) NOT NULL,
    --價格
    Price int NOT NULL,
    -- 遊戲介紹
    Description nvarchar(max) NOT NULL,
    -- 發行日期
    ReleaseDate date NOT NULL,
    -- 發行商
    publisher nvarchar(100) NOT NULL,
    -- 販售狀態 0:一般 1:特價中 
    Status int NOT NULL DEFAULT 0,
    -- 最低系統需求，外來鍵
    SRMID int NOT NULL,
    -- 建議系統需求，外來鍵
    SRRID int NOT NULL
);

-- 最低系統需求表
CREATE TABLE SystemRequirement_Min
(
    SRMID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 作業系統
    OS nvarchar(100),
    -- CPU
    CPU nvarchar(100),
    -- GPU
    GPU nvarchar(100),
    -- 記憶體
    RAM nvarchar(100),
    -- DirectX 版本
    DirectX nvarchar(100),
    -- 網路
    Internet nvarchar(100),
    -- 儲存空間
    Storage nvarchar(100),
    -- 備註
    note nvarchar(500)
)

-- 建議系統需求
CREATE TABLE SystemRequirement_Rec
(
    SRRID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 作業系統
    OS nvarchar(100),
    -- CPU
    CPU nvarchar(100),
    -- GPU
    GPU nvarchar(100),
    -- 記憶體
    RAM nvarchar(100),
    -- DirectX 版本
    DirectX nvarchar(100),
    -- 網路
    Internet nvarchar(100),
    -- 儲存空間
    Storage nvarchar(100),
    -- 備註
    note nvarchar(500)
)