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
        DataHolding.AudienceCount = 76;

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

        while(audience < 75f)
        {
            audience -= audienceLoss * Time.deltaTime;
            audienceValue = (int)audience;
            if (audience == minaudience)
            {
                isHappy = true;
                Debug.Log(true);
                DataHolding.AudienceCount = minaudience;
                SceneManager.LoadScene(0);
            }
        }
        while (audience > 75f)
        {
            audience += audienceLoss * Time.deltaTime;
            audienceValue = (int)audience;
            if (audience == maxaudience)
            {
                isHappy = true;
                Debug.Log(true);
                DataHolding.AudienceCount = maxaudience;
                SceneManager.LoadScene(0);

            }
        }
       
        //if (audience < 75f)
        //{
        //    audience -= audienceLoss * Time.deltaTime;
        //    audienceValue = (int)audience;
           
        //}
        //else if (audience == minaudience)
        //{
        //    isHappy = true;
        //    Debug.Log(true);
        //    DataHolding.AudienceCount = minaudience;
        //    SceneManager.LoadScene(0);
        //}
        //else if (audience > 75f)
        //{
        //    audience += audienceGained * Time.deltaTime;
        //    audienceValue = (int)audience;
        //}
        //else if (DataHolding.AudienceCount == maxaudience)
        //{
        //    DataHolding.AudienceCount = maxaudience;
        //    SceneManager.LoadScene(0);
        //}
        DataHolding.AudienceCount = audience + DataHolding.AudienceCount;
        audienceValue = (int)DataHolding.AudienceCount;
        audienceText.text = audienceValue.ToString();
        audience = 0;

    }

}
