using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer
{
    protected int triggerDay;
    protected int triggerTime;
    protected int triggerAffection;
    protected LinkedList<Event> events;

    public EventContainer()
    {
        this.triggerDay = 0;
        this.triggerTime = 0;
        this.triggerAffection = 0;
        this.events = new LinkedList<Event>();
    }

    public EventContainer(int triggerDay, int triggerTime, int triggerAffection)
    {
        this.triggerDay = triggerDay;
        this.triggerTime = triggerTime;
        this.triggerAffection = triggerAffection;
        this.events = new LinkedList<Event>();
    }

    public void addEventLast(Event anEvent)
    {
        this.events.AddLast(anEvent);
    }

    public void addEventFirst(Event anEvent)
    {
        this.events.AddFirst(anEvent);
    }

    public void executeEvent()
    {
        Debug.Log("EventContainer.cs: executeEvent. this.events.First.Value: " + this.events.First.Value);
        this.events.First.Value.control();
    }

    public void deleteEvent()
    {
        this.events.RemoveFirst();
    }


    public int getTriggerDay()
    {
        return this.triggerDay;
    }

    public int getTriggerTime()
    {
        return this.triggerTime;
    }

    public int getTriggerAffection()
    {
        return this.triggerAffection;
    }

    public void debugPrintInfo()
    {
        Debug.Log("DEBUG INFO: triggerDay: " + this.triggerDay);
        Debug.Log("DEBUG INFO: triggerTime: " + this.triggerTime);
        Debug.Log("DEBUG INFO: triggerAffection: " + this.triggerAffection);
        Debug.Log("DEBUG INFO: eventsCount: " + this.events.Count);
    }

    public Event debugGetFirstEvent()
    {
        return this.events.First.Value;
    }

    public int debugGetEvCount()
    {
        return this.events.Count;
    }
}
