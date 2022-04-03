using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class EllenSentences : MonoBehaviour
{
    enum State { waiting, typing, despawning}
    [SerializeField] float timeToNextFrase;
    [SerializeField] float timeToDespawn;
    [SerializeField] float speed;
    [SerializeField] string[] frases;

    string currentString;
    int stringLength;
    int currentCharIndex = 0;
    Text text;
    float currentTime;
    int index = -1;
    State currentState = State.waiting;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
        currentTime = timeToNextFrase;
    }

    void Update()
    {
        if (currentTime > 0) currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        switch (currentState) {
            case State.waiting:
                currentState = State.typing;
                currentTime = speed;
                index++;
                if (index >= frases.Length) index = 0;
                currentCharIndex = 0;
                text.text = "";
                stringLength = frases[index].Length;
                break;

            case State.typing:
                text.text += frases[index][currentCharIndex++];
                currentTime = speed;
                if (currentCharIndex >= stringLength) {
                    currentState = State.despawning;
                    currentTime = timeToDespawn;
                }
                break;

            case State.despawning:
                text.text = "";
                currentTime = timeToNextFrase;
                currentState = State.waiting;
                break;
        }
    }
}
