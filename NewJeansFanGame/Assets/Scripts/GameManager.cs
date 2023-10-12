using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public int totalPoint;
    public int stagePoint;
    public int health;
    public PlayerMove player;

    public Image[] UiHp;
    public TextMeshProUGUI UiPoint;
    public TextMeshProUGUI UiTotalPoint;

    public GameObject EndPanel;
    public GameObject GameOverPanel;

    void Update()
    {
        UiPoint.text = stagePoint.ToString();
        UiTotalPoint.text = stagePoint.ToString();
    }

    public void GameFinish()
    {
        Time.timeScale = 0;

        EndPanel.SetActive(true);
    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UiHp[health].color = new Color(1, 0, 0, 0.4f);
        }
      
        else
        {
            player.OnDie();
            GameOverPanel.SetActive(true);
            health--;
            UiHp[health].color = new Color(1, 0, 0, 0.4f);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         
            if(health > 1)
            {
                PlayerReposition();
            }

            HealthDown();

        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-10f, 0 - 1);
        player.VelocityZero();
    }

    public void MoveToMainScene()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void MoveToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
