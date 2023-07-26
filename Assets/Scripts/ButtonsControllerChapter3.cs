using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsControllerChapter3 : MonoBehaviour
{
    [SerializeField] private GameObject controllerObject;
    private string buttonText;
    public TMP_InputField inputField;

    private void Start()
    {
        inputField = controllerObject.GetComponent<ControllerChapter3>().requestedOperand;
        buttonText = GetComponentInChildren<TMP_Text>().text;
    }

    public void Press()
    {
        inputField.text += buttonText;
    }

    public void Erase()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
}
