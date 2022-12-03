using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePlay : MonoBehaviour
{

    void Awake()
    {
        update_date();
        update_time();
        update_fatigue();
        update_money();
    }

    public static void update_fatigue()
    {
        int fatigue = SystemControl.Instance.player.getFatigue();
        GameObject.Find("UI").transform.Find("Fatigue").GetComponent<Text>().text =
            "피로도 (" + fatigue.ToString() + "/5)";

        if (fatigue == 5)
        {
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired5").gameObject.SetActive(true);
        }
        else if (fatigue == 4)
        {
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired5").gameObject.SetActive(false);
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired4").gameObject.SetActive(true);
        }
        else if (fatigue == 3)
        {
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired4").gameObject.SetActive(false);
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired3").gameObject.SetActive(true);
        }
        else if (fatigue == 2)
        {
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired3").gameObject.SetActive(false);
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired2").gameObject.SetActive(true);
        }
        else if (fatigue == 1)
        {
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired2").gameObject.SetActive(false);
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired1").gameObject.SetActive(true);
        }
        else if (fatigue == 0)
        {
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired1").gameObject.SetActive(false);
            GameObject.Find("UI").transform.Find("ImgTired").transform.Find("ImgTired0").gameObject.SetActive(true);
        }

    }

    public static void update_time()
    {
        int time = SystemControl.Instance.world.getTime();
        int tempTime;
        string AMPM;

        if (time > 12)
        {
            tempTime = time - 12;
            AMPM = "PM";
        }
        else
        {
            tempTime = time;
            AMPM = "AM";
        }

        GameObject.Find("UI").transform.Find("Time").GetComponent<Text>().text =
            "현재 시간: " + time.ToString() + ":" + "00 " + AMPM;
    }

    public static void update_date()
    {
        int date = SystemControl.Instance.world.getDate();
        //ui_date.text = date.ToString() + "일 째";

        GameObject.Find("UI").transform.Find("Date").GetComponent<Text>().text =
            date.ToString() + "일 째";

    }

    public static void update_money()
    {
        int money = (int)(SystemControl.Instance.player.getMoney());//이후 utilNum 활용 필요

        GameObject.Find("UI").transform.Find("Money").GetComponent<Text>().text =
            money.ToString() + "원";
    }

    public void btn_nextTurn()
    {
        //Debug.Log("UI_GamePlay.cs: btn_nextTurn(): enetered");
        SystemControl.Instance.world.nextTurn();

        //Debug.Log("UI_GamePlay.cs: btn_nextTurn(): world.nextTurn(): completed");
        this.update_stockApp();
        //Debug.Log("UI_GamePlay.cs: btn_nextTurn(): update_stockApp(): completed");
        this.update_bankApp();
        this.update_messengerApp();
    }

    private void update_stockApp()
    {
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").gameObject.activeSelf == false)
            return;
        //Debug.Log("UI_GamePlay.cs: update_stockApp()");
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListAll").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListAll").GetComponent<SecuritiesStockListAll>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").GetComponent<StockDetailDisplay>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockBuyPage").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockBuyPage").GetComponent<StockBuyPage>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListOwned").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockListOwned").GetComponent<StockListOwned>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppStock").transform.Find("StockDetail").gameObject.activeSelf == true)
            GameObject.Find("StockDetail").transform.Find("StockDetailChart").transform.Find("ChartStock").GetComponent<ChartStock>().refresh();
    }

    private void update_bankApp()
    {
        if (GameObject.Find("PhoneOnHand").transform.Find("AppBank").gameObject.activeSelf == false)
            return;
        //Debug.Log("UI_GamePlay.cs: update_bankApp()");
        if (GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("Bank1").gameObject.activeSelf == true)
        {
            Debug.Log("UI_GamePlay.cs: update_bankApp(): if 0");
            GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("Bank1").GetComponent<AppBank_myAsset>().refresh();
        }
        if (GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("InstListAll").gameObject.activeSelf == true)
        {
            Debug.Log("UI_GamePlay.cs: update_bankApp(): if 1");
            GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("InstListAll").GetComponent<Bank_InstListAll>().refresh();
        }
        if (GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("InstSignUp").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("InstSignUp").GetComponent<Bank_InstSignUp>().refresh();
        if (GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("InstListSignedUp").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppBank").transform.Find("InstListSignedUp").GetComponent<Bank_InstListSignedUp>().refresh();
    }

    private void update_messengerApp()
    {
        if (GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").gameObject.activeSelf == false)
            return;
        //Debug.Log("UI_GamePlay.cs: update_stockApp()");
        if (GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoomList").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoomList").GetComponent<Messenger_ChatRoomList>().refresh();
    }
}
