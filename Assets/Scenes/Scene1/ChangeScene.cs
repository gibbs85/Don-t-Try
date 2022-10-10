using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void SceneChange()
    {
        //SceneManager.LoadScene("NameScene");
        SystemControl.Instance.new_game();
        SceneManager.LoadScene("Scene2");
    }
}