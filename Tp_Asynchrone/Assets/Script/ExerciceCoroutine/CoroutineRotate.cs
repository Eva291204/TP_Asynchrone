using System.Collections;
using UnityEngine;

public class CoroutineRotate : MonoBehaviour
{
    public int Speed;
    public GameObject Cube;
    private Coroutine _rotate;
    public void OnRotate()
    {
        _rotate = StartCoroutine(RotateForFiveSecond());
    }

    public void OnStopRotate()
    {
        StopCoroutine(_rotate);
    }

    IEnumerator RotateForFiveSecond()
    {
        float timeToSpin = 0;
        while (timeToSpin <= 4)
        {
            Cube.transform.Rotate(90, 90, 90 * Speed * Time.deltaTime);
            timeToSpin += Time.deltaTime;
            yield return null;
        }
    }
}
