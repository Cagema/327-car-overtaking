using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �� ������ ��
public class BGMovement : MonoBehaviour
{
    [SerializeField]
    Transform _background1;
    [SerializeField]
    Transform _background2;

    private float _backgroundHeight;

    private void Start()
    {
        // �������� ������ ����
        _backgroundHeight = _background1.GetComponent<SpriteRenderer>().bounds.size.y;
        _background2.position += new Vector3(0, _backgroundHeight, 0);
    }

    private void Update()
    {
        // ���������� ���� ����
        _background1.position += new Vector3(0, -GameManager.Single.Speed * Time.deltaTime, 0);
        _background2.position += new Vector3(0, -GameManager.Single.Speed * Time.deltaTime, 0);

        // ���� ������ ��� ����� �� ������� ������, ���������� ��� ����� �� ������ ����
        if (_background1.position.y < -_backgroundHeight)
        {
            _background1.position += new Vector3(0, _backgroundHeight * 2, 0);
        }

        // ���� ������ ��� ����� �� ������� ������, ���������� ��� ����� �� ������ ����
        if (_background2.position.y < -_backgroundHeight)
        {
            _background2.position += new Vector3(0, _backgroundHeight * 2, 0);
        }
    }
}
