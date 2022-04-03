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
    public List<string> inputActionOptions;

    [SerializeField]
    public PlayerInput playerInput;

    public int currentInput = 0;
    public int completed = 0;

    [SerializeField]
    public string currentInputAction;

    [SerializeField]
    public int minSequenceSize;


    [SerializeField]
    public int maxSequenceSize;

    [SerializeField]
    public GameObject sequenceList;

    [SerializeField]
    public GameObject challengeInputPrefab;

    [SerializeField]
    public GameObject timeChangePrefab;

    [SerializeField]
    public HandTimer handTimer;

    [SerializeField]
    public Transform timeChangeList;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        // game is over
        if (handTimer.Done()) return;

        if (sequenceList.transform.childCount > 0) {
            Transform nextInput = sequenceList.transform.GetChild(0);
            nextInput.GetComponent<ChallengeInput>().EnableHighlight();
        }

        if (inputActions.Count > 0 && completed < inputActions.Count)
        {
            if (currentInput <= inputActions.Count - 1)
            {
                if (playerInput.actions[currentInputAction].WasPressedThisFrame())
                {
                    IncrementCurrentInputAction();
                }
            }
        }

        if (completed >= inputActions.Count)
        {
            float timeBonus = 2f;
            handTimer.AddSeconds(timeBonus);
            GameObject timeChange = Instantiate(timeChangePrefab);
            timeChange.GetComponent<TimeChange>().value = timeBonus;
            timeChange.transform.SetParent(timeChangeList);
            Reset();
        }
        else if (challengeTimer.Done())
        {
            float timePenalty = 3f;
            handTimer.SubtractSeconds(timePenalty);
            GameObject timeChange = Instantiate(timeChangePrefab);
            timeChange.GetComponent<TimeChange>().value = -timePenalty;
            timeChange.transform.SetParent(timeChangeList);
            Reset();
        }
    }
    List<string> GenerateSequence()
    {
        List<string> sequence = new List<string>();
        int size = UnityEngine.Random.Range(minSequenceSize, maxSequenceSize);
        for (int i = 0; i < size; i++)
        {
            sequence.Add(GetRandomInputAction());
        }
        return sequence;
    }

    string GetRandomInputAction()
    {
        return inputActionOptions[UnityEngine.Random.Range(0, inputActionOptions.Count - 1)];
    }

    void Reset()
    {
        currentInput = 0;
        completed = 0;
        inputActions = GenerateSequence();

        if (inputActions.Count > 0) currentInputAction = inputActions[currentInput];

        int listChildren = sequenceList.transform.childCount;
        for (int i = listChildren - 1; i >= 0; i--)
        {
            GameObject.Destroy(sequenceList.transform.GetChild(i).gameObject);
        }
        sequenceList.transform.DetachChildren();

        foreach (string inputAction in inputActions)
        {
            GameObject challengeInputGameObject = Instantiate(challengeInputPrefab);
            ChallengeInput challengeInput = challengeInputGameObject.GetComponent<ChallengeInput>();
            challengeInput.playerInput = playerInput;
            challengeInput.inputAction = inputAction;
            challengeInputGameObject.transform.SetParent(sequenceList.transform);
        }

        challengeTimer.RestartTimer();
    }

    // IncrementCurrentInputAction: proceeds to the next input action, if more exist
    void IncrementCurrentInputAction()
    {
        currentInput++;
        completed++;
        currentInput = Math.Min(currentInput, inputActions.Count - 1);
        currentInputAction = inputActions[currentInput];
        GameObject.Destroy(sequenceList.transform.GetChild(0).gameObject);
    }
}
