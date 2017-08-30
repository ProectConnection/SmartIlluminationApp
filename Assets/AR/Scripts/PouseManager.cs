using UnityEngine;
using System.Collections;

public class PouseManager : MonoBehaviour {
    
    bool IsPouse;
    public bool isPouse{
        get
        {
            return IsPouse;
        }
        private set
        {
            IsPouse = value;
        }
    }

    public void SetPouse(bool tIsPouse = true)
    {
        isPouse = tIsPouse;
    }

    
}
