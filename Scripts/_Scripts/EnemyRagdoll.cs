using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour {

    private Rigidbody[] rigids;
    private Animator anim;
   // private GameObject parent;
    private bool isdead = false;

    void Start()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();

      

    Debug.Log("amin is " + anim);
    Debug.Log("rigids is " + rigids);

        //EnableRagdoll();
        //DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        Debug.Log("im enalbed");
        isdead = true;
        anim.enabled = false;

        Destroy(this.gameObject, 3);

        GameObject gc = GameObject.FindGameObjectWithTag("GameController");

        gc.GetComponent<GameController>().AddScore(1);
        gc.GetComponent<GameController>().AddTime(3);

        //this.GetComponent<EnemyShoot>().enabled = false;
       
        //Destroy(parent);
        foreach (Rigidbody rig in rigids)
        {
            Debug.Log("rifg is " + rig);
            rig.useGravity = true;
           
        }
    }



    public bool getDead()
    {
        return isdead;
    }

    public void DisableRagdoll()
    {
        anim.enabled = true;
        foreach (Rigidbody rig in rigids)
        {
            rig.useGravity = false;
        }
    }
}
