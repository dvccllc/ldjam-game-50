using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HandTimer))]
public class HandController : MonoBehaviour
{
    [SerializeField]
    public HandTimer handTimer;

    [SerializeField]
    public ChallengeTimer challengeTimer;

    [SerializeField]
    public GameOver gameOver;

    [SerializeField]
    public AudioSource soundManager;


    [SerializeField]
    public PauseToggle pauseToggle;

    // Start is called before the first frame update
    void Start()
    {
        handTimer = GetComponent<HandTimer>();
        handTimer.RestartTimer();
        //call SetWelcomeActive on ENTER key press and call the RestartTimer
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (GameOver.GameOverActive) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else pauseToggle.TogglePause(!PauseToggle.GameIsPaused);
        }

        if (PauseToggle.GameIsPaused || WelcomeScreen.WelcomeActive || GameOver.GameOverActive) return;

        // if the handtimer is complete, pause the game and wait for reset
        if (handTimer.Done())
        {
            gameOver.ToggleGameOver(true);
            handTimer.SetViewDone();
            handTimer.StopTimer();
            challengeTimer.StopTimer();
            return;
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

// penalty for wrong input
// score - 

