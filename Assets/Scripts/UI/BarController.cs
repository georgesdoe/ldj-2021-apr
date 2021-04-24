using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{ 
    public Image barFill;

    public Text barText;

    public int MaxValue = 100;

    int currValue;

    // Start is called before the first frame update
    void Start()
    {
        barText.text = MaxValue.ToString();
    }

    public void Reduce(int amount)
    {
        currValue = Mathf.Max(currValue - amount, 0);
        barFill.fillAmount = currValue / MaxValue;
        barText.text = currValue.ToString();
    }
}