import pymssql

# 建立資料庫連線
conn = pymssql.connect(
    server='.',  # 本機伺服器
    database='mydb',
)

# 建立游標，並設定 as_dict 參數
cursor = conn.cursor(as_dict=True)

# 執行 SELECT 查詢
query = "SELECT * FROM Persons WHERE Point > 2000;"
cursor.execute(query)

# 擷取查詢結果
rows = cursor.fetchall()

# 輸出查詢結果
for row in rows:
    print(row)

# 關閉游標和連線
cursor.close()
conn.close()
