using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
