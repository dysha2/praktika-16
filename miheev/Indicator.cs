using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace miheev
{
    public class Indicator
    {
        private uint[] pages = new uint[10];
        private string Word;
        public Indicator(string word)
        {
            Word = word;
        }
        public string GetWord() => Word;

        static public List<Indicator> GetIntoFile(string FileName)
        {
            List<Indicator> indicators = new List<Indicator>();
                    List<string[]> text = File.ReadAllLines(FileName).Select(x => x.Split(' ')).ToList();

                    foreach (string[] s in text)
                    {
                        try { 
                            Indicator ind = new Indicator(s[0]);
                            List<uint> pages = new List<uint>();
                            for (int i = 1; i < s.Length; i++)
                            {
                                uint a;
                                if (uint.TryParse(s[i], out a)) pages.Add(a);
                            }
                            if (pages.Count > 10)
                            {
                                pages.RemoveRange(10, pages.Count - 10);
                            } else
                            {
                            uint[] b = new uint[10 - pages.Count];
                            pages.AddRange(b);
                            }
                            ind.pages = pages.ToArray();
                            indicators.Add(ind);
                        }
                        catch { MessageBox.Show("В файле есть пустое поле"); }
                    }
                    return indicators;
        }
        public bool AddPage(uint page)
        {
                for (int i=0;i<pages.Length;i++)
                {
                    if (pages[i] == 0)
                    {
                        pages[i] = page;
                        return true;
                    }
                }
            return false;
        }

        public string GetIndicator()
        => Word + " " + string.Join(" ", pages.ToList().Select(x => x.ToString()).Where(x=>x!="0"));
        
        public void RemovePage(uint page)
        {
            for (int i=0;i<pages.Length;i++)
            {
                pages[i] = pages[i] == page ? 0 : pages[i];
            }
        }
    }
}
