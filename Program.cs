//Programme : Boss Final
//Creator : Mia Lassine 107B
//Date : 19/11/2026

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

    static int CalculatePlayerDamage(int weaponPower, int playerPower)
    {
        int totalDamage = weaponPower * playerPower;
        return totalDamage;
    }

    static int CalculateMonsterDamage(int weaponPower, int playerPower)
    {
        int totalDamage = weaponPower * playerPower;
        return totalDamage;
    }

    static int MaxPlayerHealth(int playerHealth, int playerHealthShielded)
    {
        int  totalPlayerHealth = playerHealth + playerHealthShielded;
        return  totalPlayerHealth;
    }

    static int MaxMonsterHealth(int bossHealth, int bossHealthShielded)
    {
        int totalBossHealth = bossHealth + bossHealthShielded;
        return totalBossHealth;
    }

    static int PlayerDefense(int playerHelmet, int playerChesplate, int playerLeggings, int playerBoots)
    {
        int totalDefense = playerHelmet + playerChesplate + playerLeggings + playerBoots;
        return totalDefense;
    }

    static int UsePotion(int healingReceived)
    {
        return healingReceived;
    }

    static void Main(string[] args)
    {
        Random randomNumber = new Random(); //Création d'une variable instanciée pour générer un nombre aléatoire

        int playerDamage = CalculatePlayerDamage(100, 10); //Entre 10 et 20 (2)
        int playerHealth = MaxPlayerHealth(50, 50); //HP, Shield
        int playerDefense = PlayerDefense(4, 7, 6, 3) / 100 + 1; //Helmet + Chestplate + Leggings + Boots = Defense en %
        int healPlayer = UsePotion(50); //Heal par potion
        int bossDamage = CalculateMonsterDamage(5, 2); //Entre 2 et 4 (2)
        int bossHealth = MaxMonsterHealth(10000, 0); //HP, Shield

        int counter = 0; //Compteur de boucle

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
            string? playerAnswer = Console.ReadLine();
            
            if(playerAnswer == "1") //Attaquer
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Vous décidez d'attaquer !");

            }

            else if(playerAnswer == "2") //Se soigner
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Vous décidez de vous soigner !");
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
        while(bossHealth > 0 && playerHealth > 0);
        if(isRunAway == 0)
        {
            Console.WriteLine("Tu as réussi à t'enfuir de justesse !");
        }
    }
}