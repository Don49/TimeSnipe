using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletInteraction : MonoBehaviour
{
    public abstract void OnHit(RaycastHit hit);

}
