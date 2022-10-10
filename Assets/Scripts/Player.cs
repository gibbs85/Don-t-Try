using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private int code;
    private string name;
    private double money;   // ������
    private double saving;  // ����
    private double investment;  // �ֽ� �� ���ڵ� �ݾ�
    private int fatigue;    // �Ƿε�

    /*
    public void init(int code)                  // �Ϸ�
    public void system_save();                  // 
    public void system_load();                  // 

    public void update();                       // 
    private void updateSaving();                //
    private void updateInvestment();            //

    public bool spendMoney(double money);       // �Ϸ�
    public bool exhaustFatigue(int fatigue);    // �Ϸ�

    *public void setName(string name);

    public int getCode();                       // �Ϸ�
    public string getName();                    // �Ϸ�
    public double getMoney();                   // �Ϸ�
    public int getFatigue();                    // �Ϸ�
    public double getSaving();                  // �Ϸ�
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
        if (money > this.money) // �������� ������ ��� false ����
            return false;

        else
        {
            this.money = this.money - money;
            return true;
        }
    }

    public bool exhaustFatigue(int fatigue)
    {
        if (fatigue > this.fatigue) // �Ƿε��� ������ ��� false ����
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
