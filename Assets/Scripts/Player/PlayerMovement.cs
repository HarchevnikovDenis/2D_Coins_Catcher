using UnityEngine;

public class PlayerMovement : MovingObjects
{
    private float lenghtOfSideways;
    private new Transform transform;
    public float LengthOfSideways { get { return lenghtOfSideways; } }

    private void Awake()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    private void Start()
    {
        lenghtOfSideways = PlayerStats.Instance.LengthOfSideways;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Move(direction);
        }
    }

    public override void Move(Vector3 direction)
    {
        if (!PlayerStats.Instance.isGameStart || PlayerStats.Instance.isGameOver)
        {
            return;
        }

        if (direction.x - 0.1f > transform.position.x)
        {
            // Движение вправо
            if (transform.position.x <= lenghtOfSideways)
            {
                transform.position += transform.right * movementSpeed * Time.deltaTime;
            }
            return;
        }
        
        if(direction.x + 0.1f < transform.position.x)
        {
            // Движение влево
            if (transform.position.x >= -lenghtOfSideways)
            {
                transform.position -= transform.right * movementSpeed * Time.deltaTime;
            }
            return;
        }
    }
}
