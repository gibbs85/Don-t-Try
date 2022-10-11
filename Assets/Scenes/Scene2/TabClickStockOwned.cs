using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabClickStockOwned : MonoBehaviour
{
    public void clicked(bool isOn)
    {
        //print("clicked");
        GameObject.Find("AppStock").transform.Find("StockListAll").gameObject.SetActive(false);
        //Debug.Log("Tab. StockListAll.SetActive(false)");
        GameObject.Find("AppStock").transform.Find("StockListOwned").gameObject.SetActive(true);
        //Debug.Log("Tab. StockListOwned.SetActive(true)");
        GameObject.Find("AppStock").transform.Find("StockListOwned").GetComponent<StockListOwned>().refresh();
        //Debug.Log("Tab. StockListOwned.refresh()");

        GameObject.Find("StockToggleOwned").transform.Find("Label").GetComponent<Text>().color = new Color(255, 192, 0);
        GameObject.Find("StockToggleAll").transform.Find("Label").GetComponent<Text>().color = new Color(255, 255, 255);
    }
}
