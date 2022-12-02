using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Messenger_ChatRoomList : MonoBehaviour
{
    public GameObject phoneHome;
    public GameObject pageThis;
    public GameObject pageClose;
    public GameObject pageGoBack;

    public void page_open()
    {
        this.init();
        this.refresh();
    }

    public void init()
    {
        this.phoneHome = GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").gameObject;
        this.pageThis = GameObject.Find("AppMessenger").transform.Find("ChatRoomList").gameObject;
        this.pageClose = this.pageThis;
        this.pageGoBack = this.phoneHome;
    }

    public void goBack()
    {
        this.pageGoBack.SetActive(true);
        this.pageClose.SetActive(false);
    }

    public void goHome()
    {
        this.phoneHome.SetActive(true);
        this.pageThis.SetActive(false);
    }

    public void refresh()
    {
        this.delete();

        for (int i = 0; i < SystemControl.Instance.msgr.getChatRooms().Count; i++)
        {
            ChatContainer room = SystemControl.Instance.msgr.getChatRooms()[i];

            GameObject btn = Resources.Load<GameObject>("Prefabs/BtnChatRoomList");
            GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("AppMessenger").transform.Find("ChatRoomList").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

            Instance.transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = room.getNameChatRoom();
            Instance.transform.Find("TextThumbnail").GetComponentInChildren<TextMeshProUGUI>().text = this.getThumbnail(room);

            int unread = room.getUnread();
            if (unread > 0)
            {
                //GameObject unreadAlert = GameObject.Find(Instance).transform.Find("UnreadAlert").gameObject;
                //unreadAlert.SetActive(true);
                Instance.transform.Find("UnreadAlert").gameObject.SetActive(true);
                Instance.transform.Find("UnreadAlert").transform.Find("TextUnread").GetComponentInChildren<TextMeshProUGUI>().text = unread.ToString();
            }

        }


        //foreach (ChatContainer rooms in (SystemControl.Instance.msgr.getChatRooms()))
        //{
        //    GameObject btn = Resources.Load<GameObject>("Prefabs/BtnChatRoomList");
        //    GameObject Instance = (GameObject)Instantiate(btn, GameObject.Find("AppMessenger").transform.Find("ChatRoomList").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

        //    Instance.transform.Find("TextName").GetComponentInChildren<TextMeshProUGUI>().text = rooms.getNameChatRoom();
        //    Instance.transform.Find("TextThumbnail").GetComponentInChildren<TextMeshProUGUI>().text = this.getThumbnail(rooms);

        //    int unread = rooms.getUnread();
        //    if (unread > 0)
        //    {
        //        //GameObject unreadAlert = GameObject.Find(Instance).transform.Find("UnreadAlert").gameObject;
        //        //unreadAlert.SetActive(true);
        //        Instance.transform.Find("UnreadAlert").gameObject.SetActive(true);
        //        Instance.transform.Find("UnreadAlert").transform.Find("TextUnread").GetComponentInChildren<TextMeshProUGUI>().text = unread.ToString();
        //    }
        //}
    }

    private void delete()
    {

    }

    private string getThumbnail(Chat chat)
    {
        string thumb = chat.getString();

        if(thumb.Length > 20)
        {
            thumb = thumb.Substring(0, 20);
            thumb = thumb + "......";
        }

        return thumb;
    }

    private string getThumbnail(ChatContainer chatroom)
    {
        string thumb = chatroom.getChat(-1).getString();

        if (thumb.Length > 20)
        {
            thumb = thumb.Substring(0, 20);
            thumb = thumb + "......";
        }

        return thumb;
    }
}
