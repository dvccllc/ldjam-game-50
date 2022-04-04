using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{

    private bool welcomeActive = true;
    public void SetWelcomeActive(bool activate)
    {
        print(gameObject.name);
        gameObject.SetActive(activate);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SetWelcomeActive(!welcomeActive);
        };
    }
}
