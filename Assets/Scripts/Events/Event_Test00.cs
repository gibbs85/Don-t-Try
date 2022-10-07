using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Test00 : EventContainer
{
    public Event_Test00()
    {
        this.triggerDay = 5;
        this.triggerTime = 1000;
        this.triggerAffection = 0;

        this.addEventFirst(new ev_init(this));
    }
}

struct ev_init : Event
{
    EventContainer container;

    public ev_init(EventContainer container)
    {
        this.container = container;
    }

    public bool control()
    {
        Debug.Log("Event_Test00: ev_init : EXECUTED");
        this.container.deleteEvent();
        this.container.addEventFirst(new ev_00(this.container));
        this.container.executeEvent();

        return true;
    }
}

struct ev_00 : Event
{
    EventContainer container;

    public ev_00(EventContainer container)
    {
        this.container = container;
    }

    public bool control()
    {
        Debug.Log("Event_Test00: ev_00 : EXECUTED");
        this.container.deleteEvent();
        return true;
    }
}