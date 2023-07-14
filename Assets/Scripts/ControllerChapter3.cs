using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerChapter3 : MonoBehaviour
{
    void Start()
    {
        GameObject textObject = new GameObject();
        TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
        textObject.transform.SetParent(transform);
        textObject.layer = 5;
        textMesh.text = "Hello, World!";
        textMesh.fontSize = 24;
        textMesh.color = Color.red;
        textObject.transform.position = new Vector3(0f, 0f, 0f);

    }


    void Update()
    {

    }
}
