using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputCheckerChapter4 : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] unknownStages;
    private Image[] unknownStagesImages;
    [SerializeField] private int[] unknownStagesIndexes;
    private ControllerChapter4 controller;

    private Color inactiveColor = new Color(0.42f, 0.13f, 0.13f, 0.71f);
    private Color activeColor = new Color(0f, 0f, 0f, 0.86f);
    private Color successColor = new Color(0f, 1f, 0.02f, 0.86f);

    private void Start()
    {
        unknownStagesImages = new Image[unknownStages.Length];
        controller = GetComponent<ControllerChapter4>();
        for(int i = 0; i < unknownStages.Length; ++i)
        {
            unknownStages[i].enabled = false;
            unknownStagesImages[i] = unknownStages[i].GetComponent<Image>();
            unknownStagesImages[i].color = inactiveColor;
        }
        unknownStages[controller.currentStage].enabled = true;
        unknownStagesImages[controller.currentStage].color = activeColor;
    }

    public void CheckInput(string xz)
    {
        if (xz.Equals(controller.stages[unknownStagesIndexes[controller.currentStage]].ToString()))
        {
            unknownStages[controller.currentStage].enabled = false;
            unknownStagesImages[controller.currentStage].color = successColor;
            ++controller.currentStageInAllStages;
            controller.SetTrainBorder();
            
            if (controller.currentStage + 1 >= unknownStages.Length) return;
            
            ++controller.currentStage;
            unknownStages[controller.currentStage].enabled = true;
            unknownStagesImages[controller.currentStage].color = activeColor;
        }
    }

    private void Update()
    {
        
    }
}