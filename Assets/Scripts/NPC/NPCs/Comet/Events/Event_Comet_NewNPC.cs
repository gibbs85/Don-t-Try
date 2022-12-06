using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Comet_NewNPC : Event
{
    override public bool control()
    {
        Debug.Log("Event_Comet_NewNPC.cs: control(): entered");
        SystemControl.Instance.npcs.newNPC(new NPC_Comet());

        return true;
    }
}

