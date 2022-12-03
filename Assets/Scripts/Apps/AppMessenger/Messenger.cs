using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Messenger
{
    private List<ChatContainer> chatrooms;

    public Messenger()
    {
        this.init();
    }

    private void init()
    {
        this.chatrooms = new List<ChatContainer>();
    }

    public List< ChatContainer> getChatRooms()
    {
        return this.chatrooms;
    }

    public void new_game()
    {
        this.init();
    }

    public void addChat(string chatRoomName, Chat chat)
    {

        foreach (ChatContainer room in this.chatrooms)
        {
            if (room.getNameChatRoom().Equals(chatRoomName))
            {
                room.addChat(chat);
            }
        }
    }

    public void test_AddNewChatRoom()
    {
        int date = SystemControl.Instance.world.getDate();
        ChatContainer testRoom = new ChatContainer("�׽�Ʈ ä�ù�");
        Chat chat = new Chat("�׽�Ʈ ��ȭ���", "�׽�Ʈ ���Դϴ�.", date);
        Debug.Log("Messenger.cs: test_AddNewChatRoom(): chat.getString(): " + chat.getString());
        testRoom.addChat(chat);

        this.chatrooms.Add(testRoom);
    }

    public void test_AddNewNewChatRoom()
    {
        int date = SystemControl.Instance.world.getDate();
        ChatContainer testRoom = new ChatContainer("�׽�Ʈ�� ��");
        //Chat chat = new Chat("�׽�Ʈ ��� ��", "�׽�Ʈ ���Դϴ�.", date);
        //Debug.Log("Messenger.cs: test_AddNewChatRoom(): chat.getString(): " + chat.getString());
        //testRoom.addChat(chat);

        this.chatrooms.Add(testRoom);
    }
}