using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DictionarySpeaking
{
    public class DictionaryManager
    {
        #region properties
        private string filePath = "data.xml";
        private DictionaryItem items;

        public DictionaryItem Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
        #endregion

        public DictionaryManager()
        {
            items = (DictionaryItem)DeSerializeFromXML(filePath);
        }

        #region Methods
        public void LoadDataToComboBox(ComboBox combo)
        {
            combo.DataSource = Items.Items;
        }

        public void SerializeToXML(object data, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer sr = new XmlSerializer(typeof(DictionaryItem));
                sr.Serialize(fs, data);
            }
        }

        public void Serialize()
        {
            SerializeToXML(Items, filePath);
        }

        public object DeSerializeFromXML(string filePath)
        {
            object ob;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer sr = new XmlSerializer(typeof(DictionaryItem));
                ob = sr.Deserialize(fs);
            }
            return ob;
        }
        #endregion
    }
}
