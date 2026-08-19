using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters;
    private int index;
    private void Start()
    {
        index = PlayerPrefs.GetInt("SelectPlayer");
        // Получаем все дочерние объекты, кроме первого (индекс 0)
        characters = new GameObject[transform.childCount - 1];
        for(int i = 1; i < transform.childCount; i++)
        {
            characters[i - 1] = transform.GetChild(i).gameObject;            
        }
        foreach(GameObject go in characters)  // Отключаем все модели
        {
            go.SetActive(false);
        }
        // Включаем выбранную модель (если индекс в допустимых границах)
        if (index >= 0 && index < characters.Length)
        {
            characters[index].SetActive(true);
        }
        else // Если индекс некорректный, выбираем первую модель (индекс 0)
        {            
            index = 0;
            characters[index].SetActive(true);
        }
    }
    public void SelectLeft()
    {
        characters[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characters.Length - 1;
        }
        characters[index].SetActive(true);
    }
    public void SelectRight()
    {
        characters[index].SetActive(false);
        index++;
        if (index >= characters.Length) 
        {
            index = 0;
        }
        characters[index].SetActive(true);
    }
    public void startScene()
    {
        PlayerPrefs.SetInt("SelectPlayer", index);
        SceneManager.LoadScene(1);
    }
}