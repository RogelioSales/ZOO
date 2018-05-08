using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Button okButton;
    [SerializeField]
    private GameObject CreditsPanel;
    

    private static string nameForZoo;
    private bool named;

    

    // Use this for initialization
    void Start ()
    {
        named = false;
        mainMenuPanel.SetActive(true);
        startPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (named == true)
            okButton.interactable = true;
        else
            okButton.interactable = false;
    }
    public void Play()
    {
        mainMenuPanel.SetActive(false);
        startPanel.SetActive(true);
        okButton.interactable = false;
    }
       public void InputText()
    {
        if (inputField.characterLimit == 16)
        {
            named = true;           
            nameForZoo = inputField.text;
            DataHolding.NameOfTheZoo = nameForZoo;
        

           
        }
        else
            named = false;
    }
    public void Cancel()
    {
        startPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void OKButton()
    {
        SceneManager.LoadScene(1);

    }
    public void Back()
    {
        mainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
    public void Credits()
    {
        mainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}