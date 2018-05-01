using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    [SerializeField]
    private GameObject purchasePanel;
    [SerializeField]
    private Image selectedImage;
    [SerializeField]
    private Text animalText;
    [SerializeField]
    private List<SelectionScript> animalList;
   

    private int itemSpot;

    // Use this for initialization
    void Start()
    {
        purchasePanel.SetActive(false);   
   
    }
   

    // Update is called once per frame
    void Update()
    {

    }
    public void Purchase()
    {
        
        AnimalRemoved(animalList[itemSpot],this);
        purchasePanel.SetActive(false);
    }
    public void LeftClick()
    {
        if (itemSpot > 0)
        {
            itemSpot--;
            SelectionScript selection = animalList[itemSpot];
            animalText.text = selection.animalName;
            selectedImage.sprite = selection.icon;
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
        }
    }

    public void Open()
    {
        purchasePanel.SetActive(true);
        Time.timeScale = 0;


    }
    public void Close()
    {
        purchasePanel.SetActive(false);
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
