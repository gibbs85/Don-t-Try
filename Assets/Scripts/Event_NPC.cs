using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_NPC
{
    protected EventContainer evContainer;

    protected Event_NPC()
    {
        this.evContainer = null;
    }

    protected Event_NPC(int triggerDay, int triggerTime, int triggerAffection)
    {
        this.evContainer = new EventContainer(triggerDay, triggerTime, triggerAffection);
    }

    protected void addEvInit<T>(Event evInit) where T : Event
    {
        this.evContainer.addEventLast(evInit);
    }

    public EventContainer getEvContainer()
    {
        return this.evContainer;
    }
}