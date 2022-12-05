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

    public void addChatToBeAdded(string chatRoomName, Chat chat)
    {
        foreach (ChatContainer room in this.chatrooms)
        {
            if (room.getNameChatRoom().Equals(chatRoomName))
            {
                room.addChatToBeAdded(chat);
            }
        }
    }

    public void addChatOptionsToBeAdded(string chatRoomName, ChatWithOptions chatWithOptions)
    {
        foreach (ChatContainer room in this.chatrooms)
        {
            if (room.getNameChatRoom().Equals(chatRoomName))
            {
                room.addChatWithOptions(chatWithOptions);
            }
        }
    }

    public void AddNewChatRoom(string ChatRoomName)
    {
        ChatContainer chatRoom = new ChatContainer(ChatRoomName);
        this.chatrooms.Add(chatRoom);
    }

    public void test_AddNewChatRoom()
    {
        int date = SystemControl.Instance.world.getDate();
        ChatContainer testRoom = new ChatContainer("테스트 채팅방");
        Chat chat = new Chat("테스트 대화상대", "테스트 중입니다.", date);
        Debug.Log("Messenger.cs: test_AddNewChatRoom(): chat.getString(): " + chat.getString());
        testRoom.addChat(chat);

        this.chatrooms.Add(testRoom);
    }

    public void test_AddNewNewChatRoom()
    {
        int date = SystemControl.Instance.world.getDate();
        ChatContainer testRoom = new ChatContainer("테스트방 둘");
        //Chat chat = new Chat("테스트 상대 둘", "테스트 중입니다.", date);
        //Debug.Log("Messenger.cs: test_AddNewChatRoom(): chat.getString(): " + chat.getString());
        //testRoom.addChat(chat);

        this.chatrooms.Add(testRoom);
    }
}
