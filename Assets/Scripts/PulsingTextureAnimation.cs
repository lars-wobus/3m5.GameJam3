using UnityEngine;
using UnityEngine.UI;

public class PulsingTextureAnimation : MonoBehaviour {

    [SerializeField] private Material material;
    [SerializeField] private Material startMaterial;
    [SerializeField] private Material stopMaterial;
    [SerializeField] private float length = 3;

    private Material Material
    {
        get
        {
            return material;
        }
    }

    private Material StartMaterial
    {
        get
        {
            return startMaterial;
        }
    }

    private Material StopMaterial
    {
        get
        {
            return stopMaterial;
        }
    }

    private float Length
    {
        get
        {
            return length;
        }
    }

    void Update () {
        var value = Mathf.PingPong(Time.time, Length);
        Debug.Log(value);
        Material.Lerp(StartMaterial, StopMaterial, value / Length);
    }
}
