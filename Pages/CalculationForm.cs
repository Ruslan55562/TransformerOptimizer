using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TransformerOptimizer
{
    public partial class CalculationForm : Form
    {
        private DataGridView dataGridResults;
        private TextBox txtCurrent;
        private TextBox txtResistance;
        private TextBox txtFrequency;
        private TextBox txtMagneticInduction;
        private TextBox txtMaterialCoeff;
        private TextBox txtVoltage; 
        private TextBox txtPowerFactor; 
        private Button btnCalculate;
        private Button btnClear;
        private Label lblCurrent;
        private Label lblResistance;
        private Label lblFrequency;
        private Label lblMagneticInduction;
        private Label lblMaterialCoeff;
        private Label lblVoltage;  
        private Label lblPowerFactor;  

        private double losses;
        private double coreLosses;
        private MainMenuForm mainMenuForm;


        private List<double> currents = new List<double>();
        private List<double> lossesInWindings = new List<double>();
        private List<double> coreLossesList = new List<double>();
        private List<double> EfficiencyList = new List<double>(); 

        public CalculationForm(MainMenuForm mainForm)
        {
            InitializeComponent();
            mainMenuForm = mainForm;


            lblCurrent = new Label
            {
                Text = "Ток (A)",
                Location = new System.Drawing.Point(50, 50),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtCurrent = new TextBox
            {
                Location = new System.Drawing.Point(250, 50),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            lblResistance = new Label
            {
                Text = "Опір (Ω)",
                Location = new System.Drawing.Point(50, 100),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtResistance = new TextBox
            {
                Location = new System.Drawing.Point(250, 100),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            lblFrequency = new Label
            {
                Text = "Частота (Гц)",
                Location = new System.Drawing.Point(50, 150),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtFrequency = new TextBox
            {
                Location = new System.Drawing.Point(250, 150),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            lblMagneticInduction = new Label
            {
                Text = "Магнітна індукція (Тл)",
                Location = new System.Drawing.Point(50, 200),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtMagneticInduction = new TextBox
            {
                Location = new System.Drawing.Point(250, 200),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            lblMaterialCoeff = new Label
            {
                Text = "Коефіцієнт матеріалу",
                Location = new System.Drawing.Point(50, 250),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtMaterialCoeff = new TextBox
            {
                Location = new System.Drawing.Point(250, 250),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            lblVoltage = new Label
            {
                Text = "Напруга (В)",
                Location = new System.Drawing.Point(50, 300),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtVoltage = new TextBox
            {
                Location = new System.Drawing.Point(250, 300),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            lblPowerFactor = new Label
            {
                Text = "Коефіцієнт потужності",
                Location = new System.Drawing.Point(50, 350),
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            txtPowerFactor = new TextBox
            {
                Location = new System.Drawing.Point(250, 350),
                Width = 250,
                Font = new System.Drawing.Font("Arial", 12)
            };

            btnCalculate = new Button
            {
                Text = "Розрахунок",
                Location = new System.Drawing.Point(50, 400),
                Size = new System.Drawing.Size(200, 50),
                BackColor = System.Drawing.Color.LightGreen,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };
            btnCalculate.Click += btnCalculate_Click;

            btnClear = new Button
            {
                Text = "Очистити",
                Location = new System.Drawing.Point(250, 400),
                Size = new System.Drawing.Size(200, 50),
                BackColor = System.Drawing.Color.Salmon,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };
            btnClear.Click += btnClear_Click;

            dataGridResults = new DataGridView
            {
                Location = new System.Drawing.Point(50, 480),
                Size = new System.Drawing.Size(900, 300),
                Font = new System.Drawing.Font("Arial", 12),
                ColumnCount = 2
            };
            dataGridResults.Columns[0].Name = "Параметр";
            dataGridResults.Columns[1].Name = "Значення";
            dataGridResults.Columns[0].Width = 428;
            dataGridResults.Columns[1].Width = 429;


            this.Controls.Add(lblCurrent);
            this.Controls.Add(txtCurrent);
            this.Controls.Add(lblResistance);
            this.Controls.Add(txtResistance);
            this.Controls.Add(lblFrequency);
            this.Controls.Add(txtFrequency);
            this.Controls.Add(lblMagneticInduction);
            this.Controls.Add(txtMagneticInduction);
            this.Controls.Add(lblMaterialCoeff);
            this.Controls.Add(txtMaterialCoeff);
            this.Controls.Add(lblVoltage);
            this.Controls.Add(txtVoltage);
            this.Controls.Add(lblPowerFactor);
            this.Controls.Add(txtPowerFactor);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(btnClear);
            this.Controls.Add(dataGridResults);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double current = ParseDouble(txtCurrent.Text); 
                double resistance = ParseDouble(txtResistance.Text);
                double frequency = ParseDouble(txtFrequency.Text);
                double induction = ParseDouble(txtMagneticInduction.Text);
                double materialCoeff = ParseDouble(txtMaterialCoeff.Text);
                double voltage = ParseDouble(txtVoltage.Text);
                double powerFactor = ParseDouble(txtPowerFactor.Text);

                currents.Clear();
                lossesInWindings.Clear();
                coreLossesList.Clear();
                EfficiencyList.Clear();

                // Расчет выходной мощности
                double Pout = Math.Sqrt(3) * voltage * current * powerFactor; 

                // Для расчета потерь для каждого тока
                for (double cur = 0; cur <= 100; cur += 5)  // Шаг 5 ампер
                {
                    currents.Add(cur);

                    // Потери в обмотках для каждого тока
                    double lossesInWinding = Math.Pow(cur, 2) * resistance;
                    lossesInWindings.Add(lossesInWinding);

                    // Потери в сердечнике
                    double coreLoss = materialCoeff * Math.Pow(frequency, 2) * Math.Pow(induction, 2);
                    coreLossesList.Add(coreLoss);

                    // Общие потери для данного тока
                    double totalLosses = lossesInWinding + coreLoss;

                    // Расчет КПД
                    double efficiency = (Pout / (Pout + totalLosses)) * 100; // Переводим в проценты
                    efficiency = Math.Round(efficiency, 3);
                    EfficiencyList.Add(efficiency);

                    // Добавление результатов в DataGridView для каждого тока
                    dataGridResults.Rows.Add("Ток", cur);
                    dataGridResults.Rows.Add("Втрати в обмотках", lossesInWinding); 
                    dataGridResults.Rows.Add("Втрати в осередді", coreLoss);
                    dataGridResults.Rows.Add("ККД", efficiency);  

                    dataGridResults.Rows.Add("", ""); 
                }

                mainMenuForm?.SaveGraphData(currents, lossesInWindings, coreLossesList, EfficiencyList);

                GraphForm graphForm = new GraphForm(currents, lossesInWindings, coreLossesList, EfficiencyList);
                graphForm.Show();

            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка вводу: будь ласка, використовуйте правильний формат для чисел (наприклад, 10.5).");
            }
        }




        private double ParseDouble(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new FormatException();

            return double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCurrent.Clear();
            txtResistance.Clear();
            txtFrequency.Clear();
            txtMagneticInduction.Clear();
            txtMaterialCoeff.Clear();
            txtVoltage.Clear();
            txtPowerFactor.Clear();
            dataGridResults.Rows.Clear();
        }
    }
}
