using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] public int towerHeight;
    [SerializeField] private GameObject roof;

    private GameObject[,] cells;
    private TextMeshPro[,] equations;
    private TextMeshPro roofText;


    private int[] leftNumbers;
    public int[] rightNumbers;
    public bool[] rightAnswers;
    private char[] signs;

    private int towerWidth = 2;
    private int maxResult = 20;
    private int minResult = 7;
    private int result;

    void Start()
    {
        buildLevel();
    }

    private void buildLevel()
    {
        rightAnswers = new bool[towerHeight];
        roofText = roof.GetComponentsInChildren<TextMeshPro>()[0];
        cells = new GameObject[towerHeight, towerWidth];
        equations = new TextMeshPro[towerHeight, towerWidth];
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Cell");

        signs = new char[towerHeight];
        leftNumbers = new int[towerHeight];
        rightNumbers = new int[towerHeight];

        for (int i = 0; i < squares.Length; ++i)
        {
            cells[i / towerWidth, i % towerWidth] = squares[i];
            equations[i / towerWidth, i % towerWidth] = squares[i].GetComponentsInChildren<TextMeshPro>()[0];
        }

        result = Random.Range(minResult, maxResult - 5);
        roofText.text = result.ToString();
        for (int i = 0; i < towerHeight; ++i)
        {
            int sign = Random.Range(0, 2);
            if (sign == 0)
            {
                signs[i] = '+';
                leftNumbers[i] = generateNewNumber(1, result, i);
            }
            else
            {
                signs[i] = '-';
                leftNumbers[i] = generateNewNumber(result + 1, maxResult, i);
            }

            rightNumbers[i] = Mathf.Abs(result - leftNumbers[i]);
            equations[i, 0].text = leftNumbers[i].ToString();
            equations[i, 1].text = signs[i].ToString();
        }
    }

    private int generateNewNumber(int leftBoundary, int rightBoundary, int index)
    {
        int tryNumber = Random.Range(leftBoundary, rightBoundary);
        for (int j = 0; j < index; ++j)
        {
            if (signs[j] == signs[index] && tryNumber == leftNumbers[j])
            {
                tryNumber = Random.Range(leftBoundary, rightBoundary);
                j = -1;
            }
        }
        return tryNumber;
    }
}
