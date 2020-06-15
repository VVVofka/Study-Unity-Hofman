using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Luses {
    left = 1,
    center = 2,
    right = 3
}

public class Param{
    public Luses luse = Luses.left;        // № лузы
    public float alfa = 0.0f;   // угол в градусах входа в лузу
    public float a = 1.0f;      // расстояние между прицельным и лузой в радиусах
    public float b = 5.0f;      // расстояние между битком и лузой
    public float d = 0.0f;      // резка
    public float dwrong = 0.0f; // резка неправильная
    List<Color32> history = new List<Color32>();
    int left = 3;
    float rnd = 1.0f;
    float krnd = 0.71f;

    public Param(Luses Luse, float Alfa, float A, float B, float D, float DWrong) {
        luse = Luse;
        alfa = Alfa;
        a = A;
        d = D;
        b = B;
    } // ///////////////////////////////////////////////////////////////////////////
    public bool setGood() {
        history.Add(new Color32(0, 255, 0, 255));
        rnd *= krnd;
        return --left <= 0;
    } // ///////////////////////////////////////////////////////////////////////////////////////////////////
    public bool setWrong() {
        history.Add(new Color32(255, 0, 0, 255));
        rnd /= krnd;
        return --left <= 0;
    } // ///////////////////////////////////////////////////////////////////////////////////////////////////
    public float getRnd() {
        return Random.Range(0.0f, rnd);
    } // //////////////////////////////////////////////////////////////////////////////////////////////////
} // ********************************************************************************************************
