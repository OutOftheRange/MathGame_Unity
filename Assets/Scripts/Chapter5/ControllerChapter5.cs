using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private Image enemyHpBar;
    [SerializeField] private GameObject[] trolls = new GameObject[2];
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject fireWork;

    public GameObject[] hearts;
    public HeartsAnimation[] heartsControllers;
    public GameObject[] heartsExplosion;

    private int[] answers = new int[2];
    private string[] stringAnswers = new string[2];
    private int[] hp = new int[2];
    private bool[] isAnswered = new bool[2];
    private short totalStages = 3;
    private short ourHp;
    private short enemyHp;

    private void Start()
    {
        GenerateTask();

        heartsControllers = new HeartsAnimation [hearts.Length];
        for (int i = 0; i < hearts.Length; ++i)
        {
            heartsControllers[i] = hearts[i].GetComponent<HeartsAnimation>();
        }

        heartsControllers[^1].StartAnimation();

        ourHp = 3;
        enemyHp = totalStages;

        signs[0].onValueChanged.AddListener(s => { OnInputAnswer(SignDirection.Left, s); });
        signs[1].onValueChanged.AddListener(s => { OnInputAnswer(SignDirection.Right, s); });
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

        PrintSigns();
        isAnswered[0] = false;
        isAnswered[1] = false;
    }

    private int Gcd(int a, int b) // THIS SHIT - НОД
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

    private void OnInputAnswer(SignDirection signDirection, string inputValue)
    {
        Debug.Log(signs[(int)signDirection]);
        Debug.Log(inputValue);
        if (stringAnswers[(int)signDirection].Equals(inputValue))
        {
            isAnswered[(int)signDirection] = true;
            Debug.Log("cum");
        }
        else if (stringAnswers[(int)signDirection].StartsWith(inputValue))
        {
            Debug.Log("sex");
        }
        else
        {
            Debug.Log("not sex");
            DecreaseOurHp();
        }

        CheckIfIOrEnemyHaveZeroHp();
    }

    private void DecreaseOurHp()
    {
        --ourHp;
        heartsControllers[ourHp].StopAnimation();
        hearts[ourHp].SetActive(false);
        if (ourHp > 0)
        {
            heartsControllers[ourHp - 1].StartAnimation();
        }

        heartsExplosion[ourHp].SetActive(true);
    }

    private void CheckIfIOrEnemyHaveZeroHp()
    {
        if (ourHp == 0)
        {
            // TODO end level, show game over screen (defeat)
            StartCoroutine(RunFireWork());
        }

        ushort rightAnswers = 0;
        foreach (bool result in isAnswered)
        {
            if (result)
            {
                ++rightAnswers;
            }
        }

        if (rightAnswers == isAnswered.Length)
        {
            // minus enemy hp and start new task

            --enemyHp;
            enemyHpBar.fillAmount -= 1.0f / totalStages;
            if (Math.Abs(enemyHpBar.fillAmount) < 1e-3)
            {
                enemyHpBar.fillAmount = 0;
            }

            if (enemyHp == 0)
            {
                // TODO end level, show game over screen (victory)

                foreach (GameObject troll in trolls)
                {
                    troll.GetComponent<Animator>().SetBool("isDead", true);
                }

                StartCoroutine(RunFireWork(true));
            }
            else
            {
                GenerateTask();
                signs[0].text = "";
                signs[1].text = "";
            }
        }
    }

    private IEnumerator RunFireWork(bool victory = false)
    {
        fireWork.SetActive(true);
        yield return new WaitForSeconds(1);
        gameManager.GameOver(victory);
    }
}