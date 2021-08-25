using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tenaris.View.CycleTime.Config
{
    public class ColumnCollection : ConfigurationElementCollection, IEnumerable<ColumnElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ColumnElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ColumnElement)element).Name;
        }

        public ColumnElement this[int index]
        {
            get
            {
                return BaseGet(index) as ColumnElement;
            }
            set
            {
                if ((BaseGet(index)) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public ColumnElement this[string key]
        {
            get
            {
                return BaseGet(key) as ColumnElement;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "Column";
            }
        }


        #region IEnumerable<ColumnElement> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public new IEnumerator<ColumnElement> GetEnumerator()
        {
            int count = base.Count;

            for (int i = 0; i < count; i++)
            {
                yield return base.BaseGet(i) as ColumnElement;
            }
        }

        #endregion
    }
}
