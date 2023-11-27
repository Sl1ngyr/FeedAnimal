using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDirection;
    private Rigidbody playerRidigbody;
    [SerializeField] private float speed;
    private float xRange = 15.0f;   
    
    private FoodSpawnManager _foodSpawnManager;
    [SerializeField] private Food foodPrefab;

    private void Start()
    {
        playerRidigbody = GetComponent<Rigidbody>();
        _foodSpawnManager = GetComponent<FoodSpawnManager>();
    }

    private void FixedUpdate()
    {
        
        Move(moveDirection);
    }


    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _foodSpawnManager._foodPool.Get();
        }
    }

    private void Move(Vector3 direction)
    {
        playerRidigbody.MovePosition(playerRidigbody.position + direction * Time.fixedDeltaTime * speed);
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
