using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool GameOverActive = false;
    float pitch,volume;
    
    [SerializeField]
    public AudioSource soundManager;

    public void ToggleGameOver(bool active) {
        GameOverActive = active;
        gameObject.SetActive(active);
    }

    void Update() {
        
        if (pitch == 0) pitch = soundManager.pitch;
        if (volume == 0) volume = soundManager.volume;

        if (GameOverActive) {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            soundManager.pitch = pitch / 2f;
            soundManager.volume = volume / 2f;
        } else {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            soundManager.pitch = pitch;
            soundManager.volume = volume;
        }
    }
}
