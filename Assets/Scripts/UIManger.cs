using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour {

    [SerializeField] private Text infectionRateText;
    [SerializeField] private Text sporesLeftText;
    [SerializeField] private Text thresholdText;

    private void Awake()
    {
        SetInfectionRate(0);
        SetSporesLeft(0);
        SetThreshold(0);
    }

    public void SetInfectionRate(int value)
    {
        var result = Mathf.Clamp(value, 0, int.MaxValue);
        infectionRateText.text = result.ToString();
    }

    public void SetSporesLeft(int value)
    {
        var result = Mathf.Clamp(value, 0, int.MaxValue);
        sporesLeftText.text = result.ToString();
    }

    public void SetThreshold(int value)
    {
        var result = Mathf.Clamp(value, 0, int.MaxValue);
        thresholdText.text = result.ToString();
    }
}
