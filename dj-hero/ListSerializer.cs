using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace dj_hero
{
    public class ListSerializer<T>
    {
        public List<T> list;
        private string fileName;
        private string header;

        public ListSerializer(string fileName, string header, List<T> list)
        {
            this.list = list;
            this.fileName = fileName;
            this.header = header;
        }

        public List<T> PullData()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute
            {
                ElementName = header,
                IsNullable = true
            };
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<T>), oRootAttr);
            StreamReader oStreamReader = null;

            try
            {
                oStreamReader = new StreamReader(fileName + ".xml");
                list = (List<T>)oSerializer.Deserialize(oStreamReader);
            }
            catch (FileNotFoundException)
            {
                PushData(); //jeśli plik nie istnieje, to go utwórz.
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd: " + e.Message);
            }
            finally
            {
                if (null != oStreamReader)
                {
                    oStreamReader.Dispose();
                }
            }
            return list;
        }
        /**
        * <summary>
        * Wysyła listę do pliku.
        * </summary>
        **/
        public void PushData()
        {
            XmlRootAttribute oRootAttr = new XmlRootAttribute
            {
                ElementName = header,
                IsNullable = true
            };
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<T>), oRootAttr);
            StreamWriter oStreamWriter = null;

            try
            {
                oStreamWriter = new StreamWriter(fileName + ".xml");
                oSerializer.Serialize(oStreamWriter, list);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd: " + e.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }
        }
        /**
         * <summary>
         * Zwraca listę.
         * </summary>
         * <returns>Zwraca listę</returns>
         **/
        public List<T> GetList()
        {
            return list;
        }
    }
}
