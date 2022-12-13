using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;

public class StockListOwned : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    private double moneySpentAll;
    private double moneySellAll;
    private double moneyProfit;
    private double profitRate;

    public void init()
    {
        //Debug.Log("StockListOwned.init()");
        this.refresh();
    }

    void OnEnable()
    {
        //Debug.Log("StockListOwned.OnEnable()");
        this.refresh();
    }

    public double GetMoneySellAll()
    {
        return moneySpentAll;
    }

    public void refresh()
    {
        //Debug.Log("StockListOwned.refresh()");
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        this.moneySpentAll = SystemControl.Instance.stockControl.getMoneyBought(SystemControl.Instance.player.getCode());
        this.moneySellAll = SystemControl.Instance.stockControl.getMoneySellAll(SystemControl.Instance.player.getCode());
        this.moneyProfit = this.moneySellAll - this.moneySpentAll;
        this.profitRate = ((double)this.moneyProfit / (double)this.moneySpentAll) * 100;

        GameObject.Find("StockListOwnMoneySpentAll").GetComponentInChildren<TextMeshProUGUI>().text = this.moneySpentAll.ToString("c", numberFormat);
        GameObject.Find("StockListOwnMoneySellAll").GetComponentInChildren<TextMeshProUGUI>().text = this.moneySellAll.ToString("c", numberFormat); ;
        GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().text =
            this.moneyProfit.ToString("c", numberFormat) + "(" + this.profitRate.ToString("F2") + "%)";

        if (this.profitRate > 0)
        {
            GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        }
        else if (profitRate < 0)
        {
            GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
        }
        else
        {
            GameObject.Find("StockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
        }


        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }


        //for (int i = 0; i < SystemControl.Instance.stockControl.getCountOwn(SystemControl.Instance.player.getCode()); i++) // �߿�.
        foreach (StockBought stockbought in SystemControl.Instance.stockControl.getListStocksOwnMerged(SystemControl.Instance.player.getCode()))
        {
            Stock stock = SystemControl.Instance.stockControl.getStock(stockbought.stockCode);
            int playerCode = SystemControl.Instance.player.getCode();
            string name = stock.getName();
            double price = stock.getPrice();
            double avg = SystemControl.Instance.stockControl.getMoneyAvg(playerCode, stock.getCode());
            double bought = SystemControl.Instance.stockControl.getMoneyBought(playerCode, stock.getCode());
            double sell = SystemControl.Instance.stockControl.getMoneySellAll(playerCode, stock.getCode());
            int count = SystemControl.Instance.stockControl.getCountOwn(playerCode, stock.getCode());
            double profit = sell - bought;
            double profitRate = profit / bought * 100;
            double rateDay = SystemControl.Instance.stockControl.getRateDay(stock.getCode(), SystemControl.Instance.world.getTime());

            GameObject btn = Resources.Load<GameObject>("Prefabs/BtnContentStockListOwn");
            //GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("Viewport").transform.Find("Content"));
            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("AppStock").transform.Find("StockListOwned").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));
            //Debug.Log("Instanciated.");
            Instance.transform.Find("TextStockListOwnName").GetComponentInChildren<TextMeshProUGUI>().text = name;
            Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().text = price.ToString("c", numberFormat) + "(" + rateDay.ToString("F2") + "%)";
            Instance.transform.Find("TextStockListOwnAvg").GetComponentInChildren<TextMeshProUGUI>().text = "�� ��ܰ�: " + avg.ToString("c", numberFormat);
            Instance.transform.Find("TextStockListOwnMoneyBought").GetComponentInChildren<TextMeshProUGUI>().text = "���Աݾ�: " + bought.ToString("c", numberFormat);
            Instance.transform.Find("TextStockListOwnMoneySell").GetComponentInChildren<TextMeshProUGUI>().text = "�򰡱ݾ�: " + sell.ToString("c", numberFormat);
            Instance.transform.Find("TextStockListOwnCount").GetComponentInChildren<TextMeshProUGUI>().text = "��������: " + count.ToString() + "��";
            Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().text = "���ͷ�: " + profit.ToString("c", numberFormat) + "(" + profitRate.ToString("F2") + "%)";

            if(rateDay > 0)
                Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
            else if (rateDay < 0)
                Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
            else
                Instance.transform.Find("TextStockListOwnPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);

            if (profit > 0)
                Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
            else if(profit < 0)
                Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
            else
                Instance.transform.Find("TextStockListOwnProfit").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
        }
    }
}
