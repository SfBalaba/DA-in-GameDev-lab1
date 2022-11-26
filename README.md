# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #4 выполнил(а):
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
Познакомиться с работой перцептрона на практике при помощи движка Unity. Реализовать перцептрон который умеет решать логические операции. 

## Задание 1
### В проекте реализовать перцептрон, который умеет производить вычисления: OR, AND, NAND, XOR, и дать комментарии о кореектности работы.

Ход работы: 

- Для начала создадим пустой проект на Unity. Создадим пустой объект и прикрепим ему код из методических указаний:

```py
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
	public double[] input;
	public double output;
}

public class Perceptron : MonoBehaviour {

	public TrainingSet[] ts;
	double[] weights = {0,0};
	double bias = 0;
	double totalError = 0;

	double DotProductBias(double[] v1, double[] v2) 
	{
		if (v1 == null || v2 == null)
			return -1;
	 
		if (v1.Length != v2.Length)
			return -1;
	 
		double d = 0;
		for (int x = 0; x < v1.Length; x++)
		{
			d += v1[x] * v2[x];
		}

		d += bias;
	 
		return d;
	}

	double CalcOutput(int i)
	{
		double dp = DotProductBias(weights,ts[i].input);
		if(dp > 0) return(1);
		return (0);
	}

	void InitialiseWeights()
	{
		for(int i = 0; i < weights.Length; i++)
		{
			weights[i] = Random.Range(-1.0f,1.0f);
		}
		bias = Random.Range(-1.0f,1.0f);
	}

	void UpdateWeights(int j)
	{
		double error = ts[j].output - CalcOutput(j);
		totalError += Mathf.Abs((float)error);
		for(int i = 0; i < weights.Length; i++)
		{			
			weights[i] = weights[i] + error*ts[j].input[i]; 
		}
		bias += error;
	}

	double CalcOutput(double i1, double i2)
	{
		double[] inp = new double[] {i1, i2};
		double dp = DotProductBias(weights,inp);
		if(dp > 0) return(1);
		return (0);
	}

	void Train(int epochs)
	{
		InitialiseWeights();
		
		for(int e = 0; e < epochs; e++)
		{
			totalError = 0;
			for(int t = 0; t < ts.Length; t++)
			{
				UpdateWeights(t);
				Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B: " + bias);
			}
			Debug.Log("TOTAL ERROR: " + totalError);
		}
	}

	void Start () {
		Train(8);
		Debug.Log("Test 0 0: " + CalcOutput(0,0));
		Debug.Log("Test 0 1: " + CalcOutput(0,1));
		Debug.Log("Test 1 0: " + CalcOutput(1,0));
		Debug.Log("Test 1 1: " + CalcOutput(1,1));		
	}
	
	void Update () {
		
	}
}
```

- Реализация операции OR | ИЛИ:

Тбалица истинности:

![or](https://user-images.githubusercontent.com/102922461/204007591-9cdfa249-318d-44d0-9d86-6e5dee68033a.jpg)

Установим эти значения для нашего скрипта: 

![or_realiz](https://user-images.githubusercontent.com/102922461/204007608-d2cedee9-0fc8-41c0-907a-0b964ad793ee.jpg)

Для начала зададим 1 обучающую эпоху и посмотрим на результаты наших тестов:

![результат1](https://user-images.githubusercontent.com/102922461/204008360-9000989b-21b9-46ba-bc32-6c0252b5c82c.jpg)

Значение Total Error отвечает за обучение перцептрона: если оно отлично от нуля, то модель не обучилась, если же нуль - тогда модель успешно обучилась. При первой эпохе обучения значение Total Error = 1, и из результатов тестов видно, что значения отличны от истины: в первом случае, ответ 1, хотя должен быть 0.

Зададим 4 эпохи обучения:

![2эп4(1)](https://user-images.githubusercontent.com/102922461/204010286-ee71f235-56e7-4613-a4b7-e19a9805efdf.jpg)
![2эп4(2)](https://user-images.githubusercontent.com/102922461/204010305-0d199b47-7550-4e49-90a1-97b37d155df1.jpg)
![2эп4(3)](https://user-images.githubusercontent.com/102922461/204010302-861fd7fa-f25a-4c31-8ede-587085aed8e6.jpg)


В данном случае уже при чётвертой эпохе обучения Total Error равняется нулю, и мы видим из результатов тестов, что модель успешно обучилась.
Повторим запуск программы с 4 эпохами обучения: 


![эп4(1)](https://user-images.githubusercontent.com/102922461/204008995-249bf2e3-1346-4d1b-9c8f-0e232bad179d.jpg)
![эп4(2)](https://user-images.githubusercontent.com/102922461/204009029-e50637f6-0f3d-41cb-a78b-2ebd18527565.jpg)
![эп4(3)](https://user-images.githubusercontent.com/102922461/204009075-673536ec-ec39-4e52-b1ec-7c46772793a5.jpg)

Можем сделать вывод, что 4 эпохи обучения достаточно исходя из количества испытаний(их было 2). 

В ходе подбора количества эпох обучения, в моем случае, на пятой эпохе значение Total Error равно нулю. (Подробные значения на каждой эпохе буду разбирать во втором задании с графиками.)

- Реализация операции AND | И:

Тбалица истинности:

![AND](https://user-images.githubusercontent.com/102922461/204007578-42ee0d81-3edd-42df-81fa-0303cecd2b6e.jpg)

Установим эти значения для нашего скрипта: 

![AND_REAL](https://user-images.githubusercontent.com/102922461/204014206-c67f4b55-1cee-47b9-8a9f-e5227c5db715.jpg)

Для начала зададим 1 обучающую эпоху и посмотрим на результаты наших тестов:

![Иэп1](https://user-images.githubusercontent.com/102922461/204015906-ce5641cc-9fd5-4f05-9647-b14d52037a63.jpg)

Значение Total Error отвечает за обучение перцептрона: если оно отлично от нуля, то модель не обучилась, если же нуль - тогда модель успешно обучилась. При первой эпохе обучения значение Total Error = 1, и из результатов тестов видно, что значения отличны от истины: в первом случае, ответ 1, хотя должен быть 0.

Зададим 4 эпохи обучения:

![1Иэп(1)](https://user-images.githubusercontent.com/102922461/204015965-0765c7ec-dfc6-40f0-acae-5e5521e530b7.jpg)
![1Иэп(2)](https://user-images.githubusercontent.com/102922461/204015970-d9d28610-582b-4722-a420-2b219a57de45.jpg)
![1Иэп(3)](https://user-images.githubusercontent.com/102922461/204015967-1f299f2e-f640-4b5b-9732-009660dab49a.jpg)

В данном случае уже при третьей эпохе обучения Total Error равняется нулю, и мы видим из результатов тестов, что модель успешно обучилась.
Повторим запуск программы с 4 эпохами обучения: 

![Иэп4(1)](https://user-images.githubusercontent.com/102922461/204015927-f4e13078-055d-435f-b246-4ca661469b04.jpg)
![Иэп4(2)](https://user-images.githubusercontent.com/102922461/204015925-40ee60a3-ce6e-4fab-9f22-f846b9ad8856.jpg)
![Иэп4(3)](https://user-images.githubusercontent.com/102922461/204015929-bbfe989b-2477-4541-b4b0-d9242b381600.jpg)

При втором испытании резульат показал,  что заданного количества эпох недостаточно. 
Можем сделать вывод, что 4 эпохи обучения явно недостаточно исходя из количества испытаний(их было 2). При наждении оптимального поличства эпох выбирем значение этого параметра равным 8.

В ходе подбора количества эпох обучения, в моем случае, на пятой эпохе значение Total Error равно нулю. (Подробные значения на каждой эпохе буду разбирать во втором задании с графиками.)

- Реализация операции NAND | инвертированный элемент И:

Сначала вспомним табличку для этой логической операции:

![nand](https://user-images.githubusercontent.com/102922461/204071579-d41a3918-f914-4bc4-8b18-0d7fcfe67159.jpg)

Установим эти значения для нашего скрипта: 

![nand_realiz](https://user-images.githubusercontent.com/102922461/204071577-59d69ce0-4995-4471-9272-31aae29b6611.jpg)


Для начала зададим 1 обучающую эпоху и посмотрим на результаты наших тестов:

![nand_ep1](https://user-images.githubusercontent.com/102922461/204071580-44c1c08a-df80-4f3d-aafa-3d161233e7e2.jpg)

Одной эпохи для обучения мало. Мы это подтвердили уже на трех логических операциях.

Установим 4 эпохи обучения:

![nanad_ep4(1)](https://user-images.githubusercontent.com/102922461/204071612-f7e8b877-3587-40ce-b882-4a8d0b41638e.jpg)
![nand_ep4(3)](https://user-images.githubusercontent.com/102922461/204071615-fc246c2a-b6b5-4b37-a908-a1fce61d2d3e.jpg)
![nand_ep4(2)](https://user-images.githubusercontent.com/102922461/204071616-867893e6-cc95-4c9e-ba85-0ea15b0391ab.jpg)

Четырех эпох обучения мало, было проверено на нескольких запусках. Установим значение 8:

![nand_ep8(1)](https://user-images.githubusercontent.com/102922461/204071727-e1d2369c-f491-4af7-b7e8-c2727f7183e8.jpg)
![nand_ep8(2)](https://user-images.githubusercontent.com/102922461/204071726-6bf072fc-d4a1-48c2-8078-6c4882326be7.jpg)
![nand_ep8(3)](https://user-images.githubusercontent.com/102922461/204071725-eee63b8a-4557-47d6-b57e-3914559a716d.jpg)
![nand_ep8(4)](https://user-images.githubusercontent.com/102922461/204071724-9ba3e6d3-dc68-41df-b4f6-6cab4ad3f6e7.jpg)
![nand_ep8(5)](https://user-images.githubusercontent.com/102922461/204071730-86177ab3-6f6c-410b-8af0-d4b72b976c87.jpg)

В данной попытке уже при шестой эпохе значение Total Error было равно нулю. Подробные значения во втором задании.

- Реализация операции XOR | исключающее ИЛИ:

Сначала вспомним табличку для этой логической операции:

![xor](https://user-images.githubusercontent.com/102922461/204072026-4594def7-2681-4a1a-9672-79459e52e341.jpg)

Установим эти значения для нашего скрипта: 

![xor_realiz](https://user-images.githubusercontent.com/102922461/204072028-c4346a5d-a050-4fb2-8a80-a930340dd5a4.jpg)

Сразу применим 4 эпохи обучения:

![xor_ep4(1)](https://user-images.githubusercontent.com/102922461/204072069-b265de79-d919-4254-bae8-5f0c30404d28.jpg)
![xor_ep4(2)](https://user-images.githubusercontent.com/102922461/204072072-5a2cd69b-ad78-4dc8-b977-2cfe156a9b36.jpg)
![xor_ep4(3)](https://user-images.githubusercontent.com/102922461/204072071-4df34b36-357d-40af-acc9-d5dbf4aa02c1.jpg)
![xor_ep4(4)](https://user-images.githubusercontent.com/102922461/204072070-39b730d7-23fa-451a-aa45-ee75d504b924.jpg)

При нескольких попытках четырех эпох было мало для обучения. В ходе работы с разными значениями эпох обучения было выяснено, что начиная с третьей-четвертой эпохи значение Total Error всегда было равно 4. Следовательно - однослойный перцептрон не может обучиться этой операции. 

Однослойный перцептрон в силах решать линейные задачи, а XOR таковой не является. 

Эту задачу с помощью перцептрона можно решить таким способом. Применим формулу x XOR y = (x Or y) AND (x NAND y).
Для этого я создала еще две треннировочные модели tsOr и tsNAND. А в модели ts использовала логику обычного умножения. Когда первые две модели оттренировались их значения я положила в функцию CalcOutput после тренировки модели умножения. Прикладываю новый код: 

```py
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
	public double[] input;
	public double output;
}

public class Perceptron : MonoBehaviour {
	public TrainingSet[] tsOR;
	public TrainingSet[] tsNAND;
	public TrainingSet[] ts;
	double[] weights = {0,0};
	double bias = 0;
	double totalError = 0;

	double DotProductBias(double[] v1, double[] v2) 
	{
		if (v1 == null || v2 == null)
			return -1;
	 
		if (v1.Length != v2.Length)
			return -1;
	 
		double d = 0;
		for (int x = 0; x < v1.Length; x++)
		{
			d += v1[x] * v2[x];
		}

		d += bias;
	 
		return d;
	}

	double CalcOutput(int i, TrainingSet[] set)
	{
		double dp = DotProductBias(weights,set[i].input);
		if(dp > 0) return(1);
		return (0);
	}

	void InitialiseWeights()
	{
		for(int i = 0; i < weights.Length; i++)
		{
			weights[i] = Random.Range(-1.0f,1.0f);
		}
		bias = Random.Range(-1.0f,1.0f);
	}

	void UpdateWeights(int j, TrainingSet[] set)
	{
		double error = set[j].output - CalcOutput(j, set);
		totalError += Mathf.Abs((float)error);
		for(int i = 0; i < weights.Length; i++)
		{			
			weights[i] = weights[i] + error * set[j].input[i]; 
		}
		bias += error;
	}

	double CalcOutput(double i1, double i2)
	{
		double[] inp = new double[] {i1, i2};
		double dp = DotProductBias(weights,inp);
		if(dp > 0) return(1);
		return (0);
	}

	void Train(int epochs, TrainingSet[] set)
	{
		InitialiseWeights();
		
		for(int e = 0; e < epochs; e++)
		{
			totalError = 0;
			for(int t = 0; t < set.Length; t++)
			{
				UpdateWeights(t, set);
				Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B: " + bias);
			}
			Debug.Log("TOTAL ERROR: " + totalError);
		}
	}

	void Start () {
		Train(8, tsOR);
		double tsOr0 = CalcOutput(0,0); //0
		double tsOr1 = CalcOutput(0,1); //1
		double tsOr2 = CalcOutput(1,0); //1
		double tsOr3 = CalcOutput(1,1); //1
		
		Train(8, tsNAND);
		double tsNAND0 = CalcOutput(0,0); //1
		double tsNAND1 = CalcOutput(0,1); //1
		double tsNAND2 = CalcOutput(1,0); //1
		double tsNAND3 = CalcOutput(1,1); //0

		Train(8, ts);
		Debug.Log("Test 0 0: " + CalcOutput(tsOr0, tsNAND0));
		Debug.Log("Test 0 1: " + CalcOutput(tsOr1, tsNAND1));
		Debug.Log("Test 1 0: " + CalcOutput(tsOr2, tsNAND2));
		Debug.Log("Test 1 1: " + CalcOutput(tsOr3, tsNAND3));		
	}
	
	void Update () {
		
	}
}
```

После выполнения 8 тренировок у каждой модели мы получаем удовлетворяющий нас результат:
![xor_ep8(1)](https://user-images.githubusercontent.com/102922461/204072497-95532e16-8f13-476f-92dd-4810d10361fc.jpg)
![xor_ep8(2)](https://user-images.githubusercontent.com/102922461/204072496-157f0d18-286b-42ff-8e7e-fa73eedd317e.jpg)
![xor_ep8(3)](https://user-images.githubusercontent.com/102922461/204072494-9a2c8d0d-d9e6-4acc-aa58-d092acccdd85.jpg)

![total](https://user-images.githubusercontent.com/102922461/204072505-4fc23256-3ba7-4f3d-bf0b-c9c096e80fab.jpg)
Подробный отчет по эпохам тренировок в задании 2.

Можем сделать вывод, что один слой перцептрона может решать только линейные задачи, такие как AND, OR, NAND. Для решения нелинейной задачи XOR необходимо добавлять еще слои перцептронов.


## Задание 2
### Построить графики зависимости количества эпох от ошибки обучения. Указать от чего зависит необходимое количество эпох обучения.

Для каждой операции было запущено 5 попыток с 8-ю эпохами обучения. На графиках указано среднее значение Total Error за 5 попыток.

- Операция OR | ИЛИ
![GRAPH_OR](https://user-images.githubusercontent.com/102922461/204073241-74fcd6dd-a28d-4484-9d7d-81a287a72b86.jpg)

- Операция AND | И

![GRAPH_AND](https://user-images.githubusercontent.com/102922461/204073240-959064a6-d24e-4746-9a00-28fb6ee7d49d.jpg)

- Операция NAND | инвертированный элемент И

![GRAPH_NAND](https://user-images.githubusercontent.com/102922461/204073238-fd966602-a223-42a1-a775-f862103e93fa.jpg)

- Операция XOR | исключающее ИЛИ

Для получения количества ошибок я складывала количество ошибок при каждой операции соответственно (сумма ошибок на первой эпохе в каждой операции и тд)

![GRAPH_XOR](https://user-images.githubusercontent.com/102922461/204073242-76fcd7a2-dcb9-4491-9931-6db2a0a93d7a.jpg)

Количество эпох обучения зависит от решаемой операции. Например, при операции OR и AND ошибок не встречается уже на пятой эпохе обучения, NAND -  при седьмой, XOR - при восьмой. Статистика не совсем точная, так как взято небольшое количество попыток (5). 



    
## Задание 3
### Построить визуальную модель работы перцептрона на сцене Unity.

- Для начала создадим сцену с тремя вариантами: черный куб - 0, белый куб - 1; три варианта: (0 0), (0 1)/(1 0) и (1 1).

![image](https://user-images.githubusercontent.com/101496751/203343162-49923744-d808-4c92-a32c-3ae08395d66c.png)

При их столкновении они оба окрасятся в цвет результата той или иной операции (черный - 0, белый - 1).

Для этого в коде нужно завести две переменных, которые будут отвечать за обозначение куба (0 или 1). И уже эти значения подставлять в функцию CalcOutput для определения результата операции после обучения модели. Также у верхнего куба нужно поставить Rigidbody, а у нижнего - Is trigger. Новый код:

```py
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
	public double[] input;
	public double output;
}


public class Perceptron : MonoBehaviour {
	public TrainingSet[] tsOR;
	public TrainingSet[] tsNAND;
	public TrainingSet[] ts;
	double or;
	double nand;
	double xor;

	public double firstCube;
	public double secondCube;
	double[] weights = {0,0};
	double bias = 0;
	double totalError = 0;

	double DotProductBias(double[] v1, double[] v2) 
	{
		if (v1 == null || v2 == null)
			return -1;
	 
		if (v1.Length != v2.Length)
			return -1;
	 
		double d = 0;
		for (int x = 0; x < v1.Length; x++)
		{
			d += v1[x] * v2[x];
		}

		d += bias;
	 
		return d;
	}

	double CalcOutput(int i, TrainingSet[] set)
	{
		double dp = DotProductBias(weights,set[i].input);
		if(dp > 0) return(1);
		return (0);
	}

	void InitialiseWeights()
	{
		for(int i = 0; i < weights.Length; i++)
		{
			weights[i] = Random.Range(-1.0f,1.0f);
		}
		bias = Random.Range(-1.0f,1.0f);
	}

	void UpdateWeights(int j, TrainingSet[] set)
	{
		double error = set[j].output - CalcOutput(j, set);
		totalError += Mathf.Abs((float)error);
		for(int i = 0; i < weights.Length; i++)
		{			
			weights[i] = weights[i] + error * set[j].input[i]; 
		}
		bias += error;
	}

	double CalcOutput(double i1, double i2)
	{
		double[] inp = new double[] {i1, i2};
		double dp = DotProductBias(weights,inp);
		if(dp > 0) return(1);
		return (0);
	}

	void Train(int epochs, TrainingSet[] set)
	{
		InitialiseWeights();
		
		for(int e = 0; e < epochs; e++)
		{
			totalError = 0;
			for(int t = 0; t < set.Length; t++)
			{
				UpdateWeights(t, set);
				Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B: " + bias);
			}
			Debug.Log("TOTAL ERROR: " + totalError);
		}
	}
	
	void Start () {
		Train(8, tsOR);
		double tsOr0 = CalcOutput(0,0); //0
		double tsOr1 = CalcOutput(0,1); //1
		double tsOr2 = CalcOutput(1,0); //1
		double tsOr3 = CalcOutput(1,1); //1
		or =  CalcOutput(firstCube, secondCube);

		
		Train(8, tsNAND);
		double tsNAND0 = CalcOutput(0,0); //1
		double tsNAND1 = CalcOutput(0,1); //1
		double tsNAND2 = CalcOutput(1,0); //1
		double tsNAND3 = CalcOutput(1,1); //0
		nand =  CalcOutput(firstCube, secondCube);

		Train(8, ts);
		Debug.Log("Test 0 0: " + CalcOutput(tsOr0, tsNAND0));
		Debug.Log("Test 0 1: " + CalcOutput(tsOr1, tsNAND1));
		Debug.Log("Test 1 0: " + CalcOutput(tsOr2, tsNAND2));
		Debug.Log("Test 1 1: " + CalcOutput(tsOr3, tsNAND3));
		xor = CalcOutput(nand, or);
	}
	
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other) {
		
		if (xor == 0) {
			other.gameObject.GetComponent<Renderer>().material.color = Color.black;
        	this.gameObject.GetComponent<Renderer>().material.color = Color.black;
		}
		else {
			other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
    }
}
```

- Операция OR | ИЛИ:

![or_gmfc](https://user-images.githubusercontent.com/102922461/204081057-e832e787-eb61-44a0-aadc-d182150d824e.gif)

- Операция AND | И: 

![and_gmf](https://user-images.githubusercontent.com/102922461/204081059-ed9a5b8d-b726-409d-9f51-d0373b78a2b1.gif)

- Операция NAND | инвертированный элемент И: 

![nand_gmf](https://user-images.githubusercontent.com/102922461/204081055-42547456-5245-48d5-b05b-3a280a4e5a78.gif)

- Операция XOR | исключающее ИЛИ (Для операции XOR заменим значения кубов на результаты промежуточных операций):

![xor_gmfc](https://user-images.githubusercontent.com/102922461/204081058-92b708d1-af9c-474f-9f1b-c1f65aecb0a8.gif)




## Выводы
В ходе лабороторной работы познакомилась с прародителем нейроной сети - перцептроном. С помощью однослойного перцептрона смогла реализовать такие логические операции как OR, AND, NAND. Для операции XOR пришлось применять три перцептрона, каждый из которых выполнял одну из операций упомянутых ранее( x XOR y = (x Or y) AND (x NAND y).
 Из этого сделала вывод, что однослойный перцептрон можен решить только линейные задачи. Также построила графики для оценки обучаемости каждой из логических операций. Применив функционал Unity, геймефицировала работу перцептрона: при столкновении кубов(логических элементов) результирующий куб окрашивался в цвет результата логической операции.


| Plugin | README |
| ------ | ------ |
| GitHub | [plugins/github/README.md][PlGh] |
| Unity | [plugins/unity/README.md][PlU] |
| Visual Studio Code| [plugins/visualstudiocode/README.md][PlVSC] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
