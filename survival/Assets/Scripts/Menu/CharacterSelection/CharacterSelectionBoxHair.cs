using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.CharacterSelection
{
    public class CharacterSelectionBoxHair : MonoBehaviour
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
            if (updateHair)
            {
                SetHair();
                updateHair = false;
            }

            if (updateHairColor)
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
            hair.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            switch (selectedHair)
            {
                case 0:
                    SetHairPosition(0.38f, 17.2f);
                    break;
                case 1:
                    SetHairPosition(0.91f, 17.63f);
                    break;
                case 2:
                    SetHairPosition(-0.3f, 18);
                    break;
                case 3:
                    SetHairPosition(0.35f, 14.4f);
                    break;
                case 4:
                    SetHairPosition(0.54f, 12.33f);
                    break;
                case 5:
                    SetHairPosition(-1.61f, 13.76f);
                    break;
                case 6:
                    SetHairPosition(-2.46f, 17.61f);
                    break;
                case 7:
                    SetHairPosition(-2.67f, 18.6f);
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
}
