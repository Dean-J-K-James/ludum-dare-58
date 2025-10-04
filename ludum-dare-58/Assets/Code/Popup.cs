/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using TMPro;
using UnityEngine;

/**
 * 
 */
public class Popup : MonoBehaviour
{
    public TextMeshPro text;
    float opacity = 1f;

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * 0.5f;
        opacity -= Time.deltaTime;

        text.color = new Color(text.color.r, text.color.g, text.color.b, opacity);

        if (opacity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
