/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class ResourceManager : Singleton<ResourceManager>
{
    public UIResource uiWood; //
    public UIResource uiHousing; //
    public UIResource uiPopulation; //
    public UIResource uiFood; //
    public UIResource uiTaxes; //

    public int townhall { get; private set; }
    public int wood { get; private set; }
    public int housing { get; private set; }
    public int population { get; private set; }
    public int food { get; private set; }
    public int taxes { get; private set; }

    void Start()
    {
        townhall = 0;
        wood = 0;
        housing = 0;
        population = 0;
        food = 0;
        ChangeWood(25);
        ChangeTaxes(50);
        ChangePopulation(0);
        ChangeFood(25);
    }

    public void ChangeTownhall(int amount)
    {
        townhall += amount;
        townhall = Mathf.Clamp(townhall, 0, 1);
    }

    public void ChangeWood(int amount)
    {
        wood += amount;
        wood = Mathf.Clamp(wood, 0, 999);
        uiWood.value.text = wood.ToString();
    }

    public void ChangeHousing(int amount)
    {
        housing += amount;
        housing = Mathf.Clamp(housing, 0, 999);
        uiHousing.value.text = housing.ToString();
    }

    public void ChangePopulation(int amount)
    {
        population += amount;
        population = Mathf.Clamp(population, 0, 999);
        uiPopulation.value.text = population.ToString() + " [" + amount + "]";
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        food = Mathf.Clamp(food, 0, 999);
        uiFood.value.text = food.ToString();
    }
    public void ChangeTaxes(int amount)
    {
        taxes += amount;
        taxes = Mathf.Clamp(taxes, 0, 100);
        uiTaxes.value.text = taxes.ToString();
    }
}
