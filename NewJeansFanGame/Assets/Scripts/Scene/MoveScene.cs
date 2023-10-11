using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void MoveToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MoveToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
