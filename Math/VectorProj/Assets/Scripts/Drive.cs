using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour
{
    Vector2 dir = new Vector3 (1f, 1f);
    float speed = 5f;
    void Update()
    {
        Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += dir.y * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y += (-dir.y) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x += (-dir.x) * Time.deltaTime * speed;            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += dir.x * Time.deltaTime * speed;
        }
       

        transform.position = position;

    }
}