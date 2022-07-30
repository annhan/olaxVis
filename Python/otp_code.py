#!/usr/bin/ python3

import pyotp
import base64
import datetime

class SingletonMeta(type):
    _instances = {}
    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            instance = super().__call__(*args, **kwargs)
            cls._instances[cls] = instance
        return cls._instances[cls]

class otp_code(metaclass=SingletonMeta):

    def __loop_check_otc(self,OTCF,timenow,ma):
        need_check = [0, 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, -6, -7, -8, -9]
        for i in need_check:
            timecheck = timenow + datetime.timedelta(seconds = i*30)
            if OTCF.at(timecheck) == ma: return True
        return False

    def checkOTC(self,code = "MWORKGROUP3VN",ma="000000"):
        datenow11 = datetime.datetime.now()

        try:
            secret = base64.b32encode(bytes(code, encoding='ascii'))
            totp = pyotp.TOTP(secret, interval=30)   
            return self.__loop_check_otc(totp, datenow11 , ma)
        except Exception as e:
            secret = "MWORKGROUP3VN"
            totp = pyotp.TOTP(secret, interval=30)
            return self.__loop_check_otc(totp, datenow11 , ma)
        return False
        
    def getOTC(self,code = "MWORKGROUP3VN",ma="000000"):
        value_otp = ""
        str_return = ""
        datenow11 = datetime.datetime.now()
        try:
            secret = base64.b32encode(bytes(code, encoding='ascii'))
            totp = pyotp.TOTP(secret, interval=30)
            value_otp = totp.at(datenow11) 
            str_return = "NAME OK - "
        except Exception as e:
            print("OTP ERROR",e)
            secret = "MWORKGROUP3VN"
            totp = pyotp.TOTP(secret, interval=30)
            str_return = "NAME ERROR - "
            value_otp = totp.at(datenow11) 
        return "{}{}".format(str_return,value_otp)

    def decoder(self,data):
        decoded1 = base64.b64decode(data.encode()).decode()
        decoded1 = decoded1[5:]
        decoded = base64.b64decode(decoded1.encode()).decode()
        value=decoded
        return value[5:]

    def encoder(self,beign,data):
        data = "{}{}".format(beign,data)
        value1 = base64.b64encode(data.encode()).decode()
        value1 = "{}{}".format(beign,value1)
        value = base64.b64encode(value1.encode()).decode()
        return value

data_sec = otp_code()

if __name__ == "__main__":
    status = data_sec.checkOTC(ma="502487",code = "mWork_COFFEE_0")
    print(status)
    status = data_sec.getOTC(ma="500353",code = "mWork_COFFEE_0")
    print("OTP",status)
    
    
"""
timedatectl list-timezones

sudo timedatectl set-timezone Asia/Ho_Chi_Minh

timedatectl

"""