using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue_Control : MonoBehaviour
{
    [System.Serializable]
    public enum idioma
    {
        pt,
        eng,
        spa
    }
    public idioma language;


    [Header("componets")]
    public GameObject DialogueObj; // janena do dialogo
    public Image profilesprite; // sprite do perfil
    public Text spreechText; // texto da fala 
    public Text actorNameText; // nome do NPC

    [Header("Settings")]
    public float typingSpeed; // velocidade da fala 

    // variaveis de controle 
    public bool isShowing; // se a janela esta visivel 
    private int index; // index das sentenças  
    private string[] sentences;
    private string[] nameActor;
    private Sprite[] actorSprite;

    private Player player;
    public static Dialogue_Control instance;

    // awake é chamado antes de todos  os start() na hierarquia de execução do scripts 
    private void Awake()
    {
        instance = this;
    }


    // é chamado ao inicializar
    void Start()
    {
        player = FindObjectOfType<Player>();
    }


    void Update()
    {

    }

    IEnumerator TypeSentences()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            spreechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    // pular para proxima fase/fala 
    public void NextSentence()
    {
        if( spreechText.text == sentences[index])
        {
            if (index < sentences.Length -1)
            {
                
                index++;
                spreechText.text = "";
                StartCoroutine(TypeSentences());

            }
            else //quando termina os textos
            {
                spreechText.text = "";
                actorNameText.text = "";
                index = 0;
                DialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
                player.isPaused = false;
            }
        }
    }

    // chamar a fala do NPC
    public void Spreech(string[]txt, string[]actorName, Sprite[]spriteProfile)
    {
        if (!isShowing)
        {
            DialogueObj.SetActive(true);
            sentences = txt;
            nameActor = actorName;
            actorSprite = spriteProfile;
            profilesprite.sprite = actorSprite[index];
            actorNameText.text = nameActor[index];

            StartCoroutine(TypeSentences());
            isShowing = true;
            player.isPaused = true;
        }
    }

}




