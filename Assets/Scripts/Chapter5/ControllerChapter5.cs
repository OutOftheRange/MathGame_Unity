using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

enum SignDirection
{
    Left = 0,
    Right = 1
}

public class ControllerChapter5 : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] signs = new TMP_InputField[2];
    [SerializeField] private TMP_Text[] hps = new TMP_Text[2];
    private int[] answers = new int[2];
    private string[] stringAnswers = new string[2];
    private int[] hp = new int[2];

    private void Start()
    {
        GenerateTask();
        PrintSigns();
        
        signs[0].onValueChanged.AddListener(s => {F(SignDirection.Left, s);});
        signs[1].onValueChanged.AddListener(s => {F(SignDirection.Right, s);});
    }

    private void PrintSigns()
    {
        hps[0].text = hp[0].ToString();
        hps[1].text = hp[1].ToString();
    }

    private void GenerateTask()
    {
        hp[0] = Random.Range(1, 31);
        hp[1] = Random.Range(1, 31);

        answers[0] = Gcd(hp[0], hp[1]);
        answers[1] = hp[0] * hp[1] / answers[0];
        stringAnswers[0] = answers[0].ToString();
        stringAnswers[1] = answers[1].ToString();
    }

    private int Gcd(int a, int b) // ЭТО SHIT - НОД
    {
        if (a < b)
        {
            (a, b) = (b, a);
        }

        while (b > 0)
        {
            a %= b;
            (a, b) = (b, a);
        }

        return a;
    }

    private void F(SignDirection signDirection, string inputValue)
    {
        Debug.Log(signs[(int)signDirection]);
        Debug.Log(inputValue);
        if (stringAnswers[(int)signDirection].Equals(inputValue))
        {
            Debug.Log("cum");
        }
        else if (stringAnswers[(int)signDirection].StartsWith(inputValue))
        {
            Debug.Log("sex");
        }
        else
        {
            Debug.Log("not sex");
        }
    }
}
