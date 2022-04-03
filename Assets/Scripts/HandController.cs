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
    public GameObject gameover;


    // Start is called before the first frame update
    void Start()
    {
        handTimer = GetComponent<HandTimer>();
        handTimer.RestartTimer();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // if the handtimer is complete, pause the game and wait for reset
        if (handTimer.Done())
        {
            gameover.SetActive(true);
            handTimer.SetViewDone();
            handTimer.StopTimer();
            challengeTimer.StopTimer();
            return;
        }
        // yield finished coroutine


        float fingerValue = 0f;
        // foreach (Finger finger in fingers) {
        //     finger.pressed = false;
        //     // better code: check if finger.action is in actions
        //     fingerValue = playerInput.actions[finger.action].ReadValue<float>();
        //     if (fingerValue != 0f ) {
        //         finger.pressed = true;
        //     }
        //     // update color
        //     finger.UpdateColor();

        //     // keep from squeezing finger


        // }
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

