using System.Windows.Forms;
using Transformer.UI;

namespace TransformerOptimizer
{
    public partial class MainMenuForm : Form
    {
        public Button btnOpenGraph;


        private void InitializeComponent()
        {
            this.Text = "Transformer Optimizer - Main Menu";
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplanationForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            Button btnStartCalculations = new Button
            {
                Text = "Почати розрахунок",
                Size = new System.Drawing.Size(250, 60),
                Location = new System.Drawing.Point(387, 120),
                BackColor = System.Drawing.Color.LightGreen,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };
            btnStartCalculations.Click += btnStartCalculations_Click;

            btnOpenGraph = new Button
            {
                Text = "Відкрити графік",
                Size = new System.Drawing.Size(250, 60),
                Location = new System.Drawing.Point(387, 200),
                BackColor = System.Drawing.Color.LightSkyBlue,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Enabled = false
            };
            btnOpenGraph.Click += btnOpenGraph_Click;

            Button btnShowExplanations = new Button
            {
                Text = "Пояснення",
                Size = new System.Drawing.Size(250, 60),
                Location = new System.Drawing.Point(387, 280),
                BackColor = System.Drawing.Color.LightYellow,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };
            btnShowExplanations.Click += btnShowExplanations_Click;

            Button btnExit = new Button
            {
                Text = "Вихід",
                Size = new System.Drawing.Size(250, 60),
                Location = new System.Drawing.Point(387, 360),
                BackColor = System.Drawing.Color.Salmon,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };
            btnExit.Click += btnExit_Click;

            this.Controls.Add(btnStartCalculations);
            this.Controls.Add(btnOpenGraph);
            this.Controls.Add(btnShowExplanations);
            this.Controls.Add(btnExit);
        }

        public void EnableGraphButton()
        {
            btnOpenGraph.Enabled = true; 
        }
    }
}
