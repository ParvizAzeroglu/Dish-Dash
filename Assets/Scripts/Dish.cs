using UnityEngine;

public class Dish : MonoBehaviour {
    private GameManager gameManager;
    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update() {
    }

    private void OnCollisionEnter(Collision collision) {
        // If the dish object collides with the ground object,
        // than destroy the dish object and decrease the health in the game manager.
        if (collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
            gameManager.DecreaseHealth();
        }
    }
}
