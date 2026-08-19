using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _originalScale;
    private Tween _pulseTween;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pulseTween?.Kill();
        _pulseTween = transform.DOPunchScale(_originalScale * 0.5f, 0.5f, 1, 0.5f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.InOutQuad);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pulseTween?.Kill();
        transform.localScale = _originalScale;
    }

    private void OnDestroy()
    {
        _pulseTween?.Kill();
    }
}