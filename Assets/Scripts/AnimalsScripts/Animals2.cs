using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals2 : MonoBehaviour
{
    public GameObject foodIcon;
    public GameObject MedicalIcon;
    public float amountofAudienceGained;
    public float amountofFoodloss;
    public float amountofMedicalLoss;
    private Coroutine currentCoroutine = null;
    private float[] stages = new float[] { 85f, 77f, 70f, 60f, 55f, 45f, 30f, 25f, 20f, 10f, 5f, 0f };
    private int currentStage = 0;

    private void Start()
    {
        foodIcon.SetActive(false);
        MedicalIcon.SetActive(false);
    }
    IEnumerator AutoClearCoroutine()
    {
        while (DataHolding.AudienceCount > 0)
        {
            if (currentCoroutine != null)
            {
                yield return currentCoroutine;
                currentCoroutine = null;
            }
            else
                yield return null;
        }
    }
    void StopPattern()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
    }
    void StartPattern(IEnumerator aCoroutine)
    {
        StopPattern();
        currentCoroutine = StartCoroutine(aCoroutine);
    }
    IEnumerator StartCoordinator()
    {
        StartCoroutine(AutoClearCoroutine());
        while (DataHolding.AudienceCount > 0)
        {
            if (DataHolding.AudienceCount < stages[currentStage])
            {
                StopPattern();
                if (currentStage < stages.Length)
                    currentStage++;

            }
            else if (currentCoroutine == null)
            {
                switch (currentStage)
                {
                    case 0:
                        StartPattern(Illness());
                        break;
                    case 1:
                        StartPattern(Hungry());
                        break;
                    case 2:
                        StartPattern(Illness());
                        break;
                    case 3:
                        StartPattern(Hungry());
                        break;
                    case 4:
                        StartPattern(Illness());
                        break;
                    case 5:
                        StartPattern(Hungry());
                        break;
                    case 6:
                        StartPattern(Illness());
                        break;
                    case 7:
                        StartPattern(Hungry());
                        break;
                    case 8:
                        StartPattern(Illness());
                        break;
                    case 9:
                        StartPattern(Hungry());
                        break;
                    case 10:
                        StartPattern(Illness());
                        break;
                    case 11:
                        StartPattern(Hungry());
                        break;
                }
            }
            else
            {
                StopPattern();
                if (currentStage > stages.Length)
                {
                    currentStage--;
                }
            }
            yield return null;
        }
    }
    IEnumerator Hungry()
    {
        foodIcon.SetActive(true);
        MedicalIcon.SetActive(false);
        Debug.Log("Huungry");
        if (Input.GetKeyDown(KeyCode.Alpha1) && DataHolding.FoodGained >= amountofFoodloss)
        {
            DataHolding.AudienceCount += amountofAudienceGained;
            DataHolding.FoodGained -= amountofFoodloss;
        }
        yield return null;
    }
    IEnumerator Illness()
    {
        foodIcon.SetActive(false);
        MedicalIcon.SetActive(true);
        Debug.Log("Sick");
        if (Input.GetKeyDown(KeyCode.Alpha2) && DataHolding.MedicalGained >= amountofMedicalLoss)
        {
            DataHolding.AudienceCount += amountofAudienceGained;
            DataHolding.MedicalGained -= amountofMedicalLoss;
        }
        yield return null;

    }
    private void Update()
    {
        StartCoroutine(StartCoordinator());
    }
}
