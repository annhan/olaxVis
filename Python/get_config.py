try:
    from configparser import ConfigParser
except ImportError:
    from ConfigParser import ConfigParser  # ver. < 3.0


class config():
    def __init__(self) -> None:
        self.config = ConfigParser()
        self.config.read('params.ini')

    def save_user_web(self,user,password):
        self.config.set('ROUTER', 'user', user)
        self.config.set('ROUTER', 'pass', password)
        self.save()

    def save_type_router(self,type):
        self.config.set('ROUTER', 'name', type)
        self.save()
    def get_router(self):
        user = self.config.get('ROUTER', 'user')
        passw = self.config.get('ROUTER', 'pass')
        name = self.config.get('ROUTER', 'name')
        page = self.config.get('ROUTER', 'page')
        return user,passw,name,page

    def get_chrome_path(self):
        page = self.config.get('PATH', 'chrome')
        return page

    def set_license(self,value,code):
        self.config.set('LICENSE', 'value',value) #string
        self.config.set('LICENSE', 'code',code) # la so
        self.save()        


    def get_license(self):
        value = self.config.get('LICENSE', 'value')
        code = self.config.get('LICENSE', 'code')
        return value,code


    def get_ip(self):
        server = self.config.get('GETIP', 'server')
        timeout = self.config.get('GETIP', 'timeout')
        return server,timeout

    def update(self,type,name,value):
        self.config.set(type, name, value)

    def save(self):
        with open('params.ini', 'w') as configfile:
            self.config.write(configfile)

if __name__ == "__main__":
    configdata = config()
    print(configdata.get_router())
    configdata.update('INFOR', 'pass', 'world')
    configdata.save()
