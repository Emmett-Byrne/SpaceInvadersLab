using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float spawnWait;

    public Text scoreText;
    public Text livesText;
    public Text gameOverText;

    public int score;
    public int lives;
    
    private bool gameOver;

    // Use this for initialization
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnWait);

            if (gameOver)
            {
                break;
            }
        }
    }

    public void addScore(int s)
    {
        score += s;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void endGame()
    {
        gameOverText.text = "Game Over \n Press 'R' to restart";
        gameOver = true;
    }
}
