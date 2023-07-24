using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
	[SerializeField] Road _road;
    [SerializeField] bool _spawnInTime = true;
    float _timeSpent;

	private void FixedUpdate()
	{
		if (GameManager.Single.GameActive)
		{
			if (_spawnInTime)
			{
				_timeSpent += Time.deltaTime;
				if (_timeSpent > GameManager.Single.Interval)
				{
					_timeSpent = 0;

					Spawn();
				}
			}
		}
	}

	private void Spawn()
	{
		var newGO = Instantiate(prefabs[Random.Range(0, prefabs.Length)], SetPosition(), Quaternion.identity);
		newGO.transform.SetParent(transform, true);
	}

	private Vector3 SetPosition()
	{
		return new Vector3(_road.XPos[Random.Range(0, _road.XPos.Length)], GameManager.Single.RightUpperCorner.y + 1.5f, 0);
	}
}
