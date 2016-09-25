using UnityEngine;
using System.Collections;

public class FootfallHandler : MonoBehaviour
{
    public AudioSource sound;

    public void OnFootfall()
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}