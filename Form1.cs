﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Dateiverwaltung
{
    public partial class Form1 : Form
    {
        List<PfadEintrag> publicPfadEintraege = JsonConvert.DeserializeObject<List<PfadEintrag>>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Datenbank.json")).ToString());

        bool neuerPfadWaterMarkActive = true;
        bool neuerNameWaterMarkActive = true;
        bool passwortNeueDateiWaterMark = true;
        public Form1()
        {
            InitializeComponent();
            createGridView1();
            createButtonView();
       
            textBoxNeuerPfad.GotFocus += (source, e) =>
            {
                if (neuerPfadWaterMarkActive && textBoxNeuerPfad.Text == "Pfad/Link...")
                {
                    neuerPfadWaterMarkActive = false;
                    textBoxNeuerPfad.Text = "";
                    textBoxNeuerPfad.ForeColor = Color.Black;
                }
            };

            textBoxNeuerPfad.LostFocus += (source, e) =>
            {
                if (!neuerPfadWaterMarkActive && string.IsNullOrEmpty(textBoxNeuerPfad.Text))
                {
                    neuerPfadWaterMarkActive = true;
                    textBoxNeuerPfad.Text = "Pfad/Link...";
                    textBoxNeuerPfad.ForeColor = Color.Gray;
                }
            };

            textBoxNeuerName.GotFocus += (source, e) =>
            {
                if (neuerNameWaterMarkActive && textBoxNeuerName.Text == "Name...")
                {
                    neuerNameWaterMarkActive = false;
                    textBoxNeuerName.Text = "";
                    textBoxNeuerName.ForeColor = Color.Black;
                }
            };

            textBoxNeuerName.LostFocus += (source, e) =>
            {
                if (!neuerNameWaterMarkActive && string.IsNullOrEmpty(textBoxNeuerName.Text))
                {
                    neuerNameWaterMarkActive = true;
                    textBoxNeuerName.Text = "Name...";
                    textBoxNeuerName.ForeColor = Color.Gray;
                }
            };

            textBoxExcelPasswort.GotFocus += (source, e) =>
            {
                if (passwortNeueDateiWaterMark && textBoxExcelPasswort.Text == "Passwort...")
                {
                    passwortNeueDateiWaterMark = false;
                    textBoxExcelPasswort.Text = "";
                    textBoxExcelPasswort.ForeColor = Color.Black;
                    textBoxExcelPasswort.PasswordChar = '*';
                }
            };

            textBoxExcelPasswort.LostFocus += (source, e) =>
            {
                if (!passwortNeueDateiWaterMark && string.IsNullOrEmpty(textBoxExcelPasswort.Text))
                {
                    passwortNeueDateiWaterMark = true;
                    textBoxExcelPasswort.Text = "Passwort...";
                    textBoxExcelPasswort.ForeColor = Color.Gray;
                }
            };
        }

        private void createGridView1()
        {
            //Row 0 Löschen 1 Name 2 Dateipfad 3 Aggregate 4 Blöcke 5 Mechatronik 6 Alle
            for (int i = 0; i < publicPfadEintraege.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[1, i].Value = publicPfadEintraege[i].Name;
                dataGridView1[2, i].Value = publicPfadEintraege[i].Dateipfad;

                switch (publicPfadEintraege[i].Abteilung)
                {
                    case "Aggregate":
                        dataGridView1[3, i].Value = true;
                        break;

                    case "Blöcke":
                        dataGridView1[4, i].Value = true;
                        break;

                    case "Mechatronik":
                        dataGridView1[5, i].Value = true;
                        break;
                    case "Alle":
                        dataGridView1[6, i].Value = true;
                        break;
                }
            }
        }

        private void createButtonView()
        {
            int buttonWidth = 130;  // Breite des Buttons
            int buttonHeight = 45;  // Höhe des Buttons
            int spacing = 10;       // Abstand zwischen den Buttons

            for (int i = 0; i < publicPfadEintraege.Count; i++)
            {
                Button button = new Button();
                button.Name = publicPfadEintraege[i].Dateipfad;
                button.Text = publicPfadEintraege[i].Name;
                button.Width = buttonWidth;
                button.Height = buttonHeight;
                button.UseVisualStyleBackColor = true;
                button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

                // Position des Buttons berechnen
                int x = (i % 4) * (buttonWidth + spacing) + spacing;
                int y = (i / 4) * (buttonHeight + spacing) + spacing;
                button.Location = new Point(x, y);

                button.Click += new EventHandler(Button_Click);

                abteilungsTab.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            PfadEintrag passwortEintrag = publicPfadEintraege.FirstOrDefault(x => x.Name == button.Text);
            if (passwortEintrag.Passwort != null)
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = null;
                try
                {
                    string decryptedExcelPasswort = Encoding.UTF8.GetString(Convert.FromBase64String(passwortEintrag.Passwort));
                    workbook = excel.Workbooks.Open(button.Name, Password: Encoding.UTF8.GetString(Convert.FromBase64String(decryptedExcelPasswort)), UpdateLinks: 0);
                    // hier können Sie mit der geöffneten Excel-Datei arbeiten
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                }
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(button.Name);
                }
                catch (Exception)
                {
                }
            }
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                System.Diagnostics.Process.Start(Path.GetDirectoryName(publicPfadEintraege[e.RowIndex].Dateipfad));
            }

            if (e.ColumnIndex == 3 && e.RowIndex != -1)
            {
                if (publicPfadEintraege[e.RowIndex].Abteilung != "Aggregate")
                {
                    publicPfadEintraege[e.RowIndex].Abteilung = "Aggregate";
                    dataGridView1[4, e.RowIndex].Value = dataGridView1[5, e.RowIndex].Value = dataGridView1[6, e.RowIndex].Value = false;

                    string json = JsonConvert.SerializeObject(publicPfadEintraege, Formatting.Indented);
                    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Datenbank.json"), json);
                }
            }

            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                if (publicPfadEintraege[e.RowIndex].Abteilung != "Blöcke")
                {
                    publicPfadEintraege[e.RowIndex].Abteilung = "Blöcke";
                    dataGridView1[3, e.RowIndex].Value = dataGridView1[5, e.RowIndex].Value = dataGridView1[6, e.RowIndex].Value = false;

                    string json = JsonConvert.SerializeObject(publicPfadEintraege, Formatting.Indented);
                    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Datenbank.json"), json);
                }
            }

            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                if (publicPfadEintraege[e.RowIndex].Abteilung != "Mechatronik")
                {
                    publicPfadEintraege[e.RowIndex].Abteilung = "Mechatronik";
                    dataGridView1[3, e.RowIndex].Value = dataGridView1[4, e.RowIndex].Value = dataGridView1[6, e.RowIndex].Value = false;

                    string json = JsonConvert.SerializeObject(publicPfadEintraege, Formatting.Indented);
                    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Datenbank.json"), json);
                }
            }

            if (e.ColumnIndex == 6 && e.RowIndex != -1)
            {
                if (publicPfadEintraege[e.RowIndex].Abteilung != "Alle")
                {
                    publicPfadEintraege[e.RowIndex].Abteilung = "Alle";
                    dataGridView1[3, e.RowIndex].Value = dataGridView1[4, e.RowIndex].Value = dataGridView1[5, e.RowIndex].Value = false;

                    string json = JsonConvert.SerializeObject(publicPfadEintraege, Formatting.Indented);
                    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Datenbank.json"), json);
                }
            }
        }

        private void btnPfadNeuerEintrag_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxNeuerPfad.Text = openFileDialog1.FileName;
                textBoxNeuerPfad.ForeColor = Color.Black;
            }
        }

        private void btnNeuerEintragSichern_Click(object sender, EventArgs e)
        {
            if (textBoxNeuerName.Text != "Name..." && textBoxNeuerName.Text != "" && textBoxNeuerPfad.Text != "Pfad/Link..." && textBoxNeuerPfad.Text != "" && checkBoxAggregate.Checked | checkBoxBloecke.Checked | checkBoxMechatronik.Checked | checkBoxAlle.Checked)
            {
                labelFehlerhafteEingabe.Visible = false;
                string abteilungsName = "";
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is CheckBox cBox)
                    {
                        if (cBox.CheckState == CheckState.Checked)
                        {
                            abteilungsName = cBox.Text;
                        }
                    }
                }

                string neuesExcelPasswort = null;
                if (textBoxExcelPasswort.Text != "Passwort..." && textBoxExcelPasswort.Text != "")
                {
                    string encryptedExcelPasswort = Convert.ToBase64String(Encoding.UTF8.GetBytes(textBoxExcelPasswort.Text));
                    neuesExcelPasswort = Convert.ToBase64String(Encoding.UTF8.GetBytes(encryptedExcelPasswort));
                }

                PfadEintrag neuerEintrag = new PfadEintrag
                {
                    Dateipfad = textBoxNeuerPfad.Text,
                    Name = textBoxNeuerName.Text,
                    Abteilung = abteilungsName,
                    Passwort = neuesExcelPasswort
                };
                
                publicPfadEintraege.Add(neuerEintrag);
                savePublicDB();

                neuesExcelPasswort = null;
                dataGridView1.Rows.Add();
                dataGridView1[1, dataGridView1.RowCount - 1].Value = neuerEintrag.Name;
                dataGridView1[2, dataGridView1.RowCount - 1].Value = neuerEintrag.Dateipfad;

                switch (neuerEintrag.Abteilung)
                {
                    case "Aggregate":
                        dataGridView1[3, dataGridView1.RowCount - 1].Value = true;
                        break;

                    case "Blöcke":
                        dataGridView1[4, dataGridView1.RowCount - 1].Value = true;
                        break;

                    case "Mechatronik":
                        dataGridView1[5, dataGridView1.RowCount - 1].Value = true;
                        break;
                    case "Alle":
                        dataGridView1[6, dataGridView1.RowCount - 1].Value = true;
                        break;
                }
                neuerPfadWaterMarkActive = true;
                textBoxNeuerPfad.Text = "Pfad/Link...";
                textBoxNeuerPfad.ForeColor = Color.Gray;
                neuerNameWaterMarkActive = true;
                textBoxNeuerName.Text = "Name...";
                textBoxNeuerName.ForeColor = Color.Gray;
                createButtonView();
            }
            else
            {
                if (textBoxNeuerName.Text == "Name..." | textBoxNeuerName.Text == "" && textBoxNeuerPfad.Text == "Pfad/Link..." | textBoxNeuerPfad.Text == "" && checkBoxAggregate.Checked == false | checkBoxBloecke.Checked == false | checkBoxMechatronik.Checked == false | checkBoxAlle.Checked == false)
                {
                    labelFehlerhafteEingabe.Visible = true;
                    labelFehlerhafteEingabe.Text = "Fehlende Eingabe!";
                }
                else if (textBoxNeuerName.Text == "Name..." | textBoxNeuerName.Text == "" && textBoxNeuerPfad.Text != "Pfad/Link..." && textBoxNeuerPfad.Text != "" && checkBoxAggregate.Checked | checkBoxBloecke.Checked | checkBoxMechatronik.Checked | checkBoxAlle.Checked)
                {
                    labelFehlerhafteEingabe.Visible = true;
                    labelFehlerhafteEingabe.Text = "Überprüfe Name!";
                }
                else if (textBoxNeuerPfad.Text == "Pfad/Link..." | textBoxNeuerPfad.Text == "" && textBoxNeuerName.Text != "Name..." && textBoxNeuerName.Text != "" && checkBoxAggregate.Checked | checkBoxBloecke.Checked | checkBoxMechatronik.Checked | checkBoxAlle.Checked)
                {
                    labelFehlerhafteEingabe.Visible = true;
                    labelFehlerhafteEingabe.Text = "Überprüfe Pfad!";
                }
                else if (textBoxNeuerPfad.Text != "Pfad/Link..." && textBoxNeuerPfad.Text != "" && textBoxNeuerName.Text != "Name..." && textBoxNeuerName.Text != "" && checkBoxAggregate.Checked == false && checkBoxBloecke.Checked == false && checkBoxMechatronik.Checked == false && checkBoxAlle.Checked == false)
                {
                    labelFehlerhafteEingabe.Visible = true;
                    labelFehlerhafteEingabe.Text = "Überprüfe Abteilung!";
                }
            }
        }

        private void btnEintragLoeschen_Click(object sender, EventArgs e)
        {
            int gridRowCount = dataGridView1.Rows.Count;
            bool[] toDelete = new bool[gridRowCount];
            string[] toDeleteName = new string[gridRowCount];
            for (int i = 0; i < gridRowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1[0, i].Value) == true)
                {
                    toDelete[i] = true;
                    toDeleteName[i] = dataGridView1[1, i].Value.ToString();
                }
            }
            List<int> toDeleteIndex = new List<int>();
            for (int i = 0;i < gridRowCount; i++)
            {
                if (toDelete[i] == true)
                {
                    toDeleteIndex.Add(i);
                }
            }

            toDeleteIndex.Reverse();
            foreach (int index in toDeleteIndex)
            {
                publicPfadEintraege.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
            }

            var allAbteilunsTabButtons = abteilungsTab.Controls.OfType<Button>().ToList();
            var buttonsToKeepAbteilungsTab = allAbteilunsTabButtons.Where(b => !toDeleteName.Contains(b.Text)).ToList();

            foreach (Button button in allAbteilunsTabButtons.Except(buttonsToKeepAbteilungsTab))
            {
                abteilungsTab.Controls.Remove(button);
            }
            int newButtonIndex = 0;
            int buttonWidth = 130;
            int buttonHeight = 45;
            int spacing = 10;
            foreach (Button button in buttonsToKeepAbteilungsTab)
            {
                int x = (newButtonIndex % 4) * (buttonWidth + spacing) + spacing;
                int y = (newButtonIndex / 4) * (buttonHeight + spacing) + spacing;
                button.Location = new Point(x, y);
                newButtonIndex++;
            }
            savePublicDB();
        }

        private void checkBoxAggregate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAggregate.CheckState == CheckState.Checked)
            {
                checkBoxBloecke.CheckState = checkBoxMechatronik.CheckState = checkBoxAlle.CheckState = CheckState.Unchecked;
            }
        }
        private void checkBoxBloecke_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBloecke.CheckState == CheckState.Checked)
            {
                checkBoxAggregate.CheckState = checkBoxMechatronik.CheckState = checkBoxAlle.CheckState = CheckState.Unchecked;
            }
        }
        private void checkBoxMechatronik_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMechatronik.CheckState == CheckState.Checked)
            {
                checkBoxAggregate.CheckState = checkBoxBloecke.CheckState = checkBoxAlle.CheckState = CheckState.Unchecked;
            }
        }
        private void checkBoxAlle_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlle.CheckState == CheckState.Checked)
            {
                checkBoxAggregate.CheckState = checkBoxBloecke.CheckState = checkBoxMechatronik.CheckState = CheckState.Unchecked;
            }
        }

        private void btnShowPasswort_Click(object sender, EventArgs e)
        {
            if (textBoxExcelPasswort.PasswordChar == '*')
            {
                textBoxExcelPasswort.PasswordChar = '\0';
            }
            else
            {
                textBoxExcelPasswort.PasswordChar = '*';
            }
            
        }

        void savePublicDB()
        {
            string json = JsonConvert.SerializeObject(publicPfadEintraege, Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Datenbank.json"), json);
        }
    }
}