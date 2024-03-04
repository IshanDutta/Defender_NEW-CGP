using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Main");
    }

}
