using Unity.VisualScripting;
using UnityEngine;

public class TrainShouldMove : MonoBehaviour
{
    [SerializeField] private Object controllerObject;
    [SerializeField] private int speed;
    [SerializeField] private int rightBorder;
    private ControllerChapter4 controller;

    private void Start()
    {
        controller = controllerObject.GetComponent<ControllerChapter4>();
    }

    void Update()
    {
        if (controller.trainShouldMove && transform.localPosition.x < rightBorder)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
    }
}