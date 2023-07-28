using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    int _roadIndex = 1;

    Road _road;

    private void Start()
    {
        _road = FindObjectOfType<Road>();
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bool left = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition).x < 0;

                ChangeLane(left);
            }
        }
    }

    private void ChangeLane(bool left)
    {
        _roadIndex = Mathf.Clamp(_roadIndex + (left ? -1 : 1), 0, _road.XPos.Length - 1);

        StartCoroutine(LaneMotion());
    }

    IEnumerator LaneMotion()
    {
        Vector2 finish = new Vector2(_road.XPos[_roadIndex], transform.position.y);
        while (Vector2.Distance(transform.position, finish) > 0.05f)
        {
            transform.position = Vector2.MoveTowards(transform.position, finish, Time.deltaTime * _speed);
            yield return null;
        }
        transform.position = finish;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Single.Lives--;
    }
}
