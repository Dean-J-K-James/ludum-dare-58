/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class House : MonoBehaviour
{
    /**
     * 
     */
    void Start()
    {
        ResourceManager.I.ChangeHousing(+4);
    }

    void OnDestroy()
    {
        ResourceManager.I.ChangeHousing(-4);
    }
}
