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

        NPC npc_mrPark = SystemControl.Instance.npcs.getNPC("�ڻ����");
        
        string nameNPC = npc_mrPark.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "�̹��� �ڳ� ���� ���� �ó�.", date));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ģ������ �ʹ� ū ���ڸ� �޾Ƴ�����.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���ϴ� ���� ������ �ʾ�����", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ �Ŷ� Ȯ���� ������.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�ҽ��� ����� �Ŷ� �����ϳ׸�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�츰 �����߳�. ���� ũ��", date, 1.0f));

        Chat chat = new Chat(nameNPC, "�Ա��� Ȯ�εǾ���?", date, 1.0f);
        chat.addEvent<Event_General_GetMoney>(new Event_General_GetMoney(60000000.0));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);


        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "����ߴ� �ݾ׿� �� ����ٳ�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�����մϴ�.", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );


        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� �� ������.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷��� �ڳ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� �����ϸ� ��¼���� �׷���?", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, 
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�ϰ� �־����ϴ�.", date, 1.0f),
            option2: new Chat("player", "��Ե� ��ư��� �̴ϴ�.", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ���̱� �ϳ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ �� ������ �;����� ����.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "���ڵ� �Ҹ��ϱ���.", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ��� ������ �ʹٰ� ���� �ʾҳ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "����� ����̾�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷� ���� ����� �� �Ұ����ְڳ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ����� �غ��ϰ� �ִ���", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ���� ������ ���̴���", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�����մϴ�.", date, 1.0f),
            option2: new Chat("player", "����Ե� �����Ͻó���?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ���� �۰� ���·��� �ϳ׸�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�����ϰԳ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�ڳ׿��� ���� �� ���� �ƴ�����", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���ڴ� ���� ������ ���̾�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "���� �����մϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ �� ģ�����Լ� �� �ðɼ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ �� ������ ����", date, 1.0f));

        Chat chat2 = new Chat(nameNPC, "�ٽ� �� �� ����", date, 1.0f);
        chat2.addEvent<Event_Comet_NewNPC>(new Event_Comet_NewNPC());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat2);

        this.container.deleteEvent();
        Debug.Log("Event_MrPark_intro_00 : control(): ended");
        return true;
    }
}