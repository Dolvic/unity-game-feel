using UnityEngine;
using System.Collections;

public class RagdollHandler : MonoBehaviour
{
    public GameObject character;
    public GameObject ragdollPrefab;

    private  GameObject ragdoll;

    public void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Space))
        {
            return;
        }

        var characterActive = character.activeInHierarchy;
        character.SetActive(!characterActive);

        if (characterActive)
        {
            ragdoll =
                Instantiate(ragdollPrefab, character.transform.position, character.transform.rotation) as GameObject;
        }
        else
        {
            Destroy(ragdoll);
        }
    }
}