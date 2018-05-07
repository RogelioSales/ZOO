using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text audienceText;
    [SerializeField]
    private float audience;
    [SerializeField]
    private float minaudience;
    [SerializeField]
    private float maxaudience;
    [SerializeField]
    private float audienceGained;
    [SerializeField]
    private float audienceLoss;
    private MoneyCollector money;
    private MedicalCenter medicine;
    private FoodStorage food;
    private int moneyValue;
    private int foodValue;
    private int medicineValue;
    private int audienceValue;
    private bool isHappy;
    private bool isOver;


    private void Awake()
    {
        money = FindObjectOfType<MoneyCollector>();
        medicine = FindObjectOfType<MedicalCenter>();
        food = FindObjectOfType<FoodStorage>();  
    }
    private void Start()
    {
        isHappy = false;
        DataHolding.MoneyGained = 30;
        DataHolding.FoodGained = 10;
        DataHolding.MedicalGained = 5;
        DataHolding.AudienceCount = 20;

        audienceValue = (int)DataHolding.AudienceCount;
        moneyValue = (int)DataHolding.MoneyGained;
        foodValue = (int)DataHolding.FoodGained;
        medicineValue = (int)DataHolding.MedicalGained;

        audienceText.text = audienceValue.ToString();
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
        if (audienceValue < 75f)
        {
            audience -= audienceLoss * Time.deltaTime;
            audienceValue = (int)audience;
            DataHolding.AudienceCount = audience + DataHolding.AudienceCount;
            audienceValue = (int)DataHolding.AudienceCount;
            audienceText.text = audienceValue.ToString();
            audience = 0;
            if (DataHolding.AudienceCount <= minaudience)
            {
                Debug.Log("Lost");
                SceneManager.LoadScene(0);
            }
        }
        else if (DataHolding.AudienceCount > 75f)
        {
            audience += audienceGained * Time.deltaTime;
            audienceValue = (int)audience;
            DataHolding.AudienceCount = audience + DataHolding.AudienceCount;
            audienceValue = (int)DataHolding.AudienceCount;
            audienceText.text = audienceValue.ToString();
            audience = 0;
            if (DataHolding.AudienceCount >= maxaudience)
            {
                Debug.Log("Won");
                SceneManager.LoadScene(0);
            }
        }
        
    }
 

}
