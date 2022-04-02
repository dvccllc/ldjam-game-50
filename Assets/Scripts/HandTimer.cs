using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HandTimer : MonoBehaviour
{
    [SerializeField]
    public float _duration;

    [SerializeField]
    public float progress;

    [SerializeField]
    public Text _text;

    [SerializeField]
    public bool paused;

    // Start, Update, OnTriggerEnter
    void Start() {
        StartTimer();
    }

    // StartTimer: starts the Timer countdown using coroutines
    void StartTimer()
    {
        StartCoroutine(Countdown(_duration));
    }
    
    // StopTimer: stops the Timer coroutine completely
    void StopTimer()
    {
        StopCoroutine(Countdown(_duration));
    }

    // RestartTimer: restarts the Timer countdown using coroutines and progress
    void RestartTimer()
    {
        StopTimer();
        ResetTimer();
        StartTimer();
    }

    // PauseTimer: pauses the Timer countdown
    void PauseTimer()
    {
        paused = true;
    }

    // ResumeTimer: unpauses the Timer countdown
    void ResumeTimer()
    {
        paused = false;
    }

    // ResetTimer: resets the Timer progress
    void ResetTimer()
    {
        progress = 0f;
    }

    // CurrentProgress: returns the current progress as float
    float CurrentProgress()
    {
        return progress;
    }

    // Done: returns true/false if the timer is complete
    bool Done()
    {
        return progress >= 1f;
    }

    // AddTime: simulates gaining time on the clock by removing time from the current progress
    public void AddTime (float time) {
        progress -= time;
    }

    // SubtractTime: simulates losing time on the clock by adding time to the current progress
    public void SubtractTime (float time) {
        progress += time;
    }

    // Countdown: the inumerator that increments the Timer
    private IEnumerator Countdown(float duration)
    {
        // run until 100%
        while(progress <= 1f)
        {
            // update how the timer is rendered
            UpdateView(progress);

            // increment the timer using delta time
            if (!paused) progress += Time.deltaTime / duration;

            // proceed on next frame
            yield return null;
        }

        SetViewDone();
    }

    // UpdateView: per-frame updates the timer render
    private void UpdateView(float normalizedTime) {

        if (_text != null) _text.text = String.Format("{0:0.00}  /  {1:0.00}", normalizedTime * _duration, _duration);
        // TODO: make it clear w/ timer
        // TODO: sequence challenge filling in a slider bar
    
    }

    // SetViewDone: set the timer render to completed
    private void SetViewDone() {
        if (_text != null) _text.text = "done";
        // TODO: set DONE!
    }
}
