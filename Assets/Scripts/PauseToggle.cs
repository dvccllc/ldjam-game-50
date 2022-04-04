using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseToggle : MonoBehaviour
{

    [SerializeField]
    public Toggle toggle;

    [SerializeField]
    public static bool GameIsPaused = false;

    [SerializeField]
    public Button dummy;

    [SerializeField]
    public GameObject pauseMenu;

    [SerializeField]
    public AudioSource soundManager;

    public float pitch, volume;

    void Start() {
        toggle.isOn = false;
        pauseMenu.SetActive(false);
        pitch = soundManager.pitch;
        volume = soundManager.volume;
    }

    public void TogglePause(bool pause) {
        dummy.Select();
        if (WelcomeScreen.WelcomeActive || GameOver.GameOverActive) {
            toggle.isOn = false;
            return;
        }

        if (pitch == 0) pitch = soundManager.pitch;
        if (volume == 0) volume = soundManager.volume;
        toggle.isOn = pause;
        if (pause) {
            Time.timeScale = 0f;
            GameIsPaused = true;
            pauseMenu.SetActive(true);
            soundManager.pitch = pitch / 2f;
            soundManager.volume = volume / 2f;
        } else {
            Time.timeScale = 1f;
            GameIsPaused = false;
            pauseMenu.SetActive(false);
            soundManager.pitch = pitch;
            soundManager.volume = volume;
        }
    }
}
