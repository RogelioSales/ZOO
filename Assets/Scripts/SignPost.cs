using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    public GameObject[] buttons;
    [SerializeField]
    private GameObject purchasePanel;
    [SerializeField]
    private Image selectedImage;
    [SerializeField]
    private GameObject soldOut;
    [SerializeField]
    private Text animalText;
    [SerializeField]
    private Button purchaseButton;
    [SerializeField]
    private Text NotEnough;
    [SerializeField]
    private List<SelectionScript> animalList;

    private BuildingScript buildings;
    private int itemSpot;

    // Use this for initialization
    void Start()
    {
        purchasePanel.SetActive(false);
        soldOut.SetActive(false);
        NotEnough.enabled = false;
   
    } 
    private void Refresh()
    {
        for(int i = 0; i < animalList.Count; i++)
        {
            SelectionScript selection = animalList[i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        Refresh();
    }
    public void Purchase()
    {
        SelectionScript selection = animalList[itemSpot];
        if (DataHolding.MoneyGained >= selection.price)
        {
            DataHolding.MoneyGained -= selection.price;
            DataHolding.AudienceCount++;
            soldOut.SetActive(true);
            AnimalRemoved(animalList[itemSpot], this);
            purchasePanel.SetActive(false);

            //for (int i = 0; i < buttons.Length; i++)
            //{
            //    i = 0;
            //    if (i == 0)
            //    {                  
            //    // GameObject animalBuildin = Instantiate(selection.animalBuilding, new Vector2(2, 2), Quaternion.Euler(2,3,5));
            //        AnimalRemoved(animalList[itemSpot], this);
            //        purchasePanel.SetActive(false);
            //    }
            //    else if (i == 1 )
            //    {
            //        AnimalRemoved(animalList[itemSpot], this);
            //        purchasePanel.SetActive(false);
            //    }
            //    else if (i == 2)
            //    {
            //        AnimalRemoved(animalList[itemSpot], this);
            //        purchasePanel.SetActive(false);
            //    }
            //    else if (buttons[3])
            //    {
            //        AnimalRemoved(animalList[itemSpot], this);
            //        purchasePanel.SetActive(false);
            //    }
            //    else if (buttons[4])
            //    {
            //    }
            //}
        }
        else
        {
            NotEnough.enabled = true;
        }
    }
    public void LeftClick()
    {
        if (itemSpot > 0)
        {
            itemSpot--;
            SelectionScript selection = animalList[itemSpot];
            animalText.text = selection.animalName;
            selectedImage.sprite = selection.icon;
            purchaseButton.interactable = true;
            soldOut.SetActive(false);
        }
    }
    public void RightClick()
    { 
        if(itemSpot < animalList.Count - 1)
        {
            itemSpot++;
            SelectionScript selection = animalList[itemSpot];
            animalText.text = selection.animalName;
            selectedImage.sprite = selection.icon;
            purchaseButton.interactable = true;
            soldOut.SetActive(false);
        }
    }
    public void Open()
    {
        purchasePanel.SetActive(true);
        Time.timeScale = 0;
        purchaseButton.interactable = false;
        
    }
    public void Close()
    {
        purchasePanel.SetActive(false);
        NotEnough.enabled = false;
        Time.timeScale = 1;

    }
    private void AnimalRemoved(SelectionScript selectionRemove, SignPost signpost)
    {
        for (int i = signpost.animalList.Count -1; i >= 0; i--)
        {
            if(signpost.animalList[i] == selectionRemove)
            {
                signpost.animalList.RemoveAt(i);
            }
        }
    }
}
