using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITakeDamage : MonoBehaviour
{
    private int maxHealt = 100;
    private int curentHealt;
    
    void Start()
    {
        curentHealt = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(50);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage){
        curentHealt -= damage;
        
        if(curentHealt <=0){
            Destroy(gameObject, 5);
        }
    }
}
