using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float fTimeLeft = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetTimer()
    {
        fTimeLeft = 6;
    }

    // Update is called once per frame
    void Update()
    {
        fTimeLeft -= Time.deltaTime;
        timerText.text = fTimeLeft.ToString("0");
        if (fTimeLeft < 0)
        {
            //Game Over Screen + Minotaur sounds.
        }
    }
}
