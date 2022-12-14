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
    public void new_game();                     // 추가 작업 필요
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

    public void new_game()
    {
        this.turn = 1;
        this.time = this.timeTurns[this.turn];
        this.day = 1;

        this.addEventQueue(new Event_Test00().getEvContainer());
        //this.addEventQueue(new Event_TestNewMsgLive00().getEvContainer());
    }

    private void nextDay()
    {
        /*
         * 테스트
         */

        //if (this.date == 0)
        //{
        //    SystemControl.Instance.msgr.test_AddNewChatRoom();
        //}
        //else if (this.date < 3)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "이것도 받아 보시지", this.date));
        //}
        //if (this.date == 6)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "이걸 안 보네", this.date));
        //}
        //if (this.date == 9)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "왜 안 읽음", this.date));
        //}
        //if (this. date == 10)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "야", this.date));
        //}
        //if (this.date == 11)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "야", this.date));
        //}
        //if (this.date == 12)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "야", this.date));
        //}
        //if (this.date == 13)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("player", "뭐", this.date));
        //}
        //if (this.date == 14)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("player", "왜", this.date));
        //}
        //if (this.date > 15)
        //{
        //    SystemControl.Instance.msgr.addChat("테스트 채팅방", new Chat("테스트 대화상대", "야야야야야야야야야야야야야야야야야야야야야야야야야", this.date));
        //}
        //if (this.date == 16)
        //{
        //    SystemControl.Instance.msgr.test_AddNewNewChatRoom();
        //    SystemControl.Instance.msgr.addChat("테스트방 둘", new Chat("테스트 상대 둘", "자네가 답을 안한다더군", this.date));
        //}
        //SystemControl.Instance.msgr.



        /*
         */


        //Debug.Log("World.cs: nextDay(): entered");
        this.date++; // 날짜 진행
        this.day++; // 요일 진행
        if (this.day > (int)DaysOfTheWeek.SUNDAY)
            this.day = (int)DaysOfTheWeek.MONDAY;
        this.turn = 1; // 플레이가 시작되는 두 번째[9, '10', 13, 15] 턴
        this.time = this.timeTurns[this.turn];

        SystemControl.Instance.player.exhaustFatigue(-5);
        //Debug.Log("World.cs: nextDay(). exhaustFatigue: completed");
        SystemControl.Instance.bank.update(1);
        //Debug.Log("World.cs: nextDay(). bank.update: completed");

        UI_GamePlay.update_time();
        UI_GamePlay.update_date();

        // nextTurn으로 복귀
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
        this.eventCheck();
        SystemControl.Instance.npcs.eventCheck();
        //UI_GamePlay.update_stockApp();
        //UI_GamePlay.update_bankApp();
        //Debug.Log("World.cs: nextTurn(): (inside) completed");

    }

    public void addEventQueue(EventContainer anEvent)
    {
        this.eventQueue.Add(anEvent.getTriggerDay(), anEvent);
        anEvent.debugPrintInfo();
    }

    private void eventCheck()
    {
        Debug.Log("world.cs: eventCheck(): entered");
        Debug.Log("world.cs: eventCheck(): eventQueue.Count: "+this.eventQueue.Count);

        List<int> keysToDelete = new List<int>();

        for (int i = 0; i < this.eventQueue.Count; i++)
        {
            Debug.Log("world.cs: eventCheck(): for i: " + i);
            if (this.eventQueue.Keys[i] > this.date)
            { // 실행 날짜를 충족한 이벤트가 없으면 체크 종료(break)
                Debug.Log("world.cs: eventCheck(): Keys[i]: " + this.eventQueue.Keys[i]);
                break;
            }

            EventContainer evContainer = this.eventQueue.Values[i];

            if (evContainer.getTriggerTime() > this.time)
            { // 실행 날짜는 충족하나, 시간이 충족되지 않으면 큐의 다음 이벤트 체크(continue)
                Debug.Log("world.cs: eventCheck(): Values[i]: " + evContainer.getTriggerTime());
                Debug.Log("world.cs: eventCheck(): this.time: " + this.time);
                continue;
            }

            else
            {
                Debug.Log("world.cs: eventCheck(): execute()");
                Debug.Log("world.cs: eventCheck(): eventQueue.Values[i]: " + evContainer);
                evContainer.executeEvent();
               //this.eventQueue.Remove(i);
                keysToDelete.Add(this.eventQueue.Keys[i]);
                Debug.Log("world.cs: eventCheck(): keysToDelete.Count: "+keysToDelete.Count);
                Debug.Log("world.cs: eventCheck(): keysToDelete.i: " + i);
                Debug.Log("world.cs: eventCheck(): this.eventQueue.Keys[i]: " + this.eventQueue.Keys[i]);
            }
        }

        if (keysToDelete.Count > 0)
        {
            Debug.Log("world.cs: eventCheck(): delete: enetered" );
            Debug.Log("world.cs: eventCheck(): eventQueue.Count: " + this.eventQueue.Count);
            foreach (int keys in keysToDelete)
                this.eventQueue.Remove(keys);
            Debug.Log("world.cs: eventCheck(): eventQueue.Count: " + this.eventQueue.Count);
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
