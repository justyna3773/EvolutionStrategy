using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
	class Generation_ES
	{
		public DNA_ES[] chromosomesP { get;}
		public double[] fitnessesP { get; private set; }
		public double[] fitnessesS { get; private set; }
		public int mu { get; private set; }
		public int lambda { get; private set; }
		private Random random;
		public Generation_ES(int mu, int lambda)
		{
			Random randomDNA = new Random();
			this.random = new Random();
			this.mu = mu;
			this.lambda = lambda;
			this.chromosomesP = new DNA_ES[this.mu];
			this.fitnessesP = new double[this.chromosomesP.Length];
			double[] constr = { -1d, 1d, -1d, 1d };
			for (int i = 0; i < mu; i++)
			{
				chromosomesP[i] = new DNA_ES(2, randomDNA, constr, true);
			}
			CalculateFitnesses();
		}
		public Generation_ES(DNA_ES[] chromosomes,int mu, int lambda)
		{
			this.chromosomesP = chromosomes;
			this.mu = mu;
			this.lambda = lambda;
			this.random = new Random();

			this.fitnessesP = new double[this.chromosomesP.Length];
			CalculateFitnesses();
		}
		public void CalculateFitnesses()
		{
			for (int i = 0; i < chromosomesP.Length; i++)
			{
				fitnessesP[i] = chromosomesP[i].FitnessX();
			}
		}

		public void CalculateSigmaFitnesses()
		{
		}

		public DNA_ES getRandomEntity()
		{
			int randInd = this.random.Next(0, this.chromosomesP.Length - 1);
			Console.WriteLine("\nrandom index: {0}", randInd);
			double[] chromosome = new double[this.chromosomesP[randInd].chromosomeX.Length];
			Array.Copy(this.chromosomesP[randInd].chromosomeX, chromosome, this.chromosomesP[randInd].chromosomeX.Length);
			double[] constraintsCp = new  double[this.chromosomesP[randInd].constraints.Length];
			Array.Copy(this.chromosomesP[randInd].constraints, constraintsCp, this.chromosomesP[randInd].constraints.Length);
			Random rand = new Random();
			//return this.chromosomesP[randInd];
			return new DNA_ES(chromosome, constraintsCp, rand);
		}

		public Generation_ES addGeneration(Generation_ES otherGeneration) {
			DNA_ES[] combined = this.chromosomesP.Concat(otherGeneration.chromosomesP).ToArray();
			Generation_ES combinedGen = new Generation_ES(combined, 2*this.mu, 2*this.lambda);
			combinedGen.CalculateFitnesses();
			foreach (var b in combinedGen.chromosomesP)
			{
				Console.Write(b.ToString());
			}
			return combinedGen;
		}

		public DNA_ES[] getMuBestChromosomes(int Mu)
		{
			//sorting works fine
			int[] indexesChromosomes = new int[Mu];
			List<DNA_ES> MuBestChromosomes = new List<DNA_ES>();
			double[] fitnessesPClone = (double[])fitnessesP.Clone();
			List<double> listFitnesses = fitnessesPClone.ToList();

			var sorted = listFitnesses
	.Select((x, i) => new KeyValuePair<double, int>(x, i))
	.OrderBy(x => x.Key)
	.ToList();
			Console.WriteLine("Sorted fitnesses:");
			foreach (var l in sorted)
			{
				Console.Write(l + ",");
			}
			List<double> B = sorted.Select(x => x.Key).ToList();
			List<int> idx = sorted.Select(x => x.Value).ToList();

			int a = 0;
			foreach (var b in idx)
			{
				if (a < Mu) {
					MuBestChromosomes.Add(this.chromosomesP[b]);
					a++;
				}
			}
			return MuBestChromosomes.ToArray();
		}
	}
}
