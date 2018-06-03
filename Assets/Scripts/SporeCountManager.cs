using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SporeCountManager : MonoBehaviour {

    public IntEvent GlobalSporeCountChanged;

    public int globalsporecount;
    public int GlobalSporeCount
    {
        get
        {
            return globalsporecount;
        }
        set
        {
            globalsporecount = value;
            if(GlobalSporeCountChanged == null)
            {
                return;
            }
            GlobalSporeCountChanged.Invoke(GlobalSporeCount);
        }
    }
}
