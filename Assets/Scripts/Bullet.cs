using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject missShoot;
    // public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(!collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 collisionPosition = contact.point;
            Quaternion collisionRotation = Quaternion.LookRotation(contact.normal);

            //FxMissShoot.transform.position = collisionPosition + collision.relativeVelocity.normalized * 0.1f;

            GameObject FxMissShoot = Instantiate(missShoot, collisionPosition, collisionRotation);
            Destroy(FxMissShoot,2); 
        }
       

        Destroy(gameObject);
    }
}
