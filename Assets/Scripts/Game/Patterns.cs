using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patterns : MonoBehaviour
{
    //Text of the buttons.
    public TextMeshProUGUI[] buttonTexts = new TextMeshProUGUI[3];

    //The size of the pattern. This defines the pattern array size.
    public int iPatternSize = 10;
    public int[] arrPattern;

    //The question the player is and the answer of the question (correct button).
    public int iCurrentQuestion = 0;
    public int iCurrentAnswer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //basically srand (changes the randomizer seed depending on the time).
        Random.InitState((int)System.DateTime.Now.Ticks);
        //Pattern array initialized
        arrPattern = new int[iPatternSize];
        SetPatterns();
        PrintQuestion(iCurrentQuestion);
    }
    //fills the pattern arrays with random number within 0-20 (repeated numbers are allowed)
    void SetPatterns()
    {
        for (int i = 0; i < arrPattern.Length; i++)
        {
            arrPattern[i] = Random.Range(0, 21);
        }
    }
    //Sets the button that will have the correct answer.
    void SetAnswer()
    {
        iCurrentAnswer = Random.Range(1, 4);
    }
    //Gets the answer the player inputted through pressing the buttons.
    public void Answer(int answer)
    {
        iCurrentQuestion++;
        PrintQuestion(iCurrentQuestion);
    }
    //Prints the questions on the UI (the buttons) and also creates two (2) fake answers to fill the buttons the other buttons that aren't the correct answer.
    void PrintQuestion(int patternIndex)
    {
        int a1 = Random.Range(0,21);
        int a2 = Random.Range(0,21);
        while(a1 == a2 || a1 == arrPattern[patternIndex] || a2 == arrPattern[patternIndex])
        {
            a1 = Random.Range(0, 21);
            a2 = Random.Range(0, 21);
        }
        SetAnswer();
        switch (iCurrentAnswer - 1)
        {
            case 0:
                buttonTexts[0].text = arrPattern[patternIndex].ToString();
                buttonTexts[1].text = a1.ToString();
                buttonTexts[2].text = a2.ToString();
                break;
            case 1:
                buttonTexts[1].text = arrPattern[patternIndex].ToString();
                buttonTexts[0].text = a1.ToString();
                buttonTexts[2].text = a2.ToString();
                break;
            case 2:
                buttonTexts[2].text = arrPattern[patternIndex].ToString();
                buttonTexts[0].text = a1.ToString();
                buttonTexts[1].text = a2.ToString();
                break;
            default:
                break;
        }
    }
}
