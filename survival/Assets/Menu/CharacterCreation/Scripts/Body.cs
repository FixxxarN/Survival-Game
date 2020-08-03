using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
    public Sprite Male;
    public Sprite Female;

    public Sprite[] Sprites;
    public Color32[] SkinColors;

    public Image image;
    public int selectedGender = 0;
    public int selectedColor = 0;

    public bool updateSprite = false;
    public bool updateSkinColor = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Sprites = new Sprite[2];
        Sprites[0] = Male;
        Sprites[1] = Female;

        SkinColors = new Color32[] {
            new Color32(254, 253, 253, 255),
            new Color32(245, 234, 223, 255),
            new Color32(235, 214, 193, 255),
            new Color32(220, 185, 149, 255),
            new Color32(206, 155, 105, 255),
            new Color32(190, 126, 62, 255),
            new Color32(160, 106, 52, 255),
            new Color32(131, 87, 43, 255),
            new Color32(101, 67, 33, 255),
            new Color32(86, 57, 28, 255),
            new Color32(71, 47, 23, 255),
            new Color32(57, 38, 19, 255)
        };
    }

    void Update()
    {
        if(updateSprite)
        {
            SetSprite();
            updateSprite = false;
        }

        if(updateSkinColor)
        {
            SetColor();
            updateSkinColor = false;
        }
    }

    public void PreviousGender()
    {
        if (selectedGender == 0)
            selectedGender = 1;
        else
            selectedGender--;
        SetSprite();

    }

    public void NextGender()
    {
        if (selectedGender == Sprites.Length - 1)
            selectedGender = 0;
        else
            selectedGender++;
        SetSprite();
    }

    public void PreviousColor()
    {
        if (selectedColor == 0)
            selectedColor = SkinColors.Length - 1;
        else
            selectedColor--;
        SetColor();
    }

    public void NextColor()
    {
        if (selectedColor == SkinColors.Length - 1)
            selectedColor = 0;
        else
            selectedColor++;
        SetColor();
    }

    public void SetSprite()
    {
        image.sprite = Sprites[selectedGender];
    }

    public void SetColor()
    {
        image.color = SkinColors[selectedColor];
    }
}
