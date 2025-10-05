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
    public Tile forest; //
    public Tile water; //

    void Start()
    {
        for (int x = -10; x < 10; x++)
            for (int y = -10; y < 10; y++)
            {
                //var e = Instantiate(Random.Range(0, 2) == 0 ? grass : dirt, transform);
                //e.transform.position = tilemap.CellToWorld(new Vector3Int(x, y, 0));

                World.I.Create(grass, x, y);
            }

        //pick 3 random positions, and make every tile within 4 tiles a 75% chance of forest.
        //then, do the same for 1 position and make it water.

        for (int i = 0; i < 3; i++)
        {
            int rx = Random.Range(-10, 10);
            int ry = Random.Range(-10, 10);

            for (int x = rx + -4; x < rx + 4; x++)
                for (int y = ry - 4; y < ry + 4; y++)
                {
                    if (Random.Range(0, 100) < 50)
                    {
                        var t = World.I.GetTile(x, y);
                        if (t != null)
                        {
                            //Destroy(t.gameObject);
                            World.I.Create(forest, x, y);
                        }
                    }
                }
        }

        for (int i = 0; i < 2; i++)
        {
            int rx = Random.Range(-10, 10);
            int ry = Random.Range(-10, 10);

            for (int x = rx + -2; x < rx + 2; x++)
                for (int y = ry - 2; y < ry + 2; y++)
                {
                    if (Random.Range(0, 100) < 75)
                    {
                        var t = World.I.GetTile(x, y);
                        if (t != null)
                        {
                            //Destroy(t.gameObject);
                            World.I.Create(water, x, y);
                        }
                    }
                }
        }
    }
}
