using UnityEngine;

public class WeaponDraw : WeaponCharged
{
    public float dx;
    private float time;
    private bool charging;

    public override void Shoot()
    { 
        if (!charging) return;
        Invoke(nameof(AllowShoot), delay);
        audio.Play();
        time = Mathf.Clamp(time, 0, chargeTime);
        float dm = time / chargeTime;
        ammo--;
        shotType.Shot( (int)(damage * (1 + dm * (dx - 1))));
        canShoot = false;
        time = 0;
        charging = false;
    }

    public override void Stop()
    {
        charging = false;
        Shoot();
    }

    public override void Charge()
    {
        if (ammo == 0) return;
        if (reloading)
        {
            StopCoroutine("EndReload");
            reloading = false;
        }
        if (!canShoot) return;
        charging = true;
    }

    private void Update()
    {
        if (charging) time += Time.deltaTime;
    }

    protected override bool Check()
    {
        return !charging;
    }

    protected override void StopShooting()
    {
        time = 0;
        charging = false;
    }

}
