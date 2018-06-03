using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour {

    private int SporeCount { get; set; }
    private int CellCount { get; set; }
    private SoundManager sounds;

    [SerializeField] private Text infectionRateText;
    [SerializeField] private Text sporesLeftText;
    [SerializeField] private Text cellCountText;
    [SerializeField] private Text thresholdText;

    private void Awake()
    {
        SporeCount = -1;
        CellCount = -1;
        sounds = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
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
        sounds.playSuccessSound();
        SceneManager.LoadScene("SuccessScreen", LoadSceneMode.Additive);
    }

    private void ShowFailScreen()
    {
        sounds.playFailureSound();
        SceneManager.LoadScene("FailScreen", LoadSceneMode.Additive);
    }
}
