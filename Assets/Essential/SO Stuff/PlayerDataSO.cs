using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField]
    private int lives = 3;

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

}
