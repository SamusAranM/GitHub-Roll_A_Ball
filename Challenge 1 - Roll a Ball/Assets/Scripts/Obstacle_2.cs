using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_2 : MonoBehaviour
{
    // Update is called once per frame
    // Update is called once per frame

    Vector3 startPosition = new Vector3(49.74f, 0.5f, 4f);
    Vector3 endPosition = new Vector3(38.24f, 0.5f, 4f);

    void Update() {

        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time, 1));

    }
}
