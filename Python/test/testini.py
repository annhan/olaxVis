try:
    from configparser import ConfigParser
except ImportError:
    from ConfigParser import ConfigParser  # ver. < 3.0


class config():
    def __init__(self) -> None:
        self.config = ConfigParser()
        self.config.read('params.ini')
    def get(self):
        user = self.config.get('INFOR', 'user')
        passw = self.config.get('INFOR', 'pass')
        code = self.config.get('LICENSE', 'code')
        name = self.config.get('ROUTER', 'name')
        return user,passw,code,name

    def update(self,type,name,value):
        self.config.set(type, name, value)

    def save(self):
        with open('params.ini', 'w') as configfile:
            self.config.write(configfile)

if __name__ == "__main__":
    configdata = config()
    print(configdata.get())
    configdata.update('INFOR', 'pass', 'world')
    configdata.save()
