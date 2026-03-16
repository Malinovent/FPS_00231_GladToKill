using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//Interface qui exist deja
public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private UnityEvent onClickEvent;

    [SerializeField] private Image image;
    [SerializeField] private Color hoverEnterColor;

    //Quand
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverEnterColor;
    }

    //Quoi
    private void OnClick()
    {
        onClickEvent?.Invoke();
    }
}