/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
 * 
 */
public class UIBuildingButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon; //
    public TextMeshProUGUI title; //
    public Building building; //

    /**
     * 
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        BuildController.I.SetBuilding(building);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIBuildingButtonTooltip.I.Show(building.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIBuildingButtonTooltip.I.Hide();
    }
}
