using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounterController : MonoBehaviour
{
    public Text counterText;

    public string separator = "/";

    public int maxAmount = 20;

    int currAmount = 0;


    void Start()
    {
        ResetCounter();
    }

    protected void UpdateText()
    {
        counterText.text = currAmount + separator + maxAmount;
    }

    public void Increment()
    {
        currAmount++;
        UpdateText();
    }

    public void ResetCounter()
    {
        currAmount = 0;
        UpdateText();
    }

}
