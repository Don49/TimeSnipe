using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update

        public Transform weaponIdle;
        public Transform weaponADS;
        public float aimTime;

    public Transform bulletSpawnPoint;
    public GameObject bulletObj;
    public GameObject fpsController;

    private Animator anim;
    private Animator animcam;

    public AudioSource fireWeapon;
    public AudioSource reloadWeapon;

    public float projectileVelocity;
        public float gravityOfBullet;
        public float totalBulletTravelTime;
    
    private float timeTetweenShot = 1f;
    private float nextShotTime = 0f;

    public Wind windScript;
        

    void Start()
    {
        GameObject sniper = GameObject.FindGameObjectWithTag("SniperRifle");
        GameObject snipercam = GameObject.FindGameObjectWithTag("SniperRifleCamera");
        anim = sniper.GetComponent<Animator>();
        animcam = snipercam.GetComponent<Animator>();

       // AudioSource fireWeapon = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
      
        
        if(!GameController.isPaused)
        {
            if (Input.GetMouseButton(1))
            {
                transform.localPosition = Vector3.Slerp(transform.localPosition, weaponADS.localPosition, aimTime * Time.deltaTime);
                FirstPersonController fpsC = fpsController.GetComponent<FirstPersonController>();
                if (fpsC)
                {
                    fpsC.setAdsSens(0.3f);
                }

            }
            if (Input.GetMouseButtonUp(1))
            {
                //   transform.localPosition = Vector3.Lerp(transform.localPosition, weaponIdle.localPosition, aimTime * Time.deltaTime);
                transform.localPosition = weaponIdle.localPosition;

                FirstPersonController fpsC = fpsController.GetComponent<FirstPersonController>();
                if (fpsC)
                {
                    fpsC.setNormalSens(2f);
                }


            }

            if (Time.time > nextShotTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Shoot");
                    animcam.SetTrigger("Shoot");
                    Shoot();
                    fireWeapon.Play();
                    reloadWeapon.PlayDelayed(0.25f);
                    nextShotTime = Time.time + timeTetweenShot;
                }
            }
        }
      
            


    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletPhyics bulletScript = bullet.GetComponent<BulletPhyics>();

        if(bulletScript)
        {
            bulletScript.bulletInitialProperties(bulletSpawnPoint, projectileVelocity, gravityOfBullet, windScript.GetWind());
        }

        Destroy(bullet, totalBulletTravelTime);
    }


}
