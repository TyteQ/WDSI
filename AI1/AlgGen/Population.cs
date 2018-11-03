using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI1
{
    class Population
    {
        // --- konstruktor
        public Population(int r, double pc, double pm, double del, int nv, double L,
                          double H, bool i)
        {
            Genotype[] Pop = new Genotype[r];
            Genotype[] TPop = new Genotype[r];
            PopS = r;
            PCross = pc;
            PMut = pm;
            Delta = del;
            NV = nv;
            Low = L;
            High = H;
            iInt = i;
        }

        // --- metody

        public void initPop(int r, int g, double Low, double High, bool n)
        {
            for (int i = 1; i <= r; i++)
            {
                Pop[i - 1] = new Genotype(r, 0, 0, 0, 0, 0);
                Pop[i - 1].setAllGeneRandom(Low, High, n, g);
                TPop[i - 1] = new Genotype(r, 0, 0, 0, 0, 0);
                TPop[i - 1].setAllGeneRandom(Low, High, n, g);
            }
        }

        public double Evaluate(Genotype g)
        {
            double Sum = 0;
            for (int i = 1; i <= this.NV; i++)
            {
                Sum = Sum + g.get_i_Gene(i - 1);
            }
            return Sum;
        }

        public void ComputeEval()
        {
            double tmp;
            for (int i = 1; i <= this.PopS; i++)
            {
                tmp = this.Evaluate(Pop[i - 1]);
                this.Pop[i - 1].setEval(tmp);
            }
        }

        public void ComputeFitness()
        {
            double MaxEval = this.Pop[0].getEval();
            for (int i = 1; i <= (this.PopS - 1); i++)
            {
                if (this.Pop[i].getEval() > MaxEval)
                {
                    MaxEval = this.Pop[i].getEval();
                }
            }
            for (int i = 0; i <= (this.PopS - 1); i++)
            {
                this.Pop[i].setFitness(MaxEval - this.Pop[i].getEval() + this.Delta);
            }
        }

        public void set_i_Genotype(int i, Genotype g)
        {
            for (int j = 0; j <= (this.NV - 1); j++)
            {
                this.Pop[i].set_i_Gene(j, g.get_i_Gene(j));
            }
            this.Pop[i].setEval(g.getEval());
            this.Pop[i].setFitness(g.getFitness());
            this.Pop[i].setRFitness(g.getRFitness());
            this.Pop[i].setRMax(g.getRMax());
            this.Pop[i].setRMin(g.getRMin());
        }

        public void ComputeRelativeFitness()
        {
            double Sum = 0;
            for (int i = 1; i <= this.PopS; i++)
            {
                Sum = Sum + this.Pop[i - 1].getFitness();
            }
            for (int i = 1; i <= this.PopS; i++)
            {
                this.Pop[i - 1].setRFitness(this.Pop[i - 1].getFitness() / Sum);
            }
        }

        public Genotype GetTheBest()
        {
            double Max = this.Pop[0].getEval();
            Genotype g = new Genotype(this.NV, 0, 0, 0, 0, 0);
            int p = 0;
            for (int i = 1; i <= (this.PopS - 1); i++)
            {
                if (this.Pop[i].getEval() < Max)
                {
                    Max = this.Pop[i].getEval();
                    p = i;
                }
            }
            for (int i = 0; i <= (this.NV - 1); i++)
            {
                g.set_i_Gene(i, this.Pop[p].get_i_Gene(i));
            }
            g.setEval(this.Pop[p].getEval());
            g.setFitness(this.Pop[p].getFitness());
            g.setRFitness(this.Pop[p].getRFitness());
            g.setRMax(this.Pop[p].getRMax());
            g.setRMin(this.Pop[p].getRMin());

            return g;
        }

        public void CrossOver()
        {
            double Los;
            int n = 0;
            int[] pp = new int[this.PopS];
            for (int i = 0; i <= (this.PopS - 1); i++)
            {
                Random generator = new Random();
                Los = generator.NextDouble();
                if (Los < this.PCross)
                {
                    n++;
                    pp[n] = i;
                }
            }
            int t1;
            int t2;
            int p1;
            int p2;
            int cut;
            double tmp;

            Random Generator = new Random();

            while (n > 1)
            {
                t1 = Generator.Next(n) + 1;
                p1 = pp[t1 - 1];
                pp[t1 - 1] = pp[n - 1];
                n--;
                t2 = Generator.Next(n) + 1;
                p2 = pp[t2 - 1];
                pp[t2 - 1] = pp[n - 1];
                n--;
                //----- tu krzyzujemy p1 z p2
                cut = Generator.Next(this.NV - 1);
                for (int i = cut + 1; i <= (this.NV - 1); i++)
                {
                    tmp = this.Pop[p1].get_i_Gene(i);
                    this.Pop[p1].set_i_Gene(i, this.Pop[p2].get_i_Gene(i));
                    this.Pop[p2].set_i_Gene(i, tmp);
                }
                //---------------------------
            }
        }

        public void Mutation(bool iInt)
        {
            double Los;
            if (iInt == true)
            {
                Random Generator = new Random();
                for (int i = 0; i <= (this.PopS - 1); i++)
                {
                    for (int j = 0; j <= (this.NV - 1); j++)
                    {
                        Los = (double)Generator.NextDouble();
                        if (Los < this.PMut)
                        {

                            double t = Generator.Next((int)(this.High - this.Low + 1)) + this.Low;
                            Pop[i].set_i_Gene(j, t);
                        }
                    }
                }
            }
            if (iInt == false)
            {
                Random Generator = new Random();
                for (int i = 0; i <= (this.PopS - 1); i++)
                {
                    for (int j = 0; j <= (this.NV - 1); j++)
                    {
                        Los = (double)Generator.NextDouble();
                        if (Los < this.PMut)
                        {
                            double t = this.High - this.Low;
                            t = (double)((Generator.NextDouble() * t) + this.Low);
                            Pop[i].set_i_Gene(j, t);
                        }
                    }
                }
            }
        }

        public int GetTheNumberOfTheWorst()
        {
            int MinI = 0;
            double Min = this.Pop[MinI].getEval();
            for (int i = 1; i <= (this.PopS - 1); i++)
            {
                if (this.Pop[i].getEval() > Min)
                {
                    Min = this.Pop[i].getEval();
                    MinI = i;
                }
            }
            return MinI;
        }

        public void ElitistSelection()
        {
            this.Pop[0].setRMin(0);
            this.Pop[0].setRMax(this.Pop[0].getRMin() + this.Pop[0].getRFitness());
            for (int i = 1; i <= (this.PopS - 1); i++)
            {
                this.Pop[i].setRMin(this.Pop[i - 1].getRMax());
                this.Pop[i].setRMax(this.Pop[i].getRMin() + this.Pop[i].getRFitness());
            }
            for (int i = 0; i <= (this.PopS - 1); i++)
            {
                Random Generator = new Random();
                double Los = (double)Generator.NextDouble();
                for (int j = 0; j <= (this.PopS - 1); j++)
                {
                    if ((Los >= this.Pop[j].getRMin()) && (Los < this.Pop[j].getRMax()))
                    {
                        this.TPop[i] = this.Pop[j];
                        break;
                    }
                }
            }
            for (int i = 0; i <= (this.PopS - 1); i++)
            {
                this.Pop[i] = this.TPop[i];
            }
        }

        public void FanSelection()
        {
        }
        // --- pola skladowe
        private int PopS;
        private double PCross;
        private double PMut;
        private double Delta;
        private int NV;
        private double Low;
        private double High;
        private Genotype[] Pop = new Genotype[100];
        private Genotype[] TPop = new Genotype[100];
        private bool iInt;
    }
}