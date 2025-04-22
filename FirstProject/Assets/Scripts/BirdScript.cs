using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float health;

    private float jumpForceEasy = 250f;
    private float jumpForceHard = 500f;

    [SerializeField]
    private bool isHardMode = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 100f;

        Debug.Log("Initial Health: " + health);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpForce = isHardMode ? jumpForceHard : jumpForceEasy;
            rb.AddForce(Vector2.up * jumpForce);
        }

        float targetAngle = rb.linearVelocity.y * 3f;
        float smoothedAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * 5f);
        transform.rotation = Quaternion.Euler(0, 0, smoothedAngle);

        health -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name + ", tag: " + other.tag);
        if (other.CompareTag("Food"))
        {
            FoodItem foodItem = other.GetComponent<FoodItem>();

            if (foodItem != null)
            {
                Debug.Log("Health before eating food: " + health);

                health = Mathf.Clamp(health + foodItem.food.healingAmount, 0f, 100f);
                Debug.Log("Health after eating food: " + health);
            }

            Transform current = other.transform;
            while (current != null)
            {
                Transform parent = current.parent;
                Destroy(current.gameObject);
                current = parent;
            }
        }
    }

}
