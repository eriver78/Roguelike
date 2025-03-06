using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI save1, save2, save3;
    [SerializeField] Animator anim;
    
    void Start()
    {
        if (File.Exists(Application.dataPath + "/save1.json"))
        {
            SaveData data1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.dataPath + "/save1.json"));
            save1.text = DateTime.FromBinary(data1.saveDate).ToString();
        }
        if (File.Exists(Application.dataPath + "/save2.json"))
        {
            SaveData data2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.dataPath + "/save2.json"));
            save2.text = DateTime.FromBinary(data2.saveDate).ToString();
        }
        if (File.Exists(Application.dataPath + "/save3.json"))
        {
            SaveData data3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.dataPath + "/save3.json"));
            save3.text = DateTime.FromBinary(data3.saveDate).ToString();
        }
    }    
    public void Play(int slot)
    {

        PlayerPrefs.SetInt("save", slot);
        PlayerPrefs.Save();
        if (!File.Exists(Application.dataPath + $"/save{slot}.json"))
        {
            SaveData data= new SaveData();
            File.Create(Application.dataPath + $"/save{slot}.json").Close();
            File.WriteAllText(Application.dataPath + $"/save{slot}.json", JsonUtility.ToJson(data, true));
        }
        anim.Play("Unfade");
        Destroy(gameObject);        
    }
}
