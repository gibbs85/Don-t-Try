using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : FinancialInstrument
{
    private int code;
    private string name;
    private int termOrigin;
    private double interest;
    private double stability;

    /*
    public int getCode();
    public string getName();
    public int getTermOrigin();
    public double getInterest();
    public double getStability();

    */

    public Deposit(int code, string name, int termOirigin, double interest, double stability)
    {
        this.code = code;
        this.name = name;
        this.termOrigin = termOrigin;
        this.interest = interest;
        this.stability = stability;
    }

    public override int getCode()
    {
        return this.code;
    }

    public string getName()
    {
        return this.name;
    }

    public override int getTermOrigin()
    {
        return this.termOrigin;
    }

    public override double getInterest()
    {
        return this.interest;
    }

    public double getStability()
    {
        return this.stability;
    }
}
