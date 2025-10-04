/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class ResourceProducer : MonoBehaviour
{
    //public ResourceEnum resourceType;
    //public int amount;
    public float interval;
    private float timer;

    /**
     * 
     */
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            Produce();
        }
    }

    protected virtual void Produce()
    {

    }
}
