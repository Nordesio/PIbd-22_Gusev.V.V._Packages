
namespace SoftwareInstallationShopView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonCreateOrder = new System.Windows.Forms.Button();
            this.ButtonIssuedOrder = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоИзделиямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMessages = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 36);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(782, 557);
            this.dataGridView.TabIndex = 0;
            // 
            // ButtonCreateOrder
            // 
            this.ButtonCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreateOrder.Location = new System.Drawing.Point(792, 108);
            this.ButtonCreateOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonCreateOrder.Name = "ButtonCreateOrder";
            this.ButtonCreateOrder.Size = new System.Drawing.Size(205, 31);
            this.ButtonCreateOrder.TabIndex = 2;
            this.ButtonCreateOrder.Text = "Создать заказ";
            this.ButtonCreateOrder.UseVisualStyleBackColor = true;
            this.ButtonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // ButtonIssuedOrder
            // 
            this.ButtonIssuedOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonIssuedOrder.Location = new System.Drawing.Point(791, 160);
            this.ButtonIssuedOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonIssuedOrder.Name = "ButtonIssuedOrder";
            this.ButtonIssuedOrder.Size = new System.Drawing.Size(205, 31);
            this.ButtonIssuedOrder.TabIndex = 5;
            this.ButtonIssuedOrder.Text = "Заказ выдан";
            this.ButtonIssuedOrder.UseVisualStyleBackColor = true;
            this.ButtonIssuedOrder.Click += new System.EventHandler(this.ButtonIssuedOrder_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRef.Location = new System.Drawing.Point(791, 216);
            this.ButtonRef.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(205, 31);
            this.ButtonRef.TabIndex = 6;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.toolStripMenuItemStartWorks});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1020, 30);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem,
            this.toolStripMenuItemMessages});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоИзделиямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.списокКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.списокКомпонентовToolStripMenuItem.Text = "Список изделий";
            this.списокКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // компонентыПоИзделиямToolStripMenuItem
            // 
            this.компонентыПоИзделиямToolStripMenuItem.Name = "компонентыПоИзделиямToolStripMenuItem";
            this.компонентыПоИзделиямToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.компонентыПоИзделиямToolStripMenuItem.Text = "Компоненты по изделиям";
            this.компонентыПоИзделиямToolStripMenuItem.Click += new System.EventHandler(this.ComponentPackagesToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // toolStripMenuItemStartWorks
            // 
            this.toolStripMenuItemStartWorks.Name = "toolStripMenuItemStartWorks";
            this.toolStripMenuItemStartWorks.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItemStartWorks.Text = "Запуск работ";
            this.toolStripMenuItemStartWorks.Click += new System.EventHandler(this.toolStripMenuItemStartWorks_Click);
            // 
            // toolStripMenuItemMessages
            // 
            this.toolStripMenuItemMessages.Name = "toolStripMenuItemMessages";
            this.toolStripMenuItemMessages.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemMessages.Text = "Письма";
            this.toolStripMenuItemMessages.Click += new System.EventHandler(this.toolStripMenuItemMessages_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 597);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonIssuedOrder);
            this.Controls.Add(this.ButtonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Магазин установки програмного обеспечения";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonIssuedOrder;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоИзделиямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartWorks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMessages;
    }
}