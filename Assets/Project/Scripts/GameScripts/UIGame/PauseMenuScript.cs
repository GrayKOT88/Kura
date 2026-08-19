using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseGameMenu;
    [SerializeField] private GameObject _rateGameButton;

    public void RateGameButton()
    {
        YandexGame.ReviewShow(true);
    }
    public void Resume()
    {
        _pauseGameMenu.SetActive(false);
        Time.timeScale = 1;        
    }
    public void Pause()
    {
        _pauseGameMenu.SetActive(true);
        Time.timeScale = 0;        
    }
    public void LosdMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }    
}