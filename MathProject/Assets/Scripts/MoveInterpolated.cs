using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInterpolated : MonoBehaviour
{

    [SerializeField] Transform destination;
    Vector3 startPos;
    Vector3 interPos;
    [SerializeField] float timeToDestination;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
       float t = Time.time / timeToDestination;
        if (t > 1.0f)
        {
            t = 1.0f;
        }
        interPos = (1 - t) * startPos + t * destination.position;
        transform.position = interPos;
    }
}
