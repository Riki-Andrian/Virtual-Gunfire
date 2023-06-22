using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject missShoot;
    public GameObject bloodSplash;
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
        ContactPoint contact = collision.contacts[0];
        Vector3 collisionPosition = contact.point;
        Quaternion collisionRotation = Quaternion.LookRotation(contact.normal);
        Quaternion bloodRotation = Quaternion.FromToRotation(Vector3.forward, contact.normal);
        
        if(!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Player"))
        {
            //FxMissShoot.transform.position = collisionPosition + collision.relativeVelocity.normalized * 0.1f;
            GameObject FxMissShoot = Instantiate(missShoot, collisionPosition, collisionRotation);
            Destroy(FxMissShoot,2); 
        }
        else
        {
            GameObject Blood = Instantiate(bloodSplash, collisionPosition, bloodRotation);
            Destroy(Blood, 1);

        }
        Destroy(gameObject);
    }
}
