using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CoinText : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int coinAmount;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

   
    void Update()
    {
        text.text= coinAmount.ToString();
    }
}
