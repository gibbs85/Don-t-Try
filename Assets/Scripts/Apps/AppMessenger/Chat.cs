using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat
{
    private string nameSpeaker;
    private string dialog;
    private int date;
    private bool read;

    private bool isWaitBefore;
    private bool isWaitAfter;
    private float waitTimeBefore;
    private float waitTimeAfter;

    private bool isNextMsg;
    private Chat nextMsg;

    private bool isGiveMoney;
    private double moneyGive;

    private bool isTakeMoney;
    private double moneyTake;

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
        float waitTimeAfter
        )
    {
        this.nameSpeaker = nameSpeaker;
        this.dialog = dialog;
        this.date = date;
        this.read = false;

        this.isWaitBefore = true;
        this.waitTimeAfter = waitTimeAfter;

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
