# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #1 выполнил(а):
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
Ознакомиться с основными операторами зыка Python на примере реализации линейной регрессии.

## Задание 1
### Напсиать программы Hello World на Python и Unity.
Ход работы:
- Для Python в отчёте привести скриншоты с демонстрацией сохранения документа google.colab на свой диск с запуском программы, выводящей сообщение Hello World.

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/9c013154fbfb5653be6021356293010f4fafb45f/%D0%A1%D0%BA%D1%80%D0%B8%D0%BD%D1%88%D0%BE%D1%82%2020-09-2022%20100458.jpg
https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/9c013154fbfb5653be6021356293010f4fafb45f/%D0%A1%D0%BA%D1%80%D0%B8%D0%BD%D1%88%D0%BE%D1%82%2020-09-2022%20100516.jpg
Скриншот 20-09-2022 100458.jpg
Скриншот 20-09-2022 100516.jpg

- Для Unity в  отчёте привести чкриншоты вывода сообщения Hello World в консоль.

https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/9c013154fbfb5653be6021356293010f4fafb45f/%D0%A1%D0%BA%D1%80%D0%B8%D0%BD%D1%88%D0%BE%D1%82%2020-09-2022%20120107.jpg
Скриншот 20-09-2022 120107.jpg


## Задание 2
### В разделе "ход работы" пошагово выполнить каждый пункт  с описанием и примерами реализации задач по теме лабораторной работы.

Ход работы:
 - Произвести подготовку данных для работы с алгоритмом линейной регрессии. 10 видов данных были установлены случайным образом, и данные находились в линейной зависимости. Данные преобразуются в формат массива, чтобы их можно было вычислить напрямую при использовании умножения и сложения.

```py

In [ ]:
#Import the required modules, numpy for calculation, and Matplotlib for drawing
import numpy as np
import matplotlib.pyplot as plt
#This code is for jupyter Notebook only
%matplotlib inline

# define data, and change list to array
x = [3,21,22,34,54,34,55,67,89,99]
x = np.array(x)
y = [2,22,24,65,79,82,55,130,150,199]
y = np.array(y)

#Show the effect of a scatter plot
plt.scatter(x,y)

```

- Определите связанные функции. Функция модели: определяет модель линейной регрессии wx+b. Функция потерь: функция потерь среднеквадратичной ошибки. Функция оптимизации: метод градиентного спуска для нахождения частных производных w и b.

```py

In [ ]:

#The basic linear regression model is wx + b, and sinse this is a two-dementional space, the model is ax + b
def model(a, b, x):
  return a*x+b

#The most commonly used ioss function of linear regression model is the loss function of mean variance difference
def loss_function(a, b, x, y):
  num = len(x)
  prediction = model(a, b, x)
  return (0.5/num) * (np.square(prediction-y)).sum()

#The optimization function mainly USES partial derivatives to update two parameters a and b
def optimize(a, b, x, y):
  num = len(x)
  prediction = model(a,b,x)
  #Update the values of A and B by sinding the partial derivatives of the loss function on a and b
  da = (1.0/num) * ((prediction -y)*x).sum()
  db = (1.0/num) * ((prediction -y).sum())
  a = a-Lr*da
  b = b-Lr*db
  return a, b

  #iterated function, return a and b
def iterate(a,b,x,y,times):
  for i in range(times):
    a,b = optimize(a,b,x,y)
  return a, b

```
 
  - 3. Начать итерацию
  Шаг 1 Инициализация и модель итеративной оптимизации 
```py

In [ ]:
#Initialize parameters and display
a = np.random.rand(1)
print(a)
b = np.random.rand(1)
print(b)
Lr = 0.000001

#For thw first iteartion, thw parameter values, losses and visualization after the iteration are displayed
a,b = iterate(a,b,x,y,1)
prediction = model(a,b,x)
loss = loss_function(a,b,x,y)
print(a,b,loss)
plt.scatter(x,y)
plt.plot(x, prediction)

```
Шаг 2 На второй итерации отображаются значения параметров, значения потерь и эффекты визуализации после итрации
```py

In [ ]:

a,b = iterate(a,b,x,y,2)
prediction = model(a,b,x)
loss = loss_function(a,b,x,y)
print(a,b,loss)
plt.scatter(x,y)
plt.plot(x, prediction)

```

Шаг 3 Третья итерация показывает значения параметров, значения потерь и эффекты визуализации после итрации
```py

In [ ]:

a,b = iterate(a,b,x,y,3)
prediction = model(a,b,x)
loss = loss_function(a,b,x,y)
print(a,b,loss)
plt.scatter(x,y)
plt.plot(x, prediction)

```
Шаг 4 На четвёртой итерации отображаются значения параметров, значения потерь и эффекты визуализации после итрации
```py

In [ ]:

a,b = iterate(a,b,x,y,4)
prediction = model(a,b,x)
loss = loss_function(a,b,x,y)
print(a,b,loss)
plt.scatter(x,y)
plt.plot(x, prediction)

```

Шаг 5 Пятая итерация показывает значения параметров, значения потерь и эффекты визуализации после итрации
```py

In [ ]:

a,b = iterate(a,b,x,y,5)
prediction = model(a,b,x)
loss = loss_function(a,b,x,y)
print(a,b,loss)
plt.scatter(x,y)
plt.plot(x, prediction)

```
Шаг 6 10000-я итерация показывает значение параметра, значение потерь и эффект визуализации после итрации
```py

In [ ]:

a,b = iterate(a,b,x,y,10000)
prediction = model(a,b,x)
loss = loss_function(a,b,x,y)
print(a,b,loss)
plt.scatter(x,y)
plt.plot(x, prediction)

```

## Задание 3
### Изучить код на Python и ответить на вопросы

- Должна ли величина loss стремиться к нулю при изменении исходных данных? Ответьте на вопрос, приведите пример выполнения кода, который подтверждает ваш ответ.

Величина loss должна стермится к нулю при изменении исходных данных. Это подтверждается примером кода ниже. Выходные значения из третьго столбца(loss) стремятся к нулю
```py

#Import the required modules, numpy for calculation, and Matplotlib for drawing
import numpy as np
import matplotlib.pyplot as plt

# define data, and change list to array
x1 = [1,10,20,30,40,50,60,70,80,99]
x1 = np.array(x1)
y1 = [10,20,30,30,40,60,94,100,103,119]
y1 = np.array(y1)

x = [3,21,22,34,54,34,55,67,89,99]
x = np.array(x)
y = [2,22,24,65,79,82,55,130,150,199]
y = np.array(y)

#Show the effect of a scatter plot
plt.scatter(x,y)
#The basic linear regression model is wx + b, and sinse this is a two-dementional space, the model is ax + b

def model(a, b, x):
  return a*x+b

#The most commonly used ioss function of linear regression model is the loss function of mean variance difference
def loss_function(a, b, x, y):
  num = len(x)
  prediction = model(a, b, x)
  return (0.5/num) * (np.square(prediction-y)).sum()

#The optimization function mainly USES partial derivatives to update two parameters a and b
def optimize(a, b, x, y):
  num = len(x)
  prediction = model(a,b,x)
  #Update the values of A and B by sinding the partial derivatives of the loss function on a and b
  da = (1.0/num) * ((prediction -y)*x).sum()
  db = (1.0/num) * ((prediction -y).sum())
  a = a-Lr*da
  b = b-Lr*db
  return a, b

#iterated function, return a and b
def iterate(a,b,x,y,times):
  for i in range(times):
    a,b = optimize(a,b,x,y)
  return a, b

#Initialize parameters and display
a = np.random.rand(1)
print(a)
b = np.random.rand(1)
print(b)
Lr = 0.000001

#count of iterations
iteration_number = [1,10, 100,1000, 5000, 10000]
def iterate_data(a, b,x, y, colors):
  for i in range(len(iteration_number)):
    a,b = iterate(a,b,x,y, iteration_number[i])
    prediction = model(a,b,x)
    loss = loss_function(a,b,x,y)
    print(a,b,loss)
    plt.scatter(x,y, c = colors[len(colors)-1])
    if(i == len(iteration_number)):
      plt.plot(x, prediction, c = colors[i], linewidth = 6)
    else:
      plt.plot(x, prediction, c = colors[i])

iterate_data(a,b,x,y,  [ '#8B0000', '#FA8072', '#DC143C', '#B22222', '#FFA07A', 'red' ])
print("\n")
#change data
iterate_data(a,b,x1, y1,  ['#000080', '#48D1CC', '#48D1CC', '#4682B4', 'darkblue','#00008B'])

plt.xscale("log")
plt.yscale("log")
plt.xscale("log")
plt.yscale("log")


```


 - Какова роль параметра Lr? Ответьте на вопрос, приведите пример выполнения кода, который подтверждает ваш ответ. В качестве эксперимента можете изменить значение параметра.

 Lr -  параметр, минимизирующий функцию потерь при вычисления параметров модели(а, b). Сумма квадратов отклонений точек влияет на параметры модели, которая соответствует реальным наблюдениям данных, от линии регрессии, в идеале должна быть минимальной(optimize). Поэтому чтобы минимизировать сумму квадратов реальных отклонений данных от регрессионной линии необходимо экспериментально близко к идеалу определить этот параметр. Таким образом мы выбираем лучшую из вариаций линейной регрессии.

```py 
#Import the required modules, numpy for calculation, and Matplotlib for drawing
import numpy as np
import matplotlib.pyplot as plt

# define data, and change list to array
x = [3,21,22,34,54,34,55,67,89,99]
x = np.array(x)
y = [2,22,24,65,79,82,55,130,150,199]
y = np.array(y)

#Show the effect of a scatter plot
plt.scatter(x,y)
#The basic linear regression model is wx + b, and sinse this is a two-dementional space, the model is ax + b

def model(a, b, x):
  return a*x+b

#The most commonly used ioss function of linear regression model is the loss function of mean variance difference
def loss_function(a, b, x, y):
  num = len(x)
  prediction = model(a, b, x)
  return (0.5/num) * (np.square(prediction-y)).sum()

#The optimization function mainly USES partial derivatives to update two parameters a and b
def optimize(a, b, x, y, lr):
  num = len(x)
  prediction = model(a,b,x)
  #Update the values of A and B by sinding the partial derivatives of the loss function on a and b
  da = (1.0/num) * ((prediction -y)*x).sum()
  db = (1.0/num) * ((prediction -y).sum())
  a = a-lr*da
  b = b-lr*db
  return a, b

#iterated function, return a and b
def iterate(a,b,x,y,times, lr):
  for i in range(times):
    a,b = optimize(a,b,x,y, lr)
  return a, b

#Initialize parameters and display
a = np.random.rand(1)
print(a)
b = np.random.rand(1)
print(b)
Lr = 0.000001

iteration_number = [1,2,3,4,5,10000]
def iterate_data(a, b,x, y, lr, colors):
  for i in range(len(iteration_number)):
    a,b = iterate(a,b,x,y, iteration_number[i], lr)
    prediction = model(a,b,x)
    loss = loss_function(a,b,x,y)
    print(a,b,loss)
    plt.scatter(x,y)
    if(i == len(iteration_number)):
      plt.plot(x, prediction, c = colors[i], linewidth = 6)
    else:
      plt.plot(x, prediction, c = colors[i])

iterate_data(a,b,x,y, Lr, ['#8B0000', '#FA8072', '#DC143C', '#B22222', '#FFA07A', 'red' ])
print("\n")
iterate_data(a,b,x, y, Lr/100, ['#000080', '#48D1CC', '#48D1CC', '#4682B4', 'darkblue','#00008B'])
print("\n")
iterate_data(a,b,x,y, Lr*100, ['#FFFF66', '#FFF44F', '#F8F32B', '#FFB300', '#F4C800',  'yellow'])
print("\n")
iterate_data(a,b,x,y, Lr/1000, ['#C5E384', '#9ACD32', '#4CBB17', '#138808', '#228B22', 'green'])

```
https://github.com/sf-balaba/DA-in-GameDev-lab1/blob/7681957febb1d8004778c0412d5fe9a5553e14cb/Task3.ipynb

## Выводы

В ходе проделанной мною работы я установила необходимое программное обеспечение, познакомилась с основными конструкциями Pyhton на примере реализации линейной регрссии, подробнее изучила алгоритм линейной регрессии: функцию потерь, которая использует метод наименьших квадратов, поэкспериментировала с величинами, изменяя исходные данные и величину Lr, поняла смысл Lr и loss в ходе экспериментов. Правильно подобранный Lr(коэффициент ковариации) помогает выбрать максимально близкий к идеалу вариант из вариаций линейных регрессий. Величина loss, стремится к нулю при любых данных, а также с возрастанием числа инетераци й loss уменьшается, стремясь к нулю. Я подтвердила это предположение примером кода.

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
