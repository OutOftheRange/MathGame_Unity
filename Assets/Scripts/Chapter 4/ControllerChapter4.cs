using UnityEngine;
using TMPro;

public class ControllerChapter4 : MonoBehaviour
{
    [SerializeField] private TMP_Text[] knownStages;
    [SerializeField] private int[] knownStagesIndexes;

    [SerializeField] private int stagesNumber = 7;
    public int[] stages;
    private const int NumbersBorderRange = 30;
    private const int NumbersRange = 20;

    public bool trainShouldMove = true;
    
    private void Start()
    {
        stages = new int[stagesNumber];
        int startStage = Random.Range(-NumbersBorderRange, NumbersBorderRange + 1);
        int range = Random.Range(-NumbersRange, NumbersRange + 1);
        for (int i = 0; i < stagesNumber; ++i)
        {
            stages[i] = startStage;
            startStage += range;
        }

        for (int i = 0; i < knownStages.Length; ++i)
        {
            knownStages[i].text = stages[knownStagesIndexes[i]].ToString();
        }
    }

    private void Update()
    {
    }
}