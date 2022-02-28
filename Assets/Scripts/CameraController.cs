using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform controlledObject;
    [SerializeField] private Transform cam;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = cam.position - controlledObject.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.position = controlledObject.position+distance;
    }
}
