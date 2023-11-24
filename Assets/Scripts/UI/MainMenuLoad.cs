using UnityEngine;
using UnityEngine.SceneManagement;
using SpawnManagerAnimal;

namespace UI
{
    public class MainMenuLoad : MonoBehaviour
    {
        public void MainMenuButton()
        {
            Time.timeScale = 1f;
            BaseAnimal.playerScoreFeedAnimal = 0;
            SceneManager.LoadScene("Start");
        }
    }
}