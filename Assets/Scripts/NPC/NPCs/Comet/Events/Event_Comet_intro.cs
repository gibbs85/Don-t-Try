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
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "�ȳ��ϼ���", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ����Բ� ���� ������ϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ ���� ã�� ��ôٱ���?", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "(����)����(��)\n�ȳ��ϼ��� AI�м� [��ȣ��] �����Դϴ�^^\n", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�̷�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��� ���ڴ� �߸� �����帰 �̴ϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�˼��մϴ�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�װ� ��� ����Դϱ�?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� �½��ϴ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "����Բ� �ڼ��� ���� ���� ���Ͻ� �� ���׿�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "......", date, 1.0f),
            option2: new Chat("player", "�� �� ������ϴ�", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��..��", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��� �������� �˰� �ֽ��ϴٸ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� �� ���� ��⸦ ġ�� �ִ� �� �ƴմϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� �м��� AI������ ����� �ϰ� �ְ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���͵� ������ ���� �ֽ��ϴ�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�׷�����", date, 1.0f),
            option2: new Chat("player", "������ �󸶳� ���ϱ�?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ���Ͻǰ� ����", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��Ȯ�� ��� �� �����帮�ڸ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ���忡 �ִ� �� �ֽ� 9���� ��ȣȭ�� 3������", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� �ݳ� �� 80% ���� ���� �ҷȽ��ϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�ٸ�...", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�ٸ�?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "180%�� �� �� ���� 1800������ ���� �ȵ˴ϴ�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�ں��� �ʹ� �����ϴ� �� �����̽ñ���", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� �½��ϴ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷��� ���ڸ� �޾ƺ��� �ϴ� ��������.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "���� �ʳ׿�", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��.. �½��ϴ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�ֽ����� �� �ҷ����״� ���� �����޶�� ���̶�� ��", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ ���� �� ���ٴ� ���� �˰� �ֽ��ϴ�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "......", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷��� ���� ���� �帮�� ����", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�Ҿ׸� �����Ͽ� �ðܺ��ð�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ ��Ŵٸ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ������ ����غ��� �� ����ϴ� ����Դϴ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ����԰��� ���� ������� ��Ⱑ �Ǿ��ֽ��ϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� �������� �����ðڴ� �Ͽ��� �������ϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�������� �������� �����̽ʴϴ�.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "�Ҿ��̶�� �󸶳� �����ϰ� ��� �̴ϱ�", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "õ ���� ������ ��� �ͽ��ϴ�.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��� ���ں� ġ�� ���ٸ� �����ϴٸ�", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ����� ����̰�, ��Ȳ�� ��Ȳ�̴ϱ��.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��� �Ͻð� �ͽ��ϱ�?", date, 1.0f));

        Chat option1 = new Chat("player", "500�� �غ��ô�.", date, 1.0f);
        Chat option2 = new Chat("player", "1000���� �غ��ô�.", date, 1.0f);
        Chat option3 = new Chat("player", "2000���� �غ��ô�.", date, 1.0f);
        option1.addEvent<Event_Comet_intro_00_branch_00>(new Event_Comet_intro_00_branch_00());
        option1.addEvent<Event_General_GetMoney>(new Event_General_GetMoney(-5000000.0));
        option2.addEvent<Event_Comet_intro_00_branch_01>(new Event_Comet_intro_00_branch_01());
        option2.addEvent<Event_General_GetMoney>(new Event_General_GetMoney(-10000000.0));
        option3.addEvent<Event_Comet_intro_00_branch_02>(new Event_Comet_intro_00_branch_02());
        option3.addEvent<Event_General_GetMoney>(new Event_General_GetMoney(-20000000.0));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: option1,
            option2: option2,
            option3: option3,
            date: date,
            waitTimeBefore: 1.0f
            )
            );


        this.container.deleteEvent();
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
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷��ñ���.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��, �����ϴ�", date, 1.0f));

        Chat chat = new Chat(nameNPC, "���� ���ɽ������ϴ�. ������ ���ƿ�.", date, 1.0f);
        chat.addEvent<Event_Coment_intro_01>(new Event_Coment_intro_01());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);


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
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "��, �����ϴ�", date, 1.0f));

        Chat chat = new Chat(nameNPC, "�� ������ ��븦 ���� �غ��ŵ� �� �̴ϴ�.", date, 1.0f);
        chat.addEvent<Event_Coment_intro_01>(new Event_Coment_intro_01());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);

        return true;
    }
}

public class Event_Comet_intro_00_branch_02 : Event
{
    override public bool control()
    {


        NPC npc_comet = SystemControl.Instance.npcs.getNPC("����(��)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "���� ũ�ñ���.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ����� ������ ���ذ� ���ϴ�.", date, 1.0f));

        Chat chat = new Chat(nameNPC, "�� ������ ��븦 ���� �غ��ŵ� �� �̴ϴ�.", date, 1.0f);
        chat.addEvent<Event_Coment_intro_01>(new Event_Coment_intro_01());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);

        return true;
    }
}

public class Event_Coment_intro_01 : Event
{
    override public bool control()
    {
        NPC npc_comet = SystemControl.Instance.npcs.getNPC("����(��)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�׷� ������ ���� �ٽ� ������ �帮�ڽ��ϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�� ���� �͵��� �־, ������ �� ���� �� �ɸ� ���� �ְڽ��ϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ ���� �����մϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "������ �˰ڽ��ϴ�.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "�����մϴ�.", date));

        return true;
    }
}