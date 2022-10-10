using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI t = gameObject.GetComponent<TextMeshProUGUI>();
        t.text = t.text.Replace("/username/", GameObject.Find("SystemControl").GetComponent<SystemControl>().player.getName());
    }
}
