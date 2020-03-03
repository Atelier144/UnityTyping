using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Sentence
{
    public string title;
    public string question;
}

public class TypingManager : MonoBehaviour
{
    [SerializeField] TextMeshPro textMeshProTitle;
    [SerializeField] TextMeshPro textMeshProQuestion;

    int typingCount;
    int typingTime;
    int typingSpeed;

    string currentTitle;
    string currentQuestion = "tonarinokyakuhayokukakikuukyakuda";

    char[] currentQuestionArray;

    // Start is called before the first frame update
    void Start()
    {
        currentQuestionArray = currentQuestion.ToCharArray();
        StartCoroutine(TestAutoTyping());
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            string[] keys = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            foreach(string key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    typingCount++;
                    UpdateTextMeshProQuestion();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        typingTime++;
    }
    void UpdateTextMeshProQuestion()
    {
        typingSpeed = typingCount * 3000 / typingTime;
        Debug.Log("タイピング速度：" + typingSpeed + "kpm");
    }

    IEnumerator TestAutoTyping()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            UpdateTextMeshProQuestion();
        }
    }
}
