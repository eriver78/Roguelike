using UnityEngine;

public class RayShot : SingleShot
{
    public override Vector3 Shot(int damage)
    {
       Vector3 point = base.Shot( damage);
        //
        return point;
    }
}
