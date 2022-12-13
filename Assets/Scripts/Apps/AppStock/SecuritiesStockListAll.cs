using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

using StockDOGE;

public class SecuritiesStockListAll : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    // Start is called before the first frame update
    void Start()
    {
        this.refresh();
    }

    void OnEnable()
    {
        this.refresh();
    }

    public void refresh()
    {
        /*
         * 이전 버튼들 삭제
         */

        this.delete();


        /*
         * 주식 데이터 읽어서 버튼 추가
         * 
         */
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;


        
        for (int i = 0; i < SystemControl.Instance.stockControl.getCountStocks(); i++)
        {
            //Debug.Log("SecuritiesStockListAll.cs.44 : code :" + SystemControl.Instance.stockControl.getStockAt(i).getCode());
            //Debug.Log("SecuritiesStockListAll.cs.45 : index :" + i);
            double rate = SystemControl.Instance.stockControl.getRateDay(SystemControl.Instance.stockControl.getStockAt(i).getCode(), SystemControl.Instance.world.getTime());
            //Debug.Log("SecuritiesStockListAll.cs.45 : name : " + SystemControl.Instance.stockControl.getStockAt(i).getName());
            //Debug.Log("SecuritiesStockListAll.cs.46 : rate : " + rate);
            //double rate = GameObject.Find("Stocks").GetComponent<Stocks>().getRateDay(GameObject.Find("Stocks").GetComponent<Stocks>().getStockByIndex(i), GameObject.Find("Main").GetComponent<MainScript>().GetTime());

            GameObject btn = Resources.Load<GameObject>("Prefabs/StockButtonContentListAll");
            //GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("StockListAll").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));
            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("AppStock").transform.Find("StockListAll").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));
            Instance.transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = SystemControl.Instance.stockControl.getStockAt(i).getName();
            Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().text = (SystemControl.Instance.stockControl.getStockAt(i)).getPrice().ToString("c", numberFormat)
                + "(" + rate.ToString("F2") + "%)";

            if (rate > 0)
            {
                Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
            }
            else if (rate < 0)
            {
                Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);
            }
            else
            {
                Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(129, 128, 131, 255);
            }

        }

    }

    public void delete()
    {

        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }
    }
}
