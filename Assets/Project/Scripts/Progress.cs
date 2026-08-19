using UnityEngine;
using YG;

public class Progress
{
    private static PlayerDataSO _playerData;
    public static PlayerDataSO PlayerData
    {
        get
        {
            if (_playerData == null)
                LoadData();
            return _playerData;
        }
        set => _playerData = value;
    }
    public static void SaveData()
    {
        YandexGame.savesData.saveChick = _playerData.saveChick;
        YandexGame.savesData.eatenChick = _playerData.eatenChick;
        YandexGame.savesData.recordSaveChick = _playerData.recordSaveChick;
        YandexGame.SaveProgress();       
    }
    public static void LoadData()
    {
        if (_playerData == null)
        {
            _playerData = Resources.Load<PlayerDataSO>("PlayerData");
        }
        _playerData.saveChick = YandexGame.savesData.saveChick;
        _playerData.eatenChick = YandexGame.savesData.eatenChick;
        _playerData.recordSaveChick = YandexGame.savesData.recordSaveChick;
    }    
}