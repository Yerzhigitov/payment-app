 PaymentApp

Full-Stack тестовое приложение для приема платежных данных.

Проект реализует простой сервис для создания платежей, просмотра истории операций и агрегированной статистики.

---



Backend:

- ASP.NET Core (.NET 8 / .NET 10)
- Entity Framework Core
- SQLite
- REST API
- Swagger

Frontend:

- ASP.NET Core MVC
- Bootstrap
- Razor Pages

---



 Создание платежа

Форма содержит поля:

- Wallet Number
- Account / UserId
- Email
- Phone
- Amount
- Currency
- Comment

Реализована:

- клиентская валидация
- серверная валидация
- сохранение в базу данных

---

## История платежей

Отображается таблица со следующими данными:

- дата создания
- аккаунт
- email
- сумма
- валюта
- статус
- комментарий

---

 Статистика платежей

Отдельная страница со статистикой:

- общая сумма платежей
- количество платежей
- агрегация по дням

---



Backend защищен через **API Key middleware**.

Все запросы к API требуют заголовок:


X-API-KEY: super-secret-key


---



 Создание платежа


POST /api/payments


 Получение списка платежей


GET /api/payments


 Получение статистики


GET /api/payments/stats


---


Используется:


SQLite + Entity Framework Core


Основная сущность:


Payment


Поля:


Id
WalletNumber
Account
Email
Phone
Amount
Currency
Comment
Status
CreatedAt


---

 Запуск проекта

 1. Клонировать репозиторий


git clone https://github.com/Yerzhigitov/payment-app.git


 2. Перейти в папку проекта


cd payment-app


 3. Установить зависимости


dotnet restore


 4. Создать базу данных


dotnet ef database update


 5. Запустить приложение


dotnet run


---



Главная страница:


http://localhost:5081


Swagger:


http://localhost:5081/swagger


---




Controllers
Services
Models
DTOs
Middleware
Data (DbContext)
Views


Используется:

- Dependency Injection
- async / await
- разделение слоев

---



Alexander Yerzhigitov

Full-Stack Developer
