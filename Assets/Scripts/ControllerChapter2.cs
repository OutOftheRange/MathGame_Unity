using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerChapter2 : MonoBehaviour
{
    [SerializeField] public int towerHeight;
    [SerializeField] private GameObject roof;
    [SerializeField] private GameObject levelTextObject;
    public int maxLevels;
    public int currentLevel;

    private GameObject[,] cells;
    private TextMeshPro[,] equations;
    private GameObject[] results;
    private TextMeshPro roofText;
    private TMP_Text levelText;


    private int[] leftNumbers;
    public int[] rightNumbers;
    public bool[] rightAnswers;
    private char[] signs;
    private HashSet<int> primeNumbers;
    private List<int> dividers;
    private List<int> dividends;

    private int towerWidth = 2;
    private int maxResult = 26;
    private int minResult = 4;
    private int result;

    void Start()
    {
        currentLevel = 1;
        buildLevel();
    }

    public void buildLevel()
    {
        maxLevels = Settings.maxLevels;
        dividers = new List<int>();
        dividends = new List<int>();
        rightAnswers = new bool[towerHeight];
        primeNumbers = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67 };

        roofText = roof.GetComponentsInChildren<TextMeshPro>()[0];
        levelText = levelTextObject.GetComponent<TMP_Text>();
        cells = new GameObject[towerHeight, towerWidth];
        equations = new TextMeshPro[towerHeight, towerWidth];
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Cell");
        results = GameObject.FindGameObjectsWithTag("InputField");

        foreach (GameObject res in results)
        {
            res.GetComponent<TMP_InputField>().text = "";
            res.GetComponent<TMP_InputField>().readOnly = false;
            res.GetComponent<Image>().color = new Color(0, 0, 0, 0.8627f);
        }

        signs = new char[towerHeight];
        leftNumbers = new int[towerHeight];
        rightNumbers = new int[towerHeight];

        for (int i = 0; i < squares.Length; ++i)
        {
            cells[i / towerWidth, i % towerWidth] = squares[i];
            equations[i / towerWidth, i % towerWidth] = squares[i].GetComponentsInChildren<TextMeshPro>()[0];
        }

        ChangeLevelText();

        result = generateResult();
        roofText.text = result.ToString();

        generateDividers();
        generateDividends();

        for (int i = 0; i < towerHeight / 2; ++i)
        {
            signs[i] = '*';
            leftNumbers[i] = generateNumberForMultiplication(i);
            rightNumbers[i] = result / leftNumbers[i];
            equations[i, 0].text = leftNumbers[i].ToString();
            equations[i, 1].text = signs[i].ToString();
        }
        for (int i = towerHeight / 2; i < towerHeight; ++i)
        {
            signs[i] = '/';
            leftNumbers[i] = generateNumberForDivision(i);
            rightNumbers[i] = leftNumbers[i] / result;
            equations[i, 0].text = leftNumbers[i].ToString();
            equations[i, 1].text = signs[i].ToString();
        }
    }

    private int generateResult()
    {
        int tryNumber = Random.Range(minResult, maxResult);
        while (primeNumbers.Contains(tryNumber))
        {
            tryNumber = Random.Range(minResult, maxResult);
        }
        return tryNumber;
    }

    private void generateDividers()
    {
        for (int i = 1; i <= Mathf.Sqrt(result); ++i)
        {
            if (result % i == 0)
            {
                dividers.Add(i);
                if (i * i != result)
                {
                    dividers.Add(result / i);
                }
            }
        }
    }

    private void generateDividends()
    {
        for (int i = 0; i < towerHeight; ++i)
        {
            dividends.Add(result * (i + 1));
        }
    }

    private int generateNumberForMultiplication(int index)
    {
        int tryNumber = dividers[Random.Range(0, dividers.Count)];
        for (int j = 0; j < index; ++j)
        {
            if (signs[j] == signs[index] && tryNumber == leftNumbers[j])
            {
                tryNumber = dividers[Random.Range(0, dividers.Count)];
                j = -1;
            }
        }
        return tryNumber;
    }

    private int generateNumberForDivision(int index)
    {
        int tryNumber = dividends[Random.Range(0, dividends.Count)];
        for (int j = 0; j < index; ++j)
        {
            if (signs[j] == signs[index] && tryNumber == leftNumbers[j])
            {
                tryNumber = dividends[Random.Range(0, dividends.Count)];
                j = -1;
            }
        }
        return tryNumber;
    }

    public void ChangeLevelText()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }
}
