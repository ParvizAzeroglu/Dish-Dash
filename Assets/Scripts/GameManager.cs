using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject musicObject;
    public GameObject[] dishPrefab;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject hud;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public ParticleSystem dishParticle;
    public float gameBoundLeft = -2f;
    public float gameBoundRight = -8f;
    private bool isGameOver = false;
    private float spawnRate = 1;
    private int health = 3;
    public int score = 0;
    private bool isHudActive = true;
    public bool isGamePaused = false;
    private AudioSource musicSource;
    void Start() {
        StartCoroutine(GameWave());
        musicSource = musicObject.GetComponent<AudioSource>();
        musicSource.volume = AudioManager.Instance.musicSound;
    }

    void Update() {
        if (health == 0) {
            isGameOver = true;
        }
        // Check the game over state every frame
        CheckGameOver();

        // Handle HUD visibility based on user input (H button)
        HudController();

        PauseController();

    }

    // Chechk code below pls
    private void PauseController() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver) {
            isGamePaused = !isGamePaused;
        }
        //Time.timeScale = isGamePaused ? 0f  : 1f;
        if (isGamePaused) {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        } else {
            pauseScreen.SetActive(false);
        }
    }
    private void HudController() {
        // Set UI text
        scoreText.text = $"Score: {score}";
        healthText.text = $"Health: {health}/3";
        //Toggle HUD visibility when the H key is pressed
        if (Input.GetKeyDown(KeyCode.H)) {
            isHudActive = !isHudActive;
            hud.SetActive(isHudActive);
        }
    }

    IEnumerator GameWave() {
        while (!isGameOver) {
            yield return new WaitForSeconds(spawnRate);
            SpawnDish();
        }
    }

    private void CheckGameOver() {
        if (isGameOver) {
            GameOver();
            Invoke("StopGame", 0.4f);
        } else {
            Time.timeScale = 1f;
        }
    }

    private void StopGame() {
        Time.timeScale = 0;
    }

    private void GameOver() {
        gameOverScreen.SetActive(true);
        hud.SetActive(false);
        musicSource.Stop();
    }


    private void SpawnDish() {
        int randomNum = GenerateRandomNum(0, 2);
        Instantiate(dishPrefab[randomNum], GenerateRandomPosition(), transform.rotation);
    }

    private int GenerateRandomNum(int min, int max) {
        return Random.Range(min, max);
    }

    private Vector3 GenerateRandomPosition() {
        return new Vector3(Random.Range(gameBoundLeft, gameBoundRight), transform.position.y, transform.position.z);
    }

    public void DecreaseHealth() {
        health -= 1;
    }

    public void GainScore() {
        score += 10;
    }
}
