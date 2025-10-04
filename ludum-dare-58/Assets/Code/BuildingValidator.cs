/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class BuildingValidator : MonoBehaviour
{
    public bool requiresNoBuilding;
    public int minTownhall;
    public int maxTownhall;
    public int requiredWood;

    /**
     * 
     */
    public bool IsValid(int x, int y)
    {
        var tile = GetComponent<Tile>();

        for (int i = x; i < x + tile.sizex; i++)
            for (int j = y; j < y + tile.sizey; j++)
            {
                if (World.I.GetTile(i, j) == null)
                {
                    return false;
                }

                if (requiresNoBuilding && World.I.GetTile(i, j).GetComponent<Building>() != null)
                {
                    return false;
                }

                if (!requiresNoBuilding && World.I.GetTile(i, j).GetComponent<Building>() == null)
                {
                    return false;
                }
            }

        return true;
    }

    /**
     * 
     */
    public bool IsValid()
    {
        if (ResourceManager.I.townhall < minTownhall || ResourceManager.I.townhall > maxTownhall)
        {
            return false;
        }

        if (ResourceManager.I.wood < requiredWood)
        {
            return false;
        }

        return true;
    }
}
