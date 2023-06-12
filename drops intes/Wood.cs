using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float TimeMove;

    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount < TimeMove)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }

}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player_itens>().totalWood++;
            Destroy(gameObject);
        }
    }
}
