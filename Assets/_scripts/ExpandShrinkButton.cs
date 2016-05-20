using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ExpandShrinkButton : MonoBehaviour,
    IPointerClickHandler
{
    
    public Sprite ExpandSprite;
    public Sprite ShrinkSprite;

    public UnityEvent OnExpandClick = new UnityEvent();
    public UnityEvent OnShrinkClick = new UnityEvent();

    private enum Button_State { EXPAND, SHRINK}

    private Image _buttonImage;

    private Button_State _currentButtonState = Button_State.SHRINK;

    private void Start()
    {
        Debug.Assert(ExpandSprite != null, "Expand sprite not set in editor.");
        Debug.Assert(ShrinkSprite != null, "Shrink sprite not set in editor.");
        _buttonImage = GetComponent<Image>();
        //default to Expand
        _buttonImage.sprite = ShrinkSprite;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.IsCameraZooming)
        {
            return;
        }
        FlipButtonState();
    }

    private void FlipButtonState()
    {
        if (_currentButtonState == Button_State.EXPAND)
        {
            _buttonImage.sprite = ShrinkSprite;
            _currentButtonState = Button_State.SHRINK;
            OnExpandClick.Invoke();
        }
        else
        {
            _buttonImage.sprite = ExpandSprite;
            _currentButtonState = Button_State.EXPAND;
            OnShrinkClick.Invoke();
        }
    }
}
