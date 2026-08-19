using UnityEngine;
using Zenject;

public class AchievementManager : MonoBehaviour
{
    [Inject(Id = "Gold")] private GameObject _gold;
    [Inject(Id = "Silver")] private GameObject _silver;
    [Inject(Id = "Bronze")] private GameObject _bronze;
    [Inject] private AnimalSettings _settings;

    public void UpdateMedals(int savedChickens)
    {
        _gold.SetActive(false);
        _silver.SetActive(false);
        _bronze.SetActive(false);

        if (savedChickens >= _settings.Gold)
        {
            _gold.SetActive(true);
        }
        else if (savedChickens >= _settings.Silver)
        {
            _silver.SetActive(true);
        }
        else if (savedChickens >= _settings.Bronze)
        {
            _bronze.SetActive(true);
        }
    }
}