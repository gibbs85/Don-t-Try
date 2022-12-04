using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl
{
    private List<NPC> NPCs;

    public NPCControl()
    {
        this.init();
        this.new_game();
    }

    public void new_game()
    {

    }

    private void init()
    {
        this.NPCs = new List<NPC>();
    }

    public void newNPC(NPC npc)
    {
        this.NPCs.Add(npc);
    }
}
