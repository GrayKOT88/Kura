using UnityEngine;
using YG;

public class ScoreSaver : MonoBehaviour
{
    public void SaveScores(int savedChickens, int eatenChickens)
    {
        Progress.PlayerData.saveChick = savedChickens;
        Progress.PlayerData.eatenChick = eatenChickens;

        if (savedChickens > Progress.PlayerData.recordSaveChick)
        {
            Progress.PlayerData.recordSaveChick = savedChickens;
            YandexGame.NewLeaderboardScores("saveChick", savedChickens);
        }

        Progress.SaveData();
    }
}