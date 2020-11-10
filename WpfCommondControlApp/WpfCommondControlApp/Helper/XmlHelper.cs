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
        /// 获取本地缓存配置，如果不存在，再去请求获取
        /// </summary>
        /// <param name="cfgXmlName">请求的文件名</param>
        /// <returns>文件流</returns>
        private static Stream GetLocalCacheConfig(string cfgXmlName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/LocalCacheConfig.xml";
            if (!File.Exists(path))
            {
                //string ftp = $"ftp://{ModuleSummary.Setting.CommunicationSetting.IP}:21/tmp/";
                //return AutocruisCommunicator.GetDownloadFTPStream(ftp + cfgXmlName);
            }

            FileStream stream = new FileStream(path, FileMode.Open);
            return stream;
        }

        /// <summary>
        /// 定位路径
        /// </summary>
        /// <param name="sourceItem">写入的item</param>
        /// <param name="TargetElement">目标element</param>
        private static void FindXmlElement(XElement sourceItem, XElement TargetElement)
        {
            var nodeName = sourceItem.Name;

            // 覆盖文档的节点名称
            Console.WriteLine("节点：{0}；值：{1}", nodeName, sourceItem.Value);
            var targetElements = TargetElement.Descendants(nodeName);

            // 定位
            if (targetElements.Count() == 0)
            {
                // 暂未发现出现null的情况
                // nodename在外部找不到的情况，需要确认是根节点还是新增子节点
                if (nodeName == TargetElement.Name)
                {
                    // 根节点处理
                    SetAttributes(sourceItem, TargetElement);
                }
                else
                {
                    // 新增节点处理
                    var parentElement = GetParentElement(sourceItem, TargetElement);
                    parentElement.Add(sourceItem);
                }
            }
            else if (targetElements.Count() == 1)
            {
                if (CheckParent(sourceItem.Parent, targetElements.First().Parent))
                {
                    // 由于这个targetElements的子集是全部同名的都会找到，则需要更严格的判断条件
                    // 只有一个节点的类型，则修改
                    SetAttributes(sourceItem, targetElements.First());
                }
                else
                {
                    // 新增节点处理
                    var parentElement = GetParentElement(sourceItem, TargetElement);
                    parentElement.Add(sourceItem);
                }
            }
            else
            {

                // 多个节点的类型，则继续寻找
                var sourceKey = sourceItem.Attribute("Key");
                foreach (var e in targetElements)
                {
                    var d = e.Attribute("Key");
                    if (CheckParent(sourceItem.Parent, e.Parent))
                    {
                        // 定位得条件变得更加苛刻，Key相同，且父类得节点名称相同
                        if (e.Attribute("Key").ToString() == sourceKey.ToString())
                        {
                            SetAttributes(sourceItem, e);
                            break;
                        }
                    }

                    if (e == targetElements.Last())
                    {
                        // 相同节点的匹配到最后都没有，则视为新增
                        GetParentElement(sourceItem, TargetElement).Add(sourceItem);
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
                // 当成一种默认规则吧，不然会被覆盖掉子节点，如果存在子节点，那就不往里面放value；
                targetElement.Value = sourceElement.Value;
            }

            foreach (var a in sourceElement.Attributes())
            {

                // 没有会添加，有就修改
                targetElement.SetAttributeValue(a.Name, a.Value);
            }
        }

        /// <summary>
        ///  获取目标节点的父节点
        /// </summary>
        /// <param name="sourceItem"></param>
        /// <param name="TargetElement"></param>
        /// <returns></returns>
        private static XElement GetParentElement(XElement sourceItem, XElement TargetElement)
        {
            if (sourceItem.Parent == null)
            {
                return null;
            }

            var parentname = sourceItem.Parent.Name;
            var targetElements = TargetElement.Descendants(parentname);
            if (targetElements.Count() == 0)
            {
                if (parentname == TargetElement.Name)
                {
                    return TargetElement;
                }
                else
                {
                    // 目标文档里面不存在这个源的父类的节点
                    return GetParentElement(sourceItem.Parent, TargetElement);
                }
            }

            if (targetElements.Count() == 1)
            {
                // 目标文件的路径里面只有一个这个节点名称
                return targetElements.First();
            }
            else
            {
                // 父节点再目标区域有多个同名节点的情况
                var sourceKey = sourceItem.Parent.Attribute("Key");
                foreach (var e in targetElements)
                {
                    var d = e.Attribute("Key");
                    // 定位得条件变得更加苛刻，Key相同，且父类得节点名称相同
                    if (e.Attribute("Key").ToString() == sourceKey.ToString())
                    {
                        return e;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 检查是否属于同一个父节点
        /// </summary>
        /// <param name="sourceItem"></param>
        /// <param name="TargetElement"></param>
        /// <returns></returns>
        private static bool CheckParent(XElement sourceItem, XElement TargetElement)
        {
            if (sourceItem.Attribute("Key") == null && TargetElement.Attribute("Key") == null)
            {
                // 源和目标都没有Key作为判断，则只判断父类名称
                return sourceItem.Parent?.Name == TargetElement.Parent?.Name;
            }
            else if (sourceItem.Attribute("Key") != null && TargetElement.Attribute("Key") == null)
            {
                return false;
            }
            else if (sourceItem.Attribute("Key") == null && TargetElement.Attribute("Key") != null)
            {
                return false;
            }
            else
            {
                return sourceItem.Parent.Name == TargetElement.Parent.Name && sourceItem.Attribute("Key") == TargetElement.Attribute("Key");
            }
        }

    }
}
