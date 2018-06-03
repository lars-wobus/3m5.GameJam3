using UnityEngine;

public class SporeColorManager : MonoBehaviour {

    [SerializeField] private Material[] materials;
    [SerializeField] private Material edgeMaterial;

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

    public Material GetEdgeMaterial()
    {
        return edgeMaterial;
    }
}
