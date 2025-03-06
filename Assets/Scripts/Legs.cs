using UnityEngine;

public class Legs : MonoBehaviour
{

    [SerializeField] FirstPersonController player;
    private void OnTriggerEnter(Collider other)
    {
        player.Ground();
    }

    private void OnTriggerExit(Collider other)
    {
        player.SlideOut();
    }
}
