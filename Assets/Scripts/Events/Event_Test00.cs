using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Test00
{
    private EventContainer evContainer;

    public Event_Test00()
    {
        this.evContainer = new EventContainer(0, 12, 0);

        Debug.Log("Event_Test00: created");
        this.evContainer.addEventFirst(new ev_init(this.evContainer));
        Debug.Log("Event_Test00: firstEvent: " + this.evContainer.debugGetFirstEvent());
    }

    public EventContainer getEvContainer()
    {
        return this.evContainer;
    }
}

public class ev_init : Event
{
    public ev_init(EventContainer container)
    {
        Debug.Log("Event_Test00: ev_init : created");
        this.container = container;
    }

    public override bool control()
    {
        Debug.Log("Event_Test00: ev_init : entered");
        Debug.Log("event count: " + this.container.debugGetEvCount());
        this.container.addEventLast(new ev_00_newNPC(this.container));
        Debug.Log("event count: " + this.container.debugGetEvCount());
        this.container.deleteEvent();
        this.container.executeEvent();

        return true;
    }
}

public class ev_00_newNPC : Event
{

    public ev_00_newNPC(EventContainer container)
    {
        this.container = container;
    }

    public override bool control()
    {
        Debug.Log("Event_Test00: ev_00_newNPC : entered");

        NPC newNPC = new NPC_MrPark();
        SystemControl.Instance.npcs.newNPC(newNPC);

        this.container.deleteEvent();
        return true;
    }
}