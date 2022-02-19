using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHit : BulletInteraction
{
    // Start is called before the first frame update
    //public EnemyRagdoll enemyRagdoll;
    // public EnemyShoot enemyShoot;
    public GameObject particalPre;
   // public EnemyShoot enemyShoot;
    public override void OnHit(RaycastHit hit)
    {

        GameObject particle = Instantiate(particalPre, hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);
        ParticleSystem particalSystem = particle.GetComponent<ParticleSystem>();
        MeshRenderer render = GetComponent<MeshRenderer>();
        if(particalSystem && render)
        {
            GameObject bullet = GameObject.FindGameObjectWithTag("bullet");
            bullet.GetComponent<TrailRenderer>().enabled = false;
            particalSystem.startColor = render.material.color;

        }

        //enemyShoot.setAliveFalse();
      //  enemyRagdoll.EnableRagdoll();
        //enemyShoot.enabled = false;
        Destroy(particalSystem, 1);
    }
}
