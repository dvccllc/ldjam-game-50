using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRotation : MonoBehaviour
{
    [SerializeField]
    public Quaternion originalRotation;

    [SerializeField]
    public Quaternion toRotation;

    [SerializeField]
    public float speed = 1f;

    [SerializeField]
    public HandTimer handTimer;


    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(handTimer.CurrentProgress());

        // transform.localRotation = completedRatioBetween original and destination;

        // transform.localRotation = new Quaternion (transform.localRotation.eulerAngles.x,transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z, 0f);

        // transform.localRotation = Quaternion.RotateTowards(transform.localRotation, toRotation, speed * Time.deltaTime);
    }
}
