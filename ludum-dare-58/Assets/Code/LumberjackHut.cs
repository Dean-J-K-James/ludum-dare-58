/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

/**
 * 
 */
public class LumberjackHut : ResourceProducer
{
    /**
     * 
     */
    protected override void Produce()
    {
        var x = GetComponent<Tile>().x;
        var y = GetComponent<Tile>().y;
        var wood = 0;

        for (int i = x - 1; i <= x + 1; i++)
            for (int j = y - 1; j <= y + 1; j++)
            {
                var tile = World.I.GetTile(i, j);

                if (tile != null && tile.name == "forest")
                {
                    wood++;
                }
            }

        if (wood > 0)
        {
            PopupManager.I.CreatePopup(transform.position.x, transform.position.y + 0.5f, "+[" + wood + "]");
            ResourceManager.I.ChangeWood(wood);
        }
    }
}
