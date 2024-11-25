using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Transformer.UI;

namespace TransformerOptimizer
{
    public partial class MainMenuForm : Form
    {
        public List<double> Currents { get; set; }
        public List<double> LossesInWindings { get; set; }
        public List<double> CoreLossesList { get; set; }
        public List<double> EfficiencyList { get; set; } 
        private bool isGraphDataSaved = false;


        public MainMenuForm()
        {
            InitializeComponent();
            Currents = new List<double>();
            LossesInWindings = new List<double>();
            CoreLossesList = new List<double>();
            EfficiencyList = new List<double>();
        }

        private void btnStartCalculations_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is CalculationForm)
                {
                    form.Activate(); 
                    return;
                }
            }


            CalculationForm calculationForm = new CalculationForm(this);
            calculationForm.Show();
        }

        private void btnOpenGraph_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is GraphForm)
                {
                    form.Activate();
                    return;
                }
            }

            if (!isGraphDataSaved)
            {
                MessageBox.Show("Графики еще не рассчитаны. Выполните расчет сначала.", "Ошибка");
                return;
            }

            GraphForm graphForm = new GraphForm(Currents, LossesInWindings, CoreLossesList, EfficiencyList);
            graphForm.Show();
        }


        private void btnShowExplanations_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ExplanationForm)
                {
                    form.Activate(); 
                    return;
                }
            }

            ExplanationForm explanationForm = new ExplanationForm();
            explanationForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SaveGraphData(List<double> currents, List<double> lossesInWindings, List<double> coreLosses, List<double> efficiencyList)
        {
            Currents = new List<double>(currents);
            LossesInWindings = new List<double>(lossesInWindings);
            CoreLossesList = new List<double>(coreLosses);
            EfficiencyList = new List<double>(efficiencyList);

            isGraphDataSaved = true;
            btnOpenGraph.Enabled = true;
        }

    }
}
