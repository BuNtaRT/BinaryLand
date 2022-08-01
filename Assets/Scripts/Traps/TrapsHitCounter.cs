using System;
using Enums;
using Runtime;
using UnityEngine;

namespace Traps
{
    public class TrapsHitCounter : MonoBehaviour
    {
        private int _failCount = 0;
        private void Awake()
        {
            GlobalEventManager.OnTraps.AddListener(OnTraps);
        }

        public void OnTraps(int count)
        {
            _failCount += count;
            if (_failCount == 2)
                GlobalEventManager.CallComplete(FinishStatus.WebFail);
        }
    }
}