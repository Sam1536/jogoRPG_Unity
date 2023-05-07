using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Logic : MonoBehaviour
{

    public float speed;
    private float initialSpeed;

    public int index;
    public Animator anim;

    public List<Transform> paths = new List<Transform>();

    void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Dialogue_Control.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("iswalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("iswalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if(index < paths.Count - 1)
            {
                index++;
  // caso vc quer deixar aleatorio os peths. lembrando caso vc tem mais de dois paths : index = random.range(0, paths.count -1);
            }
            else
            {
                index = 0;
            }
        }
        // direcão do Npc
        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
