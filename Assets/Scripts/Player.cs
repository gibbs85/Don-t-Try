using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private int code;
    private string name;
    private double money;   // 소지금
    private double saving;  // 예금
    private double investment;  // 주식 등 투자된 금액
    private int fatigue;    // 피로도

    /*
    public void init(int code)                  // 완료
    public void system_save();                  // 
    public void system_load();                  // 

    public void update();                       // 
    private void updateSaving();                //
    private void updateInvestment();            //

    public bool spendMoney(double money);       // 완료
    public bool exhaustFatigue(int fatigue);    // 완료

    *public void setName(string name);

    public int getCode();                       // 완료
    public string getName();                    // 완료
    public double getMoney();                   // 완료
    public int getFatigue();                    // 완료
    public double getSaving();                  // 완료
    */

    public Player(int code)
    {
        this.init(code);
    }

    public void init(int code)
    {
        this.code = code;
        this.name = "SOME NAME";
        this.money = 3000000;
        this.saving = 0;
        this.investment = 0;
        this.fatigue = 5;
    }

    public bool spendMoney(double money)
    {
        if (money > this.money) // 소지금이 부족할 경우 false 리턴
            return false;

        else
        {
            this.money = this.money - money;
            return true;
        }
    }

    public bool exhaustFatigue(int fatigue)
    {
        if (fatigue > this.fatigue) // 피로도가 부족할 경우 false 리턴
            return false;

        else
        {
            this.fatigue = this.fatigue - fatigue;
            UI_GamePlay.update_fatigue();
            return true;
        }
    }

    public int getCode()
    {
        return this.code;
    }

    public string getName()
    {
        return this.name;
    }
    public double getMoney()
    {
        return this.money;
    }
    public double getSaving()
    {
        return this.saving;
    }
    
    public void setName(string name)
    {
        this.name = name;
    }

    public int getFatigue()
    {
        return this.fatigue;
    }

}
