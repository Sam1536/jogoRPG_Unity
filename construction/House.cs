using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;
    
    [Header("Components")]
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform Point;
    [SerializeField] private GameObject collader;

    private bool detectingPlayer;
    private Player player;
    private float timeCount;
    private bool isBegining;
    private PlayerAnimie playerAnim;
    private Player_itens playerItens;

    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnimie>();
        playerItens = player.GetComponent<Player_itens>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.totalWood >= woodAmount )
        {
            //construção inicializada
            isBegining = true;
            playerAnim.OnhammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = Point.position;
            player.isPaused = true;
            playerItens.totalWood -= woodAmount;

        }
        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeAmount)
            {
                // casa é finalizada
                playerAnim.OnhammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;
                collader.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
