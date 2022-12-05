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

        NPC npc_mrPark = SystemControl.Instance.npcs.getNPC("박사장님");
        
        string nameNPC = npc_mrPark.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "이번에 자네 덕을 많이 봤네.", date));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "젊은 친구에게 너무 큰 투자를 받아내었어.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "급하던 때라 말하지 않았으나", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "성공할 거란 확신은 없었네.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "소식은 들었을 거라 생각하네만", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "우린 성공했네. 아주 크게", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "*입금 메시지.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "약속했던 금액에 더 얹었다네.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "감사합니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "내가 할 말이지.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그런데 자네", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "내가 실패하면 어쩌려고 그랬나?", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "믿고 있었습니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "좋은 말이긴 하나", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "이제는 좀 말리고 싶어지는 구만.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "투자도 할만하군요.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "내가 방금 말리고 싶다고 하지 않았나.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "곤란한 사람이야", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그럼 내가 사람을 좀 소개해주겠네.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "작은 사업을 준비하고 있던데", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "내 눈엔 괜찮아 보이더군", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "사장님도 투자하시나요?", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "물론 나도 작게 보태려고 하네만", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "조심하게나", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "자네에게 내가 할 말은 아니지만", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "투자는 아주 위험한 말이야", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat("player", "말씀 감사합니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그래.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "연락은 그 친구에게서 곧 올걸세", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "다음에 또 보도록 하지", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "다시 한 번 고맙네.", date, 1.0f));

        this.container.deleteEvent();
        Debug.Log("Event_MrPark_intro_00 : control(): ended");
        return true;
    }
}