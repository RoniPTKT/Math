using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField, Range(0,1)] float value;
    [SerializeField] RectTransform fillBar;

    private EasingFunction.Function easingFunction;
    public EasingFunction.Ease ease;
    [Range (0, 20)] public float easingSpeed;

    private void Awake()
    {
        easingFunction = EasingFunction.GetEasingFunction(ease);        //Set the correct math function based on the chosen enum
        fillBar.localScale = new Vector2 (0, fillBar.localScale.y);     //Reset the progressbar
    }

    void FixedUpdate()
    {
        float currentValue = fillBar.localScale.x;                              //Get the current value of the bar so we can use it later when easing
        if (currentValue != value)                                              //Avoids running the math unnecessary times
        {
            float t = Time.deltaTime * easingSpeed;                             //Normalise the value to ease with over time
            float newValue = easingFunction.Invoke(currentValue, value, t);     //Call the selected math function to interpolate between the current and new values
            fillBar.localScale = new Vector2(newValue, fillBar.localScale.y);   //Set the bar X scale to the new value
        }
    }
}