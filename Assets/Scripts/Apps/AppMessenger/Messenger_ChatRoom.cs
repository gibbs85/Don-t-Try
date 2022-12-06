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

        string nameSpeakerBefore = "NONE";
        string nameSpeakerNow = "NONE";

        for (int i = 0; i < this.msgCountToShow; i++)
        {
            Chat chat = this.ChatRoom.getChat(i);
            nameSpeakerNow = chat.getNameSpeaker();

            GameObject dialog;

            if (nameSpeakerNow.Equals("player"))
                dialog = Resources.Load<GameObject>("Prefabs/DialogLineRight");
            else if (nameSpeakerNow.Equals(nameSpeakerBefore))
                dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeft");
            else
                dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeftWithProfile");

            GameObject Instance = (GameObject)Instantiate(dialog, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

            Instance.transform.Find("ImageDialogBubble").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = chat.getString();
        }

        //Debug.Log("refresh_msg_Added(): getChatToBeAdded(0): " + this.ChatRoom.getChatToBeAdded(0));
        if (this.ChatRoom.getCountChatToBeAdded() > 0)
        {
            if (this.ChatRoom.getChatToBeAdded(0).getCountOptions() > 0)
            {
                this.btnNextChat.SetActive(false);

                Chat chatWithOptions = this.ChatRoom.getChatToBeAdded(0);

                Debug.Log("option found");

                GameObject optionsBox;
                Debug.Log("option point 1");
                optionsBox = Resources.Load<GameObject>("Prefabs/DialogLineOptionRight");
                Debug.Log("option point 2");
                GameObject InstanceOptionsBox = (GameObject)Instantiate(optionsBox, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));
                Debug.Log("option point 3");

                for (int i = 0; i < chatWithOptions.getCountOptions(); i++)
                {
                    Debug.Log("option point 4");
                    Chat option = chatWithOptions.getOption(i);
                    Debug.Log("option point 5");

                    GameObject optionObj = Resources.Load<GameObject>("Prefabs/BtnChatRoomOption");
                    Debug.Log("option point 6");
                    GameObject InstanceOption = (GameObject)Instantiate(optionObj, InstanceOptionsBox.transform.Find("DialogOptionBG"));
                    Debug.Log("option point 7");

                    InstanceOption.transform.Find("TextOption").GetComponentInChildren<TextMeshProUGUI>().text = option.getString();
                    InstanceOption.GetComponent<BtnInfoOption>().setOptionIndex(i);
                    Debug.Log("option point 8");
                }

                return;
            }
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
        //Debug.Log("refresh_msg_Added(): getChatToBeAdded(0): " + this.ChatRoom.getChatToBeAdded(0));
        if (this.ChatRoom.getCountChatToBeAdded() > 0)
        {
            if (this.ChatRoom.getChatToBeAdded(0).getCountOptions() > 0)
            {
                this.btnNextChat.SetActive(false);

                Chat chatWithOptions = this.ChatRoom.getChatToBeAdded(0);

                Debug.Log("option found");

                GameObject optionsBox;
                Debug.Log("option point 1");
                optionsBox = Resources.Load<GameObject>("Prefabs/DialogLineOptionRight");
                Debug.Log("option point 2");
                GameObject InstanceOptionsBox = (GameObject)Instantiate(optionsBox, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));
                Debug.Log("option point 3");

                for (int i = 0; i < chatWithOptions.getCountOptions(); i++)
                {
                    Debug.Log("option point 4");
                    Chat option = chatWithOptions.getOption(i);
                    Debug.Log("option point 5");

                    GameObject optionObj = Resources.Load<GameObject>("Prefabs/BtnChatRoomOption");
                    Debug.Log("option point 6");
                    GameObject InstanceOption = (GameObject)Instantiate(optionObj, InstanceOptionsBox.transform.Find("DialogOptionBG"));
                    Debug.Log("option point 7");

                    InstanceOption.transform.Find("TextOption").GetComponentInChildren<TextMeshProUGUI>().text = option.getString();
                    InstanceOption.GetComponent<BtnInfoOption>().setOptionIndex(i);
                    Debug.Log("option point 8");
                }

                return;
            }
        }

        string nameSpeakerBefore = "NONE";
        string nameSpeakerNow = "NONE";

        this.ChatRoom.readChecked();
        //int msgShowed = this.msgCountToShow;                
        //this.msgCountToShow = this.ChatRoom.getCountChat();
        //int countMsgAdded = this.msgCountToShow - msgShowed;

        this.msgCountToShow = this.ChatRoom.getCountChatToBeAdded();
        Debug.Log("refresh_msg_Added(): msgCountToShow:" + this.msgCountToShow);
        if (this.msgCountToShow == 0)
            return;

        //
        Chat chat = this.ChatRoom.getChatToBeAdded(0);
        this.ChatRoom.toLog();
        GameObject dialog;

        if (this.ChatRoom.getCountChat() > 0)
        {
            nameSpeakerBefore = this.ChatRoom.getChat(this.ChatRoom.getCountChat() - 2).getNameSpeaker();
        }
        nameSpeakerNow = chat.getNameSpeaker();

        Debug.Log("nameSpeakerBefore: " + nameSpeakerBefore);
        Debug.Log("nameSpeakerNow: " + nameSpeakerNow);

        if (nameSpeakerNow.Equals("player"))
            dialog = Resources.Load<GameObject>("Prefabs/DialogLineRight");
        else if (nameSpeakerNow.Equals(nameSpeakerBefore))
            dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeft");
        else
            dialog = Resources.Load<GameObject>("Prefabs/DialogLineLeftWithProfile");

        GameObject Instance = (GameObject)Instantiate(dialog, GameObject.Find("AppMessenger").transform.Find("ChatRoom").transform.Find("Scroll View Stocks All").transform.Find("Viewport").transform.Find("Content"));

        Instance.transform.Find("ImageDialogBubble").transform.Find("TextDialog").GetComponentInChildren<TextMeshProUGUI>().text = chat.getString();

        Debug.Log("Messenger_ChatRoom.cs: refresh_msg_added(): before chat.executeEvents()");
        chat.executeEvents();

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

    public void BtnClickedOption(int indexOption)
    {
        this.ChatRoom.optionSelect(indexOption);
        this.btnNextChat.SetActive(true);

        int countchild = GameObject.Find("Viewport").transform.Find("Content").childCount;
        Destroy(GameObject.Find("Viewport").transform.Find("Content").GetChild(countchild-1).gameObject);

        this.refresh_msg_added();
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
