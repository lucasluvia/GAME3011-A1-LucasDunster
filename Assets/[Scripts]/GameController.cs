using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private TextMeshProUGUI extractsText;
    [SerializeField] private TextMeshProUGUI scansText;
    [SerializeField] private TextMeshProUGUI pointsText;

    public bool ExtractMode = false; 
    public int remainingScans = 6;
    public int remainingExtracts = 3;

    private int pointTracker = 0;

    private float arraySize = 32;
    private GameObject[,] buttonArray = new GameObject[32, 32];

    void Start()
    {
        InstantiateArray();
        SetButtonText();
        extractsText.text = remainingExtracts.ToString();
        scansText.text = remainingScans.ToString();
        pointsText.text = pointTracker.ToString();
    }

    public void SwapModes()
    {
        ExtractMode = !ExtractMode;
        SetButtonText();
    }

    void SetButtonText()
    {
        if (ExtractMode)
            buttonText.text = "Extract Mode";
        else
            buttonText.text = "Scan Mode";
    }

    public void DecrementUses()
    {
        if(ExtractMode)
        {
            extractsText.text = (--remainingExtracts).ToString();
        }
        else
        {
            scansText.text = (--remainingScans).ToString();
        }
    }

    public void AddToPointTracker(int pointsToAdd)
    {
        pointTracker += pointsToAdd;
        pointsText.text = pointTracker.ToString();
    }

    void InstantiateArray()
    {
        for (int i = 0; i < arraySize; i++)
        {
            var currentRow = transform.Find("Row" + (i + 1));
            Debug.Log("Row" + (i + 1));
            int j = 0;
            foreach(Transform column in currentRow)
            {
                buttonArray[i, j] = column.gameObject;
                column.gameObject.GetComponent<ButtonBehaviour>().spotInArray = new Vector2(i, j);
                j++;
            }
        }
    }

    public GameObject GetButtonInArray(Vector2 requestersPosition, Vector2 additivePosition)
    {
        return buttonArray[(int)(requestersPosition.x + additivePosition.x), (int)(requestersPosition.y + additivePosition.y)];
    }


    //then uses j and foreach's all those?
    //and puts those at i,j? but how do you put it at the j?
    //dont you just make the j the number?
    //isnt the array like [4,24] not [4,gameObject24]?
    //then you like, have the array


    // from there its easy, to get the one above you find what is at [-1,0] of your current spot, etc
    // and return that value to use in other functions


}
