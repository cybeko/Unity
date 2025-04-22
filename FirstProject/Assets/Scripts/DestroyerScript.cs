using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform current = other.transform;
        while (current != null)
        {
            Transform parent = current.parent;
            Destroy(current.gameObject);
            current = parent;
        }
    }
}
