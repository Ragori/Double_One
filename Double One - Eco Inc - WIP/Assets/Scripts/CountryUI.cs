using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryUI : MonoBehaviour
{

    public int countryEmissions;
    public Text countryEmissionsText;
    private int emissionPercent;

    // Start is called before the first frame update
    void Start()
    {
        countryEmissions = 100;
        countryEmissionsText.text = "UK Emissions: " + countryEmissions;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            countryEmissions += 50;
            countryEmissionsText.text = "UK Emissions: " + countryEmissions;


        }

        if (Input.GetKeyUp("z"))
        {
            if (countryEmissions > 0)
            {
                countryEmissions -= 50;
                countryEmissionsText.text = "UK Emissions: " + countryEmissions;
            }

        }




    }

    public void turbineCheck()
    {

        countryEmissions -= 50;
        countryEmissionsText.text = "UK Emissions: " + countryEmissions;

    }
}
