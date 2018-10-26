using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private float spawnWait;
    public float spawnWaitMaxTime;

    public Text scoreText;
    public Text gameOverText;
    public Text livesText;

    public GameObject InvaderContainer;

    public static int score = 0;
    public static int lives = 3;
    
    public static bool gameOver = false;
    public GameObject ship;
    public Transform shipSpawn;

    // Use this for initialization
    void Start () {

        RandomWaitTime();
        UpdateLives();

        gameOver = false;

        UpdateScore();
        gameOverText.text = "";

        StartCoroutine(SpawnWave());
    }
	
	// Update is called once per frame
	void Update () {
        UpdateLives();

        if (InvaderContainer.transform.childCount == 0 || gameOver)
        {
            EndGame();
        }
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            if (gameOver)
            {
                break;
            }

            yield return new WaitForSeconds(spawnWait);

            Instantiate(ship, shipSpawn.position, shipSpawn.rotation);
        }
    }

    public void AddScore(int s)
    {
        score += s;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void EndGame()
    {
        gameOverText.text = "Game Over \n Press 'R' to restart";

        gameOver = true;

        if (Input.GetKeyDown(KeyCode.R))
        {
            lives = 3;
            score = 0;
            gameOver = false;
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void RandomWaitTime()
    {
        spawnWait = Random.Range(1.0f, spawnWaitMaxTime);
    }
}
