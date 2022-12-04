using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TestNewMsgLive00
{
    private EventContainer evContainer;

    public Event_TestNewMsgLive00()
    {
        this.evContainer = new EventContainer(2, 12, 0);

        Debug.Log("Event_TestNewMsgLive00: created");

        this.evContainer.addEventFirst(new ev_TestNewMsgLive00_0(this.evContainer));
        Debug.Log("Event_TestNewMsgLive00: firstEvent: " + this.evContainer.debugGetFirstEvent());
    }

    public EventContainer getEvContainer()
    {
        return this.evContainer;
    }
}

public class ev_TestNewMsgLive00_0 : Event
{
    EventContainer container;

    public ev_TestNewMsgLive00_0(EventContainer container)
    {
        Debug.Log("Event_TestNewMsgLive00: ev_TestNewMsgLive00_0 : created");
        this.container = container;
    }

    public override bool control()
    {
        Debug.Log("Event_TestNewMsgLive00: ev_TestNewMsgLive00_0 : entered");
        Debug.Log("event count: " + this.container.debugGetEvCount());
        this.container.addEventLast(new ev_TestNewMsgLive00_1(this.container));
        Debug.Log("event count: " + this.container.debugGetEvCount());
        this.container.deleteEvent();
        this.container.executeEvent();

        return true;
    }
}

public class ev_TestNewMsgLive00_1 : Event
{
    EventContainer container;

    public ev_TestNewMsgLive00_1(EventContainer container)
    {
        this.container = container;
    }

    public override bool control()
    {
        Debug.Log("ev_TestNewMsgLive00_0 : control(): entered");

        NPC newNPC = new NPC("첫 대화 상대");
        SystemControl.Instance.npcs.newNPC(newNPC);

        SystemControl.Instance.msgr.AddNewChatRoom("첫 대화방");

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat("첫 대화방", new Chat("첫 대화 상대", "Event_Test00에서 npc와 채팅을 추가하였습니다.", date));

        SystemControl.Instance.msgr.addChatToBeAdded("첫 대화방", new Chat("첫 대화 상대", "tobeadded에 추가된 메시지입니다. 번호: 00, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded("첫 대화방", new Chat("첫 대화 상대", "tobeadded에 추가된 메시지입니다. 번호: 01, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded("첫 대화방", new Chat("첫 대화 상대", "tobeadded에 추가된 메시지입니다. 번호: 02, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded("첫 대화방", new Chat("첫 대화 상대", "tobeadded에 추가된 메시지입니다. 번호: 03, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded("첫 대화방", new Chat("첫 대화 상대", "tobeadded에 추가된 메시지입니다. 번호: 04, waittime: 1.0f", date, 1.0f));


        this.container.deleteEvent();
        return true;
    }
}