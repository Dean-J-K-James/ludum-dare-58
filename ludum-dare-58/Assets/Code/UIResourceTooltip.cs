/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using TMPro;
using UnityEngine;

/**
 * 
 */
public class UIResourceTooltip : Singleton<UIResourceTooltip>
{
    public GameObject parent; //
    public TextMeshProUGUI tooltip; //

    public void Show(string text)
    {
        parent.gameObject.SetActive(true);
        tooltip.text = text;
    }

    public void Hide()
    {
        parent.gameObject.SetActive(false);
    }
}
