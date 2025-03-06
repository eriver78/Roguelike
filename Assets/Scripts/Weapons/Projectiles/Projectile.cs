using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed;
    public void Launch(int damage, Transform front)
    {
        transform.position = front.position;
        Go();
    }

    public abstract void Go();

    protected abstract void OnCollisionEnter(Collision collision);

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().linearVelocity);
    }
}
