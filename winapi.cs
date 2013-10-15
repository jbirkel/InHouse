// --------------------------------------------------------------------------------------
// WINAPI.CS
//
// These two functions are fixes for capabilities left out of the ListView .NET class:
//   ColumnImageRight - place a ListView column header image to the right of the text
//   ColumnImageArrow - provides access to the built-in LV arrow images: up/down/none
//
// --------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InHouseApp
{
   //
   class winapi
   {
      public static void ColumnImageToRight(ListView lv, int col, bool bReverse) {
         SetLvmColumnFormat(lv, col, !bReverse ? HDF_BITMAP_ON_RIGHT : 0, bReverse ? HDF_BITMAP_ON_RIGHT : 0);
      }

      public static void ColumnImageArrow(ListView lv, int col, SortOrder so ) {
         switch (so) {
            case SortOrder.Ascending : SetLvmColumnFormat(lv, col, HDF_SORTUP  , HDF_SORTUP | HDF_SORTDOWN); break;
            case SortOrder.Descending: SetLvmColumnFormat(lv, col, HDF_SORTDOWN, HDF_SORTUP | HDF_SORTDOWN); break;            
            default    /* .None */   : SetLvmColumnFormat(lv, col, 0           , HDF_SORTUP | HDF_SORTDOWN); break;            
         }
      }

      // From: http://social.msdn.microsoft.com/forums/en-US/winforms/thread/e3d5c054-3d74-453c-82fe-53f945545025/
      private static void SetLvmColumnFormat(ListView lv, int index, int fmtSet, int fmtClr)
      {
         if (!lv.IsHandleCreated      ) throw new InvalidOperationException  ( "Bad ListView handle"       );
         if (index >= lv.Columns.Count) throw new ArgumentOutOfRangeException( "Column index out of range" );

         LVCOLUMN lvc = new LVCOLUMN();
         lvc.mask = LVCF_FMT;

         IntPtr buf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(LVCOLUMN)));
         Marshal.StructureToPtr(lvc, buf, false);
         IntPtr retval = SendMessageW(lv.Handle, LVM_GETCOLUMNW, (IntPtr)index, buf);

         lvc = (LVCOLUMN)Marshal.PtrToStructure(buf, typeof(LVCOLUMN));
         lvc.fmt &= ~fmtClr;
         lvc.fmt |=  fmtSet;         
         Marshal.StructureToPtr(lvc, buf, false);

         retval = SendMessageW(lv.Handle, LVM_SETCOLUMNW, (IntPtr)index, buf);

         //Marshal.FreeHGlobal(lvc.pszText);
         Marshal.FreeHGlobal(buf);
      }      
      
      // P/Invoke declarations:
      [DllImport("user32.dll", CharSet = CharSet.Unicode)]
      private extern static IntPtr SendMessageW(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

      // ----------------------------------------
      // LVCOLUMN declarations (from CommCtrl.h)
      // ----------------------------------------
      private const int LVM_GETCOLUMNW = 0x1000 + 95;
      private const int LVM_SETCOLUMNW = 0x1000 + 96;
      
      private const int LVCF_FMT     = 0x0001;
      private const int LVCF_WIDTH   = 0x0002;
      private const int LVCF_TEXT    = 0x0004;
      private const int LVCF_SUBITEM = 0x0008;
      
      private const int HDF_LEFT        =  0x0000;
      private const int HDF_RIGHT       =  0x0001;
      private const int HDF_CENTER      =  0x0002;
      private const int HDF_JUSTIFYMASK =  0x0003;
      private const int HDF_RTLREADING  =  0x0004;
                                        
      private const int HDF_OWNERDRAW   =  0x8000;
      private const int HDF_STRING      =  0x4000;
      private const int HDF_BITMAP      =  0x2000;
                                              
// #if (_WIN32_IE >= 0x0300)                  
      private const int HDF_BITMAP_ON_RIGHT =  0x1000;
      private const int HDF_IMAGE           =  0x0800;
// #endif                               
// #if (_WIN32_WINNT >= 0x501)          
      private const int HDF_SORTUP          =  0x0400;
      private const int HDF_SORTDOWN        =  0x0200;
// #endif

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
      private class LVCOLUMN
      {
         public int mask;
         public int fmt;
         public int cx;
         public IntPtr pszText;
         public int cchTextMax;
         public int iSubItem;
// #if (_WIN32_IE >= 0x0300) public
//         public int    iImage;
//         public int    iOrder;
// #endif
// #if (_WIN32_WINNT >= 0x0600)
//         public int cxMin;
//         public int cxDefault;
//         public int cxIdeal;
// #endif 
      }
   }
}
