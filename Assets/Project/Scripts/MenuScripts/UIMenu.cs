using TMPro;
using UnityEngine;
using Zenject;

public class UIMenu : MonoBehaviour
{    
    [Inject(Id = "ChickCountText")] private TextMeshProUGUI _chickCountText;
    [Inject(Id = "FoxCountText")] private TextMeshProUGUI _foxCountText;
    [Inject(Id = "RecordCountText")] private TextMeshProUGUI _recordCountText;
    [Inject(Id = "GoldMedal")] private GameObject _goldMedal;
    [Inject(Id = "SilverMedal")] private GameObject _silverMedal;
    [Inject(Id = "BronzeMedal")] private GameObject _bronzeMedal;
    [Inject] private AnimalSettings _settings;

    void Start()
    {
        CountText();
        Medal();
    }
    void Medal()
    {
        _goldMedal.SetActive(false);
        _silverMedal.SetActive(false);
        _bronzeMedal.SetActive(false);
        if (Progress.PlayerData.saveChick >= _settings.Bronze)
        {
            _bronzeMedal.SetActive(true);
        }
        if (Progress.PlayerData.saveChick >= _settings.Silver)
        {
            _bronzeMedal.SetActive(false);
            _silverMedal.SetActive(true);
        }
        if (Progress.PlayerData.saveChick >= _settings.Gold)
        {
            _silverMedal.SetActive(false);
            _goldMedal.SetActive(true);
        }
    }
    void CountText()
    {
        _chickCountText.text = " " + Progress.PlayerData.saveChick;
        _foxCountText.text = " " + Progress.PlayerData.eatenChick;
        _recordCountText.text = " " + Progress.PlayerData.recordSaveChick;
    }
}