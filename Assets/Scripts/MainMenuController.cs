using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject welcomePhrase;
    [SerializeField] private int topBoundary = -120;
    [SerializeField] private int bottomBoundary = -250;
    [SerializeField] private int speed = 10;
    private RectTransform welcomePhraseRectTransform;
    private sbyte direction = 1;

    private void Start()
    {
        welcomePhraseRectTransform = welcomePhrase.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (welcomePhraseRectTransform.anchoredPosition.y < bottomBoundary)
        {
            direction = 1;
        }
        else if (welcomePhraseRectTransform.anchoredPosition.y > topBoundary)
        {
            direction = -1;
        }

        welcomePhraseRectTransform.anchoredPosition += new Vector2(0, direction * speed * Time.deltaTime);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Chapter 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Chapter 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Chapter 3");
    }
}