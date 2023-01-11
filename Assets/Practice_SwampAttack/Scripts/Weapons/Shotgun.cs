using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Vector3 spreading = new Vector3(Random.Range(0f, 0.5f), 0, 0);
        Instantiate(Bullet, shootPoint.position - spreading, Quaternion.identity, shootPoint);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity, shootPoint);
    }
}
