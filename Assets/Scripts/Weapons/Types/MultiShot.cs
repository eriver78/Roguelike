using UnityEngine;

public class MultiShot : ShotType
{
    public int shots;
    public override Vector3 Shot( int damage)
    {
        for(int i = 0; i < shots; i++)
        {
            RaycastHit hit;
            if (!Physics.Raycast(Camera.main.transform.position, GetSpread(Camera.main.transform.forward), out hit, 999)) continue;
            if (hit.collider.gameObject.TryGetComponent<Damageable>(out Damageable d))
            {

            }
            else
            {
                Instantiate(obstacle, hit.point, Quaternion.identity);
            }
        }
        return Vector3.zero;
    }
}
   
