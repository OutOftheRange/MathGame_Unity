using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsControllerChapter3 : MonoBehaviour
{
    [SerializeField] private GameObject controllerObject;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject fireWork;
    private ControllerChapter3 controller;
    private string buttonText;
    private TMP_InputField inputField;

    private void Start()
    {
        controller = controllerObject.GetComponent<ControllerChapter3>();
        inputField = controller.requestedOperand;
        buttonText = GetComponentInChildren<TMP_Text>().text;
    }

    public void Press()
    {
        if (!controller.gameOver)
        {
            inputField.text += buttonText;
            if (!string.IsNullOrEmpty(inputField.text) && inputField.text == controller.requestedNumber)
            {
                controller.gameOver = true;
                StartCoroutine(RunFireWork(1));
            }
        }
    }

    public void Erase()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    IEnumerator RunFireWork(float delayTime)
    {
        fireWork.SetActive(true);
        yield return new WaitForSeconds(delayTime);
        gameManager.GameOver();
    }
}
