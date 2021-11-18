using UnityEngine.SceneManagement;
using UnityEngine;

public class Manimenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLevelsList()
    {
        SceneManager.LoadScene(2);
    }
}
