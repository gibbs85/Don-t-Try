using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Globalization;

public class Bank_InstSignUp : MonoBehaviour
{
    NumberFormatInfo numberFormat;

    public GameObject phoneHome;
    public GameObject pageThis;
    public GameObject pageClose;
    public GameObject pageGoBack;

    public string instName;
    public int codeInst;
    public int codePlayer;
    public FinancialInstrument inst;
    public int moneySignUp;
    private string inputProcessed;
    private double moneyPlayer;

    public void page_open(FinancialInstrument inst, int codePlayer)
    {
        this.init(inst, codePlayer);
        this.refresh();
    }

    public void init(FinancialInstrument inst, int codePlayer)
    {
        Debug.Log("inst name: " + inst.getName());
        Debug.Log("inst code: " + inst.getCode());

        this.inst = inst;
        this.codePlayer = codePlayer;
        this.codeInst = this.inst.getCode();
        this.instName = this.inst.getName();
        this.moneySignUp = 0;
        this.inputProcessed = "0";
        this.moneyPlayer = SystemControl.Instance.player.getMoney();

        this.phoneHome = GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").gameObject;
        this.pageThis = GameObject.Find("AppBank").transform.Find("InstSignUp").gameObject;
        this.pageClose = this.pageThis;
        this.pageGoBack = GameObject.Find("AppBank").transform.Find("InstDetail").gameObject;
    }

    public void refresh()
    {
        this.pageThis.transform.Find("TextMoneySignUpTmpro").GetComponentInChildren<TextMeshProUGUI>().text = this.moneySignUp.ToString("c", numberFormat);

        if(this.moneySignUp > this.moneyPlayer)
            this.pageThis.transform.Find("TextMoneySignUpTmpro").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 38, 4, 255);
        else
            this.pageThis.transform.Find("TextMoneySignUpTmpro").GetComponentInChildren<TextMeshProUGUI>().color = new Color32(0, 112, 192, 255);

        this.moneyPlayer = SystemControl.Instance.player.getMoney();
        //소지금 출력 텍스트 수정
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

    private void inputHandle(string input)
    {
        if (input.Equals("back"))
        {
            if (this.inputProcessed.Equals("0"))
                return;

            if (this.inputProcessed.Length == 1)
            {
                this.inputProcessed = "0";
                this.moneySignUp = Int32.Parse(this.inputProcessed);
                this.refresh();
                return;
            }

            this.inputProcessed = this.inputProcessed.Substring(0, this.inputProcessed.Length - 1);
            this.moneySignUp = Int32.Parse(this.inputProcessed);

            this.refresh();
            return;
        }

        // 입력 최대 길이 제한
        if (this.inputProcessed.Length > 8)
            return;


        if (this.inputProcessed.Equals("0"))
        {
            this.inputProcessed = input;
            this.moneySignUp = Int32.Parse(this.inputProcessed);
            this.refresh();
            return;
        }

        this.inputProcessed += input;

        this.moneySignUp = Int32.Parse(this.inputProcessed);
        this.refresh();
    }


    public void btn_confirm()
    {
        if (this.moneySignUp > this.moneyPlayer)
            return;

        if (this.moneySignUp <= 0)
            return;

        //Debug.Log("InstSIgnUp Confirm Btn clicked.");

        SystemControl.Instance.bank.signUpInst(SystemControl.Instance.player, this.moneySignUp, this.codeInst, SystemControl.Instance.world.getDate());
        SystemControl.Instance.player.spendMoney(this.moneySignUp);
        SystemControl.Instance.player.exhaustFatigue(2);

        this.moneySignUp = 0;
        this.refresh();
    }

    public void input_1()
    {
        this.inputHandle("1");
    }
    public void input_2()
    {
        this.inputHandle("2");
    }
    public void input_3()
    {
        this.inputHandle("3");
    }
    public void input_4()
    {
        this.inputHandle("4");
    }
    public void input_5()
    {
        this.inputHandle("5");
    }
    public void input_6()
    {
        this.inputHandle("6");
    }
    public void input_7()
    {
        this.inputHandle("7");
    }
    public void input_8()
    {
        this.inputHandle("8");
    }
    public void input_9()
    {
        this.inputHandle("9");
    }
    public void input_0()
    {
        this.inputHandle("0");
    }
    public void input_00()
    {
        this.inputHandle("00");
    }
    public void input_back()
    {
        this.inputHandle("back");
    }
}
