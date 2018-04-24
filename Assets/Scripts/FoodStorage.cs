using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodStorage : MonoBehaviour
{
    [SerializeField]
    private GameObject foodBuildig;
    [SerializeField]
    private Text foodCount;
    [SerializeField]
    private float food;
    [SerializeField]
    private float foodGainedInTime;
    [SerializeField]
    private float maxFoodInStorage;

    private int foodValue;


	// Update is called once per frame
	void Update ()
    {
        if (food < maxFoodInStorage)
        {
            food += foodGainedInTime * Time.deltaTime;
            foodValue = (int)food;
        }
        else
        {
            food = maxFoodInStorage;
            foodValue = (int)food;
            Debug.Log(food);
        }
    }
    public void Collected()
    {
        DataHolding.FoodGained = food + DataHolding.FoodGained;
        foodValue = (int)DataHolding.FoodGained;
        foodCount.text = foodValue.ToString();
        food = 0;
        Debug.Log(DataHolding.FoodGained);
    }
}
