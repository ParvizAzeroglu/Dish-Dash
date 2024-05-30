using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] dishPrefab;
    public GameObject gameOverScreen;
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
    void Start() {
        StartCoroutine(GameWave());
    }

    void Update() {
        if (health == 0) {
            isGameOver = true;
        }

        // Check the game over state every frame
        CheckGameOver();

        // Handle HUD visibility based on user input (H button)
        HudController();
    }

    // Chechk code below pls
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
