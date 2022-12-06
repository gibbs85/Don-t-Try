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
        NPC npc_comet = SystemControl.Instance.npcs.getNPC("혜성(주)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;

        SystemControl.Instance.msgr.AddNewChatRoom(nameChatRoom);

        int date = SystemControl.Instance.world.getDate();
        SystemControl.Instance.msgr.addChat(nameChatRoom, new Chat(nameNPC, "안녕하세요", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "박 사장님께 말씀 들었습니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "투자할 곳을 찾고 계시다구요?", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "(광고)혜성(주)\n안녕하세요 AI분석 [신호등] 투자입니다^^\n", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "이런", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "방금 문자는 잘못 보내드린 겁니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "죄송합니다.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "그게 당신 사업입니까?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "네 맞습니다", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "사장님께 자세한 얘기는 듣지 못하신 것 같네요.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "......", date, 1.0f),
            option2: new Chat("player", "네 좀 놀랐습니다", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "예..뭐", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "어떻게 보일지는 알고 있습니다만", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "제가 그 흔한 사기를 치고 있는 건 아닙니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "시장 분석과 AI개발을 제대로 하고 있고", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "수익도 꾸준히 나고 있습니다.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "그렇군요", date, 1.0f),
            option2: new Chat("player", "수익이 얼마나 납니까?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "믿지 못하실것 같아", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "정확히 모두 다 공개드리자면", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "지금 시장에 있는 모 주식 9개와 암호화폐 3종으로", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "지난 반년 간 80% 정도 돈을 불렸습니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "다만...", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "다만?", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "180%가 된 그 돈이 1800만원이 조금 안됩니다.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "자본이 너무 부족하다 그 말씀이시군요", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "네 맞습니다", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그래서 투자를 받아보려 하는 것이지요.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "쉽지 않네요", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "네.. 맞습니다", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "주식으로 돈 불려줄테니 돈을 빌려달라는 꼴이라는 게", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "믿음이 전혀 안 간다는 것은 알고 있습니다.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "......", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그래서 제가 제안 드리는 것은", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "소액만 투자하여 맡겨보시고", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "마음에 드신다면", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그 다음을 얘기해보는 게 어떤가하는 방안입니다", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "박 사장님과도 같은 방안으로 얘기가 되어있습니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "물론 투자하지 않으시겠다 하여도 괜찮습니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "전적으로 선생님의 선택이십니다.", date, 1.0f));

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom,
            new Chat(
            nameSpeaker: "player",
            option1: new Chat("player", "소액이라면 얼마나 생각하고 계신 겁니까", date, 1.0f),
            date: date,
            waitTimeBefore: 1.0f
            )
            );

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "천 만원 정도면 어떨까 싶습니다.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "사업 투자비 치고 적다면 적습니다만", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "제 사업이 사업이고, 상황이 상황이니까요.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "어떻게 하시고 싶습니까?", date, 1.0f));

        Chat option1 = new Chat("player", "500만 해봅시다.", date, 1.0f);
        Chat option2 = new Chat("player", "1000만원 해봅시다.", date, 1.0f);
        Chat option3 = new Chat("player", "2000만원 해봅시다.", date, 1.0f);
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


        NPC npc_comet = SystemControl.Instance.npcs.getNPC("혜성(주)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그러시군요.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "네, 좋습니다", date, 1.0f));

        Chat chat = new Chat(nameNPC, "저도 조심스럽습니다. 오히려 좋아요.", date, 1.0f);
        chat.addEvent<Event_Coment_intro_01>(new Event_Coment_intro_01());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);


        return true;
    }
}

public class Event_Comet_intro_00_branch_01 : Event
{
    override public bool control()
    {


        NPC npc_comet = SystemControl.Instance.npcs.getNPC("혜성(주)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "네, 좋습니다", date, 1.0f));

        Chat chat = new Chat(nameNPC, "이 정도면 기대를 조금 해보셔도 될 겁니다.", date, 1.0f);
        chat.addEvent<Event_Coment_intro_01>(new Event_Coment_intro_01());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);

        return true;
    }
}

public class Event_Comet_intro_00_branch_02 : Event
{
    override public bool control()
    {


        NPC npc_comet = SystemControl.Instance.npcs.getNPC("혜성(주)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "통이 크시군요.", date, 1.0f));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "박 사장님 말씀이 이해가 갑니다.", date, 1.0f));

        Chat chat = new Chat(nameNPC, "이 정도면 기대를 조금 해보셔도 될 겁니다.", date, 1.0f);
        chat.addEvent<Event_Coment_intro_01>(new Event_Coment_intro_01());
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, chat);

        return true;
    }
}

public class Event_Coment_intro_01 : Event
{
    override public bool control()
    {
        NPC npc_comet = SystemControl.Instance.npcs.getNPC("혜성(주)");
        string nameNPC = npc_comet.getName();
        string nameChatRoom = nameNPC;
        int date = SystemControl.Instance.world.getDate();

        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "그럼 수익이 나면 다시 연락을 드리겠습니다.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "점 찍어둔 것들이 있어서, 빠르면 한 달이 안 걸릴 수도 있겠습니다.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "믿음과 투자 감사합니다.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "다음에 뵙겠습니다.", date));
        SystemControl.Instance.msgr.addChatToBeAdded(nameChatRoom, new Chat(nameNPC, "감사합니다.", date));

        return true;
    }
}