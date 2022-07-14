using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialog : MonoBehaviour
{
    public string[] a;
    TextMeshProUGUI dialogueText;   
    public Queue<string> sentences;
    bool istyping;
    public float typeSpeed=0.1f;
    string currenSentence;
    private void Awake()
    {
        sentences = new Queue<string>();
    }
    void Start()
    {
        Ondialogue(a);
    }
    public void Ondialogue(string[]lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
    }
    public void NextSentence()
    {
        if(sentences.Count!=0)
        {
           currenSentence = sentences.Dequeue();
            istyping = true;
            StartCoroutine(Typing(currenSentence));
        }
    }
    IEnumerator Typing(string line)
    {

        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    
}
