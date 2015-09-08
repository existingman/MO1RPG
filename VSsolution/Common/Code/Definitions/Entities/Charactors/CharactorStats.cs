using System;
using System.Collections.Generic;

using MO1.Definitions.Items;
using MO1.Definitions.Combat;

namespace MO1.Definitions.Charactors
{
    public class CharactorStats
    {
        public float strength = 10;



        private Dictionary<AttackType, float> _skills = new Dictionary<AttackType, float>();
        public float GetSkill(AttackName attackName, WeaponType weaponType)
        {
            AttackType temp = new AttackType(attackName,weaponType);
            if(!_skills.ContainsKey(temp))
            {
                _skills.Add(temp, 0);
            }
            return _skills[temp];
        }
        public void SetSkill(AttackName attackName, WeaponType weaponType, float i)
        {
            AttackType temp = new AttackType(attackName, weaponType);
            if (!_skills.ContainsKey(temp))
            {
                _skills.Add(temp, 0);
            }
            _skills[temp] = i;
        }
    }


    public struct AttackType
    {
        public AttackName AttackName;
        public WeaponType WeaponType;

        public AttackType(AttackName attackName, WeaponType weaponType)
        {
            AttackName = attackName; 
            WeaponType = weaponType;
        }
    }
}
