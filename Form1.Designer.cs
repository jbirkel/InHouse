namespace InHouseApp
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.sbMain = new System.Windows.Forms.StatusStrip();
         this.sbMainMsg = new System.Windows.Forms.ToolStripStatusLabel();
         this.lblBid = new System.Windows.Forms.ToolStripStatusLabel();
         this.tabMain = new System.Windows.Forms.TabControl();
         this.tpgInHouse = new System.Windows.Forms.TabPage();
         this.splitMain = new System.Windows.Forms.SplitContainer();
         this.tvMain = new System.Windows.Forms.TreeView();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.txtInHouse = new System.Windows.Forms.TextBox();
         this.lvInHouse = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.ilColHdrs = new System.Windows.Forms.ImageList(this.components);
         this.panel6 = new System.Windows.Forms.Panel();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.panel7 = new System.Windows.Forms.Panel();
         this.lblPageDesc = new System.Windows.Forms.Label();
         this.btnPageNext = new System.Windows.Forms.Button();
         this.btnPagePrev = new System.Windows.Forms.Button();
         this.btnSearch = new System.Windows.Forms.Button();
         this.btnReset = new System.Windows.Forms.Button();
         this.tpgMarket = new System.Windows.Forms.TabPage();
         this.rtbMktData = new System.Windows.Forms.RichTextBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.chkRefresh = new System.Windows.Forms.CheckBox();
         this.btnRefresh = new System.Windows.Forms.Button();
         this.panel5 = new System.Windows.Forms.Panel();
         this.label4 = new System.Windows.Forms.Label();
         this.txtMktFind = new System.Windows.Forms.TextBox();
         this.btnMktFindNext = new System.Windows.Forms.Button();
         this.btnMktFindPrev = new System.Windows.Forms.Button();
         this.tpgHttpQry = new System.Windows.Forms.TabPage();
         this.rtbHttpRsp = new System.Windows.Forms.RichTextBox();
         this.panel4 = new System.Windows.Forms.Panel();
         this.txtHttpGet = new System.Windows.Forms.TextBox();
         this.btnHttpQry = new System.Windows.Forms.Button();
         this.panel2 = new System.Windows.Forms.Panel();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.txtContractID = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.cbHttpQry = new System.Windows.Forms.ComboBox();
         this.txtEventClass = new System.Windows.Forms.TextBox();
         this.tpgXmlQry = new System.Windows.Forms.TabPage();
         this.rtxXmlResp = new System.Windows.Forms.RichTextBox();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnXmlQry = new System.Windows.Forms.Button();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.sbMain.SuspendLayout();
         this.tabMain.SuspendLayout();
         this.tpgInHouse.SuspendLayout();
         this.splitMain.Panel1.SuspendLayout();
         this.splitMain.Panel2.SuspendLayout();
         this.splitMain.SuspendLayout();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.panel6.SuspendLayout();
         this.panel7.SuspendLayout();
         this.tpgMarket.SuspendLayout();
         this.panel1.SuspendLayout();
         this.panel5.SuspendLayout();
         this.tpgHttpQry.SuspendLayout();
         this.panel4.SuspendLayout();
         this.panel2.SuspendLayout();
         this.tpgXmlQry.SuspendLayout();
         this.panel3.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // sbMain
         // 
         this.sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbMainMsg,
            this.lblBid});
         this.sbMain.Location = new System.Drawing.Point(0, 477);
         this.sbMain.Name = "sbMain";
         this.sbMain.Size = new System.Drawing.Size(782, 23);
         this.sbMain.TabIndex = 2;
         this.sbMain.Text = "statusStrip1";
         // 
         // sbMainMsg
         // 
         this.sbMainMsg.Name = "sbMainMsg";
         this.sbMainMsg.Size = new System.Drawing.Size(631, 18);
         this.sbMainMsg.Spring = true;
         this.sbMainMsg.Text = "Hello trader!  Click here when you\'re ready to get in on the action   ======>";
         this.sbMainMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblBid
         // 
         this.lblBid.AutoToolTip = true;
         this.lblBid.Enabled = false;
         this.lblBid.IsLink = true;
         this.lblBid.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
         this.lblBid.Margin = new System.Windows.Forms.Padding(4);
         this.lblBid.Name = "lblBid";
         this.lblBid.Size = new System.Drawing.Size(97, 15);
         this.lblBid.Text = "Buy or sell shares";
         this.lblBid.ToolTipText = "Links to the InTrade page for buying or sellling shares of the selected item.";
         this.lblBid.Click += new System.EventHandler(this.lblBid_Click);
         // 
         // tabMain
         // 
         this.tabMain.Controls.Add(this.tpgInHouse);
         this.tabMain.Controls.Add(this.tpgMarket);
         this.tabMain.Controls.Add(this.tpgHttpQry);
         this.tabMain.Controls.Add(this.tpgXmlQry);
         this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabMain.Location = new System.Drawing.Point(0, 24);
         this.tabMain.Name = "tabMain";
         this.tabMain.SelectedIndex = 0;
         this.tabMain.Size = new System.Drawing.Size(782, 453);
         this.tabMain.TabIndex = 4;
         // 
         // tpgInHouse
         // 
         this.tpgInHouse.Controls.Add(this.splitMain);
         this.tpgInHouse.Controls.Add(this.panel6);
         this.tpgInHouse.Location = new System.Drawing.Point(4, 22);
         this.tpgInHouse.Name = "tpgInHouse";
         this.tpgInHouse.Size = new System.Drawing.Size(774, 427);
         this.tpgInHouse.TabIndex = 3;
         this.tpgInHouse.Text = "InHouse";
         this.tpgInHouse.UseVisualStyleBackColor = true;
         // 
         // splitMain
         // 
         this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this.splitMain.Location = new System.Drawing.Point(0, 30);
         this.splitMain.Name = "splitMain";
         // 
         // splitMain.Panel1
         // 
         this.splitMain.Panel1.Controls.Add(this.tvMain);
         // 
         // splitMain.Panel2
         // 
         this.splitMain.Panel2.Controls.Add(this.splitContainer1);
         this.splitMain.Size = new System.Drawing.Size(774, 397);
         this.splitMain.SplitterDistance = 239;
         this.splitMain.TabIndex = 1;
         // 
         // tvMain
         // 
         this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tvMain.Location = new System.Drawing.Point(0, 0);
         this.tvMain.Name = "tvMain";
         this.tvMain.Size = new System.Drawing.Size(239, 397);
         this.tvMain.TabIndex = 1;
         this.tvMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvMain_MouseDoubleClick);
         this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.txtInHouse);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.lvInHouse);
         this.splitContainer1.Size = new System.Drawing.Size(531, 397);
         this.splitContainer1.SplitterDistance = 124;
         this.splitContainer1.TabIndex = 2;
         // 
         // txtInHouse
         // 
         this.txtInHouse.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtInHouse.Location = new System.Drawing.Point(0, 0);
         this.txtInHouse.Multiline = true;
         this.txtInHouse.Name = "txtInHouse";
         this.txtInHouse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtInHouse.Size = new System.Drawing.Size(531, 124);
         this.txtInHouse.TabIndex = 0;
         // 
         // lvInHouse
         // 
         this.lvInHouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
         this.lvInHouse.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lvInHouse.Location = new System.Drawing.Point(0, 0);
         this.lvInHouse.Name = "lvInHouse";
         this.lvInHouse.Size = new System.Drawing.Size(531, 269);
         this.lvInHouse.SmallImageList = this.ilColHdrs;
         this.lvInHouse.TabIndex = 1;
         this.lvInHouse.UseCompatibleStateImageBehavior = false;
         this.lvInHouse.View = System.Windows.Forms.View.Details;
         this.lvInHouse.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvInHouse_ColumnClick);
         this.lvInHouse.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvInHouse_ItemSelectionChanged);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Width = 125;
         // 
         // ilColHdrs
         // 
         this.ilColHdrs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilColHdrs.ImageStream")));
         this.ilColHdrs.TransparentColor = System.Drawing.Color.White;
         this.ilColHdrs.Images.SetKeyName(0, "ColHdrArrowDn.png");
         this.ilColHdrs.Images.SetKeyName(1, "ColHdrArrowUp.png");
         // 
         // panel6
         // 
         this.panel6.Controls.Add(this.textBox1);
         this.panel6.Controls.Add(this.checkBox1);
         this.panel6.Controls.Add(this.panel7);
         this.panel6.Controls.Add(this.btnSearch);
         this.panel6.Controls.Add(this.btnReset);
         this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel6.Location = new System.Drawing.Point(0, 0);
         this.panel6.Name = "panel6";
         this.panel6.Size = new System.Drawing.Size(774, 30);
         this.panel6.TabIndex = 2;
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(139, 5);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(139, 20);
         this.textBox1.TabIndex = 7;
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(304, 7);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(15, 14);
         this.checkBox1.TabIndex = 6;
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // panel7
         // 
         this.panel7.AutoSize = true;
         this.panel7.Controls.Add(this.lblPageDesc);
         this.panel7.Controls.Add(this.btnPageNext);
         this.panel7.Controls.Add(this.btnPagePrev);
         this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
         this.panel7.Location = new System.Drawing.Point(588, 0);
         this.panel7.Name = "panel7";
         this.panel7.Size = new System.Drawing.Size(186, 30);
         this.panel7.TabIndex = 5;
         // 
         // lblPageDesc
         // 
         this.lblPageDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.lblPageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPageDesc.Location = new System.Drawing.Point(5, 8);
         this.lblPageDesc.Name = "lblPageDesc";
         this.lblPageDesc.Size = new System.Drawing.Size(124, 13);
         this.lblPageDesc.TabIndex = 5;
         this.lblPageDesc.Text = "8001 thru 8050 of 9999";
         this.lblPageDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // btnPageNext
         // 
         this.btnPageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnPageNext.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
         this.btnPageNext.Location = new System.Drawing.Point(159, 4);
         this.btnPageNext.Name = "btnPageNext";
         this.btnPageNext.Size = new System.Drawing.Size(24, 23);
         this.btnPageNext.TabIndex = 3;
         this.btnPageNext.Text = "u";
         this.btnPageNext.UseVisualStyleBackColor = true;
         this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
         // 
         // btnPagePrev
         // 
         this.btnPagePrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnPagePrev.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
         this.btnPagePrev.Location = new System.Drawing.Point(132, 4);
         this.btnPagePrev.Margin = new System.Windows.Forms.Padding(0);
         this.btnPagePrev.Name = "btnPagePrev";
         this.btnPagePrev.Size = new System.Drawing.Size(24, 23);
         this.btnPagePrev.TabIndex = 2;
         this.btnPagePrev.Text = "t";
         this.btnPagePrev.UseVisualStyleBackColor = true;
         this.btnPagePrev.Click += new System.EventHandler(this.btnPagePrev_Click);
         // 
         // btnSearch
         // 
         this.btnSearch.FlatAppearance.BorderSize = 0;
         this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnSearch.Location = new System.Drawing.Point(70, 3);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(63, 23);
         this.btnSearch.TabIndex = 1;
         this.btnSearch.Text = "Search";
         this.btnSearch.UseVisualStyleBackColor = true;
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // btnReset
         // 
         this.btnReset.FlatAppearance.BorderSize = 0;
         this.btnReset.Location = new System.Drawing.Point(3, 3);
         this.btnReset.Name = "btnReset";
         this.btnReset.Size = new System.Drawing.Size(63, 23);
         this.btnReset.TabIndex = 0;
         this.btnReset.Text = "Reset";
         this.btnReset.UseVisualStyleBackColor = true;
         this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
         // 
         // tpgMarket
         // 
         this.tpgMarket.Controls.Add(this.rtbMktData);
         this.tpgMarket.Controls.Add(this.panel1);
         this.tpgMarket.Location = new System.Drawing.Point(4, 22);
         this.tpgMarket.Name = "tpgMarket";
         this.tpgMarket.Padding = new System.Windows.Forms.Padding(3);
         this.tpgMarket.Size = new System.Drawing.Size(774, 428);
         this.tpgMarket.TabIndex = 0;
         this.tpgMarket.Text = "Market Data";
         this.tpgMarket.UseVisualStyleBackColor = true;
         // 
         // rtbMktData
         // 
         this.rtbMktData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.rtbMktData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtbMktData.Location = new System.Drawing.Point(3, 31);
         this.rtbMktData.Name = "rtbMktData";
         this.rtbMktData.Size = new System.Drawing.Size(768, 394);
         this.rtbMktData.TabIndex = 6;
         this.rtbMktData.Text = "";
         this.rtbMktData.WordWrap = false;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.chkRefresh);
         this.panel1.Controls.Add(this.btnRefresh);
         this.panel1.Controls.Add(this.panel5);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(3, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(768, 28);
         this.panel1.TabIndex = 5;
         // 
         // chkRefresh
         // 
         this.chkRefresh.AutoSize = true;
         this.chkRefresh.Location = new System.Drawing.Point(64, 7);
         this.chkRefresh.Name = "chkRefresh";
         this.chkRefresh.Size = new System.Drawing.Size(65, 17);
         this.chkRefresh.TabIndex = 1;
         this.chkRefresh.Text = "Enabled";
         this.chkRefresh.UseVisualStyleBackColor = true;
         this.chkRefresh.CheckedChanged += new System.EventHandler(this.chkRefresh_CheckedChanged);
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(0, 3);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(58, 23);
         this.btnRefresh.TabIndex = 0;
         this.btnRefresh.Text = "Refresh";
         this.btnRefresh.UseVisualStyleBackColor = true;
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // panel5
         // 
         this.panel5.Controls.Add(this.label4);
         this.panel5.Controls.Add(this.txtMktFind);
         this.panel5.Controls.Add(this.btnMktFindNext);
         this.panel5.Controls.Add(this.btnMktFindPrev);
         this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
         this.panel5.Location = new System.Drawing.Point(549, 0);
         this.panel5.Name = "panel5";
         this.panel5.Size = new System.Drawing.Size(219, 28);
         this.panel5.TabIndex = 6;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 8);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(30, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Find:";
         // 
         // txtMktFind
         // 
         this.txtMktFind.Location = new System.Drawing.Point(34, 5);
         this.txtMktFind.Name = "txtMktFind";
         this.txtMktFind.Size = new System.Drawing.Size(100, 20);
         this.txtMktFind.TabIndex = 7;
         // 
         // btnMktFindNext
         // 
         this.btnMktFindNext.Location = new System.Drawing.Point(177, 3);
         this.btnMktFindNext.Name = "btnMktFindNext";
         this.btnMktFindNext.Size = new System.Drawing.Size(40, 23);
         this.btnMktFindNext.TabIndex = 9;
         this.btnMktFindNext.Text = "Prev";
         this.btnMktFindNext.UseVisualStyleBackColor = true;
         this.btnMktFindNext.Click += new System.EventHandler(this.btnMktFindPrev_Click);
         // 
         // btnMktFindPrev
         // 
         this.btnMktFindPrev.Location = new System.Drawing.Point(136, 3);
         this.btnMktFindPrev.Name = "btnMktFindPrev";
         this.btnMktFindPrev.Size = new System.Drawing.Size(40, 23);
         this.btnMktFindPrev.TabIndex = 8;
         this.btnMktFindPrev.Text = "Next";
         this.btnMktFindPrev.UseVisualStyleBackColor = true;
         this.btnMktFindPrev.Click += new System.EventHandler(this.btnMktFindNext_Click);
         // 
         // tpgHttpQry
         // 
         this.tpgHttpQry.Controls.Add(this.rtbHttpRsp);
         this.tpgHttpQry.Controls.Add(this.panel4);
         this.tpgHttpQry.Controls.Add(this.panel2);
         this.tpgHttpQry.Location = new System.Drawing.Point(4, 22);
         this.tpgHttpQry.Name = "tpgHttpQry";
         this.tpgHttpQry.Padding = new System.Windows.Forms.Padding(3);
         this.tpgHttpQry.Size = new System.Drawing.Size(774, 428);
         this.tpgHttpQry.TabIndex = 2;
         this.tpgHttpQry.Text = "HTTP GET";
         this.tpgHttpQry.UseVisualStyleBackColor = true;
         // 
         // rtbHttpRsp
         // 
         this.rtbHttpRsp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.rtbHttpRsp.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtbHttpRsp.Location = new System.Drawing.Point(3, 73);
         this.rtbHttpRsp.Name = "rtbHttpRsp";
         this.rtbHttpRsp.ReadOnly = true;
         this.rtbHttpRsp.Size = new System.Drawing.Size(768, 352);
         this.rtbHttpRsp.TabIndex = 12;
         this.rtbHttpRsp.Text = "";
         this.rtbHttpRsp.WordWrap = false;
         // 
         // panel4
         // 
         this.panel4.Controls.Add(this.txtHttpGet);
         this.panel4.Controls.Add(this.btnHttpQry);
         this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel4.Location = new System.Drawing.Point(3, 51);
         this.panel4.Name = "panel4";
         this.panel4.Size = new System.Drawing.Size(768, 22);
         this.panel4.TabIndex = 13;
         // 
         // txtHttpGet
         // 
         this.txtHttpGet.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtHttpGet.Location = new System.Drawing.Point(48, 0);
         this.txtHttpGet.Name = "txtHttpGet";
         this.txtHttpGet.Size = new System.Drawing.Size(720, 20);
         this.txtHttpGet.TabIndex = 9;
         // 
         // btnHttpQry
         // 
         this.btnHttpQry.Dock = System.Windows.Forms.DockStyle.Left;
         this.btnHttpQry.Location = new System.Drawing.Point(0, 0);
         this.btnHttpQry.Name = "btnHttpQry";
         this.btnHttpQry.Size = new System.Drawing.Size(48, 22);
         this.btnHttpQry.TabIndex = 8;
         this.btnHttpQry.Text = "POST";
         this.btnHttpQry.UseVisualStyleBackColor = true;
         this.btnHttpQry.Click += new System.EventHandler(this.btnHttpQry_Click);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.label3);
         this.panel2.Controls.Add(this.label2);
         this.panel2.Controls.Add(this.txtContractID);
         this.panel2.Controls.Add(this.label1);
         this.panel2.Controls.Add(this.cbHttpQry);
         this.panel2.Controls.Add(this.txtEventClass);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(3, 3);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(768, 48);
         this.panel2.TabIndex = 11;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(-3, 8);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(47, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Http API";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(251, 8);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(61, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Contract ID";
         // 
         // txtContractID
         // 
         this.txtContractID.Location = new System.Drawing.Point(254, 24);
         this.txtContractID.Name = "txtContractID";
         this.txtContractID.Size = new System.Drawing.Size(63, 20);
         this.txtContractID.TabIndex = 4;
         this.txtContractID.TextChanged += new System.EventHandler(this.txtContractID_TextChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(182, 8);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(63, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Event Class";
         // 
         // cbHttpQry
         // 
         this.cbHttpQry.FormattingEnabled = true;
         this.cbHttpQry.Location = new System.Drawing.Point(0, 24);
         this.cbHttpQry.Name = "cbHttpQry";
         this.cbHttpQry.Size = new System.Drawing.Size(180, 21);
         this.cbHttpQry.TabIndex = 2;
         this.cbHttpQry.SelectedIndexChanged += new System.EventHandler(this.cbHttpQry_SelectedIndexChanged);
         // 
         // txtEventClass
         // 
         this.txtEventClass.Location = new System.Drawing.Point(185, 24);
         this.txtEventClass.Name = "txtEventClass";
         this.txtEventClass.Size = new System.Drawing.Size(63, 20);
         this.txtEventClass.TabIndex = 1;
         this.txtEventClass.TextChanged += new System.EventHandler(this.txtEventClass_TextChanged);
         // 
         // tpgXmlQry
         // 
         this.tpgXmlQry.Controls.Add(this.rtxXmlResp);
         this.tpgXmlQry.Controls.Add(this.panel3);
         this.tpgXmlQry.Location = new System.Drawing.Point(4, 22);
         this.tpgXmlQry.Name = "tpgXmlQry";
         this.tpgXmlQry.Padding = new System.Windows.Forms.Padding(3);
         this.tpgXmlQry.Size = new System.Drawing.Size(774, 428);
         this.tpgXmlQry.TabIndex = 1;
         this.tpgXmlQry.Text = "XML Qry";
         this.tpgXmlQry.UseVisualStyleBackColor = true;
         // 
         // rtxXmlResp
         // 
         this.rtxXmlResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.rtxXmlResp.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtxXmlResp.Location = new System.Drawing.Point(3, 44);
         this.rtxXmlResp.Name = "rtxXmlResp";
         this.rtxXmlResp.ReadOnly = true;
         this.rtxXmlResp.Size = new System.Drawing.Size(768, 381);
         this.rtxXmlResp.TabIndex = 10;
         this.rtxXmlResp.Text = "";
         this.rtxXmlResp.WordWrap = false;
         // 
         // panel3
         // 
         this.panel3.Controls.Add(this.btnXmlQry);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(3, 3);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(768, 41);
         this.panel3.TabIndex = 9;
         // 
         // btnXmlQry
         // 
         this.btnXmlQry.Location = new System.Drawing.Point(8, 13);
         this.btnXmlQry.Name = "btnXmlQry";
         this.btnXmlQry.Size = new System.Drawing.Size(56, 22);
         this.btnXmlQry.TabIndex = 0;
         this.btnXmlQry.Text = "Send";
         this.btnXmlQry.UseVisualStyleBackColor = true;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(782, 24);
         this.menuStrip1.TabIndex = 5;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
         this.exitToolStripMenuItem.Text = "E&xit";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(782, 500);
         this.Controls.Add(this.tabMain);
         this.Controls.Add(this.sbMain);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Form1";
         this.Text = "Action House";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.sbMain.ResumeLayout(false);
         this.sbMain.PerformLayout();
         this.tabMain.ResumeLayout(false);
         this.tpgInHouse.ResumeLayout(false);
         this.splitMain.Panel1.ResumeLayout(false);
         this.splitMain.Panel2.ResumeLayout(false);
         this.splitMain.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         this.panel6.ResumeLayout(false);
         this.panel6.PerformLayout();
         this.panel7.ResumeLayout(false);
         this.tpgMarket.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.panel5.ResumeLayout(false);
         this.panel5.PerformLayout();
         this.tpgHttpQry.ResumeLayout(false);
         this.panel4.ResumeLayout(false);
         this.panel4.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.tpgXmlQry.ResumeLayout(false);
         this.panel3.ResumeLayout(false);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.StatusStrip sbMain;
      private System.Windows.Forms.ToolStripStatusLabel sbMainMsg;
      private System.Windows.Forms.TabControl tabMain;
      private System.Windows.Forms.TabPage tpgMarket;
      private System.Windows.Forms.TabPage tpgXmlQry;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.TabPage tpgHttpQry;
      private System.Windows.Forms.RichTextBox rtbMktData;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.CheckBox chkRefresh;
      private System.Windows.Forms.Button btnRefresh;
      private System.Windows.Forms.RichTextBox rtbHttpRsp;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.RichTextBox rtxXmlResp;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnXmlQry;
      private System.Windows.Forms.TextBox txtEventClass;
      private System.Windows.Forms.ComboBox cbHttpQry;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtContractID;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.TextBox txtHttpGet;
      private System.Windows.Forms.Button btnHttpQry;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Panel panel5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtMktFind;
      private System.Windows.Forms.Button btnMktFindNext;
      private System.Windows.Forms.Button btnMktFindPrev;
      private System.Windows.Forms.TabPage tpgInHouse;
      private System.Windows.Forms.SplitContainer splitMain;
      private System.Windows.Forms.TreeView tvMain;
      private System.Windows.Forms.TextBox txtInHouse;
      private System.Windows.Forms.Panel panel6;
      private System.Windows.Forms.Button btnSearch;
      private System.Windows.Forms.Button btnReset;
      private System.Windows.Forms.Button btnPageNext;
      private System.Windows.Forms.Button btnPagePrev;
      private System.Windows.Forms.Panel panel7;
      private System.Windows.Forms.Label lblPageDesc;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.ListView lvInHouse;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ImageList ilColHdrs;
      private System.Windows.Forms.ToolStripStatusLabel lblBid;
   }
}

