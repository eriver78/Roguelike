using System.Collections;
using UnityEngine;

public class WeaponCharged : Weapon
{
    public float chargeTime;
    private bool charging;

    public override void Shoot()
    {
        Invoke(nameof(AllowShoot), delay);
        canShoot = false;
        audio.Play();
        ammo--;
        shotType.Shot(damage);   
        charging = false;
    }

    public virtual void Stop()
    {
        charging = false;
        StopCoroutine("Delay");
    }

    public virtual void Charge()
    {
        if (ammo == 0) return;
        if (reloading)
        {
            StopCoroutine("EndReload");
            reloading = false;
        }
        if (!canShoot) return;
        charging = true;
        StartCoroutine("Delay");
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(chargeTime);
        charging = false;
        Shoot();
    }

    protected override bool Check()
    {
        return !charging;
    }

    protected override void StopShooting()
    {
        Stop();
    }
}

