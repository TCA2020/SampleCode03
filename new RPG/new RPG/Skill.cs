using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_RPG
{
    public class Skill
    {
        private string heroswordskillname;

        /// <summary>
        /// 勇者の剣技名前
        /// </summary>
        public string HeroSwordSkillName
        {
            get { return heroswordskillname; }
            set { heroswordskillname = value; }
        }

        private string heromagicname;

        /// <summary>
        /// 勇者の魔法名前
        /// </summary>
        public string HeroMagicName
        {
            get { return heromagicname; }
            set { heromagicname = value; }
        }

        private string herofinalskillname;

        /// <summary>
        /// 勇者の必殺技名前
        /// </summary>
        /// 
        public string HeroFinalSkillName
        {
            get { return herofinalskillname;}
            set { herofinalskillname = value;}
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
        public string BossSkillName1 
        {
            get {return bossskillname1; }
            set { bossskillname1 = value;}
        }

        private string bossskillname2;

        /// <summary>
        /// 魔王のスギ－ル2名前
        /// </summary>
        /// 
        public string BossSkillName2 
        {
            get {return bossskillname2; }
            set { bossskillname2 = value;}
        }

        private string bossfinalskillname;

        /// <summary>
        /// 魔王のfinalスギ－ル名前
        /// </summary>
        /// 
        public string BossFinalSkillName 
        {
            get {return bossfinalskillname; }
            set { bossfinalskillname = value;}
        }  

        private float bossskill1power;

        /// <summary>
        /// 魔王のスギ－ル1のパワー
        /// </summary>
        /// 
        public float BossSkill1Power 
        {
            get { return bossskill1power;}
            set { bossskill1power = value;}
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

        public float BossFinalSkillPower 
        {
            get {return bossfinalskillpower ;}
            set { bossfinalskillpower = value;}
        }

    }
}