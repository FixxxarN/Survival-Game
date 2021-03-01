using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInformation : MonoBehaviour
{
    public GameObject CharactersHandler;
    public Image CharacterInformationContainer;
    public Text CharacterName;
    public Text CharacterLevel;
    public Text CharacterXP;
    public Text CharacterMoney;

    void Start()
    {
        CharacterInformationContainer.gameObject.SetActive(false);
    }

    void Update()
    {
        foreach(Transform character in CharactersHandler.GetComponent<CharactersHandler>().Characters.transform)
        {
            if(character.gameObject.GetComponent<NPC>().IsMouseOver)
            {
                CharacterInformationContainer.rectTransform.position = Camera.main.WorldToScreenPoint(new Vector3(0, 0.4f, 0) + character.gameObject.transform.position);
                CharacterInformationContainer.gameObject.SetActive(true);
                CharacterName.text = character.gameObject.GetComponent<NPC>().PlayerData.Name.ToUpper();
                CharacterLevel.text = "LEVEL " + character.gameObject.GetComponent<NPC>().PlayerData.Level.ToString();
                CharacterXP.text = character.gameObject.GetComponent<NPC>().PlayerData.XP.ToString();
                CharacterMoney.text = "$" + character.gameObject.GetComponent<NPC>().PlayerData.Money.ToString();
                break;
            }
            else
            {
                CharacterInformationContainer.gameObject.SetActive(false);
                CharacterName.text = "";
            }
        }
    }
}
