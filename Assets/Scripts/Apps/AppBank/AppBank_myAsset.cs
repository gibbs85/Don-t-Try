using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.EventSystems;
using System;

public class AppBank_myAsset : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    private int codePlayer;
    private double money;
    private double invested;
    private double deposit;
    private double moneyAll;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awake called");
        this.refresh();
        
    }

    public void update()
    {
        Debug.Log("update called");
        this.codePlayer = SystemControl.Instance.player.getCode();
        this.money = SystemControl.Instance.player.getMoney();
        this.invested = SystemControl.Instance.stockControl.getMoneySellAll(this.codePlayer);
        this.deposit = SystemControl.Instance.bank.getSaving(this.codePlayer);

        this.moneyAll = this.money + this.invested + this.deposit;
    }

    public void refresh()
    {
        Debug.Log("refresh called");
        this.update();

        GameObject.Find("Bank1").transform.Find("TextMoney").GetComponentInChildren<TextMeshProUGUI>().text = this.money.ToString("c", numberFormat);
        GameObject.Find("Bank1").transform.Find("TextInvested").GetComponentInChildren<TextMeshProUGUI>().text = this.invested.ToString("c", numberFormat);
        GameObject.Find("Bank1").transform.Find("TextDeposit").GetComponentInChildren<TextMeshProUGUI>().text = this.deposit.ToString("c", numberFormat);
        GameObject.Find("Bank1").transform.Find("TextMoneyAll").GetComponentInChildren<TextMeshProUGUI>().text = this.moneyAll.ToString("c", numberFormat);
    }
}
