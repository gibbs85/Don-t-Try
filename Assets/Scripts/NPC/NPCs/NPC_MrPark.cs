using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_MrPark : NPC
{
    public NPC_MrPark()
    {
        this.name = "�ڻ���";
        this.affection = 0;
        this.eventsNPC = new LinkedList<EventContainer>();

        this.eventsNPC.AddLast((new Event_MrPark_intro()).getEvContainer());
    }
}
