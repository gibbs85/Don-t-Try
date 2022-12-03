using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnChatRoomList : MonoBehaviour
{
    private ChatContainer chatRoom;

    public void setChatRoom(ChatContainer chatRoom)
    {
        Debug.Log("BtnChatRoomList.cs: setChatRoom(): entered");
        this.chatRoom = chatRoom;
        Debug.Log("BtnChatRoomList.cs: setChatRoom(): chatRoom.getNameChatRoom(): " + chatRoom.getNameChatRoom());
        Debug.Log("BtnChatRoomList.cs: setChatRoom(): this.chatRoom.getNameChatRoom(): " + this.chatRoom.getNameChatRoom());
    }

    public void open_page()
    {
        GameObject page_open = GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoom").gameObject;

        Debug.Log("BtnChatRoomList.cs: open_page():");
        page_open.SetActive(true);
        page_open.GetComponentInChildren<Messenger_ChatRoom>().page_open(this.chatRoom);

        GameObject page_close = GameObject.Find("PhoneOnHand").transform.Find("AppMessenger").transform.Find("ChatRoomList").gameObject;
        page_close.SetActive(false);
    }

}
