using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameOFZoo : MonoBehaviour
{
    [SerializeField]
    private Text nameZoo;

    private MainMenu mainMenu;
    // Use this for initialization
    void Start ()
    {
        nameZoo.text = DataHolding.NameOfTheZoo;
    }

}

    

    
 

   
