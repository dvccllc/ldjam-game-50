using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField]
    public AudioSource soundManager;

    [SerializeField]
    public Button dummy;

    [SerializeField]
    public Toggle toggle;

    void Start() {
        toggle.isOn = false;
        soundManager.mute = false;
    }

    public void ToggleMute(bool mute) {
        dummy.Select();
        soundManager.mute = mute;
        toggle.isOn = mute;
    }
}
