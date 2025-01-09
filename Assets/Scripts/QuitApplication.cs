using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(0);
        }
    }
}
