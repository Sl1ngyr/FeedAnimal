using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;

    [SerializeField] private float speed = 20.0f;
    private float xRange = 15.0f;   
    
    private FoodSpawnManager _foodSpawnManager;
    [SerializeField] private Food foodPrefab;
    
    
    void Start()
    {
        _foodSpawnManager = GetComponent<FoodSpawnManager>();
    }
    
    void Update()
    {

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _foodSpawnManager._foodPool.Get();
        }
    }

    public Food GetFoodPrefab()
    {
        return foodPrefab;
    }

    public Quaternion GetFoodPrefabRotation()
    {
        return foodPrefab.transform.rotation;
    }
    
}
