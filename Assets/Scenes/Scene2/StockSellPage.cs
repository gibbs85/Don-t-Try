using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.EventSystems;
using System;

public class StockSellPage : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    public string stockName;
    public int stockPrice;
    public int stockCount;
    public int stockPriceCaled;
    public int stockCountOwn;
    public string inputProcessed;

    public void init()
    {
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        //this.stockName = GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getName();
        this.stockName = GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStockName();
        this.stockPrice = (int)(GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getPrice());
        this.stockCount = 0;

        this.stockCountOwn = SystemControl.Instance.stockControl.getCountOwn(SystemControl.Instance.player.getCode(), SystemControl.Instance.stockControl.getStock(this.stockName).getCode());

        this.stockPriceCaled = 0;
        this.inputProcessed = "0";


        Debug.Log("StockSellPage.init() : this.stockName : " + this.stockName);



        GameObject.Find("StockSellPage").transform.Find("TextStockSellPrice").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPrice.ToString("c", numberFormat);
        GameObject.Find("StockSellPage").transform.Find("TextStockSellCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCount + "??";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellOwnCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCountOwn + "??";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPriceCaled.ToString("c", numberFormat);
    }

    void OnEnable()
    {
        this.refresh();
    }

    public void refresh()
    {
        Debug.Log("StockSellPage.refresh() : this.stockName : " + this.stockName);
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.stockPriceCaled = this.stockPrice * this.stockCount;
        this.stockCountOwn = SystemControl.Instance.stockControl.getCountOwn(SystemControl.Instance.player.getCode(), SystemControl.Instance.stockControl.getStock(this.stockName).getCode());

        GameObject.Find("StockSellPage").transform.Find("TextStockSellCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCount + "??";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellOwnCount").GetComponentInChildren<TextMeshProUGUI>().text = this.stockCountOwn + "??";
        GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().text = this.stockPriceCaled.ToString("c", numberFormat);

        //if (this.stockPriceCaled > GameObject.Find("Player").GetComponent<Player>().GetMoney())
        //{
        //    GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        //}
        //else
        //{
        //    GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
        //}

        if (this.stockPriceCaled < 100000000) // 1?? ?̸?
            GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
        else if (this.stockPriceCaled < 1000000000) // 10?? ?̸?
            GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 14;
        else
            GameObject.Find("StockSellPage").transform.Find("TextStockSellPriceCaled").GetComponentInChildren<TextMeshProUGUI>().fontSize = 13;
    }

    public void inputHandle(string input)
    {
        if (input.Equals("99"))
        {
            if (this.inputProcessed.Equals("0"))
                return;

            if (this.inputProcessed.Length == 1)
            {
                this.inputProcessed = "0";
                this.stockCount = Int32.Parse(this.inputProcessed);
                this.refresh();
                return;
            }

            this.inputProcessed = this.inputProcessed.Substring(0, this.inputProcessed.Length - 1);
            this.stockCount = Int32.Parse(this.inputProcessed);

            this.refresh();
            return;
        }

        if (this.inputProcessed.Length > 2)
            return;


        if (this.inputProcessed.Equals("0"))
        {
            this.inputProcessed = input;
            this.stockCount = Int32.Parse(this.inputProcessed);
            this.refresh();
            return;
        }

        this.inputProcessed += input;

        this.stockCount = Int32.Parse(this.inputProcessed);
        this.refresh();
    }
    
    public void SellConfirmClicked()
    {
        if (this.stockCount > this.stockCountOwn) // ?Ǹ??? ?? ?ִ? ?? ????
            return;
        if (SystemControl.Instance.player.exhaustFatigue(1) == false)
            return;

        SystemControl.Instance.stockControl.sellStock(SystemControl.Instance.player, GameObject.Find("AppStock").transform.Find("StockDetail").transform.Find("StockDetailScript").GetComponent<StockDetailScript>().getStock().getCode(), this.stockCount);
        //Player.player.SetMoney(Player.player.GetMoney() + this.stockPriceCaled);
        //GameObject.Find("SystemControl").GetComponent<SystemControl>().player.spendMoney(-this.stockPriceCaled);
        this.refresh();
    }
}
