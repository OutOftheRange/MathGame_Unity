using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ControllerChapter4 : MonoBehaviour
{
    [SerializeField] private Object[] stagesObjects;
    [SerializeField] private TMP_Text[] knownStages;
    [SerializeField] private int[] knownStagesIndexes;

    [SerializeField] private int stagesNumber = 7;
    public int[] stages;
    private const int NumbersBorderRange = 30;
    private const int NumbersRange = 20;

    public int trainBorder = 0;
    public int currentStage = 0;

    public int currentStageInAllStages = 0;
    private int curKnownIndex = 0;

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

        SetTrainBorder();
    }

    public void SetTrainBorder()
    {
        if (knownStagesIndexes[curKnownIndex] == currentStageInAllStages + 1)
        {
            ++currentStageInAllStages;
        }

        if (knownStagesIndexes[curKnownIndex] == currentStageInAllStages)
        {
            while (curKnownIndex < knownStagesIndexes.Length &&
                   knownStagesIndexes[curKnownIndex] == currentStageInAllStages)
            {
                ++curKnownIndex;
                if (curKnownIndex + 1 < knownStagesIndexes.Length &&
                    knownStagesIndexes[curKnownIndex + 1] == currentStageInAllStages + 1)
                {
                    ++currentStageInAllStages;
                }
            }

            trainBorder = (int)stagesObjects[currentStageInAllStages].GetComponent<Transform>().localPosition.x;
        }
        else
        {
            trainBorder = (int)stagesObjects[currentStageInAllStages].GetComponent<Transform>().localPosition.x;
        }
        
    }

    private void Update()
    {
    }
}