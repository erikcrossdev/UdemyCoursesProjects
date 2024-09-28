using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour
{
   Vector2 dir = new Vector3 (1f, -1f);
    void Update()
    {
        Vector3 position = this.transform.position;
        position.x += dir.x * Time.deltaTime;
        position.y += dir.y * Time.deltaTime;

        transform.position = position;

        transform.LookAt (position);
    }
}