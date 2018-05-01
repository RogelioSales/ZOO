using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject moneyBuildig;
    
    public Text moneyCount;
    [SerializeField]
    private float money;
    [SerializeField]
    private float moneyGainedInTime;
    [SerializeField]
    private float maxMoneyInStorage;

    private int moneyValue;
	// Update is called once per frame
	void Update ()
    {
        if (money < maxMoneyInStorage)
        {
            money += moneyGainedInTime * Time.deltaTime;
            moneyValue = (int)money;
        }
        else
        {
            money = maxMoneyInStorage;
            moneyValue = (int)money;
            Debug.Log(money);
        }
	}
    public void Collected()
    {
        DataHolding.MoneyGained = money + DataHolding.MoneyGained;
        moneyValue = (int)DataHolding.MoneyGained;
        moneyCount.text = moneyValue.ToString();
        money = 0;

    }

}
