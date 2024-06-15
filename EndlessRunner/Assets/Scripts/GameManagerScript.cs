using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript myGameManager {  get; private set; }
    public float initGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;

    private FrogScript frogScript;
    private Spawner spawner;
    public float gameSpeed { get; private set; }
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public Button startGameButton;

    private float score;
    private bool onGameStart;


    // Start is called before the first frame update
    private void Awake()
    {
        if (!myGameManager)
        {
            myGameManager = this;
        } else
        {
            DestroyImmediate(gameObject);
        }
        
    }

    private void OnDestroy()
    {
        if (myGameManager)
        {
            myGameManager = null;
        }
    }

    private void Start()
    {
        frogScript = FindObjectOfType<FrogScript>();
        spawner = FindObjectOfType<Spawner>();
        onGameStart = true;
        PlayerPrefs.SetFloat("hiscore", 0f);
        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (Obstacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
       
        gameSpeed = initGameSpeed;
        score = 0f;
        
        enabled = true;
        gameOverText.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);
        frogScript.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        updateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void gameOver()
    {
        gameSpeed = 0f;
        enabled = false;
        frogScript.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        startGameButton.gameObject.SetActive(true);
        onGameStart = false;
        updateHighScore();
    }

    private void updateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("hiscore", 0);
      
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("hiscore", highScore);
        }

        hiScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }
}
