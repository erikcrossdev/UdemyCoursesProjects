using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 velocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) {
            collision.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        this.transform.Translate(velocity);
    }
}
