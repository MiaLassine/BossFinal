//Programme : Boss Final
//Creator : Mia Lassine 107B
//Date : 19/11/2026

using System.Data.SqlTypes;

namespace Boss_final;

/*
    CONSIGNES
    Vous développez le système de combat d'un RPG. Le héros affronte un boss final.

    Le boss possède 150 PV. Le héros possède une arme qui inflige 40 dégâts par attaque.

    Vous devez créer trois méthodes :

    1. CalculateWeaponDamage()
        - Reçoit la puissance de l'arme en paramètre.
        - Retourne les dégâts infligés (ici, la puissance de l'arme).
    2. CalculateRemainingHealth()
        - Reçoit les PV actuels du boss et les dégâts infligés.
        - Calcule les nouveaux PV du boss.
        - Retourne les nouveaux PV.
    3. DisplayBossStatus()
        - Reçoit les PV du boss.
        - Affiche son état :
        - Si ses PV sont supérieurs à 0 : "Le boss est toujours vivant !".
        - Sinon : "Félicitations ! Le boss est vaincu !".
    Dans Main() :
        1. Initialisez les PV du boss à 150.
        2. Calculez les dégâts de l'arme.
        3. Infligez les dégâts au boss.
        4. Affichez son état.
        5. Recommencez une deuxième attaque.
        6. Affichez à nouveau son état.
    BONUS :
        - Inspirez-vous de votre combat du cours de Logique & Algorithmes pour aller plus loin dans cet exercice
 */

class Program
{
    static void RoundDisplay()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Tour : ");
    }

    static void PlayerHealthDisplay()
    {
        Console.WriteLine("Player HP : ");
    }

    static void BossHealthDisplay()
    {
        Console.WriteLine("Boss HP : ");
    }

    static void PlayerRound()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Que décidez vous de faire (1 - 3) ?");
        Console.WriteLine("1. Attaquer");
        Console.WriteLine("2. Vous soigner");
        Console.WriteLine("3. Tentez de fuir");
    }

    static float CalculatePlayerDamage(float weaponPower, float playerPower)
    {
        float totalDamage = weaponPower + playerPower;
        return totalDamage;
    }

    static float CalculateMonsterDamage(float weaponPower, float playerPower)
    {
        float totalDamage = weaponPower * playerPower;
        return totalDamage;
    }

    static float MaxPlayerHealth(float playerHealth, float playerHealthShielded)
    {
        float  totalPlayerHealth = playerHealth + playerHealthShielded;
        return  totalPlayerHealth;
    }

    static float MaxMonsterHealth(float bossHealth, float bossHealthShielded)
    {
        float totalBossHealth = bossHealth + bossHealthShielded;
        return totalBossHealth;
    }

    static float PlayerDefense(float playerHelmet, float playerChesplate, float playerLeggings, float playerBoots)
    {
        float totalDefense = playerHelmet + playerChesplate + playerLeggings + playerBoots;
        return totalDefense;
    }

    static float UsePotion(float healingReceived)
    {
        return healingReceived;
    }

    static void Main(string[] args)
    {
        Random randomNumber = new Random(); //Création d'une variable instanciée pour générer un nombre aléatoire

        float playerDamage = CalculatePlayerDamage(750, 250); //Entre 10 et 20 (2)
        float playerHealth = MaxPlayerHealth(50, 50); //HP, Shield
        float playerDefense = PlayerDefense(4, 7, 6, 3) / 100 + 1; //Helmet + Chestplate + Leggings + Boots = Defense en %
        float playerHeal = UsePotion(50); //Heal par potion
        float bossDamage = CalculateMonsterDamage(5, 2); //Entre 2 et 4 (2)
        float bossHealth = MaxMonsterHealth(10000, 0); //HP, Shield

        int playerPotionStock = 0;
        float playerMoney = 300;
        string playerAnswer;

        do
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Vous possédez " + playerMoney + " pièce d'or et " + playerPotionStock + " potions.");
            Console.WriteLine("C'est 100 pièces d'or par potion.");
            Console.WriteLine("Voulez-vous acheter une potion de soin (\"Oui/...\") ?");
            Console.WriteLine("----------------------------------------------------------------------");
            playerAnswer = Console.ReadLine();
            if(playerMoney >= 100)
            {
                playerMoney -= 100;
                playerPotionStock += 1;
            }
            else if(playerMoney < 100)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Vous n'avez plus assez d'or !");
                Console.WriteLine("Vous ne pouvez plus achetez de potion!");
                break;
            }
        }
        while(playerAnswer == "Oui");

        int counter = 0; //Compteur de boucle
        float displayDamageBonus;

        float isRunAway = 1; //Random Number
        int runAwayChance = 10; //In %

        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Vous êtes face à un Boss !");

        do
        {
            counter += 1;

            RoundDisplay(); Console.WriteLine(counter);
            PlayerHealthDisplay(); Console.WriteLine(playerHealth);
            BossHealthDisplay(); Console.WriteLine(bossHealth);
            PlayerRound();

            Console.WriteLine("----------------------------------------------------------------------");
            playerAnswer = Console.ReadLine();
            
            if(playerAnswer == "1") //Attaquer
            {
                Console.WriteLine("----------------------------------------------------------------------");
                displayDamageBonus = playerDamage * (randomNumber.Next(1, 10) / 10 + 1); //Multiplie l'attaque de manière aléatoire entre 1 et 2
                bossHealth -= displayDamageBonus;
                Console.WriteLine("Vous infligez " + displayDamageBonus + " dégâts !");

                displayDamageBonus = bossDamage * (randomNumber.Next(1, 10) / 10 + 1);//Multiplie l'attaque de manière aléatoire entre 1 et 2
                playerHealth -= displayDamageBonus;
                Console.WriteLine("Vous subissez " + displayDamageBonus + " dégâts !");
            }

            else if(playerAnswer == "2") //Se soigner
            {
                if(playerPotionStock == 0)
                {
                    Console.WriteLine("Vous n'avez plus de potion !");
                    displayDamageBonus = bossDamage * (randomNumber.Next(1, 10) / 10 + 1);//Multiplie l'attaque de manière aléatoire entre 1 et 2
                    playerHealth -= displayDamageBonus;
                    Console.WriteLine("Vous subissez " + displayDamageBonus + " dégâts !");
                }

                else
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine("Vous décidez de vous soigner à l'abri des regards !");
                    playerHealth += playerHeal;
                    playerPotionStock -= 1;
                }
            }

            else if(playerAnswer == "3") //S'enfuir
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Vous décidez d'essayer de vous enfuir !");
                isRunAway = randomNumber.Next(1, 100/runAwayChance);
                if(isRunAway%runAwayChance == 0)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Tu n'as pas réussi à t'échapper !");
                }
            }
            else
            {
                Console.WriteLine("Erreur lors de l'encodage, veuillez réessayer");
            }
            Console.WriteLine("----------------------------------------------------------------------\n\n\n");

        }
        while(bossHealth >= 0 && playerHealth >= 0);
        if(isRunAway == 0)
        {
            Console.WriteLine("Tu as réussi à t'enfuir de justesse !");
        }
        if(bossHealth >= 0)
        {
            playerMoney += 1000;
            Console.WriteLine("Vous avez triomphé du mal !");
            Console.WriteLine("Vous Obtenez 1000 pièce d'or !");
            Console.WriteLine("Vous possédez désormais " + playerMoney + " pièce d'or.");
            Console.WriteLine("Vous obtenez " + randomNumber.Next(1, 3) + " fragment(s) d'âme de Boss");
        }
        if(playerHealth >= 0)
        {
            Console.WriteLine("Vous êtes mort.");
            Console.WriteLine("Vous perdez 100 pièces d'or !");
            Console.WriteLine("Vous possédez désormais " + playerMoney + " pièce d'or.");
        }
    }
}