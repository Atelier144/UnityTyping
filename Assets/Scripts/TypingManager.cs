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
    [SerializeField] TextMeshProUGUI textMeshProTitle;
    [SerializeField] TextMeshProUGUI textMeshProQuestion;

    [SerializeField] Sentence[] sentences;

    int typingCount;
    int typingTime;
    int typingSpeed;

    string currentTitle;
    string currentQuestion = "choukousokutaipingu";

    List<char> listCurrentQuestion = new List<char>();

    int currentQuestionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetSentence();
        StartCoroutine(TestAutoTyping());
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {

            switch(Type())
            {
                case 1:
                    typingCount++;
                    if (listCurrentQuestion[currentQuestionIndex] == '}')
                    {
                        currentQuestionIndex = 1;
                        typingSpeed = 3000 * typingCount / typingTime;
                        Debug.Log("タイピング速度：" + typingSpeed + "kpm");
                        typingTime = 0;
                        typingCount = 0;
                        SetSentence();
                    }
                    
                    UpdateTextMeshProQuestion();
                    break;
                case 2:
                    Debug.LogError("ミスタイプ");
                    break;
            }

        }
    }

    private void FixedUpdate()
    {
        typingTime++;
    }
    void UpdateTextMeshProQuestion()
    {
        string question = "<style=Typed>";
        int i=1;
        while(listCurrentQuestion[i]!='}')
        {
            
            if(currentQuestionIndex == i){
                question += "</style><style=Untyped>";
            }
            question += listCurrentQuestion[i];
            i++;
        }
        question += "</style>";
        textMeshProQuestion.text = question;
       

        
    }

    void SetSentence()
    {
        Sentence sentence = sentences[Random.Range(0, sentences.Length)];
        currentTitle = sentence.title;
        currentQuestion = sentence.question;

        listCurrentQuestion.Clear();
        listCurrentQuestion.Add('{');
        char[] characters = currentQuestion.ToCharArray();
        foreach(char character in characters)
        {
            listCurrentQuestion.Add(character);
        }
        listCurrentQuestion.Add('}');
        currentQuestionIndex = 1;
        UpdateTextMeshProQuestion();
        textMeshProTitle.text = currentTitle;
    }
    IEnumerator TestAutoTyping()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
        }
    }

    int Type()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'a')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'b')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'c')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'd')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'e')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'f')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'g')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'h')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'i')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'j')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'k')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'l')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'm')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'n')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'o')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'p')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'q')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'r')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 's')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 't')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'u')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'v')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'w')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'x')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'y')
            {
                currentQuestionIndex++;
                return 1;
            }
            if(listCurrentQuestion[currentQuestionIndex]== 'i') //「い」のタイピングか？
            {
                char prevChar = listCurrentQuestion[currentQuestionIndex - 1];
                if(prevChar == '{' || prevChar == 'a' || prevChar == 'i' || prevChar == 'u' || prevChar == 'e' || prevChar == 'o')
                {
                    listCurrentQuestion.Insert(currentQuestionIndex, 'y');
                    currentQuestionIndex++;
                    return 1;
                }
                if (prevChar == 'n') //前が「ん」の可能性があるか？
                {
                    if (listCurrentQuestion[currentQuestionIndex - 2] == 'n') //その前が「ん」か？
                    {
                        if (listCurrentQuestion[currentQuestionIndex - 3] == 'n') //「ん」の後が本当に「い」か？
                        {
                            return 2;

                        }
                        else
                        {
                            listCurrentQuestion.Insert(currentQuestionIndex, 'y');
                            currentQuestionIndex++;
                            return 1;
                        }
                    }
                }
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (listCurrentQuestion[currentQuestionIndex] == 'z')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        return 0;

    }
}
