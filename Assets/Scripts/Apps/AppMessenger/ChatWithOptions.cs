using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatWithOptions : Chat
{
    private List<Chat> options;

    public ChatWithOptions(string nameSpeaker, Chat option1, Chat option2, int date, float waitTimeBefore)
    {
        this.options = new List<Chat>();
        this.date = date;
        this.waitTimeBefore = waitTimeBefore;

        this.options.Add(option1);
        this.options.Add(option2);
    }
    
    public Chat getOption(int index)
    {
        return this.options[index];
    }

    public int getCountOptions()
    {
        return this.options.Count;
    }
}
