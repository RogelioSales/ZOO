using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    [SerializeField]
    private GameObject purchasePanel;
    [SerializeField]
    private

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
        purchasePanel.SetActive(true);
        Time.timeScale = 0;


    }
    public void Close()
    {
        purchasePanel.SetActive(false);
        Time.timeScale = 1;

    }
}
