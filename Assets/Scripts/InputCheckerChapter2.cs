using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InputCheckerChapter2 : MonoBehaviour
{
    [SerializeField] private GameObject controllerObject;

    private ControllerChapter2 controller;
    private Image imageComponent;
    private Color redColor;

    private void Awake()
    {
        controller = controllerObject.GetComponent<ControllerChapter2>();
        imageComponent = gameObject.GetComponent<Image>();
    }
    private void Start()
    {
        redColor = new Color(0.95f, 0.2f, 0.2f, 0.86f);
    }

    public void CheckAnswer(string number)
    {
        int squareIndex = gameObject.name[gameObject.name.Length - 2] - '0';
        if (!string.IsNullOrEmpty(number))
        {
            if (controller.rightNumbers[squareIndex] == Int32.Parse(number))
            {
                imageComponent.color = new Color(0.1f, 0.8f, 0.1f, 0.86f);
                controller.rightAnswers[squareIndex] = true;
                gameObject.GetComponent<TMP_InputField>().readOnly = true;
            }
            else
            {
                imageComponent.color = redColor;
                if (controller.rightAnswers[squareIndex])
                {
                    controller.rightAnswers[squareIndex] = false;
                }
            }
        }
        else
        {
            imageComponent.color = redColor;
            if (controller.rightAnswers[squareIndex])
            {
                controller.rightAnswers[squareIndex] = false;
            }
        }

        int countRightAnswers = 0;
        foreach (bool answer in controller.rightAnswers)
        {
            if (answer)
            {
                ++countRightAnswers;
            }
        }

        if (countRightAnswers == controller.towerHeight)
        {
            if (controller.currentLevel == controller.maxLevels)
            {
                // TODO YOU WON
                Debug.Log("You won!");
                controller.currentLevel = 1;
            }
            else
            {
                ++controller.currentLevel;
                StartCoroutine(ReloadLevel(1));
            }
        }
    }

    IEnumerator ReloadLevel(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        controller.buildLevel();
    }
}
