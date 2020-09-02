using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObjects : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;

    public virtual void Move(Vector3 direction) { }
}
