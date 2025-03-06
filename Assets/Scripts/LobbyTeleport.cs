using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyTeleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine("V");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StopCoroutine("V");
        }
    }



    public IEnumerator V()
    {

        yield return new WaitForSeconds(3);
        int n = Random.Range(1,4);
        SceneManager.LoadScene($"Map{n}");
    }
}
