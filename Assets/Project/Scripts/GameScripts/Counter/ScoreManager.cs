using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    [Inject(Id = "CounterText")] private TextMeshProUGUI _ñounterText;
    [Inject(Id = "CounterTextFox")] private TextMeshProUGUI _ñounterTextFox;
    private int _countChickens;
    private int _countFoxes;

    public int CountChickens => _countChickens;
    public int CountFoxes => _countFoxes;

    public void AddChickens(int value)
    {
        _countChickens += value;
        _ñounterText.text = " " + _countChickens;
        _ñounterText.transform.DOKill(); // Îñòàíàâëèâàåì òåêóùóş àíèìàöèş
        _ñounterText.transform.localScale = Vector3.one; // Ñáğàñûâàåì ìàñøòàá íà 1,1,1
        _ñounterText.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
    }

    public void AddFoxes(int value)
    {
        _countFoxes += value;
        _ñounterTextFox.text = " " + _countFoxes;
        _ñounterTextFox.transform.DOKill(); 
        _ñounterTextFox.transform.localScale = Vector3.one;
        _ñounterTextFox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
    }

    public void ResetScores()
    {
        _countChickens = 0;
        _countFoxes = 0;
        _ñounterText.text = " 0";
        _ñounterTextFox.text = " 0";
    }
}
