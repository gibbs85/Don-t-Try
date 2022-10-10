using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControl : MonoBehaviour
{
    public Player player;
    public World world;

    private static SystemControl instance = null;

    /*
    public new_game()
    load_game()
    save_game()
     */


    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("SystemControl Instanciated.");
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SystemControl Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public void new_game()
    {
        Debug.Log("SystemControl new_game() called.");
        this.player = new Player(1911);
        this.world = new World();
    }



}
