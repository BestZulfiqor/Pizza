# ER-диаграмма базы данных пиццерии

```mermaid
erDiagram
    USERS ||--o{ ORDERS : "размещает"
    ORDERS ||--|{ ORDER_ITEMS : "содержит"
    ORDER_ITEMS }|--|| DISHES : "включает"
    DISHES }|--|{ INGREDIENTS : "состоит из"
    DISH_INGREDIENTS }|--|| DISHES : "принадлежит"
    DISH_INGREDIENTS }|--|| INGREDIENTS : "использует"

    USERS {
        int id PK "Первичный ключ"
        string username "Имя пользователя"
        string password "Пароль"
        string email "Электронная почта"
        string role "Роль (admin/user/premium)"
        int points "Бонусные баллы"
        datetime created_at "Дата создания"
    }
    
    ORDERS {
        int id PK "Первичный ключ"
        int user_id FK "Внешний ключ на Users"
        decimal total_price "Общая сумма"
        string status "Статус заказа"
        datetime created_at "Дата создания"
        datetime delivered_at "Дата доставки"
    }
    
    ORDER_ITEMS {
        int id PK "Первичный ключ"
        int order_id FK "Внешний ключ на Orders"
        int dish_id FK "Внешний ключ на Dishes"
        int quantity "Количество"
        decimal price "Цена за единицу"
    }
    
    DISHES {
        int id PK "Первичный ключ"
        string name "Название блюда"
        string description "Описание"
        decimal price "Цена"
        string category "Категория"
        datetime created_at "Дата добавления"
    }
    
    DISH_INGREDIENTS {
        int dish_id FK "Внешний ключ на Dishes"
        int ingredient_id FK "Внешний ключ на Ingredients"
    }
    
    INGREDIENTS {
        int id PK "Первичный ключ"
        string name "Название ингредиента"
        int stock "Количество на складе"
        decimal price "Цена за единицу"
    }
```

## Описание связей

1. **USERS - ORDERS** (1:M)
   - Один пользователь может иметь много заказов
   - Каждый заказ принадлежит только одному пользователю

2. **ORDERS - ORDER_ITEMS** (1:M)
   - Один заказ может содержать много позиций
   - Каждая позиция принадлежит только одному заказу

3. **ORDER_ITEMS - DISHES** (M:1)
   - Одно блюдо может быть в разных позициях заказов
   - Каждая позиция заказа относится к одному блюду

4. **DISHES - INGREDIENTS** (M:M)
   - Одно блюдо может содержать много ингредиентов
   - Один ингредиент может использоваться в разных блюдах
   - Связь реализована через промежуточную таблицу DISH_INGREDIENTS

## Особенности таблиц

### USERS
- Хранит информацию о пользователях
- Поддерживает разные роли (admin/user/premium)
- Отслеживает бонусные баллы для системы скидок

### ORDERS
- Отслеживает все заказы
- Хранит статус и время доставки
- Содержит общую сумму заказа

### ORDER_ITEMS
- Детализация заказов
- Хранит количество и цену каждой позиции
- Позволяет отслеживать историю цен

### DISHES
- Каталог доступных блюд
- Категоризация блюд
- Описание и текущие цены

### INGREDIENTS
- Управление запасами ингредиентов
- Отслеживание стоимости ингредиентов
- Контроль наличия на складе
