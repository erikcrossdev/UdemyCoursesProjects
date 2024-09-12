using UnityEngine;

public class DestroyInvis : MonoBehaviour
{
    private void OnBecameInvisible() {
        this.gameObject.SetActive(false);
    }
}
