using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInfoOption : MonoBehaviour
{
    public int optionIndex;

    public void setOptionIndex(int index)
    {
        this.optionIndex = index;
    }

    public void btnClicked()
    {
        GameObject.Find("AppMessenger").transform.Find("ChatRoom").GetComponentInChildren<Messenger_ChatRoom>().BtnClickedOption(this.optionIndex);
    }
}
