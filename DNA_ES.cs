using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
	class DNA_ES
	{
		public double[] chromosomeX { get; private set; }
		public double[] sigmas { get; private set; }
		public double[] constraints { get; private set; }
		//constraints [-1,1,-1,1]
		public DNA_ES getDNACopy()
		{
			DNA_ES othercopy = (DNA_ES)this.MemberwiseClone();
			return othercopy;

		}

		public double Fitness { get; private set; }
		private Random random;
		private int geneMax;
		public DNA_ES(double[] chromosomes, double[] constraints, Random random)
		{
			this.chromosomeX = chromosomes;
			this.constraints = constraints;
			this.random = random;
			this.sigmas = new double[chromosomes.Length];
			this.sigmas[0] = 1;
			this.sigmas[1] = 1;

		}
		public DNA_ES(int size, Random random, double[] constraints, bool shouldInitGenes = true)
		{
			this.chromosomeX = new double[size];
			this.random = random;
			this.sigmas = new double[size];
			//this.geneMax = geneMax;
			this.constraints = constraints;
			if (shouldInitGenes)
			{

				this.chromosomeX[0] = getRandomGene(constraints[0], constraints[1]);
				Console.WriteLine("Wylosowana liczba do osobnika populacji rodzicielskiej {0}", this.chromosomeX[0]);
				this.chromosomeX[1] = getRandomGene(constraints[2], constraints[3]);
				Console.WriteLine("Wylosowana liczba do osobnika populacji rodzicielskiej {0}", this.chromosomeX[1]);
				this.sigmas[0] = 1;
				this.sigmas[1] = 1;
				//sigmy są ustawiane na jeden przy inicjalizacji genu, a co jeśli shouldInitGenes jest ustawione na false?

			}
			else
			{
				this.sigmas[0] = 1;
				this.sigmas[1] = 1;
			}

		}
		public double FitnessSigmas() {
			return CalculateFitness(this.sigmas[0], this.sigmas[1]);
		}
		public double FitnessX() {
			return CalculateFitness(this.chromosomeX[0], this.chromosomeX[1]);
		}
		public double getRandomGene(double minConstraint, double maxConstraint)
		{
			//uwzględnić ograniczenia przy losowaniu wartości genów w chromosomach

			return random.NextDouble() * (maxConstraint - minConstraint) + minConstraint;

		}

		public double CalculateFitness(double x1, double x2)
		{
			double res = Math.Pow(x1, 2) + Math.Pow(x2, 2);
			this.Fitness = res;
			return res;
		}


		public void Mutate(int n, double C, int numGeneration, bool isSigma = false)
			//dla tej funkcji n=2
		{
			//teraz trzeba losować wartości z zakresu -1 do 1
			Random randx = new Random();
			double tau_prim = C / (Math.Sqrt(2 * n));
			double tau = C / Math.Sqrt(2 * Math.Sqrt(n));
			Console.WriteLine("Tau prim: {0}", tau_prim);
			Console.WriteLine("Tau: {0}", tau);

			//Random rand = new Random();
			double n0 = randx.NextDouble();
			Console.WriteLine("Randomizing in mutations ");

			double n1 = getRandomGene(this.constraints[0], this.constraints[1]);


			double n2 = getRandomGene(this.constraints[0], this.constraints[1]);



			double factor = Math.Exp(tau_prim * n0 + tau * n1);
			double factor2 = Math.Exp(tau_prim * n0 + tau * n2);
			Console.WriteLine("Sigmas before ");
			Console.WriteLine(this.sigmas[0]);

			Console.WriteLine(this.sigmas[1]);

			this.sigmas[0] = this.sigmas[0]*factor;
			this.sigmas[1] = this.sigmas[1]*factor2;
			Console.WriteLine("Sigmas after ");
			Console.WriteLine(this.sigmas[0]);

			Console.WriteLine(this.sigmas[1]);
			//zakończony przebieg mutacji sigma
			Console.WriteLine("Xs before ");
			Console.WriteLine(this.chromosomeX[0]);
			Console.WriteLine(this.chromosomeX[1]);

			double x_n1 = getRandomGene(this.constraints[0], this.constraints[1]) ;


			double x1_prim = this.chromosomeX[0] + this.sigmas[0] * x_n1;
			double x_n2 = getRandomGene(this.constraints[0], this.constraints[1]);

			double x2_prim = this.chromosomeX[1]+this.sigmas[1]*x_n2;
			this.chromosomeX[0] = x1_prim;
			this.chromosomeX[1] = x2_prim;
			Console.WriteLine("Xs after ");
			Console.WriteLine(this.chromosomeX[0]);
			Console.WriteLine(this.chromosomeX[1]);
		}
		public override string ToString() {
			string res = " DNA details, chromosomeX: ";
			foreach (var i in this.chromosomeX)
			{
				res += i + " : ";
			}
			res += " fitness: " + this.Fitness +"\n";
			return res;
		}
	}
}
