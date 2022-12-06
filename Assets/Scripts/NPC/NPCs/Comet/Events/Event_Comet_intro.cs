using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Comet_intro : Event_NPC
{
    public Event_Comet_intro()
    {
        Debug.Log("Event_Coment_intro: create: entered");
        int triggerDay = 0;
        int triggerTime = 0;
        int triggerAffection = 0;

        this.evContainer = new EventContainer(triggerDay, triggerTime, triggerAffection);

        this.addEvInit<Event_Comet_intro_00>(new Event_Comet_intro_00(this.evContainer));
    }
}

public class Event_Comet_intro_00 : Event
{
    public Event_Comet_intro_00(EventContainer evContainer) : base(evContainer) { }

    public override bool control()
    {
        NPC npc_comet = SystemControl.Instance.npcs.getNPC("����(��)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "����(��) NPC �׽�Ʈ �մϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׽�Ʈ �޽��� 1��", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׽�Ʈ �޽��� 2��", date, 1.0f));

        Chat option1 = new Chat("player", "�б� ������ 1��", date, 1.0f);
        Chat option2 = new Chat("player", "�б� ������ 2��", date, 1.0f);
        option1.addEvent<Event_Comet_intro_00_branch_00>(new Event_Comet_intro_00_branch_00());
        option2.addEvent<Event_Comet_intro_00_branch_01>(new Event_Comet_intro_00_branch_01());

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: option1,
            option2: option2,
            date: date,
            waitTimeBefore: 1.0f
            )
            );


        return true;
    }
}

public class Event_Comet_intro_00_branch_00 : Event
{
    override public bool control()
    {
        NPC npc_comet = SystemControl.Instance.npcs.getNPC("����(��)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "�б� 1���Դϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�б� 1�� �޽��� 1��", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�б� 1�� �޽��� 2��", date, 1.0f));


        return true;
    }
}

public class Event_Comet_intro_00_branch_01 : Event
{
    override public bool control()
    {
        NPC npc_comet = SystemControl.Instance.npcs.getNPC("����(��)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "�б� 2���Դϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�б� 2�� �޽��� 1��", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�б� 2�� �޽��� 2��", date, 1.0f));


        return true;
    }
}