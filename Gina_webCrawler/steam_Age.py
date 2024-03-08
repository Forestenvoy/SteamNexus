import requests as req
from bs4 import BeautifulSoup as bs
from pprint import pprint
import json

url = "https://store.steampowered.com/app/813780/Age_of_Empires_II_Definitive_Edition/"
my_headers = {'Accept-Language': 'zh-TW'}
my_cookies = {'birthtime': '568022401'}

res = req.get(url,cookies = my_cookies,headers=my_headers)
soup = bs(res.text, "lxml")
data_List=[]

gameName = soup.select_one('div.apphub_AppName') #標題
gameDescriptionSnippet = soup.select_one('div.game_description_snippet') #敘述
gameTagList = []
for a in soup.find_all('a',class_='app_tag'): 
    if a:
        gameTagList.append(a.text.strip())  #遊戲Tag

gamePrice = soup.select_one('div.game_purchase_price') #價格
gameLanguage=[]
for a in soup.select('table.game_language_options>tr>td.ellipsis'):
    if a :
        gameLanguage.append(a.text.strip())


data_List.append({'遊戲標題':gameName.text.strip()})
data_List.append({'遊戲敘述':gameDescriptionSnippet.text.strip()})
data_List.append({'遊戲Tag':gameTagList})
data_List.append({'遊戲價格':gamePrice.text.strip()})
data_List.append({'遊戲語言':gameLanguage})
        
# print(f"遊戲標題:{gameName.text.strip()}")
# print(f"遊戲敘述:{gameDescriptionSnippet.text.strip()}")
# print(f"遊戲Tag:{gameTagList}")
# print(f"遊戲價格:{gamePrice}")
pprint(data_List)

with open("output.json","w",encoding="utf-8")as f:
    json.dump(data_List, f,ensure_ascii=False,indent=4)
    f.write(res.text)

print("輸出完成")




# pprint(res.text)

# a=res.decompose(soup.select('div[role="banner"]'))

# pprint(a.text)

# with open("output.html","w",encoding="utf-8")as f:
#     f.write(res.text)
