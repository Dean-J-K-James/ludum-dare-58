/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public class World : Singleton<World>
{
    public Dictionary<Vector2Int, Tile> tiles = new(); //
    public Grid grid; //
    public Tile demolish; //
    public Tile grass; //

    /**
     * 
     */
    public void Create(Tile prefab, int x, int y)
    {
        if (prefab == demolish)
        {
            var t = GetTile(x, y);
            Remove(t);

            for (int i = x; i < x + t.sizex; i++)
                for (int j = y; j < y + t.sizey; j++)
                {
                    Create(grass, i, j);
                }

            return;
        }

        for (int i = x; i < x + prefab.sizex; i++)
            for (int j = y; j < y + prefab.sizey; j++)
            {
                //check if a tile already exists here.
                var curr = GetTile(i, j);

                //if yes, remove it.
                if (curr != null)
                {
                    Remove(curr);
                }
            }
        

        //create it.
        var e = Instantiate(prefab, transform);
        e.transform.position = grid.CellToWorld(new Vector3Int(x, y, 0));

        e.name = prefab.name;

        e.x = x;
        e.y = y;

        //e.transform.position = new Vector3(e.transform.position.x, e.transform.position.y, -prefab.layer * 2.5f);

        e.GetComponent<SpriteRenderer>().sortingOrder = Mathf.FloorToInt((-1000f * e.transform.position.y) - prefab.layer);

        for (int i = x; i < x + prefab.sizex; i++)
            for (int j = y; j < y + prefab.sizey; j++)
            {
                tiles[new Vector2Int(i, j)] = e;
            }



        //also set it for if the tile is more than 1x1.
    }

    public Tile GetTile(int x, int y)
    {
        tiles.TryGetValue(new Vector2Int(x, y), out Tile t);
        return t;
    }

    public void Remove(Tile t)
    {
        if (tiles.ContainsValue(t))
        {
            List<Vector2Int> keysToRemove = new();

            foreach (var pair in tiles)
            {
                if (pair.Value == t)
                {
                    keysToRemove.Add(pair.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                tiles.Remove(key);
            }

            Destroy(t.gameObject);
        }
    }
}
