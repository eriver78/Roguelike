using System.Collections;
using UnityEngine;

public class WeaponAuto : Weapon
{
    private bool shooting;
    public override void Shoot()
    {
        if (!canShoot) return;
        if (ammo == 0) return;
        if (reloading)
        {
            StopCoroutine("EndReload");
            reloading = false;
        }
        StartCoroutine("Cycle");
    }

    private IEnumerator Cycle()
    {
        shooting = true;
        while (ammo > 0)
        {
            canShoot = true;
            audio.Play();
            ammo--;
            shotType.Shot(damage);
            canShoot = false;
            yield return new WaitForSeconds(delay);
        }
        canShoot = true;
        shooting = false;
        
    }

    public void Stop()
    {
        shooting = false;
        StopCoroutine("Cycle");
        canShoot = true;
    }

    protected override bool Check()
    {
        return true;
    }

    protected override void StopShooting()
    {
        Stop();
    }
}
