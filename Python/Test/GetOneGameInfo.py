import requests
from bs4 import BeautifulSoup
import os

# 遊戲網址 ~
# 未打折遊戲 Elden Ring ID ~ 1245620
# 打折遊戲 快打旋風 6 ID ~ 1364780
url = "https://store.steampowered.com/app/2399830/"

# 部分 Steam 遊戲:需要生日 cookies <-- 年齡驗證
cookies = {'birthtime': '568022401'}
# 語系:繁體中文
headers = {'Accept-Language': 'zh-TW'}
# requests 套件 讀取 html，回傳一個包含 HTTP 響應信息的 Response 物件 --> res
res = requests.get(url, cookies=cookies, headers=headers)
# .text： 這是一個字串，包含了伺服器返回的 HTML 內容。
# 解析 HTML 或 XML 文件 並存成一個變數 Soup
Soup = BeautifulSoup(res.text, 'html.parser')

# 儲存成一個 html 檔案 <-- 觀看 class、id 用
# steamhtml_filepath = '.\SteamNexus\SteamInfo.html'  # 設定"遊戲資訊.html"的相對路徑
# if not os.path.exists(steamhtml_filepath):  # 檢查 html 是否存在
#     # open('相對路徑', 'w', encoding='utf-8') <-- 檔案輸出用的
#     with open(steamhtml_filepath, 'w', encoding='utf-8') as file:
#         file.write(Soup.prettify())
#     print(f"'遊戲資訊.html'創建成功\n--------------------------")
# else:
#     print(f"'遊戲資訊.html'已存在\n--------------------------")

# 開始爬資料 ~~~

# strip()： 刪除字串頭尾空白
# 遊戲名稱
gameName = Soup.find(id="appHubAppName").text.strip()
# 發行日期
releaseDate = Soup.find(class_="date").text.strip()
# 開發人員
developer = Soup.find(id="developers_list").text.strip()
# 發行商 <-- 沒有 id 只能用開發人員指過去
publisher_parent = Soup.find(
    id="developers_list").parent.next_sibling.find_all_next()
publisher = publisher_parent[2].text.strip()

# 熱門標籤 <-- 存成一個 List
tagsListEl = Soup.find_all(class_="app_tag")
tags = []
for tag in tagsListEl:
    tagName = tag.text.strip()
    if (tagName == '+'):
        continue
    tags.append(tagName)

# 遊戲本體價格
# 第一個區塊 <div class="game_area_purchase_game_wrapper"> 必定是遊戲本體 (不含DLC)
priceInfo = Soup.find(class_="game_area_purchase_game_wrapper")
# 沒打折 會存在 class = "game_purchase_price price"
# 有打折 原價: class = "discount_original_price" | 優惠價: class = "discount_final_price"
if (priceInfo.find(class_="game_purchase_price price")):
    price = priceInfo.find(
        class_="game_purchase_price price").text.strip()
else:
    price = priceInfo.find(class_="discount_final_price").text.strip()

# 遊戲資訊 <div id="game_area_description" class="game_area_description">
gameDescription = Soup.find(id="game_area_description")
# 使用 stripped_strings 獲取所有非空白字符串 return 一個 generator <-- 來自 bs4 的方法
# join()： 利用指定的分隔符把序列中的元素合成一個字符串
gameDescription = "\n".join(gameDescription.stripped_strings)
# 去除 "關於此遊戲" 去除前 5 個字元 <-- 字串切片
gameDescription = gameDescription[5:]

#### 最低配備 ####
# <div class="game_area_sys_req_leftCol">
systemRequirement_min = Soup.find(class_="game_area_sys_req_leftCol")
# 取出清單表
sysReclist_min = systemRequirement_min.find_all("li")
# 預設為 "N/A"
sysRec_min_OS = "N/A"
sysRec_min_CPU = "N/A"
sysRec_min_memory = "N/A"
sysRec_min_GPU = "N/A"
sysRec_min_DirectX = "N/A"
sysRec_min_network = "N/A"
sysRec_min_storage = "N/A"
sysRec_min_note = "N/A"
for item in sysReclist_min:
    itemName = item.text.split()[0].strip()
    if (itemName == '作業系統:'):
        sysRec_min_OS = item.text[6:]
    if (itemName == '處理器:'):
        sysRec_min_CPU = item.text[5:]
    if (itemName == '記憶體:'):
        sysRec_min_memory = item.text[5:]
    if (itemName == '顯示卡:'):
        sysRec_min_GPU = item.text[5:]
    if (itemName == 'DirectX:'):
        sysRec_min_DirectX = item.text[9:]
    if (itemName == '網路:'):
        sysRec_min_network = item.text[4:]
    if (itemName == '儲存空間:'):
        sysRec_min_storage = item.text[6:]
    if (itemName == '備註:'):
        sysRec_min_note = item.text[4:]

#### 建議配備 ####
# <div class="game_area_sys_req_rightCol">
systemRequirement_rec = Soup.find(class_="game_area_sys_req_rightCol")
# 取出清單表
sysReclist_rec = systemRequirement_rec.find_all("li")
# 預設為 "N/A"
sysRec_rec_OS = "N/A"
sysRec_rec_CPU = "N/A"
sysRec_rec_memory = "N/A"
sysRec_rec_GPU = "N/A"
sysRec_rec_DirectX = "N/A"
sysRec_rec_network = "N/A"
sysRec_rec_storage = "N/A"
sysRec_rec_note = "N/A"
for item in sysReclist_rec:
    itemName = item.text.split()[0].strip()
    if (itemName == '作業系統:'):
        sysRec_rec_OS = item.text[6:]
    if (itemName == '處理器:'):
        sysRec_rec_CPU = item.text[5:]
    if (itemName == '記憶體:'):
        sysRec_rec_memory = item.text[5:]
    if (itemName == '顯示卡:'):
        sysRec_rec_GPU = item.text[5:]
    if (itemName == 'DirectX:'):
        sysRec_rec_DirectX = item.text[9:]
    if (itemName == '網路:'):
        sysRec_rec_network = item.text[4:]
    if (itemName == '儲存空間:'):
        sysRec_rec_storage = item.text[6:]
    if (itemName == '備註:'):
        sysRec_rec_note = item.text[4:]


# 爬蟲資訊呈現
print(f"遊戲名稱: {gameName}")
print(f"發行日期: {releaseDate}")
print(f"開發人員: {developer}")
print(f"發行商: {publisher}")
print(f"熱門標籤: {tags}")
print(f"遊戲本體價格: {price}")
print(f"遊戲資訊: {gameDescription}")
print(f"--------------------------------")
print(f"最低配備:")
print(f"作業系統: {sysRec_min_OS}")
print(f"處理器: {sysRec_min_CPU}")
print(f"記憶體: {sysRec_min_memory}")
print(f"顯示卡: {sysRec_min_GPU}")
print(f"DirectX: {sysRec_min_DirectX}")
print(f"網路: {sysRec_min_network}")
print(f"儲存空間: {sysRec_min_storage}")
print(f"備註: {sysRec_min_note}")
print(f"--------------------------------")
print(f"建議配備:")
print(f"作業系統: {sysRec_rec_OS}")
print(f"處理器: {sysRec_rec_CPU}")
print(f"記憶體: {sysRec_rec_memory}")
print(f"顯示卡: {sysRec_rec_GPU}")
print(f"DirectX: {sysRec_rec_DirectX}")
print(f"網路: {sysRec_rec_network}")
print(f"儲存空間: {sysRec_rec_storage}")
print(f"備註: {sysRec_rec_note}")
