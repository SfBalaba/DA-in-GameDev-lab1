# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #3 выполнил(а):
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
познакомиться с программными средствами для создания системы машинного обучения и ее интеграции в Unity.

## Задание 1
### Реализовать систему машинного обучения в связке Python - Google-Sheets – Unity.
Ход работы:
- Для Python в отчёте привести скриншоты с демонстрацией сохранения документа google.colab на свой диск с запуском программы, выводящей сообщение Hello World.

-	Создала новый пустой 3D проект на Unity.

![1](https://user-images.githubusercontent.com/102922461/200721900-bc47eef4-0a3e-469d-933e-363d8d9e59d8.jpg)


- Добавила .json – файлы в Pacage Manager

![2](https://user-images.githubusercontent.com/102922461/200721902-ca642622-7316-4b08-be52-b61784b07d5c.jpg)
![Скриншот 08-11-2022 201317](https://user-images.githubusercontent.com/102922461/200602145-d21c9d0a-2602-4207-a565-19ff7c841115.jpg)

- Создала виртуальную среду, установила необходимые пакеты

![Скриншот 07-11-2022 220648](https://user-images.githubusercontent.com/102922461/200602868-538de42c-079b-4b03-a279-97e35884edd9.jpg)
![Скриншот 07-11-2022 220705](https://user-images.githubusercontent.com/102922461/200602880-814353af-8704-450b-9be9-422e71b4ec70.jpg)

- Создала сцену, подключила скрипт RollerAgent, добавила необходимые компоненты

![Скриншот 07-11-2022 221750](https://user-images.githubusercontent.com/102922461/200603658-e8680771-a3ff-4e96-95dc-fc79e8d141ce.jpg)

- В корень проекта дабавила конфигурационный файл

![Скриншот 08-11-2022 202037](https://user-images.githubusercontent.com/102922461/200604130-7d0bfbac-6ea5-4e35-a17f-2b8b9326b272.jpg)

- Запустила работу ml-agent

![Скриншот 07-11-2022 222736](https://user-images.githubusercontent.com/102922461/200605178-dae2b8fe-26cf-43ae-b049-ed81f6e6a81d.jpg)

-	Сделайте 3, 9, 27 копий модели «Плоскость-Сфера-Куб», запустите симуляцию сцены и наблюдайте за результатом обучения модели.

![8 2](https://user-images.githubusercontent.com/102922461/200815174-9df99dd5-84dd-4cd1-8c94-26000e873c4b.gif)
![8 1](https://user-images.githubusercontent.com/102922461/200815171-f3c5f68e-c181-453b-be2e-aad2ae6e4828.gif)
![9](https://user-images.githubusercontent.com/102922461/200815180-b7fb431d-7c00-4475-8328-7dd47cea70be.gif)

- Проверяем работу модели

![Видео 07-11-2022 21_16_39](https://user-images.githubusercontent.com/102922461/200816030-3801c9e3-c763-45af-9781-11585c72a563.gif)

- Вывод: Модель быстрее обучается когда тренируются одновременно несколько экзамепляров. Обученная модель ищет оптимальный путь к target, преодалевая минимальное расстояние,  что свидетельствует о том, что модель обучилась достаточно хорошо.

## Задание 2
### Подробно опишите каждую строку файла конфигурации нейронной сети, доступного в папке с файлами проекта по ссылке. 

Ход работы:
 - Самостоятельно найдите информацию о компонентах Decision Requester, Behavior Parameters, добавленных на сфере.

 ```
 behaviors:
  RollerBall:
    trainer_type: ppo #тип нейросети алгоритм обучения с подкреплением
    hyperparameters:
      batch_size: 10 #Количество опытов в каждой итерации градиентного спуска
      buffer_size: 100 #количество опыта, который необходимо собрать перед обновлением модели 
      learning_rate: 3.0e-4 # скорость обучения
      beta: 5.0e-4 #доля случайных действий
      epsilon: 0.2 # порог расхождения между старой и новой политиками при обновлении градиентного спуска
      lambd: 0.99 #насколько агент уверен в оценке 
      num_epoch: 3 #количество эпох
      learning_rate_schedule: linear #Определяет, как скорость обучения изменяется с течением времени
    network_settings: #настройки модели
      normalize: false #применяется ли нормализация к входным данным 
      hidden_units: 128 #используется для генерации весов
      num_layers: 2 #число слоёв
    reward_signals:  #настройки вознаграждения
      extrinsic:
        gamma: 0.99 #агент должен действовать в настоящем, чтобы подготовиться к вознаграждению в отдаленном будущем
        strength: 1.0 #фактор для будущих вознаграждений. Фактор, на который можно умножить вознаграждение, данное окружающей средой
    max_steps: 500000 #Общее количество собранных наблюдений и предпринятых действий
    time_horizon: 64 #Количество шагов взаимодействия, которые необходимо собрать для каждого агента перед добавлением его в буфер взаимодействия
    summary_freq: 10000 #Количество опыта, который необходимо собрать перед созданием и отображением статистики обучения.
```

 Цикл наблюдения-решения-действия-вознаграждения повторяется каждый раз, когда агент запрашивает решение. Чтобы агент запрашивал решения самостоятельно за регулярной интервал нужно добавить компонент в Объект GameObject агента. Agent.RequestDecision()Decision RequesterAgent.RequestDecision()

 Класс Behavior Parameters абстрагирует логику принятия решений от самого Агента чтобы можно было использовать одну и ту же модель в нескольких агентах. Если есть файл, то для принятия решений будет использоватся нейронная сеть.


## Задание 3
### Доработайте сцену и обучите ML-Agent таким образом, чтобы шар перемещался между двумя кубами разного цвета.

Ход работы:
- Создадим новую сцену, добавим ещё один куб
![10](https://user-images.githubusercontent.com/102922461/200802337-6f4d5e7a-566f-416e-808b-1f6fbf0d3506.jpg)
- Добавм скрипт

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RollerAgent : Agent
{
    Rigidbody rBody;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    public GameObject Target_1;
    public GameObject Target_2;
    private bool firstTargetCollected;
    private bool secondTargetCollected;
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 0)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(0, 0.5f, 0);
        }
        Target_1.transform.localPosition = new Vector3(Random.value * 8-4, 0.5f, Random.value * 8-4);
        Target_2.transform.localPosition = new Vector3(Random.value * 8-4, 0.5f, Random.value * 8-4);
        Target_1.SetActive(true);
        Target_2.SetActive(true);
        firstTargetCollected = false;
        secondTargetCollected = false;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Target_1.transform.localPosition);
        sensor.AddObservation(Target_2.transform.localPosition);
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(firstTargetCollected);
        sensor.AddObservation(secondTargetCollected);
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }
    public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        rBody.AddForce(controlSignal * forceMultiplier);
        
        float distanceToTarget_1 = Vector3.Distance(this.transform.localPosition, Target_1.transform.localPosition);
        float distanceToTarget_2 = Vector3.Distance(this.transform.localPosition, Target_2.transform.localPosition);
        if (!firstTargetCollected & distanceToTarget_1 < 1.42f)
        {
            firstTargetCollected = true;
            Target_1.SetActive(false);
        }
        if (!secondTargetCollected & distanceToTarget_2 < 1.42f)
        {
            secondTargetCollected = true;
            Target_2.SetActive(false);
        }
        if(firstTargetCollected & secondTargetCollected)
        {
            SetReward(1.0f);
            EndEpisode();
        }
        else if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }
}
```
- Результат после обучения на 3, 9 и 27 экзамплярах
![11](https://user-images.githubusercontent.com/102922461/200803712-061cbb08-3a67-4235-aafa-0ac9cc47a6a1.gif)

## Выводы
В ходе лабораторной работы создала простую системы машинного обучения в Unity. Познакомилась с технологией Unity - ml-agents и её возможностями на примере обучения с подкреплением. Ознакомилась с конфигурациями нейронной сети. В ходе работы также выяснила, что при увеличении количества копий модели - она обучается быстрее.

Игровой баланс это попытка сделать игру цельной и играбельной. Сделать игру сбалансированной по сложности и масимально приносящей удовольствие. Баланс определяется соотношением сложности взаимодействия между объектами(компонентами) игры. Достигнуть баланса можно посредством модификации и настройки параметров,  разнообразием персонажей, команд, тактик игры и т.п. Баланс должен быть во времени игры, в её сложности, в сюжете (он должен быть разнообразным). Машинное обучение применяется для нахождения игрового баланса. Методы машинного обучения позволяют более точно определить игровые механики, которые справятся с задачей нахождения игрового баланса. Например, подстраивать характеристики мира, чтобы персонажу было интересно развиваться, усложнять миссии, если персонаж имеет высокие характеристики, балансировка оружия, балансировка силы(выносливость, дамаг, хилл, интеллект).

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
