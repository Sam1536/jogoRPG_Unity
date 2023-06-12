using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    
    [SerializeField] private int percentage; // porcentagem de chance de pescar um peixe a cada tentativa 
    [SerializeField] private GameObject fishPrefeb;

    private Player_itens player;
    private PlayerAnimie playerAnim;
    private bool detectingPlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_itens>();
        playerAnim = player.GetComponent<PlayerAnimie>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue < percentage)
        {
            // conseguiu pescar o peixe]
            Instantiate(fishPrefeb, player.transform.position + new Vector3(Random.Range(-2.6f, -1f),0f,0f), Quaternion.identity);
        }
        else
        {
            // não conseguiu pescar o peixe
            Debug.Log("nao pescou");
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
