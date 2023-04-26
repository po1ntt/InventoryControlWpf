using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using word = Microsoft.Office.Interop.Word;

namespace InventoryControl.Service
{
    public class WordService
    {
        private FileInfo _fileInfo;
        public WordService(string filename)
        {
            if(File.Exists(filename))
            {
                _fileInfo = new FileInfo(filename);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
            
        }
        internal bool Process(Universalniy_Dogovor_peredachi universalniy_Dogovor)
        {
           word.Application app = null;

            try
            {
                app = new word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);
                var items = new Dictionary<string, string>()
                {
                    {"[postavshik]", universalniy_Dogovor.Seller.nameSeller},
                    {"[gruzoPoluchatel]", universalniy_Dogovor.Shipper.NameShipper},
                    {"[AdressGruzoPoluchatel]", universalniy_Dogovor.Shipper.AdressShipper },
                    {"[NumberDoc]", universalniy_Dogovor.NumberUniversal },
                    {"[dataDoc]", universalniy_Dogovor.DateCreated.ToString() }

                };
                foreach( var item in items )
                {
                    word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;
                    Object wrap = word.WdFindWrap.wdFindContinue;
                    Object replace = word.WdReplace.wdReplaceAll;
                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false
                        , ReplaceWith: missing, Replace: replace);
                }
                word.Table table = app.ActiveDocument.Tables[1];
                int index = 2;

                foreach ( var item in universalniy_Dogovor.ItemsNakladnay)
                {

                    table.Rows.Add(missing);
                    table.Cell(index, 1).Range.Text = item.id_itemNakladnay.ToString();
                    table.Cell(index, 2).Range.Text = item.Equipment.name;
                    table.Cell(index, 3).Range.Text = item.Equipment.id_equip.ToString();
                    table.Cell(index, 4).Range.Text = item.count.ToString();
                    table.Cell(index, 5).Range.Text = "5 кг";
                    table.Cell(index, 6).Range.Text = "3 кг";
                    table.Cell(index, 7).Range.Text = "Коробка";
                    table.Cell(index, 8).Range.Text = item.price.ToString();
                    index++;


                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, DateTime.Now.ToString("yyyyMMdd HHmmsss") +  _fileInfo.Name);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                return true;
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(app != null)
                {
                    app.Quit();
                }
            }
            return false;

        }
    }
}
