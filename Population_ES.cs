using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
	class Population_ES
	{
		
	
		public Generation_ES populationT { get; private set; }
		public Generation_ES populationP { get; set; }
		public Generation_ES populationO { get; private set; }
		public int mu { get; private set; }
		public int lambda { get; private set; }

		public Population_ES(int mu, int lambda) {
			this.populationP = new Generation_ES(mu, lambda);
			this.populationT = null;
			this.populationO = null;
			this.mu = mu;
			this.lambda = lambda;
		}
		public void PopulationFitnesses()
		{
			//since fitnesses calculated in constructors this does not have to be called
			this.populationP.CalculateFitnesses();
			if (this.populationT != null)
			{
				this.populationT.CalculateFitnesses();
			}
		}

		public void randomChoiceT()
		{
			DNA_ES[] temp = new DNA_ES[this.populationP.mu];
			for (int i = 0; i < this.populationP.chromosomesP.Length; i++)
			{
				temp[i] = this.populationP.getRandomEntity();
			}
			this.populationT = new Generation_ES(temp, this.mu, this.lambda);
		}

		public void mutatePopulationT()
		{
			for (int i = 0; i < this.populationT.mu; i++)
			{
				this.populationT.chromosomesP[i].Mutate(2, 1, i, false);
				this.populationO = populationT;
				//sparametryzować wywołanie Mutate
			}
		}
		public DNA_ES[] chooseBestPO(int Mu)
		{
			//wybrać mu najlepszych chromosomów
			Generation_ES combinedPopulation = this.populationP.addGeneration(this.populationO);
			combinedPopulation.CalculateFitnesses();
			//choose best fitness values and corresponding entities and their DNA
			DNA_ES[] muBestChromosomes = combinedPopulation.getMuBestChromosomes(Mu);
			return muBestChromosomes;

		}

		public override string ToString()
		{
			string res ="\nPopulation P chromosomes, fitnesses: ";
			foreach (var i in this.populationP.chromosomesP)
			{
				res += i + ";";
			}
			foreach (var m in this.populationP.fitnessesP)
			{
				res += m + ";";
			}
			res += "\nPopulation T: ";
			if (this.populationT != null)
			{
				foreach (var y in this.populationT.fitnessesP)
				{
					res += y + ";";
				}
				foreach (var l in this.populationT.chromosomesP)
				{
					res += l + ";";
				}
			}
			if (this.populationO != null)
			{
				res += "\nPopulation O: ";
				foreach (var z in this.populationO.fitnessesP)
				{
					res += z + ";";
				}
				foreach (var j in this.populationO.chromosomesP)
				{
					res += j + ";";
				}
			}
			return res;
		}
	}

}
