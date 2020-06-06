using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hair : MonoBehaviour
{
    public Sprite[] Hairs;
    public Color32[] HairColors;

    public int selectedHair;
    public int selectedHairColor;

    public bool updateHair = false;
    public bool updateHairColor = false;

    private Image hair;

    // Start is called before the first frame update
    void Start()
    {
        hair = GetComponent<Image>();
        HairColors = new Color32[]
        {
            new Color32(255, 255, 255, 255),
            new Color32(255,215,0, 255),
            new Color32(184,134,11, 255),
            new Color32(128,128,0, 255),
            new Color32(0,128,0, 255),
            new Color32(70,130,180, 255),
            new Color32(0,0,255, 255),
            new Color32(147,112,219, 255),
            new Color32(128,0,128, 255),
            new Color32(165,42,42, 255),
            new Color32(255,0,0, 255),
            new Color32(139,69,19, 255),
            new Color32(205,133,63, 255),
            new Color32(128,128,128, 255),
            new Color32(0, 0, 0, 255)
        };
    }

    void Update()
    {
        if(updateHair)
        {
            SetHair();
            updateHair = false;
        }

        if(updateHairColor)
        {
            SetHairColor();
            updateHairColor = false;
        }
    }

    public void PreviousHair()
    {
        if (selectedHair == 0)
            selectedHair = Hairs.Length - 1;
        else
            selectedHair--;
        SetHair();
    }

    public void NextHair()
    {
        if (selectedHair == Hairs.Length - 1)
            selectedHair = 0;
        else
            selectedHair++;
        SetHair();
    }

    public void PreviousHairColor()
    {
        if (selectedHairColor == 0)
            selectedHairColor = HairColors.Length - 1;
        else
            selectedHairColor--;
        SetHairColor();
    }

    public void NextHairColor()
    {
        if (selectedHairColor == HairColors.Length - 1)
            selectedHairColor = 0;
        else
            selectedHairColor++;
        SetHairColor();
    }

    public void SetHair()
    {
        hair.sprite = Hairs[selectedHair];
        hair.SetNativeSize();
        switch(selectedHair)
        {
            case 0:
                SetHairPosition(-66, 34);
                break;
            case 1:
                SetHairPosition(-65, 35);
                break;
            case 2:
                SetHairPosition(-68, 36);
                break;
            case 3:
                SetHairPosition(-66, 29);
                break;
            case 4:
                SetHairPosition(-66, 25);
                break;
            case 5:
                SetHairPosition(-70, 27);
                break;
            case 6:
                SetHairPosition(-72, 35);
                break;
            case 7:
                SetHairPosition(-72, 37);
                break;
        }
    }

    private void SetHairPosition(float x, float y)
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(x, GetComponent<RectTransform>().anchoredPosition.y);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, y);
    }

    public void SetHairColor()
    {
        hair.color = HairColors[selectedHairColor];
    }
}
