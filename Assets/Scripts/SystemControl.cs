using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControl : MonoBehaviour
{
    public Player player;
    public World world;
    // Start is called before the first frame update
    // 이후 Start() 함수 방식에서 해제 필요.
    void Start()
    {
        Player player = new Player(1911);
        World world = new World();
    }

}
