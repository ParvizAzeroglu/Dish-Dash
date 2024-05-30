using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] dishPrefab;
    public float gameBoundLeft = -2f;
    public float gameBoundRight = -8f;
    private bool isGameOver = false;
    private float spawnRate = 1;
    private int health = 3;
    void Start() {
        StartCoroutine(GameWave());
    }

    void Update() {
        if (health == 0) {
            isGameOver = true;
        }

        //if (isGameOver) {
        //    Debug.Log("Game Over");
        //}
    }

    IEnumerator GameWave() {
        while (!isGameOver) {
            yield return new WaitForSeconds(spawnRate);
            SpawnDish();
        }
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
}
