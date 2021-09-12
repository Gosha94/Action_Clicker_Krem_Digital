using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;    
    [SerializeField]
    private Button _exitButton;

    public int testInt;
    public bool testGameStarted;

    public Slider DamageSlider;
    public static MainSceneController Instanse;

    private bool _isGameStarted;

    /// <summary>
    /// Свойство, определяет статус начала игры
    /// </summary>
    public bool IsGameStarted
    {

        get { return _isGameStarted; }

        set
        {
            if (value != _isGameStarted)
            {
                _isGameStarted = value;
            }
        }
    }
    void Start()
    {
        Instanse = this;
        _startButton.onClick.AddListener(
            () =>
            {
                this.IsGameStarted = true;
                _startButton.gameObject.SetActive(false);
            });

        _exitButton.onClick.AddListener(
            () =>
            {
                Application.Quit();
            });
    }

    void Update()
    {
        testInt++;
        testGameStarted = IsGameStarted;
        CheckDamageLevel();
    }

    /// <summary>
    /// Метод проверяет уровень повреждения у здания
    /// </summary>
    private void CheckDamageLevel()
    {
        if (this.DamageSlider.value >= 70.0f)
        {
            this.IsGameStarted = false;
            SceneManager.LoadScene(0);
        }
    }
}
