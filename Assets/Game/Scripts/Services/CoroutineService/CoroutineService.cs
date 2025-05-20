using System.Collections;
using UnityEngine;

namespace Runtime.Services.CoroutineService
{
    public sealed class CoroutineService : MonoBehaviour, ICoroutineService
    {
        void ICoroutineService.StartCoroutine(IEnumerator coroutine) => StartCoroutine(coroutine);
        void ICoroutineService.StopAllCoroutine() => StopAllCoroutines();
    }
}