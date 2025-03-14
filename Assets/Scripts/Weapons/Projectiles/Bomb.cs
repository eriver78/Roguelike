using UnityEngine;

public class Bomb : Projectile
{
    public override void Go()
    {
        GetComponent<Rigidbody>().linearVelocity = Camera.main.transform.forward * speed;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
