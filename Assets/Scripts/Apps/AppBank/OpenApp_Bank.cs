using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApp_Bank : MonoBehaviour
{
    public GameObject appOpen;
    public GameObject appClose;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpeningApp()
    {
        appOpen.SetActive(true);
        GameObject.Find("Bank1").GetComponentInChildren<AppBank_myAsset>().refresh();
    }

    public void ClosingApp()
    {
        appClose.SetActive(false);
    }
}
