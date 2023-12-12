namespace DemoExam
{
    partial class AdminForm
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
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.buttonPerson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(254, 12);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(236, 174);
            this.buttonAddOrder.TabIndex = 0;
            this.buttonAddOrder.Text = "Заявки";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonPerson
            // 
            this.buttonPerson.Location = new System.Drawing.Point(12, 12);
            this.buttonPerson.Name = "buttonPerson";
            this.buttonPerson.Size = new System.Drawing.Size(236, 174);
            this.buttonPerson.TabIndex = 1;
            this.buttonPerson.Text = "Пользователи";
            this.buttonPerson.UseVisualStyleBackColor = true;
            this.buttonPerson.Click += new System.EventHandler(this.buttonPerson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPerson);
            this.Controls.Add(this.buttonAddOrder);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.Button buttonPerson;
        private System.Windows.Forms.Label label1;
    }
}