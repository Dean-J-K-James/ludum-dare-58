using UnityEngine;

public class Road : MonoBehaviour
{
    public Sprite[] sprites;
    public bool connectedToTownhall = false;

    void Start()
    {
        //RefreshTile();

        //return;
        var posx = GetComponent<Tile>().x;
        var posy = GetComponent<Tile>().y;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                var tile = World.I.GetTile(posx + x, posy + y);
                if (tile != null && tile.GetComponent<Road>() != null)
                {
                    tile.GetComponent<Road>().RefreshTile();
                }
            }
        }
    }

    public void RefreshTile()
    {
        var mask = 0;
        var posx = GetComponent<Tile>().x;
        var posy = GetComponent<Tile>().y;

        if (IsRoad(posx, posy + 1)) { mask += 1; }
        if (IsRoad(posx + 1, posy)) { mask += 2; }
        if (IsRoad(posx, posy - 1)) { mask += 4; }
        if (IsRoad(posx - 1, posy)) { mask += 8; }

        GetComponent<SpriteRenderer>().sprite = sprites[mask];

        Debug.Log("Refreshing tile at : " + posx + " :: " + posy + " with mask: " + mask);
    }

    bool IsRoad(int x, int y)
    {
        var tile = World.I.GetTile(x, y);

        Debug.Log(tile);

        if (tile != null && tile.GetComponent<Road>() != null)
        {
            return true;
        }

        return false;
    }

    bool isConnectedToTownhall()
    {
        //This road is connected to a town hall if any of the adjacent roads is connected to a town hall or if an adjacent tile is the town hall.

        //var posx = GetComponent<Tile>().x;
        //var posy = GetComponent<Tile>().y;

        //for (int x = -1; x <= 1; x++)
        //    for (int y = -1; y <= 1; y++)
        //    {
        //        var tile = World.I.GetTile(posx + x, posy + y);
        //        if (tile != null && tile.GetComponent<Road>() != null && tile.GetComponent<Road>().connectedToTownhall)
        //        {
        //            tile.GetComponent<Road>().RefreshTile();
        //        }
        //    }

        return false;
    }
}
