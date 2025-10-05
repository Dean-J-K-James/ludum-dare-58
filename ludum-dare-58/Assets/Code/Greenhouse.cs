/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

/**
 * 
 */
public class Greenhouse : ResourceProducer
{
    public int amount; //

    /**
     * 
     */
    protected override void Produce()
    {
        PopupManager.I.CreatePopup(transform.position.x, transform.position.y + 0.5f, "+[" + amount + "]");
        ResourceManager.I.ChangeFood(amount);
    }
}
