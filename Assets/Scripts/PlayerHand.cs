using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHand : MonoBehaviour
{
    private int index = 0;
    public Weapon[] weapons;
    private void Start() { }
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (weapons[index] is not WeaponCharged wc) weapons[index].Shoot();
            else wc.Charge();
        }

        if (context.canceled)
        {
            if (weapons[index] is WeaponCharged wc) wc.Stop();
            if (weapons[index] is WeaponAuto wa) wa.Stop();

        }
    }

    public Weapon GetCurrentWeapon()
    {
        return weapons[index];
    }
    public void ScrollChange(InputAction.CallbackContext context)
    {
        weapons[index].gameObject.SetActive(false);
        index += (int)context.ReadValue<float>();
        if (index < 0) index = 2;
        if (index > 2) index = 0;
        weapons[index].gameObject.SetActive(true);
    }

    public void NumberChange(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        int i = int.Parse(context.control.name)-1;
        if (i == index) return;
        weapons[index].Disable();        
        index = i;
        weapons[index].gameObject.SetActive(true);
       
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (!context.started) return;       
        weapons[index].Reload();        
    }

    


}
