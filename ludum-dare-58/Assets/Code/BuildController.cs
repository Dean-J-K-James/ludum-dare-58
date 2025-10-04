/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

/**
 * 
 */
public class BuildController : Singleton<BuildController>
{
    public Building build; //
    public Grid grid; //
    public GameObject mouse; //

    int oldx;
    int oldy;

    public void SetBuilding(Building t)
    {
        build = t;
        mouse.GetComponent<SpriteRenderer>().sprite = t.GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        if (build == null) return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            build = null;
            mouse.GetComponent<SpriteRenderer>().sprite = null;
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        var tilePosition = grid.WorldToCell(mousePosition);
        tilePosition.z = 0;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var validBuild = build.GetComponent<BuildingValidator>().IsValid(tilePosition.x, tilePosition.y) && build.GetComponent<BuildingValidator>().IsValid();

            if (validBuild)
            {
                Debug.Log("Building " + build.name + " at " + tilePosition);
                ResourceManager.I.ChangeWood(-build.GetComponent<BuildingValidator>().requiredWood);
                World.I.Create(build.GetComponent<Tile>(), tilePosition.x, tilePosition.y);
            }
        }

        if (tilePosition.x == oldx && tilePosition.y == oldy)
        {
            return;
        }

        oldx = tilePosition.x;
        oldy = tilePosition.y;

        mouse.transform.position = grid.CellToWorld(tilePosition);
        mouse.transform.position = new Vector3(mouse.transform.position.x, mouse.transform.position.y, -5f);

        var isValid = build.GetComponent<BuildingValidator>().IsValid(tilePosition.x, tilePosition.y) && build.GetComponent<BuildingValidator>().IsValid();

        mouse.GetComponent<SpriteRenderer>().color = isValid ? new Color(.5f, 1f, .5f, 0.5f) : new Color(1f, .5f, .5f, 0.5f);

        //mouse.GetComponent<SpriteRenderer>().sortingOrder = 9999999; // Mathf.FloorToInt((-1000f * mouse.transform.position.y) - 9);
    }
}
