using System.Collections;
using TMPro;
using UnityEngine;

public class HackerTyping : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    [TextArea]
    public string fullText;
    public float delay = 0.05f;
    public AudioSource typingSound;

    void Start()
    {
        StartCoroutine(DelayedTyping());
    }

    IEnumerator DelayedTyping()
    {
        yield return new WaitForSeconds(2f); // 2 saniye bekle
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textUI.text = "";
        foreach (char c in fullText)
        {
            textUI.text += c;
            if (typingSound && c != ' ')
                typingSound.Play();
            yield return new WaitForSeconds(delay);
        }
    }
}
