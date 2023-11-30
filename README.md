# ArktikaTestBackend

## Описание
Задание для СПО Арктика

## Использование

### Запросы материалов

**Запрос на получение всех материалов**
```bash
curl http://localhost:port/materials
```

Ответ
```json
[
  {"name":"металл","price":41.73,"sellerId":1,"id":1},
  {"name":"дерево","price":61.50,"sellerId":1,"id":2},
  {"name":"стекло","price":42.90,"sellerId":1,"id":3}
]
```

**Запрос на получение одного из материалов**
```bash
curl http://localhost:port/materials/1
```

Ответ
```json
{"name":"металл","price":41.73,"sellerId":1,"id":1}
```

**Запрос на добавление нового материала**
```bash
curl -d '{"name":"золото","price":99.73,"sellerId":1}' -H "Content-Type: application/json" -X POST http://localhost:port/materials
```

Ответ
```json
{"name":"золото","price":99.73,"sellerId":1,"id":4}
```

**Запрос на изменение материала**
```bash
curl -d '{"name":"золото","price":99.73,"sellerId":1}' -H "Content-Type: application/json" -X PUT http://localhost:port/materials/1
```

Ответ
```json
{"name":"золото","price":99.73,"sellerId":1,"id":1}
```

**Запрос на удаление материала**
```bash
curl -X DELETE http://localhost:port/materials/1
```

Ответ
```json
{"name":"металл","price":41.73,"sellerId":1,"id":1}
```

### Запросы продавцов

**Запрос на получение всех продавцов**
```bash
curl http://localhost:port/sellers
```

Ответ
```json
[
  {"name":"Сергей","id":1},
  {"name":"Андрей","id":2}
]
```
**Запрос на получение одного из продавцов**
```bash
curl http://localhost:port/sellers/1
```

Ответ
```json
{"name":"Сергей","id":1}
```

**Запрос на добавление нового продавца**
```bash
curl -d '{"name":"Александр"}' -H "Content-Type: application/json" -X POST http://localhost:port/sellers
```

Ответ
```json
{"name":"Александр","id":3}
```

**Запрос на изменение продавца**
```bash
curl -d '{"name":"Александр"}' -H "Content-Type: application/json" -X PUT http://localhost:port/sellers/1
```

Ответ
```json
{"name":"Александр","id":1}
```

**Запрос на удаление продавца**
```bash
curl -X DELETE http://localhost:port/sellers/1
```

Ответ
```json
{"name":"Сергей","id":1}
```

### Требования к запросам

Требования к материалам:
1. Имя материала не должно быть пустым
2. Цена материала должна быть больше 0
3. Продавец с указанным id должен существовать

Требования к продавцам:
1. Имя продавца не должно быть пустым
