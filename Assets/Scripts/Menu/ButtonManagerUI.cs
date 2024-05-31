using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManagerUI : MonoBehaviour {

    public Slider musicSlider;

    private void Start() {
        if (AudioManager.Instance != null) {
            musicSlider.value = AudioManager.Instance.musicSound;
        } else {
            musicSlider.value = 1f;
        }
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void MusicSettings() {
        if (AudioManager.Instance != null) {
            AudioManager.Instance.musicSound = musicSlider.value;
        }
    }
}
