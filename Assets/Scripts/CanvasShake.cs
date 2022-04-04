using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShake : MonoBehaviour
{
    [SerializeField]
    public float shakeStrength;

    [SerializeField]
    public float shakeSpeed = 5f;

    Color originalImageColor, originalTextColor;

    [SerializeField]
    public Image image;

    [SerializeField]
    public Text text;

    void Start()
    {
        if (image != null) originalImageColor = image.color;
        if (text != null) originalTextColor = text.color;
    }

    void Update()
    {
        transform.localPosition = (Vector3)(Random.insideUnitCircle * shakeStrength);
        if (image != null) image.color = originalImageColor;
        if (text != null) text.color = originalTextColor;

        if (shakeStrength > 0)
        {
            Mathf.Clamp(shakeStrength -= Time.deltaTime * shakeSpeed, 0, 1);
            if (image != null) image.color = new Color(255f, 0f, 0f, originalImageColor.a);
            if (text != null) text.color = new Color(255f, 0f, 0f, originalTextColor.a);
        }
    }

    public void Shake(float value)
    {
        shakeStrength = value;
    }
}
