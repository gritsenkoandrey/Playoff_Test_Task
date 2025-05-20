using System.Collections;

namespace Runtime.Services.CoroutineService
{
    public interface ICoroutineService
    {
        void StartCoroutine(IEnumerator coroutine);
        void StopAllCoroutine();
    }
}