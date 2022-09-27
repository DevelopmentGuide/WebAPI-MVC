# WebAPI-MVC

### KeyWords

1. ContactUs
    - Date
    - Name
    - Email
    - Message

2. Order 
    - MemberId
    - ProductName
    - RequiredDate
    - Quantities

3. SERVER_NAME

4. DATABASE_NAME

5. Template


### Structure

```
backend
        Controllers
                ContactUs
                Order
                Users
                    Administration
                    Authentication
        Entities
                DataBaseContext 
        Models
                ContactUs
                Order
                Users
                    Roles
                    Users
        Properties
                HTTP
                SQL

frontend
        Controllers
                ContactUs
                Miscellaneous
                    Error
                    Home
                    Messages
                Order
                Users
                    NewUser
                    Users
        Models
                ContactUs
                Order
                Users
                    JWT
                    Users
        Views
                ContactUs
                    ContactUs
                    Index
                Error
                    Error401
                    Error404
                    Load1
                    Load2
                    Load3
                    Load4
                    NotLoggedIn
                    Unexpected
                Messages
                    Create
                    Delete
                    Edit
                    Order
                NewUser
                    Create
                    Delete
                    DeleteByMail
                    Edit
                    EditByMail
                    Users
                Order
                    Index
                    MyOrder
                    Order
                Shared
                    _Layout
                    Error401
                    Error404
                User
                    ControlPannel
                    HomePage
                    Login
                    MyAccount
```