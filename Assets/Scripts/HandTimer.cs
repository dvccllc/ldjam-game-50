using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HandTimer : MonoBehaviour
{
    [SerializeField]
    public float _duration;

    [SerializeField]
    public float _progress;

    [SerializeField]
    public Text _text;

    [SerializeField]
    public bool paused;

    [SerializeField]
    public Slider slider;

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
        _progress = 0f;
    }

    // CurrentProgress: returns the current progress as float
    public float CurrentProgress()
    {
        return _progress;
    }

    // Done: returns true/false if the timer is complete
    bool Done()
    {
        return _progress >= 1f;
    }

    // AddTime: simulates gaining time on the clock by removing time from the current progress
    public void AddTime (float time) {
        _progress -= time;
    }

    // SubtractTime: simulates losing time on the clock by adding time to the current progress
    public void SubtractTime (float time) {
        _progress += time;
    }

    // Countdown: the inumerator that increments the Timer
    private IEnumerator Countdown(float duration)
    {
        // run until 100%
        while(_progress <= 1f)
        {
            // update how the timer is rendered
            UpdateView(_progress);

            // increment the timer using delta time
            if (!paused) _progress += Time.deltaTime / duration;

            // proceed on next frame
            yield return null;
        }

        SetViewDone();
    }

    // UpdateView: per-frame updates the timer render
    private void UpdateView(float progress) {

        if (_text != null) _text.text = String.Format("{0:0.0}", _duration - (progress * _duration));
        if (slider != null) slider.value = progress;
        // TODO: make it clear w/ timer
        // TODO: sequence challenge filling in a slider bar
    
    }

    // SetViewDone: set the timer render to completed
    private void SetViewDone() {
        // keep it "0" for now
        // if (_text != null) _text.text = "done";
    }
}
