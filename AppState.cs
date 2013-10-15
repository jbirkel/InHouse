using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq; 
using System.Linq; 

using System.Text;

using jhblib;

namespace InHouseApp
{
   public class AppState
   {
      // The place for any single-dimension form extents we want to save.
      public Dictionary<FormExtents_e, int> FormExtents;

      public enum FormExtents_e 
      { AppLft, AppTop, AppWid, AppHgt
      , MktTreeWid
      , ColSymWid, ColLPrWid, ColVolWid, ColBidWid, ColOfrWid, ColStaWid, ColEPrWid
      }

      public class FormExtents_t : Dictionary<FormExtents_e, int> {}
            
      // constructor loads state from App Settings collection
      public AppState() {

         FormExtents = new Dictionary<FormExtents_e, int> ();      
      
         try {
            EasyXml.ImportDict( ref FormExtents
               , Properties.Settings.Default.FormExtents 
               , a => (FormExtents_e)Enum.Parse(typeof(FormExtents_e), (string)a) 
               , a => (int)a 
            ); 
         } catch {};   
      }
      
      public void Save() {
         Properties.Settings.Default.FormExtents = EasyXml.ExportDict(FormExtents);          
         Properties.Settings.Default.Save();
      }
   }
}
