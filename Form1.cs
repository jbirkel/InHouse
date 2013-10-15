// --------------------------------------------------------------------------------------
// Form1.cs - Main form of the Action House client for InTrade  "Get In on the Action"
//
//
// --------------------------------------------------------------------------------------
// NOTES:
// -- search criteria: 
//    - text (should match event name, contract name or symbol)
//    - state
//    - winners/losers (expired, 100 or 0)
//    - volume
//
// TODO:
// -- implement search bar 
// -- sort only sorts current page. Need to sort SrchMkts and refresh page.
//    -- can only do this on columns in Contract data
//    -- maybe alter col apperance to indicate global/local sorts    
// -- more columns?
// -- bid history (graph)
// -- sort tree?  within sub-category only: date expired or alpha 
// -- Bid button: http://www.intrade.com/v4/markets/contract/?contractId=751715
// *- get column sort working in main ListView
// *- implement column size save/load (no auto-size right now)
// *- still have missing lines when there are no bids: join ContractBookInfo to Markets
// *- market LINQ query can drop some items if either bid or offer sub-element is missing
//
// --------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Xml; 
using System.Xml.Linq; 

using jhblib;

namespace InHouseApp
{
   delegate void dbg_out( string s );
   
   public partial class Form1 : Form
   {
      // Cached market data XML
      const string MKTDATA_FILE = @"MarketData.xml" ;

      //string      _sMD;
      XDocument _docMD;

      AppState _APP; // = new AppState();

      // Debug and User Messages
      public void UsrMsg(string s) { sbMainMsg.Text = s; }
      public void DbgOut(string s) { sbMainMsg.Text = s; }
      
      public Form1()
      {
         InitializeComponent();
      }


      private void Form1_Load(object sender, EventArgs e)
      {
         // Temp?
         rtbMktData.SelectionTabs = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
         rtbHttpRsp.SelectionTabs = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

         // Load MarketData.xml. If found, disable the Refresh button.
         // NOTE: This should be automatic in a real product.
         try
         {
            string sMD;
            using (var sr = new StreamReader(MKTDATA_FILE))
            {
               sMD = sr.ReadToEnd();
               _docMD = XDocument.Parse(sMD);
            }
            rtbMktData.Text = EasyXml.Pretty(sMD);

            // temp   
            btnRefresh.Enabled = false;
            chkRefresh.Checked = false;
         }
         catch (Exception xx)
         {
            DbgOut(String.Format("Error reading {0} - {1}", MKTDATA_FILE, xx.Message));
            return;
         }

         _APP = new AppState();

         GUI_InitInHouseMain();
         GUI_InitHttpQryList();  
      }

      // On close, save settings.
      private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
         _APP.FormExtents[AppState.FormExtents_e.AppHgt] = this.Height;            
         _APP.FormExtents[AppState.FormExtents_e.AppWid] = this.Width ;      
         _APP.FormExtents[AppState.FormExtents_e.MktTreeWid] = splitMain.SplitterDistance ;
         _APP.FormExtents[AppState.FormExtents_e.ColLPrWid] = lvInHouse.Columns["LST"].Width;
         _APP.FormExtents[AppState.FormExtents_e.ColSymWid] = lvInHouse.Columns["SYM"].Width;
         _APP.FormExtents[AppState.FormExtents_e.ColBidWid] = lvInHouse.Columns["HIB"].Width;
         _APP.FormExtents[AppState.FormExtents_e.ColOfrWid] = lvInHouse.Columns["LOB"].Width;
         _APP.FormExtents[AppState.FormExtents_e.ColVolWid] = lvInHouse.Columns["VOL"].Width;
         _APP.FormExtents[AppState.FormExtents_e.ColStaWid] = lvInHouse.Columns["STA"].Width;          
         _APP.FormExtents[AppState.FormExtents_e.ColEPrWid] = lvInHouse.Columns["EXP"].Width; 
         _APP.Save();
      }        
      
      private void chkRefresh_CheckedChanged(object sender, EventArgs e) {
         btnRefresh.Enabled = chkRefresh.Checked;
      }

      // Search on dbl-click in the Market Tree
      private void tvMain_MouseDoubleClick(object sender, MouseEventArgs e) {
         //var tv = (TreeView)sender;
         //tv.GetNodeAt( e.Location );
         btnSearch.PerformClick();
      }

      // Enables or disables the Bid link depending on whether a contract item is selected.
      private void lvInHouse_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
         var lv = (ListView)sender;
         lblBid.Enabled = 0 < lv.SelectedItems.Count;
      }

      // Opens browser to the trading page for the selected contract. 
      private void lblBid_Click(object sender, EventArgs e)
      {
         
      }
  
// -----------------------------------------------------------------------------      
//
//    AA               ii                   HH   HH                            
//    AA           tt                       HH   HH                            
//   AAAA          tt                       HH   HH                            
//   AAAA    cccc  ttt ii  oooo  nnnnn      HH   HH   oooo  uu  uu  sss   eeee 
//  AA  AA  cc  cc tt  ii oo  oo nnn nn     HHHHHHH  oo  oo uu  uu ss ss ee  ee
//  AA  AA  cc     tt  ii oo  oo nn  nn     HH   HH  oo  oo uu  uu  ss   eeeeee
//  AAAAAA  cc     tt  ii oo  oo nn  nn     HH   HH  oo  oo uu  uu   ss  ee    
// AA    AA cc  cc tt  ii oo  oo nn  nn     HH   HH  oo  oo uu uuu ss ss ee  ee
// AA    AA  cccc   tt ii  oooo  nn  nn     HH   HH   oooo   uuuuu  sss   eeee 
//
// -----------------------------------------------------------------------------      

      private void btnMktFindNext_Click(object sender, EventArgs e) { MarketFind( txtMktFind.Text, false); }
      private void btnMktFindPrev_Click(object sender, EventArgs e) { MarketFind( txtMktFind.Text, true ); }
      private void MarketFind( string text, bool bPrev ) 
      {
         int selStart = rtbMktData.SelectionStart; 
         int startpos = bPrev ? 0        : selStart + rtbMktData.SelectionLength;
         int endpos   = bPrev ? selStart :            rtbMktData.Text.Length    ;         
         
         int newpos = rtbMktData.Find(text, startpos, endpos, bPrev ? RichTextBoxFinds.Reverse : RichTextBoxFinds.None);
         
         if (0 < newpos) {
            rtbMktData.HideSelection = false;
            rtbMktData.Select(newpos, text.Length);
            //DbgOut( String.Format( "MarketFind selecting {0},{1}", newpos, text.Length ));
         }
         else {
            UsrMsg( String.Format( "'{0}' not found.", text ));
         }   
      }

       internal class TreeNodeIH : TreeNode
       {
         public TreeNodeIH(string text, string elem, TreeNode[] children) 
            : base(text, children) 
         {
             this.Tag = elem;
         }
         
         public TreeNodeIH(string text, string elem )
            : base(text)
         {
            this.Tag = elem;
         }
       }      
      
      const string sEvtClassTag = "EventClass" ;
      const string sEvtGroupTag = "EventGroup" ;
      const string sEvtLeafTag  = "Event"      ;      
      const string sContractTag = "contract"   ;
      
//      InTradeApi.MarketData _MD = new InTradeApi.MarketData(); 
      
      void GUI_InitInHouseMain() {
         
         // Linq query to build TreeView nodes.   
         var tns = (from ec in _docMD.Descendants(sEvtClassTag)
                   select new TreeNodeIH (
                      ((string)ec.Element("name")).Trim(), sEvtClassTag,
                      (from eg in ec.Descendants(sEvtGroupTag)
                      select new TreeNodeIH (
                         ((string)eg.Element("name")).Trim(), sEvtGroupTag,
                         (from ev in eg.Descendants(sEvtLeafTag)
                         select new TreeNodeIH(
                            ((string)ev.Element("name")).Trim(), sEvtLeafTag
                         )).ToArray()                                                 
                      )).ToArray()                       
                   )).ToArray();         
         
         tvMain.LineColor = SystemColors.Highlight;
         tvMain.ShowLines = true;
         tvMain.ShowRootLines = false;         
         
         tvMain.HideSelection = false;
         tvMain.FullRowSelect = true;  // Ignored if ShowLines is true
         tvMain.HotTracking = true;
         tvMain.ShowPlusMinus = false;
         tvMain.PathSeparator = " » " ;

         tvMain.Nodes.Clear();
         tvMain.Nodes.AddRange(tns);

         //tvMain.Nodes.Add(new TreeNode("All Markets", tns));  // simpler, but forces an extra level
         //tvMain.SelectedNode = tvMain.Nodes[0];         

         var IH_ColumnProps = new[]
         { new { name="SYM", text="Symbol"    }
         , new { name="LST", text="Latest"    }
         , new { name="LOB", text="Low Offer" }
         , new { name="HIB", text="High Bid"  }
         , new { name="VOL", text="Vol"       }
         , new { name="STA", text="State"     }
         , new { name="EXP", text="Final"     }
         };
         var LvInHouseCols = (from a in IH_ColumnProps select new ColumnHeaderIH( a.name, a.text )).ToArray();

         // Don't stretch images.  (All are expected to be the same size.)
         var img =  ilColHdrs.Images[0];
         ilColHdrs.ImageSize = ilColHdrs.Images[0].Size; 
                 
         lvInHouse.Clear();
         lvInHouse.ShowItemToolTips = true;
         lvInHouse.Columns.AddRange( LvInHouseCols );
         lvInHouse.SmallImageList = ilColHdrs;
         
         // How to use Linq to calculate total volume
         var total = (from c in _docMD.Descendants("contract")
                      select Int32.Parse( ((string)c.Element("totalVolume")).Trim())
                     ).Sum();
                    
         UsrMsg( String.Format( "Total volume = {0}", total ));  
         
         // Resize sizable window features from saved settings.
         try {
            this.Height = _APP.FormExtents[AppState.FormExtents_e.AppHgt];          
            this.Width = _APP.FormExtents[AppState.FormExtents_e.AppWid];
            splitMain.SplitterDistance = _APP.FormExtents[AppState.FormExtents_e.MktTreeWid];
            lvInHouse.Columns["LST"].Width = _APP.FormExtents[AppState.FormExtents_e.ColLPrWid];
            lvInHouse.Columns["SYM"].Width = _APP.FormExtents[AppState.FormExtents_e.ColSymWid];
            lvInHouse.Columns["HIB"].Width = _APP.FormExtents[AppState.FormExtents_e.ColBidWid];
            lvInHouse.Columns["LOB"].Width = _APP.FormExtents[AppState.FormExtents_e.ColOfrWid];
            lvInHouse.Columns["VOL"].Width = _APP.FormExtents[AppState.FormExtents_e.ColVolWid];
            lvInHouse.Columns["STA"].Width = _APP.FormExtents[AppState.FormExtents_e.ColStaWid];               
            lvInHouse.Columns["EXP"].Width = _APP.FormExtents[AppState.FormExtents_e.ColEPrWid];   
         }
         catch (Exception xx) { DbgOut(xx.Message); };
      }
      
      class ColumnHeaderIH : ColumnHeader {
         public ColumnHeaderIH(string name, string title) : base() {
            this.Name = name;         
            this.Text = title;
         }
      }
     
      private void tvMain_AfterSelect(object sender, TreeViewEventArgs e) {
         TreeNode tn = e.Node;         
         CollapseAllExcept( tvMain, tn );
         tn.Expand();
         UsrMsg( tn.FullPath );
         btnReset.Enabled = true;               
      }
      
      void CollapseAllExcept( TreeView tv, TreeNode tnExcept ) {
      
         // Don't collapse the given node or its ancestors.
         var Ascendants = new List<TreeNode>();
         for( TreeNode tmp = tnExcept; null != tmp; tmp = tmp.Parent) {
            Ascendants.Add(tmp);
         }
         
         // Recurse
         TraverseCollapseAllExcept(tv.Nodes, Ascendants);
      }

      private void TraverseCollapseAllExcept(TreeNodeCollection nodes, List<TreeNode> SafeNodes) {
         foreach (TreeNode tn in nodes) {
            if (tn.IsExpanded && (null == SafeNodes || !SafeNodes.Contains(tn))) {
               tn.Toggle();
            }
            TraverseCollapseAllExcept(tn.Nodes, SafeNodes);
         }
      }

      private void btnReset_Click(object sender, EventArgs e)
      {
         tvMain.SelectedNode = null;
         TraverseCollapseAllExcept(tvMain.Nodes, null);
         UsrMsg("All Markets");         
         btnReset.Enabled = false;      
      }


      // Subset of all markets currently selected by the market tree view. (AllPages)
      static InTradeApi.Contract[] _sel_mkt_array;
      static int _nPagePos = 0;
      
      // Index by contract ID of _sel_mkt_array.
      Dictionary<string, InTradeApi.Contract> _SelMkts = new Dictionary<string, InTradeApi.Contract>();
      
      // Index by contract ID of _sel_mkt_array items matching the search criteria.
      Dictionary<string, InTradeApi.Contract> _SrchMkts = new Dictionary<string, InTradeApi.Contract>();      

      // _SrchMkts joined with ContractBookInfo data      
      // Subset of selected contracts (_Market), winnowed by search criteria and, and joined with ContractBookInfo.
//      static struct AhItems

      private void btnSearch_Click(object sender, EventArgs e)
      {
         TreeNode tn = tvMain.SelectedNode;

         var Ascendants = new List<TreeNode>();
         for (TreeNode tmp = tn; null != tmp; tmp = tmp.Parent) {
            Ascendants.Add(tmp);
         }

         // The contract selection method.
         Func<XElement,InTradeApi.Contract> Select = delegate(XElement c) {
            return new InTradeApi.Contract(
               ((string)c.Attribute("id"    )).Trim(),
               ((string)c.Element  ("name"  )).Trim(),
               ((string)c.Element  ("symbol")).Trim(),
               ((string)c.Attribute("state" )).Trim()               
            );         
         };
         
         switch (Ascendants.Count) {
            case 3: _sel_mkt_array = 
            (  from ec in _docMD.Descendants(sEvtClassTag)
               where 0 == ((string)Ascendants[2].Text).CompareTo(((string)ec.Element("name")).Trim())
               from eg in ec.Descendants(sEvtGroupTag)
               where 0 == ((string)Ascendants[1].Text).CompareTo(((string)eg.Element("name")).Trim())
               from ev in eg.Descendants(sEvtLeafTag)
               where 0 == ((string)Ascendants[0].Text).CompareTo(((string)ev.Element("name")).Trim())
               from c in ev.Descendants("contract")
               select Select(c)
            ).ToArray();
            break;

            case 2: _sel_mkt_array = 
            (  from ec in _docMD.Descendants(sEvtClassTag)
               where 0 == ((string)Ascendants[1].Text).CompareTo(((string)ec.Element("name")).Trim())
               from eg in ec.Descendants(sEvtGroupTag)
               where 0 == ((string)Ascendants[0].Text).CompareTo(((string)eg.Element("name")).Trim())
               from c in eg.Descendants("contract")
               select Select(c)               
            ).ToArray();
            break;

            case 1: _sel_mkt_array = 
            (  from ec in _docMD.Descendants(sEvtClassTag)
               where 0 == ((string)Ascendants[0].Text).CompareTo(((string)ec.Element("name")).Trim())
               from c in ec.Descendants("contract")
               select Select(c)                              
            ).ToArray();
            break;
           
            case 0: _sel_mkt_array =
            (  from c in _docMD.Descendants("contract")
               select Select(c)                           
            ).ToArray();
            break; 
            
            
            default:
            _sel_mkt_array = new InTradeApi.Contract[1] { new InTradeApi.Contract( 
                  "000", "No markets found matching the search criteria.", "NO.SYMBOL", "--"  ) 
               };
               break;          
         }  
         
         // Refresh market dictionary.  (Lookup by conID)
         _SelMkts = _sel_mkt_array.ToDictionary( a => a.id ); 
         
         // Apply search criteria to selected contracts.
         // -- no search criteria at this point
         _SrchMkts = _SelMkts;
         
         _nPagePos = 0;
         GUI_UpdateMarketPage();
         GUI_UpdatePagers();
      }

      class LviMarket : ListViewItem {
         public LviMarket( string[] subitems, string tooltip )
            : base( subitems ) {
            this.ToolTipText = tooltip;
         }
      }

      public string StrArrayToStr(string[] sa) {
         return new string( (from str in sa from ch in str select ch).ToArray() );
      }
      
      const int PAGELEN = 100;
      private void GUI_UpdateMarketPage()
      {
         string text  = "";         
         string conID = "";
         
         // Construct a contract collection that represents the subset of the search results that 
         // fit on the current page. (Using foreach here since LINQ does not support an index function.
         //var PageMkts = from c in _SrchMkts where (_nPagePos <= index) && (index < _nPagePos + PAGELEN) select c;
         
         
         var SrchMkts = (from d in _SrchMkts select d.Value).ToArray(); 
         var PageMkts = new List<InTradeApi.Contract> ();
         for (int i = _nPagePos; i < Math.Min(_sel_mkt_array.Count(), _nPagePos + PAGELEN); i++) {
            PageMkts.Add( SrchMkts[i] );
         }

         // Construct a string consisting of the contract IDs of all the items on the page.
         // NOTE: We need to trim the final separator.
         const string sep = "&id=";
         var conIdPrm = new string( (from c in PageMkts from ch in ( c.id + sep ) select ch).ToArray() );
         if (0 < conIdPrm.Length) { conIdPrm.Remove(conIdPrm.Length - sep.Length); }         
                             
         //string[] sa = {"123", "456", "789"} ;
         //var chary = new string ( (from str in sa from ch in str select ch).ToArray() );
         
         // Construct a string consisting of the contract IDs of all the items on the page.
         for (int i = _nPagePos; i < Math.Min(_sel_mkt_array.Count(), _nPagePos + PAGELEN); i++)
         {            
            text  += _sel_mkt_array[i].id + ", "
                   + _sel_mkt_array[i].state + ", "
                   + _sel_mkt_array[i].symbol + ", "
                   + _sel_mkt_array[i].name + Environment.NewLine;  // debug
                   
            conID += _sel_mkt_array[i].id + sep;
         }
         if (0 < conID.Length) { conID.Remove(conID.Length - sep.Length); }

         // debug
         txtInHouse.Clear();
         txtInHouse.Text = text;
         
         // Query the ContractBookInfo for all currently selected contracts.
         // NOTE: The contracts in the returned data may be a subset of the contracts queried.
         string sUrl = String.Format( InTradeApi.ConBkInfoD, conID, "1" );
         string xmlRsp = HttpGetAndWait( sUrl );
         
         // Following a page update none of the columns are sorted.   
         GUI_ClearColHeaderImages();

         // *T*E*S*T*
         txtHttpGet.Text = sUrl;
         rtbHttpRsp.Text = xmlRsp;
         // *T*E*S*T*         
         
//@"<?xml version=""1.0"" encoding=""UTF-8""?>
//<ContractBookInfo lastUpdateTime=""1327055113128"">
//		<contractInfo close=""0.2"" conID=""721154"" lstTrdPrc=""0.2"" lstTrdTme=""-"" state=""O"" vol=""183"">
//				<symbol>CAP.TRADE.DEC2012</symbol>
//				<orderBook>
//						<bids>
//								<bid price=""1.0"" quantity=""5"" />
//								<bid price=""0.2"" quantity=""24"" />
//						</bids>
//						<offers>
//								<offer price=""10.0"" quantity=""4"" />
//						</offers>
//				</orderBook>
//		</contractInfo>
//    <contractInfo conID="755982" expiryPrice="0.0" expiryTime="1327221379000" state="S" vol="2670"/>
//    <contractInfo conID="755983" expiryPrice="0.0" expiryTime="1327221380000" state="S" vol="669"/>
//</ContractBookInfo>  
//";
         //var doc = XDocument.Parse( InTradeApi.sSampleContractBookInfo );
         
         var doc = XDocument.Parse( xmlRsp );
/*
         var CBI = (from ci in doc.Descendants("contractInfo")
                    from bid in ci.Descendants("bid"  ) 
                    from ofr in ci.Descendants("offer")
                    orderby (float)ci.Attribute("vol")
                    select new LviMarket
                    (new string[] 
                         { (string)ci .Element  ( "symbol"      ) ?? _SrchMkts[((string)ci.Attribute("conID"))].symbol 
                         , (string)ci .Attribute( "lstTrdPrc"   ) ?? ""
                         , (string)ci .Attribute( "vol"         ) ?? ""                           
                         , (string)ci .Attribute( "state"       ) ?? ""                           
                         , (string)bid.Attribute( "price"       ) ?? "" 
                         , (string)ofr.Attribute( "price"       ) ?? ""                           
                         , (string)ci .Attribute( "expiryPrice" ) ?? ""
                         }
                    , _SrchMkts[((string)ci.Attribute("conID")).Trim()].name
                    )
                  ).ToArray(); 
*/

         var tmp = InTradeApi.States['O'];

         var CBI = (from ci in doc.Descendants("contractInfo")
                    select 
                    new string[7] 
                    { (string)ci .Attribute( "conID"       ) ?? "-"
                    , (string)ci .Attribute( "lstTrdPrc"   ) ?? "-"
                    , (ci.Descendants("offer").FirstOrDefault() != null) ? (string)ci.Descendants("offer").First().Attribute( "price" ) : "-"                          
                    , (ci.Descendants("bid"  ).FirstOrDefault() != null) ? (string)ci.Descendants("bid"  ).First().Attribute( "price" ) : "-"                          
                    , (string)ci .Attribute( "vol"         ) ?? "-"                           
                    , InTradeApi.States[((string)ci.Attribute( "state" ) ?? "-")[0]]                    
                    , (string)ci .Attribute( "expiryPrice" ) ?? "-"
                    }
                    
                  ).ToArray();


/*
         // Inner Join:
         var Join = from c in PageMkts                  
                    join cbi in CBI on c.id equals cbi[0]  // inner join
                    select new { c = c, cbi = cbi };                    
                    
         // Group Join:
         var JoinG = from c in PageMkts
                     join cbi in CBI on c.id equals cbi[0] into cbiG
                     from cbi2 in cbiG
                     select new { c = c, cbi = cbi2 };
*/
                     
         // Left Outer Join                      
         var JoinLOJ = from c in PageMkts
                       join cbi in CBI on c.id equals cbi[0] into cbiG
                       from cbi2 in cbiG.DefaultIfEmpty( 
                         new string[7] { c.id, "--", "--", c.state, "--", "--", "--" }
                       ) 
                       select new { c = c, cbi = cbi2 };        


         var LVI = ( from j in JoinLOJ
                     select new LviMarket
                     ( new string[] { j.c.symbol, j.cbi[1], j.cbi[2], j.cbi[3], j.cbi[4], j.cbi[5], j.cbi[6] }
                       , j.c.name
                     )
                   ).ToArray();                              
                     
         // Items now has                              
         
         lvInHouse.Items.Clear(); 
         lvInHouse.Items.AddRange( LVI );     
      }
      
      const int PAGE_LEN = 50;
      private void GUI_UpdatePagers() {
      
         int nTotal = _sel_mkt_array.Count() ;
         int nFrom = _nPagePos;
         int nTo   = Math.Min( _nPagePos + PAGE_LEN, nTotal );
         
         lblPageDesc.Text = String.Format( "{0} thru {1} of {2}", nFrom+1, nTo, nTotal );

         btnPagePrev.Enabled = 0 < nFrom;         
         btnPageNext.Enabled = nTo < nTotal;
      }

      private void btnPagePrev_Click(object sender, EventArgs e) {
         _nPagePos = Math.Max(0, _nPagePos - PAGE_LEN);
         GUI_UpdatePagers();
         GUI_UpdateMarketPage();
      }

      private void btnPageNext_Click(object sender, EventArgs e) {
         _nPagePos = Math.Min(_sel_mkt_array.Count(), _nPagePos + PAGE_LEN);
         GUI_UpdatePagers();  
         GUI_UpdateMarketPage();       
      }
      

      //private void tvMain_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
      //}
      //private void tvMain_Click(object sender, EventArgs e)
      //{
      //}      
      //private void tvMain_MouseClick(object sender, MouseEventArgs e)
      //{
      //   TreeNode tn = tvMain.GetNodeAt( e.Location );
      //   if (tn.IsSelected) {
      //      tvMain.SelectedNode = tvMain.SelectedNode.Parent; 
      //   } 
      //}
      
      class WaitCursorScope : UsingBlock {
         Form f;
         public WaitCursorScope(Form f)  { this.f = f; f.Cursor = Cursors.WaitCursor; }
         public override void  Finally() {             f.Cursor = Cursors.Default   ; }
      }

      int  _colCurr = -1;
      bool _colDesc = false;
      private void lvInHouse_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         var lv = (ListView)sender;
         
         _colDesc = (_colCurr == e.Column) ? !_colDesc : false;
         _colCurr = e.Column;
         
         GUI_UpdateColHeaderImages( _colCurr, _colDesc );
         GUI_LvSortColumn( lv, _colCurr, _colDesc ); // type 
      }
      
      void GUI_LvSortColumn( ListView lv, int col, bool descending ) {
         using (var wcs = new WaitCursorScope(this)) {
            lv.ListViewItemSorter = new ColumnSorter(col, descending);
         }   
      }

      void GUI_UpdateColHeaderImages(int colArrow, bool descending) {
         foreach (ColumnHeader c in lvInHouse.Columns) {
         //   c.ImageIndex = (c.Index == colArrow) ? (descending ? 0 : 1) : -1;
         //   c.TextAlign = c.TextAlign;
            winapi.ColumnImageArrow( lvInHouse, c.Index, 
               (c.Index != colArrow) ? SortOrder.None          
                                     : (descending ? SortOrder.Descending : SortOrder.Ascending )
            );
         }
         //winapi.ColumnImageToRight( lvInHouse, colArrow );
         
      }
      void GUI_ClearColHeaderImages() {
         GUI_UpdateColHeaderImages(-1, false);
      }      

      // For ListViewItem Detals view column sorting.
      //
      // -- Sorting is as follows:
      //    - assumes all sub-items are strings
      //    - tries to to convert both strings to double and compare as such
      //    - if either cannot be converted, compares them as strings.
      //      
      class ColumnSorter : System.Collections.IComparer  
      {
         private int  column    ;      
         private bool descending;
                    
         public ColumnSorter( int column, bool descending ) { 
            this.column     = column    ;
            this.descending = descending;
         }

         public int Compare(object x, object y)
         {
            string s1 = ((ListViewItem)x).SubItems[column].Text;
            string s2 = ((ListViewItem)y).SubItems[column].Text;   
                     
            if (descending) { Misc.Swap( ref s1, ref s2 ); }
            
            try {
               double a = Double.Parse(s1);
               double b = Double.Parse(s2);
               return a == b ? 0 : a < b ? -1 : 1;
            } catch( Exception ) {
               return String.Compare( s1, s2 );            
            }   
         }      
      }    
      
      
//  HH   HH  TTTTTT  TTTTTT  PPPPPP       QQQQQ                               PPPPPP                      
//  HH   HH    TT      TT    PP   PP     QQ   QQ                              PP   PP                     
//  HH   HH    TT      TT    PP   PP     QQ   QQ                              PP   PP                     
//  HH   HH    TT      TT    PP   PP     QQ   QQ  uu  uu  eeee  rrr yy yy     PP   PP  aaaa   ggggg  eeee 
//  HHHHHHH    TT      TT    PPPPPP      QQ   QQ  uu  uu ee  ee rr  yy yy     PPPPPP      aa gg  gg ee  ee
//  HH   HH    TT      TT    PP          QQ   QQ  uu  uu eeeeee rr  yy yy     PP       aaaaa gg  gg eeeeee
//  HH   HH    TT      TT    PP          QQ QQQQ  uu  uu ee     rr  yy yy     PP      aa  aa gg  gg ee    
//  HH   HH    TT      TT    PP          QQ  QQQ  uu uuu ee  ee rr   yyy      PP      aa  aa gg  gg ee  ee
//  HH   HH    TT      TT    PP           QQQQQ    uuuuu  eeee  rr   yy       PP       aaaaa  ggggg  eeee 
//                                            QQ                     yy                          gg       
//                                                                 yyy                       ggggg        
      
    
      enum eHttpQryItems { None,MarketData,EventClass,ConBkInfo,ContractInfo,ClosingPrice,TimeSales };

      private eHttpQryItems _PendQry = eHttpQryItems.None;  // query posted to server
      private eHttpQryItems _PrepQry = eHttpQryItems.None;  // current query string
        
      class HttpQryItem {
         public readonly eHttpQryItems e;
         public readonly string sQryText;
         public readonly string sUserText;
         
         public HttpQryItem( eHttpQryItems e, string sQryText, string sUserText ) {
            this.e         = e;
            this.sQryText  = sQryText;         
            this.sUserText = sUserText;
         }
         public override string ToString() { return sUserText; }
      }
      
      static readonly HttpQryItem[] HttpQueryTable = 
      { new HttpQryItem(eHttpQryItems.EventClass  , InTradeApi.sUrlEventClass, "All Contracts By Event Class"       )
      , new HttpQryItem(eHttpQryItems.ConBkInfo   , InTradeApi.ConBkInfo     , "Price Information"                  )
      , new HttpQryItem(eHttpQryItems.ContractInfo, InTradeApi.ContractInfo  , "Contract Information"               )
      , new HttpQryItem(eHttpQryItems.ClosingPrice, InTradeApi.ClosingPrice  , "Hist.Trading Info (Closing Prices)" )
      , new HttpQryItem(eHttpQryItems.TimeSales   , InTradeApi.TimeSales     , "Daily Time and Sales"               )
      };
      
      class HttpQryDict : Dictionary<eHttpQryItems,HttpQryItem> {
         public HttpQryDict() {
            foreach (HttpQryItem qi in HttpQueryTable) { Add( qi.e, qi ); }   
         }
      }

      private HttpQryDict HttpQueries = new HttpQryDict();     

      
      private void GUI_InitHttpQryList() {
         foreach (HttpQryItem qi in HttpQueryTable) {
            cbHttpQry.Items.Add( qi );
            //qi.index = cbHttpQry.Items.IndexOf( qi.sUserText );
         }
         cbHttpQry.SelectedIndex = 0;
      }

      private void cbHttpQry_SelectedIndexChanged(object sender, EventArgs e) { PrepHttpQuery(); }
      private void txtEventClass_TextChanged     (object sender, EventArgs e) { PrepHttpQuery(); }
      private void txtContractID_TextChanged     (object sender, EventArgs e) { PrepHttpQuery(); }

      private void btnRefresh_Click(object sender, EventArgs e) {
         HttpGet(InTradeApi.AllActive, eHttpQryItems.MarketData);        
      }
      private void btnHttpQry_Click(object sender, EventArgs e) {
         HttpGet( txtHttpGet.Text, _PrepQry );  
      }   
      
      // asynchronous post
      void HttpGet( string sUrl, eHttpQryItems e ) {
         if (0 < sUrl.Length) {
            Cursor = Cursors.WaitCursor;
            _PendQry = e;
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri(sUrl), e );
         }               
      }
      
      // synchronous post (blocks)
      string HttpGetAndWait( string sUrl ) {
         string ret = null;
         if (0 < sUrl.Length) {
            using (var wcs = new WaitCursorScope(this)) {
               WebClient wc = new WebClient();
               ret = wc.DownloadString( sUrl );
            }
         }      
         return ret;
      }
      
      
      void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
      {
         Cursor = Cursors.Default;
      
         if (e.Error != null) {
            MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            return;
         }
         
         switch (_PendQry)
         {
            case eHttpQryItems.MarketData:
               string sMD = e.Result;
               _docMD = XDocument.Parse(sMD);               
               
               using (var sw = new StreamWriter(@"MarketData.xml")) {
                  sw.Write(sMD);
               }
               rtbMktData.Text = EasyXml.Pretty(sMD);
               break;

            case eHttpQryItems.EventClass:
            case eHttpQryItems.ConBkInfo:
            case eHttpQryItems.ClosingPrice:
            case eHttpQryItems.ContractInfo:
            case eHttpQryItems.TimeSales:
               rtbHttpRsp.Text = EasyXml.Pretty(e.Result);
               break;

            case eHttpQryItems.None:
               rtbHttpRsp.Text = "#UNKNOWN QUERY#" + Environment.NewLine + e.Result;
               break;
         }

         _PendQry = eHttpQryItems.None;
      }
      
      void PrepHttpQuery()
      {
         HttpQryItem qi = (HttpQryItem)cbHttpQry.Items[cbHttpQry.SelectedIndex];
         
         string sUrl = "";
         switch (qi.e) {
            //case eHttpQryItems.MarketData: break;
            case eHttpQryItems.EventClass:
               string classID = (0 < txtEventClass.Text.Length) ? txtEventClass.Text : "0";
               sUrl = String.Format(qi.sQryText, classID); 
               break;          
            case eHttpQryItems.ConBkInfo:
            case eHttpQryItems.ClosingPrice: 
            case eHttpQryItems.ContractInfo: 
            case eHttpQryItems.TimeSales:
               string conID = (0 < txtContractID.Text.Length) ? txtContractID.Text : "0" ;
               sUrl = String.Format(qi.sQryText, conID, "", "" );            
               break; 
               
            case eHttpQryItems.None: break;
         }
         
         txtHttpGet.Text = sUrl;
         _PrepQry = qi.e;         
      }
   }
}
