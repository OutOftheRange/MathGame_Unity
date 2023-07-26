using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FilterInput : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void CheckInput(string number)
    {
        string formattedNumber = number.Replace("-", "");
        if (!string.IsNullOrEmpty(formattedNumber))
        {
            while (formattedNumber[0] == '0')
            {
                formattedNumber = formattedNumber.Remove(0, 1);
                if (string.IsNullOrEmpty(formattedNumber))
                {
                    break;
                }
            }

            if (!string.IsNullOrEmpty(formattedNumber))
            {
                Settings.maxLevels = Convert.ToInt32(formattedNumber);
            }
        }

        inputField.text = formattedNumber;
    }

    public void FillIfEmpty(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            inputField.text = "1";
            Settings.maxLevels = 1;
        }
    }
}
