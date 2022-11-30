using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank_InstDetail : MonoBehaviour
{
    public GameObject phoneHome;
    public GameObject pageThis;
    public GameObject pageClose;
    public GameObject pageGoBack;

    public string instName;
    public int codeInst;
    public int codePlayer;
    public FinancialInstrument inst;

    public void page_open(FinancialInstrument inst)
    {
        this.init(inst);
        this.refresh();
    }

    public void init(FinancialInstrument inst)
    {
        this.inst = inst;
        this.codeInst = this.inst.getCode();
        this.instName = this.inst.getName();

        this.phoneHome = GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").gameObject;
        this.pageThis = GameObject.Find("AppBank").transform.Find("InstDetail").gameObject;
        this.pageClose = this.pageThis;
        this.pageGoBack = GameObject.Find("AppBank").transform.Find("InstListAll").gameObject;
    }

    public void refresh()
    {
        this.pageThis.transform.Find("TextInstName").GetComponentInChildren<TextMeshProUGUI>().text = "<" + this.instName + ">";

        this.pageThis.transform.Find("TextInstTerm").GetComponentInChildren<TextMeshProUGUI>().text = "가입기간: " + this.inst.getTermOrigin().ToString() + "일";
        this.pageThis.transform.Find("TextInstInterest").GetComponentInChildren<TextMeshProUGUI>().text = "수익률: " + this.inst.getInterest().ToString("F2") + "%";
        this.pageThis.transform.Find("TextInstStability").GetComponentInChildren<TextMeshProUGUI>().text = "안정성: " + (this.inst.getStability() * 100.0).ToString("F2") + "%";
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

    public void page_open_signup()
    {
        GameObject pageOpen = GameObject.Find("AppBank").transform.Find("InstSignUp").gameObject;

        pageOpen.SetActive(true);
        Debug.Log("Bank_InstDetail: page_open_signup(): this.inst.getCode(): " + this.inst.getCode());
        pageOpen.GetComponentInChildren<Bank_InstSignUp>().page_open(this.inst, this.codePlayer);
        this.pageThis.SetActive(false);
    }

}
