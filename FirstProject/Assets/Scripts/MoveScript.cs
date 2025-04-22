using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
    }
}
