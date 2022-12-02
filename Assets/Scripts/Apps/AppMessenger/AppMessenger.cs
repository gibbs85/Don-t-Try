using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMessenger : MonoBehaviour
{
    private SortedList<int, ChatContainer> chatrooms;



    private void init()
    {
        this.loadChatRoomList();
    }

    public void openApp()
    {
        this.init();
        this.open_page_ChatRoomList();
    }

    private void loadChatRoomList()
    {
        SystemControl.Instance.msgr.getChatRooms();
    }

    public void open_page_ChatRoomList()
    {
        GameObject pageOpen = GameObject.Find("AppMessenger").transform.Find("ChatRoomList").gameObject;
        pageOpen.SetActive(true);
        pageOpen.GetComponentInChildren<Messenger_ChatRoomList>().page_open();
        //this.pageClose.SetActive(false);
    }
    //public void open_page_ChatRoom();


}
