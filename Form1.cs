using System;
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
using System.Globalization;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
// Latest Version
namespace Dateiverwaltung
{
    public partial class Form1 : Form
    {
        List<publicPfadEintrag> publicPfadEintraege;
        List<privatPfadEintrag> privatPfadEintraege;
        List<publicPfadEintrag> publicPfadEintraegeToDisplay = new List<publicPfadEintrag>();
        List<config> configEintraege = new List<config>();

        string configPath = "C:\\Dateiverwaltung";
        string configName = "config.ini";

        string publicDBPath = Path.Combine(Environment.CurrentDirectory).ToString();
        string publicDBName = "publicDB.json";

        string privatDBName = "privatDB.json";

        string[] abteilungsAuswahl = new string[] { "Aggregate", "Blöcke", "Mechatronik", "Ventile" };

        bool neuerPfadWaterMarkActive = true;
        bool neuerNameWaterMarkActive = true;
        bool passwortNeueDateiWaterMark = true;
        public Form1()
        {
            InitializeComponent();

            try
            {
                if (File.Exists(string.Join("\\", configPath, configName)))
                {
                    configEintraege = JsonConvert.DeserializeObject<List<config>>(File.ReadAllText(string.Join("\\", configPath, configName)));
                    Debug.WriteLine("Abteilung in Config: " + configEintraege[0].Abteilung);
                    Debug.WriteLine("privatDBPath in Config: " + configEintraege[0].privatDBPath);
                }
                else
                {
                    Debug.WriteLine("Config nicht vorhanden. Wird erstellt");
                    config newConfig = new config
                    {
                        privatDBPath = configPath,
                        Abteilung = null
                    };
                    configEintraege.Add(newConfig);

                    string json = JsonConvert.SerializeObject(configEintraege, Formatting.Indented);
                    File.WriteAllText(Path.Combine(configPath, configName), json);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Datei " + configName + " in Pfad " + "'" + configPath + "'" + " nicht vorhanden!");
                throw;
            }

            try
            {
                publicPfadEintraege = JsonConvert.DeserializeObject<List<publicPfadEintrag>>(File.ReadAllText(string.Join(publicDBPath, publicDBName)));
            }
            catch (Exception)
            {
                MessageBox.Show("Datei " + publicDBName + " in Pfad " + "'" + publicDBPath + "'" + " nicht vorhanden!");
                throw;
            }

            try
            {
                if (configEintraege[0].privatDBPath != null)
                {
                    if (File.Exists(string.Join("\\", configEintraege[0].privatDBPath, privatDBName)))
                    {
                        privatPfadEintraege = JsonConvert.DeserializeObject<List<privatPfadEintrag>>(File.ReadAllText(string.Join("\\", configEintraege[0].privatDBPath, privatDBName)));
                    }
                }
                else
                {
                    btnCreatePrivatDB.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Datei " + privatDBName + " in Pfad " + "'" + configEintraege[0].privatDBPath + "'" + " nicht vorhanden!");
                throw;
            }

            comboBoxAbteilungsauswahl.Items.AddRange(abteilungsAuswahl);
            comboBoxAbteilungsauswahl.SelectedItem = configEintraege[0].Abteilung;
            
            createPublicGridView();
            createPublicButtonView();
            
            displayUserName.Text = string.Join("\\", Environment.UserDomainName, Environment.UserName);
            displayComputerName.Text = Environment.MachineName;

            textBoxPublicDBPath.Text = string.Join("\\", publicDBPath, publicDBName);
            textBoxPrivatDBPath.Text = string.Join("\\", configEintraege[0].privatDBPath, privatDBName);

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

        private void comboBoxAbteilungsauswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            configEintraege[0].Abteilung = comboBoxAbteilungsauswahl.SelectedItem.ToString();
            saveConfig();
            updateButtonView();
        }

            private void createPublicGridView()
        {
            //Row 0 Löschen 1 Name 2 Dateipfad 3 Aggregate 4 Blöcke 5 Mechatronik 6 Alle
            for (int i = 0; i < publicPfadEintraege.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[1, i].Value = publicPfadEintraege[i].Name;
                dataGridView1[2, i].Value = publicPfadEintraege[i].Dateipfad;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.HeaderText == publicPfadEintraege[i].Abteilung && dataGridView1[col.Index, i] is DataGridViewCheckBoxCell)
                    {
                        dataGridView1[col.Index, i].Value = true;
                    }
                }
                
                /*
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
                    case "Ventile":
                        dataGridView1[6, i].Value = true;
                        break;
                    case "Alle":
                        dataGridView1[7, i].Value = true;
                        break;
                }*/
            }
        }

        private void createPublicButtonView()
        {
            int buttonWidth = 130;  // Breite des Buttons
            int buttonHeight = 45;  // Höhe des Buttons
            int spacing = 10;       // Abstand zwischen den Buttons
            publicPfadEintraegeToDisplay.Clear();
            List<publicPfadEintrag> publicPfadEintraegeSorted = publicPfadEintraege.Where(x => x.Abteilung == configEintraege[0].Abteilung | x.Abteilung == "Alle").ToList();
            foreach (publicPfadEintrag eintrag in publicPfadEintraegeSorted)
            {
                publicPfadEintraegeToDisplay.Add(eintrag);
            }

            for (int i = 0; i < publicPfadEintraegeToDisplay.Count; i++)
            {
                Button button = new Button();
                button.Name = publicPfadEintraegeToDisplay[i].Dateipfad;
                button.Text = publicPfadEintraegeToDisplay[i].Name;
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
            publicPfadEintrag passwortEintrag = publicPfadEintraege.FirstOrDefault(x => x.Name == button.Text);
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

        object oldNameValue = "";
        object oldPathValue = "";
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                oldNameValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
            if (e.ColumnIndex == 2)
            {
                oldPathValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                object newNameValue;
                if (oldNameValue != dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    newNameValue = publicPfadEintraege[e.RowIndex].Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    foreach (Button button in abteilungsTab.Controls.OfType<Button>())
                    {
                        if (button.Text == oldNameValue.ToString())
                        {
                            button.Text = newNameValue.ToString();
                            savePublicDB();
                        }
                    }
                }
            }
            if (e.ColumnIndex == 2)
            {
                object newPathValue;
                if (oldPathValue != dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    newPathValue = publicPfadEintraege[e.RowIndex].Dateipfad = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    foreach (Button button in abteilungsTab.Controls.OfType<Button>())
                    {
                        if (button.Name == oldPathValue.ToString())
                        {
                            button.Name = newPathValue.ToString();
                            savePublicDB();
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                try
                {
                    System.Diagnostics.Process.Start(Path.GetDirectoryName(publicPfadEintraege[e.RowIndex].Dateipfad));
                }
                catch (Exception)
                {
                }
            }
            updateButtonView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Überprüfen, ob die geklickte Zelle eine CheckBox ist
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                // Deaktivieren Sie alle anderen CheckBoxes in der Zeile
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != e.ColumnIndex && cell.ColumnIndex != 0 && cell is DataGridViewCheckBoxCell)
                    {
                        cell.Value = false;
                    }
                }
                publicPfadEintraege[e.RowIndex].Abteilung = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                updateButtonView();
            }
        }

        private void btnPublicPfadNeuerEintrag_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxNeuerPfad.Text = openFileDialog1.FileName;
                textBoxNeuerPfad.ForeColor = Color.Black;
            }
        }

        private void btnNeuerPublicEintragSichern_Click(object sender, EventArgs e)
        {
            if (textBoxNeuerName.Text != "Name..." && textBoxNeuerName.Text != "" && textBoxNeuerPfad.Text != "Pfad/Link..." && textBoxNeuerPfad.Text != "" && checkBoxAggregate.Checked | checkBoxBloecke.Checked | checkBoxMechatronik.Checked | checkBoxVentile.Checked | checkBoxAlle.Checked)
            {
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

                publicPfadEintrag neuerEintrag = new publicPfadEintrag
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
                    case "Ventile":
                        dataGridView1[6, dataGridView1.RowCount - 1].Value = true;
                        break;
                    case "Alle":
                        dataGridView1[7, dataGridView1.RowCount - 1].Value = true;
                        break;
                }

                neuerPfadWaterMarkActive = true;
                textBoxNeuerPfad.Text = "Pfad/Link...";
                textBoxNeuerPfad.ForeColor = Color.Gray;
                neuerNameWaterMarkActive = true;
                textBoxNeuerName.Text = "Name...";
                textBoxNeuerName.ForeColor = Color.Gray;
                createPublicButtonView();
            }
        }

        private void btnPublicEintragLoeschen_Click(object sender, EventArgs e)
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
            updateButtonView();
            /*            var allAbteilunsTabButtons = abteilungsTab.Controls.OfType<Button>().ToList();
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
            */
        }

        private void Group1_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox selectedCheckbox = (CheckBox)sender;
            if (selectedCheckbox.Checked)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is CheckBox cBox && cBox != selectedCheckbox)
                    {
                        cBox.Checked = false;
                    }
                }
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
            File.WriteAllText(string.Join(publicDBPath, publicDBName), json);
        }

        void saveConfig()
        {
            string config = JsonConvert.SerializeObject(configEintraege, Formatting.Indented);
            File.WriteAllText(string.Join("\\", configPath, configName), config);
        }

        private void btnReiheNachOben_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int currentIndex = dataGridView1.SelectedRows[0].Index;
                if (currentIndex > 0)
                {
                    DataGridViewRow rowToMove = dataGridView1.Rows[currentIndex];
                    publicPfadEintrag publicPfadEintragToMove = publicPfadEintraege[currentIndex];
                    publicPfadEintraege.RemoveAt(currentIndex);
                    publicPfadEintraege.Insert(currentIndex - 1, publicPfadEintragToMove);
                    dataGridView1.Rows.RemoveAt(currentIndex);
                    dataGridView1.Rows.Insert(currentIndex - 1, rowToMove);
                    dataGridView1.Rows[currentIndex - 1].Selected = true;
                    updateButtonView();
                }
            }
        }

        private void btnReiheNachUnten_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int currentIndex = dataGridView1.SelectedRows[0].Index;
                if (currentIndex < dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow rowToMove = dataGridView1.Rows[currentIndex];
                    publicPfadEintrag publicPfadEintragToMove = publicPfadEintraege[currentIndex];
                    publicPfadEintraege.RemoveAt(currentIndex);
                    publicPfadEintraege.Insert(currentIndex + 1, publicPfadEintragToMove);
                    dataGridView1.Rows.RemoveAt(currentIndex);
                    dataGridView1.Rows.Insert(currentIndex + 1, rowToMove);
                    dataGridView1.Rows[currentIndex + 1].Selected = true;
                    updateButtonView();
                }
            }
        }
        private void updateButtonView()
        {
            foreach (Button button in abteilungsTab.Controls.OfType<Button>().ToList())
            {
                abteilungsTab.Controls.Remove(button);
                button.Dispose();
            }
            savePublicDB();
            createPublicButtonView();
        }
    }
}
