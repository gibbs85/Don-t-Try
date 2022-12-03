using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messenger_ChatRoom : MonoBehaviour
{
    public GameObject phoneHome;
    public GameObject pageThis;
    public GameObject pageClose;
    public GameObject pageGoBack;

    private GameObject panelUpper;

    private ChatContainer ChatRoom;
    private int msgCountToShow;

    public void page_open(ChatContainer chatRoom)
    {
        this.init(chatRoom);
        this.refresh();
    }

    public void init(ChatContainer chatRoom)
    {
        this.phoneHome = GameObject.Find("PhoneOnHand").transform.Find("ScreenHome").gameObject;
        this.pageThis = GameObject.Find("AppMessenger").transform.Find("ChatRoom").gameObject;
        this.pageClose = this.pageThis;
        this.pageGoBack = GameObject.Find("AppMessenger").transform.Find("ChatRoomList").gameObject;

        this.panelUpper = this.pageThis.transform.Find("PanelUpper").gameObject;

        this.ChatRoom = chatRoom;
        this.msgCountToShow = 30;
    }

    public void goBack()
    {
        this.pageGoBack.SetActive(true);
        this.pageGoBack.GetComponentInChildren<Messenger_ChatRoomList>().page_open();
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
        this.ChatRoom.readChecked();
        this.panelUpper.transform.Find("TextChatRoomName").GetComponentInChildren<TextMeshProUGUI>().text = this.ChatRoom.getNameChatRoom();

        //int countMaxMsg = 30;
        //int countMsgAll = this.ChatRoom.getCountChat()
        //int countMaxMsg = countMsgAll;
        //if (countMsgAll < countMaxMsg)
        //    countMaxMsg = countMsgAll;

        //msgCountToShow = countMaxMsg;

        this.msgCountToShow = this.ChatRoom.getCountChat();


        for (int i = 0; i < this.msgCountToShow; i++)
        {
            GameObject dialogLeft = Resources.Load<GameObject>("Prefabs/DialogLineLeft");
            GameObject Instance = (GameObject)Instantiate(dialogLeft, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

            Instance.transform.Find("ImageDialogBubble").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = this.ChatRoom.getChat(i).getString();
        }
    }

    public void refresh_msg_added()
    {
        this.ChatRoom.readChecked();
        int msgShowed = this.msgCountToShow;                // msgShowed = 30 (index 0~29)
        this.msgCountToShow = this.ChatRoom.getCountChat(); // msgCountToShow = 31 (index 0~30)
        //int countMsgAdded = this.msgCountToShow - msgShowed;


        for (int i = msgShowed; i < this.msgCountToShow; i++)   // 30 (index 30)
        {
            Chat chat = this.ChatRoom.getChat(i);
            GameObject dialog;

            if (chat.getNameSpeaker().Equals("player"))
                dialog = Resources.Load<GameObject>("Prefabs/DialogLineRight");
            else
                dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeft");

            GameObject Instance = (GameObject)Instantiate(dialog, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

            Instance.transform.Find("ImageDialogBubble").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = chat.getString();
        }

        
    }

    private void delete()
    {

        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }
    }

}
