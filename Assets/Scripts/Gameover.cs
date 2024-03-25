using UnityEngine;
using UnityEngine.SceneManagement;


public class Gameover : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Title");
    }

}
