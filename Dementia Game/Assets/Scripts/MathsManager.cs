using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathsManager : MonoBehaviour
{
    
    private int[] index,awnser,result,multiplier,pickNumber,dropdownValues,operaterDropdownValue;
    private int operaterValue, increment, scoreMultiplier, randomNumberPick,rangeReducer;
    private GameObject[] tempNumbers, tempSigns;
    public GameObject[] NumberArray, DragabeNumbers, PositiveNegative,Transitions;
    private float time=0.0f;
    private float score;
    const int V = 10;
    public GameObject ResultScreen,OK,Good,Great;
    //public GameObject[] DragabeNumbers;
    public Transform[] NumberSpawner, OperaterSpawner;
    public BoxCollider2D[] AwnserBoxes,DraggableNumbers;
    public float TimeLimit = 3.0f;
    public float TimeRemaining = 60f;
    
    public Dropdown[] dropdowns, operaterDropdown;
    public TMP_Text Points,TimerText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreMultiplier = 0;
        index = new int[9999];
        awnser= new int[4];
        result = new int[4];
        multiplier = new int[4];
        tempNumbers = new GameObject[8];
        tempSigns = new GameObject[4];
        pickNumber = new int[V];
        dropdownValues = new int[4];
        operaterDropdownValue = new int[4];

        increment =0;
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = Random.Range(0, 9);
        }
        Debug.Log(increment);


        for (int l = 0; l < OperaterSpawner.Length; l++)
        {
            operaterValue = Random.Range(0, 2);
            
            
            if(operaterValue==0)
            {
                multiplier[l] = operaterValue -1;
            }
            else
            {
                multiplier[l] = operaterValue ;
            }
            dropdownValues[l] = dropdowns[l].value;
            operaterDropdownValue[l] = (operaterDropdown[l].value)-1;
            tempSigns[l]=Instantiate(PositiveNegative[operaterValue], OperaterSpawner[l].position, Quaternion.identity);
        }
        for (int k = 0; k < awnser.Length; k++)
        {
            rangeReducer = 0;
            awnser[k] = index[2 * k] + multiplier[k]*index[(2 * k) + 1];
            
        }
        for (int j = 0; j < NumberSpawner.Length; j++)
        {
            tempNumbers[j]=Instantiate(NumberArray[index[j]], NumberSpawner[j].position, Quaternion.identity);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        TimeRemaining -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(TimeRemaining / 60);
        float seconds = Mathf.FloorToInt(TimeRemaining % 60);
        TimerText.text = "Time Remaining: "+minutes+":"+seconds;
        time += Time.deltaTime;
       
        Points.text = "Points: " + Mathf.Round(score);
        
        if (time >= TimeLimit)
        {
            ShuffleNumbers();
            //ShuffleSigns();
            time = 0;
            TimeLimit -= 0.075f;
        }
        for (int i = 0; i < dropdowns.Length; i++)
        {
            if (awnser[i] == dropdownValues[i] && TimeRemaining > 0)
            {
                Debug.Log("Yes");
                score+=1f/60f;
            }
            else
            {
                Debug.Log("No");
                //if (scoreMultiplier > 0)
                //{
                //    scoreMultiplier -= 1;
                //}
            }
        }
        //Debug.Log(operaterDropdownValue[0]);
        Debug.Log(dropdownValues[2]);
        Debug.Log(awnser[2]);
        if (TimeRemaining<=0.0f)
        {
           
            TimerText.gameObject.SetActive(false);
            ResultScreen.SetActive(true);
            Points.gameObject.SetActive(false);
            if (score < 50)
            {
                OK.SetActive(true);
            }
            else if (score > 150)
            {
                Great.SetActive(true);
            }
            else
            {
                Good.SetActive(true);
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
            operaterDropdownValue[i] = (operaterDropdown[i].value) - 1;
            dropdownValues[i] = operaterDropdownValue[i]*dropdowns[i].value;

            
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
            awnser[increment / 2] = index[increment] +  -1 *multiplier[increment / 2] * index[increment + 1];
        }
        else
        {
            awnser[increment / 2] = index[increment - 1] + -1 * multiplier[increment / 2] * index[increment];
        }

        
        StartCoroutine(TransitionTime(increment));
        

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

    IEnumerator TransitionTime(int i)
    {
        Transitions[i].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Transitions[i].SetActive(false);
    }
}
