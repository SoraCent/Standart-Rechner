using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Standart_Rechner
{
    public partial class RechnerForm : Form
    {
        string last_output { get; set; }
        public RechnerForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void RechnerForm_Load(object sender, EventArgs e)
        {
            btnGleich.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnBackspace.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Focus();
            this.KeyPreview = true;
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "0";
        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "1";
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "2";
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "3";
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "4";
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "5";
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "6";
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "7";
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "8";
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "9";
        }

        private void btnComma_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += ".";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "-";
        }

        private void btnDurch_Click(object sender, EventArgs e)
        {
            check_error();
            string rechnung = RechnerOutput.Text;
            if (rechnung != "")
            {
                RechnerOutput.Text += "/";
            }
        }

        private void btnMal_Click(object sender, EventArgs e)
        {
            check_error();
            string rechnung = RechnerOutput.Text;
            if (RechnerOutput.Text != "")
            {
                RechnerOutput.Text += "*";
            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "3.1415926";
        }

        private void btnProzent_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "%";
        }

        private void btnKlammerAuf_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += "(";
        }

        private void btnKlammerZu_Click(object sender, EventArgs e)
        {
            check_error();
            RechnerOutput.Text += ")";
        }

        public void btnGleich_Click(object sender, EventArgs e)
        {
            check_error();
            string rechnung = RechnerOutput.Text;
            if (RechnerOutput.Text != "")
            {
                DataTable dt = new DataTable();

                if (rechnung.Contains("/") && !(rechnung.Contains(".")))
                {
                    try
                    {
                        if (rechnung.Contains("/0"))
                        {
                            RechnerOutput.Text = "Durch Null ERROR";
                        }
                        else
                        {
                            double anwser = (double)dt.Compute(rechnung, null);
                            string resultat = anwser.ToString();
                            RechnerOutput.Text = resultat;
                        }
                    }
                    catch
                    {
                        last_output = RechnerOutput.Text;
                        //Error Name
                        RechnerOutput.Text = "Syntax ERROR";
                        //Neue Linie
                        RechnerOutput.AppendText(Environment.NewLine);
                        //Weitere Infos
                        RechnerOutput.AppendText(Environment.NewLine + "Alles Löschen : [C]" + Environment.NewLine + "Zurück : [←]");
                    }
                }
                else if (rechnung.Contains("."))
                {
                    try
                    {
                        if (rechnung.Contains("/0"))
                        {
                            RechnerOutput.Text = "Durch Null ERROR";
                        }
                        else
                        {
                            decimal anwser = (decimal)dt.Compute(rechnung, null);
                            decimal rounded_anwser = Math.Round(anwser, 10, MidpointRounding.AwayFromZero);
                            string resultat = rounded_anwser.ToString();
                            RechnerOutput.Text = resultat;
                        }
                    }
                    catch
                    {
                        last_output = RechnerOutput.Text;
                        //Error Name
                        RechnerOutput.Text = "Syntax ERROR";
                        //Neue Linie
                        RechnerOutput.AppendText(Environment.NewLine);
                        //Weitere Infos
                        RechnerOutput.AppendText(Environment.NewLine + "Alles Löschen : [C]" + Environment.NewLine + "Zurück : [←]");
                    }
                }
                    
                else if (rechnung.Contains("*"))
                {
                    try
                    {
                        if (rechnung.Contains("/0"))
                        {
                            RechnerOutput.Text = "Durch Null ERROR";
                        }
                        else
                        {
                            decimal anwser = (decimal)dt.Compute(rechnung, "");
                            string resultat = anwser.ToString();
                            RechnerOutput.Text = resultat;
                        }
                    }
                    catch
                    {
                        last_output = RechnerOutput.Text;
                        //Error Name
                        RechnerOutput.Text = "Syntax ERROR";
                        //Neue Linie
                        RechnerOutput.AppendText(Environment.NewLine);
                        //Weitere Infos
                        RechnerOutput.AppendText(Environment.NewLine + "Alles Löschen : [C]" + Environment.NewLine + "Zurück : [←]");
                    }
                }
                else
                {
                    try
                    {
                        if (rechnung.Contains("/0"))
                        {
                            RechnerOutput.Text = "Durch Null ERROR";
                        }
                        else
                        {
                            int anwser = (int)dt.Compute(rechnung, "");
                            string resultat = anwser.ToString();
                            RechnerOutput.Text = resultat;
                        }
                    }
                    catch
                    {
                        last_output = RechnerOutput.Text;
                        //Error Name
                        RechnerOutput.Text = "Syntax ERROR";
                        //Neue Linie
                        RechnerOutput.AppendText(Environment.NewLine);
                        //Weitere Infos
                        RechnerOutput.AppendText(Environment.NewLine + "Alles Löschen : [C]" + Environment.NewLine + "Zurück : [←]");
                    }
                }

                /*if (rechnung.Contains("*"))
                {
                    if(!(rechnung.Contains(".")))
                    {
                        rechnung += ".0";

                        int anwser = (int)dt.Compute(rechnung, null);
                        string tmp_resultat = anwser.ToString();
                        string resultat = tmp_resultat.Replace(".0", "");

                        RechnerOutput.Text = resultat;
                    }
                    else
                    {
                        var anwser = dt.Compute(rechnung, null);
                        string resultat = anwser.ToString();
                        RechnerOutput.Text = resultat;
                    }
                }
                else
                {
                    var anwser = dt.Compute(rechnung, null);
                    string resultat = anwser.ToString();
                    RechnerOutput.Text = resultat;
                }

                try
                {
                    if (rechnung.Contains("/0"))
                    {
                        last_output = RechnerOutput.Text;
                        RechnerOutput.Text = "Math ERROR";
                        RechnerOutput.AppendText(Environment.NewLine);
                        RechnerOutput.AppendText(Environment.NewLine + "Alles Löschen : [C]" + Environment.NewLine + "Zurück : [←]");
                    }
                    else
                    {
                        if(rechnung.Contains("*"))
                        {
                            System.Int64 anwser = (System.Int64)dt.Compute(rechnung, null);
                            string resultat = anwser.ToString();
                            RechnerOutput.Text = resultat;
                        }
                        else
                        {
                            var anwser = dt.Compute(rechnung, null);
                            string resultat = anwser.ToString();
                            RechnerOutput.Text = resultat;
                        }
                    }
                }
                catch
                {
                    last_output = RechnerOutput.Text;
                    RechnerOutput.Text = "Syntax ERROR";
                    RechnerOutput.AppendText(Environment.NewLine);
                    RechnerOutput.AppendText(Environment.NewLine + "Alles Löschen : [C]" + Environment.NewLine + "Zurück : [←]");
                }*/
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            RechnerOutput.Text = "";
            this.Focus();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            check_error();

            string rechnung = RechnerOutput.Text;
            //rechnung = rechnung.Substring(rechnung.Length - 1);
            string s = RechnerOutput.Text;

            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "";
            }

            RechnerOutput.Text = s;
        }

        private void dunkelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hellToolStripMenuItem.Checked = false;
            change_theme();
        }

        private void hellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dunkelToolStripMenuItem.Checked = false;
            change_theme();
        }

        private void allow_buttons()
        {
            btnMal.Enabled = true;
            btnDurch.Enabled = true;
            btnPlus.Enabled = true;
            btnMinus.Enabled = true;
            btnGleich.Enabled = true;
        }

        private void check_error()
        {
            this.Focus();
            string Check_String = RechnerOutput.Text;
            if (Regex.IsMatch(Check_String, "ERROR"))
            {
                RechnerOutput.Text = "";
            }
        }

        private void change_theme()
        {
            if (hellToolStripMenuItem.Checked == true && dunkelToolStripMenuItem.Checked == false)
            {
                this.BackColor = Color.White;
            } else
            {
                this.BackColor = Color.FromArgb(42, 42, 42);
            }
        }

        //Menüband

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("************************\nAutor: SoraCent\nRelease Date: 12.02.2018\nUpdate Date: 11.03.2019\nVersion: 0.1.2\n************************");
        }

        private void btnPfeilLinks_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(last_output))
            {
            }
            else
            {
                RechnerOutput.Text = last_output;
                last_output = null;
            }
        }

        private void btnPfeilOben_Click(object sender, EventArgs e)
        {

        }

        private void btnPfeilUnten_Click(object sender, EventArgs e)
        {

        }

        private void btnPfeilRechts_Click(object sender, EventArgs e)
        {

        }

        //Key EVENT
        private void RechnerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                case Keys.D1:
                    // Simuliert button Klick.
                    btnNumber1.PerformClick();
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    btnNumber2.PerformClick();
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    btnNumber3.PerformClick();
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    btnNumber4.PerformClick();
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    btnNumber5.PerformClick();
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    btnNumber6.PerformClick();
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    btnNumber7.PerformClick();
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    btnNumber8.PerformClick();
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    btnNumber9.PerformClick();
                    break;

                case Keys.NumPad0:
                case Keys.D0:
                    btnNumber0.PerformClick();
                    break;

                case Keys.Enter:
                case Keys.E:
                    btnGleich.PerformClick();
                    break;

                //Operatoren

                case Keys.Multiply:
                    btnMal.PerformClick();
                    break;

                case Keys.Divide:
                    btnDurch.PerformClick();
                    break;

                case Keys.Subtract:
                case Keys.OemMinus:
                    btnMinus.PerformClick();
                    break;

                case Keys.Add:
                    btnPlus.PerformClick();
                    break;

                case Keys.Decimal:
                case Keys.OemPeriod:
                case Keys.Oemcomma:
                    btnComma.PerformClick();
                    break;

                //Lösch Button

                case Keys.Back:
                    btnBackspace.PerformClick();
                    break;

                case Keys.C:
                    btnClear.PerformClick();
                    break;

                //Pi

                case Keys.P:
                    btnPi.PerformClick();
                    break;

                //Pfeil tasten

                case Keys.Left:
                    btnPfeilLinks.PerformClick();
                    break;

                case Keys.Right:
                    btnPfeilRechts.PerformClick();
                    break;

                case Keys.Up:
                    btnPfeilOben.PerformClick();
                    break;

                case Keys.Down:
                    btnPfeilUnten.PerformClick();
                    break;

                default:
                    break;
            }
        }
    }
}