import requests  # https 請求
from bs4 import BeautifulSoup  # 網頁解析
import pymssql  # SQL Server 資料庫操作

# 跑分參考網址 cpubenchmark
url = "https://www.cpubenchmark.net/cpu_list.php"

headers = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36'
}

res = requests.get(url, headers=headers)
Soup = BeautifulSoup(res.text, 'html.parser')

# 找到 CPU Table
CPUTable = Soup.find(id="cputable")
# 將每一列的資料存成 List
CPUData = CPUTable.find("tbody").find_all("tr")

# 製作 CPU Dictionary ~ 名稱:分數
CPUDict = {}
for Data in CPUData:
    CPU = Data.find_all("td")
    Name = CPU[0].text.strip()
    # 只抓 intel AMD CPU
    if (Name[:3] != 'AMD' and Name[:5] != 'Intel'):
        continue
    Score = CPU[1].text.strip()
    # 去除分數中的逗號
    Score = Score.replace(',', '')
    Score = int(Score)
    CPUDict[Name] = Score

try:
    # 建立資料庫連線
    conn = pymssql.connect(
        server='.',  # 本機伺服器
        database='SteamNexus',
    )

    print("資料庫連線建立成功！")

    # 在這裡可以繼續執行與資料庫相關的操作

except Exception as e:
    print("建立資料庫連線時發生錯誤：", e)
    # 在這裡可以處理錯誤，例如日誌記錄、顯示錯誤訊息等

# 建立游標
cursor = conn.cursor()
# 游標是一個物件，可以使用它來向資料庫發送 SQL 命令，並處理返回的結果。

try:
    # 遍歷字典，插入資料到資料庫
    for Name, Score in CPUDict.items():
        query = f"INSERT INTO CPUs(Name, Score) VALUES ('{Name}', {Score});"
        cursor.execute(query)
    conn.commit()

    print("資料全部插入成功！")

except Exception as e:
    # 如果出現錯誤，回滾事務
    conn.rollback()
    print("資料插入失敗：", e)

finally:
    # 關閉游標
    cursor.close()
    # 關閉資料庫連線
    conn.close()
