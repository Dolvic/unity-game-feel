using System;
using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    private float moveSpeed;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        moveSpeed = 0;
    }

    public void Update()
    {
        DetermineMoveSpeed();
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var halfHorizontal = Input.GetAxis("HalfHorizontal");

        var turnSpeed = DecideTurnSpeed(horizontal, halfHorizontal);

        var isMoving = vertical > 0;
        anim.SetBool("IsMoving", isMoving);
        anim.SetFloat("TurnSpeed", turnSpeed);

        anim.SetFloat("MoveSpeed", moveSpeed);
    }

    private void DetermineMoveSpeed()
    {
        KeyCode[] speedKeys =
        {
            KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5,
            KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0
        };
        var speed = moveSpeed;

        for (var i = 0; i < speedKeys.Length; i++)
        {
            var speedKey = speedKeys[i];
            if (Input.GetKeyUp(speedKey))
            {
                speed = (float) Math.Round(i / 9.0, 2);
                break;
            }
        }
        moveSpeed = speed;
    }

    private static float DecideTurnSpeed(float horizontal, float halfHorizontal)
    {
        float turnSpeed = 0;

        if (horizontal != 0)
        {
            turnSpeed = horizontal;
        }
        else if(halfHorizontal != 0)
        {
            turnSpeed = halfHorizontal * 0.5f;
        }

        return turnSpeed;
    }
}