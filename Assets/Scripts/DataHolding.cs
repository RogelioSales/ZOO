using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolding
{
    private static string nameOfTheZoo;

    public static string NameOfTheZoo
    {
        get { return nameOfTheZoo; }
        set { nameOfTheZoo = value; }
    }
    private static float moneyGained;

    public static float MoneyGained
    {
        get { return moneyGained; }
        set { moneyGained = value; }
    }
    private static float foodGained;

    public static float FoodGained
    {
        get { return foodGained; }
        set { foodGained = value; }
    }
    private static float medicalGained;

    public static float MedicalGained
    {
        get { return medicalGained; }
        set { medicalGained = value; }
    }
}
