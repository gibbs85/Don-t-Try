using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControl : MonoBehaviour
{
    public Player player;
    public World world;
    public StockControl stockControl;
    public Bank bank;
    public Messenger msgr;

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
        this.stockControl = new StockControl();
        this.bank = new Bank();
        this.msgr = new Messenger();
        Debug.Log("SystemControl: new Classes completed.");


        this.world.new_game();
        this.stockControl.new_game();
        this.bank.new_game();
        this.msgr.new_game();
        Debug.Log("SystemControl: new Classes: new_game() completed.");

    }



}
