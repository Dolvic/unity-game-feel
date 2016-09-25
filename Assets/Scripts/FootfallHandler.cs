using System;
using UnityEngine;
using System.Collections;

public class FootfallHandler : MonoBehaviour
{
    public AudioSource sound;
    public ParticleSystem leftParticles;
    public ParticleSystem rightParticles;

    public void OnLeftFootfall()
    {
        SimulateFootfall(leftParticles);
    }

    public void OnRightFootfall()
    {
        SimulateFootfall(rightParticles);
    }

    private void SimulateFootfall(ParticleSystem particles)
    {
        if (sound != null)
        {
            sound.Play();
        }

        if (particles != null)
        {
            particles.Play();
        }
    }
}