using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour{

 [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject developerInfo;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button aboutButton;
    public Button developerInfoButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        developerInfoButton.onClick.AddListener(EnableDeveloperInfoButton);
        aboutButton.onClick.AddListener(EnableAbout);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }
        

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        developerInfo.SetActive(false);
        about.SetActive(false);
    }

    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        developerInfo.SetActive(false);
        about.SetActive(true);
    }

    public void EnableDeveloperInfoButton()
    {
        mainMenu.SetActive(false);
        developerInfo.SetActive(true);
        about.SetActive(false);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        developerInfo.SetActive(false);
        about.SetActive(false);
    }

    
}




