using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target_Player;

    public Vector3 offset_Camera;
    void Start()
    {
        offset_Camera = transform.position - target_Player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = target_Player.transform.position + offset_Camera;
        transform.position = pos;
    }
}
