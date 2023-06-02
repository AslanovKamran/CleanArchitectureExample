# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id":"0000000000-0000-0000-0000-0000000000",
    "name":"Yummy menu",
    "descritpion":"A menu with some yummy food",
    "averageRating":4.5,
    "sections":[
        {
            "id":"0000000000-0000-0000-0000-0000000000",
            "name":"Appetizers",
            "descritpion":"Starters",
            "items":[
                {
                    "id":"0000000000-0000-0000-0000-0000000000",
                    "name":"Fried Pickles",
                    "description":"Deep fried pickles",
                    "price":5.99
                }
            ]
        }
    ],
    "createdDateTime":"2020-01-01",
    "updatedDateTime":"2020-01-01",
    "hostId":"0000000000-0000-0000-0000-0000000000",
    "dinnerIds":["0000000000-0000-0000-0000-0000000000"],
    "menuReviesIds":["0000000000-0000-0000-0000-0000000000"],
}
```