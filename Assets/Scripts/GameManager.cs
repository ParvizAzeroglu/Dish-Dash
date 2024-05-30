using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] dishPrefab;
    public GameObject gameOverScreen;
    public float gameBoundLeft = -2f;
    public float gameBoundRight = -8f;
    private bool isGameOver = false;
    private float spawnRate = 1;
    private int health = 3;
    public int score = 0;
    void Start() {
        StartCoroutine(GameWave());
    }

    void Update() {
        if (health == 0) {
            isGameOver = true;
        }

        // Check the game over state every frame
        CheckGameOver();
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
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }

    private void GameOver() {
        gameOverScreen.SetActive(true);
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
