using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Comet : NPC
{
    public NPC_Comet()
    {

        Debug.Log("NPC_Comet.cs: created: entered");

        this.name = "����(��)";
        this.affection = 0;
        this.eventsNPC = new LinkedList<EventContainer>();

        this.eventsNPC.AddLast((new Event_Comet_intro()).getEvContainer());
    }
}
