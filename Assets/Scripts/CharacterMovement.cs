using System;
using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var turnSpeed = horizontal;

        var isMoving = vertical > 0;
        anim.SetBool("IsMoving", isMoving);
        anim.SetFloat("TurnSpeed", turnSpeed);
    }
}