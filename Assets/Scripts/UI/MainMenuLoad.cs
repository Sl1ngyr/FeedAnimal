using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuLoad : MonoBehaviour
    {
        public void MainMenuButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Start");
        }
    }
}