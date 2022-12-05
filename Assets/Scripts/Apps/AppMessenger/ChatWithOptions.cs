using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWithOptions : Chat
{
    private List<Chat> options;

    public ChatWithOptions(string nameSpeaker, Chat option1, Chat option2, int date)
    {
        this.options = new List<Chat>();
        this.date = date;

        this.options.Add(option1);
        this.options.Add(option2);
    }
    
    public Chat selectOption(int index)
    {
        return this.options[index];
    }
}
