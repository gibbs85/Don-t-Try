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

    public void btn_nextTurn()
    {
        SystemControl.Instance.world.nextTurn();
    }
}
