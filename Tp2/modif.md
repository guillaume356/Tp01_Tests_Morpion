# TP - 1 Reprise d'un projet Legacy

## I - Les difficultés liées à la validation

### 1. Redondance de code

Le code a pour structure un fichier Program.cs pour gérer le choix du jeu et un fichier Morpion.cs et Puissance4.cs qui s'occupe respectivement de la logique et de l'affichage de chaque jeu. 

Le problème est que certaines méthodes font globalement la même chose.

Méthode affichePlateau du Morpion :

```csharp
public void affichePlateau()
{
    Console.WriteLine();
    Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}");
    Console.WriteLine("    |     |");
    Console.WriteLine("----+-----+----");
    Console.WriteLine("    |     |");
    Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}");
    Console.WriteLine("    |     |");
    Console.WriteLine("----+-----+----");
    Console.WriteLine("    |     |");
    Console.WriteLine($" {grille[2, 0]}  |  {grille[1, 1]}  |  {grille[0, 2]}");
}
```

Méthode affichePlateau du Puissance 4 :

```csharp
public void affichePlateau()
{
    Console.WriteLine();
    Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}  |  {grille[0, 3]}  |  {grille[0, 4]}  |  {grille[0, 5]}  |  {grille[0, 6]}");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine("----+-----+-----+-----+-----+-----+----");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}  |  {grille[1, 3]}  |  {grille[1, 4]}  |  {grille[1, 5]}  |  {grille[1, 6]}");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine("----+-----+-----+-----+-----+-----+----");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine($" {grille[2, 0]}  |  {grille[2, 1]}  |  {grille[2, 2]}  |  {grille[2, 3]}  |  {grille[2, 4]}  |  {grille[2, 5]}  |  {grille[1, 6]}");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine("----+-----+-----+-----+-----+-----+----");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine($" {grille[3, 0]}  |  {grille[3, 1]}  |  {grille[3, 2]}  |  {grille[3, 3]}  |  {grille[3, 4]}  |  {grille[3, 5]}  |  {grille[1, 6]}");
    Console.WriteLine("    |     |     |     |     |     |");
    Console.WriteLine("----+-----+-----+-----+-----+-----+----");
}
```

Comme on peut le voir, la logique est la même ce qui entraine un code redondant. C'est un problème car en cas d'ajout d'une nouvelle grille pour un autre jeu, il faudra recréer une méthode affichePlateau() ce qui fait perdre du temps à l'équipe de dev. 

Même cas pour les deux méthodes tourJoueur et tourJoueur2 qui sont presque identique à la différence du symbole utilisé par chaque joueur

```cs
public void tourJoueur()
{
 var (row, column) = (0, 0);
 bool moved = false;

while (!quiterJeu && !moved)
{
    Console.Clear();
    affichePlateau();
    Console.WriteLine();
    Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
    Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.Escape:
            quiterJeu = true;
            Console.Clear();
            break;

        case ConsoleKey.RightArrow:
            if (column >= 2)
            {
                column = 0;
            }
            else
            {
                column = column + 1;
            }
            break;

        case ConsoleKey.LeftArrow:
            if (column <= 0)
            {
                column = 2;
            }
            else
            {
                column = column - 1;
            }
            break;

        case ConsoleKey.UpArrow:
            if (row <= 0)
            {
                row = 2;
            }
            else
            {
                row = row - 1;
            }
            break;

        case ConsoleKey.DownArrow:
            if (row >= 2)
            {
                row = 0;
            }
            else
            {
                row = row + 1;
            }
            break;
        case ConsoleKey.Enter:
            if (grille[row, column] is ' ')
            {
                grille[row, column] = 'X';
                //grille[row, column] = 'O'; Seul changement
                moved = true;
                quiterJeu = false;
            }
            break;
    }

}
```

Les deux méthodes prennent de la place pour rien. Une seule fait la même chose que l'autre.

### 2. Présence de code mort

Deux morceaux de code mort sont également présents, on ne peut savoir à quoi ce code faisait référence ni pourquoi il a été commenté et conservé. De plus ces deux morceaux de codes sont les mêmes.

```cs
                    //case ConsoleKey.UpArrow:
                    //    if (row <= 0)
                    //    {
                    //        row = 3;
                    //    }
                    //    else
                    //    {
                    //        row = row - 1;
                    //    }
                    //    break;

                    //case ConsoleKey.DownArrow:
                    //    if (row >= 3)
                    //    {
                    //        row = 0;
                    //    }
                    //    else
                    //    {
                    //        row = row + 1;
                    //    }
                    //    break; 
```

### 3. Logique de manipulation des entrées utilisateur

La gestion des entrées utilisateur dans le fichier Program.cs est réalisée de manière peu intuitive, notamment à travers l'utilisation de structures de contrôle goto, ce qui rend le flux du programme difficile à suivre et à déboguer. L'absence d'une structure de contrôle plus moderne et plus lisible pour la navigation entre les différentes parties du jeu complique la maintenance et l'extension du code.

```cs
        GetKey:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.X:
                    Morpion morpion = new Morpion();
                    morpion.BoucleJeu();
                    break;
                case ConsoleKey.P:
                    PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
                    puissanceQuatre.BoucleJeu();
                    break;
                default:
                    goto GetKey;
            }
```

### 4. Manque de modularité et de séparation des préoccupations

Les fichiers Morpion.cs et PuissanceQuatre.cs mélangent la logique du jeu avec l'affichage et la gestion des entrées utilisateur. Cette approche viole le principe de responsabilité unique et rend le code moins modulaire. Il devient plus difficile d'apporter des modifications à l'un des aspects du jeu (logique, affichage, interaction) sans risquer d'affecter les autres.

Prenons l'exemple de la méthode affichePlateau :

```cs
        public void affichePlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[1, 1]}  |  {grille[0, 2]}");
        }
```

Cette méthode illustre un manque de séparation entre la logique de jeu (manipulation des grilles) et l'affichage. Idéalement, la logique de jeu devrait être isolée de l'interface utilisateur, permettant par exemple de remplacer facilement la console par une interface graphique sans avoir à modifier la logique sous-jacente.

### 5. Conditions de victoire

Les conditions de victoire et les vérifications d'égalité sont gérées par des blocs de code spécifiques à chaque jeu, ce qui pourrait entraîner une duplication inutile et rendre ces vérifications difficiles à maintenir. Une approche plus centralisée ou l'utilisation de stratégies communes pourrait simplifier la gestion des états de jeu.

```cs
        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
             grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c ||
             grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c ||
             grille[2, 0] == c && grille[1, 1] == c && grille[0, 2] == c;
```

## II - Les méthodes de résolution de ces problèmes

Pour valider l'existant et corriger les bugs éventuels identifiés dans la première partie de ce rapport, plusieurs stratégies et actions correctives doivent être mises en œuvre. Ces actions visent à améliorer la qualité du code, sa maintenabilité, et sa robustesse face aux bugs rencontrés.

### A. Validation et Correction de l'Existant

1. **Analyse et Refactorisation du Code** :
   
   - **Redondance de Code** : Implémenter des méthodes génériques pour les fonctionnalités communes entre les jeux, telles que `affichePlateau`, pour réduire la duplication.
   - **Code Mort** : Supprimer tout code commenté ou inutilisé pour clarifier la base de code et éviter toute confusion.
   - **Modularité et Séparation des Préoccupations** : Adopter le modèle MVC pour séparer la logique de jeu (Modèle) de l'affichage (Vue) et de la gestion des entrées (Contrôleur).

2. **Révision des Conditions de Victoire** :
   
   - Revoir les implémentations des méthodes `verifVictoire` pour chaque jeu afin de corriger les logiques de détection de victoire défaillantes.
   - Écrire des tests unitaires spécifiques pour chaque scénario de victoire afin de valider l'efficacité et la fiabilité de ces méthodes.

### B. Correction des Bugs Spécifiques

1. **Bugs de Conditions de Victoire** :
   
   - Effectuer une revue de code minutieuse pour identifier les erreurs logiques.
   - Utiliser des matrices ou des tableaux de test pour simuler toutes les combinaisons de victoire possibles et garantir la fiabilité des vérifications.

2. **Placement Automatique des Pions** :
   
   - **Analyse de la Logique de Tour** : Vérifier le mécanisme de changement de tour pour s'assurer qu'un mouvement ne soit enregistré qu'après une action valide de l'utilisateur.
   - **Debugging Pas à Pas** : Suivre le flux d'exécution du jeu lors du placement des pions pour identifier toute modification d'état non désirée ou appel de fonction erroné.

### C. Mise en Place d'un Cadre de Test

1. **Développement de Tests Unitaires et d'Intégration** : Mettre en place un ensemble complet de tests pour chaque composant du jeu, afin de détecter et corriger les bugs de manière proactive.
2. **Intégration Continue (CI)** : Utiliser des outils de CI pour automatiser les tests et s'assurer que chaque modification du code maintient la qualité et la fonctionnalité globales.

## III - Le développement des fonctionnalités manquantes

Pour enrichir le projet avec une option de jeu contre l'ordinateur et la possibilité de sauvegarder une partie en cours, il est crucial d'adopter une démarche structurée respectant les exigences de qualité et de robustesse. Ci-dessous, la procédure pour intégrer ces nouvelles fonctionnalités :

### A. Intégration d'un Joueur Contrôlé par l'Ordinateur

1. **Conception d'une IA de Niveaux Variés** : Pour le jeu contre l'ordinateur, plusieurs niveaux de difficulté sont développés. Au niveau le plus basique, l'ordinateur réalise des mouvements aléatoires. Pour des niveaux supérieurs, des algorithmes de décision plus élaborés, tels que Minimax, sont intégrés pour évaluer les mouvements possibles afin de maximiser les chances de victoire de l'IA tout en minimisant celles de l'adversaire.

2. **Architecture Modulaire** : L'architecture du programme est modifiée pour permettre l'intégration d'un joueur IA. Une interface ou une classe abstraite est utilisée pour définir le comportement commun entre un joueur humain et l'IA, facilitant ainsi le basculement entre les deux modes de jeu.

3. **Paramétrage du Niveau de Difficulté** : Un mécanisme permet aux joueurs de choisir le niveau de difficulté de l'IA avant le début de la partie, via un menu de sélection ou un paramètre lors du lancement d'une nouvelle partie.

### B. Système de Sauvegarde et de Persistance

1. **Conception du Système de Sauvegarde** : Un mécanisme pour sauvegarder l'état actuel du jeu en cours est implémenté, incluant la sérialisation de l'état de la grille, du tour actuel, et d'autres métadonnées nécessaires pour reprendre une partie.

2. **Choix du Format de Sauvegarde** : Un format de sauvegarde comme JSON ou XML est choisi pour la facilité de manipulation et la portabilité des données. Des méthodes de sérialisation et de désérialisation correspondantes sont développées.

3. **Gestion des Fichiers de Sauvegarde** : Une fonctionnalité pour enregistrer et charger les parties depuis des fichiers est développée. Il est vérifié que l'utilisateur peut choisir de reprendre une partie sauvegardée au démarrage du jeu.

### C. Tests et Assurance Qualité

1. **Tests Unitaires et d'Intégration** : Des tests unitaires sont développés pour chaque nouvelle fonctionnalité, couvrant les cas d'utilisation typiques ainsi que les cas limites. Pour l'IA, les différents niveaux de difficulté sont testés pour assurer la cohérence des choix de l'ordinateur.

2. **Tests de Performances** : Il est assuré que l'intégration de l'IA et du système de sauvegarde ne dégrade pas les performances du jeu, particulièrement pour les niveaux de difficulté élevés de l'IA.

3. **Revue de Code et Tests Manuels** : Des revues de code sont organisées pour chaque ajout majeur, et des tests manuels sont effectués pour simuler des scénarios de jeu réels, y compris la reprise de partie à partir de sauvegardes.

En suivant ces étapes et en se concentrant sur la qualité et la robustesse du développement, le projet sera capable d'offrir une expérience de jeu améliorée et flexible, répondant ainsi aux attentes des parties prenantes. L'adoption de pratiques de développement rigoureuses, la mise en œuvre de tests exhaustifs, et l'implication des utilisateurs finaux dans le processus de test sont essentielles pour recueillir des retours précieux et garantir le succès de l'implémentation.
