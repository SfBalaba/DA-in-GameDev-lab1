# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #2 выполнил(а):
- Балаба Софья Николаевна
- РИ210940
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | # | 20 |
| Задание 3 | # | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
познакомиться с программными средствами для организции передачи данных между инструментами google, Python и Unity

## Задание 1
### Реализовать совместную работу и передачу данных в связке Python - Google-Sheets – Unity. 
Ход работы:
- В облачном сервисе google console подключить API для работы с google sheets и google drive.

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/dd40a84f090253ef931896d3b70cf8512a71d8c0/1.jpg

- Реализовать запись данных из скрипта на python в google-таблицу. Данные описывают изменение темпа инфляции на протяжении 11 отсчётных периодов, с учётом стоимости игрового объекта в каждый период.

```py

import random

import gspread
import numpy as np
gs = gspread.service_account(filename = 'unitydatascience-2fec49160aca.json')
sh = gs.open('UnitySheets')
price = np.random.randint(2000, 10000, 11)
mon = list(range(1, 11))
i = 0
while i<= len(mon):
    i += 1
    if i == 0:
        continue
    else:
        tempInf = ((price[i-1]-price[i-2])/price[i-2])*100
        tempInf = str(tempInf)
        tempInf = tempInf.replace('.', ',')
        sh.sheet1.update(('A' + str(i)), str(i))
        sh.sheet1.update(('B' + str(i)), str(price[i-1]))
        sh.sheet1.update(('C' + str(i)), str(tempInf))
        print(tempInf)

```

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/dd40a84f090253ef931896d3b70cf8512a71d8c0/2.jpg

- Создать новый проект на Unity, который будет получать данные из google-таблицы, в которую были записаны данные в предыдущем пункте.

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/dd40a84f090253ef931896d3b70cf8512a71d8c0/3.jpg

- Написать функционал на Unity, в котором будет воспризводиться аудио-файл в зависимости от значения данных из таблицы.

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/573f2d5c8e3329ce7ce30f834763be05ddbe004e/6.jpg

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/573f2d5c8e3329ce7ce30f834763be05ddbe004e/5.jpg

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/573f2d5c8e3329ce7ce30f834763be05ddbe004e/NewBehaviourScript.cs


## Задание 2
### Реализовать запись в Google-таблицу набора данных, полученных с помощью линейной регрессии из лабораторной работы № 1. 
Ход работы:
 - 


## Задание 3
### Самостоятельно разработать сценарий воспроизведения звукового сопровождения в Unity в зависимости от изменения считанных данных в задании 2.



## Выводы

В ходе проделанной мною работы я познакомилась с программными средствами для организции передачи данных между инструментами google, Python и Unity. В облачном сервисе google console подключила API для работы с google sheets и google drive, реализовала запись данных из скрипта на python в google-таблицу, создала новый проект на Unity, а также написала функционал на Unity, в котором воспризводёлся аудио-файл в зависимости от значения данных из таблицы.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
