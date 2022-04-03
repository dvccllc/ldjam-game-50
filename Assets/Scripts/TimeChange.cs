using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeChange : MonoBehaviour
{
    [SerializeField]
    public float fadeDelay = 1f;

    [SerializeField]
    public float fadeDuration = 2f;

    [SerializeField]
    public float _progress;

    [SerializeField]
    public Text plusMinusText, valueText;

    public float value;

    [SerializeField]
    public string valueSuffix;

    Color initialColor;

    // Start is called before the first frame update
    void Start()
    {
        if (value > 0f)
        {
            plusMinusText.color = Color.green;
            valueText.color = Color.green;
            plusMinusText.text = "+";
        }
        else
        {
            plusMinusText.color = Color.red;
            valueText.color = Color.red;
            plusMinusText.text = "-";
        }
        initialColor = plusMinusText.color;
        valueText.text = String.Format("{0:0}" + valueSuffix, Math.Abs(value));
        StartCoroutine(Countdown(fadeDuration));
    }

    // Countdown: the inumerator that increments the Timer
    private IEnumerator Countdown(float duration)
    {
        yield return new WaitForSeconds(fadeDelay);

        // run until 100%
        while (_progress < 1f)
        {
            // increment the timer using delta time
            _progress += Time.deltaTime / duration;
            _progress = Mathf.Clamp(_progress, 0f, 1f);
            Color fadedColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
            plusMinusText.color = Color.Lerp(initialColor, fadedColor, _progress);
            valueText.color = Color.Lerp(initialColor, fadedColor, _progress);
            yield return null;
        }

        GameObject.Destroy(gameObject);
    }

}
