using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DaysOfTheWeek
{
    MONDAY = 0,
    TUESDAY = 1,
    WEDNESDAY = 2,
    THURSDAY = 3,
    FRIDAY = 4,
    SATURDAY =5,
    SUNDAY = 6
}

public class World
{
    private int time;
    private int[] timeTurns; // �� ������ �ð�
    private int turn; // 0���� �÷��� �Ұ�. 1, 2, 3, ... ���� TimeTurns�� ��ġ
    private int day; // enum DaysOfTheWeek ���.
    private int date;
    private SortedList<int, EventContainer> eventQueue;

    /*
    public void new_game();                     // �߰� �۾� �ʿ�
    public void system_save();              // ����
    public void system_load();              // ����

    public void refresh();                  // ����

    public void nextTurn();                 // �߰� �۾� �ʿ�
    private void nextDay();                  // �߰� �۾� �ʿ�
    public void addEventQueue(EventContainer anEvent);  // �Ϸ�
    private void eventCheck();    // �Ϸ�

    public int getDay();                    // �Ϸ�
    public int getDate();                   // �Ϸ�
    public int getTime();                   // �Ϸ�
    */

    public World()
    {
        this.time = 0;
        this.timeTurns = new int[] { 9, 10, 13, 15};
        this.turn = 0;
        this.day = 0;
        this.date = 0;
        this.eventQueue = new SortedList<int, EventContainer>();
    }

    public void new_game()
    {
        this.turn = 1;
        this.time = this.timeTurns[this.turn];
        this.day = 1;

        //this.eventQueue.addEventQueue(new Event_Zero);
    }

    private void nextDay()
    {
        /*
         * �׽�Ʈ
         */

        if (this.date == 0)
        {
            SystemControl.Instance.msgr.test_AddNewChatRoom();
        }
        else if (this.date < 3)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "�̰͵� �޾� ������", this.date));
        }
        if (this.date == 6)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "�̰� �� ����", this.date));
        }
        if (this.date == 9)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "�� �� ����", this.date));
        }
        if (this. date == 10)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "��", this.date));
        }
        if (this.date == 11)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "��", this.date));
        }
        if (this.date == 12)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "��", this.date));
        }
        if (this.date > 13)
        {
            SystemControl.Instance.msgr.addChat("�׽�Ʈ ä�ù�", new Chat("�׽�Ʈ ��ȭ���", "�߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾߾�", this.date));
        }
        if (this.date > 14)
        {
            SystemControl.Instance.msgr.test_AddNewNewChatRoom();
            SystemControl.Instance.msgr.addChat("�׽�Ʈ�� ��", new Chat("�׽�Ʈ ��� ��", "�ڳװ� ���� ���Ѵٴ���", this.date));
        }
        //SystemControl.Instance.msgr.

        /*
         */


        Debug.Log("World.cs: nextDay(): entered");
        this.date++; // ��¥ ����
        this.day++; // ���� ����
        if (this.day > (int)DaysOfTheWeek.SUNDAY)
            this.day = (int)DaysOfTheWeek.MONDAY;
        this.turn = 1; // �÷��̰� ���۵Ǵ� �� ��°[9, '10', 13, 15] ��
        this.time = this.timeTurns[this.turn];

        SystemControl.Instance.player.exhaustFatigue(-5);
        Debug.Log("World.cs: nextDay(). exhaustFatigue: completed");
        SystemControl.Instance.bank.update(1);
        Debug.Log("World.cs: nextDay(). bank.update: completed");

        UI_GamePlay.update_time();
        UI_GamePlay.update_date();

        // nextTurn���� ����
    }


    public void nextTurn()
    {
        //Debug.Log("World.cs: nextTurn(): enetered");
        this.turn++;
        if (this.turn >= this.timeTurns.Length)
        {
            this.nextDay();
        }

        this.time = this.timeTurns[this.turn];
        //SystemControl.Instance.stockControl.updateAllStocks(this.time - this.timeTurns[this.turn - 1]);//not sure
        //Debug.Log("World.cs: nextTurn(): stockControl.updateAllStocks() completed");

        UI_GamePlay.update_time();
        //UI_GamePlay.update_stockApp();
        //UI_GamePlay.update_bankApp();
        //Debug.Log("World.cs: nextTurn(): (inside) completed");

    }

    public void addEventQueue(EventContainer anEvent)
    {
        this.eventQueue.Add(anEvent.getTriggerDay(), anEvent);
    }

    private void eventCheck()
    {
        for (int i = 0; i < this.eventQueue.Count; i++)
        {
            if (this.eventQueue.Keys[i] > this.date) // ���� ��¥�� ������ �̺�Ʈ�� ������ üũ ����(break)
                break;

            if (this.eventQueue.Values[i].getTriggerTime() > this.time) // ���� ��¥�� �����ϳ�, �ð��� �������� ������ ť�� ���� �̺�Ʈ üũ(continue)
                continue;

            else
            {
                this.eventQueue.Values[i].executeEvent(); // ���� ��� ���� �� �̺�Ʈ ����

                this.eventCheck(); // ���� �Ϸ� �� �̺�Ʈ üũ �ٽ� ����
            }
        }
    }

    public int getDay()
    {
        return (int)(this.day);
    }
    public int getDate()
    {
        return this.date;
    }
    public int getTime()
    {
        return this.time;
    }

}
