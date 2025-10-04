/**********************************************/
/* Dean James * Unity Project * Ludum Dare 58 */
/**********************************************/

using UnityEngine;

/**
 * 
 */
public class CameraManager : MonoBehaviour
{
    void Update()
    {
        int x = 0;
        int y = 0;

        if (Input.GetKey(KeyCode.W)) y += 1;
        if (Input.GetKey(KeyCode.A)) x -= 1;
        if (Input.GetKey(KeyCode.S)) y -= 1;
        if (Input.GetKey(KeyCode.D)) x += 1;


        var move = new Vector3(x, y, 0);

        move.Normalize();

        var newPosition = Camera.main.transform.position + (10f * Time.deltaTime * move);

        newPosition.x = Mathf.Clamp(newPosition.x, -10f, 10f);
        newPosition.y = Mathf.Clamp(newPosition.y, -10f, 10f);
     
        Camera.main.transform.position = newPosition;

        var wheel = Input.GetAxis("Mouse ScrollWheel");

        if (wheel != 0f)
        {
            var newSize = Camera.main.orthographicSize - (5f * wheel);
            newSize = Mathf.Clamp(newSize, 2.5f, 7.5f);
            Camera.main.orthographicSize = newSize;
        }
    }
}
