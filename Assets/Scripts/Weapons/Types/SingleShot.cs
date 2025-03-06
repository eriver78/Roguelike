using UnityEngine;

public class SingleShot : ShotType
{
    public override Vector3 Shot( int damage)
    {
        RaycastHit hit;
        if (!Physics.Raycast(Camera.main.transform.position, GetSpread(Camera.main.transform.forward), out hit, 999)) return Vector3.zero;
        if (hit.collider.gameObject.TryGetComponent<Damageable>(out Damageable d))
        {
            
        }
        else
        {
         //   Instantiate(obstacle, hit.point, Quaternion.identity);
        }
        return hit.point;

    }
}
