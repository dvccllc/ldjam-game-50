using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRotation : MonoBehaviour
{
    [SerializeField]
    public float speed = 1f;

    [SerializeField]
    public HandTimer handTimer;

    public Vector3 currentAngle;
    public Vector3 originalAngle;
    public Vector3 targetAngle;

    public float fullFlex = 90f;

    // Start is called before the first frame update
    void Start()
    {
        // eulerAngles is -180f to 180f (x, y, z)

        // set originalAngle so we can have a progress-to-flexed
        originalAngle = transform.eulerAngles;

        // currentAngle will track where we are at all times
        currentAngle = transform.eulerAngles;

        // targetAngle is where we want to go
        //    set a default to the current, so no change from original.
        targetAngle = currentAngle;
    }

    // ClampAngle: takes a -180 to 180 euler angle, and "clamps" it between 0 and 360.
    public static float ClampAngle(float eulerAngles)
    {
        float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
        if (result < 0)
        {
            result += 360f;
        }
        return result;
    }

    public void Update()
    {

        // 0 to 1 float of timer progress (hand closing)
        float progress = handTimer.CurrentProgress();

        // only rotate X for now
        //   we can set other "flex" angles but for now just X
        float angleXDestination = originalAngle.x + (fullFlex * progress);

        // targetAngle is a clamped euler (x, y, z) destination
        //    it uses the currentAngle, and the angleXDestination we calculated using progress
        //       so... 0 to 100% between originalAngle and the fullFlexAngle
        targetAngle = new Vector3(ClampAngle(angleXDestination), ClampAngle(currentAngle.y), ClampAngle(currentAngle.z));

        // here is the Math magic, a slow ease function between our current euler and the target euler


        // todo: if the difference between currentAngle and targetAngle is small enough, snap it into place.
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, speed * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, speed * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, speed * Time.deltaTime));

        // assign the transform eulers
        // remember to clamp angles between 0 and 360
        transform.eulerAngles = new Vector3(ClampAngle(currentAngle.x), ClampAngle(currentAngle.y), ClampAngle(currentAngle.z));
    }

}
