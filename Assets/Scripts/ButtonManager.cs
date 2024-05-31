using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void RestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeButton() {
        gameManager.isGamePaused = false;
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
}
