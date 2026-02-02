using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
