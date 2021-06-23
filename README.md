# YaelTestAspNetCore
# The project must be opened via VS
file-> open project
You can test the functions of the API with Postman
Open Postman application
Disable SSL certificate verification
url:
https: // localhost: 44330 / api / Calculators /

Post
Post-> Body-> raw-> Json
Send this object in Boy
  {
     "num1": "12",
     "_operator": "+",
     "num2": "13",
     "result": "0"
   }
   
Get
Get -> by url

Get by id
change the url:
https: // localhost: 44330 / api / Calculators / 1

Upate
Put-> Body-> raw-> Json
Send this object in Boy
  {
     "num1": "15",
     "_operator": "+",
     "num2": "13",
     "result": "0"
   }
and change the url:
https: // localhost: 44330 / api / Calculators / 1
