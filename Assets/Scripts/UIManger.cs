using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour {

    private int SporeCount { get; set; }
    private int CellCount { get; set; }

    [SerializeField] private Text infectionRateText;
    [SerializeField] private Text sporesLeftText;
    [SerializeField] private Text cellCountText;
    [SerializeField] private Text thresholdText;

    private void Awake()
    {
        SporeCount = -1;
        CellCount = -1;
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
        SporeCount = result;

        CheckGameOverState();
    }

    public void SetCellCount(int value)
    {
        var result = Mathf.Clamp(value, 0, int.MaxValue);
        cellCountText.text = result.ToString();
        CellCount = result;

        CheckGameOverState();
    }

    public void SetThreshold(int value)
    {
        var result = Mathf.Clamp(value, 0, int.MaxValue);
        thresholdText.text = result.ToString();
    }

    private void CheckGameOverState()
    {
        if (SporeCount == 0 && CellCount > 0)
        {
            ShowFailScreen();
            return;
        }

        if (CellCount == 0)
        {
            ShowSuccessScreen();
            return;
        }
    }

    private void ShowSuccessScreen()
    {
        SceneManager.LoadScene("SuccessScreen", LoadSceneMode.Additive);
    }

    private void ShowFailScreen()
    {
        SceneManager.LoadScene("FailScreen", LoadSceneMode.Additive);
    }
}
