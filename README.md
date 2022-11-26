# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #2 выполнил(а):
- Балаба Софья Николаевна
- РИ210940
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

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

![1](https://user-images.githubusercontent.com/102922461/204083902-fdb50005-dbe6-4c39-a719-4f395d3d9e32.jpg)

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

![2](https://user-images.githubusercontent.com/102922461/204083903-97a81cfa-e756-4736-9e8a-9c09026b7d8f.jpg)

- Создать новый проект на Unity, который будет получать данные из google-таблицы, в которую были записаны данные в предыдущем пункте.

![3](https://user-images.githubusercontent.com/102922461/204083898-f0c90f87-3d59-4258-b30b-611816b7b5cb.jpg)

- Написать функционал на Unity, в котором будет воспризводиться аудио-файл в зависимости от значения данных из таблицы.

![6](https://user-images.githubusercontent.com/102922461/204083901-11e06acd-823d-4fe7-ba1c-f55a07cbee27.jpg)

![5](https://user-images.githubusercontent.com/102922461/204083899-587cd426-2064-4ab6-a88f-9252edde36b3.jpg)

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/573f2d5c8e3329ce7ce30f834763be05ddbe004e/NewBehaviourScript.cs


## Задание 2
### Реализовать запись в Google-таблицу набора данных, полученных с помощью линейной регрессии из лабораторной работы №1.

Для начала нужно проделать всю ту же самую работу с Google Console:
Создать лист в google-таблицах по аналогии из первого задания. Затем нужно переделать код линейной регрессии из лабораторной работы №1 также по аналогии с кодом из задания 1. В прошлой ЛР выяснилось, что чем больше паремтр Lr тем больше разница между потерями, этим мы и воспользуемся.
Будем выгружать разницу между текущей и предыдущей величиной loss. Рассмотрим 10 итераций.
Новый код представлен ниже:

```py
import numpy as np
import gspread

x = [3, 21, 22, 34, 54, 34, 55, 67, 89, 99]
x = np.array(x)
y = [2, 22, 24, 65, 79, 82, 55, 130, 150, 199]
y = np.array(y)

def model(a, b, x):
  return a*x + b

def loss_function(a, b, x, y):
  num = len(x)
  prediction = model(a, b, x)
  return (0.5 / num) * (np.square(prediction - y)).sum()

def optimize(a, b, x, y):
  num = len(x)
  prediction = model(a, b, x)
  da = (1.0 / num) * ((prediction - y) * x).sum()
  db = (1.0 / num) * ((prediction - y).sum())
  a = a - Lr * da
  b = b - Lr * db
  return a, b

def iterate(a, b, x, y, times):
  for i in range(times):
    a, b= optimize(a, b, x, y)
  return a, b

a = np.random.rand(1)
b = np.random.rand(1)
Lr = 0.0001

gc = gspread.service_account(filename='regression-364710-2384e60c3dac.json')
sh = gc.open("RegressionSheet")

prev_loss = 0

for i in range(10):
    a, b = iterate(a, b, x, y, i + 1)

    prediction = model(a, b, x)
    temp_loss = loss_function(a, b, x, y)

    diff_loss = abs(temp_loss - prev_loss)
    prev_loss = temp_loss

    sh.sheet1.update(('A' + str(i + 1)), str(i + 1))
    sh.sheet1.update(('B' + str(i + 1)), str(temp_loss))
    sh.sheet1.update(('C' + str(i + 1)), str(diff_loss))
```
Данные появились в google-таблице:
![194300336-fa7f1a7c-2ed4-4e9c-8e9e-f19786607896](https://user-images.githubusercontent.com/102922461/204083741-5ca0de1b-ac1f-4346-ad91-b3f04486bace.png)

## Задание 3
### Самостоятельно разработать сценарий воспроизведения звукового сопровождения в Unity в зависимости от изменения считанных данных в задании 2.

Сначала также нужно создать новый проект и подключить необходимые файлы. Затем нужно изменить данные воспроизведения аудио-файлов из 1 задания. Теперь если значение меньше 2, то выходит хорошая аудио-запись, больше 2 и меньше 300 - нормальная, больше 300 - плохая.
Новый код с измененными границами для произведения айдио-файлов:

```py
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip goodSpeak;
    public AudioClip normalSpeak;
    public AudioClip badSpeak;
    private AudioSource selectAudio;
    private Dictionary<string,float> dataSet = new Dictionary<string, float>();
    private bool statusStart = false;
    private int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoogleSheets());
    }

    // Update is called once per frame
    void Update()
    {
        if (dataSet["Mon_" + i.ToString()] <= 2 & statusStart == false & i != dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioGood());
            Debug.Log(dataSet["Mon_" + i.ToString()]);
        }

        if (dataSet["Mon_" + i.ToString()] > 2 & dataSet["Mon_" + i.ToString()] < 300 & statusStart == false & i != dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioNormal());
            Debug.Log(dataSet["Mon_" + i.ToString()]);
        }

        if (dataSet["Mon_" + i.ToString()] >= 300 & statusStart == false & i != dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioBad());
            Debug.Log(dataSet["Mon_" + i.ToString()]);
        }
    }

    IEnumerator GoogleSheets()
    {
        UnityWebRequest curentResp = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1lPJwP6lLr1_dAXH6hV6QgOX_BUsz2KZUSTDXSi-Mfbw/values/Лист1?key=AIzaSyD-bRuAcWrSgZeShsllpOnLy_WX2Tkzjys");
        yield return curentResp.SendWebRequest();
        string rawResp = curentResp.downloadHandler.text;
        var rawJson = JSON.Parse(rawResp);
        foreach (var itemRawJson in rawJson["values"])
        {
            var parseJson = JSON.Parse(itemRawJson.ToString());
            var selectRow = parseJson[0].AsStringList;
            dataSet.Add(("Mon_" + selectRow[0]), float.Parse(selectRow[2]));
        }
    }

    IEnumerator PlaySelectAudioGood()
    {
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
        selectAudio.clip = goodSpeak;
        selectAudio.Play();
        yield return new WaitForSeconds(3);
        statusStart = false;
        i++;
    }
    IEnumerator PlaySelectAudioNormal()
    {
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
        selectAudio.clip = normalSpeak;
        selectAudio.Play();
        yield return new WaitForSeconds(3);
        statusStart = false;
        i++;
    }
    IEnumerator PlaySelectAudioBad()
    {
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
        selectAudio.clip = badSpeak;
        selectAudio.Play();
        yield return new WaitForSeconds(4);
        statusStart = false;
        i++;
    }
}
```

Вывод в консоли:
![194300819-79018e1f-6e47-4d9f-a038-d7e6340c97ab](https://user-images.githubusercontent.com/102922461/204083740-f8dd9569-a22e-424f-bf16-13ac828c1795.png)


## Выводы
В ходе лабораторной работы №2 я освоила связку между Python - Google Sheets - Unity. Научилась делать вывод из PyCharm'a в google-таблицы, а уже из них - в Unity. Опробовала сделать это с несколькими проектами, например, с линейной регрессией из прошлой лабораторной работы.

| Plugin | README |
| ------ | ------ |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| Google.colab | [plugins/googlecolab/README.md][PlGc] |
| Google Sheets | [plugins/googlesheets/README.md][PlGS] |
| Google Console | [plugins/googleconsole/README.md][PlGC] |
| PyCharm | [plugins/pycharm/README.md][PlPC] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**

