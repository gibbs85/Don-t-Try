using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MrPark_intro : Event_NPC
{
    public Event_MrPark_intro()
    {
        int triggerDay = 1;
        int triggerTime = 12;
        int triggerAffection = 0;

        this.evContainer = new EventContainer(triggerDay, triggerTime, triggerAffection);


        Debug.Log("Event_MrPark_intro_00 : create(): entered");
        this.addEvInit<Event_MrPark_intro_00>(new Event_MrPark_intro_00(this.evContainer));


    }
}

public class Event_MrPark_intro_00 : Event
{
    public Event_MrPark_intro_00(EventContainer evContainer) : base(evContainer) { }

    public override bool control()
    {
        Debug.Log("Event_MrPark_intro_00 : control(): entered");

        NPC npc_mrPark = SystemControl.Instance.npcs.getNPC("박사장");
        
        string nameNPC = npc_mrPark.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "프로필 메시지 테스트합니다.", date));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "프로필 메시지 테스트합니다. toBeAdded 첫 번째", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "tobeadded에 추가된 메시지입니다. 번호: 01, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "tobeadded에 추가된 메시지입니다. 번호: 02, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "tobeadded에 추가된 메시지입니다. 번호: 03, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "tobeadded에 추가된 메시지입니다. 번호: 04, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "player가 말 합니다. 번호: 05, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "player가 말 합니다. 번호: 06, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "tobeadded에 추가된 메시지입니다. 번호: 07, waittime: 1.0f", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "tobeadded에 추가된 메시지입니다. 번호: 08, waittime: 1.0f", date, 1.0f));


        this.container.deleteEvent();
        Debug.Log("Event_MrPark_intro_00 : control(): ended");
        return true;
    }
}