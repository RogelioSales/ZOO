using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private MoneyCollector money;
    private MedicalCenter medicine;
    private FoodStorage food;
    private int moneyValue;
    private int foodValue;
    private int medicineValue;
    private int audienceValue;
   
    private void Awake()
    {
        money = FindObjectOfType<MoneyCollector>();
        medicine = FindObjectOfType<MedicalCenter>();
        food = FindObjectOfType<FoodStorage>();  
    }
    private void Start()
    {
        DataHolding.MoneyGained = 30;
        DataHolding.FoodGained = 10;
        DataHolding.MedicalGained = 5;

        moneyValue = (int)DataHolding.MoneyGained;
        foodValue = (int)DataHolding.FoodGained;
        medicineValue = (int)DataHolding.MedicalGained;

        medicine.medicalCount.text = medicineValue.ToString();
        food.foodCount.text = foodValue.ToString();
        money.moneyCount.text = moneyValue.ToString();

    }
    private void Update()
    {
        moneyValue = (int)DataHolding.MoneyGained;
        foodValue = (int)DataHolding.FoodGained;
        medicineValue = (int)DataHolding.MedicalGained;
        medicine.medicalCount.text = medicineValue.ToString();
        food.foodCount.text = foodValue.ToString();
        money.moneyCount.text = moneyValue.ToString();
    }
}
