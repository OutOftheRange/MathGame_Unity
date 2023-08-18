using UnityEngine;
using TMPro;

public class MainMenuNumberButtons : MonoBehaviour
{
    [SerializeField] private GameObject numbersInputField;
    private TMP_InputField inputField;

    private void Start()
    {
        inputField = numbersInputField.GetComponent<TMP_InputField>();
    }

    public void Increment()
    {
        ++Settings.maxLevels;
        inputField.text = Settings.maxLevels.ToString();
    }

    public void Decrement()
    {
        if (Settings.maxLevels > 1)
        {
            --Settings.maxLevels;
            inputField.text = Settings.maxLevels.ToString();
        }
    }
}