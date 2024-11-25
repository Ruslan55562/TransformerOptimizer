using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TransformerOptimizer
{
    public partial class GraphForm : Form
    {
        private List<double> currents;
        private List<double> lossesInWindings;
        private List<double> coreLossesList;
        private List<double> efficiencyList;

        public GraphForm(List<double> currents, List<double> lossesInWindings, List<double> coreLossesList, List<double> efficiencyList)
        {
            InitializeComponent();
            this.currents = currents;
            this.lossesInWindings = lossesInWindings;
            this.coreLossesList = coreLossesList;
            this.efficiencyList = efficiencyList;
        }


        private void GraphForm_Load(object sender, EventArgs e)
        {
            Chart chartLossesInWindings = CreateChart("Втрати в обмотках", lossesInWindings, "Струм (A)", "Втрати (Вт)", System.Drawing.Color.Red);
            chartLossesInWindings.Dock = DockStyle.Top;
            chartLossesInWindings.Height = 250;
            this.Controls.Add(chartLossesInWindings);

            Chart chartCoreLosses = CreateChart("Втрати в осередді", coreLossesList, "Струм (A)", "Втрати (Вт)", System.Drawing.Color.Blue);
            chartCoreLosses.Dock = DockStyle.Top;
            chartCoreLosses.Height = 250;
            this.Controls.Add(chartCoreLosses);

            Chart chartEfficiency = CreateChart("ККД", efficiencyList, "Струм (A)", "ККД (%)", System.Drawing.Color.Green);
            chartEfficiency.Dock = DockStyle.Top;
            chartEfficiency.Height = 250;
            this.Controls.Add(chartEfficiency);
        }

        private Chart CreateChart(string title, List<double> data, string xAxisTitle, string yAxisTitle, System.Drawing.Color lineColor)
        {
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea("MainArea")
            {
                AxisX = { Title = xAxisTitle, TitleFont = new System.Drawing.Font("Arial", 12) },
                AxisY = { Title = yAxisTitle, TitleFont = new System.Drawing.Font("Arial", 12) }
            };

            chart.ChartAreas.Add(chartArea);

            Series series = new Series(title)
            {
                ChartType = SeriesChartType.Line,
                Color = lineColor,
                BorderWidth = 2
            };

            for (int i = 0; i < currents.Count; i++)
            {
                series.Points.AddXY(currents[i], data[i]);
            }

            chart.Series.Add(series);

            Legend legend = new Legend("MainLegend")
            {
                Docking = Docking.Bottom,
                Alignment = System.Drawing.StringAlignment.Center
            };
            chart.Legends.Add(legend);

            if (yAxisTitle == "ККД (%)")
            {
                chartArea.AxisY.Maximum = 100;
                chartArea.AxisY.Minimum = 0;
                chartArea.AxisY.Interval = 10;
            }

            return chart;
        }

    }
}
