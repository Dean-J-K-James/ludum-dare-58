/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

/**
 * 
 */
public class Greenhouse : ResourceProducer
{
    /**
     * 
     */
    protected override void Produce()
    {
        PopupManager.I.CreatePopup(transform.position.x, transform.position.y + 0.5f, "+[1]");
        ResourceManager.I.ChangeFood(1);
    }
}
