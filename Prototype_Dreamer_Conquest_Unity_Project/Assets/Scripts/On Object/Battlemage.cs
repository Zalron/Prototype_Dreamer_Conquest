using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;

namespace DreamerConquest.Manager.Characters.Battlemage
{
    public class Battlemage : MonoBehaviour
    {
        public BattlemageManager battlemageManager;
        public BattlemageType battlemageType;
        public int battlemageType
        public int battlemageTypeInt;
        void Start() // Use this for initialization
        {
            battlemageTypeInt = battlemageManager.GenerateRandomBattleMageRole(battlemageTypeInt);
            battlemageTypeInt = (int)battlemageType;
            Debug.Log(battlemageTypeInt);
        }
        void Update() // Update is called once per frame
        {

        }
    }
}
