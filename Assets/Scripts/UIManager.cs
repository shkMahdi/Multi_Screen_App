using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject welcomePanel;
    public GameObject counterPanel;
    public GameObject congratsPanel;

    [Header("Welcome Screen")]
    public TMP_InputField nameInput;
    public Button continueButton;
    public TextMeshProUGUI errorText;

    [Header("Counter Screen")]
    public TextMeshProUGUI counterText;
    public Button incrementButton;
    public Button decrementButton;

    [Header("Congrats Screen")]
    public TextMeshProUGUI congratsText;
    public Button restartButton;

    private int counterValue;
    private const string NAME_KEY = "PlayerName";
    private const string COUNTER_KEY = "CounterValue";
    private const int TARGET_VALUE = 10;

    void Start()
    {
        continueButton.onClick.AddListener(OnContinueClicked);
        incrementButton.onClick.AddListener(OnIncrementClicked);
        decrementButton.onClick.AddListener(OnDecrementClicked);
        restartButton.onClick.AddListener(OnRestartClicked);

        if (errorText != null) errorText.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey(NAME_KEY))
        {
            counterValue = PlayerPrefs.GetInt(COUNTER_KEY, 0);
            ShowCounterOrCongrats();
        }
        else
        {
            ShowScreen(welcomePanel);
        }
    }

    void OnContinueClicked()
    {
        string enteredName = nameInput.text.Trim();

        if (string.IsNullOrEmpty(enteredName))
        {
            errorText.text = "Please enter your name.";
            errorText.gameObject.SetActive(true);
            return;
        }

        PlayerPrefs.SetString(NAME_KEY, enteredName);
        PlayerPrefs.SetInt(COUNTER_KEY, 0);
        PlayerPrefs.Save();
        counterValue = 0;

        ShowScreen(counterPanel);
        UpdateCounterText();
    }

    void OnIncrementClicked()
    {
        counterValue++;
        SaveCounter();
        UpdateCounterText();
        CheckForCompletion();
    }

    void OnDecrementClicked()
    {
        counterValue--;
        SaveCounter();
        UpdateCounterText();
    }

    void OnRestartClicked()
    {
        counterValue = 0;
        SaveCounter();
        ShowScreen(counterPanel);
        UpdateCounterText();
    }

    void SaveCounter()
    {
        PlayerPrefs.SetInt(COUNTER_KEY, counterValue);
        PlayerPrefs.Save();
    }

    void UpdateCounterText()
    {
        counterText.text = counterValue.ToString();
    }

    void CheckForCompletion()
    {
        if (counterValue >= TARGET_VALUE)
        {
            ShowCongrats();
        }
    }

    void ShowCounterOrCongrats()
    {
        if (counterValue >= TARGET_VALUE)
            ShowCongrats();
        else
        {
            ShowScreen(counterPanel);
            UpdateCounterText();
        }
    }

    void ShowCongrats()
    {
        string playerName = PlayerPrefs.GetString(NAME_KEY, "Player");
        congratsText.text = "Congratulations, " + playerName + "! You reached 10!";
        ShowScreen(congratsPanel);
    }

    void ShowScreen(GameObject screenToShow)
    {
        welcomePanel.SetActive(screenToShow == welcomePanel);
        counterPanel.SetActive(screenToShow == counterPanel);
        congratsPanel.SetActive(screenToShow == congratsPanel);
    }
}