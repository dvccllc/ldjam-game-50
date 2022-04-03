using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChallengeInput : MonoBehaviour
{
    [SerializeField]
    public string inputAction;
    [SerializeField]
    public PlayerInput playerInput;

    public string inputKey;

    [SerializeField]
    public Text _text;

    void Update() {
        inputKey = "NA";
        if (playerInput.actions[inputAction].controls.Count > 0) {
            // assign the input label using the displayname for the input binding
            //   this value will be dynamic depending on the control scheme being used (keyboard vs gamepad)
            inputKey = playerInput.actions[inputAction].controls[0].displayName;
            _text.text = inputKey;

        }
    }
}
