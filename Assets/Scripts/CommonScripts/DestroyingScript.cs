using UnityEngine;

public class DestroyingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DestroyObjectAfterStart(3);
    }

    /// <summary>
    /// Метод уничтожает игровой объект, привязанный к данному скрипту
    /// </summary>
    /// <param name="seconds">Время, через которое произойдет уничтожение объекта</param>
    void DestroyObjectAfterStart(int seconds)
    {
        Destroy(this.gameObject, seconds);
    }

}
