using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArray : MonoBehaviour
{

    public float arraySize = 32;
    [SerializeField] private GameObject[,] nodes = new GameObject[32, 32];

    // Vector? GameObject[,] thing idk? comma is array thing? for 2d

    // for loop where i is like, first value? and also row?
    //gets things with row tag? name? 

    void Start()
    {
        InstantiateArray();
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
                nodes[i, j] = column.gameObject;
                j++;
            }
        }
    }

    //then uses j and foreach's all those?
    //and puts those at i,j? but how do you put it at the j?
    //dont you just make the j the number?
    //isnt the array like [4,24] not [4,gameObject24]?
    //then you like, have the array


    // from there its easy, to get the one above you find what is at [-1,0] of your current spot, etc
    // and return that value to use in other functions


}
