using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChatContainer
{
    public string nameChatRoom;
    public int unread;
    private LinkedList<Chat> chatLog;

    //public bool addChat(Chat chat);
    //public string getNameChatRoom();
    //public void setToRead();

    public ChatContainer(string nameChatRoom)
    {
        this.nameChatRoom = nameChatRoom;
        this.unread = 0;
        this.chatLog = new LinkedList<Chat>();
    }

    public void addChat(Chat chat)
    {
        this.chatLog.AddLast(chat);
    }

    public string getNameChatRoom()
    {
        return this.nameChatRoom;
    }

    public Chat getChat(int index)
    {
        return this.chatLog.ElementAt(index);
    }

    public void setToRead()
    {
        //
    }

    public int getUnread()
    {
        return this.unread;
    }
}
