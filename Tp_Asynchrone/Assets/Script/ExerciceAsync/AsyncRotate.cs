using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AsyncRotate : MonoBehaviour
{
    public int Speed;
    public GameObject Cube;
    [SerializeField] private bool _isRotate;
    private CancellationTokenSource _cancellationToken;

    public void OnRotate()
    {
        _cancellationToken = new CancellationTokenSource();
        RotateCube();
    }
    public void StopRotate()
    {
        _cancellationToken.Cancel();
    }
    public async void RotateCube()
    {
        _isRotate = true;
        await UniTask.Delay(5000, cancellationToken: _cancellationToken.Token).SuppressCancellationThrow();
        _isRotate = false;
    }

    public void Update()
    {
        if (_isRotate)
        {
            Cube.transform.Rotate(90, 90, 90 * Speed * Time.deltaTime);
        }
    }
}
