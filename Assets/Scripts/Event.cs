using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    protected EventContainer container;

    public Event()
    {
        this.container = null;
    }

    public Event(EventContainer evContainer)
    {
        this.container = evContainer;
    }

    protected void setEvContainer(EventContainer evContainer)
    {
        this.container = evContainer;
    }

    public virtual bool control()
    {
        return false;
    }
}
