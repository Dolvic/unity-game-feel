using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
    }
}
