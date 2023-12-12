namespace DemoExam.Forms
{
    partial class OrdersForm
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
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonAddOrders = new System.Windows.Forms.Button();
            this.buttonEditOrder = new System.Windows.Forms.Button();
            this.buttonDeleteOrder = new System.Windows.Forms.Button();
            this.buttonEqipStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(17, 16);
            this.dataGridViewOrders.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(1033, 377);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellContentClick);
            // 
            // buttonAddOrders
            // 
            this.buttonAddOrders.Location = new System.Drawing.Point(17, 401);
            this.buttonAddOrders.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddOrders.Name = "buttonAddOrders";
            this.buttonAddOrders.Size = new System.Drawing.Size(316, 138);
            this.buttonAddOrders.TabIndex = 1;
            this.buttonAddOrders.Text = "Добавить новую заявку";
            this.buttonAddOrders.UseVisualStyleBackColor = true;
            this.buttonAddOrders.Click += new System.EventHandler(this.buttonAddOrders_Click);
            // 
            // buttonEditOrder
            // 
            this.buttonEditOrder.Location = new System.Drawing.Point(343, 401);
            this.buttonEditOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditOrder.Name = "buttonEditOrder";
            this.buttonEditOrder.Size = new System.Drawing.Size(379, 138);
            this.buttonEditOrder.TabIndex = 2;
            this.buttonEditOrder.Text = "Изменить заявку";
            this.buttonEditOrder.UseVisualStyleBackColor = true;
            this.buttonEditOrder.Click += new System.EventHandler(this.buttonEditOrder_Click);
            // 
            // buttonDeleteOrder
            // 
            this.buttonDeleteOrder.Location = new System.Drawing.Point(729, 401);
            this.buttonDeleteOrder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteOrder.Name = "buttonDeleteOrder";
            this.buttonDeleteOrder.Size = new System.Drawing.Size(321, 138);
            this.buttonDeleteOrder.TabIndex = 3;
            this.buttonDeleteOrder.Text = "Удалить заявку";
            this.buttonDeleteOrder.UseVisualStyleBackColor = true;
            this.buttonDeleteOrder.Click += new System.EventHandler(this.buttonDeleteOrder_Click);
            // 
            // buttonEqipStatus
            // 
            this.buttonEqipStatus.Location = new System.Drawing.Point(729, 401);
            this.buttonEqipStatus.Name = "buttonEqipStatus";
            this.buttonEqipStatus.Size = new System.Drawing.Size(321, 138);
            this.buttonEqipStatus.TabIndex = 4;
            this.buttonEqipStatus.Text = "Изменить статус";
            this.buttonEqipStatus.UseVisualStyleBackColor = true;
            this.buttonEqipStatus.Click += new System.EventHandler(this.buttonEqipStatus_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonEqipStatus);
            this.Controls.Add(this.buttonDeleteOrder);
            this.Controls.Add(this.buttonEditOrder);
            this.Controls.Add(this.buttonAddOrders);
            this.Controls.Add(this.dataGridViewOrders);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrdersForm";
            this.Text = "OrdersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonAddOrders;
        private System.Windows.Forms.Button buttonEditOrder;
        private System.Windows.Forms.Button buttonDeleteOrder;
        private System.Windows.Forms.Button buttonEqipStatus;
    }
}