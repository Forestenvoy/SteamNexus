-- SteamNexus 資料表建立

USE SteamNexus;

-- 中央處理器 CPUs 
CREATE TABLE CPUs
(
    CPUID INT NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- CPU 名稱
    Name NVARCHAR(100) NOT NULL,
    -- CPU 跑分
    Score INT NOT NULL
);

-- 顯示卡 GPUs
CREATE TABLE GPUs
(
    GPUID INT NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- GPU 名稱
    Name NVARCHAR(100) NOT NULL,
    -- GPU 跑分
    Score INT NOT NULL
);

-- 遊戲語言表
CREATE TABLE Languages
(
    LanguageID int NOT NULL PRIMARY KEY IDENTITY(100,1),
    -- 英文
    english int DEFAULT 0,
    -- 簡體中文
    schinese int DEFAULT 0,
    -- 繁體中文
    tchinese int DEFAULT 0,
    -- 法文
    french int DEFAULT 0,
    -- 義大利文
    italian int DEFAULT 0,
    -- 德文
    german int DEFAULT 0,
    -- 西班牙文 - 西班牙
    spanish_spain int DEFAULT 0,
    -- 西班牙文 - 拉丁美洲
    spanish_latinamerica int DEFAULT 0,
    -- 葡萄牙文 - 巴西
    portuguese_brazil int DEFAULT 0,
    -- 俄文
    russian int DEFAULT 0,
    -- 日文
    japanese int DEFAULT 0,
    -- 韓文
    korean int DEFAULT 0,
);

-- 最低配備
CREATE TABLE MinimumRequirements
(
    MinReqID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- CPU，外來鍵，預設 10000
    CPUID int NOT NULL DEFAULT 10000,
    -- GPU，外來鍵，預設 10000
    GPUID int NOT NULL DEFAULT 10000,
    -- 記憶體，預設 4 
    RAM int NOT NULL DEFAULT 4,
    -- 作業系統
    OS NVARCHAR(100),
    -- DirectX
    DirectX NVARCHAR(100),
    -- 網路需求
    Network NVARCHAR(100),
    -- 儲存空間
    Storage NVARCHAR(100),
    -- 音效卡
    Audio NVARCHAR(100),
    -- 備註
    Note NVARCHAR(500)
);

-- 建議配備
CREATE TABLE RecommendedRequirements
(
    RecReqID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- CPU，外來鍵，預設 10000
    CPUID int NOT NULL DEFAULT 10000,
    -- GPU，外來鍵，預設 10000
    GPUID int NOT NULL DEFAULT 10000,
    -- 記憶體，預設 4 
    RAM int NOT NULL DEFAULT 4,
    -- 作業系統
    OS NVARCHAR(100),
    -- DirectX
    DirectX NVARCHAR(100),
    -- 網路需求
    Network NVARCHAR(100),
    -- 儲存空間
    Storage NVARCHAR(100),
    -- 音效卡
    Audio NVARCHAR(100),
    -- 備註
    Note NVARCHAR(500)
);

-- 遊戲資料表
CREATE TABLE Games
(
    GameID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- Steam 內部的 遊戲 ID
    AppID int NOT NULL,
    -- 遊戲名稱
    Name NVARCHAR(100) NOT NULL,
    -- 遊戲原始價格
    OriginalPrice int NOT NULL,
    -- 遊戲現在價格
    CurrentPrice int NOT NULL,
    -- 歷史最低價格
    LowestPrice int NOT NULL,
    -- 遊戲分級
    AgeRating NVARCHAR(100) NOT NULL,
    -- 發行日期
    ReleaseDate DATETIME,
    -- 發行商
    Publisher NVARCHAR(100),
    -- 遊戲介紹
    Description NVARCHAR(MAX),
    -- 當前遊玩人數
    Players int,
    -- 24小時高峰人數
    PeakPlayers int,
    -- 遊戲語言支援
    LanguageID int NOT NULL,
    -- 遊戲圖片路徑
    ImagePath NVARCHAR(300),
    -- 遊戲影片路徑
    VideoPath NVARCHAR(300),
    -- 最低配備
    MinReqID int NOT NULL,
    -- 建議配備
    RecReqID int NOT NULL
);

-- 標籤表
CREATE TABLE Tags
(
    TagID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 標籤名稱
    Name NVARCHAR(100) NOT NULL
);

-- 標籤群組表 
CREATE TABLE TagGroups
(
    TagGroupID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 遊戲ID，外來鍵
    GameID int NOT NULL,
    -- 標籤ID，外來鍵
    TagID int NOT NULL
);

-- 價格歷史表
CREATE TABLE PriceHistory
(
    PriceHistoryID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 遊戲ID，外來鍵
    GameID int NOT NULL,
    -- 日期
    Date DATE NOT NULL,
    -- 價格
    Price int NOT NULL
)

-- 遊玩人數歷史表
CREATE TABLE PlayersHistory
(
    PlayersHistoryID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 遊戲ID，外來鍵
    GameID int NOT NULL,
    -- 日期 and 時間
    Date DATETIME NOT NULL,
    -- 遊玩人數
    Players int NOT NULL
)

-- 會員資料表
CREATE TABLE Members
(
    MemberID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 會員帳號 = 信箱
    Email NVARCHAR(100) NOT NULL UNIQUE,
    -- 會員密碼
    Password NVARCHAR(100) NOT NULL,
    -- 名稱
    Name NVARCHAR(100),
    -- 性別
    Gender bit DEFAULT 0,
    -- 電話
    Phone NVARCHAR(100),
    -- 生日
    Birthday DATE DEFAULT '1900-01-01',
    -- 大頭照
    Photo NVARCHAR(300),
    -- 會員的 CPU
    CPUID int NOT NULL DEFAULT 10000,
    -- 會員的 GPU
    GPUID int NOT NULL DEFAULT 10000,
    -- 會員的 RAM
    RAM int NOT NULL DEFAULT 4
)

-- 遊戲追蹤表
CREATE TABLE GameFollows
(
    GameFollowID int NOT NULL PRIMARY KEY IDENTITY(10000,1),
    -- 會員ID，外來鍵
    MemberID int NOT NULL,
    -- 遊戲ID，外來鍵
    GameID int NOT NULL,
    -- 追蹤時間，預設現在時間
    FollowTime DATETIME DEFAULT GETDATE()
)