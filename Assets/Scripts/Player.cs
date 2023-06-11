using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int maxHealt = 100;
    private int curentHealt;
    private int damageWeapon = 20;
    public bool hasPowerBullet;
    // Start is called before the first frame update
    void Start()
    {
        curentHealt = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetDamageWeapon(){
        if(hasPowerBullet){
            return 50;
        }
        else{
        return damageWeapon;
        }
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUpBullet")){
            hasPowerBullet = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());

        }
        else if(other.CompareTag("Heal"))
        {
            if(curentHealt < maxHealt)
            {
                curentHealt += 20;
                if(curentHealt >= 100)
                {
                    curentHealt = maxHealt;
                }
            } 
            Debug.Log("CurentHP "+ curentHealt);
            Destroy(other.gameObject);
        }
    }
    IEnumerator PowerUpCountdownRoutine() {
        yield return new WaitForSeconds(20); 
        hasPowerBullet = false; 
    }
}
