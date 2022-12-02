using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_App_Messenger : MonoBehaviour
{
    public GameObject appOpen;
    public GameObject appClose;

    public void OpeningApp()
    {
        appOpen.SetActive(true);
        appOpen.GetComponentInChildren<AppMessenger>().openApp();
    }

    public void ClosingApp()
    {
        appClose.SetActive(false);
    }
}
