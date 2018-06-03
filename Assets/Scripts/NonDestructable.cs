using UnityEngine;

public class NonDestructable : MonoBehaviour {

    private void Start () {
        DontDestroyOnLoad(gameObject);
    }
}
