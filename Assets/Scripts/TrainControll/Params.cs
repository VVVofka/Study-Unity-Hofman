using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using UnityEngine;

public class Params : MonoBehaviour {
    List<Param> lstAll = new List<Param>();
    List<Param> lstInWork = new List<Param>();
    Luses[] luses = {Luses.left, Luses.center, Luses.right};
    float[] valfa = { -10, -5, 5, 10};
    float[] va = {0.5f, 1.0f, 1.5f};
    float[] vb = {5f, 6f, 7.5f};
    float[] vd = {1f / 3f, 1f / 4f};

    void Start() {
        int n = 0;
        foreach(Luses l in luses)
            foreach(float alfa in valfa)
                foreach(float a in va)
                    foreach(float b in vb) {
                        lstAll.Add(new Param(Luses.left, alfa, a, b, vd[0], vd[1]));
                        lstInWork.Add(lstAll[n++]);
                        for(int nd = 1; nd < vd.Length - 1; nd++) {
                            lstAll.Add(new Param(Luses.left, alfa, a, b, vd[nd], vd[nd - 1]));
                            lstInWork.Add(lstAll[n++]);
                            lstAll.Add(new Param(Luses.left, alfa, a, b, vd[nd], vd[nd + 1]));
                            lstInWork.Add(lstAll[n++]);
                        }
                        lstAll.Add(new Param(Luses.left, alfa, a, b, vd[vd.Length - 1], vd[vd.Length - 2]));
                        lstInWork.Add(lstAll[n++]);
                    }
    }
} // /////////////////////////////////////////////////////////////////////////
void Update() { }
} // ******************************************************************************
