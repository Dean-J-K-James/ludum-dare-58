/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class PopupManager : Singleton<PopupManager>
{
    public Popup prefab;

    public void CreatePopup(float x, float y, string message)
    {
        var e = Instantiate(prefab, transform);

        e.transform.position = new Vector3(x, y, -5);
        e.text.text = message;
    }
}
