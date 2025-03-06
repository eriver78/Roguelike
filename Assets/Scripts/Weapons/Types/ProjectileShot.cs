using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ProjectileShot : ShotType
{
    [SerializeField] Projectile prefab;
    [SerializeField] Transform front;
    
    public override Vector3 Shot(int damage)

    {
        var p= Instantiate(prefab);
        p.Launch(damage,front);
        return Vector3.zero;
    }
}
    
