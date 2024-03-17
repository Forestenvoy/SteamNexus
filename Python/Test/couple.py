import requests
from bs4 import BeautifulSoup
import os

# 存原價屋的 html 方便我看

url = "https://coolpc.com.tw/evaluate.php"

headers = {
    'user-agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36'}

res = requests.get(url,  headers=headers)
Soup = BeautifulSoup(res.text, 'html.parser')

coolpchtml_filepath = './python/Test/coolpcInfo.html'  # 設定"遊戲資訊.html"的相對路徑
if not os.path.exists(coolpchtml_filepath):  # 檢查 html 是否存在
    # open('相對路徑', 'w', encoding='utf-8') <-- 檔案輸出用的
    with open(coolpchtml_filepath, 'w', encoding='utf-8') as file:
        file.write(Soup.prettify())
    print(f"'原價屋.html'創建成功\n--------------------------")
else:
    print(f"'原價屋.html'已存在\n--------------------------")
