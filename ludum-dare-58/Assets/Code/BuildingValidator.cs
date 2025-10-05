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
    public bool requiresNearbyRoad;
    public int minTownhall;
    public int maxTownhall;
    public int requiredWood;
    public int requiredTaxes;

    /**
     * 
     */
    public bool IsValid(int x, int y)
    {
        var tile = GetComponent<Tile>();

        var connected = false;

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

                if (name == "road")
                {
                    for (int q = i - 1; q <= i + 1; q++)
                        for (int w = j - 1; w <= j + 1; w++)
                        {
                            //if (q == i && w == j) continue;
                            //dont do diagonals
                            if (Mathf.Abs(q - i) + Mathf.Abs(w - j) == 2) continue;

                            var testtile = World.I.GetTile(q, w);
                            if (testtile != null && testtile.name == "townhall")
                            {
                                connected = true;
                            }
                        }
                }

                if (requiresNearbyRoad)
                {
                    for (int q = i - 1; q <= i + 1; q++)
                        for (int w = j - 1; w <= j + 1; w++)
                        {
                            if (Mathf.Abs(q - i) + Mathf.Abs(w - j) == 2) continue;

                            var testtile = World.I.GetTile(q, w);
                            if (testtile != null && testtile.name == "road")
                            {
                                connected = true;
                            }
                        }
                }
                else
                {
                    connected = true;
                }
            }

        return connected;
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

        if (ResourceManager.I.taxes < requiredTaxes)
        {
            return false;
        }

        return true;
    }
}
