using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInst : MonoBehaviour
{
    public string name;
    public int code;
    public FinancialInstrument inst;

    public GameObject pageOpen;
    public GameObject pageClose;

    public void openDetailPage()
    {
        this.pageOpen = GameObject.Find("AppBank").transform.Find("InstDetail").gameObject;
        this.pageClose = GameObject.Find("AppBank").transform.Find("InstListAll").gameObject;

        Debug.Log("Detail page opend");
        Debug.Log("Inst name is : " + this.name);
        Debug.Log("Inst code is : " + this.code);

        pageOpen.SetActive(true);
        this.pageOpen.GetComponentInChildren<Bank_InstDetail>().page_open(this.inst);
        pageClose.SetActive(false);
    }

    public void setInst(FinancialInstrument inst)
    {
        this.inst = inst;
        this.name = this.inst.getName();
        this.code = this.inst.getCode();
    }

    public string getName()
    {
        return this.name;
    }

    public int getCode()
    {
        return this.code;
    }
}
