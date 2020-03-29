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
                    if (listCurrentQuestion[currentQuestionIndex] == '*')
                    {
                        currentQuestionIndex = 0;
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
        int i = 0;
        while(listCurrentQuestion[i]!='*')
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
        char[] characters = currentQuestion.ToCharArray();
        foreach(char character in characters)
        {
            listCurrentQuestion.Add(character);
        }
        listCurrentQuestion.Add('*');
        currentQuestionIndex = 0;
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
        char prevChar4 = currentQuestionIndex >= 4 ? listCurrentQuestion[currentQuestionIndex - 4] : '\0';
        char prevChar3 = currentQuestionIndex >= 3 ? listCurrentQuestion[currentQuestionIndex - 3] : '\0';
        char prevChar2 = currentQuestionIndex >= 2 ? listCurrentQuestion[currentQuestionIndex - 2] : '\0';
        char prevChar = currentQuestionIndex >= 1 ? listCurrentQuestion[currentQuestionIndex - 1] : '\0';
        char currentChar = listCurrentQuestion[currentQuestionIndex];
        char nextChar = listCurrentQuestion[currentQuestionIndex + 1];
        char nextChar2 = nextChar == '*' ? '*' : listCurrentQuestion[currentQuestionIndex + 2];
        char nextChar3 = nextChar2 == '*' ? '*' : listCurrentQuestion[currentQuestionIndex + 3];
        char nextChar4 = nextChar3 == '*' ? '*' : listCurrentQuestion[currentQuestionIndex + 4];

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentChar == 'a')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currentChar == 'b')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentChar == 'c')
            {
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 's' && (nextChar == 'i' || nextChar == 'e') && prevChar != 's') 
            {
                listCurrentQuestion[currentQuestionIndex] = 'c';
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 'k' && (nextChar == 'a' || nextChar == 'u' || nextChar == 'o') && prevChar != 'k')
            {
                listCurrentQuestion[currentQuestionIndex] = 'c';
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 't' && nextChar == 'i' && prevChar != 't')
            {
                listCurrentQuestion[currentQuestionIndex] = 'c';
                listCurrentQuestion.Insert(currentQuestionIndex + 1, 'h');
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 't' && nextChar == 'y' && prevChar != 't')
            {
                listCurrentQuestion[currentQuestionIndex] = 'c';
                listCurrentQuestion[currentQuestionIndex + 1] = 'h';
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentChar == 'd')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentChar == 'e')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentChar == 'f')
            {
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 'h' && nextChar == 'u')
            {
                listCurrentQuestion[currentQuestionIndex] = 'f';
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (currentChar == 'g')
            {
                currentQuestionIndex++;
                return 1;
            }
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (currentChar == 'h')
            {
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 'i' && prevChar == 's')
            {
                listCurrentQuestion.Insert(currentQuestionIndex, 'h');
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 'y' && prevChar == 's')
            {
                listCurrentQuestion[currentQuestionIndex] = 'h';
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
            if (currentChar == 'z' && nextChar == 'i' && prevChar != 'z')
            {
                listCurrentQuestion[currentQuestionIndex] = 'j';
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
            if (currentChar == 'n')
            {
                currentQuestionIndex++;
                return 1;
            }
            if (prevChar == 'n' && prevChar2 != 'n' && currentChar != 'a' && currentChar != 'i' && currentChar != 'u' && currentChar != 'e' && currentChar != 'o' && currentChar != 'y')
            {
                listCurrentQuestion.Insert(currentQuestionIndex, 'n');
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
            if (currentChar == 'q')
            {
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 'k' && nextChar == 'u' && prevChar != 'k')
            {
                listCurrentQuestion[currentQuestionIndex] = 'q';
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
            if (currentChar == 's')
            {
                currentQuestionIndex++;
                return 1;
            }
            if (currentChar == 'u' && prevChar == 't')
            {
                listCurrentQuestion.Insert(currentQuestionIndex, 's');
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
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (currentChar == '-')
            {
                currentQuestionIndex++;
                return 1;
            }
        }
        return 0;

    }
}
