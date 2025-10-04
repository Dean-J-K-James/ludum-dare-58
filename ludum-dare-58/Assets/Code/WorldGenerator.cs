/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class WorldGenerator : MonoBehaviour
{
    public Tile grass; //
    public Tile dirt; //

    void Start()
    {
        for (int x = -10; x < 10; x++)
            for (int y = -10; y < 10; y++)
            {
                //var e = Instantiate(Random.Range(0, 2) == 0 ? grass : dirt, transform);
                //e.transform.position = tilemap.CellToWorld(new Vector3Int(x, y, 0));

                World.I.Create(Random.Range(0, 2) == 0 ? grass : dirt, x, y);
            }
    }
}
