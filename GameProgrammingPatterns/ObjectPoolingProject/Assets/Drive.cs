using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 10.0f;
    public Slider healthbar;
    public GameObject explosion;
    private void Start()
    {
        healthbar.value = 100;
    }
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //Instantiate(bullet, this.transform.position, Quaternion.identity);
            GameObject b = Pool.singleton.Get("Bullet");
            if(b != null)
            {
                b.transform.position = this.transform.position;
                b.SetActive(true);
            }
        }

        //Make the healthbar follow the ship position
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position) 
            + new Vector3(0, -35, 0); // to make the healthbar on the bottom of the ship
                                                ;
        healthbar.transform.position = screenPos;

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) {
            healthbar.value -= 5;
            if (healthbar.value <= 0)
            {
                Instantiate (explosion, this.transform.position, Quaternion.identity);

                Destroy(healthbar.gameObject, 0.1f); 
                Destroy(gameObject, 0.1f);
            }
        }
       
    }
}