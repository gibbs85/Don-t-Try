using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public struct InstSignedUp
//{
//    public int playerCode;
//    public int instCode;
//    public double moneyDeposit;
//    public double dateSignedUp;
//    public int termLeft;
//    public FinancialInstrument inst;

//    public void pastsDay(int daysPast)
//    {
//        Debug.Log("InstSignedUp: pastsDay(" + daysPast + ")");
//        this.termLeft -= daysPast;
//        if (this.termLeft < 0)
//            this.termLeft = 0;
//        Debug.Log("InstSignedUp: terLeft: " + this.termLeft);
//    }

//    public FinancialInstrument getInst()
//    {
//        return this.inst;
//    }

//    public int getTermLeft()
//    {
//        return this.termLeft;
//    }

//    public double getMoneyDeposit()
//    {
//        return this.moneyDeposit;
//    }

//}

public class InstSignedUp
{
    private int playerCode;
    private int instCode;
    private double moneyDeposit;
    private int dateSignedUp;
    private int termLeft;
    private FinancialInstrument inst;

    public InstSignedUp(int playerCode, int instCode, double moneyDeposit, int dateSignedUp, int termLeft, FinancialInstrument inst)
    {
        this.playerCode = playerCode;
        this.instCode = instCode;
        this.moneyDeposit = moneyDeposit;
        this.dateSignedUp = dateSignedUp;
        this.termLeft = termLeft;
        this.inst = inst;
    }

    public void pastsDay(int daysPast)
    {
        Debug.Log("InstSignedUp: pastsDay(" + daysPast + ")");
        this.termLeft -= daysPast;
        if (this.termLeft < 0)
            this.termLeft = 0;
        Debug.Log("InstSignedUp: terLeft: " + this.termLeft);
    }

    public FinancialInstrument getInst()
    {
        return this.inst;
    }

    public int getTermLeft()
    {
        return this.termLeft;
    }

    public double getMoneyDeposit()
    {
        return this.moneyDeposit;
    }

    public int getInstCode()
    {
        return this.instCode;
    }

    public int getPlayerCode()
    {
        return this.playerCode;
    }
}

public class Bank
{
    private List<FinancialInstrument> instrument;
    private List<InstSignedUp> instrumentsSignedUp;

    /*

    public void new_game();                                                                      // 완료
    public void system_save();                                                                   //
    public void system_load();                                                                   //

    public void update(int daysPast);                                                            // 완료
    private void returnMoney(intSignedUp inst);                                                  //
    public void signUpInst(Player player, double moneySignUp, FinancialInstrument instrument);   // 완료
    public FinancialInstrument getInst();                                                        //
    public FinancialInstrument getInst(int instCode);                                            // 완료
    public List<FinancialInstrument> getInstsAll();                                              // 완료
    public List<FinancialInstrument> getInstsAll(int codePlayer);                                //
    public double getSaving(int codePlayer);                                                     // 완료

    public void addInst(FinancialInstrument);                                                    // 완료
    public void delInst(FinancialInstrument);                                                    // 완료
    private void addInstSignedUp(InstSignedUp instSignedUp);                                     // 완료
    private void delInstSignedUp(InstSignedUp instSignedUp);                                     // 완료
    private void delInstSignedUp(InstSignedUp instSignedUp);                                     // 완료


    */

    public Bank()
    {
        this.instrument = new List<FinancialInstrument>();
        this.instrumentsSignedUp = new List<InstSignedUp>();
    }

    public void new_game()
    {
        /*
         * 초기 예금 상품 생성 및 추가
         * 
         * public Deposit(int code, string name, int termOirigin, double interest, double stability)
         * 
         */
        Deposit deposit_nh = new Deposit(100, "농협예금", 10, 1.05, 1.0);
        Deposit deposit_sh = new Deposit(200, "신협예금", 10, 1.06, 1.0);
        Deposit deposit_bs = new Deposit(300, "부산은행예금", 10, 1.04, 1.0);

        this.addInst(deposit_nh);
        this.addInst(deposit_sh);
        this.addInst(deposit_bs);
    }

    public void update(int daysPast)
    {
        List<InstSignedUp> toDelte = new List<InstSignedUp>();

        Debug.Log("Bank.cs: update(daysPast): "+ daysPast);
        foreach(InstSignedUp instSignedups in this.instrumentsSignedUp)
        {
            Debug.Log("Bank.cs: update(): foreach");
            instSignedups.pastsDay(daysPast);

            Debug.Log("Bank.cs: update(): instSignedups.getTermLeft(): " + instSignedups.getTermLeft());

            if (instSignedups.getTermLeft() == 0)
            {
                Debug.Log("Bank.cs: update(): if: entered");
                this.returnMoney(instSignedups);
                Debug.Log("Bank.cs: update(): if: eneded");
                toDelte.Add(instSignedups);
            }
        }

        foreach(InstSignedUp instSignedups in toDelte)
        {
            this.delInstSignedUp(instSignedups);
        }


    }

    public void signUpInst(Player player, double moneySignUp, int instCode, int date)
    {
        Debug.Log("Bank.cs: InstSIgnUp()");

        //InstSignedUp instSignUp;
        //instSignUp.playerCode = player.getCode();
        //instSignUp.instCode = instCode;
        //instSignUp.moneyDeposit = moneySignUp;
        //instSignUp.dateSignedUp = date;
        //instSignUp.termLeft = this.getInst(instCode).getTermOrigin();
        //instSignUp.inst = this.getInst(instCode);

        InstSignedUp instSignup = new InstSignedUp(player.getCode(), instCode, moneySignUp, date, this.getInst(instCode).getTermOrigin(), this.getInst(instCode));

        //Debug.Log("playerCode: " + instSignUp.playerCode);
        //Debug.Log("instCode: " + instSignUp.instCode);
        //Debug.Log("moneyDeposit: " + instSignUp.moneyDeposit);
        //Debug.Log("dateSignedUp: " + instSignUp.dateSignedUp);
        //Debug.Log("termLeft: " + instSignUp.termLeft);

        this.addInstSignedUp(instSignup);
    }

    private void returnMoney(InstSignedUp instSignedUp)
    {
        Debug.Log("Bank.cs: returnMoney(): entered");
        double money = instSignedUp.getMoneyDeposit();
        double interest = this.getInst(instSignedUp.getInstCode()).getInterest();

        money = money * interest;

        //안정성 연산 임시 생략

        SystemControl.Instance.player.spendMoney(-money);
        //this.delInstSignedUp(instSignedUp); // deletion in foreach enumeration is forhibited.
        Debug.Log("Bank.cs: returnMoney(): completed");
    }

    public double getSaving(int codePlayer)
    {
        double saving = 0;

        foreach(InstSignedUp instSignedUp in (this.instrumentsSignedUp.FindAll(signedUp => signedUp.getPlayerCode() == codePlayer)))
        {
            saving += instSignedUp.getMoneyDeposit();
        }

        return saving;
    }

    public FinancialInstrument getInst(int instCode)
    {
        return this.instrument.Find(inst => inst.getCode() == instCode);
    }

    public void addInst(FinancialInstrument inst)
    {
        this.instrument.Add(inst);
    }

    private void addInstSignedUp(InstSignedUp instSignedUp)
    {
        this.instrumentsSignedUp.Add(instSignedUp);
    }

    private void delInstSignedUp(int codePlayer, int codeInst)
    {
        this.instrumentsSignedUp.Remove(    this.instrumentsSignedUp.Find(    signedUp => (  (signedUp.getPlayerCode()) == codePlayer  ) && (signedUp.getInstCode() == codeInst    )    ));
    }

    private void delInstSignedUp(InstSignedUp instSignedUp)
    {
        Debug.Log("Bank.cs: delInstSignedUp(): entered");
        this.instrumentsSignedUp.Remove(instSignedUp);
        Debug.Log("Bank.cs: delInstSignedUp(): completed");
    }

    public List<FinancialInstrument> getInstsAll()
    {
        return this.instrument;
    }

    public List<InstSignedUp> getInstsAll(int codePlayer)
    {
        List<InstSignedUp> instsSignedUp = new List<InstSignedUp>();
        foreach (InstSignedUp signedUp in this.instrumentsSignedUp)
            if (signedUp.getPlayerCode() == codePlayer)
                instsSignedUp.Add(signedUp);

        return instsSignedUp;
    }

    public int getInstsCount()
    {
        return this.instrument.Count;
    }



}
