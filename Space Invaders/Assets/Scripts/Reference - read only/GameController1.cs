using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    public int score;
    private bool restart;
    private bool gameOver;

    void Start ()
    {
        restart = false;
        gameOver = false;

        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        updateScore();
        StartCoroutine(spawnWave());
	}
	
	void Update ()
    {
		if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}

    IEnumerator spawnWave()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRot = Quaternion.identity;
                Instantiate(hazard, spawnPos, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
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
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
