using UnityEngine;

public class Uzi : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity, shootPoint);
    }
}
