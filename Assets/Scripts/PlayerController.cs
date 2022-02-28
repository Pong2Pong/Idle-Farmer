using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject scythe;
    [SerializeField] private Rigidbody controlledObject;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;
    public bool isTriggered;

    private void FixedUpdate()
    {
        controlledObject.velocity = new Vector3(joystick.Horizontal * moveSpeed, controlledObject.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(controlledObject.velocity);
            if (isTriggered)
            {
                animator.enabled=true;
                animator.SetFloat("Speed", 0);
                animator.SetBool("IsHarvesting", true);
                scythe.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                animator.SetFloat("Speed", Vector3.ClampMagnitude(controlledObject.velocity,1).magnitude);
                animator.SetBool("IsHarvesting", false);
                scythe.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}