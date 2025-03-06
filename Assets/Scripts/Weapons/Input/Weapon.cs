using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{
    public string wname;
    public int damage;
    public float reloadTime;
    public int magsize;
    public float delay;
    public Sprite sprite;
    [HideInInspector] public int ammo;
    public ShotType shotType;
    public bool reloading, canShoot = true, hasSpread;
    public AudioSource audio;
    public float recoil;
    public int mags;
    [HideInInspector]public int reserve;
    public Animator anim;
    public void Reload()
    {        
        if (reloading) return;
        if (ammo == magsize) return;        
        if (reserve == 0) return;       
        if (!Check()) return;       
        anim.Play("Reload");
        reloading = true;
        StopShooting();
        StartCoroutine("EndReload");
    }

    public void Disable()
    {
        reloading = false;
        StopShooting() ;
        StopCoroutine("EndReload");
        gameObject.SetActive(false);
    }

    protected abstract bool Check();

    protected abstract void StopShooting();



    private IEnumerator EndReload()
    {
        yield return new WaitForSeconds(reloadTime);
        int n = magsize - ammo;
        if (n <= reserve)
        {
            reserve -= n;
            ammo += n;
        }
        else
        {
            ammo += reserve;
            reserve = 0;
        }
        reloading = false;
    }

    public abstract void Shoot();

    public void AllowShoot()
    {
        canShoot = true;
    }

    private void Start()
    {
        ammo = magsize;
        reserve = magsize * mags;

    }
}
