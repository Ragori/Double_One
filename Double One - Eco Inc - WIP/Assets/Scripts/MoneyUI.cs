using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public int money;
    public Text moneyText;
    private int PP = 10;
    public Text ppText;
    private int emissions = 95;
    public Text emissionsText;
    private bool turbine = false;

    private void Start()
    {
        money = 50000;
    }
    private void Update()
    {
        moneyText.text = "£: " + money;
        ppText.text = "PP: " + PP;
        emissionsText.text = "World Emissons: " + emissions + "%";


        if (Input.GetKey("up"))
        {
            PP += 10;
            money += 50000;

        }


    }

    public void RemoveMoney()
    {
        
        money -= 10000;
        
    }

    public void TurbineTrue()
    {
        turbine = true;
    }
}
