using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
	class EvolutionStrategy1
	{
		public Population_ES population;
		public EvolutionStrategy1(int mu, int lambda, int epochs)
		{
			DNA_ES[] muBest = new DNA_ES[mu];
			for (int i = 0; i < epochs; i++)
			{
				
				if (i == 0)
				{
					this.population = new Population_ES(mu, lambda);
				}
				if (i > 0)
				{

					this.population.populationP = new Generation_ES(muBest, mu, lambda);
				}

				//this.population.PopulationFitnesses();
				Console.WriteLine(this.population.ToString());
				this.population.randomChoiceT();
				Console.WriteLine("-------------------------");
				Console.WriteLine(this.population.ToString());
				this.population.mutatePopulationT();
				Console.WriteLine("-------------------------");
				Console.WriteLine(this.population.ToString());
				Console.WriteLine("-------------------------");
				muBest = this.population.chooseBestPO(4);

				Console.WriteLine("-----------------------------");
				foreach (var k in muBest)
				{
					Console.WriteLine(k + ",");
				}
				//Console.ReadLine();
				Console.WriteLine("Koniec epoki {0}",i );
				
			}
		}
	}
}
