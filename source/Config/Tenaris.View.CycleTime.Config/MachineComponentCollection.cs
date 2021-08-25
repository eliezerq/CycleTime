using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tenaris.View.CycleTime.Config
{
    public class MachineComponentCollection : ConfigurationElementCollection, IEnumerable<MachineComponentElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MachineComponentElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MachineComponentElement)element).Id;
        }

        public MachineComponentElement this[int index]
        {
            get
            {
                return BaseGet(index) as MachineComponentElement;
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

        public MachineComponentElement this[string key]
        {
            get
            {
                return BaseGet(key) as MachineComponentElement;
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
                return "MachineComponent";
            }
        }

        #region IEnumerable<MachineComponentElement> Members
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public new IEnumerator<MachineComponentElement> GetEnumerator()
        {
            int count = base.Count;

            for (int i = 0; i < count; i++)
            {
                yield return base.BaseGet(i) as MachineComponentElement;
            }
        }
        #endregion
    }
}
