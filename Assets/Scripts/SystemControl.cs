using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControl : MonoBehaviour
{
    public Player player;
    public World world;
    // Start is called before the first frame update
    // ���� Start() �Լ� ��Ŀ��� ���� �ʿ�.
    void Start()
    {
        Player player = new Player(1911);
        World world = new World();
    }

}
