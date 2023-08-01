using Enum = System.Enum;
using Array = System.Array;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Operator = Enums.Operator;

public class ControllerChapter3 : MonoBehaviour
{
    [SerializeField] private GameObject[] equation;
    private TMP_InputField leftOperand;
    private TMP_Text eqOperator;
    private TMP_InputField centerOperand;
    private TMP_InputField rightOperand;
    private Operator _operator;
    public TMP_InputField requestedOperand;
    public string requestedNumber;
    private int maxNumber = 20;
    private int firstNumber;
    private int secondNumber;
    private int result;
    public bool gameOver = false;

    void Start()
    {
        leftOperand = equation[0].GetComponent<TMP_InputField>();
        eqOperator = equation[1].GetComponent<TMP_Text>();
        centerOperand = equation[2].GetComponent<TMP_InputField>();
        rightOperand = equation[3].GetComponent<TMP_InputField>();

        LoadLevel();
    }

    private void LoadLevel()
    {
        Array operatorElements = Enum.GetValues(typeof(Operator));
        _operator = (Operator)operatorElements.GetValue(Random.Range(0, operatorElements.Length));

        result = Random.Range(3, maxNumber + 1);
        firstNumber = Random.Range(1, result);
        secondNumber = result - firstNumber;

        switch (Random.Range(0, 3))
        {
            case 0:
                requestedOperand = leftOperand;
                requestedNumber = ToRoman(firstNumber);
                leftOperand.readOnly = false;
                break;
            case 1:
                requestedOperand = centerOperand;
                requestedNumber = ToRoman(secondNumber);
                centerOperand.readOnly = false;
                break;
            case 2:
                requestedOperand = rightOperand;
                requestedNumber = ToRoman(result);
                rightOperand.readOnly = false;
                break;
        }

        if (_operator == Operator.Add)
        {
            eqOperator.text = "+";

            if (leftOperand.readOnly)
            {
                leftOperand.text = ToRoman(firstNumber);
            }
            if (centerOperand.readOnly)
            {
                centerOperand.text = ToRoman(secondNumber);
            }
            if (rightOperand.readOnly)
            {
                rightOperand.text = ToRoman(result);
            }
        }
        else
        {
            eqOperator.text = "-";

            if (leftOperand.readOnly)
            {
                leftOperand.text = ToRoman(result);
            }
            else
            {
                requestedNumber = ToRoman(result);
            }
            if (centerOperand.readOnly)
            {
                centerOperand.text = ToRoman(firstNumber);
            }
            else
            {
                requestedNumber = ToRoman(firstNumber);
            }
            if (rightOperand.readOnly)
            {
                rightOperand.text = ToRoman(secondNumber);
            }
            else
            {
                requestedNumber = ToRoman(secondNumber);
            }
        }

        requestedOperand.readOnly = true;
    }

    private static string ToRoman(int number)
    {
        if (number >= 50) return "L" + ToRoman(number - 50);
        if (number >= 40) return "XL" + ToRoman(number - 40);
        if (number >= 10) return "X" + ToRoman(number - 10);
        if (number >= 9) return "IX" + ToRoman(number - 9);
        if (number >= 5) return "V" + ToRoman(number - 5);
        if (number >= 4) return "IV" + ToRoman(number - 4);
        if (number >= 1) return "I" + ToRoman(number - 1);
        return "";
    }
}
