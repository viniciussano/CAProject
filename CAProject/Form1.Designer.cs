namespace CAProject
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("101");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("104");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("203");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("207");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Single Room", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("102");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("105");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("204");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("205");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Double Room", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("103");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("107");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("201");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("206");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Twin Room", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("106");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("202");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Family Room", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Rooms", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10,
            treeNode15,
            treeNode18});
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.createReservation = new System.Windows.Forms.Button();
            this.deleteReservation = new System.Windows.Forms.Button();
            this.updateReservation = new System.Windows.Forms.Button();
            this.searchReservation = new System.Windows.Forms.Button();
            this.guestName = new System.Windows.Forms.TextBox();
            this.guestEmail = new System.Windows.Forms.TextBox();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkin = new System.Windows.Forms.DateTimePicker();
            this.checkout = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.one = new System.Windows.Forms.RadioButton();
            this.two = new System.Windows.Forms.RadioButton();
            this.three = new System.Windows.Forms.RadioButton();
            this.four = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.roomType = new System.Windows.Forms.DomainUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalRate = new System.Windows.Forms.TextBox();
            this.roomSelector = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(865, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 99);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Reservation System";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(57, 706);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1820, 277);
            this.listBox1.TabIndex = 1;
            // 
            // createReservation
            // 
            this.createReservation.Location = new System.Drawing.Point(1183, 152);
            this.createReservation.Name = "createReservation";
            this.createReservation.Size = new System.Drawing.Size(147, 23);
            this.createReservation.TabIndex = 2;
            this.createReservation.Text = "Create Reservation";
            this.createReservation.UseVisualStyleBackColor = true;
            this.createReservation.Click += new System.EventHandler(this.createReservation_Click);
            // 
            // deleteReservation
            // 
            this.deleteReservation.Location = new System.Drawing.Point(1183, 214);
            this.deleteReservation.Name = "deleteReservation";
            this.deleteReservation.Size = new System.Drawing.Size(147, 23);
            this.deleteReservation.TabIndex = 3;
            this.deleteReservation.Text = "Delete Reservation";
            this.deleteReservation.UseVisualStyleBackColor = true;
            // 
            // updateReservation
            // 
            this.updateReservation.Location = new System.Drawing.Point(1183, 283);
            this.updateReservation.Name = "updateReservation";
            this.updateReservation.Size = new System.Drawing.Size(147, 23);
            this.updateReservation.TabIndex = 4;
            this.updateReservation.Text = "Update Reservation";
            this.updateReservation.UseVisualStyleBackColor = true;
            // 
            // searchReservation
            // 
            this.searchReservation.Location = new System.Drawing.Point(1183, 353);
            this.searchReservation.Name = "searchReservation";
            this.searchReservation.Size = new System.Drawing.Size(147, 23);
            this.searchReservation.TabIndex = 5;
            this.searchReservation.Text = "Search Reservation";
            this.searchReservation.UseVisualStyleBackColor = true;
            // 
            // guestName
            // 
            this.guestName.Location = new System.Drawing.Point(493, 162);
            this.guestName.Name = "guestName";
            this.guestName.Size = new System.Drawing.Size(362, 20);
            this.guestName.TabIndex = 6;
            // 
            // guestEmail
            // 
            this.guestEmail.Location = new System.Drawing.Point(493, 227);
            this.guestEmail.Name = "guestEmail";
            this.guestEmail.Size = new System.Drawing.Size(362, 20);
            this.guestEmail.TabIndex = 7;
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(493, 300);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(362, 20);
            this.phoneNumber.TabIndex = 8;
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(493, 360);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(362, 20);
            this.address.TabIndex = 9;
            this.address.Click += new System.EventHandler(this.address_TextChanged);
            this.address.TextChanged += new System.EventHandler(this.address_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Check-in Date";
            this.label5.Click += new System.EventHandler(this.address_TextChanged);
            // 
            // checkin
            // 
            this.checkin.Location = new System.Drawing.Point(493, 471);
            this.checkin.MaxDate = new System.DateTime(2028, 12, 31, 0, 0, 0, 0);
            this.checkin.MinDate = new System.DateTime(2025, 10, 24, 0, 0, 0, 0);
            this.checkin.Name = "checkin";
            this.checkin.Size = new System.Drawing.Size(200, 20);
            this.checkin.TabIndex = 15;
            // 
            // checkout
            // 
            this.checkout.Location = new System.Drawing.Point(493, 535);
            this.checkout.Name = "checkout";
            this.checkout.Size = new System.Drawing.Size(200, 20);
            this.checkout.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Check-out Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total number of guests";
            // 
            // one
            // 
            this.one.AutoSize = true;
            this.one.Checked = true;
            this.one.Location = new System.Drawing.Point(493, 417);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(31, 17);
            this.one.TabIndex = 19;
            this.one.TabStop = true;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            // 
            // two
            // 
            this.two.AutoSize = true;
            this.two.Location = new System.Drawing.Point(540, 417);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(31, 17);
            this.two.TabIndex = 20;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            // 
            // three
            // 
            this.three.AutoSize = true;
            this.three.Location = new System.Drawing.Point(589, 417);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(31, 17);
            this.three.TabIndex = 21;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            // 
            // four
            // 
            this.four.AutoSize = true;
            this.four.Location = new System.Drawing.Point(638, 417);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(31, 17);
            this.four.TabIndex = 22;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Guest Name";
            // 
            // roomType
            // 
            this.roomType.Items.Add("Single Room");
            this.roomType.Items.Add("Double Room");
            this.roomType.Items.Add("Triple Room");
            this.roomType.Items.Add("Family Room");
            this.roomType.Location = new System.Drawing.Point(493, 595);
            this.roomType.Name = "roomType";
            this.roomType.Size = new System.Drawing.Size(120, 20);
            this.roomType.TabIndex = 24;
            this.roomType.Text = "Choose Room";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(359, 597);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Select room type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(388, 647);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Total Rate";
            // 
            // totalRate
            // 
            this.totalRate.Location = new System.Drawing.Point(493, 647);
            this.totalRate.Name = "totalRate";
            this.totalRate.Size = new System.Drawing.Size(120, 20);
            this.totalRate.TabIndex = 27;
            // 
            // roomSelector
            // 
            this.roomSelector.Location = new System.Drawing.Point(882, 426);
            this.roomSelector.Name = "roomSelector";
            treeNode1.Name = "roomNo101";
            treeNode1.Text = "101";
            treeNode2.Name = "Node17";
            treeNode2.Text = "104";
            treeNode3.Name = "Node18";
            treeNode3.Text = "203";
            treeNode4.Name = "Node19";
            treeNode4.Text = "207";
            treeNode5.Name = "singleRoom";
            treeNode5.Text = "Single Room";
            treeNode6.Name = "roomNo102";
            treeNode6.Text = "102";
            treeNode7.Name = "Node14";
            treeNode7.Text = "105";
            treeNode8.Name = "Node15";
            treeNode8.Text = "204";
            treeNode9.Name = "Node16";
            treeNode9.Text = "205";
            treeNode10.Name = "doubleRoom";
            treeNode10.Text = "Double Room";
            treeNode11.Name = "roomNo103";
            treeNode11.Text = "103";
            treeNode12.Name = "Node11";
            treeNode12.Text = "107";
            treeNode13.Name = "Node12";
            treeNode13.Text = "201";
            treeNode14.Name = "Node13";
            treeNode14.Text = "206";
            treeNode15.Name = "twinRoom";
            treeNode15.Text = "Twin Room";
            treeNode16.Name = "roomNo106";
            treeNode16.Text = "106";
            treeNode17.Name = "roomNo202";
            treeNode17.Text = "202";
            treeNode18.Name = "familyRoom";
            treeNode18.Text = "Family Room";
            treeNode19.Name = "rooms";
            treeNode19.Text = "Rooms";
            this.roomSelector.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode19});
            this.roomSelector.Size = new System.Drawing.Size(350, 241);
            this.roomSelector.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 1011);
            this.Controls.Add(this.roomSelector);
            this.Controls.Add(this.totalRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.roomType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.four);
            this.Controls.Add(this.three);
            this.Controls.Add(this.two);
            this.Controls.Add(this.one);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkout);
            this.Controls.Add(this.checkin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.address);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.guestEmail);
            this.Controls.Add(this.guestName);
            this.Controls.Add(this.searchReservation);
            this.Controls.Add(this.updateReservation);
            this.Controls.Add(this.deleteReservation);
            this.Controls.Add(this.createReservation);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Hotel Reservation System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button createReservation;
        private System.Windows.Forms.Button deleteReservation;
        private System.Windows.Forms.Button updateReservation;
        private System.Windows.Forms.Button searchReservation;
        private System.Windows.Forms.TextBox guestName;
        private System.Windows.Forms.TextBox guestEmail;
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker checkin;
        private System.Windows.Forms.DateTimePicker checkout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton one;
        private System.Windows.Forms.RadioButton two;
        private System.Windows.Forms.RadioButton three;
        private System.Windows.Forms.RadioButton four;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DomainUpDown roomType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox totalRate;
        private System.Windows.Forms.TreeView roomSelector;
    }
}

