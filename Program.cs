using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
	class Program
	{
		

		static void Main(string[] args)
		{
			//Epoch epoch1 = new Epoch(10, 0.9,20, 0.02f,false);


			EvolutionStrategy1 ev1 = new EvolutionStrategy1(4, 4, 20);
			//Console.ReadLine();
			/*Random rand = new Random();
			double[] constr = { -1, 1, -1, 1 };
			DNA_ES prime = new DNA_ES(4, rand, constr, true);
			double[] chromosome = new double[prime.chromosomeX.Length];
			Array.Copy(prime.chromosomeX,chromosome,prime.chromosomeX.Length);
			Console.WriteLine(prime.ToString());
			DNA_ES copyPrime = new DNA_ES(chromosome,constr,rand);
			copyPrime.Mutate(2, 1, 1, false);
			Console.WriteLine(prime.ToString());
			Console.WriteLine(copyPrime.ToString());*/
			Console.ReadLine();












			/*Random rand = new Random();
			Console.WriteLine(rand);
			DNA parent1 = new DNA(10, rand, 10, true);
			DNA parent2 = new DNA(10, rand, 10, true);
			float calculateFitness = parent1.CalculateFitness();

			Console.WriteLine(calculateFitness);
			Console.WriteLine(parent1.ToString());
			Console.WriteLine(parent2.ToString());
			DNA[] firstchildren = parent1.Crossover(parent2, 4);
			foreach (DNA child in firstchildren){
				Console.WriteLine("Children:");
				Console.WriteLine(child.ToString());
			}*/
			/*Population population1 = new Population(10);
			Console.WriteLine(population1.initializePopulation());
			foreach (DNA i in population1.population_dna)
			{
		
				Console.WriteLine("Osobnik " + i.ToString());
			}
			population1.CalculateFitnesses();
			/*Console.WriteLine("Wybrane indeksy");
			foreach (int i in population1.russianWheel())
			{
				Console.Write(i+",");
			}*/
			/*Console.WriteLine("Wyliczone wartości funkcji przystosowania");
			float sum = 0;
			foreach (float i in population1.fitnesses)
			{
				Console.WriteLine(i);
				sum += i;
			}
			Console.WriteLine(sum / population1.fitnesses.Length);
			;
			population1.replaceGeneration(population1.Crossovers(0.75));
			Console.WriteLine("Populacja po wywołaniu crossoveru i zastąpieniu pokolenia");
			foreach (DNA i in population1.population_dna)
			{
				Console.WriteLine("Osobnik " + i.ToString());
			}
			Console.WriteLine("Wartości funkcji przystosowania po crossoverze");
			population1.CalculateFitnesses();
			float sum2 = 0;
			foreach (float i in population1.fitnesses)
			{
				Console.WriteLine(i);
				sum2 += i;
			}
			Console.WriteLine(sum2 / population1.fitnesses.Length);
			Console.ReadLine();*/

		}
	}
}
