# PatientsInfo.ConsoleEditor
Предметна область "Облік пацієнтів" в режимі консолі.

See: 

## Сутності
Дана область містить наступні сутності:
- Пацієнт;
- Хвороба;
- Особа.

## Інтерфейс
Існують два інтерфейса:
- В режимі "введення числа":
[![](https://github.com/YarikVor/PatientsInfo.ConsoleEditor/blob/main/Img/r0.png?raw=true)](https://github.com/YarikVor/PatientsInfo.ConsoleEditor/blob/main/Img/r0.png?raw=true)

- В режимі "Консолі".
[![](https://github.com/YarikVor/PatientsInfo.ConsoleEditor/blob/main/Img/r1.png?raw=true)](https://github.com/YarikVor/PatientsInfo.ConsoleEditor/blob/main/Img/r1.png?raw=true)

## Команди
Існують наступні команди:

|Команда|   |№|Опис|
| ------------ | ------------ | ------------ | ------------ |
|quit|   |0|Вихід з консолі|
|switch|   |1|Змінити режим інтерфейса|
|crttd|   |2|Створити тестові дані|
|add|[percon]|3|Додати особу|
|   |[pacient]|4|Додати пацієнта|
|   |[disease]|5|Додати хворобу|
|rem|[percon]|6|Видалити особу|
|   |[pacient]|7|Видалити пацієнта|
|   |[disease]|8|Видалити хворобу|
|table|[clear]|9|Очистити таблицю|
||[patient]|-|Вивести таблицю про пацієнтів|
||[percon]|-|Вивести таблицю про осіб|
||[disease]|-|Вивести таблицю про хвороб|

## Формат збереження данних
Існують наступні типи даних:
- XML;
- Binary.

