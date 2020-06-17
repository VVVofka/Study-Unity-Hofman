using UnityEngine;
using UnityEngine.UI;   // Импортируем фреймворк для работы с кодом UI.
using System.Collections;

public class UIController : MonoBehaviour {
    [SerializeField] private Text scoreLabel;   // Объект сцены Reference Text для задания свойства text.

    void Update() {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
    } // ////////////////////////////////////////////////////////////////////////////////////
    public void OnOpenSettings() {  //  Метод, вызываемый кнопкой настроек.
        Debug.Log("open settings");
    } // ///////////////////////////////////////////////////////////////////////////////////////
} // ***************************************************************************************