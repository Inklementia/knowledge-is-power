using System.Collections;
using UnityEngine;

namespace _Sources._Scripts.Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}