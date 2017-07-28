using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Design;
using Isid.NJ.View.Widget;

namespace Isid.KKH.Common.KKHView.Common.Control
{
    /// <summary>
    /// Kkhボタンリストコントロール 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/02/20</description>
    ///       <description>IP Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KkhButtonList : ListControl
    {
        #region メンバ
        private FlowLayoutPanel _flpButtonList;

        #endregion メンバ

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        public KkhButtonList()
        {
            InitializeComponent();

            _flpButtonList = new FlowLayoutPanel();
            _flpButtonList.AutoSize = true;
            _flpButtonList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _flpButtonList.Dock = DockStyle.Fill;
            _flpButtonList.FlowDirection = FlowDirection.LeftToRight;
            _flpButtonList.TabStop = false;

            this.Controls.Add(_flpButtonList);
        }

        #endregion コンストラクタ

        #region パブリックメソッド

        /// <summary>
        /// 指定したインデックス位置にあるラジオボタンを選択します。 
        /// 既に選択されているラジオボタンが存在する場合は、処理を行いません。 
        /// </summary>
        /// <param name="index">ラジオボタンを選択する項目の、0 から始まるインデックス番号</param>
        public void InitializeSelection(int index)
        {
            if (this.Checked)
            {
                return;
            }

            NJRadioButton radioButton = (NJRadioButton)this.ButtonControls[index];
            radioButton.Checked = true;
        }

        /// <summary>
        /// コントロールに入力フォーカスを設定します。 
        /// </summary>
        /// <returns>入力フォーカス要求が成功した場合はtrue、それ以外はfalse</returns>
        public new bool Focus()
        {
            foreach (System.Windows.Forms.Control control in _flpButtonList.Controls)
            {
                NJRadioButton radioButton = (NJRadioButton)control;
                if (radioButton.Checked)
                {
                    return radioButton.Focus();
                }
            }
            return false;
        }

        #endregion パブリックメソッド

        #region プロテクトメソッド

        /// <summary>
        /// 指定したインデックス位置にあるオブジェクトのデータとデータ ソースの内容との同期をとり直します。 
        /// </summary>
        /// <param name="index">データを更新する項目の、0 から始まるインデックス番号</param>
        protected override void RefreshItem(int index)
        {
        }

        /// <summary>
        /// コレクション内の指定したオブジェクトの配列を設定します。 
        /// </summary>
        /// <param name="items">項目の配列</param>
        protected override void SetItemsCore(System.Collections.IList items)
        {
            this.SuspendLayout();

            _flpButtonList.Controls.Clear();

            for (int index = 0; index < items.Count; index++)
            {
                NJRadioButton radioButton = new NJRadioButton();
                radioButton.AutoCheck = true;
                radioButton.AutoSize = true;
                radioButton.TabIndex = index;

                radioButton.SuspendLayout();

                object item = items[index];

                if (item is DataRowView)
                {
                    DataRowView dataRowView = (DataRowView)item;
                    DataRow dataRow = dataRowView.Row;

                    if (!string.IsNullOrEmpty(base.DisplayMember))
                    {
                        radioButton.Text = (string)dataRow[this.GetMemberName(base.DisplayMember)];
                        radioButton.Name = (string)dataRow[this.GetMemberName(base.DisplayMember)];
                    }
                    if (!string.IsNullOrEmpty(this.ValueMember))
                    {
                        radioButton.Tag = (string)dataRow[this.GetMemberName(base.ValueMember)];
                    }
                    if (!string.IsNullOrEmpty(this.CheckedMember))
                    {
                        radioButton.Checked = (bool)dataRow[this.GetMemberName(this.CheckedMember)];
                    }
                    if (!string.IsNullOrEmpty(this.EnabledMember))
                    {
                        radioButton.Enabled = (bool)dataRow[this.GetMemberName(this.EnabledMember)];
                    }
                }

                radioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

                _flpButtonList.Controls.Add(radioButton);
            }

            this.ResumeLayout();
        }

        #endregion プロテクトメソッド

        #region プライベートメソッド

        /// <summary>
        /// Member名を取得します。 
        /// </summary>
        /// <param name="memberName">Member名</param>
        /// <returns>Member名</returns>
        private string GetMemberName(string memberName)
        {
            int lastIndex = memberName.LastIndexOf(".");
            if (lastIndex < 0)
            {
                return memberName;
            }
            else
            {
                return memberName.Substring(++lastIndex);
            }
        }

        #endregion プライベートメソッド

        #region プロパティ

        /// <summary>
        /// コントロール内に格納されているコントロールのコレクションを取得します。 
        /// </summary>
        public ControlCollection ButtonControls
        {
            get { return _flpButtonList.Controls; }
        }

        /// <summary>
        /// DataMemberです。 
        /// </summary>
        private string _dataMember;

        /// <summary>
        /// DataMemberを取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public string DataMember
        {
            get { return _dataMember; }
            set { _dataMember = value; }
        }

        /// <summary>
        /// CheckedMemberです。 
        /// </summary>
        private string _checkedMember;

        /// <summary>
        /// CheckedMemberを取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public string CheckedMember
        {
            get { return _checkedMember; }
            set { _checkedMember = value; }
        }

        /// <summary>
        /// EnabledMemberです。 
        /// </summary>
        private string _enabledMember;

        /// <summary>
        /// EnabledMemberを取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public string EnabledMember
        {
            get { return _enabledMember; }
            set { _enabledMember = value; }
        }

        /// <summary>
        /// 現在選択されている項目の 0 から始まるインデックス番号
        /// </summary>
        private int _selectedIndex;

        /// <summary>
        /// 現在選択されている項目の 0 から始まるインデックス番号を取得または設定します。 
        /// </summary>
        public override int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;

                if (value < 0)
                {
                    return;
                }

                if (_flpButtonList.Controls.Count == 0)
                {
                    return;
                }

                NJRadioButton radioButton = (NJRadioButton)_flpButtonList.Controls[value];

                BindingContext bindingContext = radioButton.BindingContext;
                if (bindingContext != null)
                {
                    BindingManagerBase bindingManagerBase = bindingContext[base.DataSource, this.DataMember];
                    bindingManagerBase.Position = value;
                }
            }
        }

        /// <summary>
        /// ラジオボタンが選択されるかどうかを示す値を取得します。 
        /// </summary>
        public bool Checked
        {
            get
            {
                foreach (System.Windows.Forms.Control control in _flpButtonList.Controls)
                {
                    NJRadioButton radioButton = (NJRadioButton)control;
                    if (radioButton.Checked)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Rgボタンリストコントロール内の選択されている項目の値を取得または設定します。 
        /// </summary>
        public object CheckedValue
        {
            get
            {
                foreach (System.Windows.Forms.Control control in _flpButtonList.Controls)
                {
                    NJRadioButton radioButton = (NJRadioButton)control;

                    if (radioButton.Checked)
                    {
                        return radioButton.Tag;
                    }
                }

                return null;
            }
            set
            {
                foreach (System.Windows.Forms.Control control in _flpButtonList.Controls)
                {
                    NJRadioButton radioButton = (NJRadioButton)control;
                    int index = _flpButtonList.Controls.IndexOf(radioButton);

                    BindingContext bindingContext = radioButton.BindingContext;
                    if (bindingContext != null)
                    {
                        BindingManagerBase bindingManagerBase = bindingContext[base.DataSource, this.DataMember];
                        DataRowView current = (DataRowView)bindingManagerBase.Current;

                        DataRowView dataRowView = current.DataView[index];
                        DataRow dataRow = dataRowView.Row;

                        // 値
                        object data = dataRow[this.GetMemberName(this.ValueMember)];
                        // データタイプ
                        Type type = dataRowView.DataView.Table.Columns[this.GetMemberName(this.ValueMember)].DataType;

                        if (System.Type.GetType("System.String") == type)
                        {
                            // System.String
                            if (((string)data).Equals((string)value))
                            {
                                radioButton.Checked = true;
                                return;
                            }
                        }
                    }
                }

                // 該当なしの場合は先頭のコントロールを選択 
                if (_flpButtonList.Controls.Count != 0)
                {
                    System.Windows.Forms.Control firstControl = _flpButtonList.Controls[0];
                    NJRadioButton firstRadioButton = (NJRadioButton)firstControl;
                    firstRadioButton.Checked = true;
                }
            }
        }

        #endregion

        #region イベント

        /// <summary>
        /// Checkedプロパティの値が変更された場合に発生します。 
        /// </summary>
        /// <param name="sender">ラジオボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            NJRadioButton radioButton = (NJRadioButton)sender;
            int index = _flpButtonList.Controls.IndexOf(radioButton);

            BindingContext bindingContext = radioButton.BindingContext;
            if (bindingContext != null)
            {
                BindingManagerBase bindingManagerBase = bindingContext[base.DataSource, this.DataMember];
                DataRowView current = (DataRowView)bindingManagerBase.Current;

                DataRowView dataRowView = current.DataView[index];
                DataRow dataRow = dataRowView.Row;
                dataRow[this.GetMemberName(this.CheckedMember)] = radioButton.Checked;

                if (radioButton.Checked)
                {
                    bindingManagerBase.Position = index;
                }
            }

            if (this.CheckedChanged != null)
            {
                this.CheckedChanged(sender, e);
            }
        }

        /// <summary>
        /// CheckedChangedEventHandlerです。 
        /// </summary>
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Checkedプロパティの値が変更された場合に発生します。 
        /// </summary>
        [Category("Rg")]
        public event CheckedChangedEventHandler CheckedChanged;

        #endregion イベント
    }
}
