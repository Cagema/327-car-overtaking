using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        transform.Translate((_speed + GameManager.Single.Speed) * Time.deltaTime * Vector3.down);
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -GameManager.Single.RightUpperCorner.y - 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
