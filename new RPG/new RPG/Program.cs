using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_RPG
{
    public class Program
    {
        static void Main(string[] args)
        {


            Random r = new Random();

            Soldier Hero = new Soldier();



            //プレイヤー
            Console.Write("名前を入力してください：");
            Hero.HeroName = Console.ReadLine();

            Hero.Attack = 180.0f;
            Hero.HP = 3200.0f;
            Hero.MAXHP = 3200.0f;
            Hero.Defence = 120.0f;
            



            //魔王
            Soldier Boss = new Soldier();
            string Bossname = "魔王";
            Boss.Attack = 200.0f;
            Boss.HP = 7200.0f;
            Boss.MAXHP = 7200.0f;
            Boss.Defence = 100.0f;


            Skill ss = new Skill();
            ss.HeroSwordSkillName = "はやぶさぎり";
            Hero.HeroSwordSkill = ss;
            Skill mgc = new Skill();
            mgc.HeroMagicName = "ベホイミ";
            mgc.HeroMagicPower = 650.0f;
            Hero.HeroMagic = mgc;
            Skill FS = new Skill();
            FS.HeroFinalSkillName = "ギガスラッシュ";
            Hero.HeroFinalSkill = FS;

            



            //回避率
            Hero.HeroMiss = 15;



            Skill BS1 = new Skill();
            BS1.BossSkillName1 = "灼熱吐息";
            Boss.BossSkill1 = BS1;

            Skill BS2 = new Skill();
            BS2.BossSkillName2 = "メラゾーマ";
            Boss.BossSkill2 = BS2;

            Skill BFS = new Skill();
            BFS.BossFinalSkillName = "魔神斬";
            Boss.BossFinalSkill = BFS;

            Boss.BossMiss = 5;

          

            Console.WriteLine("============================================勇者VS魔王=============================================");
            Console.WriteLine(Hero.HeroName + "，攻撃力：" + Hero.Attack + ", HP：" + Hero.HP + "，\n剣技：" + ss.HeroSwordSkillName + "，\n魔法：" + mgc.HeroMagicName + "，\n必殺技：" + FS.HeroFinalSkillName+"\n" );
            Console.WriteLine(Bossname + "，攻撃力：" + Boss.Attack + "，HP：" + Boss.HP + "，\nスギ－ル1：" + BS1.BossSkillName1 + " ，\nスギ－ル2：" + BS2.BossSkillName2  + "，\nfinalスギ－ル：" + BFS.BossFinalSkillName+"\n" );
            Console.WriteLine("ボタンを押して戦闘開始");
            Console.ReadKey();

            
            
            int count = 1;

            
            
            while (true)
            {
                Console.WriteLine("==========================Round" + count + "============================");
                System.Threading.Thread.Sleep(1500);

                
                
                //勇者の攻撃
                if (r.Next(0, 101) < Boss.BossMiss)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("【" + Hero.HeroName + "】の攻撃!!,【" + Bossname + "】は攻撃を回避されました");
                }
                else
                {
                    int HeroSkillProbability1 = r.Next(0, 100);

                    if (HeroSkillProbability1 > 85)//勇者のfinalskill発動
                    {
                        float FinalSkilldamage = Hero.HeroFinalSkillDamage(Boss);
                        
                        if (Boss.HP<=0)
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("【" + Hero.HeroName + "】は【" + FS.HeroFinalSkillName + "】を発動した,【" + Bossname + "】に" + FinalSkilldamage + "のダメ－ジ!\n【" + Bossname + "】のHPは0になった");
                        }
                        else                     
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("【" + Hero.HeroName + "】は【" + FS.HeroFinalSkillName + "】を発動した,【" + Bossname + "】に" + FinalSkilldamage + "のダメ－ジ!\n【" + Bossname + "】のHPは" + (Boss.HP) + "です");
                        }
                       
                        Console.WriteLine();
                        
                       
                    }
                    else if (HeroSkillProbability1 >= 40 && HeroSkillProbability1 <= 80)//剣技と魔法を発動
                    {
                        int SkillProbability2 = r.Next(0, 100);

                        if (SkillProbability2 >= 0 && SkillProbability2 < 50)
                        {
                            
                            

                            float SwordSkilldamage1 = Hero.HeroSwordDamage1(Boss);
                            float SwordSkilldamage2 = Hero.HeroSwordDamage2(Boss);

                            if (Boss.HP<=0)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("【" + Hero.HeroName + "】は【" + ss.HeroSwordSkillName + "】を発動する!!\n【" + Hero.HeroName + "】の連続攻撃!!【" + Bossname + "】に" + SwordSkilldamage1 + "のダメ－ジ!\n【" + Bossname + "】のHPは0です\n【" + Bossname + "】に" + SwordSkilldamage2 + "のダメ－ジ!\n【" + Bossname + "】のHPは0です");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("【" + Hero.HeroName + "】は【" + ss.HeroSwordSkillName + "】を発動する!!\n【" + Hero.HeroName + "】の連続攻撃!!【" + Bossname + "】に" + SwordSkilldamage1 + "のダメ－ジ!\n【" + Bossname + "】のHPは" + (Boss.HP+SwordSkilldamage2) + "です\n【" + Bossname + "】に" + SwordSkilldamage2 + "のダメ－ジ!\n【" + Bossname + "】のHPは" + (Boss.HP) + "です");
                            }
            
                            Console.WriteLine();
                            
                            
                        }
                        else
                        {
                            

                            Hero.HP += mgc.HeroMagicPower;

                            if(Hero.HP > Hero.MAXHP)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Hero.HP = Hero.MAXHP;
                                Console.WriteLine("【" + Hero.HeroName + "】の【" + mgc.HeroMagicName + "】!!【" + Hero.HeroName + "】のHP回復完全した\n【" + Hero.HeroName + "】のHPは" + (Hero.MAXHP ) + "です");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("【" + Hero.HeroName + "】は【" + mgc.HeroMagicName + "】を発動する!!【" + Hero.HeroName + "】" + mgc.HeroMagicPower + "のHP回復した\n【" + Hero.HeroName + "】のHPは" + (Hero.HP ) + "です");
                            }


                            
                            Console.WriteLine();

                            
                        }
                    }
                    else//攻撃
                    {
                        
                        
                        float herodamage = Hero.HeroAttackDamage(Boss);
                        if (Boss.HP<=0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("【" + Hero.HeroName + "】の攻撃！！！【" + Bossname + "】に" + herodamage + "のダメ－ジ，【" + Bossname + "】のHPは0になった");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("【" + Hero.HeroName + "】の攻撃！！！【" + Bossname + "】に" + herodamage + "のダメ－ジ，【" + Bossname + "】のHPは" + (Boss.HP) + "です");
                        }
                        
                        Console.WriteLine();

                    }

                    //魔王HPの判定
                    if (Boss.HP <= 0)
                    {

                        Console.WriteLine("【" + Bossname + "】を倒した!!!!!世界は再び光を得る！！！！！");
                        break;
                    }
                }
                //魔王の攻撃

                System.Threading.Thread.Sleep(1500);
                
                if (r.Next(0, 101) < Hero.HeroMiss)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("【" + Bossname + "】の攻撃!!!,【" + Hero.HeroName + "】回避成功");
                }
                else
                {
                    int BossSkillProbability1 = r.Next(0, 100);

                    if (BossSkillProbability1 > 85)//魔王のfinalskill
                    {
                        
                        float bossfinalskilldamage = Boss.BossFinalSkillDamage(Hero);
                        if (Hero.HP<=0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("【" + Bossname + "】の【" + BFS.BossFinalSkillName + "】!!!【" + Hero.HeroName + "】に" + bossfinalskilldamage + "のダメージ,【" + Hero.HeroName + "】のHPは0です");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("【" + Bossname + "】の【" + BFS.BossFinalSkillName + "】!!!【" + Hero.HeroName + "】に" + bossfinalskilldamage + "のダメージ,【" + Hero.HeroName + "】のHPは" + (Hero.HP) + "です");
                        }
                        
                        Console.WriteLine();
                        
                    }
                    else if (BossSkillProbability1 >= 40 && BossSkillProbability1 <= 80)//スギ－ル1と2
                    {
                        int BossSkillProbability2 = r.Next(0, 100);
                        if (BossSkillProbability2 >= 0 && BossSkillProbability2 < 50)
                        {
                            
                            float bossskill1damage = Boss.BossSkill1Damage(Hero);
                            if (Hero.HP<=0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("【" + Bossname + "】の【" + BS1.BossSkillName1 + "】!!!【" + Hero.HeroName + "】に" + bossskill1damage + " のダメージ,【" + Hero.HeroName + "】のHPは0です");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("【" + Bossname + "】の【" + BS1.BossSkillName1 + "】!!!【" + Hero.HeroName + "】に" + bossskill1damage + " のダメージ,【" + Hero.HeroName + "】のHPは" + (Hero.HP) + "です");
                            }
                            
                            Console.WriteLine();
                           
                           
                        }
                        else
                        {
                            
                            float bossskill2damage = Boss.BossSkill2Damage(Hero);

                            if (Hero.HP<=0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("【" + Bossname + "】の【" + BS2.BossSkillName2 + "】!!!【" + Hero.HeroName + "】に" + bossskill2damage + " のダメージ,【" + Hero.HeroName + "】のHPは0です");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("【" + Bossname + "】の【" + BS2.BossSkillName2 + "】!!!【" + Hero.HeroName + "】に" + bossskill2damage + " のダメージ,【" + Hero.HeroName + "】のHPは" + (Hero.HP) + "です");
                            }

                            
                            Console.WriteLine();
                          
                        }
                    }
                    else//普通攻击
                    {
                        
                        float bossattackdamage = Boss.BossAttackDamage(Hero);

                        if (Hero.HP<=0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("【" + Bossname + "】の攻撃！！！【" + Hero.HeroName + "】に" + bossattackdamage + "のダメ－ジ，【" + Hero.HeroName + "】のHPは0です");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("【" + Bossname + "】の攻撃！！！【" + Hero.HeroName + "】に" + bossattackdamage + "のダメ－ジ，【" + Hero.HeroName + "】のHPは" + (Hero.HP) + "です");
                        }
                        
                        Console.WriteLine();
                       
                    }
                    if (Hero.HP <= 0)
                    {
                        

                        Console.WriteLine("【" + Hero.HeroName + "】死んだ！【" + Bossname + "】世界を支配した");
                        break;
                    }
                }



                count++;
            }
            Console.ReadKey();

        }
    }
}