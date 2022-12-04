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
    private GameObject btnNextChat;

    private ChatContainer ChatRoom;
    private int msgCountToShow;

    private float waitTime;

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
        this.btnNextChat = this.pageThis.transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("BtnChatRoomNextChat").gameObject;

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

    ////v1
    //public void refresh_msg_added()
    //{
    //    this.ChatRoom.readChecked();
    //    int msgShowed = this.msgCountToShow;                // msgShowed = 30 (index 0~29)
    //    this.msgCountToShow = this.ChatRoom.getCountChat(); // msgCountToShow = 31 (index 0~30)
    //    //int countMsgAdded = this.msgCountToShow - msgShowed;


    //    for (int i = msgShowed; i < this.msgCountToShow; i++)   // 30 (index 30)
    //    {
    //        Chat chat = this.ChatRoom.getChat(i);
    //        GameObject dialog;

    //        if (chat.getNameSpeaker().Equals("player"))
    //            dialog = Resources.Load<GameObject>("Prefabs/DialogLineRight");
    //        else
    //            dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeft");

    //        GameObject Instance = (GameObject)Instantiate(dialog, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

    //        Instance.transform.Find("ImageDialogBubble").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = chat.getString();
    //    }
    //}


    //v2: 버튼 액션 포함
    public void refresh_msg_added()
    {
        this.ChatRoom.readChecked();
        //int msgShowed = this.msgCountToShow;                
        //this.msgCountToShow = this.ChatRoom.getCountChat();
        //int countMsgAdded = this.msgCountToShow - msgShowed;

        this.msgCountToShow = this.ChatRoom.getCountChatToBeAdded();
        Debug.Log("refresh_msg_Added(): msgCountToShow:" + this.msgCountToShow);
        if (this.msgCountToShow == 0)
            return;

        Debug.Log("refresh_msg_added: passed if()");
        //
        Chat chat = this.ChatRoom.getChatToBeAdded(0);
        Debug.Log("refresh_msg_added: passed getChatToBeAdded()");
        this.ChatRoom.toLog();
        Debug.Log("refresh_msg_added: passed toLog()");
        GameObject dialog;

        Debug.Log("refresh_msg_added: chat.toLog(). countToBeAdded: "+this.ChatRoom.getCountChatToBeAdded());

        if (chat.getNameSpeaker().Equals("player"))
            dialog = Resources.Load<GameObject>("Prefabs/DialogLineRight");
        else
            dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeft");

        Debug.Log("refresh_msg_added: passed if else()");

        GameObject Instance = (GameObject)Instantiate(dialog, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

        Instance.transform.Find("ImageDialogBubble").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = chat.getString();
        //this.BtnClickedReadingMsg(chat.getWaitTimeAfter());
        this.waitTime = chat.getWaitTimeAfter();
        //StartCoroutine("lockNextChat");
        //StopCoroutine("lockNextChat");

    }

    private void delete()
    {

        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;

        for (int i = 0; i < countchild; i++)
        {
            Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(i).gameObject);
        }
    }

    public string getNameChatRoom()
    {
        return this.ChatRoom.getNameChatRoom();
    }

    public void BtnClickedReadingMsg(float waitTime)
    {
        this.waitTime = waitTime;
        //
        StartCoroutine("lockNextChat");
        StopCoroutine("lockNextChat");
    }

    IEnumerator lockNextChat()
    {
        this.btnNextChat.SetActive(false);
        for (float f = 0; f < this.waitTime; f += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
        }
        this.btnNextChat.SetActive(true);
    }

}
