using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
[RequireComponent(typeof(Text))]
public class EllenSentences : MonoBehaviour
{
    enum State { waiting, typing, despawning}
    [SerializeField] int level = 1;
    [SerializeField] float timeToNextFrase;
    [SerializeField] float timeToDespawn;
    [SerializeField] float speed;
    [SerializeField] string fileName;
    private string path;
    string[] frases;
    [SerializeField] Color playerColor;
    [SerializeField] Color secondVoiceColor;
    string currentString;
    int stringLength;
    int currentCharIndex = 0;
    Text text;
    float currentTime;
    int index = -1;
    State currentState = State.waiting;
    void Start()
    {
        if (ScriptableStaticClass.instance.level != level) {
            this.enabled = false;
            return;
        }
        path = Application.streamingAssetsPath + "/EllentFrases/" + fileName + ".txt";
        frases = File.ReadAllLines(path);
        text = GetComponent<Text>();
        text.text = "";
        currentTime = 2;
    }

    void Update()
    {
        if (index < frases.Length && currentTime > 0) currentTime -= Time.deltaTime;
        if (index < frases.Length && currentTime <= 0)
        switch (currentState) {
            case State.waiting:
                currentState = State.typing;
                currentTime = speed;
                index++;
                    if (index >= frases.Length) return;
                currentCharIndex = 0;
                text.text = "";
                stringLength = frases[index].Length;
                if(!string.IsNullOrEmpty(frases[index]) && frases[index][frases[index].Length-1] == '^') {
                    text.color = secondVoiceColor;
                        frases[index] = frases[index].Split('^')[0];
                        stringLength--;
                } else {
                    text.color = playerColor;
                }
                break;

            case State.typing:
                if(!string.IsNullOrEmpty(frases[index]) && frases[index][currentCharIndex] == '@') {
                        text.text += ScriptableStaticClass.instance.explorerNumber.ToString();
                        currentCharIndex++;
                } else if(!string.IsNullOrEmpty(frases[index]))
                    text.text += frases[index][currentCharIndex++]/* == '@' ? ScriptableStaticClass.instance.explorerNumber.ToString() : frases[index][currentCharIndex++].ToString()*/;
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
