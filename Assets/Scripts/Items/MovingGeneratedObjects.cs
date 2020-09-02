using UnityEngine;

public class MovingGeneratedObjects : MovingObjects
{
    private void Update()
    {
        Move(-Vector3.up);

        if(!isTheObjectVisible())
        {
            Destroy(this.gameObject);
        }
    }

    public override void Move(Vector3 direction)
    {
        if (!PlayerStats.Instance.isGameStart || PlayerStats.Instance.isGameOver)
        {
            return;
        }

        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private bool isTheObjectVisible()
    {
        return transform.position.y > -7.0f;
    }
}
