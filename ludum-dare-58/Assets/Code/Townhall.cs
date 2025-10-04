/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class Townhall : MonoBehaviour
{
    /**
     * 
     */
    void Start()
    {
        ResourceManager.I.ChangeTownhall(1);
    }

    void OnDestroy()
    {
        ResourceManager.I.ChangeHousing(-1);
    }
}
