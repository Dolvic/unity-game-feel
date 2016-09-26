﻿using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class FootfallHandler : MonoBehaviour
{
    public AudioSource woodSound;
    public AudioSource metalSound;
    public ParticleSystem leftParticles;
    public ParticleSystem rightParticles;

    private Rigidbody rigidBody;
    private bool onMetal;
    private bool onGround;

    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        var characterPosition = rigidBody.position;
        onGround = Math.Abs(characterPosition.y) < .001;
        var position = characterPosition;
        position.y += 1;
        RaycastHit hit;
        var wasHit = Physics.Raycast(position, Vector3.down, out hit, position.y, 1 << 8);
        if (wasHit)
        {
            onMetal = hit.collider.CompareTag("MetalFloor");
            onGround = onGround || onMetal;
        }
    }

    public void OnLeftFootfall()
    {
        if (onGround)
        {
            SimulateFootfall(leftParticles);
        }
    }

    public void OnRightFootfall()
    {
        if (onGround)
        {
            SimulateFootfall(rightParticles);
        }
    }

    private void SimulateFootfall(ParticleSystem particles)
    {
        var sound = onMetal ? metalSound : woodSound;
        if (sound != null)
        {
            sound.Play();
        }

        if (!onMetal && particles != null)
        {
            particles.Play();
        }
    }
}