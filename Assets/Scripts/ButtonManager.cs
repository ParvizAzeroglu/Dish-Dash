using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void RestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
