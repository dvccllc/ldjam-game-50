using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{   
    [SerializeField]
    public bool pressed;
    [SerializeField]
    public string action;


    public Color originalColor;

    public Renderer[] renderers;
    void Start() {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void UpdateColor () {
        foreach (Renderer r in renderers) {
            if (r == null) continue;
            r.material.color = originalColor;
            if (pressed) r.material.color = Color.red;
        }
    }
}
