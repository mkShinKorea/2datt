using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text nowScoreText;
    public Text maxScoreText;
    public GameObject gameOver;
    public Sprite btnUp;
    public Sprite btnDown;
    public Button restart;
    public AudioClip au;
    public float interval = 0.1f;
    public int addScore = 1;

    PlayerController player;

    float nowInterval = 0f;
    int nowScore = 0, maxScore = 0;

    private void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    private void Update() {
        if (player.IsDead) {
            gameOver.SetActive(true);
            return;
        }

        if (nowInterval >= interval) {
            nowInterval = 0f;
            nowScore += addScore;
        }
        else {
            nowInterval += Time.deltaTime;
        }

        nowScoreText.text = nowScore.ToString();
        
        if (nowScore >= maxScore) {
            maxScore = nowScore;
            maxScoreText.text = maxScore.ToString();
        }
    }

    private void initGame() {
        gameOver.SetActive(false);
        nowScore = 0;
        nowInterval = 0;

        nowScoreText.text = nowScore.ToString();
        maxScoreText.text = maxScore.ToString();
    }


    public void OnRestartButtonClick()
    {

        au.play();
        restart.gameObject.GetComponent<Image>().sprite = btnDown;
        
        GameObject.Find("Cactus").GetComponent<CactusManager>().initGame();
        GameObject.FindWithTag("Player").GetComponent <PlayerController>().initGame();
        
    }
}
