#MyHistory Api

- [MyHistory API](#myhistoy-api)
    - [Auth](#auth)
    - [Register](#register)
        - [Register Request](#register-request)
        - [Register Response](#register-response)
    - [Login](#login)
        - [Login Request](#login-request)
        - [Login Response](#login-response)



## Auth

### Register
```js
POST {{localhost}}/auth/register
```

#### Register Request
```json
{
    "FirstName":"Test First Name",
    "LastName":"Test Last Name",
    "Email":"test@email.com",
    "Password":"SuperSecurePassword123"
}

```
#### Register Response

``` js
200 OK
```

```JSON
{
    "Id": 2,
    "FirstName":"Test First Name",
    "LastName":"Test Last Name",
    "Email":"test@email.com",
    "Token":"adnaspdonanp12p312mpmasdapsdn"    
}
```
#### Login Request
```JSON
{
    "Email":"test@email.com",
    "Password":"SuperSecurePassword123"
}
```


#### Login Repose
```JS
200 OK
```

```json
{
    "Id": 12,
    "FirstName":"Test First Name",
    "LastName":"Test Last Name",
    "Email":"test@email.com",
    "Token":"adnaspdonanp12p312mpmasdapsdn"
}
```