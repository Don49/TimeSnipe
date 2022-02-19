using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    Rigidbody myRb;
    public float movementVal;
    private int waitTime;

   // private Vector3 newLocation;
   IEnumerator Start()
    {

        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach( Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
            rb.useGravity = false;
                }


        Collider[] colls = GetComponentsInChildren<Collider>();
        foreach (Collider col in colls)
        {
            col.enabled = false;
        }

        anim = GetComponent<Animator>();
       // Debug.Log("adsasdasd " + anim);

        EnemyShoot shootScript = GetComponent<EnemyShoot>();


        while(true)
        {
            waitTime = Random.Range(3, 10);
           /* if(newLocation != null)
            {
                transform.position = newLocation;
            }*/
            yield return new WaitForSeconds(waitTime);


            

            if (shootScript)
            {
                shootScript.shootPlayer();
            }

            int num = Random.Range(0, 4);

            anim.SetInteger("MoveType", num);
            anim.SetTrigger("Move");
            yield return new WaitForSeconds(0.5f);

            myRb = GetComponent<Rigidbody>();
            if (num == 0)
            {
              //  Debug.Log("sdfdsf");
               
                myRb.AddForce(Vector3.back * movementVal , ForceMode.Acceleration);
                // myRb.AddForce(-transform.forward * 10000f * Time.deltaTime);
            }
            else if (num == 1)
            {
              
                myRb.AddForce(Vector3.left * movementVal, ForceMode.Acceleration);
            }
            else if (num == 2)
            {
              
                myRb.AddForce(Vector3.right * movementVal, ForceMode.Acceleration);
            }
                
            else if (num == 3)
            {
               
                myRb.AddForce(Vector3.forward * movementVal, ForceMode.Acceleration);
            }
               
            //  myRb.AddForce(transform.forward * 10000f * Time.deltaTime);



            //newLocation = transform.position;



        }
    }
}
