using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public int money;
    public Text moneyText;
    private int PP;
    public Text ppText;
    private int emissions;
    public Text emissionsText;
    public bool turbine = false;
    private int newEmissions;

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
        //emissions = newEmissions;

        if (Input.GetKeyUp("up"))
        {
            PP += 10;
            ppText.text = "PP: " + PP;

            money += 50000;
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
                money -= 50000;
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
        
        money -= 10000;
        moneyText.text = "£: " + money;

     //   emissions -= 5;
     //   emissionsText.text = "World Emissons: " + emissions + "%";
    }

    public void TurbineTrue()
    {
        turbine = true;
    }
}
