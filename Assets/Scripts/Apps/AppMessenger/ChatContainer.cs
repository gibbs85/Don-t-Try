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
        this.unread++;

        if (GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoom").gameObject.activeSelf == true)
            GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoom").GetComponent<Messenger_ChatRoom>().refresh_msg_added();
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

    public string getThumbnail()
    {
        string thumb = this.chatLog.Last().getString();

        if (thumb.Length > 13)
        {
            thumb = thumb.Substring(0, 13);
            thumb = thumb + "......";
        }

        return thumb;
    }

    public int getCountChat()
    {
        return this.chatLog.Count;
    }

    public void readChecked()
    {
        int unreadIndexStart = this.unread;
        for (int i = 0; i < unreadIndexStart; i++)
        {
            this.chatLog.ElementAt(this.chatLog.Count - unreadIndexStart + i).doneRead();
            this.unread--;
        }
    }

    public void readChecked(int count)
    {

    }
}
