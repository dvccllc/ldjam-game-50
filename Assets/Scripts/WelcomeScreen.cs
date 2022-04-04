using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{

    public static bool WelcomeActive = true;
    public static void SetWelcomeActive(bool activate)
    {
        WelcomeActive = activate;
    }

    void Start()
    {
        SetWelcomeActive(true);
    }

    void Update()
    {
        gameObject.SetActive(WelcomeActive);
    }
}
