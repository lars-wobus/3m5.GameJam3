using UnityEngine;

public class SporeColorManager : MonoBehaviour {

    [SerializeField] private Material[] materials;
    public Material[] Materials
    {
        get
        {
            return materials;
        }
    }

    public Material GetMaterial(int index)
    {
        return Materials[Mathf.Clamp(index, 0, materials.Length)];
    }
}
