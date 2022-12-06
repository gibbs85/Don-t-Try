using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_General_GetMoney : Event
{
    private double money;

    public Event_General_GetMoney(double money)
    {
        this.money = money;
    }

    override public bool control()
    {
        Debug.Log("Event_General_GiveMoney.cs: control(): entered");
        SystemControl.Instance.player.spendMoney(-(this.money));
        return true;
    }
}
