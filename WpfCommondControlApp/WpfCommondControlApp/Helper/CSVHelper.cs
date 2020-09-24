using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCommondControlApp.Helper
{
    /// <summary>
    /// 描述：csv操作类
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public class CSVHelper
    {
        /// <summary>
        /// 打开csv
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable OpenCSV(string filePath)
        {
            DataTable dt = new DataTable();
            if (!File.Exists(filePath))
            {
                return null;
            }
            try
            {
                using (FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        string strLine = "";
                        //记录每行记录中的各字段内容
                        string[] aryLine = null;
                        string[] tableHead = null;
                        //标示列数
                        int columnCount = 0;
                        //标示是否是读取的第一行
                        bool IsFirst = true;

                        int hangshu = 0;

                        //  逐行读取CSV中的数据
                        while ((strLine = sr.ReadLine()) != null)
                        {
                            if (IsFirst == true)
                            {
                                tableHead = strLine.Split(',');
                                IsFirst = false;
                                columnCount = tableHead.Length;
                                for (int i = 0; i < columnCount; i++)
                                {
                                    tableHead[i] = tableHead[i].Replace("\"", "");
                                    DataColumn dc = new DataColumn(tableHead[i]);
                                    dt.Columns.Add(dc);
                                }
                            }
                            else
                            {
                                aryLine = strLine.Split(',');
                                DataRow dr = dt.NewRow();
                                for (int j = 0; j < columnCount; j++)
                                {
                                    dr[j] = aryLine[j].Replace("\"", "");
                                }
                                dt.Rows.Add(dr);
                            }
                            hangshu += 1;

                            //Console.WriteLine(dt.Rows.Count);
                        }

                        //
                        //if (aryLine != null && aryLine.Length > 0)
                        //{
                        //    dt.DefaultView.Sort = tableHead[2] + " " + "DESC";
                        //}
                        sr.Close();
                        fs.Close();

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("检测到SN.csv正在被别的程序占用，请先关闭进程，再继续操作");
            }
            return dt;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        public static Boolean SaveCSV(DataTable dt, string fullFileName)
        {
            Boolean r = false;
            try
            {
                using (FileStream fs = new FileStream(fullFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                    {
                        string data = "";

                        //写出列名称
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            data += dt.Columns[i].ColumnName.ToString();
                            if (i < dt.Columns.Count - 1)
                            {
                                data += ",";
                            }
                        }
                        sw.WriteLine(data);

                        //写出各行数据
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = "";
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                data += dt.Rows[i][j].ToString();
                                if (j < dt.Columns.Count - 1)
                                {
                                    data += ",";
                                }
                            }
                            sw.WriteLine(data);
                        }
                        sw.Close();
                        fs.Close();

                        r = true;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("随意记录一下就行");
            }
            return r;
        }

        /// <summary>
        /// 用法记录一下，不过使用的时候还是参考文档更快
        /// </summary>
        public static void Usage()
        {
            var dt = OpenCSV(System.AppDomain.CurrentDomain.BaseDirectory + @"\SN.csv");
            if (dt == null || dt.Columns.Count == 0)
            {
                dt = new DataTable("SNTable");
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "时间";
                // Add the Column to the DataColumnCollection.
                dt.Columns.Add(column);

                // Create second column.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "结果";
                dt.Columns.Add(column);

                // Create third column.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "读取SN";
                dt.Columns.Add(column);

                // Create third column.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "扫描SN";
                dt.Columns.Add(column);


            }
            DataRow row;
            row = dt.NewRow();
            row["时间"] = "时间：" + DateTime.Now.ToString();
            row["结果"] = "通过" ;
            row["读取SN"] = "读取SN：" ;
            row["扫描SN"] = "扫描SN：" ;
            dt.Rows.Add(row);
            SaveCSV(dt, System.AppDomain.CurrentDomain.BaseDirectory + @"\SN.csv");

        }
    }
}
