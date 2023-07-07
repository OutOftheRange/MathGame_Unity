using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputChecker : MonoBehaviour
{
    [SerializeField] private GameObject controllerObject;

    private Controller controller;
    private Image imageComponent;
    private Color redColor;

    private void Awake()
    {
        controller = controllerObject.GetComponent<Controller>();
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
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
