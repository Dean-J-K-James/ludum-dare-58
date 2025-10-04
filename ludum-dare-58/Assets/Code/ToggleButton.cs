using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject target; //

    public void OnPointerClick(PointerEventData eventData)
    {
        target.SetActive(!target.activeSelf);
    }
}
