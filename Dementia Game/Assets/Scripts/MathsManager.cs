using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathsManager : MonoBehaviour
{
    
    private int[] index,awnser,result,multiplier,pickNumber,dropdownValues;
    private int operaterValue,increment,randomNumberPick,rangeReducer;
    private GameObject[] tempNumbers,tempSigns;
    private float time=0.0f;

    const int V = 10;
    public GameObject[] NumberArray, DragabeNumbers,PositiveNegative;
    //public GameObject[] DragabeNumbers;
    public Transform[] NumberSpawner, OperaterSpawner;
    public BoxCollider2D[] AwnserBoxes,DraggableNumbers;
    public float TimeLimit = 3.0f;
    public float SignTime = 3.0f;

    public Dropdown[] dropdowns;
    // Start is called before the first frame update
    void Start()
    {
        
        index = new int[9999];
        awnser= new int[4];
        result = new int[4];
        multiplier = new int[4];
        tempNumbers = new GameObject[8];
        tempSigns = new GameObject[4];
        pickNumber = new int[V];
        dropdownValues = new int[4];

        increment =0;
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = Random.Range(0, 9);
        }
        Debug.Log(increment);


        for (int l = 0; l < OperaterSpawner.Length; l++)
        {
            operaterValue = Random.Range(0, 2);
            tempSigns[l]=Instantiate(PositiveNegative[operaterValue], OperaterSpawner[l].position, Quaternion.identity);
            
            if(operaterValue==0)
            {
                multiplier[l] = operaterValue +1;
            }
            else
            {
                multiplier[l] = operaterValue - 2;
            }
            dropdownValues[l] = dropdowns[l].value;
        }
        for (int k = 0; k < awnser.Length; k++)
        {
            rangeReducer = 0;
            awnser[k] = index[2 * k] + multiplier[k]*index[(2 * k) + 1];
            //while(awnser[k]==0)
            //{

            //}
            //if (k > 0)
            //{

            //    while (awnser[k] == awnser[k - 1])
            //    {

            //        randomNumberPick = Random.Range(rangeReducer, 9);
            //        index[2 * k] = pickNumber[randomNumberPick];
            //        awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
            //        for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
            //        {
            //            pickNumber[j] = pickNumber[j - 1];
            //        }
            //        rangeReducer++;
            //    }
            //    rangeReducer = 0;
            //    Reassign();
            //    //if (k > 1)
            //    //{
            //    //    while (awnser[k] == awnser[k - 2])
            //    //    {
            //    //        randomNumberPick = Random.Range(rangeReducer, 9);
            //    //        index[2 * k] = pickNumber[randomNumberPick];
            //    //        awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
            //    //        for (int j = randomNumberPick - 1; j > 0 + rangeReducer; j--)
            //    //        {
            //    //            pickNumber[j] = pickNumber[j - 1];
            //    //        }
            //    //        rangeReducer++;
            //    //    }
            //    //    Reassign();
            //    //    rangeReducer = 0;
            //    //    if (k > 2)
            //    //    {
            //    //        while (awnser[k] == awnser[k - 3])
            //    //        {
            //    //            randomNumberPick = Random.Range(rangeReducer, 9);
            //    //            index[2 * k] = pickNumber[randomNumberPick];
            //    //            awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
            //    //            for (int j = randomNumberPick - 1; j > 0 + rangeReducer; j--)
            //    //            {
            //    //                pickNumber[j] = pickNumber[j - 1];
            //    //            }
            //    //            rangeReducer++;
            //    //        }
            //    //        Reassign();
            //    //    }
            //    //}

            //}
            //Reassign();
            //rangeReducer = 0;
            //while (awnser[k] <= 0)
            //{
            //    randomNumberPick = Random.Range(rangeReducer, 9);
            //    index[2 * k] = pickNumber[randomNumberPick];
            //    awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
            //    for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
            //    {
            //        pickNumber[j] = pickNumber[j - 1];
            //    }
            //    rangeReducer++;
            //}
            //Reassign();
            //rangeReducer = 0;
            //while (awnser[k] >= 10)
            //{
            //    randomNumberPick = Random.Range(rangeReducer, 9);
            //    index[2 * k] = pickNumber[randomNumberPick];
            //    awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
            //    for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
            //    {
            //        pickNumber[j] = pickNumber[j - 1];
            //    }
            //    rangeReducer++;
            //}
            //Reassign();
        }
        for (int j = 0; j < NumberSpawner.Length; j++)
        {
            tempNumbers[j]=Instantiate(NumberArray[index[j]], NumberSpawner[j].position, Quaternion.identity);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        
        if(time>=TimeLimit)
        {
            ShuffleNumbers();
            //ShuffleSigns();
            time = 0;
        }
        for (int i = 0; i < dropdowns.Length; i++)
        {
            if (awnser[i] == dropdownValues[i])
            {
            Debug.Log("Yes");
        }
            else
        {
            Debug.Log("No");
        }
        }
    }

    //void DropdownValueChanged(Dropdown change)
    //{
    //    CheckAwnsers();
    //}

    public void CheckAwnsers()
    {
        for (int i = 0; i < dropdowns.Length; i++)
        {

            dropdownValues[i] = multiplier[i]*dropdowns[i].value;

            
            //if (awnser[i] == dropdownValues[i])
            //{
            //    Debug.Log("Yes");
            //}
            //else
            //{
            //    Debug.Log("No");
            //}
        }
    }
    void Reassign()
    {
        for (int m = 0; m < pickNumber.Length; m++)
        {
            pickNumber[m] = m;
        }
    }
    
    void ShuffleNumbers()
    {


        index[increment] = Random.Range(0, 9);

        operaterValue = Random.Range(0, 2);
        
        Destroy(tempSigns[increment/2]);
        tempSigns[increment/2] = null;
        tempSigns[increment/2] = Instantiate(PositiveNegative[operaterValue], OperaterSpawner[increment / 2].position, Quaternion.identity);
        if (operaterValue == 0)
        {
            multiplier[increment / 2] = operaterValue + 1;
        }
        else
        {
            multiplier[increment / 2] = operaterValue - 2;
        }

        if (increment % 2 == 0)
        {
            awnser[increment / 2] = index[increment] + multiplier[increment / 2] * index[increment + 1];
        }
        else
        {
            awnser[increment / 2] = index[increment - 1] + multiplier[increment / 2] * index[increment];
        }

        //for (int k = awnser.Length - 1; k >= 0; k--)
        //{
        //    rangeReducer = 0;
        //    while (awnser[k] <= 0)
        //    {
        //        randomNumberPick = Random.Range(rangeReducer, 9);
        //        index[increment] = pickNumber[randomNumberPick];
        //        awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
        //        for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
        //        {
        //            pickNumber[j] = pickNumber[j - 1];
        //        }
        //        rangeReducer++;
        //    }
        //    Reassign();
        //    rangeReducer = 0;
        //}
        //    while (awnser[k] >= 10)
        //    {
        //        randomNumberPick = Random.Range(rangeReducer, 9);
        //        index[increment] = pickNumber[randomNumberPick];
        //        awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
        //        for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
        //        {
        //            pickNumber[j] = pickNumber[j - 1];
        //        }
        //        rangeReducer++;
        //    }
        //    Reassign();
        //    if (k > 0)
        //    {
        //        rangeReducer = 0;
        //        while (awnser[k] == awnser[k - 1])
        //        {
        //            randomNumberPick = Random.Range(rangeReducer, 9);
        //            index[increment] = pickNumber[randomNumberPick];
        //            awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
        //            for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
        //            {
        //                pickNumber[j] = pickNumber[j - 1];
        //            }
        //            rangeReducer++;
        //        }
        //        Reassign();
        //        rangeReducer = 0;
        //        if (k > 1)
        //        {
        //            while (awnser[k] == awnser[k - 2])
        //            {
        //                randomNumberPick = Random.Range(rangeReducer, 9);
        //                index[increment] = pickNumber[randomNumberPick];
        //                awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
        //                for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
        //                {
        //                    pickNumber[j] = pickNumber[j - 1];
        //                }
        //                rangeReducer++;
        //            }
        //            Reassign();
        //            rangeReducer = 0;
        //            if (k > 2)
        //            {
        //                while (awnser[k] == awnser[k - 3])
        //                {
        //                    randomNumberPick = Random.Range(rangeReducer, 9);
        //                    index[increment] = pickNumber[randomNumberPick];
        //                    awnser[k] = index[2 * k] + multiplier[k] * index[(2 * k) + 1];
        //                    for (int j = randomNumberPick; j > 0 + rangeReducer; j--)
        //                    {
        //                        pickNumber[j] = pickNumber[j - 1];
        //                    }
        //                    rangeReducer++;
        //                }
        //                Reassign();
        //            }
        //        }

        //    }

        //}
        Destroy(tempNumbers[increment]);
        tempNumbers[increment] = null;
        tempNumbers[increment] = Instantiate(NumberArray[index[increment]], NumberSpawner[increment].position, Quaternion.identity);


        if (increment >=7)
        {
            increment = 0;
        }
        else
        {
            increment++;
        }
        
        //Debug.Log(increment);


    }
}
