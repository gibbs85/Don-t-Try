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
    private int[] timeTurns; // 턴 마다의 시간
    private int turn; // 0턴은 플레이 불가. 1, 2, 3, ... 턴은 TimeTurns에 매치
    private int day; // enum DaysOfTheWeek 사용.
    private int date;
    private SortedList<int, EventContainer> eventQueue;

    /*
    public void init();                     // 추가 작업 필요
    public void system_save();              // 없음
    public void system_load();              // 없음

    public void refresh();                  // 없음

    public void nextTurn();                 // 추가 작업 필요
    private void nextDay();                  // 추가 작업 필요
    public void addEventQueue(EventContainer anEvent);  // 완료
    private void eventCheck();    // 완료

    public int getDay();                    // 완료
    public int getDate();                   // 완료
    public int getTime();                   // 완료
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

    public void init()
    {
        this.turn = 1;
        this.time = this.timeTurns[this.turn];
        this.day = 1;

        //this.eventQueue.addEventQueue(new Event_Zero);
    }

    private void nextDay()
    {
        this.date++; // 날짜 진행
        this.day++; // 요일 진행
        if (this.day > (int)DaysOfTheWeek.SUNDAY)
            this.day = (int)DaysOfTheWeek.MONDAY;
        this.turn = 0; // 플레이가 시작되는 두 번째[9, '10', 13, 15] 턴
        this.time = this.timeTurns[this.turn];

        SystemControl.Instance.player.exhaustFatigue(-5);
        UI_GamePlay.update_time();
        UI_GamePlay.update_date();

        // nextTurn으로 복귀
    }


    public void nextTurn()
    {
        this.turn++;
        if (this.turn >= this.timeTurns.Length)
            this.nextDay();

        this.time = this.timeTurns[this.turn];
        SystemControl.Instance.player.exhaustFatigue(1);

        UI_GamePlay.update_time();
        //GameObject.Find("StockControl").GetComponent<Stocks>().UpdateAllStocks(this.time - this.timeTurns[this.turn - 1]); // 주식 업데이트
    }

    public void addEventQueue(EventContainer anEvent)
    {
        this.eventQueue.Add(anEvent.getTriggerDay(), anEvent);
    }

    private void eventCheck()
    {
        for (int i = 0; i < this.eventQueue.Count; i++)
        {
            if (this.eventQueue.Keys[i] > this.date) // 실행 날짜를 충족한 이벤트가 없으면 체크 종료(break)
                break;

            if (this.eventQueue.Values[i].getTriggerTime() > this.time) // 실행 날짜는 충족하나, 시간이 충족되지 않으면 큐의 다음 이벤트 체크(continue)
                continue;

            else
            {
                this.eventQueue.Values[i].executeEvent(); // 조건 모두 충족 시 이벤트 실행

                this.eventCheck(); // 실행 완료 후 이벤트 체크 다시 실행
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
