using System;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] TMPro.TextMeshProUGUI text;

    private void Start()
    {
        amount = 100;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = amount.ToString();
    }

    public void Add(int moneyGain)
    {
        amount += moneyGain;
        UpdateText();
    }
}
