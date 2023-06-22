using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private int maxHealt = 100;
    private int curentHealt;
    private int damageWeapon = 20;
    public bool hasPowerBullet = false;
    private TakeDamage enemy;
    private int damageEnemy;
    public TextMeshProUGUI Hp;
    private int regen = 30;
    private AudioSource powerAudio;
    public Image uiImage;
    public TextMeshProUGUI sb;
    public TextMeshProUGUI lose;

    private SceneLoader scene;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if(enemyObject != null){
            enemy = enemyObject.GetComponent<TakeDamage>();
        }


        GameObject sceneObject = GameObject.Find("TransitionManager");
        if(sceneObject != null){
            scene = sceneObject.GetComponent<SceneLoader>();
        }


        curentHealt = maxHealt;

        lose.enabled = false;

        powerAudio =  GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            damageEnemy = enemy.GetDamageEnemy();
        }
        if(hasPowerBullet)
        {
            uiImage.enabled = true;
            sb.enabled = true; 
        }
        else if(!hasPowerBullet)
        {
            uiImage.enabled = false;
            sb.enabled = false;
        }
        if(curentHealt==0)
        {
            lose.enabled = true;
            scene.GoToScene(0);
        }
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
            powerAudio.Play();
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());

        }
        else if(other.CompareTag("Heal"))
        {
            if(curentHealt < maxHealt)
            {
                curentHealt += regen;
                if(curentHealt >= 100)
                {
                    curentHealt = maxHealt;
                }
                powerAudio.Play();
            } 
            Debug.Log("CurentHP "+ curentHealt);
            Destroy(other.gameObject);
            ChangeHp();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Shooted(damageEnemy);
            Destroy(collision.gameObject);
        }
        
        
    }
    IEnumerator PowerUpCountdownRoutine() {
        yield return new WaitForSeconds(10); 
        hasPowerBullet = false; 
    }

     private void Shooted(int damage){
        curentHealt -= damage;
        if(curentHealt == 0){
            //animator.SetTrigger("Death");
            //GameObject spawnedHeal = Instantiate(heal, transform.position, Quaternion.identity);
            //Destroy(gameObject, 5);
            Debug.Log("Kalah");
            ChangeHp();
        }
        else if(curentHealt > 0)
        {
            Debug.Log("HP : "+ curentHealt);
            Debug.Log("Damage "+ damage);
            ChangeHp();
        }
       
    }

    private void ChangeHp()
    {
        string originalHp = Hp.text;
        string[] values = originalHp.Split('/');

        if(values.Length == 2)
        {
            values[0] = curentHealt.ToString();
            string modifiedHp = values[0] + "/" + values[1];
            Hp.text = modifiedHp;
        }   
    }
}
