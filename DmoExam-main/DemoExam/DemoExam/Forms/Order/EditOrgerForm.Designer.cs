namespace DemoExam.Forms
{
    partial class EditOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxProblem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewСlient = new System.Windows.Forms.DataGridView();
            this.buttonRegСlient = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.dataGridViewMaster = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditClient = new System.Windows.Forms.Button();
            this.buttonEditMaster = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewСlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(119, 13);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(231, 21);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // comboBoxProblem
            // 
            this.comboBoxProblem.FormattingEnabled = true;
            this.comboBoxProblem.Location = new System.Drawing.Point(119, 40);
            this.comboBoxProblem.Name = "comboBoxProblem";
            this.comboBoxProblem.Size = new System.Drawing.Size(231, 21);
            this.comboBoxProblem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип оборудования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип проблемы";
            // 
            // dataGridViewСlient
            // 
            this.dataGridViewСlient.AllowUserToAddRows = false;
            this.dataGridViewСlient.AllowUserToDeleteRows = false;
            this.dataGridViewСlient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewСlient.Location = new System.Drawing.Point(359, 53);
            this.dataGridViewСlient.MultiSelect = false;
            this.dataGridViewСlient.Name = "dataGridViewСlient";
            this.dataGridViewСlient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewСlient.Size = new System.Drawing.Size(397, 190);
            this.dataGridViewСlient.TabIndex = 4;
            // 
            // buttonRegСlient
            // 
            this.buttonRegСlient.Location = new System.Drawing.Point(765, 91);
            this.buttonRegСlient.Name = "buttonRegСlient";
            this.buttonRegСlient.Size = new System.Drawing.Size(179, 49);
            this.buttonRegСlient.TabIndex = 5;
            this.buttonRegСlient.Text = "зарегистрировать нового пользователя";
            this.buttonRegСlient.UseVisualStyleBackColor = true;
            this.buttonRegСlient.Click += new System.EventHandler(this.buttonRegСlient_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(765, 29);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(179, 20);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.Text = "Поиск";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(762, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "поиск по ";
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Location = new System.Drawing.Point(823, 53);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOrder.TabIndex = 9;
            // 
            // dataGridViewMaster
            // 
            this.dataGridViewMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaster.Location = new System.Drawing.Point(13, 155);
            this.dataGridViewMaster.MultiSelect = false;
            this.dataGridViewMaster.Name = "dataGridViewMaster";
            this.dataGridViewMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaster.Size = new System.Drawing.Size(340, 88);
            this.dataGridViewMaster.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Мастера";
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(12, 408);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(932, 28);
            this.buttonCreateOrder.TabIndex = 14;
            this.buttonCreateOrder.Text = "Изменить заявку";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrdert_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Клинеты";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(12, 271);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(932, 131);
            this.textBoxComment.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Коментарий";
            // 
            // buttonEditClient
            // 
            this.buttonEditClient.Location = new System.Drawing.Point(359, 24);
            this.buttonEditClient.Name = "buttonEditClient";
            this.buttonEditClient.Size = new System.Drawing.Size(397, 23);
            this.buttonEditClient.TabIndex = 19;
            this.buttonEditClient.Text = "изменить";
            this.buttonEditClient.UseVisualStyleBackColor = true;
            this.buttonEditClient.Click += new System.EventHandler(this.buttonEditClient_Click);
            // 
            // buttonEditMaster
            // 
            this.buttonEditMaster.Location = new System.Drawing.Point(12, 126);
            this.buttonEditMaster.Name = "buttonEditMaster";
            this.buttonEditMaster.Size = new System.Drawing.Size(341, 23);
            this.buttonEditMaster.TabIndex = 20;
            this.buttonEditMaster.Text = "изменить";
            this.buttonEditMaster.UseVisualStyleBackColor = true;
            this.buttonEditMaster.Click += new System.EventHandler(this.buttonEditMaster_Click);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(119, 67);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(231, 21);
            this.comboBoxStatus.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Статус";
            // 
            // EditOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 445);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.buttonEditMaster);
            this.Controls.Add(this.buttonEditClient);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewMaster);
            this.Controls.Add(this.comboBoxOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonRegСlient);
            this.Controls.Add(this.dataGridViewСlient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProblem);
            this.Controls.Add(this.comboBoxType);
            this.Name = "EditOrderForm";
            this.Text = "CreateOrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewСlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewСlient;
        private System.Windows.Forms.Button buttonRegСlient;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxOrder;
        private System.Windows.Forms.DataGridView dataGridViewMaster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditClient;
        private System.Windows.Forms.Button buttonEditMaster;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label7;
    }
}