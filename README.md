# WebAPI-MVC

### KeyWords

1. ContactUs
    - ContactUsController 
    - msg_context 
    - ContactMsg 
    
        - Date
        - Name
        - Email
        - Message

2. Order 
    - OrderController 
    - order_context
    - u_o_Joint
    - MyOrder

    - UserOrder

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
                    ContactUsController
                Order
                    OrderController
                Users
                    AdministrationController
                    AuthenticationController
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
                    ContactUsController
                Miscellaneous
                    ErrorController
                    HomeController
                    MessagesController
                Order
                    OrderController
                Users
                    NewUserController
                    UsersController
        Models
                ContactUs
                Order
                    Order
                    UserOrder
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