using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public struct chat : Chat
//{
//    public string nameSpeaker;
//    public string dialog;
//    public int date;
//    public bool read;

//    override public bool control()
//    {
//        return false;
//    }
//    public override bool getRead()
//    {
//        if (this.read == true)
//        {
//            return true;
//        }
//        else
//            return false;
//    }
//    public override string getString()
//    {
//        return this.dialog;
//    }
//}

public class Messenger
{
    private SortedList<int, ChatContainer> chatrooms;

    public Messenger()
    {
        this.init();
    }

    private void init()
    {
        this.chatrooms = new SortedList<int, ChatContainer>();
    }

    public SortedList<int, ChatContainer> getChatRooms()
    {
        return this.chatrooms;
    }

    public void new_game()
    {
        this.init();
    }

    //public void addChat(string chatRoomName)
    //{
    //    foreach(ChatContainer room in this.chatrooms)
    //    {
    //        if (room.getNameChatRoom().Equals(chatRoomName))
    //        {
    //            room.addChat(cc);
    //        }
    //    }
    //}

    //public void test_AddNewChatRoom()
    //{
    //    ChatContainer testRoom = new ChatContainer("�׽�Ʈ ä�ù�");
    //    chat cc = new chat();
    //    cc.nameSpeaker = "�׽�Ʈ ��ȭ���";
    //    cc.dialog = "�׽�Ʈ ���Դϴ�.";
    //    cc.date = 0;
    //    cc.read = false;
    //    testRoom.addChat(cc);

    //    this.chatrooms.Add(testRoom);
    //}
}
