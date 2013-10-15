using System;
using System.Collections.Generic; 
using System.Linq;

namespace InHouseApp
{
   // Based on Intrade_XML_API.pdf
   public class InTradeApi
   {
      public const string Http_Server = "http://api.intrade.com/jsp/XML/MarketData";

      // 3.1 Active Contract Listing 
      // This is a list of all active contract and contracts that have expired(settled) within the last 24hrs.
      public const string AllActive = Http_Server + "/xml.jsp";

      // 3.2 All Contracts By Event Class
      //   To get a list of contracts in a specific class where:
      //   {0} - the id of the EventClass  (E.g. 19 for politics.)
      public const string sUrlEventClass = Http_Server + "/XMLForClass.jsp?classID={0}";

      // 3.3 Price Information
      //   Current price information:
      //   {0} - the id of the contract for which marketdata is to be returned. 
      //         (Multiple ids may be specified,  e.g. id=23423&id=34566&... ) 
      //   {1} - a timestamp to indicate a cutoff period for marketdata. Contracts whose
      //         marketdata has not changed since this timestamp will not be displayed.
      //         Timestamps are represented by the number of milliseconds since January 1, 1970, 00:00:00 GMT.
      //   {2} - the depth of orders that are returned. This defaults to 5. i.e. a maximum of 5
      //         bid/offer prices are returned. If you just need the best price you should pass in “depth=1”      
      //
      //   Example: http://api.intrade.com/jsp/XML/MarketData/ContractBookXML.jsp?id=21433&id=11738&timestamp=0      
      //            
      public const string ConBkInfo   = Http_Server + "/ContractBookXML.jsp?id={0}";      
      public const string ConBkInfoT  = Http_Server + "/ContractBookXML.jsp?id={0}&timestamp={1}";      
      public const string ConBkInfoD  = Http_Server + "/ContractBookXML.jsp?id={0}&depth={1}";      
      public const string ConBkInfoTD = Http_Server + "/ContractBookXML.jsp?id={0}&timestamp={1}&depth={2}";

      // 3.4 Contract Info
      //   Other contract data:
      //   {0} id - the id of the contract for which information is to be returned. 
      //            (Multiple ids may be specified, e.g. id=23423&id=34566&... )
      //
      //   Example: http://api.intrade.com/jsp/XML/MarketData/ConInfo.jsp?id=11738
      //      
      public const string ContractInfo = Http_Server + "/ContractInfo.jsp?id={0}";

      // 3.5 Historical Trading Info (Closing Prices)
      //   Historical closing price and session hi/lo data:
      //   {0} - the id of the contract for which information is to be returned. (Single id only.)
      //
      //   Example: http://api.intrade.com/jsp/XML/MarketData/ClosingPrice.jsp?conID=11738   
      //
      public const string ClosingPrice = Http_Server + "/ClosingPrice.jsp?conID={0}";

      // 3.6 Daily Time and Sales
      //   Time and Sales data information, returned in CSV format.
      //   {0} - the id of the contract for which marketdata is to be returned. Single id only. 
      //
      //   Example: https://api.intrade.com/jsp/XML/TradeData/TimeAndSales.jsp?conID=11738
      //
      //   NOTE: The CSV format is: UTC Timestamp, BST Datetime, Price, volume.

      public const string TimeSales = Http_Server + "/TimeAndSales.jsp?conID={0}";

      public const string XMLAPI_Server = "http://api.intrade.com/xml/handler.jsp";
      public const string XMLAPI_Sandbox = "http://api.intrade.com/jsp/XML/MarketData";
      
      public const string sSampleMarketData =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<MarketData intrade.timestamp=""1326664159013"">
      <EventClass id=""78"">
            <name>Business</name>
            <displayOrder>20</displayOrder>
            <EventGroup id=""9605"">
                  <name>Cap and Trade</name>
                  <displayOrder>230</displayOrder>
                  <Event EndDate=""1388577600000"" StartDate=""1237939200000"" groupID=""9605"" id=""86968"">
                        <Description />
                        <name>A cap and trade system for emissions trading to be established in the United States</name>
                        <displayOrder>27817</displayOrder>
                        <contract ccy=""USD"" id=""721154"" inRunning=""false"" state=""O"" tickSize=""0.1"" tickValue=""0.01"" type=""PX"">
                              <name>A cap and trade system for emissions trading to be established before midnight ET on 31 Dec 2012</name>
                              <symbol>CAP.TRADE.DEC2012</symbol>
                              <totalVolume>183</totalVolume>
                        </contract>
                        <contract ccy=""USD"" id=""721155"" inRunning=""false"" state=""O"" tickSize=""0.1"" tickValue=""0.01"" type=""PX"">
                              <name>A cap and trade system for emissions trading to be established before midnight ET on 31 Dec 2013</name>
                              <symbol>CAP.TRADE.DEC2013</symbol>
                              <totalVolume>60</totalVolume>
                        </contract>
                  </Event>
            </EventGroup>
		</EventClass>
</MarketData>
";
      public class Contract {
         public string id { get; set; }
         public string name { get; set; }
         public string symbol { get; set; }
         //public char   state { get; set; }                
         public string state { get; set; }       
         //public Contract(string id, string name, string symbol, char state)         
         public Contract(string id, string name, string symbol, string state)
         {
            this.id = id;
            this.name = name;
            this.symbol = symbol;
            this.state  = state;
         }
      }

      public const string sSampleContractBookInfo =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<ContractBookInfo lastUpdateTime=""1327055113128"">
		<contractInfo close=""0.2"" conID=""721154"" lstTrdPrc=""0.2"" lstTrdTme=""-"" state=""O"" vol=""183"">
				<symbol>CAP.TRADE.DEC2012</symbol>
				<orderBook>
						<bids>
								<bid price=""1.0"" quantity=""5"" />
								<bid price=""0.2"" quantity=""24"" />
								<bid price=""0.1"" quantity=""75"" />
						</bids>
						<offers>
								<offer price=""10.0"" quantity=""4"" />
						</offers>
				</orderBook>
		</contractInfo>
</ContractBookInfo>  
";    
      
      public const string sSampleClosingPrice =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<ClosingPrice timestamp=""1327084549410"">
		<cp date=""7:00AM 06/03/10 GMT"" dt=""1275548407000"" price=""45.0"" sessionHi=""45.0"" sessionLo=""40.0"" />
		<cp date=""7:00AM 06/04/10 GMT"" dt=""1275634808000"" price=""45.0"" sessionHi="""" sessionLo="""" />
		<cp date=""7:00AM 06/05/10 GMT"" dt=""1275721208000"" price=""45.0"" sessionHi="""" sessionLo="""" />
		<cp date=""7:00AM 01/18/12 GMT"" dt=""1326870018000"" price=""0.200000002980232"" sessionHi="""" sessionLo="""" />
		<cp date=""7:00AM 01/19/12 GMT"" dt=""1326956419000"" price=""0.200000002980232"" sessionHi="""" sessionLo="""" />
		<cp date=""7:00AM 01/20/12 GMT"" dt=""1327042816000"" price=""0.200000002980232"" sessionHi="""" sessionLo="""" />
</ClosingPrice>      
";

      // --------------------------------------------------------------------------------
      // Contract state codes      
      // --------------------------------------------------------------------------------

      public static Dictionary<char, string> States = new Dictionary<char, string> 
      { { 'I', "Initialized"       }    
      , { 'O', "Open"              }       
      , { 'P', "Paused"            }
      , { 'C', "Session Closed"    }       
      , { 'E', "Closed for Expiry" }       
      , { 'S', "Settled (Expired}" }       
      , { 'X', "Cancelled"         }       
      , { 'R', "Reversed"          }       
      , { '-', "No state"          }                   
      , { '?', "???Unknown"        }             
      };
            
      /*
      public static State_dict States = new State_dict();

      public class State_dict : Dictionary<char, string> {
        
         public State_dict() 
         { 
            var A = new[]
            {  new { code='I', desc="Initialized"       }    
            ,  new { code='O', desc="Open"              }       
            ,  new { code='P', desc="Paused"            }
            ,  new { code='C', desc="Session Closed"    }       
            ,  new { code='E', desc="Closed for Expiry" }       
            ,  new { code='S', desc="Settled (Expired}" }       
            ,  new { code='X', desc="Cancelled"         }       
            ,  new { code='R', desc="Reversed"          }       
            ,  new { code='-', desc="No state"          }                   
            ,  new { code='?', desc="???Unknown"        }             
            };               
            
            foreach (var a in A) { this.Add(a.code, a.desc); } 
         }
      }
      */
   
/*      
      public class MarketData {
         //public List<EventClass> classes;      
         public EventClass[] classes;
//         public MarketData () {
//            classes = new List<EventClass>();
//         }
      }      
      
      public class EventClass {
         public string name { get; set; }
//         public List<EventGroup> groups;         
         public EventGroup[] groups;
//         public EventClass() {
//            groups = new List<EventGroup>();
//         }
      }
      
      public class EventGroup {
         public string name { get; set; }      
      }
*/
   }
}
