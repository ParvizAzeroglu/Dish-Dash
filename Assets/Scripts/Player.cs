using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 5f;
    private GameManager gameManager;
    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update() {
        PlayerMove();
    }

    private void PlayerMove() {
        if (Input.GetKey(KeyCode.A)) {
            if (transform.position.x < gameManager.gameBoundLeft) {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        } else if (Input.GetKey(KeyCode.D)) {
            if (transform.position.x > gameManager.gameBoundRight) {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Dish")) {
            DishCollide(collision.gameObject);
        }
    }

    private void DishCollide(GameObject dishObject) {
        Destroy(dishObject);
        gameManager.GainScore();
    }
}
