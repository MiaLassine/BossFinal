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
    static void remainingDisplays(int counter)
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Tour :" + counter);

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
        int playerHealth = MaxPlayerHealth(100, 100);
        int playerDefense = PlayerDefense(4, 7, 6, 3) / 100 + 1; //Defense en %
        int healPlayer = UsePotion(50); //Heal par potion
        int bossDamage = CalculateMonsterDamage(5, 2); //Entre 2 et 4 (2)
        int bossHealth = MaxMonsterHealth(10000, 0);

        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Vous êtes face à un Boss !");
        Console.WriteLine("Que décidez vous de faire (1 - 3) ?");
        Console.WriteLine("1. Attaquer");
        Console.WriteLine("2. Vous soigner");
        Console.WriteLine("3. Tentez de fuir");
        Console.WriteLine("----------------------------------------------------------------------");
        string? stringPlayerAnswer = Console.ReadLine();
        int intPlayerAnswer = Convert.ToInt32(stringPlayerAnswer);
        Console.WriteLine("----------------------------------------------------------------------");
        do
        {
            if(intPlayerAnswer == '1')
            {

            }
            else if(intPlayerAnswer == '2')
            {

            }
            else if(intPlayerAnswer == '3')
            {

            }
            else
            {
                Console.WriteLine("Erreur d'encodage, veuillez réessayez");
            }
        }
        while(bossHealth > 0 && playerHealth > 0);
    }
}