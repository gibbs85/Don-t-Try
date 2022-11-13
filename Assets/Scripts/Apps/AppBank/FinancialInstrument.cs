using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FinancialInstrument
{
    private int code;
    private string name;
    private double interest;

    public abstract string getName();
    public abstract int getCode();
    public abstract int getTermOrigin();
    public abstract double getInterest();
}
