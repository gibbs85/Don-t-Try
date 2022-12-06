using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC
{
    protected string name;
    protected int affection;
    protected LinkedList<EventContainer> eventsNPC;
    //private bool queable;

    protected NPC()
    {
        this.name = "NONE";
        this.affection = 0;
        this.eventsNPC = null;
    }

    public NPC(string name)
    {
        this.name = name;
        this.affection = 0;
        this.eventsNPC = new LinkedList<EventContainer>();
    }

    public NPC(string name, int affection)
    {
        this.name = name;
        this.affection = affection;
        this.eventsNPC = new LinkedList<EventContainer>();
    }

    void init()
    {
        //
    }

    public void eventCheck()
    {
        Debug.Log("NPC.cs: eventCheck(): entered");

        if (this.eventsNPC.Count == 0)
            return;

        EventContainer anEvent = this.eventsNPC.First.Value;
        int dateToday = SystemControl.Instance.world.getDate();
        int dateTrigger = anEvent.getTriggerDay();
        int timeNow = SystemControl.Instance.world.getTime();
        int triggerTime = anEvent.getTriggerTime();
        int triggerAffection = anEvent.getTriggerAffection();

        if (this.affection < triggerAffection)
            return;

        if ( (dateToday > dateTrigger))
        {
            SystemControl.Instance.world.addEventQueue(anEvent);
            this.delEvent(anEvent);
            Debug.Log("NPC.cs: eventCheck(): world.addEventQueue, this.delEvent() if 1");
            return;
        }
        if ( (dateToday == dateTrigger) &&  (timeNow >= triggerTime))
        {
            SystemControl.Instance.world.addEventQueue(anEvent);
            this.delEvent(anEvent);
            Debug.Log("NPC.cs: eventCheck(): world.addEventQueue, this.delEvent() if 2");
            return;
        }
    }

    private void delEvent(EventContainer anEvent)
    {
        this.eventsNPC.Remove(anEvent);
    }

    public string getName()
    {
        return this.name;
    }
    public int getAffection()
    {
        return this.affection;
    }
}
