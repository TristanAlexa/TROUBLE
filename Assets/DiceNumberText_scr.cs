using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DiceNumberText_scr : MonoBehaviour
{
    //UI Text component
    Text text;
    public static int diceNumber;

    // Initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = diceNumber.ToString();
    }
}
