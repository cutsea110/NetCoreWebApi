ASP.NET Core 2.2 Jwt Authentication sample
===========================================

ref.) https://tnakamura.hatenablog.com/entry/2017/08/31/use-jwt-bearer-authentication-on-aspnetcore2

Running
==============

1. start git bash.
2. change directory to this project.
3. run
```shell
$ dotnet.exe run                                                                                                                                                
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]                                                                                        
      User profile is available. Using 'C:\Users\cut-sea\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
Hosting environment: Development                                                                                                                                
Content root path: C:\Users\cut-sea\source\repos\NetCoreWebApi                                                                                                  
Now listening on: http://localhost:5000                                                                                                                         
Application started. Press Ctrl+C to shut down.                                                                                                                 
```
4. open the other git bash command prompt and then make request like this.(401)
```shell
$ curl -v --insecure  http://localhost:5000/api/me
  % Total    % Received % Xferd  Average Speed   Time    Time     Time  Current
                                 Dload  Upload   Total   Spent    Left  Speed
  0     0    0     0    0     0      0      0 --:--:-- --:--:-- --:--:--     0*   Trying ::1:5000...
* TCP_NODELAY set
* Connected to localhost (::1) port 5000 (#0)
> GET /api/me HTTP/1.1
> Host: localhost:5000
> User-Agent: curl/7.65.1
> Accept: */*
>
* Mark bundle as not supporting multiuse
< HTTP/1.1 401 Unauthorized
< Date: Thu, 01 Aug 2019 15:03:50 GMT
< Server: Kestrel
< Content-Length: 0
< WWW-Authenticate: Bearer
<
  0     0    0     0    0     0      0      0 --:--:-- --:--:-- --:--:--     0
```
5. and then do this like below.
```shell
$ curl -v --insecure -X POST -H 'Content-Type: application/json' --data '{"userName":"cutsea110","password":"p@ssw0rd"}'  http://localhost:5000/api/token                                                                             
Note: Unnecessary use of -X or --request, POST is already inferred.                                                                                                                                                                   
  % Total    % Received % Xferd  Average Speed   Time    Time     Time  Current                                                                                                                                                       
                                 Dload  Upload   Total   Spent    Left  Speed                                                                                                                                                         
  0     0    0     0    0     0      0      0 --:--:-- --:--:-- --:--:--     0*   Trying ::1:5000...                                                                                                                                  
* TCP_NODELAY set                                                                                                                                                                                                                     
* Connected to localhost (::1) port 5000 (#0)                                                                                                                                                                                         
> POST /api/token HTTP/1.1                                                                                                                                                                                                            
> Host: localhost:5000                                                                                                                                                                                                                
> User-Agent: curl/7.65.1                                                                                                                                                                                                             
> Accept: */*                                                                                                                                                                                                                         
> Content-Type: application/json                                                                                                                                                                                                      
> Content-Length: 46                                                                                                                                                                                                                  
>                                                                                                                                                                                                                                     
} [46 bytes data]                                                                                                                                                                                                                     
* upload completely sent off: 46 out of 46 bytes                                                                                                                                                                                      
* Mark bundle as not supporting multiuse                                                                                                                                                                                              
< HTTP/1.1 200 OK                                                                                                                                                                                                                     
< Date: Thu, 01 Aug 2019 15:07:00 GMT                                                                                                                                                                                                 
< Content-Type: application/json; charset=utf-8                                                                                                                                                                                       
< Server: Kestrel                                                                                                                                                                                                                     
< Transfer-Encoding: chunked                                                                                                                                                                                                          
<                                                                                                                                                                                                                                     
{ [554 bytes data]                                                                                                                                                                                                                    
100   593    0   547  100    46   5362    450 --:--:-- --:--:-- --:--:--  5813{"token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIyZDFkMGY3ZC0wOGRmLTQ3YWQtOTdhMy0yZDdlNDM2NTdkZGYiLCJzdWIiOiJjdXRzZWExMTAiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIyZDFkMGY3ZC0wOGRmLTQ3YWQtOTdhMy0yZDdlNDM2NTdkZGYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiY3V0c2VhMTEwIiwiZXhwIjoxNTY1Mjc2ODIxLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.CdTDlZFGfOYKCzEQ8ogSN9BwPgLFSYleZScsDs65GiI","expiration":"2019-08-08T15:07:01Z"}                                                                 
* Connection #0 to host localhost left intact                                                                                                                                                                                         
                                                                                                                                                                                                                                      
```
6. and then check this.
```shell
TODO: this is failed.
```

