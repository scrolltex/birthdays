# BirthDayS

Программа BirthDayS предназначена для напоминания о днях рождения. 
При запуске она сравнивает текущую дату с данными в текстовом файле и выводит поздравление или напоминание, если день рожденья завтра. Учитываются выходные дни – напоминания выводятся заранее.
Файлы программы должны находиться в одном каталоге. Местонахождение файла с данными можно указать при запуске. 
Предусмотрена возможность запуска программы один раз в день (например, в скриптах регистрации).
Файл с данными о днях рожденья можно создать в любом текстовом редакторе. Кодировка – DOS (CP866), или любая другая.
Мелодии для поздравления и напоминания размещены во внешних файлах, что позволяет легко заменить их другими.
В набор также входит утилита для управления автозапуском программы.
Программа реализована на C# и .NET Framework 4.

### Системные требования:
+ .NET Framework не ниже 4 версии.
+ Windows XP и выше

В архиве:

+ BirthDayS.exe – исполняемый модуль программы
+ BDTools.exe – утилита управления автозапуском
+ Birthday1.wav - мелодия для поздравления
+ Birthday2.wav – мелодия для напоминания
+ BIRTH.DAY – пример файла данных о днях рожденья

### Установка:
Программа не требует установки. Просто разархивируйте файлы в любой каталог.

### Запуск:
BirthDays \[-ls] \[-enc кодировка] \[-cf путь_к_файлу]

+ -ls – активировать проверку на последний запуск
+ -enc – кодировка файла
+ -cf {путь_к_файлу} – местонахождение файла базы данных, если он находится не вместе с программой.

### Горячие клавиши

Key | Description
--- | ---
Space  | пропуск одного сообщения
ESC | немедленный выход из программы
F1  | отобразить окно «О программе»

# BDTools
Утилита для настройки автозапуска

:copyright: Данил "[scrolltex](http://www.scrolltex.ru)" Калашников
