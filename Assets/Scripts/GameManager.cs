using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverVictoryUI;
    [SerializeField] private GameObject gameOverDefeatUI;

    public void GameOver(bool won = false)
    {
        if (won) gameOverVictoryUI.SetActive(true);
        else gameOverDefeatUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}