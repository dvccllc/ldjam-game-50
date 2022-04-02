using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.UI;
using System;

public class HandController : MonoBehaviour
{
    [SerializeField]
    public PlayerInput playerInput;

    [SerializeField]
    public float thumbPress;

    [SerializeField]
    public List<Finger> fingers;

    public bool closing;

    [SerializeField]
    public float seconds = 10f;

    [SerializeField]
    public Text timeRemaining;


    // Start is called before the first frame update
    void Start()
    {
        if (!fingers.Any()) fingers = new List<Finger>();
        playerInput = GetComponent<PlayerInput>();
        Debug.Log("playerInput set on Start");

        closing = true;
        StartCoroutine(Countdown(5f));
    }



    private IEnumerator Countdown(float duration)
    {
        //to whatever you want
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            // countdownImage.fillAmount = normalizedTime;
            normalizedTime += Time.deltaTime / duration;
            timeRemaining.text = String.Format("{0:0.00}", normalizedTime);

            // where we dispatch other events or data
            yield return null;
        }
        timeRemaining.text = "done";
    }

    // Update is called once per frame
    void Update()
    {

        // yield finished coroutine


        float fingerValue = 0f;
        foreach (Finger finger in fingers) {
            finger.pressed = false;
            // better code: check if finger.action is in actions
            fingerValue = playerInput.actions[finger.action].ReadValue<float>();
            if (fingerValue != 0f ) {
                finger.pressed = true;
            }
            // update color
            finger.UpdateColor();

            // keep from squeezing finger


        }
    }
}
// TODO:

// slowly close over time

// timer mechanism
// start -> during -> end
// timer receive event
//   -> key pressed
//   -> finish
//   -> ran out of time


// 
// timer finish -> do something
// 
// take input -> impact coroutine
// take input -> add time? 

// start "60 second timer"
//    every successful input SEQUENCE, add 30 sec to timer
//    every bad input, remove 1 second from timer
//    if you lose a segment, you lose the chunk from capacity
//    chunked add/loss

//    last as long as possible

// palm color gradient red -> green as time "passes" to simulate hand closing
// 


// prompt for key
// start timer
// accept key within timer
// fault player if not pressed,
// if pressed, increment, add time? idk
// 
// convert text bar to % bar gauge 


