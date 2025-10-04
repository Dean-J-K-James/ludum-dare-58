/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * 
 */
public class UIResource : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI value; //
    //public TextMeshProUGUI change; //
    public string description; //

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIResourceTooltip.I.Show(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIResourceTooltip.I.Hide();
    }
}
