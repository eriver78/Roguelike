using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtons : MonoBehaviour
{
    [SerializeField] Button cont;
    private SaveData data;

    private void OnEnable()
    {
        data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.dataPath + "/save"+PlayerPrefs.GetInt("save")+".json"));      
        cont.interactable = data.scene != "lobby";       

    }

    public void NewRun()
    {
        SceneManager.LoadScene("lobby");
    }

    public void Continue()
    {
        SceneManager.LoadScene(data.scene);
    }
}
