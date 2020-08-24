using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Events;

namespace Assets.Scripts.Gameplay
{
    public interface PointsChanger
    {
        void AddPointsChangedListener(UnityAction<int> listener);
    }
}
