using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : FinancialInstrument
{
    private int code;
    private string name;
    private int termOrigin;
    private int termLeft;
    private double interest;
    private double stability;

    /*
    public void pastsDay(int day);
    public int getCode();
    public string getName();
    public int getTermOrigin();
    public int getTermLeft();
    public double getInterest();
    public double getStability();

    */

    public void pastsDay(int day)
    {
        this.termLeft = -day;
    }

    public int getCode()
    {
        return this.code;
    }

    public string getName()
    {
        return this.name;
    }

    public int getTermOrigin()
    {
        return this.termOrigin;
    }

    public int getTermLeft()
    {
        return this.termLeft;
    }

    public double getInterest()
    {
        return this.interest;
    }

    public double getStability()
    {
        return this.stability;
    }
}
