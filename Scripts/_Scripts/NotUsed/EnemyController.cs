using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRagdoll rg = this.GetComponent<EnemyRagdoll>();
        EnemyShoot es = this.GetComponent<EnemyShoot>();

        Debug.Log("en shgoot + " + es.name);

        while (alive == true)
        {
            StartCoroutine(waitTime());
            es.shootPlayer();

            bool ded = rg.getDead();
            Debug.Log("ded = " + ded);
            if (ded == true)
            {
                // es.setAliveFalse();
                alive = false;

                this.GetComponent<EnemyShoot>().enabled = false;
              
            }

        }
        

    }

    IEnumerator waitTime()
    {
        int randTime = Random.Range(3, 10);
        yield return new WaitForSeconds(randTime);
    }

}
