using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControler : MonoBehaviour
{

    public GameObject TransitionScreen;
    public void OnStartClick()
    {
        TransitionScreen.SetActive(true);
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitClick()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    } 
}