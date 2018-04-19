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
}
