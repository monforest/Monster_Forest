using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;

    public float smoothTime;

    Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(cam.position.x, cam.position.y, -10);

        transform.position = Vector3.SmoothDamp(transform.position,
            targetPosition, ref velocity, smoothTime);

    }
}
