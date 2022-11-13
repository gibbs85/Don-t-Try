using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InstSignedUp
{
    public int playerCode;
    public int instCode;
    public double moneyDeposit;
    public double dateSignedUp;
    public int termLeft;

    public void pastsDay(int daysPast)
    {
        this.termLeft -= daysPast;
        if (this.termLeft < 0)
            this.termLeft = 0;
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
        Deposit deposit_basic = new Deposit(0, "예금테스트", 10, 1.05, 1.0);
        this.addInst(deposit_basic);
    }

    public void update(int daysPast)
    {
        foreach(InstSignedUp instSignedups in this.instrumentsSignedUp)
        {
            instSignedups.pastsDay(daysPast);

            if(instSignedups.termLeft == 0)
            {
                this.returnMoney(instSignedups);
            }
        }
    }

    public void signUpInst(Player player, double moneySignUp, int instCode, int date)
    {
        InstSignedUp instSignUp;
        instSignUp.playerCode = player.getCode();
        instSignUp.instCode = instCode;
        instSignUp.moneyDeposit = moneySignUp;
        instSignUp.dateSignedUp = date;
        instSignUp.termLeft = this.getInst(instCode).getTermOrigin();

        this.addInstSignedUp(instSignUp);
    }

    private void returnMoney(InstSignedUp instSignedUp)
    {
        double money = instSignedUp.moneyDeposit;
        double interest = this.getInst(instSignedUp.instCode).getInterest();

        money = money * interest;

        //안정성 연산 임시 생략

        SystemControl.Instance.player.spendMoney(-money);
        this.delInstSignedUp(instSignedUp);
    }

    public double getSaving(int codePlayer)
    {
        double saving = 0;

        foreach(InstSignedUp instSignedUp in (this.instrumentsSignedUp.FindAll(signedUp => signedUp.playerCode == codePlayer)))
        {
            saving += instSignedUp.moneyDeposit;
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
        this.instrumentsSignedUp.Remove(this.instrumentsSignedUp.Find(signedUp => (signedUp.playerCode == codePlayer) && (signedUp.instCode == codeInst)));
    }

    private void delInstSignedUp(InstSignedUp instSignedUp)
    {
        this.instrumentsSignedUp.Remove(instSignedUp);
    }




}
