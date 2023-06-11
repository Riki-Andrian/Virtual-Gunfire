using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private int maxHealt = 100;
    private int curentHealt;
    public Animator animator;
    private Player player;
    private int damagePlayer;
    public GameObject heal;
    private Rigidbody rb;

 
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null){
            player = playerObject.GetComponent<Player>();
        }
        curentHealt = maxHealt;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            damagePlayer = player.GetDamageWeapon();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Shooted(damagePlayer);
            Destroy(collision.gameObject);
        }
        
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
          Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
          rb.isKinematic = true;
        }
    }

    private void Shooted(int damage){
        curentHealt -= damage;
        
        if(curentHealt <=0){
            animator.SetTrigger("Death");
            GameObject spawnedHeal = Instantiate(heal, transform.position, Quaternion.identity);
            Destroy(gameObject, 5);
        }
        else{
            animator.SetTrigger("Damage");
            Debug.Log("Damage "+ damage);
        }
    }

}
