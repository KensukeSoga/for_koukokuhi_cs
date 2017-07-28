using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Epson.Utility
{
    public class EpsonComboBoxItem
    {
        private string _code = "";
        private string _name = "";

        public EpsonComboBoxItem(string code, string name)
        {
            _code = code;
            _name = name;
        }

        //実際の値　
        //（ValueMemberに設定する文字列と同名にする）
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
