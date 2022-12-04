using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC
{
    private string name;
    private int affection;
    private LinkedList<EventContainer> eventsNPC;
    //private bool queable;


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
        EventContainer anEvent = this.eventsNPC.First.Value;
        int dateToday = SystemControl.Instance.world.getDate();
        int dateTrigger = anEvent.getTriggerDay();
        int triggerAffection = anEvent.getTriggerAffection();

        if ( (dateToday >= dateTrigger) && (this.affection >= triggerAffection))
        {
            SystemControl.Instance.world.addEventQueue(anEvent);
            this.delEvent(anEvent);
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
