using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WpfCommondControlApp.Helper
{
    /// <summary>
    /// 描述：xml的工具类
    /// 提供公共的xml处理方法
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public static class XmlHelper
    {

        private static XElement _lastNode;
        public static void Test()
        {
            string targetpath = @"E:\Target.xml";//需要被修改的文档
            string sourcepath = @"E:\Source.xml";//使用值取覆盖的文档
            using (Stream stream = File.Open(targetpath, FileMode.Open))
            {
                var p = stream.Position;
                var l = stream.Length;
                XElement TargetElement = XElement.Load(stream);//被修改
                //清空原本的流数据
                XElement sourceElement = XElement.Load(sourcepath);
                foreach (var sourceItem in sourceElement.DescendantsAndSelf())
                {
                    FindXmlElement(sourceItem, TargetElement);
                }
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    TargetElement.Save(ms);
                //    byte[] buffer = new byte[8192];
                //    int readCount = ms.Read(buffer, 0, buffer.Length);
                //    while (readCount > 0)
                //    {
                //        ms.Write(buffer, 0, readCount);
                //        readCount = ms.Read(buffer, 0, buffer.Length);
                //    }
                //    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                //}
                //保存
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                XmlWriter writer = XmlWriter.Create(@"E:\Target2.xml", settings);
                
                TargetElement.WriteTo(writer);

                writer.WriteEndDocument();

                // Write the XML to file and close the writer.
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// 定位路径
        /// </summary>
        /// <param name="sourceItem">写入的item</param>
        /// <param name="TargetElement">目标element</param>
        private static void FindXmlElement(XElement sourceItem, XElement TargetElement)
        {
            var nodeName = sourceItem.Name;//覆盖文档的节点名称
            Console.WriteLine("节点：{0}；值：{1}", nodeName, sourceItem.Value);
            var targetElements = TargetElement.Descendants(nodeName);
            //定位
            if (targetElements.Count() == 0)
            {
                //暂未发现出现null的情况
                //nodename在外部找不到的情况，需要确认是根节点还是新增子节点
                if (nodeName == TargetElement.Name)
                {
                    _lastNode = TargetElement;
                    //根节点处理
                    SetAttributes(sourceItem, TargetElement);
                }
                else
                {
                    //新增节点处理
                    _lastNode.Parent.Add(new XElement(nodeName));
                    var t = TargetElement.Descendants(nodeName);
                    SetAttributes(sourceItem, t.First());
                }
            }
            else if (targetElements.Count() == 1)
            {
                _lastNode = targetElements.First();
                //只有一个节点的类型，则修改
                SetAttributes(sourceItem, targetElements.First());
            }
            else
            {
                _lastNode = targetElements.First();
                //多个节点的类型，则继续寻找
                var sourceKey = sourceItem.Attributes("Key");
                foreach (var e in targetElements)
                {
                    //默认一个把，作为一个单一判断量.也先认为全部存在吧
                    if (e.Attribute("Key") == sourceKey)
                    {
                        SetAttributes(sourceItem, e);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 修改，设置属性和对应的值
        /// </summary>
        /// <param name="sourceElement"></param>
        /// <param name="targetElement"></param>
        private static void SetAttributes(XElement sourceElement, XElement targetElement)
        {
            if (!targetElement.HasElements)
            {
                //当成一种默认规则吧，不然会被覆盖掉子节点，如果存在子节点，那就不往里面放value；
                targetElement.Value = sourceElement.Value;
            }
            foreach (var a in sourceElement.Attributes())
            {
                //没有会添加，有就修改
                targetElement.SetAttributeValue(a.Name, a.Value);
            }
        }

    }
}
