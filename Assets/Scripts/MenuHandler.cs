using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void StartGame()
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("No scene name set");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
