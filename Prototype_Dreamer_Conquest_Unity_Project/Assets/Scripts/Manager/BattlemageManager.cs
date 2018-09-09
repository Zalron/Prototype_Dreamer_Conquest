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
    public class BattlemageManager : Singleton<MonoBehaviour>
    {
        public BattlemageType battlemageType;
        public GameObject battlemageObject;
        public Vector3 battlemageSpawnLocation;
        void Start() // Use this for initialization
        {
            //Instantiate(battlemageObject, battlemageSpawnLocation, Quaternion.identity);
        }
        void Update() // Update is called once per frame
        {

        }
        public int GenerateRandomBattleMageRole(int randomBattlemageRoleGenerationResult)
        {
            int randomBattlemageRoleGeneration = Random.Range(1, 11);
            if (randomBattlemageRoleGeneration == 1)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.COMMANDER;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 2)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.RIFLEMAN;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 3)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.MARKSMAN;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 4)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.HEAVY_WEAPONS;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 5)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.ANTI_ARMOUR;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 6)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.CHAMPION;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 7)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.ENGINEER;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 8)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.GUARDIAN;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 9)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.SORCERER;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            if (randomBattlemageRoleGeneration == 10)
            {
                randomBattlemageRoleGenerationResult = (int)BattlemageType.DEMOLITION;
                Debug.Log(randomBattlemageRoleGenerationResult);
                return randomBattlemageRoleGenerationResult;
            }
            return 0;
        }
    }
}
