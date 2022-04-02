using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(ChallengeTimer))]
public class Challenge : MonoBehaviour
{
    [SerializeField]
    public ChallengeTimer challengeTimer;

    [SerializeField]
    public List<string> inputActions;

    [SerializeField]
    public PlayerInput playerInput;

    public int currentInput = 0;

    [SerializeField]
    public string currentInputAction;  

    void Start() {
        currentInput = 0;
        if (inputActions.Count > 0) currentInputAction = inputActions[currentInput];
    }

    void CheckForInput() {
        // check if player is pressing input
        if (playerInput.actions[currentInputAction].WasPressedThisFrame()) {
            IncrementCurrentInputAction();
        }
    }

    void Update() {
        if (inputActions.Count > 0) {
            if (currentInput <= inputActions.Count - 1) {
                CheckForInput();
            }
        }
    }

    // IncrementCurrentInputAction: proceeds to the next input action, if more exist
    void IncrementCurrentInputAction() {
        currentInput++;
        currentInput = Math.Min(currentInput, inputActions.Count - 1);
        currentInputAction = inputActions[currentInput];
    }
}
