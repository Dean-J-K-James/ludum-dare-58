/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class PopulationManager : ResourceProducer
{
    protected override void Produce()
    {
        ResourceManager.I.ChangeFood(-ResourceManager.I.population);

        var increase = 0;
        
        if (ResourceManager.I.housing > ResourceManager.I.population)
        {
            increase = 1;
        }

        if (ResourceManager.I.food < 1)
        {
            increase = -1;
        }




        ResourceManager.I.ChangePopulation(increase);
    }
}
