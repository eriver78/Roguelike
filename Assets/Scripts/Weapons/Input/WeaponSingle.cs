using UnityEngine;

public class WeaponSingle : Weapon
{
    public override void Shoot()
    {
        if (!canShoot) return;
        if (ammo == 0) return;
        if (reloading)
        {
            StopCoroutine("EndReload");
            reloading = false;
        }
        Invoke(nameof(AllowShoot),delay);
        canShoot = false;
        audio.Play();
        ammo--;
        shotType.Shot(damage);

    }

    protected override bool Check()
    {
        return true;
    }

    protected override void StopShooting()
    {
        return;
    }
}
