using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControll : MonoBehaviour
{
    public TextMeshProUGUI text;

    public CharController cC;
    public float time;



    void Update()
    {
        time = cC.time;
        text.text = time.ToString("0.000");
    }
}
