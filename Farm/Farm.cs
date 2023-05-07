using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotsSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite Carrot;
    [SerializeField] private Sprite hole;

    [Header("settings")]
    [SerializeField] private int DigAmount; // quantidade de "escavação"
    [SerializeField] private int WaterAmount; // total de água para cenoura nascer
    
    [SerializeField] private bool detecting;
    private bool isPlayer; // fica verdadeira quando o player fica encostando
    
    
    private int initialDigAmount;
    private float currentWater;

    private bool dugHole;

    private bool plantedCarrots;

    Player_itens playerItens;


    // Start is called before the first frame update
    void Start()
    {
        playerItens = FindObjectOfType<Player_itens>();
        initialDigAmount = DigAmount;
    }


    private void Update()
    {
        
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            // encheu o total de água necessario
            if (currentWater >= WaterAmount && !plantedCarrots)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRenderer.sprite = Carrot;

                plantedCarrots = true;

            }
            if (Input.GetKeyDown(KeyCode.E)&& plantedCarrots && isPlayer)
            {
                audioSource.PlayOneShot(carrotsSFX);
                spriteRenderer.sprite = hole;
                playerItens.carrots++;
                currentWater = 0f;
            }
        }
    }

    // Update is called once per frame
    public void OnHit()
    {
        DigAmount--;

        if(DigAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

       // if (DigAmount <= 0)
        
            // plantar a cenoura
       //   spriteRenderer.sprite = Carrot;

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dig"))
        {
            OnHit();
        }
        if (collision.CompareTag("water"))
        {
            detecting = true;
        }
        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            detecting = false;
        }
        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}