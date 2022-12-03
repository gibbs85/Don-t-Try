using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat
{
    private string nameSpeaker;
    private string dialog;
    private int date;
    private bool read;

    public Chat(string nameSpeaker, string dialog, int date)
    {
        this.nameSpeaker = nameSpeaker;
        this.dialog = dialog;
        this.date = date;
        this.read = false;
    }

    public bool getRead()
    {
        return this.read;
    }

    public string getString()
    {
        return this.dialog;
    }

    public string getNameSpeaker()
    {
        return this.nameSpeaker;
    }

    public void doneRead()
    {
        this.read = true;
    }
}

public interface ChatInControl
{
    public  bool control();
}
