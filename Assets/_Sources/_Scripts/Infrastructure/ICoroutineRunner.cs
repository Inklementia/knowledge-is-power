using System.Collections;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}