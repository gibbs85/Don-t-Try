using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Bank_InstListAll : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    public GameObject phoneHome;
    public GameObject pageThis;
    public GameObject pageClose;
    public GameObject pageGoBack;

    // Start is called before the first frame update
    void Start()
    {
        this.init();
        this.refresh();
    }

    void OnEnable()
    {
        this.refresh();
    }

    public void page_open()
    {
        this.init();
        this.refresh();
    }

    public void init()
    {
        this.phoneHome = GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").gameObject;
        this.pageThis = GameObject.Find("AppBank").transform.Find("InstListAll").gameObject;
        this.pageClose = this.pageThis;
        this.pageGoBack = GameObject.Find("AppBank").transform.Find("Bank1").gameObject;
    }

    public void goBack()
    {
        this.pageGoBack.SetActive(true);
        this.pageClose.SetActive(false);
    }

    public void goHome()
    {
        this.phoneHome.SetActive(true);
        this.pageThis.SetActive(false);
    }

    public void refresh()
    {
        Debug.Log("Bank_InstListAll.cs: refresh()");
        /*
         * 이전 버튼들 삭제
         */

        this.delete();


        /*
         * 주식 데이터 읽어서 버튼 추가
         * 
         */
        numberFormat = new CultureInfo("ko-KR", false).NumberFormat;

        int i = 0;
        foreach (FinancialInstrument inst in (SystemControl.Instance.bank.getInstsAll()))
        {
            i++;
            Debug.Log("Count:" + i);
            double rate = inst.getInterest();

            GameObject btn = Resources.Load<GameObject>("Prefabs/InstButtonContentListAll");

            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("AppBank").transform.Find("InstListAll").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

            Instance.GetComponentInChildren<BtnInst>().setInst(inst);

            Instance.transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = Instance.GetComponentInChildren<BtnInst>().getName();
            Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().text = "이윤: " + inst.getInterest().ToString("F2") + "%";
            Instance.transform.Find("TextStab").GetComponentInChildren<TextMeshProUGUI>().text = "안정성: " + (inst.getStability() * 100.0).ToString("F2") + "%";
            Instance.transform.Find("TextTerm").GetComponentInChildren<TextMeshProUGUI>().text = "예치 기간: " + inst.getTermOrigin().ToString() + "일";

            Instance.transform.Find("TextPrice").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);


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

    public void page_open_listAll()
    {
        this.page_open();
    }

    public void page_open_listSignedUp()
    {
        GameObject pageOpen = GameObject.Find("AppBank").transform.Find("InstListSignedUp").gameObject;
        pageOpen.SetActive(true);
        pageOpen.GetComponentInChildren<Bank_InstListSignedUp>().page_open();
        this.pageClose.SetActive(false);
    }

}
