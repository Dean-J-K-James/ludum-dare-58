/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using TMPro;
using UnityEngine;

/**
 * 
 */
public class UIBuildingButtonTooltip : Singleton<UIBuildingButtonTooltip>
{
    public GameObject parent; //
    public TextMeshProUGUI tooltip; //
    public TextMeshProUGUI wood; //
    public TextMeshProUGUI taxes; //

    public void Show(Building building)
    {
        parent.gameObject.SetActive(true);
        tooltip.text = building.description;
        wood.text = "Required Wood: " + building.GetComponent<BuildingValidator>().requiredWood;
        taxes.text = "Required Taxes: " + building.GetComponent<BuildingValidator>().requiredTaxes;
    }

    public void Hide()
    {
        parent.gameObject.SetActive(false);
    }
}
