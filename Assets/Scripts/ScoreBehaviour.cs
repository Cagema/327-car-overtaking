using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField] float _timeBetweenScoreAdd;
    public void StartScoreAdder()
    {
        StartCoroutine(ScoreAdder());
    }

    private IEnumerator ScoreAdder()
    {
        do
        {
            GameManager.Single.Score++;
            yield return new WaitForSeconds(_timeBetweenScoreAdd);
        } while (GameManager.Single.GameActive);
    }
}
