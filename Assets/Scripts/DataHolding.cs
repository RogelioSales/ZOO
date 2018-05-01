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
    private static float audienceCount;
    public static float AudienceCount
    {
        get { return audienceCount; }
        set { audienceCount = value; }
    }
    private static string zebra;
    public static string Zebra
    {
        get { return zebra; }
        set { zebra = value; }
    }
    private static string lion;
    public static string Lion
    {
        get { return lion; }
        set { lion = value; }
    }
}
