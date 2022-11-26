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