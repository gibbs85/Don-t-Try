using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChatContainer
{
    public string nameChatRoom;
    public int unread;
    private LinkedList<Chat> chatLog;
    private LinkedList<Chat> chatTobeAdded;
    //private ArrayList chatTobeAdded;


    //public bool addChat(Chat chat);
    //public string getNameChatRoom();
    //public void setToRead();

    public ChatContainer(string nameChatRoom)
    {
        this.nameChatRoom = nameChatRoom;
        this.unread = 0;
        this.chatLog = new LinkedList<Chat>();
        this.chatTobeAdded = new LinkedList<Chat>();
    }

    public void addChat(Chat chat)
    {
        this.chatLog.AddLast(chat);
        this.unread++;

        GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").transform.Find("BtnSNS").GetComponent<MessengerHomeIcon>().setUnread(this.unread);


        if (GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoom").gameObject.activeSelf == true)
        {
            GameObject chatRoomOpendObj = GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoom").gameObject;
            string chatRoomOpendName = chatRoomOpendObj.GetComponent<Messenger_ChatRoom>().getNameChatRoom();

            if (chatRoomOpendName.Equals(this.nameChatRoom))
                GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoom").GetComponent<Messenger_ChatRoom>().refresh_msg_added();
            else
            {
                GameObject.Find("PhoneOnHand").GetComponent<PhoneUI>().noti(this);
            }
        }
        else
            GameObject.Find("PhoneOnHand").GetComponent<PhoneUI>().noti(this);
    }

    public void addChatToBeAdded(Chat chat)
    {
        this.chatTobeAdded.AddLast(chat);
    }

    public void addChatWithOptions(ChatWithOptions chatWithOptions)
    {
        this.chatTobeAdded.AddLast(chatWithOptions);
    }

    private Chat getChatWithOptions()
    {
        if (this.chatTobeAdded.First.Value.getCountOptions() > 0)
        {
            return this.chatTobeAdded.First.Value;
        }
        else
        {
            Debug.Log("ChatContainer.cs: getChatWithOptions: doesn't have options");
            Debug.Log("ChatContainer.cs: getChatWithOptions: returning null");
            return null;
        }

    }

    public string getNameChatRoom()
    {
        return this.nameChatRoom;
    }

    public Chat getChat(int index)
    {
        return this.chatLog.ElementAt(index);
    }

    public Chat getChatToBeAdded(int index)
    {
        return this.chatTobeAdded.ElementAt(index);
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

    public int getCountChatToBeAdded()
    {
        return this.chatTobeAdded.Count;
    }

    public void toLog()
    {
        //Debug.Log("toLog: entered");
        this.chatLog.AddLast(this.chatTobeAdded.First.Value);
        //Debug.Log("toLog: addChat passed");
        this.chatTobeAdded.RemoveFirst();
        //Debug.Log("toLog: removeFirst passed");
    }

    public void optionSelect(int index)
    {
        Chat selectedChat = this.getChatWithOptions().getOption(index);
        this.chatTobeAdded.RemoveFirst();
        this.chatTobeAdded.AddFirst(selectedChat);
    }

    public void readChecked()
    {
        int unreadIndexStart = this.unread;
        for (int i = 0; i < unreadIndexStart; i++)
        {
            this.chatLog.ElementAt(this.chatLog.Count - unreadIndexStart + i).doneRead();
            this.unread--;
        }
        GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").transform.Find("BtnSNS").GetComponent<MessengerHomeIcon>().setUnread(this.unread);
    }

    public void readChecked(int count)
    {

    }
}
