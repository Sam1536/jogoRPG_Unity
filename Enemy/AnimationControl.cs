using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;  
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnimie player;
    private Animator anim;
    private Skeleton skeleton;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerAnimie>();
        skeleton = GetComponentInParent<Skeleton>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("Transition", value);
    }
      
    public void Attack()
    {
        if (!skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

            if (hit != null)
            {
                //detecta colisão com o player
                player.OnHit();
            }
        }
       
       
    }

    public void OnHit()
    {

        if (skeleton.currenthealth <= 0)
        {
            skeleton.isDead = true;
            anim.SetTrigger("death");

            Destroy(skeleton.gameObject, 1f);
        }
        else
        {
            anim.SetTrigger("hit");
            skeleton.currenthealth--;

            skeleton.healthBar.fillAmount = skeleton.currenthealth / skeleton.totalhealth;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

}



