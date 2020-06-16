using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Mode {
    start,
    mainMenu,
    waitChoose,
    showResult
} // ****************************************************************************************
public class Controller : MonoBehaviour {
    Mode mode = Mode.start;
    Params prms = new Params();

    void Update() {
        switch(mode) {
        case Mode.start:
            doShowMainMenu();
            break;
        case Mode.mainMenu:
            inMainMenu();
            break;
        case Mode.waitChoose:
            inWaitChoose();
            break;
        case Mode.showResult:
            inShowResult();
            break;
        default:
            break;
        }
    } // //////////////////////////////////////////////////////////////////////////////////////////////
    void inMainMenu() {
        if(Input.GetKey(KeyCode.Space) ||
            Input.GetKey(KeyCode.KeypadEnter) ||
            Input.GetKey(KeyCode.Return)) {
            doSetBalls();
        } else if(Input.GetKey(KeyCode.Escape)) {
               // TODO exit programm
        }
    } // /////////////////////////////////////////////////////////////////////////////////////////////
    void inWaitChoose() {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            if(prms.setChoiceLeft())
                onSuccessChoose();
            else
                prms.setWrong();
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            if(prms.setChoiceRight())
                onSuccessChoose();
            else
                prms.setWrong();
        } else if(Input.GetKey(KeyCode.Escape)) {
            doShowMainMenu();
        }
    } // //////////////////////////////////////////////////////////////////////////////
    void inShowResult() {
        if(Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.Space)) {

            prms.selectParam();
            doSetBalls();
        } else if(Input.GetKey(KeyCode.Escape)) {
            doShowMainMenu();
        }
    } // ///////////////////////////////////////////////////////////////////////
    void onSuccessChoose() {
        int remainExercise = prms.setGood();
        if(remainExercise <= 0)
            if(prms.RemainExercises() <= 0)
                doFinishExercises();
            else
                doFinishExercise();
    } // ////////////////////////////////////////////////////////////////////////////////
    void doFinishExercise() { } // TODO sound, progress bar
    void doFinishExercises() {    // TODO sound, results
        doShowMainMenu();
    } // /////////////////////////////////////////////////////////////////////////////////
    void doShowMainMenu() {
        mode = Mode.mainMenu;   // TODO: main menu
    } // //////////////////////////////////////////////////////////////////////////////////
    void doSetBalls() {  // TODO view
        mode = Mode.waitChoose;
    } // /////////////////////////////////////////////////////////////////////////////////
} // ***************************************************************************************************
