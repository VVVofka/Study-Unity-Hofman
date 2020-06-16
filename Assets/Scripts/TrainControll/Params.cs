using System.Collections.Generic;

public class Params {
    Param curParam = null;
    List<Param> lstAll = new List<Param>();
    List<Param> lstInWork = new List<Param>();
    public Luses[] luses = {Luses.left, Luses.center, Luses.right};
    public float[] valfa = { -10, -5, 5, 10};
    public float[] va = {0.5f, 1.0f, 1.5f};
    public float[] vb = {4.5f, 6f, 8.5f};
    public float[] vd = {1f / 3f, 1f / 4f};

    public Params() {
        foreach(Luses l in luses)
            foreach(float alfa in valfa)
                foreach(float a in va)
                    foreach(float b in vb) 
                        for(int nd = 0; nd < vd.Length; nd++) {
                            if(nd > 0) {
                                lstAll.Add(new Param(Luses.left, alfa, a, b, vd[nd], vd[nd - 1]));
                                lstInWork.Add(lstAll[lstAll.Count - 1]);
                            }
                            if(nd < vd.Length - 1) {
                                lstAll.Add(new Param(Luses.left, alfa, a, b, vd[nd], vd[nd + 1]));
                                lstInWork.Add(lstAll[lstAll.Count - 1]);
                            }
                        }
    } // /////////////////////////////////////////////////////////////////////////
    public Param selectParam() {
        curParam = null;
        float max = 0f;
        foreach(Param cur in lstInWork) { 
            float rnd = cur.getRnd();
            if(rnd > max) {
                max = rnd;
                curParam = cur;
            }
        }
        return curParam;
    } // ///////////////////////////////////////////////////////////////////////////////////////
    public int setChoice(bool success) {
        int remain = success ? curParam.setGood() : curParam.setWrong();
        if(remain <= 0)
            lstInWork.Remove(curParam);
        return lstInWork.Count;
    } // /////////////////////////////////////////////////////////////////////////////
} // ******************************************************************************
