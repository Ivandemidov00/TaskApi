# TaskApi

API реализованный при помощи архитектурного подхода CQRS,  
на платформе .NET Core СУБД SQLite, фронтенд Javascript


![Peek 2021-09-07 11-49](https://user-images.githubusercontent.com/23259611/132299064-5a899d2d-5b59-4261-892b-c7b6da63c96c.gif)

## Сущности

* Tasks

| Имя           | Тип                | 
| ------------- |:------------------:| 
| ID            | INTEGER            | 
| Name          | TEXT               |  
| Description   | TEXT               |
| StatusId      | INTEGER            |    

* Statuses

| Имя           | Тип                | 
| ------------- |:------------------:| 
| Status_ID     | INTEGER            | 
| Status_Name   | TEXT               |  
  


## Методы

**GetAll**  
http://localhost:5000/api/task/getall
```javascript
{
    "tasks": [
        {
            "id": 44,
            "name": "five",
            "description": "two",
            "status": "В работе"
        },
        {
            "id": 45,
            "name": "seven",
            "description": "two",
            "status": "В работе"
        }
    ]
}
```
**Get**   
http://localhost:5000/api/task/get/{id}
```javascript
{
    "id": 44,
    "name": "two",
    "description": "two",
    "status": "В работе"
}
```
**Create**   
http://localhost:5000/api/task/create  
Body
```javascript

{
    "Name":"seven",
    "Description":"two",
    "Status":2
}
```
**Update**   
http://localhost:5000/api/task/update  
Body
```javascript

{
    "id":44,
    "Name":"3331w",
    "Description":"111",
    "StatusId":2
    
}
```
**Delete**   
http://localhost:5000/api/task/delete/{id}
