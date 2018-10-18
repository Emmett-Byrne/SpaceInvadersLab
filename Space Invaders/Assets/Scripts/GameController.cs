using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float spawnWait;

    public Text scoreText;
    public Text gameOverText;

    public int score;
    public int lives;
    
    private bool gameOver;
    public GameObject ship;
    public Transform shipSpawn;

    // Use this for initialization
    void Start () {
        score = 0;
        updateScore();
        gameOverText.text = "";

        StartCoroutine(spawnWave());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnWait);

            Instantiate(ship, shipSpawn.position, shipSpawn.rotation);

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
