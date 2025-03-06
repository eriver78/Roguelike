using UnityEngine;

public abstract class ShotType : MonoBehaviour
{
    public ParticleSystem obstacle;
    public float spread;
    

    public abstract Vector3 Shot(int damage);
    public Vector3 GetSpread(Vector3 direction)
    {
        return direction;

    }
}
