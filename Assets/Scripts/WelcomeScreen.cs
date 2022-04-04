using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{

    public static bool WelcomeActive = true;
    public void SetWelcomeActive(bool activate)
    {
        print(gameObject.name);
        gameObject.SetActive(activate);
        WelcomeActive = activate;
    }

    void Start() {
        SetWelcomeActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (WelcomeActive && Input.GetKeyDown(KeyCode.Return)) {
            // only run this once
            SetWelcomeActive(false);
        };

        // pause time scale while welcome screen is active
        if (WelcomeActive) Time.timeScale = 0f;
        if (!WelcomeActive) Time.timeScale = 1f;
    }
}
