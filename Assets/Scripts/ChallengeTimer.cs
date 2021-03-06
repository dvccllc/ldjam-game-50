using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChallengeTimer : MonoBehaviour
{
    [SerializeField]
    public float _duration;

    [SerializeField]
    public float _progress;

    [SerializeField]
    public bool paused;

    [SerializeField]
    public Slider slider;

    // StartTimer: starts the Timer countdown using coroutines
    public void StartTimer()
    {
        StartCoroutine(Countdown(_duration));
    }

    // StopTimer: stops the Timer coroutine completely
    public void StopTimer()
    {
        StopAllCoroutines();
    }

    // RestartTimer: restarts the Timer countdown using coroutines and progress
    public void RestartTimer()
    {
        StopTimer();
        ResetTimer();
        StartTimer();
    }

    // PauseTimer: pauses the Timer countdown
    public void PauseTimer()
    {
        paused = true;
    }

    // ResumeTimer: unpauses the Timer countdown
    public void ResumeTimer()
    {
        paused = false;
    }

    // ResetTimer: resets the Timer progress
    public void ResetTimer()
    {
        _progress = 0f;
    }

    // SetDuration: sets the duration as float
    public void SetDuration(float duration)
    {
        _duration = duration;
    }

    // CurrentProgress: returns the current progress as float
    public float CurrentProgress()
    {
        return _progress;
    }

    // Done: returns true/false if the timer is complete
    public bool Done()
    {
        return _progress >= 1f;
    }

    // AddSeconds: simulates gaining time on the clock by removing time from the current progress
    public void AddSeconds(float seconds)
    {
        float time = seconds / _duration;
        _progress -= time;
        if (_progress < 0f) _progress = 0f;
    }

    // SubtractSeconds: simulates losing time on the clock by adding time to the current progress
    public void SubtractSeconds(float seconds)
    {
        float time = seconds / _duration;
        _progress += time;
        if (_progress > 1f) _progress = 1f;
    }

    // Countdown: the inumerator that increments the Timer
    private IEnumerator Countdown(float duration)
    {
        // run until 100%
        while (_progress < 1f)
        {
            // update how the timer is rendered
            UpdateView(_progress);

            // increment the timer using delta time
            if (!paused) _progress += Time.deltaTime / duration;
            _progress = Mathf.Clamp(_progress, 0f, 1f);
            // proceed on next frame
            yield return null;
        }

        SetViewDone();
    }


    // UpdateView: per-frame updates the timer render
    private void UpdateView(float progress)
    {
        if (slider != null) slider.value = 1f - progress;
    }

    // SetViewDone: set the timer render to completed
    private void SetViewDone()
    {
        // keep it "0" for now
        // if (_text != null) _text.text = "done";
    }
}
