using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    public float musicSound = 1f;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //private void Update() {
    //    Debug.Log(musicSound);
    //}
}
