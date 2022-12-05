using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat
{
    protected string nameSpeaker;
    protected string dialog;
    protected int date;
    protected bool read;

    protected bool isWaitBefore;
    protected bool isWaitAfter;
    protected float waitTimeBefore;
    protected float waitTimeAfter;

    protected bool isNextMsg;
    protected Chat nextMsg;

    protected bool isGiveMoney;
    protected double moneyGive;

    protected bool isTakeMoney;
    protected double moneyTake;

    protected Chat()
    {
        this.nameSpeaker = "NONE";
    }

    public Chat(string nameSpeaker, string dialog, int date)
    {
        this.nameSpeaker = nameSpeaker;
        this.dialog = dialog;
        this.date = date;
        this.read = false;

        this.isWaitBefore = false;
        this.waitTimeBefore = 0f;
        this.isWaitAfter = false;
        this.waitTimeAfter = 0;
        this.isNextMsg = false;
        this.isGiveMoney = false;
        this.moneyGive = 0;
        this.isTakeMoney = false;
        this.moneyTake = 0;
    }


    public Chat(string nameSpeaker, string dialog, int date,
        float waitTimeBefore
        )
    {
        this.nameSpeaker = nameSpeaker;
        this.dialog = dialog;
        this.date = date;
        this.read = false;

        this.isWaitBefore = true;
        this.waitTimeBefore = waitTimeBefore;

        this.isNextMsg = false;
        this.isGiveMoney = false;
        this.moneyGive = 0;
        this.isTakeMoney = false;
        this.moneyTake = 0;
    }

    public bool getRead()
    {
        return this.read;
    }

    public string getString()
    {
        return this.dialog;
    }

    public string getNameSpeaker()
    {
        return this.nameSpeaker;
    }

    public void doneRead()
    {
        this.read = true;
    }

    public float getWaitTimeAfter()
    {
        return this.waitTimeAfter;
    }
}

//public interface ChatInControl
//{
//    public  bool control();
//}
