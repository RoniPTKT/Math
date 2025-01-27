using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCalc : MonoBehaviour
{
    RectTransform canvas;
    [SerializeField] private RectTransform panel;
    [SerializeField] float widthPercent;
    [SerializeField] float heightPercent;

    private void Update()
    {
        canvas = GetComponent<RectTransform>();

        //Calculate the size for the window relative to the screen size
        float windowWidth = canvas.sizeDelta.x / 100 * widthPercent;
        float windowHeight = canvas.sizeDelta.y / 100 * heightPercent;

        //Calculate how much space the window needs on the sides
        float marginLeft = (canvas.sizeDelta.x - windowWidth) / 2;
        float marginTop = (canvas.sizeDelta.y - windowHeight) / -2;

        //Set the size and position of the window
        panel.sizeDelta = new Vector2(windowWidth, windowHeight);
        panel.anchoredPosition = new Vector2 (marginLeft, marginTop);
    }
}
