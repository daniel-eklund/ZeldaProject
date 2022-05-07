using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    //public Animator anim;
    private Queue<string> sentences;
    //bool inDialog = false;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update() { }

    public void StartDialog(Dialog dialog, int start_pos)
    {
        //anim.SetBool("isOpen", true);
        //inDialog = true;
        //Debug.Log("Starting conversation with " + dialog.name);
        dialogBox.SetActive(true);
        nameText.text = dialog.name;
        sentences.Clear();
        Time.timeScale = 0;
        
        if (start_pos == 0) {
            //enqueue every sentence
            foreach (string sentence in dialog.sentences)
                sentences.Enqueue(sentence);
        } else {
            //only enqueue the last sentence
            //TODO: Enqueue up to X positions
            sentences.Enqueue(dialog.sentences[sentences.Count - 1]);
        }
        
        DisplayNextSentence();
    }

    public int DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //end dialog
            EndDialog();
            return 0;
        } else
        {
            string sentence = sentences.Dequeue();
            //Debug.Log(sentence);
            //dialogText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(typeSentence(sentence));
            return 1;
        }
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        Debug.Log("End conversation");
        dialogBox.SetActive(false);
        Time.timeScale = 1;
        //anim.SetBool("isOpen", false);
        //FindObjectOfType<CharController>().setInteract();
    }

}
