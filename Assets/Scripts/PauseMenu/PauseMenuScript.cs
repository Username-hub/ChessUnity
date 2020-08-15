using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class PauseMenuScript : MonoBehaviour
    {
        public GameManager gameManager;
        public BoardScript BoardScript;
        public GameObject pauseMenu;
        
        private bool onPause = false;
        public void PusePeressed()
        {
            if (!onPause)
            {
                PauseGame();
                onPause = true;
            }
            else
            {
                ResumeGame();
                onPause = false;
            }

            gameManager.onPause = onPause;
        }

        private void PauseGame()
        {
            pauseMenu.SetActive(true);
        }

        private void ResumeGame()
        {
            pauseMenu.SetActive(false);
        }

        public void QuitToMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}