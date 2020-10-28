using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_RPG
{
    public class Soldier
    {
        //勇者の名前
        private string heroname;

        public string HeroName
        {
            get { return heroname; }
            set { heroname = value; }
        }
        //HP
        private float hp;

        public float HP
        {
            get { return hp; }
            set { hp = value; }
        }

        //MAXHP
        private float maxhp;

        public float MAXHP
        {
            get { return maxhp; }
            set { maxhp = value; }
        }

        //攻撃力
        private float attack;

        public float Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        //防御力
        private float defence;

        public float Defence 
        {
            get { return defence; }
            set { defence = value;}
        }
        
        //勇者の剣技
        private Skill heroswordskill;

        public Skill HeroSwordSkill
        {
            get { return heroswordskill; }
            set { heroswordskill = value; }
        }

        //勇者の魔法
        private Skill heromagic;

        
        public Skill HeroMagic
        {
            get { return heromagic; }
            set { heromagic = value; }
        }
        //勇者の必杀技
        private Skill herofinalskill;

        internal Skill HeroFinalSkill
        {
            get { return herofinalskill; }
            set { herofinalskill = value; }
        }
        //勇者の回避
        private int heromiss;

        public int HeroMiss
        {
            get { return heromiss; }
            set { heromiss = value; }
        }

        //魔王の回避
        private int bossmiss;

        public int BossMiss {
            get { return bossmiss; }
            set { bossmiss = value; }
        }

        //魔王のスギ－ル1
        private Skill bossskill1;

        public Skill BossSkill1 
        {
            get { return bossskill1;}
            set { bossskill1 = value;}
        }


        //魔王のスギ－ル2
        private Skill bossskill2;

        public Skill BossSkill2 {
            get { return bossskill2; }
            set { bossskill2 = value; }
        }

        //魔王のFinalスギ－ル2
        private Skill bossfinalskill;

        public Skill BossFinalSkill {
            get { return bossfinalskill; }
            set { bossfinalskill = value; }
        }
        
        private string heroswordskillname;

        /// <summary>
        /// 勇者の剣技名前
        /// </summary>
        public string HeroSwordSkillName {
            get { return heroswordskillname; }
            set { heroswordskillname = value; }
        }

        private string heromagicname;

        /// <summary>
        /// 勇者の魔法名前
        /// </summary>
        public string HeroMagicName {
            get { return heromagicname; }
            set { heromagicname = value; }
        }

        private string herofinalskillname;

        /// <summary>
        /// 勇者の必殺技名前
        /// </summary>
        /// 
        public string HeroFinalSkillName {
            get { return herofinalskillname; }
            set { herofinalskillname = value; }
        }

        private float heroswordskillpower;

        /// <summary>
        /// 勇者の剣技のパワー
        /// </summary>
        public float HeroSwordSkillPower {
            get { return heroswordskillpower; }
            set { heroswordskillpower = value; }
        }

        private float heromagicpower;

        /// <summary>
        /// 勇者の魔法のパワー
        /// </summary>
        public float HeroMagicPower {
            get { return heromagicpower; }
            set { heromagicpower = value; }
        }


        private float herofinalskillpower;
        /// <summary>
        /// 勇者の必殺技のパワー
        /// </summary>
        /// 
        public float HeroFinalSkillPower {
            get { return herofinalskillpower; }
            set { herofinalskillpower = value; }
        }


        private string bossskillname1;

        /// <summary>
        /// 魔王のスギ－ル1名前
        /// </summary>
        /// 
        public string BossSkillName1 {
            get { return bossskillname1; }
            set { bossskillname1 = value; }
        }

        private string bossskillname2;

        /// <summary>
        /// 魔王のスギ－ル2名前
        /// </summary>
        /// 
        public string BossSkillName2 {
            get { return bossskillname2; }
            set { bossskillname2 = value; }
        }

        private string bossfinalskillname;

        /// <summary>
        /// 魔王のfinalスギ－ル名前
        /// </summary>
        /// 
        public string BossFinalSkillName {
            get { return bossfinalskillname; }
            set { bossfinalskillname = value; }
        }

        private float bossskill1power;

        /// <summary>
        /// 魔王のスギ－ル1のパワー
        /// </summary>
        /// 
        public float BossSkill1Power {
            get { return bossskill1power; }
            set { bossskill1power = value; }
        }

        private float bossskill2power;

        /// <summary>
        /// 魔王のスギ－ル2のパワー
        /// </summary>
        /// 
        public float BossSkill2Power {
            get { return bossskill2power; }
            set { bossskill2power = value; }
        }

        private float bossfinalskillpower;

        /// <summary>
        /// 魔王のfinalスギ－ルのパワー
        /// </summary>
        /// 

        public float BossFinalSkillPower {
            get { return bossfinalskillpower; }
            set { bossfinalskillpower = value; }
        }


        public float HeroAttackDamage(Soldier target)
        {
            float herodamage = DamageCalculator.CalculateDamage(this, target);                    
            
            target.HP -= herodamage;          

            return herodamage;
        }

        public float HeroSwordDamage1(Soldier target)
        {
            float herosworddamage1 = DamageCalculator.HeroSwordSkillDamage1(this, target);

            target.HP = target.HP - herosworddamage1;

            return herosworddamage1;
        }

        public float HeroSwordDamage2(Soldier target)
        {
            float herosworddamage2 = DamageCalculator.HeroSwordSkillDamage2(this, target);

            target.HP = target.HP - herosworddamage2;

            return herosworddamage2;
        }



        public float HeroFinalSkillDamage(Soldier target)
        {
            float herofinalskilldamage = DamageCalculator.HeroFinalSkillDamage(this,target);

            target.HP -= herofinalskilldamage;

            return herofinalskilldamage;

        }

        public float BossAttackDamage(Soldier target)
        {
            float bossattackdamage = DamageCalculator.CalculateDamage(this, target);

            target.HP -= bossattackdamage;

            return bossattackdamage;
        }

        public float BossSkill1Damage(Soldier target)
        {
            float bossskill1damage = DamageCalculator.BossSkill1Damage(this, target);

            target.HP -= bossskill1damage;

            return bossskill1damage;
        }

        public float BossSkill2Damage(Soldier target)
        {
            float bossskill2damage = DamageCalculator.BossSkill2Damage(this, target);

            target.HP -= bossskill2damage;

            return bossskill2damage;
        }

        public float BossFinalSkillDamage(Soldier target)
        {
            float bossfinalskilldamage = DamageCalculator.BossFinalSkillDamage(this, target);

            target.HP -= bossfinalskilldamage;

            return bossfinalskilldamage;

        }


    }
}