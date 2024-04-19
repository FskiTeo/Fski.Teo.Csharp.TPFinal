using CommandLine;
using Fiminski.RG.DAL.DAL;
using Fiminski.RG.DAL.Model;
using Fiminski.RG.DAL.Service;
using System.Runtime.CompilerServices;

namespace CommandLineTest
{
    class Program
    {
        class Options
        {
            [Option("import", HelpText = "Specify this option to trigger the import functionality.")]
            public bool Import { get; set; }

            [Value(0, MetaName = "FilePath", HelpText = "File path to import.")]
            public string FilePath { get; set; }

            [Option("choix", HelpText = "Choix de la ville")]
            public bool Choix { get; set; }

            [Value(0, MetaName = "Ville", HelpText = "Nom de la ville")]
            public string Ville { get; set; }
        }

        static void Main(string[] args)
        {
            List<string> inputLines = new List<string>();

            var _context = new ApplicationDBContext();
            var espionnageService = new EspionnageService(_context);

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    if (o.Import)
                    {
                        if (!string.IsNullOrWhiteSpace(o.FilePath))
                        {
                            
                            Console.WriteLine($"Importing file: {o.FilePath}");

                            if (File.Exists(o.FilePath))
                            {

                                try
                                {
                                    using(StreamReader sr = new StreamReader(o.FilePath))
                                    {
                                        string line;
                                        while ((line = sr.ReadLine()) != null)
                                        {
                                            inputLines.Add(line);
                                        }

                                        Console.WriteLine($"Nombre de lignes lues : {inputLines.Count}");

                                        for(int i = 0; i < inputLines.Count; i++)
                                        {
                                            string[] inputLineList = inputLines[i].Split("; ");
                                            string nom = inputLineList[0];
                                            string code = inputLineList[1];
                                            espionnageService.AddEspion(nom, code);
                                        }

                                        Console.WriteLine("Tous vos espions ont correctement été ajoutés !");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Erreur lors de la lecure du fichier {o.FilePath} : {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Erreur : Le fichier \"{o.FilePath}\" n'existe pas.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erreur : Le chemin du fichier n'a pas été spécifié.");
                        }
                    }
                    else if (o.Choix)
                    {
                        if (!string.IsNullOrWhiteSpace(o.Ville))
                        {
                            List<Espion> espions = espionnageService.GetEspionsByVille(o.Ville);

                            foreach (Espion espion in espions)
                            {
                                Console.WriteLine(espion.Name + " " + espion.Code);
                            }
                        }                        
                    }
                    else
                    {
                        Console.WriteLine("Hello");
                    }
                })
                .WithNotParsed(errors =>
                {
                    Console.WriteLine("Utilisation : Application.exe --import <FilePath>");
                });
        }
    }
}
