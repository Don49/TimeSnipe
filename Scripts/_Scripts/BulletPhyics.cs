using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class BulletPhyics : MonoBehaviour
{
    private Vector2 wind;
    private float speed;
    private float gravity;
    private Vector3 initialPosition;
    private Vector3 direction;

    private bool hasBulletBeenRequested;
    private float bulletStartTime = -1; // must initially be less that 0

   
    public void bulletInitialProperties(Transform startPositon, float bulletSpeed, float gravity, Vector2 wind)
    {
       
        initialPosition = startPositon.position;
        direction = startPositon.forward;
        speed = bulletSpeed;
        this.gravity = gravity;
        this.wind = wind;
        hasBulletBeenRequested = true;
        bulletStartTime = -1f;
    }

    public void FixedUpdate()
    {
        if (!hasBulletBeenRequested) return;
        

        if(bulletStartTime < 0)// get bullet start time
        {
            bulletStartTime = Time.time;
           // Debug.Log("the time is " + bulletStartTime);
        }

        RaycastHit hit;
        float currentTime = Time.time - bulletStartTime; // current time
        float nextPointTime = currentTime + Time.fixedDeltaTime; // time for the position where the bullet should be next

        Vector3 currentPosition = FindBulletDropPositionAtTime(currentTime);
        Vector3 nextPosition = FindBulletDropPositionAtTime(nextPointTime);

       // Debug.Log("bulletstart time is " + bulletStartTime);
       // Debug.Log("delta time is " + Time.time);

       // Debug.Log("current time is " + currentTime);
       // Debug.Log("next time is " + nextPointTime);

        if (detectHitBetweenPoints(currentPosition, nextPosition, out hit))// detect hit between the current and next point
        {
           Debug.Log( hit.collider.gameObject.name);
            //Destroy(gameObject); // destroys bullet
            if (hit.collider.gameObject.tag == "menuTarget")
            {
                Debug.Log("We are facing the door.");
               // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));
                Application.LoadLevel(1);
            }


            if (hit.collider.gameObject.tag == "enemy")
            {

                Debug.Log("Enemy down");
                EnemyRagdoll ragdollscript = gameObject.GetComponent<EnemyRagdoll>();

                ragdollscript.EnableRagdoll();
            }

           


           if(hit.collider.gameObject.tag == "environment")
            {
                Destroy(this);
            }

            BulletInteraction hasHit = hit.transform.GetComponent<BulletInteraction>();
            

            Debug.Log("has gih  " + hasHit);

           if(hasHit)
            {
                hasHit.OnHit(hit);

               // EnemyShoot es = GetComponent<EnemyShoot>();
               // Debug.Log("es is " + es.name);
              //  es.enabled = false;
               // hit.transform.GetComponent<EnemyShoot>().enabled = false;

               /* if (bulletScript)
                {
                    bulletScript.setAliveFalse() ;
                }
                Debug.Log("im hit");*/
                
            }
               
            

        }

    }

   /* internal void bulletInitialProperties(Vector3 localPosition, int v1, int v2)
    {
        throw new NotImplementedException();
    }
*/
    /*public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            Debug.Log("other " + other);
            EnemyRagdoll ragdollscript = other.GetComponent<EnemyRagdoll>();

            ragdollscript.EnableRagdoll();
        }
    }*/

    public void Update()
    {
       if (!hasBulletBeenRequested || bulletStartTime < 0) return;// bullet validation
       
        float currentTime = Time.time - bulletStartTime;
        //float nextPointTime = currentTime + Time.deltaTime;
        Vector3 currentPosition = FindBulletDropPositionAtTime(currentTime);
        transform.position = currentPosition;//////////////

    }

    public Vector3 FindBulletDropPositionAtTime(float time) 
    {
      //   Vector3 currentPosition = initialPosition  + (direction * speed * time); // find position of bullet at current time
        Vector3 movementVec = (direction * time* speed);
        Vector3 windVec = new Vector3(wind.x, 0 , wind.y) * time* time; // impact of wind on bullet
        Vector3 gravityImpact = Vector3.down * gravity * time * time; // impact of gravity on bullet at above position
        
      //  return currentPosition + gravityImpact + movementVec + windVec; // return position of bullet at time with effect of gravity and wind
        return initialPosition + gravityImpact + movementVec + windVec; // return position of bullet at time with effect of gravity
    }

    public bool detectHitBetweenPoints(Vector3 firstPoint, Vector3 secondPoint, out RaycastHit hit)
    {
        bool hasHit = Physics.Raycast(firstPoint, secondPoint - firstPoint, out hit, (secondPoint - firstPoint).magnitude);// Checks if between the two given points the raycast intersects with anything. magnitude needed so its max distance is known
      //  Debug.Log("should have hit swat " + hasHit);
        return hasHit;
    }

}
