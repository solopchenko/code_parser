﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Word = Microsoft.Office.Interop.Word;

namespace Code_parser
{
    public class WordDocument
    {
        private Word._Application _wordApplication;
        private Word._Document _report;

        private static object _sum = "sum";
        private object _nameFileTemplate;


        public WordDocument(object pathToTemplate)
        {
            _nameFileTemplate = pathToTemplate;
        }

        public void ReportGeneration(Info info)
        {
            try
            {
                _wordApplication = new Word.Application();

                _report = _wordApplication.Documents.Open(ref _nameFileTemplate);

                int i = 2;
                foreach (var field in info.Fileds)
                {
                    _report.Tables[1].Cell(2, i++).Range.Text = field.ToString();
                }

                _report.Bookmarks.get_Item(ref _sum).Range.Text = info.Sum.ToString();

                _wordApplication.Visible = true;
            }
            catch (Exception)
            {
                _wordApplication.Quit();
                throw;
            }
        }
    }

    public class Info
    {
        private double[] _fields = new double[9];
        public double Sum { private set; get; }

        public double[] Fileds
        {
            get { return _fields; }
        }

        public Info(double s, params double[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                _fields[i] = list[i];
            }

            Sum = s;
        }
    }
}
