using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public Wallet wallet;
    public Text moneyLabel;

    void Update()
    {
        moneyLabel.text = AddLeadingZeros(wallet.getValue());
    }

    private string AddLeadingZeros(int v)
    {
        String result = v + "";
        while(result.Length < 11)
        {
            result = "0" + result;
        }
        return result;
    }
}
