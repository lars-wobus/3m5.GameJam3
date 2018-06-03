using UnityEngine;

public class MaterialAnimation : MonoBehaviour {

    [SerializeField] private Material material;
    [SerializeField] private Vector2 offset;
	
	void Update () {
        material.SetTextureOffset("_MainTex", offset * Time.time);
    }

    private void OnApplicationQuit()
    {
        material.SetTextureOffset("_MainTex", Vector2.zero);
    }
}
