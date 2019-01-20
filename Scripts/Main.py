import requests
import time
import random

basePath="https://filmcrawlerbackendservice.azurewebsites.net/api/ParseImdbMovie?fileName=tt0"

for i in range(910000,911000):
    strIndex=str(i)
    print("Current movie index "+strIndex)
    r = requests.post(basePath+strIndex)
    print(r.status_code, r.reason)
    # sleepValue=random.randint(1, 3)
    # print("SleepedValue "+str(sleepValue))
    # time.sleep(sleepValue)
    # print("After SleepedValue " + str(sleepValue))
print("Koniec")