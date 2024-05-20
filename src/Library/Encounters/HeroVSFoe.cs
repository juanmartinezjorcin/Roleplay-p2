using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace RoleplayGame
{
    public class HeroVSFoe : IEncounter
    {
        public List<Hero> heroes = new List<Hero>(); // era protected, lo tuvimos que cambiar para los tests
        public List<Foe> foes = new List<Foe>(); // aca tambien
        public HeroVSFoe(){            

        }

        public void DoEncounter()
        {
            int loop = 0;
            while (loop == 0)
            {
                FoesAttack();
                if (heroes.Count == 0)
                {
                    Console.WriteLine("Foes Wins!");
                    loop++;
                    break;
                }
                HeroesAttack();
                if (foes.Count == 0)
                {
                    loop++;
                    Console.WriteLine("Heroes Wins!");
                    foreach (Hero hero in heroes)
                    {
                        hero.Cure();
                    }
                    break;
                }  
            }
            Console.WriteLine("The encounter has ended");
        }
        public void FoesAttack()
        {
            /// <summary>
            /// Cada Foe ataca unicamente un heroe. Si hay un sólo héroe, todos los enemigos atacan al mismo. Si hay más de un enemigo y más de un héroe, el primer enemigo ataca al primer héroe, el segundo enemigo ataca al segundo héroe, y así sucesivamente.
            /// Se eliminan los heroes una vez vencidos
            /// </summary>
            int j = 0;
            for (int i = 0; i < foes.Count; i++)
            {
                if(heroes[j].Health != 0)
                {
                    foes[i].Attack(heroes[j]);
                    j++;
                    if (j >= heroes.Count) { j=0; }
                    continue;
                }
                else
                {
                    i--;
                    j++;
                    if (j >= heroes.Count) { j=0; }
                    continue;
                }
            }
            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Health == 0)
                {
                    RemoveCharacter(heroes[i]);
                    i--;
                }
            }

        }
        /// <summary>
        /// Todos los héroes atacan a cada uno de los enemigos 1 vez.
        /// Se eliminan los enemigos una vez vencidos y se suman los puntos de victoria correspondientes
        /// </summary>
        public void HeroesAttack()
        {
            foreach (Hero hero in heroes)
            {
                for (int i = 0; i < foes.Count; i++)
                {
                    if (foes[i].Health > 0)
                    {
                        hero.Attack(foes[i]);
                    }
                    if (foes[i].Health == 0)
                    {
                        hero.checkForVP(foes[i]);
                        RemoveCharacter(foes[i]);
                        i--;
                    }
                }
            }
        }
        public void AddCharacter(Character character)
        {
            if(character is Hero)
            {
                this.heroes.Add((Hero)character);
            }
            else if(character is Foe)
            {
                this.foes.Add((Foe)character);
            }
            else{
                Console.WriteLine("Character not Hero or Foe");
            }
        }

        public void RemoveCharacter(Character character)
        {
            if(character is Hero)
            {
                this.heroes.Remove((Hero)character);
            }
            else if(character is Foe)
            {
                this.foes.Remove((Foe)character);
            }
        }
    }
}

