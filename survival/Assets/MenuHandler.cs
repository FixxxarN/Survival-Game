using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MenuHandler : MonoBehaviour
{
    public GameObject TheOneTitle;
    public GameObject SelectCharacterTitle;
    public GameObject CreateCharacterTitle;
    public GameObject SelectWorldTitle;
    public GameObject CreateWorldTitle;
    public GameObject ButtonHolderMainMenu;
    public GameObject ButtonHolderSelection;
    public GameObject ButtonHolderCharacterSelection;
    public GameObject ButtonHolderCharacterCreation;
    public GameObject ButtonHolderWorldSelection;
    public GameObject ButtonHolderWorldCreation;
    public GameObject ButtonHolderAchievements;
    public GameObject ButtonHolderSettings;

    public CharacterInformation CharacterInformation;

    void Update()
    {
        switch(MenuStateHandler.currentMenuState)
        {
            case MenuState.mainMenu:
                TheOneTitle.SetActive(true);
                ButtonHolderMainMenu.SetActive(true);
                ButtonHolderSelection.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(false);
                ButtonHolderAchievements.SetActive(false);
                ButtonHolderSettings.SetActive(false);
                SelectCharacterTitle.SetActive(false);
                ButtonHolderCharacterCreation.SetActive(false);
                CreateCharacterTitle.SetActive(false);
                CharacterInformation.enabled = false;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 850;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 480;
                break;
            case MenuState.selection:
                TheOneTitle.SetActive(true);
                ButtonHolderSelection.SetActive(true);
                ButtonHolderMainMenu.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(false);
                ButtonHolderAchievements.SetActive(false);
                ButtonHolderSettings.SetActive(false);
                SelectCharacterTitle.SetActive(false);
                ButtonHolderCharacterCreation.SetActive(false);
                CreateCharacterTitle.SetActive(false);
                CharacterInformation.enabled = false;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 850;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 480;
                break;
            case MenuState.characterSelection:
                TheOneTitle.SetActive(false);
                ButtonHolderSelection.SetActive(false);
                ButtonHolderMainMenu.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(true);
                ButtonHolderAchievements.SetActive(false);
                ButtonHolderSettings.SetActive(false);
                SelectCharacterTitle.SetActive(true);
                ButtonHolderCharacterCreation.SetActive(false);
                CreateCharacterTitle.SetActive(false);
                CharacterInformation.enabled = true;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 425;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 240;
                break;
            case MenuState.characterCreation:
                TheOneTitle.SetActive(false);
                ButtonHolderSelection.SetActive(false);
                ButtonHolderMainMenu.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(false);
                ButtonHolderAchievements.SetActive(false);
                ButtonHolderSettings.SetActive(false);
                SelectCharacterTitle.SetActive(false);
                ButtonHolderCharacterCreation.SetActive(true);
                CreateCharacterTitle.SetActive(true);
                CharacterInformation.enabled = false;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 425;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 240;
                break;
            case MenuState.worldSelection:
                TheOneTitle.SetActive(false);
                ButtonHolderSelection.SetActive(false);
                ButtonHolderMainMenu.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(false);
                ButtonHolderAchievements.SetActive(false);
                ButtonHolderSettings.SetActive(false);
                SelectCharacterTitle.SetActive(false);
                ButtonHolderCharacterCreation.SetActive(false);
                CreateCharacterTitle.SetActive(false);
                CharacterInformation.enabled = false;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 850;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 480;
                break;
            case MenuState.worldCreation:
                break;
            case MenuState.achievements:
                TheOneTitle.SetActive(false);
                ButtonHolderSelection.SetActive(false);
                ButtonHolderMainMenu.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(false);
                ButtonHolderAchievements.SetActive(true);
                ButtonHolderSettings.SetActive(false);
                SelectCharacterTitle.SetActive(false);
                ButtonHolderCharacterCreation.SetActive(false);
                CreateCharacterTitle.SetActive(false);
                CharacterInformation.enabled = false;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 850;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 480;
                break;
            case MenuState.settings:
                TheOneTitle.SetActive(false);
                ButtonHolderSelection.SetActive(false);
                ButtonHolderMainMenu.SetActive(false);
                ButtonHolderCharacterSelection.SetActive(false);
                ButtonHolderAchievements.SetActive(false);
                ButtonHolderSettings.SetActive(true);
                SelectCharacterTitle.SetActive(false);
                ButtonHolderCharacterCreation.SetActive(false);
                CreateCharacterTitle.SetActive(false);
                CharacterInformation.enabled = false;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionX = 850;
                Camera.main.GetComponent<PixelPerfectCamera>().refResolutionY = 480;
                break;
            default:
                break;
        }
    }

    public void GoToMainMenu()
    {
        MenuStateHandler.currentMenuState = MenuState.mainMenu;
    }

    public void GoToSelection()
    {
        MenuStateHandler.currentMenuState = MenuState.selection;
    }

    public void GoToCharacterSelection()
    {
        MenuStateHandler.currentMenuState = MenuState.characterSelection;
    }

    public void GoToCharacterCreation()
    {
        MenuStateHandler.currentMenuState = MenuState.characterCreation;
    }

    public void GoToAchievements()
    {
        MenuStateHandler.currentMenuState = MenuState.achievements;
    }

    public void GoToSettings()
    {
        MenuStateHandler.currentMenuState = MenuState.settings;
    }
}
