/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public class UIBuildingList : MonoBehaviour
{
    public UIBuildingButton prefab;
    public Building[] buildings;

    List<UIBuildingButton> buttons = new();

    /**
     * 
     */
    void Start()
    {
        foreach (var building in buildings)
        {
            var btn = Instantiate(prefab, transform);

            btn.building = building;
            btn.title.text = building.title;
            btn.icon.sprite = building.icon;

            buttons.Add(btn);
        }
    }

    void Update()
    {
        foreach (var button in buttons)
        {
            var valid = button.building.GetComponent<BuildingValidator>().IsValid();

            button.State(valid);
        }
    }
}
