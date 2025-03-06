using UnityEngine;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    public void Play()
    {
        buttons.SetActive(!buttons.activeInHierarchy);
    }
  
    public void Exit()
    {
        Application.Quit();
    }


}
