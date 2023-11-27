using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsMenu;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsMenu.activeSelf == false)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
        isGamePaused = false;
    }
    
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
        isGamePaused = true;
    }
}
