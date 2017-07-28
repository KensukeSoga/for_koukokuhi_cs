using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class LionComboBoxItem
    {
        private string _code = "";
        private string _name = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        public LionComboBoxItem(string code, string name)
        {
            _code = code;
            _name = name;
        }

        //実際の値　
        //（ValueMemberに設定する文字列と同名にする） 
        /// <summary>
        /// 
        /// </summary>
        public string CODE
        {
            set
            {
                _code = value;
            }
            get
            {
                return _code;
            }
        }

        //表示名称
        //（DisplayMemberに設定する文字列と同名にする） 
        /// <summary>
        /// 
        /// </summary>
        public string NAME
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }
    }
}
