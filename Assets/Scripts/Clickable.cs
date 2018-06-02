using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Tip: Generic UnityEvents must be serialized before they show up in the inspector!
[System.Serializable]
public class IntEvent : UnityEvent<int>{ };

public class Clickable : MonoBehaviour {

    private static int MinSporeCount = 0;
    private static int MaxSporeCount = int.MaxValue;

    [SerializeField] private int sporeCount = 0;
    [SerializeField] private IntEvent SporeCountChanged;

    public int SporeCount
    {
        get
        {
            return sporeCount;
        }
        set
        {
            var tmp = Mathf.Clamp(value, MinSporeCount, MaxSporeCount);
            if (tmp == sporeCount)
            {
                return;
            }
            sporeCount = tmp;

            if(SporeCountChanged == null)
            {
                return;
            }
            SporeCountChanged.Invoke(sporeCount);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSporeCount(int count)
    {
        SporeCount = sporeCount + count;
    }
}
