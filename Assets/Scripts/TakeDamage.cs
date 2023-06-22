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
    public GameObject powerBullet;
    private Rigidbody rb;
    private float yOffset = 0.5f;

    //Atack
    public GameObject bullet;
    public Transform spawnPoint;
    public GameObject flash;
    public float fireSpeed = 20f;
    private AudioSource shootAudio;
    private float destroyMuzzle = 0.1f;
    private float flashOffset = 0.1f;
    public int damageEnemy = 20;

    public event System.Action<Enemy> OnDestroyed;

    private SpawnManager spawnManager;

 
    
    void Start()
    {
        //scrip player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null){
            player = playerObject.GetComponent<Player>();
        }

        GameObject spawnEnemy = GameObject.Find("SpawnManager");
        if(spawnEnemy != null)
        {
            spawnManager = spawnEnemy.GetComponent<SpawnManager>();
        }

        curentHealt = maxHealt;
        shootAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        
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
        
        if(curentHealt == 0){
            animator.SetTrigger("Death");
            int power = Random.Range(0, 2);
            if(power == 0){
                GameObject spawnedHeal = Instantiate(heal, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);
            }
            else if(power == 1){
                GameObject spawnedPower = Instantiate(powerBullet, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity); 
            }
            Destroy(gameObject, 2);
        }
        else{
            animator.SetTrigger("Damage");
            Debug.Log("Damage "+ damage);
        }
    }

    private void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;

        GameObject muzzleFlash = Instantiate(flash);
        Vector3 flashDirection = spawnPoint.transform.forward;
        Quaternion flashRotation = Quaternion.LookRotation(flashDirection, Vector3.up);

        muzzleFlash.transform.position = spawnPoint.position + spawnPoint.forward * flashOffset;
        muzzleFlash.transform.rotation = flashRotation;

        shootAudio.Play();
        Destroy(spawnedBullet,5);
        Destroy(muzzleFlash, destroyMuzzle);
    }

    public int GetDamageEnemy(){
        return damageEnemy;  
    }

     private void OnDestroy()
    {
        if(spawnManager != null)
        {
            spawnManager.EnemyDestroyed();
        }
    }

}
