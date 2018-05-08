using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
   // public GameObject[] buttons;
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
    private List<BuildingScript> buildingList;
    [SerializeField]
    private List<SelectionScript> animalList;
    
    private int itemSpot;
    private int buildingSpot;

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
        for (int b = 0; b < buildingList.Count; b++)
        {
            BuildingScript buildings = buildingList[b];
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
        BuildingScript buildings = buildingList[buildingSpot];

        if (DataHolding.MoneyGained >= selection.price)
        {
            DataHolding.MoneyGained -= selection.price;
            DataHolding.AudienceCount++;
            soldOut.SetActive(true);
            
            buildings.buttons.SetActive(false);
            GameObject animalbuilding = Instantiate(selection.animalBuilding, buildings.spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
            AnimalRemoved(animalList[itemSpot], this);
            ButtonRemoval(buildingList[buildingSpot], this);
            purchasePanel.SetActive(false);
            Time.timeScale = 1;

            //for (buildingSpot = 0; buildingSpot < buildingList.Count; buildingSpot++)
            //{
            //    if (buildingSpot == 0)
            //    {
                    
            //    }
            //    else if (buildingSpot == 1)
            //    {
            //        BuildingScript buildings = buildingList[buildingSpot];
            //        buildings.buttons.SetActive(false);
            //        GameObject animalbuildin = Instantiate(selection.animalBuilding, buildings.spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
            //        buildingSpot++;
            //        AnimalRemoved(animalList[itemSpot], this);
            //        purchasePanel.SetActive(false);
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
            NotEnough.enabled = false;
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
            NotEnough.enabled = false;
        }
    }
    public void Open()
    {
        purchasePanel.SetActive(true);
        Time.timeScale = 0;
        NotEnough.enabled = false;
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
    private void ButtonRemoval(BuildingScript buttonRemoved, SignPost signPost)
    {
        for (int i = signPost.buildingList.Count - 1; i >= 0; i--)
        {
            if(signPost.buildingList[i] == buttonRemoved)
            {
                signPost.buildingList.RemoveAt(i);
            }
        }
    }
}
