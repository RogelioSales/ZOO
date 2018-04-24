using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MedicalCenter : MonoBehaviour
{
    [SerializeField]
    private GameObject medicalBuildig;
    [SerializeField]
    private Text medicalCount;
    [SerializeField]
    private float medical;
    [SerializeField]
    private float medicalGainedInTime;
    [SerializeField]
    private float maxMedicalInStorage;

    private int medicalValue;
    // Update is called once per frame
    void Update ()
    {
        if (medical < maxMedicalInStorage)
        {
            medical += medicalGainedInTime * Time.deltaTime;
            medicalValue = (int)medical;
        }
        else
        {
            medical = maxMedicalInStorage;
            medicalValue = (int)medical;
            Debug.Log(medical);
        }
    }
    public void Collected()
    {
        DataHolding.MedicalGained = medical + DataHolding.MedicalGained;
        medicalValue = (int)DataHolding.MedicalGained;
        medicalCount.text = medicalValue.ToString();
        medical= 0;
        Debug.Log(DataHolding.MedicalGained);
    }

}
