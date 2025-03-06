using System;

[Serializable]
public class SaveData 
{  
    public int level = 1 ; 
    public int skillPoints = 0;
    public int money = 0;
    public long saveDate = DateTime.Now.ToBinary();
    public string scene = "lobby";
}
