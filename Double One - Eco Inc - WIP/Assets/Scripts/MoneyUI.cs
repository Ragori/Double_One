using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    static public int money;
    public Text moneyText;
    private int PP;
    public Text ppText;
    static private int emissions;
    public Text emissionsText;
    public bool turbine = false;
    public bool solar = false;
    public bool hydro = false;

    public void Start()
    {
        money = 50000;
        PP = 10;
        emissions = 95;

        moneyText.text = "£: " + money;
        ppText.text = "PP: " + PP;
        emissionsText.text = "World Emissons: " + emissions + "%";
    }
    private void Update()
    {

        if (money <= 0)
        {
            money = 0;
        }

        if (Input.GetKeyUp("up"))
        {
            PP += 10;
            ppText.text = "PP: " + PP;

            money += 5000;
            moneyText.text = "£: " + money;


        }

        if (Input.GetKeyUp("down"))
        {
            if (PP > 0)
            {
                PP -= 10;
                ppText.text = "PP: " + PP;
            }

            if (money > 0)
            {
                money -= 5000;
                moneyText.text = "£: " + money;
            }

            

        }

        if (Input.GetKeyUp("left"))
        {   
            if (emissions > 0)
            {
                emissions -= 5;
                emissionsText.text = "World Emissons: " + emissions + "%";
             //   newEmissions = emissions;

            }
        }

        if (Input.GetKeyUp("right"))
        {
            if (emissions < 100)
            {
                emissions += 5;
                emissionsText.text = "World Emissons: " + emissions + "%";
            //    newEmissions = emissions;
            }
        }

    }

    public void RemoveMoney()
    {
        if (turbine == true)
        {
            if (money > 0 && money - 10000 >= 0)
            {
                money -= 10000;
                moneyText.text = "£: " + money;
                AllFalse();
            }
        }

        if (solar == true)
        {
            if (money > 0 && money - 15000 >= 0)
            {
                money -= 15000;
                moneyText.text = "£: " + money;
                AllFalse();
            }
        }

        if (hydro == true)
        {
            if (money > 0 && money - 20000 >= 0)
            {
                money -= 20000;
                moneyText.text = "£: " + money;
                AllFalse();
            }
        }

    }

    public void TurbineTrue()
    {
        turbine = true;
        RemoveMoney();
        
    }

    public void SolarTrue()
    {
        solar = true;
        RemoveMoney();

    }

    public void HydroTrue()
    {
        hydro = true;
        RemoveMoney();

    }

    public void AllFalse()
    {
        turbine = false;
        solar = false;
        hydro = false;
    }
}
