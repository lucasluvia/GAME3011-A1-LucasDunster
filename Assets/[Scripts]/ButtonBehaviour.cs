using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public ButtonArray buttonArrayRef;
    public MaterialValues materialValue;
    public Vector2 spotInArray = new Vector2(0, 0);
    private Color HiddenValueColor = Color.white;
    private Color FullValueColour = Color.blue;
    private Color HalfValueColour = new Color(0f, 0.4f, 1f, 1f);
    private Color QuarterValueColour = new Color(0f, 0.6f, 1f, 1f);
    private Color EmptyValueColour = new Color(0.7f, 0.7f, 0.7f, 1f);

    private Image image;

    private Color MaterialValueColour;
    private float pointValue;

    public bool isRevealed;
    public bool isExtracting = false;

    // Start is called before the first frame update
    void Start()
    {
        buttonArrayRef = transform.parent.parent.GetComponent<ButtonArray>();
        SetMaterialValueVariables();
        image = GetComponent<Image>();
        image.color = HiddenValueColor;
        gameObject.GetComponent<Button>().onClick.AddListener(wasClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRevealed)
        {
            image.color = MaterialValueColour;
        }
    }

    void SetMaterialValueVariables()
    {
        switch(materialValue)
        {
            case MaterialValues.FULL:
                MaterialValueColour = FullValueColour;
                pointValue = 500;
                break;
            case MaterialValues.HALF:
                MaterialValueColour = HalfValueColour;
                pointValue = 250;
                break;
            case MaterialValues.QUARTER:
                MaterialValueColour = QuarterValueColour;
                pointValue = 125;
                break;
            case MaterialValues.EMPTY:
                MaterialValueColour = EmptyValueColour;
                pointValue = 0;
                break;
        }
    }

    void ExtractMaterial()
    {
        materialValue = MaterialValues.EMPTY;
        //give pointValue;
        //call DecrementMaterialLevel of surrounding 8
        SetMaterialValueVariables();
    }

    public void wasClicked()
    {
        Debug.Log("Clicked");

        if(isExtracting)
        {
            ExtractMaterial();
        }
        else
        {
            Reveal();
            if(spotInArray.x-1 > 0)
            {
                if(spotInArray.y - 1 > 0)
                    buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(-1, -1)).GetComponent<ButtonBehaviour>().Reveal();
                buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(-1, 0)).GetComponent<ButtonBehaviour>().Reveal();
                if (spotInArray.y + 1 < 32)
                    buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(-1, +1)).GetComponent<ButtonBehaviour>().Reveal();
            }
            if(spotInArray.x+1 <32)
            {
                if (spotInArray.y - 1 > 0)
                    buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(+1, -1)).GetComponent<ButtonBehaviour>().Reveal();
                buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(+1, 0)).GetComponent<ButtonBehaviour>().Reveal();
                if (spotInArray.y + 1 < 32)
                    buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(+1, +1)).GetComponent<ButtonBehaviour>().Reveal();
            }
            if (spotInArray.y - 1 > 0)
                buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(0, -1)).GetComponent<ButtonBehaviour>().Reveal();
            if (spotInArray.y + 1 < 32)
                buttonArrayRef.GetButtonInArray(spotInArray, new Vector2(0, +1)).GetComponent<ButtonBehaviour>().Reveal();
        }

    }

    void DecrementMaterialLevel()
    {

        switch (materialValue)
        {
            case MaterialValues.FULL:
                materialValue = MaterialValues.HALF;
                //give pointValue; ??
                break;
            case MaterialValues.HALF:
                materialValue = MaterialValues.QUARTER;
                //give pointValue; ??
                break;
            case MaterialValues.QUARTER:
                materialValue = MaterialValues.EMPTY;
                //give pointValue; ??
                break;
        }
        SetMaterialValueVariables();
    }

    void Reveal()
    {
        isRevealed = true;
    }

}
