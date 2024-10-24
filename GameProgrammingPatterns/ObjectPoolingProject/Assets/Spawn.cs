using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject asteroid;
   
    void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            /*
            Instantiate(asteroid,
                this.transform.position +
                new Vector3(Random.Range(-10, 10), 0, 0), Quaternion.identity);
            */
            GameObject asteroid = Pool.singleton.Get("Asteroid");
            if (asteroid != null)
            {
                asteroid.transform.position = this.transform.position
                    + new Vector3(Random.Range(-10, 10), 0, 0);
                asteroid.SetActive(true);
            }
        }
    }
}
