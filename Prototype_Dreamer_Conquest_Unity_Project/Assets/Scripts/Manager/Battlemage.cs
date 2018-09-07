using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;

namespace DreamerConquest.Manager.Characters.Battlemage
{
    public enum BattlemageType
    {
        COMMANDER,
        SORCERER,
        GUARDIAN,
        ENGINEER,
        HONOUR_GUARD,
        VETERAN,
        CHAMPION,
        CLERIC,
        ACE,
        ADMIRAL,
        SIGNALLER,
        LOGICIAN,
        SENSOR,
        STANDARD_BEARER,
        OBSERVER,
        ANTI_ARMOUR,
        HEAVY_WEAPONS,
        DEMOLITION,
        MARKSMAN,
        RIFLEMAN,
    }
    public class Battlemage : Singleton<MonoBehaviour>
    {
        public BattlemageType battlemageType;
        void Start() // Use this for initialization
        {

        }
        void Update() // Update is called once per frame
        {

        }
        public void GenerateRandomBattleMage()
        {
            int randomStandardBattlemageRoll = Random.Range(1, 11);
            if (randomStandardBattlemageRoll == 0)
            {

            }
        }
    }
}
