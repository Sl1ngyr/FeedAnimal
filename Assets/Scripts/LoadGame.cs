using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
