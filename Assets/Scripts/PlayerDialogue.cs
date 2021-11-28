using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDialogue : MonoBehaviour
{
    public TextMeshPro dialogue;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float intreval = 0.1f;
    private string currentText = "";


    void Start()
    {
        dialogue = GetComponent<TextMeshPro>();
        offsetX = 0f;
        offsetY = 3f;
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

    public IEnumerator Dialogue(string fulltext)
    {
        Debug.Log("got here 2");
        StartCoroutine(ShowText("Where... where am I?  "));
        Debug.Log("got here 3");
        yield return new WaitForSeconds(3f);
        fulltext = "";
        dialogue.text = fulltext;
    }
}
