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

    public void new_game();                                                                      // �Ϸ�
    public void system_save();                                                                   //
    public void system_load();                                                                   //

    public void update(int daysPast);                                                            // �Ϸ�
    private void returnMoney(intSignedUp inst);                                                  //
    public void signUpInst(Player player, double moneySignUp, FinancialInstrument instrument);   // �Ϸ�
    public FinancialInstrument getInst();                                                        //
    public FinancialInstrument getInst(int instCode);                                            // �Ϸ�
    public double getSaving(int codePlayer);                                                     // �Ϸ�

    public void addInst(FinancialInstrument);                                                    // �Ϸ�
    public void delInst(FinancialInstrument);                                                    // �Ϸ�
    private void addInstSignedUp(InstSignedUp instSignedUp);                                     // �Ϸ�
    private void delInstSignedUp(InstSignedUp instSignedUp);                                     // �Ϸ�
    private void delInstSignedUp(InstSignedUp instSignedUp);                                     // �Ϸ�


    */

    public Bank()
    {
        this.instrument = new List<FinancialInstrument>();
        this.instrumentsSignedUp = new List<InstSignedUp>();
    }

    public void new_game()
    {
        /*
         * �ʱ� ���� ��ǰ ���� �� �߰�
         * 
         * public Deposit(int code, string name, int termOirigin, double interest, double stability)
         * 
         */
        Deposit deposit_basic = new Deposit(0, "�����׽�Ʈ", 10, 1.05, 1.0);
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

        //������ ���� �ӽ� ����

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
