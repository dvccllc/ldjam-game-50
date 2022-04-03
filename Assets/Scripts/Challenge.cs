using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(ChallengeTimer))]
public class Challenge : MonoBehaviour
{
    [SerializeField]
    public ChallengeTimer challengeTimer;

    [SerializeField]
    public List<string> inputActions;

    public int currentInput = 0;
    public int completed = 0;
    public int score = 0;

    [SerializeField]
    public float defaultDurationSeconds = 2f;

    [SerializeField]
    public float timerDurationPerLetterSeconds = 0.25f;

    [SerializeField]
    public string currentInputAction;

    // [SerializeField]
    // public int minSequenceSize = 3;


    // [SerializeField]
    // public int maxSequenceSize = 4;

    [SerializeField]
    public int currentSequenceSize = 3;

    [SerializeField]
    public int maxSequenceSize = 12;

    [SerializeField]
    public GameObject sequenceList;

    [SerializeField]
    public GameObject challengeInputPrefab;

    [SerializeField]
    public GameObject timeChangePrefab;


    [SerializeField]
    public GameObject scoreChangePrefab;

    [SerializeField]
    public Transform scoreChangeList;


    [SerializeField]
    public HandTimer handTimer;

    [SerializeField]
    public Transform timeChangeList;

    [SerializeField]
    public Text scoreText;

    // integer key is the length of the word
    // string value is the actual word
    public Dictionary<int, List<string>> wordbank;

    void Start()
    {
        InitializeWordbank();
        Reset();
    }

    void Update()
    {
        // game is over
        if (handTimer.Done()) return;

        if (sequenceList.transform.childCount > 0)
        {
            Transform nextInput = sequenceList.transform.GetChild(0);
            nextInput.GetComponent<ChallengeInput>().EnableHighlight();
        }

        if (inputActions.Count > 0 && completed < inputActions.Count)
        {
            if (currentInput <= inputActions.Count - 1)
            {
                if (Input.GetKeyDown(currentInputAction))
                {
                    IncrementCurrentInputAction();
                }
            }
        }

        if (completed >= inputActions.Count)
        {
            score++;
            float timeBonus = 2f;
            handTimer.AddSeconds(timeBonus);

            // time change popup
            GameObject timeChange = Instantiate(timeChangePrefab);
            TimeChange tc = timeChange.GetComponent<TimeChange>();
            tc.value = timeBonus;
            tc.valueSuffix = "s";
            timeChange.transform.SetParent(timeChangeList);

            // score change popup
            GameObject scoreChange = Instantiate(scoreChangePrefab);
            tc = scoreChange.GetComponent<TimeChange>();
            tc.value = 1;
            tc.valueSuffix = "";
            scoreChange.transform.SetParent(scoreChangeList);
            Reset();
        }
        else if (challengeTimer.Done())
        {
            float timePenalty = inputActions.Count;
            handTimer.SubtractSeconds(timePenalty);
            GameObject timeChange = Instantiate(timeChangePrefab);
            TimeChange tc = timeChange.GetComponent<TimeChange>();
            tc.value = -timePenalty;
            tc.valueSuffix = "s";
            timeChange.transform.SetParent(timeChangeList);
            Reset();
        }

        scoreText.text = score.ToString();
    }

    List<string> GenerateWordbankSequence()
    {
        List<string> sequence = new List<string>();
        // int wordSize = UnityEngine.Random.Range(minSequenceSize, maxSequenceSize);
        int wordSize = currentSequenceSize;
        List<string> words = wordbank[wordSize];
        int randomWordIndex = UnityEngine.Random.Range(0, words.Count - 1);

        string randomWord = words[randomWordIndex];

        // no repeats
        if (currentSequenceSize < maxSequenceSize) {
            wordbank[wordSize].Remove(randomWord);
            if (wordbank[wordSize].Count == 0) {
                currentSequenceSize++;
            }
        }

        for (int i = 0; i < randomWord.Length; i++)
        {
            sequence.Add(randomWord[i].ToString().ToLower());
        }

        return sequence;
    }


    void Reset()
    {
        currentInput = 0;
        completed = 0;

        inputActions = GenerateWordbankSequence();

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
            challengeInput.inputAction = inputAction;
            challengeInputGameObject.transform.SetParent(sequenceList.transform);
        }

        challengeTimer.SetDuration(defaultDurationSeconds + timerDurationPerLetterSeconds * (inputActions.Count));
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

    void InitializeWordbank()
    {
        wordbank = new Dictionary<int, List<string>>(){
        {3, new List<string> {
            "Ego",
            "ant",
            "gem"
        }},
        {4, new List<string> {
            "Kang",
            "Loki",
            "Odin"
        }},
        {5, new List<string>{
            "Beast",
            "Atlas",
            "X-Men",
            "Cable",
            "Rogue",
            "Havok"
        }},
        {6, new List<string>{
            "Falcon",
            "Gambit",
            "Bedlam",
            "Attuma",
            "Bishop",
            "Diablo",
            "Thanos",
            "Ultron"
        }},
        {7, new List<string> {
            "Crystal",
            "Hawkeye",
            "Justice",
            "Elektra",
            "Cyclops",
            "Sunfire",
            "IronMan",
            "HankPym",
            "TheHand",
        }},
        {8, new List<string> {
            "Avengers",
            "Colossus",
            "Darkhawk",
            "Firebird",
            "Firestar",
            "Hercules",
            "Darkstar",
            "Deadpool",
            "Inhumans",
            "RedSkull",
            "NickFury",
        }},
        {9, new List<string> {
            "Daredevil",
            "Bulldozer",
            "Moonstone",
            "Archangel",
            "Avalanche",
            "DocSamson",
            "MariaHill",
        }},
        {10, new List<string> {
            "Illuminati",
            "Juggernaut",
            "Apocalypse",
            "Pestilence",
            "BlackWidow",
            "GrimReaper",
            "HumanTorch",
        }},
        {11, new List<string> {
            "Sub-Mariner",
            "Quicksilver",
            "EdwinJarvis",
            "FoggyNelson",
            "DoomsdayMan",
        }},
        {12, new List<string> {
            "BlackPanther",
            "CountNefaria",
            "DoctorVoodoo",
            "ScarletWitch"
        }}
        };
    }
}
