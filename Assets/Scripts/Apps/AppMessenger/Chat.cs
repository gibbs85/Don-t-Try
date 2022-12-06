using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat
{
    protected string nameSpeaker;
    protected string dialog;
    protected int date;
    protected bool read;

    protected bool isWaitBefore;
    protected bool isWaitAfter;
    protected float waitTimeBefore;
    protected float waitTimeAfter;

    protected List<Chat> options;

    protected LinkedList<Event> events;
    //public addEvent(Event anEvent)
    //public executeEvents()

    protected Chat()
    {
        this.nameSpeaker = "NONE";
    }

    public Chat(string nameSpeaker, string dialog, int date)
    {
        this.options = new List<Chat>();
        this.events = new LinkedList<Event>();

        this.nameSpeaker = nameSpeaker;
        this.dialog = dialog;
        this.date = date;
        this.read = false;

        this.isWaitBefore = false;
        this.waitTimeBefore = 0f;
        this.isWaitAfter = false;
        this.waitTimeAfter = 0;

    }


    public Chat(string nameSpeaker, string dialog, int date,
        float waitTimeBefore
        )
    {
        this.options = new List<Chat>();
        this.events = new LinkedList<Event>();

        this.nameSpeaker = nameSpeaker;
        this.dialog = dialog;
        this.date = date;
        this.read = false;

        this.isWaitBefore = true;
        this.waitTimeBefore = waitTimeBefore;
    }

    public Chat(string nameSpeaker, Chat option1, int date, float waitTimeBefore)
    {
        this.options = new List<Chat>();
        this.events = new LinkedList<Event>();
        this.date = date;
        this.waitTimeBefore = waitTimeBefore;

        this.options.Add(option1);

        //this.optionsCount = 2;
    }

    public Chat(string nameSpeaker, Chat option1, Chat option2, int date, float waitTimeBefore)
    {
        this.options = new List<Chat>();
        this.events = new LinkedList<Event>();
        this.date = date;
        this.waitTimeBefore = waitTimeBefore;

        this.options.Add(option1);
        this.options.Add(option2);

        //this.optionsCount = 2;
    }

    public Chat getOption(int index)
    {
        return this.options[index];
    }

    public int getCountOptions()
    {
        return this.options.Count;
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

    public float getWaitTimeAfter()
    {
        return this.waitTimeAfter;
    }

    public void addEvent(Event anEvent)
    {
        this.events.AddLast(anEvent);
    }

    public void addEvent<T>(Event anEvent) where T : Event
    {
        this.events.AddLast(anEvent);
    }

    public void executeEvents()
    {
        Debug.Log("Chat.cs: executeEvents(): entered");
        Debug.Log("Chat.cs: executeEvents(): this.events.Count: "+this.events.Count);
        if (this.events.Count > 0)
        {
            foreach (Event anEvent in this.events)
            {
                anEvent.control();
            }
        }
    }
}

//public interface ChatInControl
//{
//    public  bool control();
//}
