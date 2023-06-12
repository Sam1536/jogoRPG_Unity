using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    bool playerHit;
    public dialogue_sets dialogue;

    private List<string> sentences = new List<string>();
    private List<string> actorName = new List<string>();
    private List<Sprite> actorSprite = new List<Sprite>();

    // é chamado a cada freme 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            Dialogue_Control.instance.Spreech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());
        }
    }


    void GetTexts()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {

            switch (Dialogue_Control.instance.language)
            {
                case Dialogue_Control.idioma.pt:
                    sentences.Add(dialogue.dialogues[i].Sentence.portuguese);
                    break;
                
                case Dialogue_Control.idioma.eng:
                    sentences.Add(dialogue.dialogues[i].Sentence.english);
                    break;
                
                case Dialogue_Control.idioma.spa:
                    sentences.Add(dialogue.dialogues[i].Sentence.spanish);
                    break;
            }


            actorName.Add(dialogue.dialogues[i].actorName);
            actorSprite.Add(dialogue.dialogues[i].profile);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetTexts();
    }

    // é usado pela fisica
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
           
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
