using Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime
{
    public static class GlobalEventManager 
    {
        /*-----------------------------------------------------------------------------------------*/
        public static readonly UnityEvent<FinishStatus> OnComplete = new UnityEvent<FinishStatus>();
        public static void CallComplete(FinishStatus status) => OnComplete.Invoke(status);

        /*-----------------------------------------------------------------------------------------*/
        public static readonly UnityEvent<int> OnTraps = new UnityEvent<int>();
        public static void CallTraps(int status) => OnTraps.Invoke(status);
        
        /*-----------------------------------------------------------------------------------------*/
        public static readonly UnityEvent<int> OnScore = new UnityEvent<int>();
        public static void CallAddScore(int status) => OnScore.Invoke(status);

    }
}