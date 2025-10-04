/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T I { get; private set; } //

    /**
     * 
     */
    void Awake()
    {
        I = this as T;
    }
}