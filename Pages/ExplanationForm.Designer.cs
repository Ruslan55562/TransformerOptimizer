using System.Windows.Forms;
using System;

namespace Transformer.UI
{
    partial class ExplanationForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplanationForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "Пояснення";
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            TextBox txtExplanation = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Arial", 12),
                Text = "На цій сторінці пояснюється, як розраховуються параметри трансформатора:" +
                   Environment.NewLine +
                   Environment.NewLine +

                   "1. **Втрати в обмотках** (P):" + Environment.NewLine +
                   "   Втрати в обмотках трансформатора розраховуються за формулою I²R, де:" + Environment.NewLine +
                   "   - **I** — ток в обмотках (Ампери)" + Environment.NewLine +
                   "   - **R** — опір обмоток (Оми)" + Environment.NewLine +
                   "   Високі втрати в обмотках означають більшу теплоту та зниження ефективності трансформатора." + Environment.NewLine +
                   Environment.NewLine +

                   "2. **Втрати в сердечнику** (P_core):" + Environment.NewLine +
                   "   Втрати в сердечнику трансформатора залежать від магнітної індукції, частоти та коефіцієнта матеріалу." + Environment.NewLine +
                   "   Втрати розраховуються за формулою:" + Environment.NewLine +
                   "   **P_core = k * f² * B²**, де:" + Environment.NewLine +
                   "   - **k** — коефіцієнт матеріалу" + Environment.NewLine +
                   "   - **f** — частота струму (Гц)" + Environment.NewLine +
                   "   - **B** — магнітна індукція (Тл)" + Environment.NewLine +
                   "   Ці втрати можуть бути значними при високих частотах та великих значеннях індукції." + Environment.NewLine +
                   Environment.NewLine +

                   "3. **Коефіцієнт корисної дії (КПД):**" + Environment.NewLine +
                   "   ККД трансформатора розраховується як відношення корисної потужності до загальної потужності:" + Environment.NewLine +
                   "   **ККД = P_out / (P_out + P_losses + P_core)**, де:" + Environment.NewLine +
                   "   - **P_out** — вихідна потужність (Ватт)" + Environment.NewLine +
                   "   - **P_losses** — втрати в обмотках" + Environment.NewLine +
                   "   - **P_core** — втрати в сердечнику" + Environment.NewLine +
                   "   Чим менші втрати в обмотках і сердечнику, тим вищий ККД трансформатора." + Environment.NewLine +
                   Environment.NewLine +

                   "4. **Пояснення розрахунків:**" + Environment.NewLine +
                   "   При розрахунках ми використовуємо спрощені значення для вихідної потужності трансформатора." + Environment.NewLine +
                   "   Вихідна потужність часто вказується в технічних характеристиках трансформатора і є важливим параметром для оцінки його ефективності." +
                   Environment.NewLine
            };

            this.Controls.Add(txtExplanation);
        }
    }
}