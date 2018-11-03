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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace AI1
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class AlgorytmGenetyczny : Page
    {
        public AlgorytmGenetyczny()

        {

            this.InitializeComponent();

        }

        bool iInt;

        double Delta;

        double PCrossOver;

        double PMutation;

        int PopSize;

        int NumberOfVariables;

        double MaxValueOfEachGene;

        double MinValueOfEachGene;

        int NumberOfIteration;

        int Iteration;

        Population Pop1;

        Genotype TheBest;

        Genotype NowTheBest;



        private void Button_Click(object sender, RoutedEventArgs e)

        {



            iInt = (bool)false;

            Delta = (double)0.00000001;

            PCrossOver = (double)0.7;

            PMutation = (double)0.005;

            PopSize = 100;

            NumberOfVariables = 10;

            MaxValueOfEachGene = 10;

            MinValueOfEachGene = 0;

            NumberOfIteration = 10000;

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)

        {

            TheBest = new Genotype(NumberOfVariables, 0, 0, 0, 0, 0);

            NowTheBest = new Genotype(NumberOfVariables, 0, 0, 0, 0, 0);

            Pop1 = new Population(PopSize, PCrossOver, PMutation, Delta,

                    NumberOfVariables, MinValueOfEachGene, MaxValueOfEachGene, iInt);

            Pop1.initPop(PopSize, NumberOfVariables,

                    MinValueOfEachGene, MaxValueOfEachGene, iInt);

            Pop1.ComputeEval();

            Pop1.ComputeFitness();

            Pop1.ComputeRelativeFitness();

            TheBest = Pop1.GetTheBest();

            NowTheBest = Pop1.GetTheBest();

            Iteration = 0;

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)

        {

            for (int i = 1; i <= NumberOfIteration; i++)

            {

                Iteration++;

                Pop1.CrossOver();

                Pop1.Mutation(iInt);

                Pop1.ComputeEval();

                Pop1.ComputeFitness();

                Pop1.ComputeRelativeFitness();

                Pop1.ElitistSelection();

                Pop1.ComputeEval();

                Pop1.ComputeFitness();

                Pop1.ComputeRelativeFitness();

                NowTheBest = Pop1.GetTheBest();

                if (NowTheBest.getEval() > TheBest.getEval())

                {

                    Pop1.set_i_Genotype(Pop1.GetTheNumberOfTheWorst(), TheBest);

                }

                if (NowTheBest.getEval() < TheBest.getEval())

                {

                    for (int n = 0; n <= (NumberOfVariables - 1); n++)

                    {

                        TheBest.set_i_Gene(n, NowTheBest.get_i_Gene(n));

                        TheBest.setEval(NowTheBest.getEval());

                    }

                }

                textBlock1.Text = "Iteration = " + Iteration + "   Evaluate = " + TheBest.getEval();

            }



            FileStream writeStream;

            try

            {

                writeStream = new FileStream("TheBest.txt", FileMode.OpenOrCreate);

                BinaryWriter writeBinay = new BinaryWriter(writeStream);

                textBlock2.Text = "Writing data to the stream.";

                for (int i = 0; i < NumberOfVariables; i++)

                {

                    writeBinay.Write(TheBest.get_i_Gene(i - 1));

                }

            }

            catch (Exception ex)

            {

                textBlock2.Text = ex.ToString();

            }

        }
    }
}
