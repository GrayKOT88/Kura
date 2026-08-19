using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public int saveChick;
    public int eatenChick;
    public int recordSaveChick;

    public void ResetData()
    {
        saveChick = 0;
        eatenChick = 0;        
    }
}
