 
import requests, json,time,os
from requests.auth import HTTPBasicAuth

from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
url = "http://@192.168.1.1/GponForm/waninfo_XForm"
header = {
    "Connection": "keep-alive",
    "Upgrade-Insecure-Requests": "1",
    "Accept" :"text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
    "Content-type": "application/x-www-form-urlencoded"}
payload =  "XWebPageName=waninfo&wan_list=0&vRefresh=0"
auth = HTTPBasicAuth('admin', '3093046744')
auth = HTTPBasicAuth('admin123', 'nhan300191')
paylog="XRanID=e5039b302aa0f579e7753f987bf233340ea6d26bb25b1fdd2364a3b6e41467cf&XNonce=cvgFXcvNTACbEm628Y0a8kKOZGIArJ9T&XWebPageName=index"
                                                                                    #CAXyVHqevEbZeAnoaDtycfrPSM9Uvyh5
                                                                                    #q0cZqg4oAur7fWK66V2eYmE8iUbJUA2L


#response_decoded_json = requests.post(url, data=payload, headers=header, auth=auth)
"""
getIP = requests.get("http://192.168.1.1")
getIP = requests.get("http://192.168.1.1/login.html")
getIP = requests.get("http://192.168.1.1/script/jquery.js")
getIP = requests.get("http://192.168.1.1/script/sha256.js")
getIP = requests.get("http://192.168.1.1/script/rg_menu.js")
getIP = requests.get("http://192.168.1.1/script/lang_en.js")
getIP = requests.get("http://192.168.1.1/style/reset.css")
getIP = requests.get("http://192.168.1.1/images/logo.png")
getIP = requests.get("http://192.168.1.1/style/ont.css")
getIP = requests.get("http://192.168.1.1/style/reset.css")

"""

#browser	=	webdriver.Firefox()#"C:\Program Files\Google\Chrome\Application\chrome.exe"
"""browser = webdriver.Chrome("C:\Program Files\Google\Chrome\Application\chrome.exe")
browser.get('http://192.168.1.1/login.html') 

userElem	=	browser.find_element_by_id('username') 
userElem.send_keys('admin') #admn no here 
passwordElem	=	browser.find_element_by_id('password') 
passwordElem.send_keys('3093046744') # password here 
loginElem	=	browser.find_element_by_id('btn_login') 
loginElem.click() 

browser.close()"""
# wait for transition then continue to fill items
"""userElem = WebDriverWait(browser, 10).until(EC.presence_of_element_located((By.ID, 'username')))
userElem.send_keys("admin")
password = WebDriverWait(browser, 10).until(EC.presence_of_element_located((By.ID, 'password')))
password.send_keys("3093046744")
signInButton = browser.find_element_by_id('btn_login')
signInButton.click()"""
"""


browser	=	webdriver.Firefox() 
browser.get('http://mywebsite.me') 
userElem	=	browser.find_element_by_id('txtUserName') 
userElem.send_keys('admission number') #admn no here 
passwordElem	=	browser.find_element_by_id('txtPassword') 
passwordElem.send_keys('password') # password here 
loginElem	=	browser.find_element_by_id('btnLogin') 
loginElem.click() 

"""
#response_decoded_json = requests.post("http://192.168.1.1/GponForm/LoginForm", data=paylog, headers=header)


#print("LOGIN",response_decoded_json.status_code ,flush=True)
response_decoded_json = requests.post(url, data=payload, headers=header)
#admind23093046744
print(response_decoded_json.status_code ,flush=True)
if (response_decoded_json.status_code == 200):
    status = 1
    while(status == 1):
        ipaddress = '8.8.8.8'
        status = os.system("ping -t500 -n 1 " + ipaddress)
        print("response",status,flush=True)
    getIP = requests.get("https://api.myip.com/")
    print(getIP.json(),flush=True)
else:
    print("Pls, login agian",flush=True)


#http://192.168.1.1/GponForm/LoginForm

"""
http://192.168.1.1/GponForm/waninfo_XForm


XWebPageName=waninfo&wan_list=0&vRefresh=0


url = "http://192.168.1.1/GponForm/wan_XForm"
payload = "XWebPageName=wan&wan_list=0&wan_en=1&internet=4&tr069=2&iptv=8&ip_ver=0&ip_mode=1&mtu=1500&nat=1&metric=1&ppp_user=Sgfdl-201113-871&ppp_pass=08ypih%25%26*%25%5E%23T%28%29%23%24%26E%25SUCG6uy%24E%26&ppp_mode=0&static_ip=&static_mask=&static_gw=&ipv6_static_addr=&ipv6_static_wanplen=&dnswr=0&dns1=0.0.0.0&dns2=0.0.0.0&ipv6_dnswr=1&ipv6_dns1=2001%3A4860%3A4860%3A%3A8888&ipv6_dns2=2001%3A4860%3A4860%3A%3A8844&rd6_en=0&rd6_opt=0&rd6_manual_prefix_val=&rd6_manual_prefix_length_val=0&rd6_manual_ipv4mask_length_val=0&rd6_manual_border_addr_val=0.0.0.0&dslite_en=0&dslite_mode=0&dslite_aftraddr=&ipv6_ad_mode=2&ipv6_ad_static=&ipv6_pd_mode=16&ipv6_pd_static=&ipv6gw="
Frame 47: 805 bytes on wire (6440 bits), 805 bytes captured (6440 bits) on interface {541524ED-25D1-4687-ADB2-1CF7B713EFBD}, id 0
Ethernet II, Src: IntelCor_ef:c3:79 (4c:eb:42:ef:c3:79), Dst: CigShang_b7:d4:06 (34:b5:a3:b7:d4:06)
Internet Protocol Version 4, Src: 192.168.1.70, Dst: 192.168.1.1
Transmission Control Protocol, Src Port: 58491, Dst Port: 80, Seq: 1, Ack: 1, Len: 751
Hypertext Transfer Protocol
    POST /GponForm/LoginForm HTTP/1.1\r\n
    Host: 192.168.1.1\r\n
    Connection: keep-alive\r\n
    Content-Length: 130\r\n
    Cache-Control: max-age=0\r\n
    Upgrade-Insecure-Requests: 1\r\n
    Origin: http://192.168.1.1\r\n
    Content-Type: application/x-www-form-urlencoded\r\n
    User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82 Safari/537.36\r\n
                Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82 Safari/537.36
    Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9\r\n
    Referer: http://192.168.1.1/login.html\r\n
    Accept-Encoding: gzip, deflate\r\n
    Accept-Language: en-US,en;q=0.9,vi;q=0.8\r\n
    \r\n
    [Full request URI: http://192.168.1.1/GponForm/LoginForm]
    [HTTP request 1/1]
    [Response in frame: 60]
    File Data: 130 bytes
HTML Form URL Encoded: application/x-www-form-urlencoded
    Form item: "XRanID" = "e5039b302aa0f579e7753f987bf233340ea6d26bb25b1fdd2364a3b6e41467cf"
    Form item: "XNonce" = "q0cZqg4oAur7fWK66V2eYmE8iUbJUA2L"
        Key: XNonce
        Value: q0cZqg4oAur7fWK66V2eYmE8iUbJUA2L
    Form item: "XWebPageName" = "index"
        Key: XWebPageName
        Value: index
HTML Form URL Encoded: application/x-www-form-urlencoded




Form item: "XRanID" = "e5039b302aa0f579e7753f987bf233340ea6d26bb25b1fdd2364a3b6e41467cf"
Form item: "XNonce" = "q0cZqg4oAur7fWK66V2eYmE8iUbJUA2L"
Form item: "XWebPageName" = "index"
XRanID=e5039b302aa0f579e7753f987bf233340ea6d26bb25b1fdd2364a3b6e41467cf&XNonce=q0cZqg4oAur7fWK66V2eYmE8iUbJUA2L&XWebPageName=index
"""