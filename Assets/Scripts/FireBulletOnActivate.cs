using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public GameObject flash;
    public float fireSpeed = 20f;
    private AudioSource shootAudio;
    private float destroyMuzzle = 0.1f;
    private float flashOffset = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        shootAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
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

}
