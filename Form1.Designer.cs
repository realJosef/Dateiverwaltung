using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Dateiverwaltung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.abteilungsTab = new System.Windows.Forms.TabPage();
            this.eigeneTab = new System.Windows.Forms.TabPage();
            this.verwaltungsTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReiheNachUnten = new System.Windows.Forms.Button();
            this.btnReiheNachOben = new System.Windows.Forms.Button();
            this.btnPublicEintragLoeschen = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loeschenColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateipfadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aggregateColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bloeckeColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mechatronikColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alleColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAlle = new System.Windows.Forms.CheckBox();
            this.checkBoxMechatronik = new System.Windows.Forms.CheckBox();
            this.checkBoxBloecke = new System.Windows.Forms.CheckBox();
            this.checkBoxAggregate = new System.Windows.Forms.CheckBox();
            this.btnShowPasswort = new System.Windows.Forms.Button();
            this.textBoxExcelPasswort = new System.Windows.Forms.TextBox();
            this.labelFehlerhafteEingabe = new System.Windows.Forms.Label();
            this.textBoxNeuerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPublicPfadNeuerEintrag = new System.Windows.Forms.Button();
            this.btnNeuerPublicEintragSichern = new System.Windows.Forms.Button();
            this.textBoxNeuerPfad = new System.Windows.Forms.TextBox();
            this.userTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxPrivatDBPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPublicDBPath = new System.Windows.Forms.TextBox();
            this.displayComputerName = new System.Windows.Forms.Label();
            this.displayUserName = new System.Windows.Forms.Label();
            this.labelComputerName = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCreatePrivatDB = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.verwaltungsTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.userTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tabControl1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(801, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.abteilungsTab);
            this.tabControl1.Controls.Add(this.eigeneTab);
            this.tabControl1.Controls.Add(this.verwaltungsTab);
            this.tabControl1.Controls.Add(this.userTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // abteilungsTab
            // 
            this.abteilungsTab.Location = new System.Drawing.Point(4, 25);
            this.abteilungsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.abteilungsTab.Name = "abteilungsTab";
            this.abteilungsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.abteilungsTab.Size = new System.Drawing.Size(789, 419);
            this.abteilungsTab.TabIndex = 0;
            this.abteilungsTab.Text = "Abteilung";
            this.abteilungsTab.UseVisualStyleBackColor = true;
            // 
            // eigeneTab
            // 
            this.eigeneTab.Location = new System.Drawing.Point(4, 25);
            this.eigeneTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eigeneTab.Name = "eigeneTab";
            this.eigeneTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eigeneTab.Size = new System.Drawing.Size(789, 419);
            this.eigeneTab.TabIndex = 1;
            this.eigeneTab.Text = "Eigene";
            this.eigeneTab.UseVisualStyleBackColor = true;
            // 
            // verwaltungsTab
            // 
            this.verwaltungsTab.Controls.Add(this.groupBox2);
            this.verwaltungsTab.Controls.Add(this.groupBox1);
            this.verwaltungsTab.Location = new System.Drawing.Point(4, 25);
            this.verwaltungsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.verwaltungsTab.Name = "verwaltungsTab";
            this.verwaltungsTab.Size = new System.Drawing.Size(789, 419);
            this.verwaltungsTab.TabIndex = 2;
            this.verwaltungsTab.Text = "Verwaltung";
            this.verwaltungsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReiheNachUnten);
            this.groupBox2.Controls.Add(this.btnReiheNachOben);
            this.groupBox2.Controls.Add(this.btnPublicEintragLoeschen);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(5, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(781, 315);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eintrag Löschen";
            // 
            // btnReiheNachUnten
            // 
            this.btnReiheNachUnten.Location = new System.Drawing.Point(117, 288);
            this.btnReiheNachUnten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReiheNachUnten.Name = "btnReiheNachUnten";
            this.btnReiheNachUnten.Size = new System.Drawing.Size(105, 23);
            this.btnReiheNachUnten.TabIndex = 11;
            this.btnReiheNachUnten.Text = "Nach Unten";
            this.btnReiheNachUnten.UseVisualStyleBackColor = true;
            this.btnReiheNachUnten.Click += new System.EventHandler(this.btnReiheNachUnten_Click);
            // 
            // btnReiheNachOben
            // 
            this.btnReiheNachOben.Location = new System.Drawing.Point(6, 288);
            this.btnReiheNachOben.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReiheNachOben.Name = "btnReiheNachOben";
            this.btnReiheNachOben.Size = new System.Drawing.Size(105, 23);
            this.btnReiheNachOben.TabIndex = 10;
            this.btnReiheNachOben.Text = "Nach Oben";
            this.btnReiheNachOben.UseVisualStyleBackColor = true;
            this.btnReiheNachOben.Click += new System.EventHandler(this.btnReiheNachOben_Click);
            // 
            // btnPublicEintragLoeschen
            // 
            this.btnPublicEintragLoeschen.Location = new System.Drawing.Point(669, 288);
            this.btnPublicEintragLoeschen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPublicEintragLoeschen.Name = "btnPublicEintragLoeschen";
            this.btnPublicEintragLoeschen.Size = new System.Drawing.Size(105, 23);
            this.btnPublicEintragLoeschen.TabIndex = 9;
            this.btnPublicEintragLoeschen.Text = "Löschen";
            this.btnPublicEintragLoeschen.UseVisualStyleBackColor = true;
            this.btnPublicEintragLoeschen.Click += new System.EventHandler(this.btnPublicEintragLoeschen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loeschenColumn,
            this.nameColumn,
            this.dateipfadColumn,
            this.aggregateColumn,
            this.bloeckeColumn,
            this.mechatronikColumn,
            this.alleColumn});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(781, 258);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // loeschenColumn
            // 
            this.loeschenColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.loeschenColumn.HeaderText = "Löschen";
            this.loeschenColumn.MinimumWidth = 6;
            this.loeschenColumn.Name = "loeschenColumn";
            this.loeschenColumn.Width = 64;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.MinimumWidth = 6;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 73;
            // 
            // dateipfadColumn
            // 
            this.dateipfadColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateipfadColumn.HeaderText = "Dateipfad";
            this.dateipfadColumn.MinimumWidth = 6;
            this.dateipfadColumn.Name = "dateipfadColumn";
            // 
            // aggregateColumn
            // 
            this.aggregateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.aggregateColumn.HeaderText = "Aggregate";
            this.aggregateColumn.MinimumWidth = 6;
            this.aggregateColumn.Name = "aggregateColumn";
            this.aggregateColumn.Width = 77;
            // 
            // bloeckeColumn
            // 
            this.bloeckeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.bloeckeColumn.HeaderText = "Blöcke";
            this.bloeckeColumn.MinimumWidth = 6;
            this.bloeckeColumn.Name = "bloeckeColumn";
            this.bloeckeColumn.Width = 55;
            // 
            // mechatronikColumn
            // 
            this.mechatronikColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.mechatronikColumn.HeaderText = "Mechatronik";
            this.mechatronikColumn.MinimumWidth = 6;
            this.mechatronikColumn.Name = "mechatronikColumn";
            this.mechatronikColumn.Width = 86;
            // 
            // alleColumn
            // 
            this.alleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.alleColumn.HeaderText = "Alle";
            this.alleColumn.MinimumWidth = 6;
            this.alleColumn.Name = "alleColumn";
            this.alleColumn.Width = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxAlle);
            this.groupBox1.Controls.Add(this.checkBoxMechatronik);
            this.groupBox1.Controls.Add(this.checkBoxBloecke);
            this.groupBox1.Controls.Add(this.checkBoxAggregate);
            this.groupBox1.Controls.Add(this.btnShowPasswort);
            this.groupBox1.Controls.Add(this.textBoxExcelPasswort);
            this.groupBox1.Controls.Add(this.labelFehlerhafteEingabe);
            this.groupBox1.Controls.Add(this.textBoxNeuerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPublicPfadNeuerEintrag);
            this.groupBox1.Controls.Add(this.btnNeuerPublicEintragSichern);
            this.groupBox1.Controls.Add(this.textBoxNeuerPfad);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(781, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neuer Eintrag";
            // 
            // checkBoxAlle
            // 
            this.checkBoxAlle.AutoSize = true;
            this.checkBoxAlle.Location = new System.Drawing.Point(547, 56);
            this.checkBoxAlle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAlle.Name = "checkBoxAlle";
            this.checkBoxAlle.Size = new System.Drawing.Size(52, 20);
            this.checkBoxAlle.TabIndex = 17;
            this.checkBoxAlle.Text = "Alle";
            this.checkBoxAlle.UseVisualStyleBackColor = true;
            this.checkBoxAlle.CheckedChanged += new System.EventHandler(this.Group1_CheckBox_CheckedChanged);
            // 
            // checkBoxMechatronik
            // 
            this.checkBoxMechatronik.AutoSize = true;
            this.checkBoxMechatronik.Location = new System.Drawing.Point(437, 56);
            this.checkBoxMechatronik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxMechatronik.Name = "checkBoxMechatronik";
            this.checkBoxMechatronik.Size = new System.Drawing.Size(102, 20);
            this.checkBoxMechatronik.TabIndex = 16;
            this.checkBoxMechatronik.Text = "Mechatronik";
            this.checkBoxMechatronik.UseVisualStyleBackColor = true;
            this.checkBoxMechatronik.CheckedChanged += new System.EventHandler(this.Group1_CheckBox_CheckedChanged);
            // 
            // checkBoxBloecke
            // 
            this.checkBoxBloecke.AutoSize = true;
            this.checkBoxBloecke.Location = new System.Drawing.Point(361, 56);
            this.checkBoxBloecke.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxBloecke.Name = "checkBoxBloecke";
            this.checkBoxBloecke.Size = new System.Drawing.Size(71, 20);
            this.checkBoxBloecke.TabIndex = 15;
            this.checkBoxBloecke.Text = "Blöcke";
            this.checkBoxBloecke.UseVisualStyleBackColor = true;
            this.checkBoxBloecke.CheckedChanged += new System.EventHandler(this.Group1_CheckBox_CheckedChanged);
            // 
            // checkBoxAggregate
            // 
            this.checkBoxAggregate.AutoSize = true;
            this.checkBoxAggregate.Location = new System.Drawing.Point(261, 56);
            this.checkBoxAggregate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAggregate.Name = "checkBoxAggregate";
            this.checkBoxAggregate.Size = new System.Drawing.Size(93, 20);
            this.checkBoxAggregate.TabIndex = 14;
            this.checkBoxAggregate.Text = "Aggregate";
            this.checkBoxAggregate.UseVisualStyleBackColor = true;
            this.checkBoxAggregate.CheckedChanged += new System.EventHandler(this.Group1_CheckBox_CheckedChanged);
            // 
            // btnShowPasswort
            // 
            this.btnShowPasswort.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPasswort.Image")));
            this.btnShowPasswort.Location = new System.Drawing.Point(749, 50);
            this.btnShowPasswort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowPasswort.Name = "btnShowPasswort";
            this.btnShowPasswort.Size = new System.Drawing.Size(32, 30);
            this.btnShowPasswort.TabIndex = 13;
            this.btnShowPasswort.UseVisualStyleBackColor = true;
            this.btnShowPasswort.Click += new System.EventHandler(this.btnShowPasswort_Click);
            // 
            // textBoxExcelPasswort
            // 
            this.textBoxExcelPasswort.ForeColor = System.Drawing.Color.Gray;
            this.textBoxExcelPasswort.Location = new System.Drawing.Point(604, 55);
            this.textBoxExcelPasswort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxExcelPasswort.Name = "textBoxExcelPasswort";
            this.textBoxExcelPasswort.Size = new System.Drawing.Size(148, 22);
            this.textBoxExcelPasswort.TabIndex = 12;
            this.textBoxExcelPasswort.Text = "Passwort...";
            // 
            // labelFehlerhafteEingabe
            // 
            this.labelFehlerhafteEingabe.AutoSize = true;
            this.labelFehlerhafteEingabe.ForeColor = System.Drawing.Color.Crimson;
            this.labelFehlerhafteEingabe.Location = new System.Drawing.Point(5, 58);
            this.labelFehlerhafteEingabe.Name = "labelFehlerhafteEingabe";
            this.labelFehlerhafteEingabe.Size = new System.Drawing.Size(123, 16);
            this.labelFehlerhafteEingabe.TabIndex = 11;
            this.labelFehlerhafteEingabe.Text = "Eingabe Fehlerhaft!";
            this.labelFehlerhafteEingabe.Visible = false;
            // 
            // textBoxNeuerName
            // 
            this.textBoxNeuerName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxNeuerName.Location = new System.Drawing.Point(117, 23);
            this.textBoxNeuerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNeuerName.Name = "textBoxNeuerName";
            this.textBoxNeuerName.Size = new System.Drawing.Size(101, 22);
            this.textBoxNeuerName.TabIndex = 10;
            this.textBoxNeuerName.Text = "Name...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Abteilungsauswahl:";
            // 
            // btnPublicPfadNeuerEintrag
            // 
            this.btnPublicPfadNeuerEintrag.Location = new System.Drawing.Point(733, 21);
            this.btnPublicPfadNeuerEintrag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPublicPfadNeuerEintrag.Name = "btnPublicPfadNeuerEintrag";
            this.btnPublicPfadNeuerEintrag.Size = new System.Drawing.Size(41, 23);
            this.btnPublicPfadNeuerEintrag.TabIndex = 2;
            this.btnPublicPfadNeuerEintrag.Text = "...";
            this.btnPublicPfadNeuerEintrag.UseVisualStyleBackColor = true;
            this.btnPublicPfadNeuerEintrag.Click += new System.EventHandler(this.btnPublicPfadNeuerEintrag_Click);
            // 
            // btnNeuerPublicEintragSichern
            // 
            this.btnNeuerPublicEintragSichern.Location = new System.Drawing.Point(5, 22);
            this.btnNeuerPublicEintragSichern.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNeuerPublicEintragSichern.Name = "btnNeuerPublicEintragSichern";
            this.btnNeuerPublicEintragSichern.Size = new System.Drawing.Size(105, 23);
            this.btnNeuerPublicEintragSichern.TabIndex = 1;
            this.btnNeuerPublicEintragSichern.Text = "Hinzufügen";
            this.btnNeuerPublicEintragSichern.UseVisualStyleBackColor = true;
            this.btnNeuerPublicEintragSichern.Click += new System.EventHandler(this.btnNeuerPublicEintragSichern_Click);
            // 
            // textBoxNeuerPfad
            // 
            this.textBoxNeuerPfad.ForeColor = System.Drawing.Color.Gray;
            this.textBoxNeuerPfad.Location = new System.Drawing.Point(224, 22);
            this.textBoxNeuerPfad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNeuerPfad.Name = "textBoxNeuerPfad";
            this.textBoxNeuerPfad.Size = new System.Drawing.Size(503, 22);
            this.textBoxNeuerPfad.TabIndex = 0;
            this.textBoxNeuerPfad.Text = "Pfad/Link...";
            // 
            // userTab
            // 
            this.userTab.Controls.Add(this.groupBox4);
            this.userTab.Controls.Add(this.groupBox3);
            this.userTab.Controls.Add(this.displayComputerName);
            this.userTab.Controls.Add(this.displayUserName);
            this.userTab.Controls.Add(this.labelComputerName);
            this.userTab.Controls.Add(this.labelUserName);
            this.userTab.Location = new System.Drawing.Point(4, 25);
            this.userTab.Name = "userTab";
            this.userTab.Size = new System.Drawing.Size(789, 419);
            this.userTab.TabIndex = 3;
            this.userTab.Text = "User";
            this.userTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreatePrivatDB);
            this.groupBox4.Controls.Add(this.textBoxPrivatDBPath);
            this.groupBox4.Location = new System.Drawing.Point(7, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(779, 85);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Privater Datenbank Pfad";
            // 
            // textBoxPrivatDBPath
            // 
            this.textBoxPrivatDBPath.Location = new System.Drawing.Point(7, 22);
            this.textBoxPrivatDBPath.Name = "textBoxPrivatDBPath";
            this.textBoxPrivatDBPath.Size = new System.Drawing.Size(766, 22);
            this.textBoxPrivatDBPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxPublicDBPath);
            this.groupBox3.Location = new System.Drawing.Point(6, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(779, 58);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Öffentlicher Datenbank Pfad";
            // 
            // textBoxPublicDBPath
            // 
            this.textBoxPublicDBPath.Location = new System.Drawing.Point(7, 22);
            this.textBoxPublicDBPath.Name = "textBoxPublicDBPath";
            this.textBoxPublicDBPath.Size = new System.Drawing.Size(766, 22);
            this.textBoxPublicDBPath.TabIndex = 0;
            // 
            // displayComputerName
            // 
            this.displayComputerName.AutoSize = true;
            this.displayComputerName.Location = new System.Drawing.Point(128, 35);
            this.displayComputerName.Name = "displayComputerName";
            this.displayComputerName.Size = new System.Drawing.Size(146, 16);
            this.displayComputerName.TabIndex = 4;
            this.displayComputerName.Text = "displayComputerName";
            // 
            // displayUserName
            // 
            this.displayUserName.AutoSize = true;
            this.displayUserName.Location = new System.Drawing.Point(128, 9);
            this.displayUserName.Name = "displayUserName";
            this.displayUserName.Size = new System.Drawing.Size(117, 16);
            this.displayUserName.TabIndex = 3;
            this.displayUserName.Text = "displayUserName";
            // 
            // labelComputerName
            // 
            this.labelComputerName.AutoSize = true;
            this.labelComputerName.Location = new System.Drawing.Point(10, 35);
            this.labelComputerName.Name = "labelComputerName";
            this.labelComputerName.Size = new System.Drawing.Size(105, 16);
            this.labelComputerName.TabIndex = 2;
            this.labelComputerName.Text = "ComputerName:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(10, 9);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(76, 16);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "UserName:";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCreatePrivatDB
            // 
            this.btnCreatePrivatDB.Location = new System.Drawing.Point(7, 51);
            this.btnCreatePrivatDB.Name = "btnCreatePrivatDB";
            this.btnCreatePrivatDB.Size = new System.Drawing.Size(125, 23);
            this.btnCreatePrivatDB.TabIndex = 1;
            this.btnCreatePrivatDB.Text = "Erstelle Datei";
            this.btnCreatePrivatDB.UseVisualStyleBackColor = true;
            this.btnCreatePrivatDB.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Dateiverwaltung";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.verwaltungsTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.userTab.ResumeLayout(false);
            this.userTab.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage abteilungsTab;
        private System.Windows.Forms.TabPage eigeneTab;
        private System.Windows.Forms.TabPage verwaltungsTab;
        private GroupBox groupBox1;
        private Button btnPublicPfadNeuerEintrag;
        private Button btnNeuerPublicEintragSichern;
        private TextBox textBoxNeuerPfad;
        private GroupBox groupBox2;
        private Button btnPublicEintragLoeschen;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn loeschenColumn;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn dateipfadColumn;
        private DataGridViewCheckBoxColumn aggregateColumn;
        private DataGridViewCheckBoxColumn bloeckeColumn;
        private DataGridViewCheckBoxColumn mechatronikColumn;
        private DataGridViewCheckBoxColumn alleColumn;
        private OpenFileDialog openFileDialog1;
        private TextBox textBoxNeuerName;
        private Label labelFehlerhafteEingabe;
        private TextBox textBoxExcelPasswort;
        private Button btnShowPasswort;
        private CheckBox checkBoxAlle;
        private CheckBox checkBoxMechatronik;
        private CheckBox checkBoxBloecke;
        private CheckBox checkBoxAggregate;
        private Label label1;
        private Button btnReiheNachUnten;
        private Button btnReiheNachOben;
        private TabPage userTab;
        private Label labelComputerName;
        private Label labelUserName;
        private Label displayUserName;
        private Label displayComputerName;
        private GroupBox groupBox3;
        private TextBox textBoxPublicDBPath;
        private GroupBox groupBox4;
        private TextBox textBoxPrivatDBPath;
        private Button btnCreatePrivatDB;
    }
}

