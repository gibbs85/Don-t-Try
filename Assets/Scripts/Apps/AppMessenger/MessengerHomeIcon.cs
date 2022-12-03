using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessengerHomeIcon : MonoBehaviour
{
    private int unread;
    public GameObject icon;

    public void setUnread(int count)
    {
        this.unread = count;
        this.refresh();
    }

    public void refresh()
    {
        Debug.Log("Messenger_ChatRoomList.cs: refresh(): unread: " + this.unread);
        if (this.unread > 99)
        {
            this.icon.transform.Find("UnreadAlert").transform.Find("TextUnread").GetComponentInChildren<TextMeshProUGUI>().text = "99+";
            this.icon.transform.Find("UnreadAlert").transform.Find("TextUnread").GetComponentInChildren<TextMeshProUGUI>().fontSize = 8;
        }
        else if (this.unread > 0)
        {
            //GameObject unreadAlert = GameObject.Find(Instance).transform.Find("UnreadAlert").gameObject;
            //unreadAlert.SetActive(true);
            this.icon.transform.Find("UnreadAlert").gameObject.SetActive(true);
            this.icon.transform.Find("UnreadAlert").transform.Find("TextUnread").GetComponentInChildren<TextMeshProUGUI>().text = this.unread.ToString();
        }
        else
        {
            if (this.icon.transform.Find("UnreadAlert").gameObject.activeSelf == true)
                this.icon.transform.Find("UnreadAlert").gameObject.SetActive(false);
        }
    }
}
