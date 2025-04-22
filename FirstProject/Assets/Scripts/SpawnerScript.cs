using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    private float pipeOffsetMax = 2f;

    [SerializeField]
    private Food[] foods;

    private float foodOffsetMax = 4.5f;

    private float period = 4.0f;
    private float pipeTimeout;
    private float foodTimeout;

    void Start()
    {
        pipeTimeout = 0f;
        foodTimeout = period * 1.5f;
    }

    void Update()
    {
        pipeTimeout -= Time.deltaTime;
        if (pipeTimeout <= 0)
        {
            pipeTimeout = period;
            SpawnPipe();
        }

        foodTimeout -= Time.deltaTime;
        if (foodTimeout <= 0)
        {
            foodTimeout = period;
            SpawnFood();
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position + Random.Range(-pipeOffsetMax, pipeOffsetMax) * Vector3.up;
    }

    private void SpawnFood()
    {
        foreach (Food food in foods)
        {
            float randValue = Random.Range(0f, 1f);
            if (randValue <= food.spawnProbability)
            {
                GameObject foodObject = Instantiate(food.foodPrefab);
                foodObject.transform.position = transform.position + Random.Range(-foodOffsetMax, foodOffsetMax) * Vector3.up;

                FoodItem foodItem = foodObject.GetComponent<FoodItem>();
                if (foodItem != null)
                {
                    foodItem.food = food;
                }

                break;
            }
        }
    }

}
