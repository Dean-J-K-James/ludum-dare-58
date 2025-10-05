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

    void Start()
    {
        DoTutorial("");
    }

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
                ResourceManager.I.ChangeTaxes(-build.GetComponent<BuildingValidator>().requiredTaxes);
                World.I.Create(build.GetComponent<Tile>(), tilePosition.x, tilePosition.y);

                DoTutorial(build.name);
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

    public int tutorial = 0;
    public GameObject[] tutorialSteps;

    void DoTutorial(string building)
    {
        if (tutorial == 0 && building == "townhall")
        {
            tutorial = 1;
        }

        if (tutorial == 1 && building == "lumberjack-hut")
        {
            tutorial = 2;
        }

        if (tutorial == 2 && building == "house")
        {
            tutorial = 3;
        }

        if (tutorial == 3 && building == "field")
        {
            tutorial = 4;
        }

        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == tutorial);
        }
    }
}
