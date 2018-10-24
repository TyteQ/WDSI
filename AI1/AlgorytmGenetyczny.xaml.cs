using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AI1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlgorytmGenetyczny : Page
    {
        private double Eval;
        private double Fitness;
        private double RFitness;
        private double RMin;
        private double RMax;
        private double[] Gene = null;

        // --- konstruktor
        public AlgorytmGenetyczny(int g, double ev, double f, double rf, double rmin, double rmax)
        {
            Eval = ev;
            Fitness = f;
            RFitness = rf;
            RMin = rmin;
            RMax = rmax;
            Gene = new double[g];

            for (int i = 1; i <= g; i++)
            {
                Gene[i - 1] = 0;
            }
            this.InitializeComponent();
        }
        public void setEval(double n)
        {
            Eval = n;
        }

        public void setFitness(double n)
        {
            Fitness = n;
        }

        public void setRFitness(double n)
        {
            RFitness = n;
        }

        public void setRMin(double n)
        {
            RMin = n;
        }

        public void setRMax(double n)
        {
            RMax = n;
        }

        public void set_i_Gene(int i, double n)
        {
            Gene[i] = n;
        }
        public void setAllGeneRandom(double Low, double High, bool n, int ile)
        {
            for (int i = 1; i <= ile; i++)
            {
                    Random generator = new Random();
                if (n == true)
                {
                    this.Gene[i - 1] = (generator.Next((int)(High - Low + 1)) + Low);
                }
                else
                {
                    this.Gene[i - 1] = (double)((generator.NextDouble() * (High - Low)) + Low);
                }
            }
        }

        public double getEval()
        {
            return Eval;
        }

        public double getFitness()
        {
            return Fitness;
        }

        public double getRFitness()
        {
            return RFitness;
        }

        public double getRMin()
        {
            return RMin;
        }

        public int getGeneLength()
        {
            return this.Gene.Length;
        }

        public double getRMax()
        {
            return RMax;
        }

        public double get_i_Gene(int i)
        {
            return Gene[i];
        }


        public AlgorytmGenetyczny()
        {
            this.InitializeComponent();
        }
    }
}
