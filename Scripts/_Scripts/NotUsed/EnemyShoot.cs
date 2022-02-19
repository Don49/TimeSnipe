using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Transform player;
    public GameObject bulletPref;

    public float shootVelocity;
    public float shootUpThrust;
    //private bool alive;
    public Transform shootPoint;
  



 IEnumerator Start()
    {
        while(true)
        {
        int randTime = Random.Range(3, 10);
        yield return new WaitForSeconds(randTime);
        shootPlayer();
        }



    }

    public void shootPlayer()
    {
        transform.LookAt(player);

        Rigidbody rb = Instantiate(bulletPref, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootVelocity, ForceMode.Impulse);
        rb.AddForce(transform.forward * shootUpThrust, ForceMode.Impulse);
      //  //Vector3 offset = new Vector3(-1, 2, -2);
       // Vector3 newoffset = transform.position + offset;

        /*GameObject bullet = Instantiate(bulletPref, shootPoint.position, Quaternion.identity);
        BulletPhyics bulletScript = bullet.GetComponent<BulletPhyics>();

        

       // Debug.Log("trans " + transform.position + " offset" + newoffset);

        if (bulletScript)
        {
            bulletScript.bulletInitialProperties(shootPoint, 1500, -1);
        }

        Destroy(bullet, 10);*/



    }

}
