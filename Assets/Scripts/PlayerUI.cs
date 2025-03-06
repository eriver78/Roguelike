using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] PlayerHand hand;
    [SerializeField] TextMeshProUGUI AmmoText,wname;
    [SerializeField] Image picture;
    

    
    void Update()
    {
        AmmoText.text = hand.GetCurrentWeapon().ammo+"/"+ hand.GetCurrentWeapon().reserve;
        picture.sprite = hand.GetCurrentWeapon().sprite;
        wname.text = hand.GetCurrentWeapon().wname;
    }
}
