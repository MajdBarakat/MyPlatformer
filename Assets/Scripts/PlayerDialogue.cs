using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDialogue : MonoBehaviour
{
    public TextMeshPro dialogue;
    [SerializeField] private float intreval = 0.1f;
    [SerializeField] private float timeBetween;
    [SerializeField] private string[] dialogueList;
    private string currentText = "";


    void Start()
    {
        dialogue = GetComponent<TextMeshPro>();
        StartCoroutine(Dialogue(dialogueList));
    }

    IEnumerator ShowText(string fulltext)
    {
        for (int i = 0; i < fulltext.Length; i++)
        {
            currentText = fulltext.Substring(0, i);
            dialogue.text = currentText;
            yield return new WaitForSeconds(intreval);
        }
    }

    IEnumerator Dialogue(string[] dialogueList)
    {
        for (int i = 0; i < dialogueList.Length; i++)
        {
        StartCoroutine(ShowText(dialogueList[i]));
        yield return new WaitForSeconds(timeBetween);
        }
        dialogue.text = "";
    }
}
